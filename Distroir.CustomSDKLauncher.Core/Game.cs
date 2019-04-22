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
using System.IO;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Game
    {
        /// <summary>
        /// Name of the game
        /// </summary>
        public string Name;

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

        public override string ToString()
        {
            return Name;
        }
    }
}
