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

using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class CustomAppTemplate : AppTemplate
    {
        public CustomAppTemplate()
        {
            Info = new AppInfo();
            Info.Icon = Data.DefaultIcon;
            Info.DisplayText = "Custom application";
        }

        public override bool Configure()
        {
            var d = new CustomAppConfigurationDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (d.info != null)
                {
                    Info = d.info;
                    return true;
                }
            }

            return false;
        }
    }
}
