/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
                Icon = Data.steam_x16
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
                Info.Icon = Data.steam_x16;

                return true;
            }

            return false;
        }
    }
}
