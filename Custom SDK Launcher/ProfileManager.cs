using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Custom_SDK_Launcher
{
    public class ProfileManager
    {
        /// <summary>
        /// Full path to file containing list of profiles
        /// </summary>
        public static string ProfileListFilename;

        /// <summary>
        /// List of profiles
        /// </summary>
        public static List<Profile> Profiles = new List<Profile>();

        /// <summary>
        /// Saves list of profiles to file
        /// </summary>
        public static void SaveProfiles()
        {
            //Create serializer and writer
            TextWriter w = new StreamWriter(ProfileListFilename);
            XmlSerializer s = new XmlSerializer(typeof(Profile[]));

            //Serialize stream
            s.Serialize(w, Profiles);

            //Clean memory and close stream
            w.Close();
            w.Dispose();
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

            //Create serializer and stream
            TextReader r = new StreamReader(ProfileListFilename);
            XmlSerializer s = new XmlSerializer(typeof(Profile[]));

            //Get data
            returnvalue = (Profile[])s.Deserialize(r);

            //Clean memory and close stream
            r.Close();
            r.Dispose();

            //Return data
            return returnvalue;
        }
    }
}
