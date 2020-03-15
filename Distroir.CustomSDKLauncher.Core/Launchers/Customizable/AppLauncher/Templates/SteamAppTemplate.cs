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

using System;
using System.Drawing;
using Newtonsoft.Json;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers.Json;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class SteamAppTemplate : AppTemplate
    {
        public int AppId { get; private set; } = -1;
        public string Name { get; private set; } = "Steam application";

        [JsonConverter(typeof(JsonImageConverter))]
        public Image Icon { get; private set; } = Data.DefaultIcon;

        public override AppInfo Info =>
            new AppInfo()
            {
                UseCustomArguments = false,
                UseCustomWorkingDirectory = false,
                Path = "steam://run/" + AppId,
                DisplayText = Name,
                Icon = Icon
            };

        public override bool Configure()
        {
            var dialog = new Core.AppLauncher.Dialogs.SteamAppConfigurationDialog();
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AppId = Int32.Parse(dialog.AppId);
                Name = dialog.AppName;
                Icon = dialog.AppIcon;
                
                return true;
            }

            return false;
        }
    }
}
