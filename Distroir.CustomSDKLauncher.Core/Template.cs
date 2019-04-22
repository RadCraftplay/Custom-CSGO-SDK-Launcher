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
namespace Distroir.CustomSDKLauncher.Core
{
    public class Template
    {
        /// <summary>
        /// Name of template. For example "Counter-Strike: Global Offensive"
        /// </summary>
        public string Name;
        /// <summary>
        /// Name of directory containing "gameinfo.txt" file. For example "csgo"
        /// </summary>
        public string GameinfoDirName;
        /// <summary>
        /// Name of directory containing game files. Used only during first launch
        /// </summary>
        public string GameDirName;


        //Overrides ToString method and returns name of profile
        public override string ToString()
        {
            return Name;
        }

        //Creates profile based on template
        public Game ToProfile(string gameDir)
        {
            //Create profile
            Game p = new Game()
            {
                ProfileName = Name,
                GameinfoDirName = GameinfoDirName,
                GameDir = gameDir
            };

            //Return profile
            return p;
        }
    }
}
