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
using System.IO;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers
{
    public class XmlStringSerializer<T> : ContentSerializer<T>
    {
        /// <summary>
        /// String to deserialize
        /// </summary>
        string toProcess;

        /// <summary>
        /// Deserializes string to an object array
        /// </summary>
        /// <param name="Source">String </param>
        public XmlStringSerializer(string Source)
        {
            toProcess = Source;
        }

        public override T[] Load()
        {
            using (TextReader reader = new StringReader(toProcess))
            {
                //Create instance of XMLSerializer
                XmlSerializer s = new XmlSerializer(typeof(T[]));
                //Read data
                return (T[])s.Deserialize(reader);
            }
        }

        public override void Save(T[] Array)
        {
            throw new NotImplementedException();
        }
    }
}
