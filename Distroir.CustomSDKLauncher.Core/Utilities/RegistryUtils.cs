using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
