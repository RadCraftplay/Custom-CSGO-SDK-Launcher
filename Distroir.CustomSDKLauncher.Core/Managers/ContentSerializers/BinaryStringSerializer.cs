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
using System.Runtime.Serialization.Formatters.Binary;

namespace Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers
{
    public class BinaryStringSerializer<T> : ContentSerializer<T>
    {
        /// <summary>
        /// String to deserialize
        /// </summary>
        string toProcess;

        /// <summary>
        /// Deserializes string to an object array
        /// </summary>
        /// <param name="Source">String </param>
        public BinaryStringSerializer(string Source)
        {
            toProcess = Source;
        }

        public override T[] Load()
        {
            using (Stream s = GenerateStreamFromString(toProcess))
            {
                BinaryFormatter f = new BinaryFormatter();
                return (T[])f.Deserialize(s);
            }
        }

        public override void Save(T[] Array)
        {
            throw new NotImplementedException();
        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
