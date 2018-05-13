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
        public static bool RegisterProtocol()
        {
            return RegisterProtocol(true);
        }

        /// <summary>
        /// Registers sdklauncher protocol
        /// </summary>
        public static bool RegisterProtocol(bool showAlert)
        {
            if (showAlert)
                MessageBoxes.Info("UAC prompt will be displayed after you click ok.\nConfirmation is required to register protocol for launcher");

            try
            {
                Process associator = Process.Start(GetAssociatorPath(), "-r");
                associator.WaitForExit();
                return associator.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Registers sdklauncher protocol
        /// </summary>
        public static bool UnregisterProtocol()
        {
            return UnregisterProtocol(true);
        }

        /// <summary>
        /// Unregisters sdklauncher protocol
        /// </summary>
        public static bool UnregisterProtocol(bool showAlert)
        {
            if (showAlert)
                MessageBoxes.Info("UAC prompt will be displayed after you click ok.\nConfirmation is required to unregister protocol");

            try
            {
                Process associator = Process.Start(GetAssociatorPath(), "-u");
                associator.WaitForExit();
                return associator.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if protocol is registered
        /// </summary>
        public static bool IsProtocolRegistered()
        {
            RegistryKey protocolKey = GetKeyFromPath(RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Default), "sdklauncher");

            if (protocolKey == null)
                return false;
            else
                return true;
        }
    }
}
