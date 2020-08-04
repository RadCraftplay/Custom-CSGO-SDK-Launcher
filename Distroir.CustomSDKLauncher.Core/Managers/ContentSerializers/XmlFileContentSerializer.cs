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

using System.IO;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers
{
    public class XmlFileContentSerializer<T> : ContentSerializer<T>
    {
        /// <summary>
        /// Name of file to serialize/deserialize
        /// </summary>
        string FileName;

        public XmlFileContentSerializer(string Filename)
        {
            FileName = Filename;
            CanSave = true;
        }

        public override T[] Load()
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                //Create serializer
                XmlSerializer s = new XmlSerializer(typeof(T[]));

                //Deserialize
                return (T[])s.Deserialize(reader);
            }
        }

        public override void Save(T[] Array)
        {
            using (StreamWriter w = new StreamWriter(FileName))
            {
                //Create serializer
                XmlSerializer s = new XmlSerializer(typeof(T[]));

                //Serialize objects
                s.Serialize(w, Array);
            }
        }
    }
}
