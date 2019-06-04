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
            = MigrationConflictSolution.NoDecission;

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

        private void KeepProfilesButton_Click(object sender, System.EventArgs e)
        {
            ContinueAndCloseIfAgeed(MigrationConflictSolution.KeepProfilesXml);
        }

        private void KeepAllButton_Click(object sender, System.EventArgs e)
        {
            ContinueAndCloseIfAgeed(MigrationConflictSolution.KeepBoth);
        }

        private void KeepGamesButton_Click(object sender, System.EventArgs e)
        {
            ContinueAndCloseIfAgeed(MigrationConflictSolution.KeepGamesXml);
        }

        void ContinueAndCloseIfAgeed(MigrationConflictSolution solution)
        {
            if (AskForConfirmation(solution))
            {
                ConflictSolution = solution;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <returns>True if user confirmed</returns>
        bool AskForConfirmation(MigrationConflictSolution solution)
        {
            StringBuilder messageBuilder = new StringBuilder();

            switch (solution)
            {
                case MigrationConflictSolution.KeepProfilesXml:
                    messageBuilder.AppendLine("Are you sure to keep ONLY games from file profiles.xml?");
                    break;
                case MigrationConflictSolution.KeepGamesXml:
                    messageBuilder.AppendLine("Are you sure to keep ONLY games from file games.xml?");
                    break;
                case MigrationConflictSolution.KeepBoth:
                    messageBuilder.AppendLine("Are you sure to keep ALL games from both files?");
                    break;
                default:
                    messageBuilder.AppendLine("Are you sure you want to continue?");
                    break;
            }
            messageBuilder.Append("This can not be undone");

            var dialogResult = MessageBox.Show(
                messageBuilder.ToString(),
                "Custom SDK Launcher",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
            return dialogResult == DialogResult.Yes;
        }
    }
}
