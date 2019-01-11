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
