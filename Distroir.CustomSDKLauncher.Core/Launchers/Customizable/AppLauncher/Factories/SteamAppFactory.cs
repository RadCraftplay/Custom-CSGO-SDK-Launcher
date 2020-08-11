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

        public int AppId { get; private set; }
        public string Name { get; private set; }
        public Image Icon { get; private set; }
        
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

        public bool Configure()
        {
            var dialog = new SteamAppConfigurationDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AppId = dialog.AppId == null ? Convert.ToInt32(dialog.AppId) : -1;
                Name = dialog.AppName;
                Icon = dialog.Icon.ToBitmap();
                return true;
            }

            return false;
        }
    }
}