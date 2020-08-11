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
using Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Templates;

namespace Distroir.CustomSDKLauncher.Core.Launchers.Customizable.AppLauncher.Dialogs
{
    public partial class AppSelectorDialog : Form
    {
        public AppTemplate SelectedAppTemplate { get; private set; }
        public IAppInfoFactory SelectedAppFactory { get; private set; }
        private List<AppTemplate> _templates;

        public AppSelectorDialog()
        {
            InitializeComponent();
            LoadAppTemplates();
        }

        void LoadAppTemplates()
        {
            _templates = new List<AppTemplate>();
            _templates.Add(new BasicAppTemplate());
            _templates.Add(new CustomAppTemplate());
            _templates.Add(new JavaAppTemplate());
            _templates.Add(new SteamAppTemplate());

            appListView.SmallImageList =  GetTemplateImages();
            //appListView.StateImageList = GetTemplateImages();
            AddTemplatesToList();
        }

        ImageList GetTemplateImages()
        {
            ImageList l = new ImageList();

            foreach (AppTemplate t in _templates)
                l.Images.Add(t.Info.Icon);

            return l;
        }

        void AddTemplatesToList()
        {
            for (int i = 0; i < _templates.Count; i++)
            {
                AppTemplate t = _templates[i];

                appListView.Items.Add(new ListViewItem(t.Info.DisplayText)
                {
                    Tag = t,
                    ImageIndex = i,
                });
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (appListView.SelectedItems.Count > 0)
            {
                AppTemplate template = (AppTemplate)appListView.SelectedItems[0].Tag;

                if (template.CanConfigure)
                    if (!template.Configure())
                        return;

                SelectedAppTemplate = template;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
