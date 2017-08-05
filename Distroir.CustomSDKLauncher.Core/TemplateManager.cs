/*
Custom SDK Launcher
Copyright (C) 2017 Distroir

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
using System.Text;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core
{
    //Bug: Fix tf2 template: Replace gamedir tf2 with tf
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
                GameinfoDirName = "tf"
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
