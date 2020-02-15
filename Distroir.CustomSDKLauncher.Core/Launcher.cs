/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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
using Distroir.CustomSDKLauncher.Core.Utilities;
using Distroir.CustomSDKLauncher.Core.Utilities.Checker;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Launcher
    {
        public static void Launch(Game p, SDKApplication app)
        {
            GameChecker checker = new GameChecker(p);
            string filename = string.Empty;
            string arguments = string.Empty;

            if (!checker.IsValid())
            {
                MessageBoxes.Error(BuildFullErrorMessage(checker.LastErrorMessage));
                return;
            }

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

        private static string BuildFullErrorMessage(string lastErrorMessage)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(lastErrorMessage);
            builder.AppendLine("1. Go to 'Settings -> Edit list of games' and check if your game has been configured properly");
            builder.AppendLine("2. Make sure you have installed all required SDK's (For example: in case of CS:GO, you have to install Counter-Strike: Global Offensive SDK for tools to work correctly)");
            return builder.ToString();
        }

        /// <summary>
        /// Gets path to executable file of specified tool
        /// </summary>
        /// <param name="g">Selected game</param>
        /// <param name="app">App to launch</param>
        /// <returns>Path to executable of specified tool</returns>
        static string GetToolPath(Game g, SDKApplication app)
        {
            switch (app)
            {
                case SDKApplication.Hammer:
                    return Path.Combine(g.GetBinDirectory(), "hammer.exe");
                case SDKApplication.HLMV:
                    return Path.Combine(g.GetBinDirectory(), "hlmv.exe");
                case SDKApplication.FacePoser:
                    return Path.Combine(g.GetBinDirectory(), "hlfaceposer.exe");
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
