﻿using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Distroir.CustomSDKLauncher.Core.Migrators
{
    public class GameMigrator : IMigrator
    {
        string oldGameListFilename = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Distroir",
                "Custom SDK Launcher",
                "profiles.xml");

        public bool RequiresMigration()
        {
            return File.Exists(oldGameListFilename);
        }

        public void Migrate()
        {
            WriteDocument();
            File.Delete(oldGameListFilename);
        }

        private void WriteDocument()
        {
            using (TextWriter textWriter = new StreamWriter(DataManagers.GameListFilename))
            {
                using (XmlWriter newFileWriter = new XmlTextWriter(textWriter))
                {
                    using (XmlReader oldFileReader = new XmlTextReader(oldGameListFilename))
                    {
                        WriteDocument(oldFileReader, newFileWriter);
                    }
                }
            }
        }

        private void WriteDocument(XmlReader oldFileReader, XmlWriter newFileWriter)
        {
            newFileWriter.WriteStartDocument();

            while (oldFileReader.Read())
            {
                ProcessCurrentElement(oldFileReader, newFileWriter);
            }

            newFileWriter.WriteEndDocument();
        }

        private void ProcessCurrentElement(XmlReader oldFileReader, XmlWriter newFileWriter)
        {
            switch (oldFileReader.NodeType)
            {
                case XmlNodeType.Element:
                    switch (oldFileReader.Name)
                    {
                        case "ArrayOfProfile":
                            newFileWriter.WriteStartElement("ArrayOfGame");
                            break;
                        case "Profile":
                            newFileWriter.WriteStartElement("Game");
                            break;
                        case "ProfileName":
                            newFileWriter.WriteStartElement("Name");
                            break;
                        default:
                            newFileWriter.WriteStartElement(oldFileReader.Name);
                            break;
                    }
                    break;
                case XmlNodeType.Text:
                    newFileWriter.WriteString(oldFileReader.Value);
                    break;
                case XmlNodeType.EndElement:
                    newFileWriter.WriteEndElement();
                    break;
            }
        }
    }
}
