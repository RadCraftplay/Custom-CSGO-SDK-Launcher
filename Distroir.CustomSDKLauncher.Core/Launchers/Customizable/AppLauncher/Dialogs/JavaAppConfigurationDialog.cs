﻿/*
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
using System.IO;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    public partial class JavaAppConfigurationDialog : Form
    {
        public AppInfo Info { get; private set; }

        public JavaAppConfigurationDialog()
        {
            InitializeComponent();
            TagRadioButtons();
            SetDefaultIcon();
        }

        private void TagRadioButtons()
        {
            usePathVariableRadioButton.Tag = new PathJavaPathFinder();
            tryToFindJavaExeRadioButton.Tag = new RegistryJavaPathFinder();
            customPathRadioButton.Tag = new CustomJavaPathFinder(ref customPathTextBox);
        }

        private void SetDefaultIcon()
        {
            IJavaPathFinder finder = GetSelectedJavaPathFinder();

            if (finder != null)
                if (finder.CanGetPath())
                    iconSelector.SetIconFromExecutableFile(finder.Path);
        }

        private IJavaPathFinder GetSelectedJavaPathFinder()
        {
            foreach (Control control in javaExecutablePathGroupBox.Controls)
                if (control is RadioButton button)
                    if (button.Checked)
                        return (IJavaPathFinder)button.Tag;

            return null;
        }

        private void selectJarPathButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Java Executable Files|*.jar";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    jarFilePathTextBox.Text = ofd.FileName;
                }
            }
        }

        private void selectJavaExePathButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Java VM Files|java.exe;javaw.exe";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    customPathTextBox.Text = ofd.FileName;
                }
            }
        }

        private void UpdateRadioButtons(object sender, EventArgs e)
        {
            foreach (RadioButton b in new RadioButton[] {
                customPathRadioButton,
                tryToFindJavaExeRadioButton,
                usePathVariableRadioButton })
            {
                b.Checked = (b == sender);
            }

            customPathTextBox.Enabled = selectJavaExePathButton.Enabled = customPathRadioButton.Checked;

            IJavaPathFinder finder = GetSelectedJavaPathFinder();
            if (finder != null)
                if (finder.CanGetPath())
                    iconSelector.TrySetIconFromExecutableFile(finder.Path);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Info = new AppInfo();
            bool anyChecked = false;

            //Check if game name is empty
            if (gameNameTextBox.Text == string.Empty)
            {
                Utilities.MessageBoxes.Warning("Game name is empty!");
                return;
            }

            //Check if jar file path is empty
            if (jarFilePathTextBox.Text == string.Empty)
            {
                Utilities.MessageBoxes.Warning("Jar file path is empty!");
                return;
            }

            if (!File.Exists(jarFilePathTextBox.Text))
            {
                Utilities.MessageBoxes.Warning("Provided jar file does not exist!");
                return;
            }

            //Try to find RadioButtons
            foreach (Control c in javaExecutablePathGroupBox.Controls)
            {
                if (c is RadioButton b)
                {
                    if (b.Checked)
                    {
                        //At least one RadioButton is checked
                        anyChecked = true;

                        //Get finder from RadioButton
                        IJavaPathFinder f = b.Tag as IJavaPathFinder;

                        //If test of the path fails
                        if (!f.CanGetPath())
                        {
                            //Throw an error
                            Utilities.MessageBoxes.Error("Unable to find java executable. Try to select other method");
                            //And return
                            return;
                        }

                        Info.Path = f.Path;
                    }
                }
            }

            //If all RadioButtons are unchecked
            if (!anyChecked)
            {
                //Throw error
                Utilities.MessageBoxes.Warning("Select java executable");
                return;
            }

            Info.Icon = iconSelector.Icon;
            Info.DisplayText = gameNameTextBox.Text;
            Info.UseCustomArguments = true;
            Info.Arguments = String.Format("-jar {0}{1}{0}", '"', jarFilePathTextBox.Text);

            //Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}