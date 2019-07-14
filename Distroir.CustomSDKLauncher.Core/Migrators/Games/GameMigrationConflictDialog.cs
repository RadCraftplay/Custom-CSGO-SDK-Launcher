using Distroir.CustomSDKLauncher.Core.Managers;
using Distroir.CustomSDKLauncher.Core.Managers.Serializers;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Distroir.Configuration;
using Distroir.CustomSDKLauncher.Shared.Core;
using System.Collections.Generic;
using Distroir.CustomSDKLauncher.Shared.UI;

namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    public partial class GameMigrationConflictDialog : Form
    {
        public GameMigrationConflictSolution ConflictSolution { get; private set; }
            = GameMigrationConflictSolution.NoDecision;

        public GameMigrationConflictDialog()
        {
            InitializeComponent();

            LoadProfiles();
            LoadGames();
            TagRadioButtons();

            FormClosing += GameMigrationConflictDialog_FormClosing;
        }

        private void GameMigrationConflictDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", 
                "Custom SDK Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void TagRadioButtons()
        {
            keepAllGamesRadioButton.Tag = GameMigrationConflictSolution.KeepBoth;
            keepOnlyGamesXmlRadioButton.Tag = GameMigrationConflictSolution.KeepGamesXml;
            keepOnlyProfilesXmlRadioButton.Tag = GameMigrationConflictSolution.KeepProfilesXml;
            doNotDoAnythingRadioButton.Tag = GameMigrationConflictSolution.NoDecisionThisTime;
        }

        private void LoadProfiles()
        {
            foreach (Game game in GameCache.CachedGames)
                profilesListView.Items.Add(new ListViewItem(game.Name)
                {
                    Tag = game
                });
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

        void ContinueAndCloseIfAgeed(GameMigrationConflictSolution solution)
        {
            if (AskForConfirmation(solution))
            {
                ConflictSolution = solution;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <returns>True if user confirmed</returns>
        bool AskForConfirmation(GameMigrationConflictSolution solution)
        {
            StringBuilder messageBuilder = new StringBuilder();

            switch (solution)
            {
                case GameMigrationConflictSolution.KeepProfilesXml:
                    messageBuilder.AppendLine("Are you sure to keep ONLY games from file profiles.xml?");
                    break;
                case GameMigrationConflictSolution.KeepGamesXml:
                    messageBuilder.AppendLine("Are you sure to keep ONLY games from file games.xml?");
                    break;
                case GameMigrationConflictSolution.KeepBoth:
                    messageBuilder.AppendLine("Are you sure to keep ALL games from both files?");
                    break;
                case GameMigrationConflictSolution.NoDecisionThisTime:
                    return true;
                default:
                    MessageBox.Show(
                        "Please choose at least one option",
                        "Custom SDK Launcher",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
            }
            messageBuilder.Append("This can not be undone");

            var dialogResult = MessageBox.Show(
                messageBuilder.ToString(),
                "Custom SDK Launcher",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
            return dialogResult == DialogResult.Yes;
        }

        private void KeepOnlyProfilesXmlRadioButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
                if (c is RadioButton radioButton)
                    radioButton.Checked = c == (Control)sender;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            GameMigrationConflictSolution solution = GameMigrationConflictSolution.NoDecision;

            if (ignoreFutureConflictsCheckBox.Checked)
                Config.AddVariable("IgnoreGameMigrationConflicts", true);

            foreach (Control c in Controls)
            {
                if (c is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        solution = (GameMigrationConflictSolution)radioButton.Tag;
                        break;
                    }
                }
            }

            ContinueAndCloseIfAgeed(solution);
        }

        private void MigrationConflictInfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HelpTopic migrationTopic = GetTopics()
                .Where(topic => topic.Name == "Migration conflicts")
                .First();

            HelpDialog dialog = new HelpDialog(migrationTopic);
            dialog.ShowDialog();

        }

        private List<HelpTopic> GetTopics()
        {
            if (DataManagers.HelpTopicManager.Objects.Count == 0)
                DataManagers.HelpTopicManager.Load();

            return DataManagers.HelpTopicManager.Objects;
        }
    }
}
