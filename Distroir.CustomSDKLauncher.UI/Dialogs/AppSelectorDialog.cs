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
