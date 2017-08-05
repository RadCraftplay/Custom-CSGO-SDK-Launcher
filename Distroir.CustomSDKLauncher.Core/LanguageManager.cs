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
using Distroir.Configuration;
using System.Collections.Generic;
using System.Globalization;

namespace Distroir.CustomSDKLauncher.Core
{
    public class LanguageManager
    {
        /// <summary>
        /// Currently used language
        /// </summary>
        public static CultureInfo Culture;

        /// <summary>
        /// Short name of current language stored in config
        /// </summary>
        public static string GetCfgLanguageCode()
        {
            //Create returnvalue
            string retval = Config.TryReadString("Language");

            //Look for errors
            if (string.IsNullOrEmpty(retval))
                return "en";

            //Return value
            return retval;
        }

        /// <summary>
        /// Dictionary of language codes
        /// </summary>
        /// <returns>Dictionary containing short language codes</returns>
        static Dictionary<string, string> LanguageCodes()
        {
            //Create dictionary
            Dictionary<string, string> retval = new Dictionary<string, string>();

            //Add languages
            retval.Add("English", "en");
            retval.Add("Polski", "pl");

            //Return value
            return retval;
        }

        /// <summary>
        /// Returns 2 characters long language name
        /// </summary>
        /// <param name="LanguageName">Name of the language</param>
        /// <returns></returns>
        public static string GetLanguageCode(string LanguageName)
        {
            //Create returnvalue
            string retval = "en";
            //Try to get language code
            LanguageCodes().TryGetValue(LanguageName, out retval);

            //Return value
            return retval;
        }

        /// <summary>
        /// Loads language info
        /// </summary>
        public static void LoadLanguageInfo()
        {
            //Set cultureInfo
            Culture = CultureInfo.CreateSpecificCulture(GetCfgLanguageCode());
        }
    }
}
