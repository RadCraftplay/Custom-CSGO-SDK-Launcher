/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Associator
{
    public class IOUtils
    {
        public static string GetSdkLauncherPath()
        {
            FileInfo thisApp = new FileInfo(Application.ExecutablePath);
            DirectoryInfo appDir = thisApp.Directory;

            string devLauncherPath = Path.Combine(appDir.FullName, "Distroir.CustomSDKLauncher.exe");

            if (File.Exists(devLauncherPath))
                return devLauncherPath;
            else
                return $"{'"'}{Path.Combine(appDir.FullName, "Custom SDK Launcher.exe")}{'"'}";
        }
    }
}
