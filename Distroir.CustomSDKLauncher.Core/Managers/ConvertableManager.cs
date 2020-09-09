using System;
using System.Collections.Generic;
using System.Linq;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;

namespace Distroir.CustomSDKLauncher.Core.Managers
{
    /// <summary>
    /// Reads data of type T (used by serializer) and converts them to type Y (available in application)
    /// </summary>
    /// <typeparam name="T">Source data type</typeparam>
    /// <typeparam name="Y">Dest data type</typeparam>
    public class ConvertableManager<T, Y> : IManager<Y>
    {
        public List<Y> Objects { get; set; }
        private ContentSerializer<T> Serializer { get; }
        private IConverter<T, Y> Converter { get; }

        public ConvertableManager(ContentSerializer<T> serializer, IConverter<T, Y> converter)
        {
            Serializer = serializer;
            Converter = converter;
            Objects = new List<Y>();
        }
        
        public void Load()
        {
            var deserialized = Serializer.Load().ToList();
            Objects = deserialized
                .Select(deserializedObject => Converter.Convert(deserializedObject)).ToList();
        }

        public bool TryLoad()
        {
            try
            {
                Load();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            var convertedArray = Objects
                .Select(objectToConvert => Converter.Convert(objectToConvert)).ToArray();
            
            if (!Serializer.CanSave)
                throw new NotSupportedException("This serializer does not support saving");
            
            Serializer.Save(convertedArray);
        }
    }
}