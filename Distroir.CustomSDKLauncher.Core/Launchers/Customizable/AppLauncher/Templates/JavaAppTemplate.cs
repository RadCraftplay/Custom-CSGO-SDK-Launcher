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

using Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates
{
    public class JavaAppTemplate : AppTemplate
    {
        public JavaAppTemplate()
        {
            Info = new AppInfo();
            Info.Icon = Data.DefaultIcon;
            Info.DisplayText = "Java application";
        }

        public override bool Configure()
        {
            var v = new JavaAppConfigurationDialog();
            if (v.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Info = v.Info;
                return true;
            }

            return false;
        }
    }
}
