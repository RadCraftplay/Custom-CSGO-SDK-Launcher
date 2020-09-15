using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers.Json
{
    public class JsonImageConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var base64 = (string)reader.Value;
            return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var image = (Image) value;
            var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            
            var imageData = ms.ToArray();
            writer.WriteValue(imageData);
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Image);
        }
    }
}