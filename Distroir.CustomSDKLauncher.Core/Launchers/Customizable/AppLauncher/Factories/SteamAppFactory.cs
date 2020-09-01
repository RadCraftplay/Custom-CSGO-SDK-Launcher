using System;
using System.Drawing;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;

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
        
        public static SteamAppFactory Default => new SteamAppFactory(-1, "Steam Application", Data.DefaultIcon);

        public int AppId { get;}
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

        public IAppInfoFactory Configure()
        {
            var dialog = new SteamAppConfigurationDialog(AppId, Name, Icon);
            return dialog.ShowDialog() == DialogResult.OK
                ? new SteamAppFactory(Convert.ToInt32(dialog.AppId), dialog.Name, dialog.AppIcon)
                : this;
        }
    }
}