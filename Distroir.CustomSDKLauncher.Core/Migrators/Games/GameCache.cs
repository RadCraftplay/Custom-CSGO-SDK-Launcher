/*
Custom SDK Launcher
Copyright (C) 2017-2020 Distroir

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
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Distroir.CustomSDKLauncher.Core.Managers.ContentSerializers;

namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    public class GameCache
    {
        private static Game[] _cachedGames;
        internal readonly static string oldGameListFilename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Distroir",
                "Custom SDK Launcher",
                "profiles.xml");

        public static Game[] CachedGames
        {
            get
            {
                if (_cachedGames == null)
                    _cachedGames = GetDataToCache();

                return _cachedGames;
            }
        }

        private static Game[] GetDataToCache()
        {
            GameToProfileConverter converter = GameToProfileConverter.Singleton;
            ContentSerializer<Game> gameListSerializer
                = new XmlStringContentSerializer<Game>(converter.ConvertAndWriteToString(
                    oldGameListFilename));

            return gameListSerializer.Load();
        }
    }
}
