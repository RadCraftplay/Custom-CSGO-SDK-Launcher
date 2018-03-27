/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.CommunityContent
{
    public class ImageData
    {
        public string Name;

        /// <summary>
        /// Group thumbnail
        /// </summary>
        [XmlIgnore]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Byte array used for serialization of thumbnail
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("Thumbnail")]
        public byte[] ThumbnailSerialized
        {
            get
            { // serialize
                if (Thumbnail == null)
                    return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    Thumbnail.Save(ms, ImageFormat.Tiff);
                    return ms.ToArray();
                }
            }
            set
            { // deserialize
                if (value == null)
                    Thumbnail = null;
                else
                {
                    using (MemoryStream ms = new MemoryStream(value))
                        Thumbnail = Image.FromStream(ms);
                }
            }
        }
    }
}
