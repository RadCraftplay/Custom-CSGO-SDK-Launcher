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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher
{
    public class AppInfo : IDisposable
    {
        /// <summary>
        /// Path to an executable file
        /// </summary>
        public string Path;

        public bool UseCustomWorkingDirectory = false;
        public string CustomWorkingDirectory;

        public bool UseCustomArguments = false;
        /// <summary>
        /// Process arguments
        /// </summary>
        public string Arguments;

        /// <summary>
        /// Text displayed on button
        /// </summary>
        public string DisplayText;

        /// <summary>
        /// Image representation used for serialization
        /// </summary>
        [XmlElement("Icon")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] ImageSerialized;

        /// <summary>
        /// Icon displayed on button
        /// </summary>
        [XmlIgnore]
        public Image Icon
        {
            get
            {
                if (ImageSerialized == null)
                    return null;
                
                using (MemoryStream ms = new MemoryStream(ImageSerialized))
                    return Image.FromStream(ms);
            }
            set
            {
                if (value == null)
                {
                    ImageSerialized = null;
                    return;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    value.Save(ms, ImageFormat.Tiff);
                    ImageSerialized = ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Executable path formatted using Path Formatter
        /// </summary>
        [XmlIgnore]
        public string PathFormatted
        {
            get
            {
                if (Path == null)
                    return null;

                return PathFormatter.Format(Path);
            }
        }

        /// <summary>
        /// Custom working directory formatted using Path Formatter
        /// </summary>
        [XmlIgnore]
        public string CustomWorkingDirectoryFormatted
        {
            get
            {
                if (CustomWorkingDirectory == null)
                    return null;

                return PathFormatter.Format(CustomWorkingDirectory);
            }
        }

        /// <summary>
        /// Arguments formatted using Path Formatter
        /// </summary>
        [XmlIgnore]
        public string ArgumentsFormatted
        {
            get
            {
                if (Arguments == null)
                    return null;

                return PathFormatter.Format(Arguments);
            }
        }

        public AppInfo()
        {
            UseCustomWorkingDirectory = false;
            UseCustomArguments = false;
        }

        /// <summary>
        /// Launches application
        /// </summary>
        public void Launch()
        {
            Process p = new Process();

            p.StartInfo.FileName = PathFormatted;

            if (UseCustomArguments)
                p.StartInfo.Arguments = ArgumentsFormatted;

            if (UseCustomWorkingDirectory)
                p.StartInfo.WorkingDirectory = CustomWorkingDirectoryFormatted;

            p.Start();
        }

        public void Dispose()
        {
            Path = null;
            CustomWorkingDirectory = null;
            Arguments = null;
            DisplayText = null;
            Icon = null;
        }
    }
}
