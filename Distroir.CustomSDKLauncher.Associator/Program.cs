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
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Associator
{
    static class Program
    {
        /// <summary>
        /// Entry point of an application
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string protocolName = "sdklauncher";

            //Enable visual styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Not enough arguments
            if (args.Length < 1)
                return;

            //Pass argments
            try
            {
                if (args[0].ToLower() == "-r" || args[0].ToLower() == "--register")
                {
                    RegistryUtils.RegisterProtocol(protocolName, IOUtils.GetSdkLauncherPath());
                    MessageBox.Show("Protocol successfully registered!", "Custom SDK Launcher Associator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (args[0].ToLower() == "-u" || args[0].ToLower() == "--unregister")
                {
                    RegistryUtils.UnregisterProtocol(protocolName);
                    MessageBox.Show("Protocol successfully unregistered!", "Custom SDK Launcher Associator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Unable to register or unregister protocol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
