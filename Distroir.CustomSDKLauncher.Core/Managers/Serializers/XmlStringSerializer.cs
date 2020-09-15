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

namespace Distroir.CustomSDKLauncher.Core.Managers.Serializers
{
    public class XmlStringSerializer<T> : ISerializer<T>
    {
        private readonly string _toDeserialize;

        public XmlStringSerializer(string toDeserialize)
        {
            _toDeserialize = toDeserialize;
        }
        
        public void Serialize(T toSerialize)
        {
            throw new NotImplementedException();
        }

        public T Deserialize()
        {
            using (TextReader reader = new StringReader(_toDeserialize))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}