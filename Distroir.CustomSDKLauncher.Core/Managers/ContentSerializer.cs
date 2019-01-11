/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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

namespace Distroir.CustomSDKLauncher.Core.Managers
{
    public abstract class ContentSerializer<T>
    {
        /// <summary>
        /// Determines if content serializer can serialize objects
        /// </summary>
        public bool CanSave = false;
        /// <summary>
        /// Serializes an array ans saves it to file
        /// </summary>
        /// <param name="Array">Array to serialize</param>
        public abstract void Save(T[] Array);
        /// <summary>
        /// Loads an array 
        /// </summary>
        public abstract T[] Load();
    }
}
