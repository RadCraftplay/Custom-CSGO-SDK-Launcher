using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Feedback
{
    public class Scheduler
    {
        TimeSpan span;

        public Scheduler(TimeSpan scheduleSpan)
        {
            span = scheduleSpan;
        }

        /// <summary>
        /// Checks if time passed
        /// </summary>
        /// <returns>True if time passed</returns>
        public bool Check(string dateInPast)
        {
            return Check(DateSerializer.DeserializeDate(dateInPast));
        }

        /// <summary>
        /// Checks if time passed
        /// </summary>
        /// <returns>True if time passed</returns>
        public bool Check(DateTime dateInPast)
        {
            TimeSpan reference = DateTime.Now - dateInPast;
            return TimeSpan.Compare(span, reference) == -1;
        }

        
    }
}
