using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core
{
    public class TemplateManager
    {
        public static List<Template> Templates = new List<Template>();

        public static void LoadTemplates()
        {
            //Clear template list
            Templates.Clear();

            //Create instance of XMLSerializer
            XmlSerializer s = new XmlSerializer(typeof(Template[]));

            //Read data
            using (TextReader reader = new StringReader(Data.Templates))
            {
                Templates = ((Template[])s.Deserialize(reader)).ToList();
            }
        }

        public static void CreateTemplates()
        {
            //Create templates
            Template csgo = new Template()
            {
                Name = "Counter-Strike: Global Offensive",
                GameinfoDirName = "csgo"
            };
            Template tf2 = new Template()
            {
                Name = "Team Fortress 2",
                GameinfoDirName = "tf2"
            };
            Template gmod = new Template()
            {
                Name = "Garry's mod",
                GameinfoDirName = "garrysmod"
            };

            //Add templates
            Templates.Add(csgo);
            Templates.Add(tf2);
            Templates.Add(gmod);

            //Serialize templates
            StreamWriter w = new StreamWriter(@"C:\users\x\desktop\Templates.xml");
            XmlSerializer s = new XmlSerializer(typeof(Template[]));
            s.Serialize(w, Templates.ToArray());
        }
    }
}
