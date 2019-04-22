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
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ChooseTemplateDialog : Form
    {
        public ChooseTemplateDialog()
        {
            //Create controls
            InitializeComponent();

            //Load templates
            RefreshList();
        }

        /// <summary>
        /// Refreshes ListView
        /// </summary>
        void RefreshList()
        {
            //Load templates
            if (DataManagers.TemplateManager.Objects == null)
                DataManagers.TemplateManager.Load();

            //Clear list
            templateListView.Items.Clear();

            //For every template
            foreach (Template t in DataManagers.TemplateManager.Objects)
            {
                //Create ListViewItem
                ListViewItem i = new ListViewItem(t.Name);
                i.Tag = t;

                //And add it to the list
                templateListView.Items.Add(i);
            }
        }

        private void useButton_Click(object sender, EventArgs e)
        {
            if (templateListView.SelectedItems.Count > 0)
            {
                //Create dialog
                var v = new EditGameDialog((Template)templateListView.SelectedItems[0].Tag);
                //Get parent control
                var f = (GameListEditDialog)Tag;

                //Show dialog
                if (v.ShowDialog() == DialogResult.OK)
                {
                    //Add ListViewItem
                    f.Profiles.Add(v.Profile);
                    f.AddIem(v.Profile);

                    //Close dialog
                    Close();
                }
            }
        }
    }
}
