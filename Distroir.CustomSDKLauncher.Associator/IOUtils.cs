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
