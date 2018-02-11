/*
Custom SDK Launcher
Copyright (C) 2017 Distroir

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using Distroir.Configuration;
using Distroir.CustomSDKLauncher.Core;
using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    //TODO: Add language selection
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            //Create controls
            InitializeComponent();
            //Apply settings to controls
            UpdateControls();
            //Apply translations
            //TODO: Remove comment
            //ApplyTranslations();
        }

        void ApplyTranslations()
        {
            ResourceManager rm = new ResourceManager(LanguageResourcesList.SettingsDialogRes, typeof(Form1).Assembly);

            //SettingsDialog
            Text = rm.GetString("settingsDialog_text", LanguageManager.Culture);

            //Tab pages
            profilesTabPage.Text = rm.GetString("profilesTabPage_text", LanguageManager.Culture);
            aboutTabPage.Text = rm.GetString("aboutTabPage_text", LanguageManager.Culture);
            backupTabPage.Text = rm.GetString("backupTabPage_text", LanguageManager.Culture);

            //ProfilesTabPage
            profileLabel.Text = rm.GetString("profileLabel_text", LanguageManager.Culture);

            profileListComboBox.Location = new System.Drawing.Point(
                Convert.ToInt32(rm.GetString("profileListComboBox_X", LanguageManager.Culture)),
                profileListComboBox.Location.Y);
            profileListComboBox.Size = new System.Drawing.Size(
                Convert.ToInt32(rm.GetString("profileListComboBox_length", LanguageManager.Culture)),
                profileListComboBox.Size.Height);

            editListOfProfilesLinkLabel.Text = rm.GetString("editListOfProfilesLinkLabel_text", LanguageManager.Culture);
            editListOfProfilesLinkLabel.Location = new System.Drawing.Point(
                Convert.ToInt32(rm.GetString("editListOfProfilesLinkLabel_X", LanguageManager.Culture)),
                editListOfProfilesLinkLabel.Location.Y);

            displayCurrentlySelectedProfileCheckBox.Text = rm.GetString("displayCurrentlySelectedProfileCheckBox_text", LanguageManager.Culture);
            saveButton.Text = rm.GetString("saveButton_text", LanguageManager.Culture);

            //backupTabPage
            settingsAndProfilesGroupBox.Text = rm.GetString("settingsAndProfilesGroupBox_text", LanguageManager.Culture);
            createBackupButton.Text = rm.GetString("createBackupButton_text", LanguageManager.Culture);
            restoreBackupButton.Text = rm.GetString("restoreBackupButton_text", LanguageManager.Culture);
        }

        void UpdateControls()
        {
            //Refresh list of profiles
            RefreshList();
            //Update controls
            displayCurrentlySelectedProfileCheckBox.Checked = Config.TryReadInt("DisplayCurrentProfileName") == 1;
            preLoadDataCheckBox.Checked = Config.TryReadInt("LoadDataAtStartup") == 1;
            //Update version info
            copyrightLabel.Text = GetCopyright();
            versionLabel.Text = string.Format("Version: {0}", ProductVersion);
        }

        private string GetCopyright()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(AssemblyCopyrightAttribute))
                {
                    AssemblyCopyrightAttribute aca = (AssemblyCopyrightAttribute)o;
                    return aca.Copyright;
                }
            }
            return string.Empty;
        }

        void RefreshList()
        {
            //Clear item list
            profileListComboBox.Items.Clear();

            //Add profiles to ComboBox
            foreach (Profile p in ProfileManager.Profiles)
                profileListComboBox.Items.Add(p);

            //Set profile
            try
            {
                profileListComboBox.SelectedIndex = Config.TryReadInt("SelectedProfileId");
            }
            catch
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Saves settings
        /// </summary>
        void SaveSettings()
        {
            //Save current profile ID
            Config.AddVariable("SelectedProfileId", profileListComboBox.SelectedIndex);

            //Save orther settings
            Config.AddVariable("DisplayCurrentProfileName", BoolToInt(displayCurrentlySelectedProfileCheckBox.Checked));
            Config.AddVariable("LoadDataAtStartup", BoolToInt(preLoadDataCheckBox.Checked));
        }

        int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        #region Events

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create dialog
            var v = new ProfileListEditDialog();

            //Show dialog
            if (v.ShowDialog() == DialogResult.OK)
            {
                //Refresh profile list
                RefreshList();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Save settings
            SaveSettings();

            //Close dialog
            Close();
        }

        private void ViewLicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var l = new LicenseDialog(Resources.Licenses.License__Only_custom_sdk_launcher_);
            l.ShowDialog();
        }

        private void gpl3LicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.ShellLaunch("https://www.gnu.org/licenses/gpl-3.0.en.html");
        }

        private void fugueIconsSetLicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var l = new LicenseDialog(Resources.Licenses.FUGUE_README);
            l.ShowDialog();
        }

        private void createBackupButton_Click(object sender, EventArgs e)
        {
            //Create dialog
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                //Set filter
                sfd.Filter = "Backup files|*.dbak";

                //If User pressed ok
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //Save settings
                    Config.Save();
                    ProfileManager.SaveProfiles();

                    //Do backup
                    BackupManager m = new BackupManager(sfd.FileName);
                    m.Backup();
                }
            }
        }

        private void restoreBackupButton_Click(object sender, EventArgs e)
        {
            //Create dialog
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //Set filter
                ofd.Filter = "Backup files|*.dbak";

                //If User pressed ok
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Restore backup
                    BackupManager m = new BackupManager(ofd.FileName);
                    m.Restore();

                    //Restore settings
                    Config.Load();
                    ProfileManager.LoadProfiles();
                    UpdateControls();
                }
            }
        }

        #endregion
    }
}
