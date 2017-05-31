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
using System;
using System.Windows.Forms;

namespace Custom_SDK_Launcher.Dialogs
{
    public partial class EditItemDialog : Form
    {
        public Profile Profile;

        public EditItemDialog()
        {
            //Create profile
            Profile = new Profile();
            //Create controls
            InitializeComponent();
        }

        public EditItemDialog(Profile p)
        {
            //Set profile
            Profile = p;
            //We are now using this control to edit profile
            Text = "Edit profile";

            //Create controls
            InitializeComponent();

            //Set values
            nameTextBox.Text = Profile.ProfileName;
            gameDirTextBox.Text = Profile.GameDir;
            gameInfoTextBox.Text = Profile.GameinfoDirName;
            gameDirFolderBrowserDialog.SelectedPath = Profile.GameDir;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Save settings
            Profile.ProfileName = nameTextBox.Text;
            Profile.GameDir = gameDirTextBox.Text;
            Profile.GameinfoDirName = gameInfoTextBox.Text;

            //Close control
            DialogResult = DialogResult.OK;
            Close();
        }

        private void gameDirBrowseButton_Click(object sender, EventArgs e)
        {
            gameDirFolderBrowserDialog.SelectedPath = gameDirTextBox.Text;

            if (gameDirFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                gameDirTextBox.Text = gameDirFolderBrowserDialog.SelectedPath;
            }
        }
    }
}
