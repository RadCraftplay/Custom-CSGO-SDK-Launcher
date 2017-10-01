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

            //Load templates
            TemplateManager.LoadTemplates();

            //Reload list
            ReloadList();

            //Change game directory
            directoryTextBox.Text = Utils.CombineDefaultGameDirName(TemplateManager.Templates[0].GameDirName);
        }

        /// <summary>
        /// Reloads list of templates inside combo box
        /// </summary>
        void ReloadList()
        {
            //Clear list of items
            gameComboBox.Items.Clear();

            //Add templates
            foreach (Template t in TemplateManager.Templates)
            {
                gameComboBox.Items.Add(t);
            }

            //Select first item
            gameComboBox.SelectedIndex = 0;
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
            //Prevent user from editing data
            Enabled = false;

            //Simple mode
            if (simpleRadioButton.Checked)
            {

                //Check if directory exists
                if (!Directory.Exists(directoryTextBox.Text))
                {
                    //Inform user that directory does not exist
                    MessageBox.Show("Directory does not exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Re-enable control
                    Enabled = true;
                    //Skip rest of the method
                    return;
                }

                //Create profile
                Profile p = ((Template)gameComboBox.Items[gameComboBox.SelectedIndex]).ToProfile(gameDirectoryTextBox.Text);

                //Add profile to list
                ProfileManager.Profiles.Add(p);
            }
            else //Advanced mode
            {
                if (profileNameTextBox.Text.Length == 0 ||
                    gameDirectoryTextBox.Text.Length == 0 ||
                    gameinfoDirectoryTextBox.Text.Length == 0)
                {
                    //Inform user that he need to fill all fields
                    MessageBox.Show("You need to fill all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Re-enable control
                    Enabled = true;
                    //Skip rest of the method
                    return;
                }

                //Create profile
                Profile p = new Profile();
                p.ProfileName = profileNameTextBox.Text;
                p.GameDir = gameDirectoryTextBox.Text;
                p.GameinfoDirName = gameinfoDirectoryTextBox.Text;

                //Add profile to list
                ProfileManager.Profiles.Add(p);
            }

            //Select profile
            Config.AddVariable("SelectedProfileId", 0);

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

        private void radioButton_Checked(object sender, EventArgs e)
        {
            toggleControls((RadioButton)sender == simpleRadioButton);
        }

        /// <summary>
        /// Toggles Control.Enabled flag
        /// </summary>
        /// <param name="simple">User checked simple configuration radio button</param>
        void toggleControls(bool simple)
        {
            //Simple configuration controls
            simpleLabel1.Enabled = simple;
            simpleLabel2.Enabled = simple;
            gameComboBox.Enabled = simple;
            directoryTextBox.Enabled = simple;
            selectDirectoryButton.Enabled = simple;

            //Advanced configuration controls
            advancedLabel1.Enabled = !simple;
            advancedLabel2.Enabled = !simple;
            advancedLabel3.Enabled = !simple;
            profileNameTextBox.Enabled = !simple;
            gameDirectoryTextBox.Enabled = !simple;
            selectDirectoryAdvancedButton.Enabled = !simple;
            gameinfoDirectoryTextBox.Enabled = !simple;
        }

        private void gameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change game directory
            directoryTextBox.Text = Utils.CombineDefaultGameDirName(TemplateManager.Templates[gameComboBox.SelectedIndex].GameDirName);
        }

        private void selectDirectoryAdvancedButton_Click(object sender, EventArgs e)
        {
            //Create FolderBrowserDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //Set path
            fbd.SelectedPath = gameDirectoryTextBox.Text;

            //Show dialog
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //Set text inside textBox
                gameDirectoryTextBox.Text = fbd.SelectedPath;
            }
        }
    }
}
