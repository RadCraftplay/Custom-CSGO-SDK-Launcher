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
using Distroir.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Utilities;

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
        /// Tries to execute shell command
        /// </summary>
        /// <param name="arg1">Command</param>
        /// <returns></returns>
        public static bool TryLaunch(string arg1)
        {
            try
            {
                Process.Start(arg1);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tries to launch specified tool
        /// </summary>
        /// <param name="app">Application to launch</param>
        public static void TryLaunchTool(SDKApplication app)
        {
            try
            {
                int SelectedGameId = Config.TryReadInt("SelectedProfileId");

                if (SelectedGameId < 0)
                {
                    MessageBox.Show("You need to select game in settings and/or create new one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Game SelectedGame = Managers.DataManagers.GameManager.Objects[SelectedGameId];
                Launcher.Launch(SelectedGame, app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool TryGetSelectedGame(out Game game)
        {
            try
            {
                int SelectedGameId = Config.TryReadInt("SelectedProfileId");
                game = Managers.DataManagers.GameManager.Objects[SelectedGameId];

                return true;
            }
            catch
            {
                game = new Game();
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
            string programfilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

            if (PlatformChecker.is64BitOperatingSystem)
                programfilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

            return $"{programfilesDir}\\Steam\\steamapps\\common\\{gameDir}";
        }

        /// <summary>
        /// Reloads global variables used by Path Formatter
        /// </summary>
        /// <returns>True if operation succeed</returns>
        public static bool TryReloadPathFormatterVars()
        {
            PathFormatter.Paths.Clear();

            Game g;

            if (TryGetSelectedGame(out g))
            {
                PathFormatter.Paths.Add("GameDir", g.GameDir);
                PathFormatter.Paths.Add("GameinfoDir", g.GameinfoDirName);
                PathFormatter.Paths.Add("GameBinDir", Path.Combine(g.GameDir, "bin"));

                return true;
            }
            else
            {
                if (Config.TryReadInt("FirstLaunch") == 0)
                    MessageBoxes.Warning("We were unable to get selected game\n" +
                        "Make sure that you have created at least one game");
            }

            return false;
        }
    }
}
