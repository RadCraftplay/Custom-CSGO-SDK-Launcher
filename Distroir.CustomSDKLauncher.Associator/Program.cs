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
            catch (Exception ex)
            {
                MessageBox.Show("Unable to register or unregister protocol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
