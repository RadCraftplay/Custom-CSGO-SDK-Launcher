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

using System.Collections.Generic;
using System.Linq;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Managers;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable
{
    public class CustomizableLauncher : Launcher
    {
        public override List<IApp> Apps
        {
            get
            {
                if (DataManagers.AppManager.Objects?.Count == 0)
                    DataManagers.AppManager.TryLoad();
                
                return DataManagers.AppManager.Objects?
                    .Select(x => x as IApp).ToList();
            }
        }

        public override string Name => "Customizable launcher";

        private List<IApp> GetApplicationsFromInfos(List<AppInfo> appInfos)
        {
            List<IApp> apps = new List<IApp>();

            foreach (var info in appInfos)
                apps.Add(new CustomizableApp(info));

            return apps;
        }

        private List<AppInfo> GetAppInfosFromApps(List<IApp> apps)
        {
            List<AppInfo> infos = new List<AppInfo>();

            foreach (var app in apps)
                if (app is CustomizableApp customizableApp)
                    infos.Add(customizableApp.Info);

            return infos;
        }
    }
}
