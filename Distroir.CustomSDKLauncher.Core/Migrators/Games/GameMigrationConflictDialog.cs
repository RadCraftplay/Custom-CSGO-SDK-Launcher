using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    public partial class GameMigrationConflictDialog : Form
    {
        public MigrationConflictSolution ConflictSolution { get; private set; }

        public GameMigrationConflictDialog()
        {
            InitializeComponent();

            LoadProfiles();
            LoadGames();
        }

        private void LoadProfiles()
        {
            string gamesString = ConvertProfilesToGames();
            XmlStringSerializer<Game> gameListSerializer
                = new XmlStringSerializer<Game>(gamesString);

            LoadListOfGamesIntoListView(gameListSerializer, profilesListView);
        }

        private string ConvertProfilesToGames()
        {
            GameMigrator migrator = new GameMigrator();
            StringBuilder xmlBuilder = new StringBuilder();

            using (TextWriter textWriter = new StringWriter(xmlBuilder))
            using (XmlWriter writer = XmlWriter.Create(textWriter))
            using (XmlReader reader = new XmlTextReader(migrator.oldGameListFilename))
                migrator.WriteDocument(reader, writer);

            return xmlBuilder.ToString();
        }

        private void LoadGames()
        {
            XmlFileSerializer<Game> gameListSerializer
                = new XmlFileSerializer<Game>(DataManagers.GameListFilename);

            LoadListOfGamesIntoListView(gameListSerializer, gamesListView);
        }

        void LoadListOfGamesIntoListView(ContentSerializer<Game> serializer, ListView listView)
        {
            Game[] games = serializer.Load();

            foreach (Game game in games)
            {
                ListViewItem gameItem = new ListViewItem(game.Name);
                gameItem.Tag = game;

                listView.Items.Add(gameItem);
            }
        }
    }
}
