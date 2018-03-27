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
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class JavaUtils
    {
        /// <summary>
        /// Gets latest java installation home path
        /// </summary>
        /// <returns>Latest java installation home path</returns>
        public static string GetJavaHomePath()
        {
            RegistryKey JdkRegKey = RegistryUtils.GetKeyFromPath(Registry.LocalMachine, "SOFTWARE/JavaSoft/Java Development Kit");
            RegistryKey LatestJdk = JdkRegKey.OpenSubKey(JdkRegKey.GetSubKeyNames().Last());

            return LatestJdk.GetValue("JavaHome").ToString();
        }

        /// <summary>
        /// Tries to get java home directory
        /// </summary>
        /// <param name="value">Latest java installation home path</param>
        /// <returns>True if operation succeed</returns>
        public static bool TryGetJavaHomePath(out string value)
        {
            try
            {
                value = GetJavaHomePath();
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }
    }
}
