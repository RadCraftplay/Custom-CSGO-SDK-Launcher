/*
Custom SDK Launcher
Copyright (C) 2017-2018 Distroir

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
using Distroir.CustomSDKLauncher.Core.AppLauncher;
using Distroir.CustomSDKLauncher.Core.AppLauncher.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class AppSelectorDialog : Form
    {
        public AppInfo selectedAppInfo;

        List<AppTemplate> templates;

        public AppSelectorDialog()
        {
            InitializeComponent();
            LoadAppTemplates();
        }

        void LoadAppTemplates()
        {
            templates = new List<AppTemplate>();
            templates.Add(new BasicAppTemplate());
            templates.Add(new CustomAppTemplate());

            appListView.SmallImageList =  GetTemplateImages();
            //appListView.StateImageList = GetTemplateImages();
            AddTemplatesToList();
        }

        ImageList GetTemplateImages()
        {
            ImageList l = new ImageList();

            foreach (AppTemplate t in templates)
                l.Images.Add(t.Info.Icon);

            return l;
        }

        void AddTemplatesToList()
        {
            for (int i = 0; i < templates.Count; i++)
            {
                AppTemplate t = templates[i];

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
                AppTemplate t = (AppTemplate)appListView.SelectedItems[0].Tag;

                if (t.CanConfigure)
                    if (!t.Configure())
                        return;

                selectedAppInfo = t.Info;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
