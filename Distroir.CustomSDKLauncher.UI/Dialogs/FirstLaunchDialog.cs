/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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