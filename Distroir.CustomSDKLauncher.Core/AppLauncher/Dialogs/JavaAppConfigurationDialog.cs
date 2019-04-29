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
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    public partial class JavaAppConfigurationDialog : Form
    {
        public AppInfo info;

        public JavaAppConfigurationDialog()
        {
            InitializeComponent();
            TagRadioButtons();
        }

        void TagRadioButtons()
        {
            usePathVariableRadioButton.Tag = new JavaPathFinders.PathFinder();
            tryToFindJavaExeRadioButton.Tag = new JavaPathFinders.RegistryFinder();
            customPathRadioButton.Tag = new JavaPathFinders.CustomFinder();
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
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            info = new AppInfo();
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

            //Try to find RadioButtons
            foreach (Control c in javaExecutablePathGroupBox.Controls)
            {
                try
                {
                    //Try to convert control to RadioButton
                    RadioButton b = (RadioButton)c;

                    if (b.Checked)
                    {
                        //At least one RadioButton is checked
                        anyChecked = true;

                        //Get finder from RadioButton
                        JavaPathFinder f = (JavaPathFinder)b.Tag;

                        //If test of the path fails
                        if (!f.Test(customPathTextBox.Text))
                        {
                            //Throw an error
                            Utilities.MessageBoxes.Error("Unable to find java executable. Try to select other method");
                            //And return
                            return;
                        }

                        //Get java executable path
                        if (f.pathType == PathType.Embed)
                            info.Path = f.Path;
                        else
                            info.Path = customPathTextBox.Text;
                    }
                }
                catch
                {
                    //Control isn't RadioButton -> skip
                }
            }

            //If all RadioButtons are unchecked
            if (!anyChecked)
            {
                //Throw error
                Utilities.MessageBoxes.Warning("Select java executable");
                return;
            }

            //Get appIcon
            Image appIcon;
            Utilities.IconHelper.TrySetDefaultIcon(info.Path, out appIcon);

            //Set AppInfo
            info.Icon = appIcon;
            info.DisplayText = gameNameTextBox.Text;
            info.UseCustomArguments = true;
            info.Arguments = String.Format("-jar {0}{1}{0}", '"', jarFilePathTextBox.Text);

            //Close dialog
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    /// <summary>
    /// As the name suggests, tries to find java path
    /// </summary>
    abstract class JavaPathFinder
    {
        /// <summary>
        /// Tests if executable can be found that way
        /// </summary>
        /// <param name="textBoxPath">Path from PathTextBox</param>
        /// <returns></returns>
        public abstract bool Test(string textBoxPath);

        /// <summary>
        /// Path to java executable
        /// </summary>
        public abstract string Path { get; }

        /// <summary>
        /// Way to get path
        /// </summary>
        public PathType pathType;
    }

    enum PathType
    {
        /// <summary>
        /// Uses JavaPathFinder.Path
        /// </summary>
        Embed,
        /// <summary>
        /// Uses PathTextBox.Text
        /// </summary>
        FromTextbox
    }

    class JavaPathFinders
    {
        public class PathFinder : JavaPathFinder
        {
            public override string Path => "javaw";

            public PathFinder() => pathType = PathType.Embed;

            public override bool Test(string textBoxPath)
            {
                return Utils.TryLaunch(Path);
            }
        }

        public class RegistryFinder : JavaPathFinder
        {
            public override string Path => exePath;
            string exePath;

            public RegistryFinder() => pathType = PathType.Embed;

            public override bool Test(string textBoxPath)
            {
                string output;
                bool result = Utilities.JavaUtils.TryGetJavaHomePath(out output);

                exePath = System.IO.Path.Combine(output, "bin\\javaw.exe");
                return result;
            }
        }

        public class CustomFinder : JavaPathFinder
        {
            public override string Path => null;

            public CustomFinder() => pathType = PathType.FromTextbox;

            public override bool Test(string textBoxPath)
            {
                return Utils.TryLaunch(textBoxPath);
            }
        }
    }

}
