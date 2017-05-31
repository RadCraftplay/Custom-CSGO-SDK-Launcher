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
