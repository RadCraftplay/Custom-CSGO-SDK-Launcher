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
using Distroir.Configuration;
using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;
using Distroir.CustomSDKLauncher.Core.Migrators.Games;
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
        readonly string oldGameListFilename = GameCache.oldGameListFilename;

        public bool RequiresMigration()
        {
            return File.Exists(oldGameListFilename);
        }

        public void Migrate()
        {
            if (IgnoreMigrationConflists())
                return;

            var solution = CheckForConflicts() ?
                LetUserDecide() : GameMigrationConflictSolution.NoConflict;

            PerformMigration(solution);
        }

        private bool CheckForConflicts()
        {
            return File.Exists(DataManagers.GameListFilename)
                && File.Exists(oldGameListFilename);
        }

        private bool IgnoreMigrationConflists()
        {
            bool ignoreConflicts = false;

            if (!Config.TryReadBool("IgnoreGameMigrationConflicts", out ignoreConflicts))
                Config.AddVariable("IgnoreGameMigrationConflicts", false);

            return ignoreConflicts;
        }

        private GameMigrationConflictSolution LetUserDecide()
        {
            var dialog = new Games.GameMigrationConflictDialog();
            
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ?
                dialog.ConflictSolution : GameMigrationConflictSolution.NoDecision;
        }

        private void PerformMigration(GameMigrationConflictSolution solution)
        {
            switch (solution)
            {
                case GameMigrationConflictSolution.NoDecisionThisTime:
                case GameMigrationConflictSolution.NoDecision:
                    break;
                case GameMigrationConflictSolution.KeepGamesXml:
                    File.Delete(oldGameListFilename);
                    break;
                case GameMigrationConflictSolution.KeepBoth:
                    WriteGamesFromBothFiles();
                    File.Delete(oldGameListFilename);
                    break;
                case GameMigrationConflictSolution.NoConflict:
                case GameMigrationConflictSolution.KeepProfilesXml:
                default:
                    File.Delete(DataManagers.GameListFilename);
                    WriteDocument();
                    File.Delete(oldGameListFilename);
                    break;
            }
        }

        private void WriteGamesFromBothFiles()
        {
            XmlFileSerializer<Game> gameListSerializer
                = new XmlFileSerializer<Game>(DataManagers.GameListFilename);
            List<Game> games = gameListSerializer.Load().ToList();

            foreach (Game game in GameCache.CachedGames)
            {
                game.Name += " (profiles.xml)";
                games.Add(game);
            }

            gameListSerializer.Save(games.ToArray());
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
