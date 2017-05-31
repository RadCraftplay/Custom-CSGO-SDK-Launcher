using Distroir.Configuration;
using System;
using System.Windows.Forms;

namespace Custom_SDK_Launcher.Dialogs
{
    //TODO: Add skins
    //TODO: Add language selection
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            //Create controls
            InitializeComponent();
            //Refresh list of profiles
            RefreshList();
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
            //Save selected profile ID
            Config.AddVariable("SelectedProfileId", profileListComboBox.SelectedIndex);
            //Close dialog
            Close();
        }
    }
}
