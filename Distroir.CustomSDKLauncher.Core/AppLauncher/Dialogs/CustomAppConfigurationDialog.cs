/*
Custom SDK Launcher
Copyright (C) 2017 Distroir

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Utilities;
using Etier.IconHelper;

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

            if (IconPictureBox.Image == null)
                TrySetDefaultIcon();

            Image buff = IconPictureBox.Image;
            i.Icon = buff;

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

        private void defaultIconButton_Click(object sender, EventArgs e)
        {
            TrySetDefaultIcon();
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
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathTextBox.Text = ofd.FileName;

                    //if (nameTextBox.Text == string.Empty)
                    nameTextBox.Text = GetAppName(ofd.FileName);

                    TrySetDefaultIcon();
                }
            }
        }

        private void selectCustomWorkingDirectoryButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    customWorkingDirectoryTextBox.Text = ofd.SelectedPath;
                }
            }
        }

        private void overrideAppIconButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Supported icon files|*.ico;*.png;*.jpg;*.tiff;*.bmp",
                CheckFileExists = true
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SetIcon(ofd.FileName);
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

        #region Images

        bool TrySetDefaultIcon()
        {
            if (!System.IO.File.Exists(pathTextBox.Text))
            {
                IconPictureBox.Image = Data.DefaultIcon;
                return false;
            }

            try
            {
                IconPictureBox.Image = IconReader.GetFileIcon(
                    pathTextBox.Text,
                    IconReader.IconSize.Small,
                    false).ToBitmap();

                return true;
            }
            catch
            {
                return false;
            }
        }

        void SetIcon(string path)
        {
            Image icon = Image.FromFile(path);

            if (icon.Size != new Size(16, 16))
            {
                icon = ResizeImage(icon, 16, 16);
            }

            IconPictureBox.Image = icon;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion

        string GetAppName(string filename)
        {
            var i = new System.IO.FileInfo(filename);
            return i.Name.Remove((int)i.Name.Length - i.Extension.Length);
        }

        #endregion
    }
}
