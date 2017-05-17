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
        public Form1()
        {
            Utils.CheckDirs();
            Config.Load();

            if (Config.TryReadInt("FirstLaunch") == 1)
            {
                MessageBox.Show(string.Format("Click on {0}Settings{0} button, and select your {0}Counter-Strike: Global Offensive{0} directory", '"'), "Custom SDK launcher");
            }

            Utils.UpdateGamedirs((string)Config.TryReadString("CSGO_DIR"));
            Config.AddVariable("FirstLaunch", 0);

            InitializeComponent();
        }

        #region Button click events

        private void launchHammerButton_Click(object sender, EventArgs e)
        {
            Utils.Launch("hammer.exe", "-nop4");
        }

        private void launchModelViewerButton_Click(object sender, EventArgs e)
        {
            Utils.Launch("hlmv.exe");
        }

        private void launchFacePoserButton_Click(object sender, EventArgs e)
        {
            Utils.Launch("hlfaceposer.exe", "-nop4");
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
            var d = new SettingsDialog();
            d.ShowDialog();
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Save();
        }
    }
}
