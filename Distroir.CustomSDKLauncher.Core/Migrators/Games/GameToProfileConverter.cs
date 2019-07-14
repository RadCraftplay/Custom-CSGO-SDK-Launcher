/*
Custom SDK Launcher
Copyright (C) 2017-2019 Distroir

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
using System.Xml;

namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    public class GameToProfileConverter
    {
        private static GameToProfileConverter _singleton;

        public static GameToProfileConverter Singleton
        {
            get
            {
                if (_singleton == null)
                    _singleton = new GameToProfileConverter();

                return _singleton;
            }
        }

        private GameToProfileConverter() { }

        public void Convert(string profileListFilename, string gameListFilename)
        {
            WriteDocument(profileListFilename, gameListFilename);
        }

        public string ConvertAndWriteToString(string profileListFilename)
        {
            StringBuilder outputBuilder = new StringBuilder();

            using (StreamReader profileReader = new StreamReader(profileListFilename))
            using (TextWriter gameWriter = new StringWriter(outputBuilder))
                WriteDocument(profileReader, gameWriter);

            return outputBuilder.ToString();
        }

        private void WriteDocument(string profileListFilename, string gameListFilename)
        {
            using (StreamWriter writer = new StreamWriter(gameListFilename))
            using (StreamReader reader = new StreamReader(profileListFilename))
                WriteDocument(reader, writer);
        }

        private void WriteDocument(TextReader reader, TextWriter writer)
        {
            var settings = new XmlWriterSettings()
            {
                Indent = true
            };

            using (XmlWriter newFileWriter = XmlWriter.Create(writer, settings))
            using (XmlReader oldFileReader = new XmlTextReader(reader))
                WriteDocument(oldFileReader, newFileWriter);
        }

        internal void WriteDocument(XmlReader oldFileReader, XmlWriter newFileWriter)
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
