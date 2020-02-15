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
using System.IO;
using Etier.IconHelper;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class IconProvider
    {
        public IconReader.IconSize IconSize { get; }

        public IconProvider(IconReader.IconSize iconSize)
        {
            IconSize = iconSize;
        }

        public static IconProvider Default
        {
            get
            {
                return new IconProvider(IconReader.IconSize.Small);
            }
        }

        public Image GetFileIcon(string path)
        {
            if (string.IsNullOrEmpty(path))
                return Data.DefaultIcon;

            try
            {
                return IconReader.GetFileIcon(path, IconSize, false)
                    .ToBitmap();
            }
            catch
            {
                return Data.DefaultIcon;
            }
        }

        public Image GetIconFromFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"File with name '{path}' not found!");

            Image icon = Image.FromFile(path);
            int iconSize = IconSize == IconReader.IconSize.Small ?
                16 : 32;

            if (icon.Width != iconSize || icon.Height != iconSize)
                icon = ResizeIcon(icon, iconSize);

            return icon;
        }

        private Image ResizeIcon(Image icon, int iconSize)
        {
            Rectangle finalRectangle = new Rectangle(0, 0, iconSize, iconSize);
            Bitmap finalBitmap = new Bitmap(iconSize, iconSize);

            using (Graphics graphics = Graphics.FromImage(finalBitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(icon, finalRectangle, 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel, attributes);
                }
            }

            return finalBitmap;
        }
    }
}
