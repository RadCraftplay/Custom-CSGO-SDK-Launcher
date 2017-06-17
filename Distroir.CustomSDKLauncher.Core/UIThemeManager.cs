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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using Distroir.Configuration;

namespace Distroir.CustomSDKLauncher.Core
{
    public class UIThemeManager
    {
        /// <summary>
        /// Currently used theme
        /// </summary>
        public static UITheme CurrentTheme;
        /// <summary>
        /// List of available themes
        /// </summary>
        public static List<UITheme> Themes = new List<UITheme>();

        /// <summary>
        /// Converts all data stroed in XML file to list of themes
        /// </summary>
        public static void LoadThemes()
        {
            //Create instance of XMLSerializer
            XmlSerializer s = new XmlSerializer(typeof(UITheme[]));

            //Read data
            using (TextReader reader = new StringReader(Data.UIThemes))
            {
                Themes = ((UITheme[])s.Deserialize(reader)).ToList();
            }
        }

        /// <summary>
        /// Loads current theme
        /// </summary>
        public static void LoadCurrentTheme()
        {
            //Create returnvalue
            int themeId = Config.TryReadInt("ThemeID");

            //Look for errors
            if (themeId < 0)
                themeId = 0;

            //Set current theme
            CurrentTheme = Themes[themeId];
        }

        /// <summary>
        /// This is method exists only because of developing purposes
        /// </summary>
        public static void CreateThemes()
        {
            //Create themes
            UITheme Light = new UITheme()
            {
                Name = "Light",
                BackgroundColor = Color.FromKnownColor(KnownColor.Control),
                TextColor = Color.FromKnownColor(KnownColor.ControlText),
                ButtonColor = Color.FromKnownColor(KnownColor.Control),
                ButtonTextColor = Color.FromKnownColor(KnownColor.ControlText),
                LinkColor = Color.Blue,
                LinkClickedColor = Color.BlueViolet
            };
            UITheme Dark = new UITheme()
            {
                Name = "Dark",
                BackgroundColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
                TextColor = Color.FromKnownColor(KnownColor.White),
                ButtonColor = Color.FromKnownColor(KnownColor.ControlDarkDark),
                ButtonTextColor = Color.FromKnownColor(KnownColor.White),
                LinkColor = Color.FromKnownColor(KnownColor.MediumTurquoise),
                LinkClickedColor = Color.FromKnownColor(KnownColor.MediumSlateBlue)
            };

            //Add themes
            Themes.Add(Light);
            Themes.Add(Dark);

            //Serialize themes
            StreamWriter w = new StreamWriter(@"C:\users\x\desktop\UIThemes.xml");
            XmlSerializer s = new XmlSerializer(typeof(UITheme[]));

            s.Serialize(w, Themes.ToArray());
        }
    }
}
