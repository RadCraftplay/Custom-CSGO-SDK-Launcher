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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    public partial class CustomAppConfigurationDialog : Form
    {
        public AppInfo info = null;

        public CustomAppConfigurationDialog()
        {
            InitializeComponent();
        }

        #region Events

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Check if everything is ok
            if (pathTextBox.Text == string.Empty)
            {
                MessageBoxes.Warning("Path is empty!");
                return;
            }
            if (nameTextBox.Text == string.Empty)
            {
                MessageBoxes.Warning("Name is empty!");
                return;
            }

            //Set new AppInfo
            AppInfo i = new AppInfo();
            i.Path = pathTextBox.Text;
            i.DisplayText = nameTextBox.Text;
            i.Icon = iconSelector.Icon;

            if (argumentsCheckBox.Checked)
            {
                i.Arguments = argumentsTextBox.Text;
                i.UseCustomArguments = true;
            }

            if (customWorkingDirectoryCheckBox.Checked)
            {
                i.CustomWorkingDirectory = customWorkingDirectoryTextBox.Text;
                i.UseCustomWorkingDirectory = true;
            }

            info = i;

            //Everything is ok - close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e)
        {
            iconSelector.TrySetDefaultSource(pathTextBox.Text);
        }

        #region Browsers

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Executable files|*.exe",
                CheckFileExists = true
            })
            {
                if (pathTextBox.Text != string.Empty)
                    ofd.FileName = pathTextBox.Text;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathTextBox.Text = ofd.FileName;

                    //if (nameTextBox.Text == string.Empty)
                    nameTextBox.Text = GetAppName(ofd.FileName);
                    iconSelector.TrySetIconFromExecutableFile(ofd.FileName);
                }
            }
        }

        private void selectCustomWorkingDirectoryButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                ofd.SelectedPath = customWorkingDirectoryTextBox.Text;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    customWorkingDirectoryTextBox.Text = ofd.SelectedPath;
                }
            }
        }

        #endregion

        #region Checkboxes

        private void argumentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            argumentsTextBox.Enabled = argumentsCheckBox.Checked;
        }

        private void customWorkingDirectoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customWorkingDirectoryTextBox.Enabled = customWorkingDirectoryCheckBox.Checked;
            selectCustomWorkingDirectoryButton.Enabled = customWorkingDirectoryCheckBox.Checked;
        }

        #endregion

        #endregion

        #region Methods

        string GetAppName(string filename)
        {
            var i = new System.IO.FileInfo(filename);
            return i.Name.Remove((int)i.Name.Length - i.Extension.Length);
        }

        #endregion
    }
}
