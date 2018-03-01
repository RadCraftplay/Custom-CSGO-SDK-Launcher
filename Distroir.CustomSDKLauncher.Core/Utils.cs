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
using Distroir.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Utils
    {
        static string ConfigDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher");

        /// <summary>
        /// Checks if directories for config exist
        /// </summary>
        public static void CheckDirs()
        {
            if (!Directory.Exists(ConfigDir))
                Directory.CreateDirectory(ConfigDir);
        }

        /// <summary>
        /// Execute shell command
        /// </summary>
        /// <param name="arg1">Command</param>
        public static void ShellLaunch(string arg1)
        {
            Process.Start(arg1);
        }

        /// <summary>
        /// Tries to launch specified tool
        /// </summary>
        /// <param name="app">Application to launch</param>
        public static void TryLaunchTool(SDKApplication app)
        {
            try
            {
                //Get selected profile id
                int SelectedProfileId = Config.TryReadInt("SelectedProfileId");

                if (SelectedProfileId < 0)
                {
                    //Tell user what went wrong
                    MessageBox.Show("You need to select profile in settings and/or create new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Cancel execution of an application
                    return;
                }

                //Get selected profile
                Profile SelectedProfile = ProfileManager.Profiles[SelectedProfileId];
                //Launch application
                Launcher.Launch(SelectedProfile, app);
            }
            catch (Exception ex)
            {
                //Inform user that something unexpected happened
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool TryGetSelectedProfile(out Profile p)
        {
            try
            {
                //Get selected profile id
                int SelectedProfileId = Config.TryReadInt("SelectedProfileId");
                //Get selected profile
                p = ProfileManager.Profiles[SelectedProfileId];

                return true;
            }
            catch
            {
                p = new Profile();
                return false;
            }
        }

        /// <summary>
        /// Creates default path of game
        /// </summary>
        /// <param name="gameDir"></param>
        /// <returns></returns>
        public static string CombineDefaultGameDirName(string gameDir)
        {
            //Get program files directory
            string programfilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            //If 64 bit operating system, use x86 directory
            if (PlatformChecker.is64BitOperatingSystem)
                programfilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            //Return game directory
            return $"{programfilesDir}\\Steam\\steamapps\\common\\{gameDir}";
        }

        /// <summary>
        /// Reloads global variables used by Path Formatter
        /// </summary>
        /// <returns>True if operation succeed</returns>
        public static bool TryReloadPathFormatterVars()
        {
            PathFormatter.Paths.Clear();

            Profile p;

            if (TryGetSelectedProfile(out p))
            {
                PathFormatter.Paths.Add(new System.Collections.Generic.KeyValuePair<string, string>(
                    "GameDir",
                    p.GameDir
                    ));
                PathFormatter.Paths.Add(new System.Collections.Generic.KeyValuePair<string, string>(
                    "GameinfoDir",
                    p.GameinfoDirName
                    ));
                PathFormatter.Paths.Add(new System.Collections.Generic.KeyValuePair<string, string>(
                    "GameBinDir",
                    Path.Combine(p.GameDir, "bin")
                    ));

                return true;
            }

            return false;
        }
    }
}
