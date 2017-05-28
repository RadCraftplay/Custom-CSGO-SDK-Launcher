using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Custom_SDK_Launcher.Dialogs
{
    //TODO: Add comments
    public partial class ProfileListEditDialog : Form
    {
        /// <summary>
        /// Local copy of ProfileManager.Profiles
        /// </summary>
        List<Profile> Profiles;

        public ProfileListEditDialog()
        {
            InitializeComponent();

            //Create copy of profile list
            Profiles = ProfileManager.Profiles;
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

        void AddIem(Profile p)
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

        private void addButton_Click(object sender, EventArgs e) //TODO: Add button action
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

        private void editButton_Click(object sender, EventArgs e) //TODO: Edit button action
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

        private void okButton_Click(object sender, EventArgs e)
        {
            //Update profile list
            ProfileManager.Profiles = Profiles;
            //Close dialog
            Close();
        }
    }
}
