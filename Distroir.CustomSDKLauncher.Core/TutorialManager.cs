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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Distroir.CustomSDKLauncher.Core
{
    public class TutorialManager
    {
        /// <summary>
        /// List of tutorials
        /// </summary>
        public static List<Tutorial> Tutorials = new List<Tutorial>();

        /// <summary>
        /// Converts all data stroed in XML file to list of tutorials
        /// </summary>
        public static void LoadTutorials()
        {
            //Create instance of XMLSerializer
            XmlSerializer s = new XmlSerializer(typeof(Tutorial[]));

            //Read data
            using (TextReader reader = new StringReader(Data.Tutorials))
            {
                Tutorials = ((Tutorial[])s.Deserialize(reader)).ToList();
            }
        }

        /// <summary>
        /// This is method exists only because of developing purposes
        /// </summary>
        public static void CreateTutorials()
        {
            //Create tutorials
            Tutorial t1 = new Tutorial(
                "Fmpone's tutorials",
                "https://www.youtube.com/channel/UCrVkmwv-AHBAo-92OeSh9YQ/videos",
                "Counter-Strike: Global Offensive");
            Tutorial t2 = new Tutorial(
                "TopHATTwaffle's tutorials",
                "https://www.youtube.com/playlist?list=PL-454Fe3dQH0WCzAsmydsr24NFaFrNC_h",
                "Counter-Strike: Global Offensive");
            Tutorial t3 = new Tutorial(
                "Valve tutorials",
                "https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Level_Creation",
                "Counter-Strike: Global Offensive");
            Tutorial t4 = new Tutorial(
                "Kliksphilip's tutorials",
                "https://www.youtube.com/playlist?list=PLfwtcDG7LpxF7-uH_P9La76dgCMC_lfk3",
                "Counter-Strike: Global Offensive");
            Tutorial t5 = new Tutorial(
                string.Format("{0}Man vs. Engine{0} by will2k", '"'),
                "http://gamebanana.com/tuts/11178",
                "Counter-Strike: Global Offensive");

            //Add tutorials
            Tutorials.Add(t1);
            Tutorials.Add(t2);
            Tutorials.Add(t3);
            Tutorials.Add(t4);
            Tutorials.Add(t5);

            //Serialize tutorials
            StreamWriter w = new StreamWriter(@"C:\users\x\desktop\Tutorials.xml");
            XmlSerializer s = new XmlSerializer(typeof(Tutorial[]));

            s.Serialize(w, Tutorials.ToArray());
        }
    }
}
