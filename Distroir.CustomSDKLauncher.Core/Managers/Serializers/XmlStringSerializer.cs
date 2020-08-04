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