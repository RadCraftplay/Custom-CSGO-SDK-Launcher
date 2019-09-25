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
using Distroir.CustomSDKLauncher.Core.Utilities;
using Distroir.CustomSDKLauncher.Core.Utilities.Checker;
using System;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class EditGameDialog : Form
    {
        public Game Game;

        public EditGameDialog()
        {
            Game = new Game();
            InitializeComponent();
        }

        public EditGameDialog(Template t)
        {
            Game = new Game()
            {
                Name = t.Name,
                GameinfoDirName = t.GameinfoDirName
            };

            InitializeComponent();

            nameTextBox.Text = Game.Name;
            gameInfoTextBox.Text = Game.GameinfoDirName;
        }

        public EditGameDialog(Game p)
        {
            Game = p;
            Text = "Edit game";

            InitializeComponent();

            nameTextBox.Text = Game.Name;
            gameDirTextBox.Text = Game.GameDir;
            gameInfoTextBox.Text = Game.GameinfoDirName;
            gameDirFolderBrowserDialog.SelectedPath = Game.GameDir;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Game newGame = new Game()
            {
                Name = nameTextBox.Text,
                GameDir = gameDirTextBox.Text,
                GameinfoDirName = gameInfoTextBox.Text
            };
            GameChecker checker = new GameChecker(newGame);
            
            if (!checker.IsValid())
            {
                MessageBoxes.Error(checker.LastErrorMessage);
                return;
            }

            Game = newGame;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void gameDirBrowseButton_Click(object sender, EventArgs e)
        {
            gameDirFolderBrowserDialog.SelectedPath = gameDirTextBox.Text;

            if (gameDirFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                gameDirTextBox.Text = gameDirFolderBrowserDialog.SelectedPath;
            }
        }
    }
}
