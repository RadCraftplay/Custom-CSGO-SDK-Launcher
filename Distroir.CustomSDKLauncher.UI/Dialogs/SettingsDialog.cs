/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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
using Distroir.CustomSDKLauncher.Core.Backups;
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs;
using Distroir.CustomSDKLauncher.Core.Launchers.Editable;
using Distroir.CustomSDKLauncher.Core.Launchers.Standard;
using Launcher = Distroir.CustomSDKLauncher.Core.Launchers.Launcher;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class SettingsDialog : Form
    {
        private readonly List<Launcher> Launchers = new List<Launcher>
        {
            new StandardLauncher(),
            new CustomizableLauncher(),
            new EditableLauncher()
        };

        public SettingsDialog()
        {
            var activeLauncherId = Config.ReadInt("LauncherType");
            
            InitializeComponent();
            UpdateControls();
            UpdateButtons(Launchers[activeLauncherId].Apps);
        }

        #region Controls

        void UpdateControls()
        {
            RefreshList(Config.TryReadInt("SelectedProfileId"));

            foreach (var launcher in Launchers)
            {
                var item = new ComboBoxItem(launcher.Name, launcher);
                launchersComboBox.Items.Add(item);
            }
            
            displayCurrentlySelectedGameCheckBox.Checked = Config.TryReadInt("DisplayCurrentProfileName") == 1;
            preLoadDataCheckBox.Checked = Config.TryReadInt("LoadDataAtStartup") == 1;
            disableFeedbackCheckBox.Checked = Config.TryReadBool("DisableFeedbackNotifications");
            ignoreGameMigrationConflictsCheckBox.Checked = Config.TryReadBool("IgnoreGameMigrationConflicts");
            launchersComboBox.SelectedIndex = Config.ReadInt("LauncherType");

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

        void RefreshList(int selectedIndex)
        {
            gameListComboBox.Items.Clear();

            foreach (Game g in DataManagers.GameManager.Objects)
                gameListComboBox.Items.Add(g);

            try
            {
                gameListComboBox.SelectedIndex = selectedIndex;
            }
            catch
            {
                //Do nothing
            }
        }

        #endregion

        #region Saving settings

        void SaveSettings()
        {
            Config.AddVariable("SelectedProfileId", gameListComboBox.SelectedIndex);
            Config.AddVariable("DisplayCurrentProfileName", BoolToInt(displayCurrentlySelectedGameCheckBox.Checked));
            Config.AddVariable("LoadDataAtStartup", BoolToInt(preLoadDataCheckBox.Checked));
            Config.AddVariable("DisableFeedbackNotifications", disableFeedbackCheckBox.Checked);
            Config.AddVariable("IgnoreGameMigrationConflicts", ignoreGameMigrationConflictsCheckBox.Checked);
            Config.AddVariable("LauncherType", launchersComboBox.SelectedIndex);
            
            Utils.TryReloadPathFormatterVars();

            DataManagers.GameManager.Save();
            DataManagers.AppManager.Save();
            DataManagers.CustomizableApplicationInfo.Save();
        }

        int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        #endregion

        #region Events

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var gameListEditDialog = new GameListEditDialog(DataManagers.GameManager.Objects);

            if (gameListEditDialog.ShowDialog() == DialogResult.OK)
            {
                Game selectedGame = DataManagers.GameManager.Objects[gameListComboBox.SelectedIndex];
                List<Game> newListOfGames = gameListEditDialog.Games;

                int selectedIndex = FindOutSelectedIndex(
                    selectedGame,
                    newListOfGames);
                DataManagers.GameManager.Objects = newListOfGames;
                RefreshList(selectedIndex);
            }
        }

        #region Finding selected game

        private int FindOutSelectedIndex(Game activeGame, List<Game> games)
        {
            var mostLikelySelectedGameId = games
                .OrderByDescending(game => CalculateMatchScore(activeGame, (Game)game))
                .Select(game => games.IndexOf(game))
                .First();

            return mostLikelySelectedGameId;
        }

        private object CalculateMatchScore(Game activeGame, Game comparedGame)
        {
            int matchScore = 0;

            if (activeGame.GameDir == comparedGame.GameDir)
                matchScore++;
            if (activeGame.GameinfoDirName == comparedGame.GameinfoDirName)
                matchScore++;
            if (activeGame.Name == comparedGame.Name)
                matchScore++;

            return matchScore;

        }

        #endregion

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            SaveSettings();
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
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Backup files|*.dbak";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Config.Save();
                    DataManagers.GameManager.Save();

                    BackupManager m = new BackupManager(sfd.FileName);
                    m.Backup();
                }
            }
        }

        private void restoreBackupButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup files|*.dbak";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    BackupManager m = new BackupManager(ofd.FileName);
                    m.Restore();
                    m.Dispose();

                    Config.Load();
                    DataManagers.GameManager.Load();
                    DataManagers.AppManager.Load();
                    DataManagers.CustomizableApplicationInfo.Load();
                    UpdateControls();
                    
                    var activeLauncherId = Config.ReadInt("LauncherType");
                    UpdateButtons(Launchers[activeLauncherId].Apps);
                }
            }
        }

        private void ResetSettingsButton_Click(object sender, EventArgs e)
        {
            var dialog = new ResetSettingsDialog();
            dialog.ShowDialog();
        }

        private void launcherButtonEdit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var app = button?.Tag as IApp;
            
            if (app is IConfigurableApp configurableApp)
                if (configurableApp.Configure())
                    UpdateButton(app, button);
        }

        private void sendFeedbackButton_Click(object sender, EventArgs e)
        {
            //Open survey URL in default browser
            Core.Feedback.FeedbackFetcher.SendFeedback();
        }

        #endregion

        #region AppLauncher

        void UpdateButtons(List<IApp> apps)
        {
            if (apps == null || apps.Count != 3)
                return;

            UpdateButton(apps[0], launcherEditButton1);
            UpdateButton(apps[1], launcherEditButton2);
            UpdateButton(apps[2], launcherEditButton3);
        }

        private void UpdateButton(IApp app, Button button)
        {
            var enabled = app is IConfigurableApp;
            
            ApplyDisplayableItem(app.DisplayableItem, button);
            button.Tag = app;
            button.Enabled = enabled;
        }

        private void ApplyDisplayableItem(IDisplayableItem item, Button button)
        {
            button.Text = item.Name;
            button.Image = item.Icon;
        }

        List<IApp> GetUpdatedAppList()
        {
            var apps = new List<IApp>();
            
            apps.Add((IApp)launcherEditButton1.Tag);
            apps.Add((IApp)launcherEditButton2.Tag);
            apps.Add((IApp)launcherEditButton3.Tag);
            
            return apps;
        }

        #endregion

        private void thirdPartyLibrariesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dialog = new ThirdPartyLicensesDialog();
            dialog.ShowDialog();
        }

        private void launchersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = launchersComboBox.SelectedItem as ComboBoxItem;
            var launcher = item?.Tag as Launcher;

            UpdateButtons(launcher?.Apps);
        }
    }

    internal class ComboBoxItem
    {
        private string Name { get; }
        public object Tag { get; }

        public ComboBoxItem(string name, object tag)
        {
            Name = name;
            Tag = tag;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
