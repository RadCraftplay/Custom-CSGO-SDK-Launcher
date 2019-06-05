using Distroir.CustomSDKLauncher.Core.Managers;
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
        internal string oldGameListFilename = Path.Combine(
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
            var solution = CheckForConflicts() ?
                LetUserDecide() : GameMigrationConflictSolution.NoConflict;

            PerformMigration(solution);
        }

        private bool CheckForConflicts()
        {
            return File.Exists(DataManagers.GameListFilename)
                && File.Exists(oldGameListFilename);
        }

        private GameMigrationConflictSolution LetUserDecide()
        {
            var dialog = new Games.GameMigrationConflictDialog();
            
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ?
                dialog.ConflictSolution : GameMigrationConflictSolution.NoDecission;
        }

        private void PerformMigration(GameMigrationConflictSolution solution)
        {
            switch (solution)
            {
                case GameMigrationConflictSolution.NoDecission:
                    //TODO: Decide what to do with migration if user canceled dialog
                    throw new NotImplementedException();
                case GameMigrationConflictSolution.KeepGamesXml:
                    File.Delete(oldGameListFilename);
                    break;
                case GameMigrationConflictSolution.KeepBoth:
                    //TODO: Implement keep both
                    throw new NotImplementedException();
                case GameMigrationConflictSolution.NoConflict:
                case GameMigrationConflictSolution.KeepProfilesXml:
                default:
                    File.Delete(DataManagers.GameListFilename);
                    WriteDocument();
                    File.Delete(oldGameListFilename);
                    break;
            }
        }

        private void RemoveGamesFileIfRequired()
        {
            //TODO: Ask user if he wants to keep existing games.xml file
            if (File.Exists(DataManagers.GameListFilename))
                File.Delete(DataManagers.GameListFilename);
        }

        private void WriteDocument()
        {
            var settings = new XmlWriterSettings()
            {
                Indent = true
            };

            using (TextWriter textWriter = new StreamWriter(DataManagers.GameListFilename))
            {
                using (XmlWriter newFileWriter = XmlWriter.Create(textWriter, settings))
                {
                    using (XmlReader oldFileReader = new XmlTextReader(oldGameListFilename))
                    {
                        WriteDocument(oldFileReader, newFileWriter);
                    }
                }
            }
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
