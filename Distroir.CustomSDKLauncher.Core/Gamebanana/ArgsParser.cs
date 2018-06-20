/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana
{
    public class ArgsParser
    {
        public static ModInfo Parse(string[] args)
        {
            ModInfo returnInfo;
            string modInstallInfo;
            string[] parameters;

            //Check if args count is valid
            if (args.Length != 1)
                return null;

            //Get mod install info
            modInstallInfo = args[0];

            //Check if install info string is valid
            if (!modInstallInfo.StartsWith("sdklauncher:["))
                return null;

            //Cut beggining of the string
            //Remove sdklauncher:
            modInstallInfo = modInstallInfo.Substring(12);

            //Split string into parameters
            parameters = modInstallInfo.Split(',');
            //Remove brackets []
            Carve(ref parameters);

            //Validate parameters
            if (parameters.Length < 1)
                return null;

            //Get mod info
            returnInfo = new ModInfo();
            returnInfo.Url = parameters[0];
            returnInfo.GameId = parameters[1];

            if (parameters.Length > 2)
            {
                returnInfo.CategoryId = parameters[2];
            }

            //Return mod info
            return returnInfo;
        }

        /// <summary>
        /// Removes first and last character from strings inside string array
        /// </summary>
        /// <param name="parameters">String array to carve</param>
        static void Carve(ref string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Substring(1);
                parameters[i] = parameters[i].Remove(parameters[i].Length - 1);
            }
        }
    }
}
