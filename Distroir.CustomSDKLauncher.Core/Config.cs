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
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace Distroir.Configuration
{
    public static class Config
    {
        #region Variables

        /// <summary>
        /// Contains settings of the application
        /// </summary>
        public static List<Key> settings = new List<Key>();
        /// <summary>
        /// Config file name
        /// </summary>
        public static string destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher", "config.xml");

        #endregion

        #region Config Variables

        /// <summary>
        /// Add varriable to config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="value">Value of the varriable</param>
        public static void AddVariable(string name, string value)
        {
            Key k = new Key();
            k.name = name;
            k.value = value;

            try
            {
                foreach (Key key in settings)
                    if (key.name == k.name)
                        settings.Remove(key);
            }
            catch { }

            settings.Add(k);
        }

        /// <summary>
        /// Add varriable to config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="value">Value of the varriable</param>
        public static void AddVariable(string name, object value)
        {
            AddVariable(name, value.ToString());
        }

        /// <summary>
        /// Add varriable to config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="value">Value of the varriable</param>
        public static void AddVariable(string name, int value)
        {
            AddVariable(name, value.ToString());
        }

        /// <summary>
        /// Add varriable to config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="value">Value of the varriable</param>
        public static void AddVariable(string name, float value)
        {
            AddVariable(name, value.ToString("R").Replace(',', '.'));
        }

        /// <summary>
        /// Gets value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe</returns>
        public static string ReadVariable(string name)
        {
            foreach (Key k in settings)
                if (k.name == name)
                    return k.value;

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Removes object from config
        /// </summary>
        /// <param name="name">Name of varriable to remove</param>
        public static void RemoveVariable(string name)
        {
            foreach (Key key in settings)
            {
                if (key.name == name)
                {
                    settings.Remove(key);
                    break;
                }
            }
        }

        /// <summary>
        /// Tries to get value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe</returns>
        public static object TryReadVariable(string name)
        {
            try
            {
                return ReadVariable(name);
            }
            catch { }

            return null;
        }

        /// <summary>
        /// Gets value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe (as string)</returns>
        public static object ReadString(string name)
        {
            return ReadVariable(name);
        }

        /// <summary>
        /// Tries to get value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe (as string)</returns>
        public static string TryReadString(string name)
        {
            return (string)TryReadVariable(name);
        }

        /// <summary>
        /// Gets value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe (as float)</returns>
        public static float ReadFloat(string name)
        {
            return float.Parse((string)ReadVariable(name), CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Tries to get value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe (as float)</returns>
        public static float TryReadFloat(string name)
        {
            return float.Parse((string)TryReadVariable(name), CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Gets value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe</returns>
        public static int ReadInt(string name)
        {
            return Convert.ToInt32((string)ReadVariable(name));
        }

        /// <summary>
        /// Tries to get value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <returns>Value of specified varrialbe (as int)</returns>
        public static int TryReadInt(string name)
        {
            return Convert.ToInt32((string)TryReadVariable(name));
        }

        #endregion

        #region IO

        /// <summary>
        /// Saves config
        /// </summary>
        public static void Save()
        {
            TextWriter w = new StreamWriter(destination);
            XmlSerializer s = new XmlSerializer(typeof(Key[]));

            s.Serialize(w, settings.ToArray());
            w.Close();
            w.Dispose();
        }

        /// <summary>
        /// Loads config
        /// </summary>
        public static void Load()
        {
            try
            {
                settings.Clear();

                TextReader w = new StreamReader(destination);
                XmlSerializer s = new XmlSerializer(typeof(Key[]));

                foreach (Key k in (Key[])s.Deserialize(w))
                    settings.Add(k);

                w.Close();
                w.Dispose();
            }
            catch
            {
                //AddVariable("CSGO_DIR", @"C:\Program Files\Steam\steamapps\common\Counter-Strike Global Offensive");
                AddVariable("FirstLaunch", 1);
                AddVariable("DisplayCurrentProfileName", 1);
                //Utils.UpdateGamedirs(@"C:\Program Files\Steam\steamapps\common\Counter-Strike Global Offensive");
            }
        }

        #endregion

        [Serializable]
        public class KeyNotFoundException : Exception
        {
            public override string Message => "Key with matching name not found";
        }
    }

    public class Key
    {
        public string name;
        public string value;
    }
}
