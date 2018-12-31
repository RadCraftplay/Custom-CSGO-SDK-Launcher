using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Templates
{
    public class SteamAppTemplate : AppTemplate
    {
        public SteamAppTemplate()
        {
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            Info = new AppInfo()
            {
                DisplayText = "Steam application",
                Icon = Data.DefaultIcon
            };
        }

        public override bool Configure()
        {
            var dialog = new Dialogs.SteamAppConfigurationDialog();
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Info = new AppInfo();
                Info.UseCustomArguments = false;
                Info.UseCustomWorkingDirectory = false;
                Info.Path = "steam://run/" + dialog.AppId;
                Info.DisplayText = dialog.AppName;
                Info.Icon = Data.DefaultIcon;

                return true;
            }

            return false;
        }
    }
}
