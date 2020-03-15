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
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;
using Distroir.CustomSDKLauncher.Core.Managers.Converters;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class AppUtils
    {
        private static AppTemplateToAppConverter Converter { get; }
        
        public static void CreateApplications()
        {
            //Create app list
            BasicAppTemplate t = new BasicAppTemplate();

            t.GenerateDefaultConfig(Launchers.Customizable.AppLauncher.Templates.SDKApplication.Hammer);
            AppInfo hammer = t.Info;

            t.GenerateDefaultConfig(Launchers.Customizable.AppLauncher.Templates.SDKApplication.HLMV);
            AppInfo hlmv = t.Info;

            t.GenerateDefaultConfig(Launchers.Customizable.AppLauncher.Templates.SDKApplication.FacePoser);
            AppInfo facePoser = t.Info;

            //Add apps
            List<AppInfo> Applications = new List<AppInfo>();
            Applications.Add(hammer);
            Applications.Add(hlmv);
            Applications.Add(facePoser);

            //Save apps
            DataManagers.AppManager.Objects = Applications
                .Select(x => Converter.Convert(x)).ToList();
            DataManagers.AppManager.Save();
        }
    }
}
