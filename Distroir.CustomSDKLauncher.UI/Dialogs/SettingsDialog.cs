/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Backups;
using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class SettingsDialog : Form
    {
        Form1 formReference;
        List<AppInfo> appListReference = new List<AppInfo>();

        public SettingsDialog(Form1 f)
        {
            //Add references
            formReference = f;
            appListReference = DataManagers.AppManager.Objects;
            //Create controls
            InitializeComponent();
            //Apply settings to controls
            UpdateControls();
            UpdateButtons();
        }

        #region Controls

        void UpdateControls()
        {
            //Refresh list of games
            RefreshList();
            //Update controls
            displayCurrentlySelectedGameCheckBox.Checked = Config.TryReadInt("DisplayCurrentProfileName") == 1;
            preLoadDataCheckBox.Checked = Config.TryReadInt("LoadDataAtStartup") == 1;
            useNewLauncherCheckBox.Checked = Config.TryReadInt("UseNewLauncher") == 1;
            disableFeedbackCheckBox.Checked = Config.TryReadBool("DisableFeedbackNotifications");
            ignoreGameMigrationConflictsCheckBox.Checked = Config.TryReadBool("IgnoreGameMigrationConflicts");

            launcherEditButton1.Enabled = useNewLauncherCheckBox.Checked;
            launcherEditButton2.Enabled = useNewLauncherCheckBox.Checked;
            launcherEditButton3.Enabled = useNewLauncherCheckBox.Checked;
            actionChangeLabel.Visible = useNewLauncherCheckBox.Checked;

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
            gameListComboBox.Items.Clear();

            foreach (Game g in DataManagers.GameManager.Objects)
                gameListComboBox.Items.Add(g);

            try
            {
                gameListComboBox.SelectedIndex = Config.TryReadInt("SelectedProfileId");
            }
            catch
            {
                //Do nothing
            }
        }

        #endregion

        #region Saving settings

        /// <summary>
        /// Saves settings
        /// </summary>
        void SaveSettings()
        {
            Config.AddVariable("SelectedProfileId", gameListComboBox.SelectedIndex);
            Config.AddVariable("DisplayCurrentProfileName", BoolToInt(displayCurrentlySelectedGameCheckBox.Checked));
            Config.AddVariable("LoadDataAtStartup", BoolToInt(preLoadDataCheckBox.Checked));
            Config.AddVariable("UseNewLauncher", BoolToInt(useNewLauncherCheckBox.Checked));
            Config.AddVariable("DisableFeedbackNotifications", disableFeedbackCheckBox.Checked);
            Config.AddVariable("IgnoreGameMigrationConflicts", ignoreGameMigrationConflictsCheckBox.Checked);

            Utils.TryReloadPathFormatterVars();
            DataManagers.AppManager.Objects = appListReference;
            formReference.ApplyLauncherSettings();

            DataManagers.AppManager.Save();
        }

        int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        #endregion

        #region Events

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create dialog
            var v = new GameListEditDialog();

            //Show dialog
            if (v.ShowDialog() == DialogResult.OK)
            {
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

        private void gamebananaLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.ShellLaunch("https://gamebanana.com/tools/6145");
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.ShellLaunch("https://github.com/RadCraftplay/Custom-CSGO-SDK-Launcher");
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
                    DataManagers.GameManager.Save();

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
                    m.Dispose();

                    //Restore settings
                    Config.Load();
                    DataManagers.GameManager.Load();
                    DataManagers.AppManager.Load();
                    appListReference = DataManagers.AppManager.Objects;
                    UpdateControls();
                    UpdateButtons();
                }
            }
        }

        private void launcherButtonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            //Edit button AppInfo
            var d = new AppSelectorDialog();
            if (d.ShowDialog() == DialogResult.OK)
                b.Tag = d.selectedAppInfo;

            //Update application list
            UpdateAppList();
            //Update button actions in main window
            UpdateButtons();
        }

        private void useNewLauncherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            launcherEditButton1.Enabled = useNewLauncherCheckBox.Checked;
            launcherEditButton2.Enabled = useNewLauncherCheckBox.Checked;
            launcherEditButton3.Enabled = useNewLauncherCheckBox.Checked;
            actionChangeLabel.Visible = useNewLauncherCheckBox.Checked;
        }

        private void sendFeedbackButton_Click(object sender, EventArgs e)
        {
            //Open survey URL in default browser 
            Core.Feedback.FeedbackFetcher.SendFeedback();
        }

        #endregion

        #region AppLauncher

        void UpdateButtons()
        {
            AppUtils.UpdateButtons(appListReference, new Button[]
            {
                launcherEditButton1,
                launcherEditButton2,
                launcherEditButton3
            });
        }

        void UpdateAppList()
        {
            appListReference.Clear();
            appListReference.Add((AppInfo)launcherEditButton1.Tag);
            appListReference.Add((AppInfo)launcherEditButton2.Tag);
            appListReference.Add((AppInfo)launcherEditButton3.Tag);
        }

        #endregion
    }
}
