using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Steam;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class FirstLaunchDialog : Form
    {
        public List<Game> CreatedGames { get; set; } = new List<Game>();
        
        public FirstLaunchDialog()
        {
            InitializeComponent();
        }

        private void radioButton_MouseDown(object sender, MouseEventArgs e)
        {
            UncheckOtherCheckboxes(sender as CheckBox);
        }

        private void radioButton_KeyDown(object sender, KeyEventArgs e)
        {
            UncheckOtherCheckboxes(sender as CheckBox);
        }

        private void UncheckOtherCheckboxes(CheckBox sender)
        {
            foreach (Control control in Controls)
                if (control is CheckBox checkBox)
                    if (checkBox != sender)
                        checkBox.Checked = false;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            if (manualDetectionRadioButton.Checked)
            {
                var dialog = new SetupFirstGameDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                    CreatedGames.Add(dialog.PromptedGame);
            }
            else
                CreatedGames = SteamGameFinder.GetSupportedSteamGames().ToList();

            if (CreatedGames.Count > 0)
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}