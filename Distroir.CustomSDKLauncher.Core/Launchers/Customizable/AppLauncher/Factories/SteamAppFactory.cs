using System;
using System.Drawing;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class SteamAppFactory : IAppInfoFactory
    {
        public SteamAppFactory(int appId, string name, Image icon)
        {
            AppId = appId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }

        public int AppId { get; }
        public string Name { get; }
        public Image Icon { get; }
        
        public AppInfo GetInfo()
        {
            return new AppInfo()
            {
                UseCustomArguments = false,
                UseCustomWorkingDirectory = false,
                Path = "steam://run/" + AppId,
                DisplayText = Name,
                Icon = Icon
            };
        }
    }
}