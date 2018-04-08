using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Distroir.CustomSDKLauncher.Core.Utilities;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class ExceptionLogger
    {
        static string LogDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher", "Logs");

        public static void Log(Exception ex)
        {
            string logFileName = Path.Combine(LogDirectory, "CSDKL Error " + DateSerializer.SerializeDateAndTime(DateTime.Now) + ".log");

            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);

            using (StreamWriter w = new StreamWriter(logFileName))
            {
                w.WriteLine("Message: " + ex.Message);
                w.WriteLine("Stack trace:");
                w.WriteLine(ex.StackTrace);
            }
        }
    }
}
