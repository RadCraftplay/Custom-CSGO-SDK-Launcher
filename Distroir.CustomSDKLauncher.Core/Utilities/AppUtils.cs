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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class AppUtils
    {
        public static void CreateApplications()
        {
            //Create app list
            BasicAppTemplate t = new BasicAppTemplate();

            t.GenerateDefaultConfig(AppLauncher.Templates.SDKApplication.Hammer);
            AppInfo hammer = t.Info;

            t.GenerateDefaultConfig(AppLauncher.Templates.SDKApplication.HLMV);
            AppInfo hlmv = t.Info;

            t.GenerateDefaultConfig(AppLauncher.Templates.SDKApplication.FacePoser);
            AppInfo facePoser = t.Info;

            //Add apps
            List<AppInfo> Applications = new List<AppInfo>();
            Applications.Add(hammer);
            Applications.Add(hlmv);
            Applications.Add(facePoser);

            //Save apps
            DataManagers.AppManager.Objects = Applications;
            DataManagers.AppManager.Save();
        }

        public static void UpdateButtons(Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                UpdateButton(buttons[i], i);
            }
        }

        public static void UpdateButtons(List<AppInfo> info, Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                UpdateButton(info, buttons[i], i);
            }
        }

        static void UpdateButton(Button b, int id)
        {
            AppInfo i = DataManagers.AppManager.Objects[id];

            b.Text = i.DisplayText;
            b.Image = i.Icon;
            b.Tag = i;
        }

        static void UpdateButton(List<AppInfo> info, Button b, int id)
        {
            AppInfo i = info[id];

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
