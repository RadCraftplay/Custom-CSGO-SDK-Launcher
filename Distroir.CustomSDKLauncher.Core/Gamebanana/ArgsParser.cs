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

            //Cut beggining of install info
            modInstallInfo = modInstallInfo.Substring(12);

            //Get parameters
            parameters = modInstallInfo.Split(',');
            //Format parameters
            Carve(ref parameters);

            //Validate parameters
            if (parameters.Length < 1)
                return null;

            //Get mod info
            returnInfo = new ModInfo();
            returnInfo.Url = parameters[0];
            returnInfo.GameId = Convert.ToInt32(parameters[1]);

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
