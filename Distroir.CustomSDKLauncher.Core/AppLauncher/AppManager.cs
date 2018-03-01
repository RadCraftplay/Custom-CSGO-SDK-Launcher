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
using Distroir.CustomSDKLauncher.Core.AppLauncher.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher
{
    public class AppManager
    {
        public static List<AppInfo> Applications;
        static string AppListFilename = @"C:\users\x\desktop\apps.xml";

        public static void LoadApplications()
        {
            //Initialize list of applications
            Applications = new List<AppInfo>();

            //Clear template list
            Applications.Clear();

            //Create instance of XMLSerializer
            XmlSerializer s = new XmlSerializer(typeof(AppInfo[]));

            //Read data
            using (TextReader reader = new StreamReader(AppListFilename))
            {
                Applications = ((AppInfo[])s.Deserialize(reader)).ToList();
            }
        }

        public static bool TryLoadApplications()
        {
            try
            {
                LoadApplications();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void CreateApplications()
        {
            //Create app list
            BasicAppTemplate t = new BasicAppTemplate();

            t.GenerateDefaultConfig(Templates.SDKApplication.Hammer);
            AppInfo hammer = t.Info;

            t.GenerateDefaultConfig(Templates.SDKApplication.HLMV);
            AppInfo hlmv = t.Info;

            t.GenerateDefaultConfig(Templates.SDKApplication.FacePoser);
            AppInfo facePoser = t.Info;

            //Add apps
            Applications = new List<AppInfo>();
            Applications.Add(hammer);
            Applications.Add(hlmv);
            Applications.Add(facePoser);

            //Serialize templates
            SaveApplications();
        }

        public static bool SaveApplications()
        {
            try
            {
                //Create serializer and writer
                TextWriter w = new StreamWriter(AppListFilename);
                XmlSerializer s = new XmlSerializer(typeof(AppInfo[]));

                //Serialize stream
                s.Serialize(w, Applications.ToArray());

                //Clean memory and close stream
                w.Close();
                w.Dispose();

                //There were no errors
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void UpdateButtons(Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                UpdateButton(buttons[i], i);
            }
        }

        static void UpdateButton(Button b, int id)
        {
            AppInfo i = Applications[id];

            b.Text = i.DisplayText;
            b.Image = i.Icon;
            b.Tag = i;
        }

        public static void LaunchApp(Button sender)
        {
            AppInfo i = (AppInfo)sender.Tag;
            i.Launch();
        }
    }
}
