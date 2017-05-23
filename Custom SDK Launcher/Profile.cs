using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Custom_SDK_Launcher
{
    public class Profile
    {
        /// <summary>
        /// Name of the profile
        /// </summary>
        public string ProfileName;

        /// <summary>
        /// Full path of game directory. For example "C:\Program Files\Steam\steamapps\common\Counter-Strike Global Offensive"
        /// </summary>
        public string GameDir;
        /// <summary>
        /// Name of directory containing "gameinfo.txt" file. For example "csgo"
        /// </summary>
        public string GameinfoDirName;

        public string GetBinDirectory()
        {
            return Path.Combine(GameDir, "bin");
        }

        public string GetGameinfoDirectory()
        {
            return Path.Combine(GameDir, GameinfoDirName);
        }
    }
}
