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
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class DateSerializer
    {

        /// <summary>
        /// Serializes date to string
        /// </summary>
        public static string SerializeDate(DateTime date)
        {
            return $"{date.Year}-{date.Month}-{date.Day}";
        }

        /// <summary>
        /// Serializes date and time to string
        /// </summary>
        public static string SerializeDateAndTime(DateTime date)
        {
            return $"{date.Year}-{date.Month}-{date.Day}_{date.Hour}-{date.Minute}-{date.Second}";
        }

        /// <summary>
        /// Deserializes date from string
        /// </summary>
        public static DateTime DeserializeDate(string date)
        {
            string[] dataSplitted = date.Split('-');
            int[] values = new int[3];

            //Read int values
            for (int i = 0; i < 3; i++)
                values[i] = Convert.ToInt32(dataSplitted[i]);

            return new DateTime(values[0], values[1], values[2]);
        }
    }
}
