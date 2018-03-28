using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Feedback
{
    public class DateSerializer
    {
        public static string SerializeDate(DateTime date)
        {
            return $"{date.Year}-{date.Month}-{date.Day}";
        }

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
