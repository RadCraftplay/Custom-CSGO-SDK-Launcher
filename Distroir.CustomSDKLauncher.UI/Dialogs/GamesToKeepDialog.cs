using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class GamesToKeepDialog : Form
    {
        public List<Game> Games => keptGamesListView.Items
            .Cast<ListViewItem>()
            .Select(item => item.Tag as Game)
            .ToList();

        public GamesToKeepDialog(List<Game> keptGames, List<Game> discardedGames)
        {
            InitializeComponent();

            foreach (var game in keptGames)
                keptGamesListView.Items.Add(GetItemFromGame(game));

            foreach (var game in discardedGames)
                discardedGamesListView.Items.Add(GetItemFromGame(game));
        }

        private ListViewItem GetItemFromGame(Game game)
        {
            return new ListViewItem(game.Name)
            {
                Tag = game
            };
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(keptGamesListView, discardedGamesListView);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(discardedGamesListView, keptGamesListView);
        }

        /// <summary>
        /// Moves selected items from list view a to list view b
        /// </summary>
        private void MoveSelectedItems(ListView a, ListView b)
        {
            foreach (ListViewItem item in a.SelectedItems)
                MoveItem(item, a, b);
        }

        /// <summary>
        /// Moves item from list view a to list view b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void MoveItem(ListViewItem item, ListView a, ListView b)
        {
            a.Items.Remove(item);
            b.Items.Add(item);
        }
    }
}
