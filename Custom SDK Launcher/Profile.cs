using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Custom_SDK_Launcher
{
    public class Profile
    {
        public string ProfileName;

        public string GameDir;
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
