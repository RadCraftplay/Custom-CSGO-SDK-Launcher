using System;
using System.Drawing;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;
using Distroir.CustomSDKLauncher.Core.Utilities;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories
{
    public class SteamAppFactory : IAppInfoFactory
    {
        [JsonConstructor]
        public SteamAppFactory(int appId, string name, SerializableImage icon)
        {
            AppId = appId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Icon = icon;
        }
        
        public SteamAppFactory(int appId, string name, Image icon)
        {
            AppId = appId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Icon = new SerializableImage(icon);
        }
        
        public static SteamAppFactory Default => new SteamAppFactory(-1, "Steam Application", Data.DefaultIcon);

        public int AppId { get;}
        public string Name { get; }
        public SerializableImage Icon { get; }
        
        public AppInfo GetInfo()
        {
            return new AppInfo()
            {
                UseCustomArguments = false,
                UseCustomWorkingDirectory = false,
                Path = "steam://run/" + AppId,
                DisplayText = Name,
                Icon = Icon.Image
            };
        }

        public IAppInfoFactory Configure()
        {
            var dialog = new SteamAppConfigurationDialog(AppId, Name, Icon.Image);
            return dialog.ShowDialog() == DialogResult.OK
                ? new SteamAppFactory(Convert.ToInt32(dialog.AppId), dialog.AppName, dialog.AppIcon)
                : this;
        }
    }
}