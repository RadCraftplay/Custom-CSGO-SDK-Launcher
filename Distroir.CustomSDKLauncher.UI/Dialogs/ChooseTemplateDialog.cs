using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Distroir.CustomSDKLauncher.Core;

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
            //Clear list
            templateListView.Items.Clear();

            //For every template
            foreach (Template t in TemplateManager.Templates)
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
                //Close dialog
                Close();

                //Create dialog
                var v = new EditItemDialog((Template)templateListView.SelectedItems[0].Tag);
                //Get parent control
                var f = (ProfileListEditDialog)Tag;

                //Show dialog
                if (v.ShowDialog() == DialogResult.OK)
                {
                    //Add ListViewItem
                    f.Profiles.Add(v.Profile);
                    f.AddIem(v.Profile);
                }
            }
        }
    }
}
