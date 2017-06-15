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
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    //TODO: Add skins
    //TODO: Add language selection
    //TODO: Add about tab
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            //Create controls
            InitializeComponent();
            //Apply settings to controls
            UpdateControls();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Create dialog
            var v = new ProfileListEditDialog();

            //Show dialog
            if (v.ShowDialog() == DialogResult.OK)
            {
                //Refresh profile list
                RefreshList();
            }
        }

        void UpdateControls()
        {
            //Refresh list of profiles
            RefreshList();

            displayCurrentlySelectedProfileCheckBox.Checked = Config.TryReadInt("DisplayCurrentProfileName") == 1;
        }

        void RefreshList()
        {
            //Clear item list
            profileListComboBox.Items.Clear();

            //Add profiles to ComboBox
            foreach (Profile p in ProfileManager.Profiles)
                profileListComboBox.Items.Add(p);

            //Set profile
            try
            {
                profileListComboBox.SelectedIndex = Config.TryReadInt("SelectedProfileId");
            }
            catch
            {
                //Do nothing
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Save settings
            //Save current profile ID
            Config.AddVariable("SelectedProfileId", profileListComboBox.SelectedIndex);

            //Save orther settings
            if (displayCurrentlySelectedProfileCheckBox.Checked)
                Config.AddVariable("DisplayCurrentProfileName", 1);
            else
                Config.AddVariable("DisplayCurrentProfileName", 0);

            //Close dialog
            Close();
        }
    }
}
