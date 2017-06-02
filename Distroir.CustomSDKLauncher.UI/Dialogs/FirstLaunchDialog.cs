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
using System.IO;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class FirstLaunchDialog : Form
    {
        public FirstLaunchDialog()
        {
            InitializeComponent();
        }

        private void selectDirectoryButton_Click(object sender, EventArgs e)
        {
            //Create FolderBrowserDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //Set path
            fbd.SelectedPath = directoryTextBox.Text;

            //Show dialog
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //Set text inside textBox
                directoryTextBox.Text = fbd.SelectedPath;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Prevent user form changing text stored inside textBox
            directoryTextBox.Enabled = false;

            //Check if directory exists
            if (!Directory.Exists(directoryTextBox.Text))
            {
                //Inform user that directory does not exist
                MessageBox.Show("Directory does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Re-enable textBox
                directoryTextBox.Enabled = true;
                //Skip rest of the method
                return;
            }

            //Create profile
            Profile p = new Profile();
            p.ProfileName = "Counter-Strike: Global Offensive";
            p.GameDir = directoryTextBox.Text;
            p.GameinfoDirName = "csgo";

            //Add profile to list
            ProfileManager.Profiles.Add(p);

            //Select profile
            Config.AddVariable("SelectedProfileId", 0);

            //Re-enable textBox
            directoryTextBox.Enabled = true;

            //Set dialog result
            DialogResult = DialogResult.OK;

            //Close dialog
            Close();
        }

        private void directoryTextBox_TextChanged(object sender, EventArgs e)
        {
            //Disable button if textBox is empty
            if (directoryTextBox.Text.Length == 0)
                okButton.Enabled = false;
            else
                okButton.Enabled = true;
        }
    }
}
