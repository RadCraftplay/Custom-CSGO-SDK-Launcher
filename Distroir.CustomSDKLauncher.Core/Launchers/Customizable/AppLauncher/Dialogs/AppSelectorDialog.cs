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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Factories;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs
{
    public partial class AppSelectorDialog : Form
    {
        public AppInfo SelectedAppInfo => SelectedAppFactory.GetInfo();
        public IAppInfoFactory SelectedAppFactory { get; private set; }

        public AppSelectorDialog()
        {
            InitializeComponent();
            SetupList(appListView);
        }

        private void SetupList(ListView view)
        {
            var factories = GetFactories();
            var imageList = new ImageList();

            for (int i = 0; i < factories.Count; i++)
            {
                var factory = factories[i];
                var info = factory.GetInfo();

                var item = new ListViewItem(info.DisplayText)
                {
                    Tag = factory,
                    ImageIndex = i
                };

                imageList.Images.Add(info.Icon);
                view.Items.Add(item);
            }

            view.SmallImageList = imageList;
        }

        private List<IAppInfoFactory> GetFactories()
        {
            return new List<IAppInfoFactory>
            {
                BasicAppFactory.Default,
                CustomAppFactory.Default,
                JavaAppFactory.Default,
                SteamAppFactory.Default
            };
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (appListView.SelectedItems.Count > 0)
            {
                var factory = (IAppInfoFactory)appListView.SelectedItems[0].Tag;
                factory = factory.Configure();
                SelectedAppFactory = factory;
                
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
