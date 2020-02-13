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

        public override string ToString()
        {
            return Name;
        }

        public Game ToGame(string gameDir)
        {
            Game p = new Game()
            {
                Name = Name,
                GameinfoDirName = GameinfoDirName,
                GameDir = gameDir
            };

            return p;
        }
        
        public bool Equals(Template other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && GameDirName == other.GameDirName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Template) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (GameDirName != null ? GameDirName.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Template left, Template right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Template left, Template right)
        {
            return !Equals(left, right);
        }
    }
}
