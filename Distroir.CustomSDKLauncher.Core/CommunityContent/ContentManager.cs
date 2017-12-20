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

//#define TESTING

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core.CommunityContent
{
    public class ContentManager
    {
        public static List<ContentGroup> ContentGroups = new List<ContentGroup>();

        /// <summary>
        /// Loads content groups
        /// </summary>
        public static void LoadContentGroups()
        {
            //Clear template list
            ContentGroups.Clear();

            //Create instance of XMLSerializer
            XmlSerializer s = new XmlSerializer(typeof(ContentGroup[]));

            //Deserialize content groups from XML file
            using (TextReader reader = new StringReader(Data.ContentGroups))
            {
                ContentGroups = ((ContentGroup[])s.Deserialize(reader)).ToList();
            }
        }

        #if TESTING

        public static void WriteContentGroups(string filename)
        {
            StreamWriter w = new StreamWriter(filename);
            XmlSerializer s = new XmlSerializer(typeof(ContentGroup[]));
            s.Serialize(w, ContentGroups.ToArray());
        }

        public static void WriteExampleGroups()
        {
            ContentGroups.Clear();

            ContentGroup gb = new ContentGroup()
            {
                Name = "Gamebanana",
                Thumbnail = Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\gamebanana.tiff"),
                Contents = new ContentInfo[]
                {
                    new ContentInfo()
                    {
                        Name = "Homepage",
                        Description = "Gamebanana homepage",
                        url = "https://gamebanana.com",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Gamebanana\Homepage.bmp")
                    },
                    new ContentInfo()
                    {
                        Name = "Prefabs",
                        Description = "Map objects",
                        url = "https://gamebanana.com/prefabs",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Gamebanana\Prefabs.bmp")
                    }
                }
            };

            ContentGroups.Add(gb);

            ContentGroup tut = new ContentGroup()
            {
                Name = "Tutorials",
                Thumbnail = Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\tutorials.tiff"),
                Contents = new ContentInfo[]
                {
                    new ContentInfo()
                    {
                        Name = "Fmpone's video tutorials",
                        Author = "Fmpone",
                        Description = "Fmpone is creator of de_cache",
                        url = "https://www.youtube.com/channel/UCrVkmwv-AHBAo-92OeSh9YQ/videos",
                        Game = "Counter-Strike: Global Offensive",
                        Engine = "Source Engine",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Tutorials\Fmpone.bmp")
                    },
                    new ContentInfo()
                    {
                        Name = "Counter-Strike Global Offensive Level Design Boot Camp",
                        Author = "TopHATTwaffle",
                        Description = "Great tutorial series created by TopHATTwaffle - mapmaker with over 10 years of experience",
                        url = "https://www.youtube.com/channel/UCrVkmwv-AHBAo-92OeSh9YQ/videos",
                        Game = "Counter-Strike: Global Offensive",
                        Engine = "Source Engine",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Tutorials\TopHATTwaffle.bmp")
                    },
                    new ContentInfo()
                    {
                        Name = "Counter-Strike: Global Offensive Level Creation (Wiki)",
                        Author = "Valve",
                        Description = "Wiki focused on Counter-Strike: Global Offensive level design using its authoring tools",
                        url = "https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Level_Creation",
                        Game = "Counter-Strike: Global Offensive",
                        Engine = "Source Engine",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Tutorials\Valve.bmp")
                    },
                    new ContentInfo()
                    {
                        Name = "Man vs. Engine",
                        Author = "Will2k",
                        Description = "In this tutorial Will is taking a look at ",
                        url = "http://gamebanana.com/tuts/11178",
                        Engine = "Source Engine",
                        Thumbnail = (Bitmap)Image.FromFile(@"C:\Users\x\Desktop\xD\csdkl\Tutorials\Man vs engine.bmp")
                    }
                }
            };

            ContentGroups.Add(tut);

            WriteContentGroups(@"C:\Users\x\desktop\cg.xml");
        }

        #endif
    }
}
