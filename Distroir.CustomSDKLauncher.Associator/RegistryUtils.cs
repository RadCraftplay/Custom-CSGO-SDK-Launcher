using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Associator
{
    class RegistryUtils
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

        /// <summary>
        /// Registers protocol
        /// </summary>
        /// <param name="protocolName">Protocol name</param>
        /// <param name="appPath">Path to an application</param>
        public static void RegisterProtocol(string protocolName, string appPath)
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Default);

            if (key.OpenSubKey(protocolName) == null)
            {
                key = key.CreateSubKey(protocolName);
                key.SetValue(string.Empty, "URL: " + protocolName + " Protocol");
                key.SetValue("URL Protocol", string.Empty);

                key = key.CreateSubKey(@"shell\open\command");
                key.SetValue(string.Empty, appPath + " " + "%1");
            }
        }

        public static void UnregisterProtocol(string protocolName)
        {
            RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Default);

            if (key.OpenSubKey(protocolName) != null)
                key.DeleteSubKeyTree(protocolName);
        }
    }
}
