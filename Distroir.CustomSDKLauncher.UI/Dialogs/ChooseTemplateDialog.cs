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
using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.Managers;
using System;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ChooseTemplateDialog : Form
    {
        private GameListEditDialog _gameListEditDialog;
        private Game _game;

        public Game Game => _game;

        public ChooseTemplateDialog(GameListEditDialog dialog)
        {
            InitializeComponent();

            _gameListEditDialog = dialog;
            RefreshList();
        }

        /// <summary>
        /// Refreshes ListView
        /// </summary>
        void RefreshList()
        {
            if (DataManagers.TemplateManager.Objects == null
                || DataManagers.TemplateManager.Objects.Count == 0)
                DataManagers.TemplateManager.Load();

            templateListView.Items.Clear();

            foreach (Template t in DataManagers.TemplateManager.Objects)
            {
                ListViewItem i = new ListViewItem(t.Name);
                i.Tag = t;

                templateListView.Items.Add(i);
            }
        }

        private void useButton_Click(object sender, EventArgs e)
        {
            if (templateListView.SelectedItems.Count > 0)
            {
                var editGameDialog = new EditGameDialog((Template)templateListView.SelectedItems[0].Tag);

                if (editGameDialog.ShowDialog() == DialogResult.OK)
                {
                    _game = editGameDialog.Game;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
