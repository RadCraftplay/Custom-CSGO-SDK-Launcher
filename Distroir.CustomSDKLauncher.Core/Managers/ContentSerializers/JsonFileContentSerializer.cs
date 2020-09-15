using System.IO;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers
{
    public class JsonFileContentSerializer<T> : ContentSerializer<T>
    {
        private readonly string _filename;
        private readonly JsonSerializer _fileSerializer;

        public JsonFileContentSerializer(string filename)
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