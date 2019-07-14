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
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class GameListEditDialog : Form
    {
        /// <summary>
        /// Local copy of GameManager.Games
        /// </summary>
        public List<Game> Games;

        public GameListEditDialog()
        {
            InitializeComponent();

            Games = DataManagers.GameManager.Objects;
            LoadList();
        }

        void LoadList()
        {
            foreach (Game p in Games)
            {
                AddIem(p);
            }
        }

        public void AddIem(Game p)
        {
            ListViewItem i = new ListViewItem()
            {
                Name = p.Name,
                Text = p.Name,
                Tag = p
            };

            gameListView.Items.Add(i);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Show EditItemDialog
            var v = new EditGameDialog();

            if (v.ShowDialog() == DialogResult.OK)
            {
                //Add ListViewItem
                Games.Add(v.Game);
                AddIem(v.Game);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            //If user selected any items
            if (gameListView.SelectedItems.Count > 0)
            {
                //For every selected item
                for (int i = 0; i < gameListView.SelectedItems.Count; i++)
                {
                    //Remove item from list
                    Games.Remove((Game)gameListView.SelectedItems[i].Tag);
                    //And remove it from control
                    gameListView.SelectedItems[i].Remove();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedItems.Count > 0)
            {
                //Create instance of selected item
                var i = gameListView.SelectedItems[0];
                //Show EditItemDialog
                var v = new EditGameDialog((Game)i.Tag);

                if (v.ShowDialog() == DialogResult.OK)
                {
                    //Set values
                    i.Name = v.Game.Name;
                    i.Text = v.Game.Name;
                    i.Tag = v.Game;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DataManagers.GameManager.Objects = Games;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void createFromTemplateButton_Click(object sender, EventArgs e)
        {
            //Show ChooseTemplateDialog
            var c = new ChooseTemplateDialog();
            c.Tag = this;
            c.ShowDialog();
        }
    }
}
