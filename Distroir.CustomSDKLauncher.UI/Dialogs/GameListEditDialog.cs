﻿/*
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
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Steam;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class GameListEditDialog : Form
    {
        public List<Game> Games { get; private set; } = new List<Game>();

        public GameListEditDialog(List<Game> games)
        {
            Games = games;

            InitializeComponent();
            ReloadList(Games);
        }

        void ReloadList(List<Game> games)
        {
            gameListView.Items.Clear();

            foreach (Game game in games)
                AddItem(game);
        }

        public void AddItem(Game game)
        {
            ListViewItem i = new ListViewItem()
            {
                Name = game.Name,
                Text = game.Name,
                Tag = game
            };

            gameListView.Items.Add(i);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var v = new EditGameDialog();

            if (v.ShowDialog() == DialogResult.OK)
                AddItem(v.Game);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
                for (int i = 0; i < gameListView.SelectedItems.Count; i++)
                    gameListView.SelectedItems[i].Remove();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                var item = gameListView.SelectedItems[0];
                var editGameDialog = new EditGameDialog((Game)item.Tag);

                if (editGameDialog.ShowDialog() == DialogResult.OK)
                {
                    Game editedGame = editGameDialog.Game;

                    item.Name = editedGame.Name;
                    item.Text = editedGame.Name;
                    item.Tag = editedGame;
                }
            }
        }

        private List<Game> RebuildListOfGames()
        {
            IEnumerable<ListViewItem> enumerableItems = gameListView.Items.Cast<ListViewItem>();
            var games = from item in enumerableItems
                        select item.Tag
                        as Game;

            return games.ToList();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Games = RebuildListOfGames();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void createFromTemplateButton_Click(object sender, EventArgs e)
        {
            var chooseTemplateDialog = new ChooseTemplateDialog(this);

            if (chooseTemplateDialog.ShowDialog() == DialogResult.OK)
                AddItem(chooseTemplateDialog.Game);
        }

        private void MoveItem(int index, ListViewItem item)
        {
            gameListView.Items.RemoveAt(item.Index);
            gameListView.Items.Insert(index, item);
        }

        private void MoveToTopButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = gameListView.SelectedItems[0];

            if (selectedItem == null)
                return;

            MoveItem(0, selectedItem);
            gameListView.Select();
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = gameListView.SelectedItems[0];

            if (selectedItem != null && selectedItem.Index != 0)
            {
                int newIndex = selectedItem.Index - 1;
                MoveItem(newIndex, selectedItem);
            }

            gameListView.Select();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = gameListView.SelectedItems[0];

            if (selectedItem != null && selectedItem.Index != gameListView.Items.Count - 1)
            {
                int newIndex = selectedItem.Index + 1;
                MoveItem(newIndex, selectedItem);
            }

            gameListView.Select();
        }

        private void MoveToBottomButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = gameListView.SelectedItems[0];

            if (selectedItem == null)
                return;

            int newIndex = gameListView.Items.Count - 1;
            MoveItem(newIndex, selectedItem);
            gameListView.Select();
        }

        private void duplicateGameButton_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems?.Count == 1)
                AddItem(gameListView.SelectedItems[0].Tag as Game);
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            var foundGames = SteamGameFinder.GetSupportedSteamGames()
                .ToList();

            if (foundGames.Count == 0)
                MessageBox.Show("No games have been found automatically", "Custom SDK Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var categorizedGames = AssignGamesToCategories(foundGames, Games);

                var dialog = new GamesToKeepDialog(categorizedGames.kept, categorizedGames.discarded);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Games.AddRange(dialog.Games);
                    ReloadList(Games);
                }
            }
        }

        public (List<Game> kept, List<Game> discarded) AssignGamesToCategories(List<Game> foundGames, List<Game> ownedGames)
        {
            List<Game> kept = new List<Game>();
            List<Game> discarded = new List<Game>();

            var gameDirectories = ownedGames
                .Select(ownedGame => ownedGame.GameDir.ToLower()).ToList();

            foreach (var foundGame in foundGames)
            {
                var foundMatchingGame = gameDirectories.Contains(foundGame.GameDir.ToLower());

                if (foundMatchingGame)
                    discarded.Add(foundGame);
                else
                    kept.Add(foundGame);
            }

            return (kept, discarded);
        }
    }
}
