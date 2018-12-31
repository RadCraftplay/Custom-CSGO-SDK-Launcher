using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    public partial class SteamAppConfigurationDialog : Form
    {
        public string AppId => idTextBox.Text;
        public string AppName => nameTextBox.Text;

        public SteamAppConfigurationDialog()
        {
            InitializeComponent();
        }

        private void idInfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.TryLaunch("https://steamdb.info/apps/");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        bool ValidateInput()
        {
            if (idTextBox.Text.Length < 1 || nameTextBox.Text.Length < 1)
            {
                Utilities.MessageBoxes.Error("At least one field is empty!");
                return false;
            }
            if (!ulong.TryParse(idTextBox.Text, out ulong foo))
            {
                Utilities.MessageBoxes.Error("App id can contain only digits");
                return false;
            }

            return true;
        }

        private void tipLabel_Click(object sender, EventArgs e)
        {
            idTextBox.Focus();
        }

        private void idTextBox_Enter(object sender, EventArgs e)
        {
            tipLabel.Hide();
        }

        private void idTextBox_Leave(object sender, EventArgs e)
        {
            if (idTextBox.Text.Length < 1)
            {
                tipLabel.Show();
            }
        }
    }
}
