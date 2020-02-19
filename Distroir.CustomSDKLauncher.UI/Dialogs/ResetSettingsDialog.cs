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
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ResetSettingsDialog : Form
    {
        public ResetSettingsDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult agreement = AskToAgree();

            if (agreement == DialogResult.Yes)
            {
                if (gamesCheckBox.Checked)
                    File.Delete(DataManagers.GameListFilename);

                if (launcherCheckBox.Checked)
                    File.Delete(DataManagers.AppListFilename);

                if (otherCheckBox.Checked)
                    File.Delete(Configuration.Config.Destination);
                
                Environment.Exit(0);
            }
        }

        private DialogResult AskToAgree()
        {
            return MessageBox.Show("Selected settings will be reset. This can not be undone!\nAre you sure you want to continue?", "Resetting settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
