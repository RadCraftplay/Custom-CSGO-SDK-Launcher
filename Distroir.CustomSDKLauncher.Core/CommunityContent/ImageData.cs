using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.CommunityContent
{
    public class ImageData
    {
        public string Name;

        /// <summary>
        /// Group thumbnail
        /// </summary>
        [XmlIgnore]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Byte array used for serialization of thumbnail
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("Thumbnail")]
        public byte[] ThumbnailSerialized
        {
            get
            { // serialize
                if (Thumbnail == null)
                    return null;
                using (MemoryStream ms = new MemoryStream())
                {
                    Thumbnail.Save(ms, ImageFormat.Tiff);
                    return ms.ToArray();
                }
            }
            set
            { // deserialize
                if (value == null)
                    Thumbnail = null;
                else
                {
                    using (MemoryStream ms = new MemoryStream(value))
                        Thumbnail = Image.FromStream(ms);
                }
            }
        }
    }
}
