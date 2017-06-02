/*
Custom SDK Launcher
Copyright (C) 2017 Distroir

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
using System.Diagnostics;
using System.IO;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Launcher
    {
        public static void Launch(Profile p, SDKApplication app)
        {
            //Create strings
            string filename = string.Empty;
            string arguments = string.Empty;

            //Select configuration
            switch (app)
            {
                case SDKApplication.Hammer:
                    filename = GetToolPath(p, app);
                    arguments = "-nop4 ";
                    break;
                case SDKApplication.HLMV:
                    filename = GetToolPath(p, app);
                    break;
                case SDKApplication.FacePoser:
                    filename = GetToolPath(p, app);
                    arguments = "-nop4 ";
                    break;
            }

            //Add gamedir to arguments
            arguments += string.Format("-game {0}{1}{0}", '"', p.GetGameinfoDirectory());

            //Create process
            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = p.GetBinDirectory();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.Arguments = arguments;
            //Start process
            proc.Start();
        }

        /// <summary>
        /// Gets path to executable file of specified tool
        /// </summary>
        /// <param name="p">Selected profile</param>
        /// <param name="app">App to launch</param>
        /// <returns>Path to executable of specified tool</returns>
        static string GetToolPath(Profile p, SDKApplication app)
        {
            switch (app)
            {
                case SDKApplication.Hammer:
                    return Path.Combine(p.GetBinDirectory(), "hammer.exe");
                case SDKApplication.HLMV:
                    return Path.Combine(p.GetBinDirectory(), "hlmv.exe");
                case SDKApplication.FacePoser:
                    return Path.Combine(p.GetBinDirectory(), "hlfaceposer.exe");
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// As the name suggests
    /// </summary>
    public enum SDKApplication
    {
        /// <summary>
        /// Hammer world editor
        /// </summary>
        Hammer,
        /// <summary>
        /// Model viewer
        /// </summary>
        HLMV,
        /// <summary>
        /// Face poser
        /// </summary>
        FacePoser
    }
}
