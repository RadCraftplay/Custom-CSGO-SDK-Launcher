/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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
using System.Linq;
using System.Xml.Serialization;

namespace Distroir.Configuration
{
    public static class Config
    {
        #region Variables

        /// <summary>
        /// Contains settings of an application
        /// </summary>
        private static readonly Dictionary<string, string> Settings = new Dictionary<string, string>();
        /// <summary>
        /// Config file name
        /// </summary>
        public static string Destination => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Distroir", "Custom SDK Launcher", "config.xml");

        #endregion

        #region Config Variables

        /// <summary>
        /// Add variable to config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public static void AddVariable(string name, string value)
        {
            Settings[name] = value;
        }

        /// <summary>
        /// Add variable to config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public static void AddVariable(string name, object value)
        {
            AddVariable(name, value.ToString());
        }

        /// <summary>
        /// Add variable to config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public static void AddVariable(string name, int value)
        {
            AddVariable(name, value.ToString());
        }

        /// <summary>
        /// Add variable to config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public static void AddVariable(string name, bool value)
        {
            AddVariable(name, value ? 1 : 0);
        }

        /// <summary>
        /// Add variable to config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public static void AddVariable(string name, float value)
        {
            AddVariable(name, value.ToString("R").Replace(',', '.'));
        }

        /// <summary>
        /// Gets value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable</returns>
        public static string ReadVariable(string name)
        {
            return Settings[name];
        }

        /// <summary>
        /// Removes object from config
        /// </summary>
        /// <param name="name">Name of variable to remove</param>
        public static void RemoveVariable(string name)
        {
            Settings.Remove(name);
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable</returns>
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
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified variable</returns>
        public static bool TryReadVariable(string name, out object var)
        {
            try
            {
                var = ReadVariable(name);
                return true;
            }
            catch
            {
                var = null;
                return false;
            }
        }

        /// <summary>
        /// Gets value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable (as string)</returns>
        public static object ReadString(string name)
        {
            return ReadVariable(name);
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable (as string)</returns>
        public static string TryReadString(string name)
        {
            return (string)TryReadVariable(name);
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified variable (as string)</returns>
        public static bool TryReadString(string name, out string var)
        {
            try
            {
                var = (string)ReadVariable(name);
                return true;
            }
            catch
            {
                var = null;
                return false;
            }
        }

        /// <summary>
        /// Gets value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable (as float)</returns>
        public static float ReadFloat(string name)
        {
            return float.Parse((string)ReadVariable(name), CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable (as float)</returns>
        public static float TryReadFloat(string name)
        {
            return float.Parse((string)TryReadVariable(name), CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Tries to get value of varrible from the config
        /// </summary>
        /// <param name="name">Name of the varriable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified varrialbe (as float)</returns>
        public static bool TryReadFloat(string name, out float var)
        {
            try
            {
                var = float.Parse((string)ReadVariable(name), CultureInfo.InvariantCulture.NumberFormat);
                return true;
            }
            catch
            {
                var = -1f;
                return false;
            }
        }

        /// <summary>
        /// Gets value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable</returns>
        public static int ReadInt(string name)
        {
            return Convert.ToInt32((string)ReadVariable(name));
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable (as int)</returns>
        public static int TryReadInt(string name)
        {
            int retVal = 0;
            TryReadInt(name, out retVal);
            return retVal;
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified variable (as int)</returns>
        public static bool TryReadInt(string name, out int var)
        {
            try
            {
                var = Convert.ToInt32((string)ReadVariable(name));
                return true;
            }
            catch
            {
                var = -1;
                return false;
            }
        }

        /// <summary>
        /// Gets value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <returns>Value of specified variable</returns>
        public static bool ReadBool(string name)
        {
            return ReadInt(name) == 1;
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified variable (as int)</returns>
        public static bool TryReadBool(string name)
        {
            bool result = false;
            TryReadBool(name, out result);

            return result;
        }

        /// <summary>
        /// Tries to get value of variable from the config
        /// </summary>
        /// <param name="name">Name of the variable</param>
        /// <param name="var">Out variable</param>
        /// <returns>Value of specified variable (as int)</returns>
        public static bool TryReadBool(string name, out bool var)
        {
            try
            {
                var = ReadBool(name);
                return true;
            }
            catch
            {
                var = false;
                return false;
            }
        }

        #endregion

        #region IO

        /// <summary>
        /// Saves config
        /// </summary>
        public static void Save()
        {
            TextWriter w = new StreamWriter(Destination);
            XmlSerializer s = new XmlSerializer(typeof(Key[]));

            s.Serialize(w, Settings.Select(key => new Key(key.Key, key.Value)).ToArray());
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
                Settings.Clear();

                TextReader w = new StreamReader(Destination);
                XmlSerializer s = new XmlSerializer(typeof(Key[]));

                foreach (Key k in (Key[])s.Deserialize(w))
                    Settings.Add(k.name, k.value);

                w.Close();
                w.Dispose();
            }
            catch
            {
                //AddVariable("CSGO_DIR", @"C:\Program Files\Steam\steamapps\common\Counter-Strike Global Offensive");
                AddVariable("FirstLaunch", 1);
                AddVariable("DisplayCurrentProfileName", 1);
                AddVariable("LoadDataAtStartup", 0);
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

        public Key(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public Key()
        {
        }
    }
}
