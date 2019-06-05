using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Distroir.CustomSDKLauncher.Core.Migrators
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
                = new XmlStringSerializer<Game>(converter.ConvertAndWriteToString(
                    oldGameListFilename));

            return gameListSerializer.Load();
        }
    }
}
