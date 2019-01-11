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
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ProfileListEditDialog : Form
    {
        /// <summary>
        /// Local copy of ProfileManager.Profiles
        /// </summary>
        public List<Profile> Profiles;

        public ProfileListEditDialog()
        {
            InitializeComponent();

            //Create copy of profile list
            Profiles = DataManagers.ProfileManager.Objects;
            LoadList();
        }

        void LoadList()
        {
            //For every profile on list
            foreach (Profile p in Profiles)
            {
                //Add ListViewItem
                AddIem(p);
            }
        }

        public void AddIem(Profile p)
        {
            //Create new ListViewItem
            ListViewItem i = new ListViewItem()
            {
                Name = p.ProfileName,
                Text = p.ProfileName,
                Tag = p
            };

            //And add it to ListView
            profileListView.Items.Add(i);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Show EditItemDialog
            var v = new EditItemDialog();

            if (v.ShowDialog() == DialogResult.OK)
            {
                //Add ListViewItem
                Profiles.Add(v.Profile);
                AddIem(v.Profile);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            //If user selected any items
            if (profileListView.SelectedItems.Count > 0)
            {
                //For every selected item
                for (int i = 0; i < profileListView.SelectedItems.Count; i++)
                {
                    //Remove item from list
                    Profiles.Remove((Profile)profileListView.SelectedItems[i].Tag);
                    //And remove it from control
                    profileListView.SelectedItems[i].Remove();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (profileListView.SelectedItems.Count > 0)
            {
                //Create instance of selected item
                var i = profileListView.SelectedItems[0];
                //Show EditItemDialog
                var v = new EditItemDialog((Profile)i.Tag);

                if (v.ShowDialog() == DialogResult.OK)
                {
                    //Set values
                    i.Name = v.Profile.ProfileName;
                    i.Text = v.Profile.ProfileName;
                    i.Tag = v.Profile;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Update profile list
            DataManagers.ProfileManager.Objects = Profiles;
            //Set dialog result
            DialogResult = DialogResult.OK;
            //Close dialog
            Close();
        }

        private void createFromTemplateButton_Click(object sender, EventArgs e)
        {
            //Show ChooseTemplateDialog
            var c = new ChooseTemplateDialog();
            c.Tag = this;
            c.ShowDialog();
        }
    }
}
