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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Apps;
using Distroir.CustomSDKLauncher.Core.Managers;

namespace Distroir.CustomSDKLauncher.Core.Launchers
{
    public class CustomizableLauncher : Launcher
    {
        private List<AppInfo> _cachedAppInfos;
        private List<IApp> _cachedApplications;

        public override List<IApp> Apps
        {
            get
            {
                if (DataManagers.AppManager.Objects != _cachedAppInfos)
                {
                    _cachedAppInfos = DataManagers.AppManager.Objects;
                    _cachedApplications = GetApplicationsFromInfos(_cachedAppInfos);
                }

                return _cachedApplications;
            }
        }

        private List<IApp> GetApplicationsFromInfos(List<AppInfo> appInfos)
        {
            List<IApp> apps = new List<IApp>();

            foreach (var info in appInfos)
                apps.Add(new CustomizableApp(info));

            return apps;
        }
    }
}
