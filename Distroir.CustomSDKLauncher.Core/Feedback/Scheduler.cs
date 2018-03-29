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
