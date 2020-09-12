using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Distroir.CustomSDKLauncher.Core.Utilities
{
    public class SerializableImage
    {
        [JsonIgnore]
        [XmlIgnore]
        public Image Image
        {
            get
            {
                if (ImageSerialized == null)
                    return null;
                
                using (MemoryStream ms = new MemoryStream(ImageSerialized))
                    return Image.FromStream(ms);
            }
            set
            {
                if (value == null)
                {
                    ImageSerialized = null;
                    return;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    value.Save(ms, ImageFormat.Tiff);
                    ImageSerialized = ms.ToArray();
                }
            }
        }

        public byte[] ImageSerialized { get; private set; }

        public SerializableImage(Image image)
        {
            Image = image ?? throw new ArgumentNullException(nameof(image));
        }

        [JsonConstructor]
        public SerializableImage(byte[] imageSerialized)
        {
            ImageSerialized = imageSerialized ?? throw new ArgumentNullException(nameof(imageSerialized));
        }

        public static implicit operator Image(SerializableImage image) => image.Image;
        
        public static explicit operator SerializableImage(Image image) => new SerializableImage(image);
    }
}