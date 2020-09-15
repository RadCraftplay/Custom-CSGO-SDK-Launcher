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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Utilities;
using System.IO;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Controls
{
    public partial class IconSelector : UserControl
    {
        private readonly IconProvider _iconProvider;
        private string _defaultFilePath;

        public Image Icon
        {
            get => iconPictureBox.Image;
            set => iconPictureBox.Image = value;
        }

        public IconSelector()
        {
            _iconProvider = IconProvider.Default;

            InitializeComponent();
            iconPictureBox.Image = Data.DefaultIcon;
        }

        #region Methods

        public bool TrySetDefaultSource(string path)
        {
            if (File.Exists(path))
            {
                _defaultFilePath = path;
                return true;
            }
            else
                return false;
        }

        public void SetDefaultSource(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!", path);

            _defaultFilePath = path;
        }

        public bool TrySetIconFromFile(string path)
        {
            try
            {
                SetIconFromFile(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetIconFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!", path);

            iconPictureBox.Image = _iconProvider.GetFileIcon(path);
        }

        public bool TrySetIconFromExecutableFile(string path)
        {
            try
            {
                SetIconFromExecutableFile(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetIconFromExecutableFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found!", path);

            _defaultFilePath = path;
            iconPictureBox.Image = _iconProvider.GetFileIcon(path);
        }

        #endregion

        #region Events

        private void DefaultIconButton_Click(object sender, EventArgs e)
        {
            iconPictureBox.Image = _iconProvider.GetFileIcon(_defaultFilePath);
        }

        private void CustomAppIconButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "Supported icon files|*.ico;*.png;*.jpg;*.tiff;*.bmp",
                CheckFileExists = true
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = dialog.FileName;
                    iconPictureBox.Image = _iconProvider.GetIconFromFile(filename);
                }
            }
        }

        #endregion
    }
}
