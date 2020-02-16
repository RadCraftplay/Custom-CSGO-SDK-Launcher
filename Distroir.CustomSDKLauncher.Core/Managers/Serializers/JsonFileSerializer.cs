using System.IO;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Managers.Serializers
{
    public class JsonFileSerializer<T> : ContentSerializer<T>
    {
        private readonly string _filename;
        private readonly JsonSerializer _fileSerializer;

        public JsonFileSerializer(string filename)
        {
            CanSave = true;
            _filename = filename;
            _fileSerializer = new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Formatting = Formatting.Indented
            };
        }

        public override T[] Load()
        {
            using (TextReader reader = new StreamReader(_filename))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
                return _fileSerializer.Deserialize<T[]>(jsonReader);
        }

        public override void Save(T[] array)
        {
            using (TextWriter writer = new StreamWriter(_filename))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                _fileSerializer.Serialize(jsonWriter, array);
        }
    }
}