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
using System.IO;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories.Java;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates.Java.PathFinders;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    public partial class JavaAppConfigurationDialog : Form
    {
        public JavaApplication Application { get; private set; }

        public JavaAppConfigurationDialog()
        {
            InitializeComponent();
            TagRadioButtons();
            SetDefaultIcon();
        }

        public JavaAppConfigurationDialog(JavaApplication application)
        {
            Application = application;
            
            InitializeComponent();
            TagRadioButtons();
            SetDefaultIcon();

            appNameTextBox.Text = application.Name;
            jarFilePathTextBox.Text = application.JarFilePath;

            if (!string.IsNullOrWhiteSpace(application.JavaExecutablePath))
            {
                customPathRadioButton.Checked = true;
                customPathTextBox.Text = application.JavaExecutablePath;
                customPathTextBox.Enabled = true;
                selectJavaExePathButton.Enabled = true;
            }
            else
            {
                usePathVariableRadioButton.Checked = true;
            }
            
            iconSelector.Icon = application.Icon.Image;
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
            //Check if game name is empty
            if (appNameTextBox.Text == string.Empty)
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
            
            var javaExecutablePath = GetJavaExecutablePath();
            if (javaExecutablePath == null)
                return;

            Application = new JavaApplication(
                appNameTextBox.Text,
                jarFilePathTextBox.Text,
                javaExecutablePath,
                iconSelector.Icon);
            DialogResult = DialogResult.OK;
            Close();
        }

        private string GetJavaExecutablePath()
        {
            foreach (Control control in javaExecutablePathGroupBox.Controls)
            {
                if (control is RadioButton button)
                {
                    if (button.Checked)
                    {
                        var finder = button.Tag as IJavaPathFinder;
                        
                        if (finder != null && !finder.CanGetPath())
                        {
                            //Throw an error
                            Utilities.MessageBoxes.Error("Unable to find java executable. Try to select other method");
                            //And return
                            return null;
                        }

                        return finder?.Path;
                    }
                }
            }

            return null;
        }
    }
}
