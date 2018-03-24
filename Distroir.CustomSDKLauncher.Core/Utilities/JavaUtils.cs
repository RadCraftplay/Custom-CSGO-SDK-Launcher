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
