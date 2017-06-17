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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core
{
    [Serializable]
    public class UITheme
    {
        public string Name;

        [XmlIgnore]
        public Color BackgroundColor;
        [XmlIgnore]
        public Color TextColor;
        [XmlIgnore]
        public Color ButtonColor;
        [XmlIgnore]
        public Color ButtonTextColor;
        [XmlIgnore]
        public Color LinkColor;
        [XmlIgnore]
        public Color LinkClickedColor;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("BackgroundColor")]
        public string BackgroundColorString
        {
            get
            {
                if (BackgroundColor == null)
                    return null;
                return BackgroundColor.ToArgb().ToString();
            }
            set
            {
                BackgroundColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("TextColor")]
        public string TextColorString
        {
            get
            {
                if (TextColor == null)
                    return null;
                return TextColor.ToArgb().ToString();
            }
            set
            {
                TextColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ButtonColor")]
        public string ButtonColorString
        {
            get
            {
                if (ButtonColor == null)
                    return null;
                return ButtonColor.ToArgb().ToString();
            }
            set
            {
                ButtonColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("ButtonTextColor")]
        public string ButtonTextColorString
        {
            get
            {
                if (ButtonTextColor == null)
                    return null;
                return ButtonTextColor.ToArgb().ToString();
            }
            set
            {
                ButtonTextColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("LinkColor")]
        public string LinkColorString
        {
            get
            {
                if (LinkColor == null)
                    return null;
                return LinkColor.ToArgb().ToString();
            }
            set
            {
                LinkColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("LinkClickedColor")]
        public string LinkClickedColorString
        {
            get
            {
                if (LinkClickedColor == null)
                    return null;
                return LinkClickedColor.ToArgb().ToString();
            }
            set
            {
                LinkClickedColor = Color.FromArgb(Convert.ToInt32(value));
            }
        }
    }
}
