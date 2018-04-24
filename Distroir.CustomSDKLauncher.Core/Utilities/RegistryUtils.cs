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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class RegistryUtils
    {
        /// <summary>
        /// Gets registry subkey from path
        /// </summary>
        /// <param name="key">Root key</param>
        /// <param name="path">Path inside registry (for example: "SOFTWARE/JavaSoft/Java Development Kit")</param>
        public static RegistryKey GetKeyFromPath(RegistryKey key, string path)
        {
            var reference = key;

            foreach (string subKeyName in path.Split('/'))
                reference = reference.OpenSubKey(subKeyName);

            return reference;
        }

        static string GetAssociatorPath()
        {
            FileInfo thisApp = new FileInfo(Application.ExecutablePath);
            DirectoryInfo appDir = thisApp.Directory;

            return Path.Combine(appDir.FullName, "Distroir.CustomSDKLauncher.Associator.exe");
        }

        /// <summary>
        /// Registers sdklauncher protocol
        /// </summary>
        public static void RegisterProtocol()
        {
            MessageBoxes.Info("UAC prompt will be displayed after you click ok.\nConfirmation is required to register protocol for launcher");
            Process.Start(GetAssociatorPath(), "-r").WaitForExit();
        }

        /// <summary>
        /// Unregisters sdklauncher protocol
        /// </summary>
        public static void UnregisterProtocol()
        {
            MessageBoxes.Info("UAC prompt will be displayed after you click ok.\nConfirmation is required to unregister protocol");
            Process.Start(GetAssociatorPath(), "-u").WaitForExit();
        }
    }
}
