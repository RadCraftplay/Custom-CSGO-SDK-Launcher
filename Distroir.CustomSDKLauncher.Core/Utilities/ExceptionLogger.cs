/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
