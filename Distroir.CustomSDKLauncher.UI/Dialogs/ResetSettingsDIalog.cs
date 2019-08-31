using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ResetSettingsDialog : Form
    {
        public ResetSettingsDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult agreement = AskToAgree();

            if (agreement == DialogResult.Yes)
            {
                if (gamesCheckBox.Checked)
                    File.Delete(DataManagers.GameListFilename);

                if (launcherCheckBox.Checked)
                    File.Delete(DataManagers.AppListFilename);

                if (otherCheckBox.Checked)
                    File.Delete(Configuration.Config.destination);

                Environment.Exit(0);
            }
        }

        private DialogResult AskToAgree()
        {
            return MessageBox.Show("Selected settings will be reset. This can not be undone!\nAre you sure you want to continue?", "Resetting settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
