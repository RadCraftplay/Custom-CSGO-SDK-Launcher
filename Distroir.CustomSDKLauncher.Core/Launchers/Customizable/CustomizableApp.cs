﻿/*
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

using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable
{
    public class CustomizableApp : IConfigurableApp
    {
        private AppInfo Info { get; set; }

        public IDisplayableItem DisplayableItem => new AppDependentDisplayableItem(Info);

        public CustomizableApp(AppInfo info)
        {
            Info = info;
        }

        public void Launch(Game associatedGame)
        {
            Info.Launch();
        }

        public bool Configure()
        {
            var dialog = new AppSelectorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Info = dialog.SelectedAppTemplate.Info;
                return true;
            }

            return false;
        }
    }
}
