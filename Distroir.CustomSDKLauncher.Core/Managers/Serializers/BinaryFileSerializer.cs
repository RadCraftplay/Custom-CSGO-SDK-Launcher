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
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Distroir.CustomSDKLauncher.Core.Managers.Serializers
{
    public class BinaryFileSerializer<T> : ContentSerializer<T>
    {
        /// <summary>
        /// Name of file to serialize/deserialize
        /// </summary>
        string FileName;

        public BinaryFileSerializer(string Filename)
        {
            FileName = Filename;
            CanSave = true;
        }

        public override T[] Load()
        {
            using (Stream s = new FileStream(FileName, FileMode.Open))
            {
                BinaryFormatter f = new BinaryFormatter();
                return (T[])f.Deserialize(s);
            }
        }

        public override void Save(T[] Array)
        {
            using (Stream s = new FileStream(FileName, FileMode.Create))
            {
                BinaryFormatter f = new BinaryFormatter();
                
                f.Serialize(s, Array);
            }
        }
    }
}
