using Distroir.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_SDK_Launcher
{
    public partial class Form1 : Form
    {
        //TODO: Improve tutorials
        public Form1()
        {
            //Load configuration
            Utils.CheckDirs();
            Config.Load();

            //Load profiles
            ProfileManager.LoadProfiles();

            //Check if it's first launch
            if (Config.TryReadInt("FirstLaunch") == 1)
            {
                //Create dialog
                var v = new Dialogs.FirstLaunchDialog();

                //Show dialog
                if (!(v.ShowDialog() == DialogResult.OK))
                {
                    //Inform user that he needs to select his csgo directory
                    MessageBox.Show("Can not continue. You need to select your csgo directory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Close application
                    Environment.Exit(0);
                }
            }

            //Set gamedir
            if (!string.IsNullOrEmpty(Config.TryReadString("CSGO_DIR")))
            {
                //Create profile
                Profile p = new Profile();
                p.ProfileName = "Counter-Strike: Global Offensive";
                p.GameDir = Config.TryReadString("CSGO_DIR");
                p.GameinfoDirName = "csgo";

                //Add profile to list
                ProfileManager.Profiles.Add(p);

                //Select profile
                Config.AddVariable("SelectedProfileId", 0);

                //Remove variable
                Config.RemoveVariable("CSGO_DIR");
            }

            //This is not first launch anymore
            Config.AddVariable("FirstLaunch", 0);

            //Create controls
            InitializeComponent();
        }

        #region Form events

        #region Button click events

        private void launchHammerButton_Click(object sender, EventArgs e)
        {
            //Utils.Launch("hammer.exe", "-nop4");
            Utils.TryLaunchTool(SDKApplication.Hammer);
        }

        private void launchModelViewerButton_Click(object sender, EventArgs e)
        {
            //Utils.Launch("hlmv.exe");
            Utils.TryLaunchTool(SDKApplication.HLMV);
        }

        private void launchFacePoserButton_Click(object sender, EventArgs e)
        {
            //Utils.Launch("hlfaceposer.exe", "-nop4");
            Utils.TryLaunchTool(SDKApplication.FacePoser);
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
            var d = new Dialogs.SettingsDialog();
            d.ShowDialog();
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save config
            Config.Save();
            //Save list of profiles
            ProfileManager.SaveProfiles();
        }

        #endregion
    }
}
