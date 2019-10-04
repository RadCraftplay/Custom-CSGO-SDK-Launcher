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
