using Distroir.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Custom_SDK_Launcher
{
    public class Utils
    {
        static string cs_gamedir = @"D:\Programy\SteamLibrary\SteamApps\common\Counter-Strike Global Offensive\csgo";
        static string cs_bin = @"D:\Programy\SteamLibrary\SteamApps\common\Counter-Strike Global Offensive\bin";
        static string ConfigDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher");

        /// <summary>
        /// Checks if directories for config exist
        /// </summary>
        public static void CheckDirs()
        {
            if (!Directory.Exists(ConfigDir))
                Directory.CreateDirectory(ConfigDir);
        }

        [Obsolete]
        public static void UpdateGamedirs(string directory)
        {
            cs_gamedir = Path.Combine(directory, "csgo");
            cs_bin = Path.Combine(directory, "bin");
        }

        /// <summary>
        /// Launches application located in csgo's bin directory
        /// </summary>
        /// <param name="filename">Name of file to launch</param>
        [Obsolete]
        public static void Launch(string filename)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.WorkingDirectory = cs_bin;
                p.StartInfo.FileName = Path.Combine(cs_bin, filename);
                p.StartInfo.Arguments = string.Format("-game {0}{1}{0}", '"', cs_gamedir);
                p.Start();
            }
            catch
            {
                MessageBox.Show("Couldn't launch application. Check your settings first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// Launches application located in csgo's bin directory
        /// </summary>
        /// <param name="filename">Name of file to launch</param>
        /// <param name="args">Arguments</param>
        [Obsolete]
        public static void Launch(string filename, string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.WorkingDirectory = cs_bin;
                p.StartInfo.FileName = Path.Combine(cs_bin, filename);
                p.StartInfo.Arguments = string.Format("-game {0}{1}{0} {2}", '"', cs_gamedir, args);
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't launch application. Check your settings first", "Error: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
