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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Custom_SDK_Launcher
{
    public class ProfileManager
    {
        /// <summary>
        /// Full path to file containing list of profiles
        /// </summary>
        public static string ProfileListFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher", "profiles.xml");

        /// <summary>
        /// List of profiles
        /// </summary>
        public static List<Profile> Profiles = new List<Profile>();

        /// <summary>
        /// Saves list of profiles to file
        /// </summary>
        public static void SaveProfiles()
        {
            try
            {
                //Create serializer and writer
                TextWriter w = new StreamWriter(ProfileListFilename);
                XmlSerializer s = new XmlSerializer(typeof(Profile[]));

                //Serialize stream
                s.Serialize(w, Profiles.ToArray());

                //Clean memory and close stream
                w.Close();
                w.Dispose();
            }
            catch
            {
                //Do nothing
            }
        }

        /// <summary>
        /// Loads profiles to memory
        /// </summary>
        public static void LoadProfiles()
        {
            if (File.Exists(ProfileListFilename))
            {
                //Clear list of profiles
                Profiles.Clear();
                //Load profile list to memory
                Profiles = GetProfiles().ToList();
            }
        }

        static Profile[] GetProfiles()
        {
            //Create returnvalue
            Profile[] returnvalue = new Profile[0];

            try
            {
                //Create serializer and stream
                TextReader r = new StreamReader(ProfileListFilename);
                XmlSerializer s = new XmlSerializer(typeof(Profile[]));

                //Get data
                returnvalue = (Profile[])s.Deserialize(r);

                //Clean memory and close stream
                r.Close();
                r.Dispose();
            }
            catch
            {
                //Do nothing
            }

            //Return data
            return returnvalue;
        }
    }
}
