﻿/*
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
using Distroir.CustomSDKLauncher.Core.CommunityContent;
using Distroir.CustomSDKLauncher.Core.Feedback;
using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Migrators;
using Distroir.CustomSDKLauncher.Core.Utilities;
using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers;
using Launcher = Distroir.CustomSDKLauncher.Core.Launcher;

namespace Distroir.CustomSDKLauncher.UI
{
    public partial class Form1 : Form
    {
        private Core.Launchers.Launcher _launcher;
        
        public Form1()
        {
            //Load configuration
            Utils.CheckDirs();
            Config.Load();
            //LanguageManager.LoadLanguageInfo();

            MigrateOldFiles();

            LoadData();

            //Unused: Load theme
            //Reason: Themes on winforms do not look good
            //UIThemeManager.LoadThemes();
            //UIThemeManager.LoadCurrentTheme();

            //Check if it's first launch
            CheckIfItsFirstLaunch();

            //Migrate csgo directory from first version of Custom SDK Launcher
            //It happens only, when you are launching newer version for the first time
            //And you had previously used version 1
            SetCsgoDirectoryFromConfig();

            //This is not first launch anymore
            Config.AddVariable("FirstLaunch", 0);

            //Create controls
            InitializeComponent();

            //Update controls
            AppUtils.UpdateButtons(new Button[]
                {
                    launchHammerButton,
                    launchModelViewerButton,
                    launchFacePoserButton
                });
            UpdateToolsGroupBoxText();
            ApplyLauncherSettings();

            //Unused: Apply theme to UI
            //ApplyTheme();

            //Ask for feedback
            System.Threading.Tasks.Task.Factory.StartNew(AskForFeedback);
        }

        private void MigrateOldFiles()
        {
            IMigrator m = new GameMigrator();

            if (m.RequiresMigration())
                m.Migrate();
        }

        private void LoadData()
        {
            int LoadAtStartup, useNewLauncher;

            //Games
            DataManagers.GameManager.TryLoad();
            //Reloads list of variables used to format paths
            Utils.TryReloadPathFormatterVars();
            
            //Load application list
            if (!DataManagers.AppManager.TryLoad())
                AppUtils.CreateApplications();

            //Try to load data settings
            if (!Config.TryReadInt("LoadDataAtStartup", out LoadAtStartup))
            {
                LoadAtStartup = 0;
                Config.AddVariable("LoadDataAtStartup", 0);
            }

            //Load less important data on startup
            if (LoadAtStartup == 1)
            {
                DataManagers.TemplateManager.Load();
                DataManagers.TutorialManager.Load();
                ContentManager.LoadContentGroups();
            }

            if (!Config.TryReadInt("UseNewLauncher", out useNewLauncher))
            {
                useNewLauncher = 0;
                Config.AddVariable("UseNewLauncher", 1);
            }
        }

        private void ApplyLauncherSettings()
        {
            bool useNewLauncher = Config.ReadInt("UseNewLauncher") == 1;
            _launcher = useNewLauncher ? (Core.Launchers.Launcher) new CustomizableLauncher() : new StandardLauncher();
        }

        #region Form events

        #region Button click events
        
        private void launchAppOneButton_Click(object sender, EventArgs e)
        {
            if (Utils.TryGetSelectedGame(out Game game))
                _launcher.Launch(0, game);
        }
        
        private void launchAppTwoButton_Click(object sender, EventArgs e)
        {
            if (Utils.TryGetSelectedGame(out Game game))
                _launcher.Launch(1, game);
        }
        
        private void launchAppThreeButton_Click(object sender, EventArgs e)
        {
            if (Utils.TryGetSelectedGame(out Game game))
                _launcher.Launch(2, game);
        }

        private void fmponeButton_Click(object sender, EventArgs e)
        {
            Utils.ShellLaunch("https://www.youtube.com/channel/UCrVkmwv-AHBAo-92OeSh9YQ/videos");
        }

        private void topHattWaffleButton_Click(object sender, EventArgs e)
        {
            Utils.ShellLaunch("https://www.youtube.com/playlist?list=PL-454Fe3dQH0WCzAsmydsr24NFaFrNC_h");
        }

        private void csgoSdkButton_Click(object sender, EventArgs e)
        {
            Utils.ShellLaunch("https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Level_Creation");
        }

        private void kliksButton_Click(object sender, EventArgs e)
        {
            Utils.ShellLaunch("https://www.youtube.com/playlist?list=PLfwtcDG7LpxF7-uH_P9La76dgCMC_lfk3");
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var settingsDialog = new Dialogs.SettingsDialog();

            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                ApplyLauncherSettings();
                UpdateToolsGroupBoxText();
            }
        }

        private void moreTutorialsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var v = new Dialogs.CommunityContentBrowserDialog();
            v.ShowDialog();
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save config
            Config.Save();
            //Save list of games
            DataManagers.GameManager.Save();
        }

        #endregion

        #region Methods

        void CheckIfItsFirstLaunch()
        {
            if (Config.TryReadInt("FirstLaunch") == 1)
            {
                //Create dialog
                var v = new Dialogs.FirstLaunchDialog();

                //Show dialog
                if (!(v.ShowDialog() == DialogResult.OK))
                {
                    //If user closes dialog without selecting csgo directory
                    //Inform user that he needs to select his csgo directory
                    MessageBox.Show("Can not continue. You need to create your first game", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Cannot continue
                    //Close application
                    Environment.Exit(0);
                }
            }
        }

        void SetCsgoDirectoryFromConfig()
        {
            //Set gamedir
            if (!string.IsNullOrEmpty(Config.TryReadString("CSGO_DIR")))
            {
                Game p = new Game();
                p.Name = "Counter-Strike: Global Offensive";
                p.GameDir = Config.TryReadString("CSGO_DIR");
                p.GameinfoDirName = "csgo";

                DataManagers.GameManager.Objects.Add(p);
                Config.AddVariable("SelectedProfileId", 0);
                Config.RemoveVariable("CSGO_DIR");
            }
        }

        /// <summary>
        /// Asks for feedback
        /// </summary>
        void AskForFeedback()
        {
            bool disableFeedback = false;

            //Set default value
            if (!Config.TryReadBool("DisableFeedbackNotifications", out disableFeedback))
            {
                disableFeedback = false;
                Config.AddVariable("DisableFeedbackNotifications", disableFeedback);
                
            }

            //Ask for feedback
            if (!disableFeedback)
            {
                FeedbackFetcher f = new FeedbackFetcher();
                f.Activate();
            }
        }

        #region Utilies

        string GetCurrentGameName()
        {
            Utils.TryGetSelectedGame(out Game g);
            return g.Name;
        }

        /// <summary>
        /// Changes text inside toolsGroupBox control
        /// </summary>
        /// <param name="rm">Resource manager</param>
        void UpdateToolsGroupBoxText()
        {
            if (Config.TryReadInt("DisplayCurrentProfileName") == 1 && !string.IsNullOrEmpty(GetCurrentGameName()))
            {
                //Set text
                string text = string.Format("Tools - {0}", GetCurrentGameName());
                text = CutStringIfTooLong(text, 40);
                toolsGroupBox.Text = text;
            }
            else
            {
                //Set text
                toolsGroupBox.Text = "Tools";
            }
        }

        /// <summary>
        /// Cuts string if it's too long
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="length">Maximal length of string</param>
        /// <returns></returns>
        string CutStringIfTooLong(string s, int length)
        {
            if (s.Length > length)
            {
                //Shorten string
                char[] buffer = new char[length];
                s.CopyTo(0, buffer, 0, length);
                //Get string from buffer
                s = charArrayToString(buffer) + "...";
                return s;
            }

            //String is the same, return it
            return s;
        }

        /// <summary>
        /// Converts char array to string
        /// </summary>
        /// <param name="array">Char array</param>
        /// <returns></returns>
        string charArrayToString(char[] array)
        {
            string returnvalue = string.Empty;

            foreach (char c in array)
                returnvalue += c;

            return returnvalue;
        }

        #endregion

        #endregion
    }
}
