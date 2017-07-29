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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core
{
    public class Tutorial
    {
        public Tutorial() { }

        public Tutorial(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public Tutorial(string name, string url, string game)
        {
            Name = name;
            Url = url;
            Game = game;
        }

        /// <summary>
        /// Tutorial name (For example "Fmpone's tutorials")
        /// </summary>
        public string Name;
        /// <summary>
        /// Link to tutorial (For example "https://www.youtube.com/channel/UCrVkmwv-AHBAo-92OeSh9YQ/videos")
        /// </summary>
        public string Url;

        /// <summary>
        /// Specifies to what game tutorial belongs
        /// </summary>
        public string Game;
    }
}
