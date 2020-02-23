using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    public partial class ThirdPartyLicensesDialog : Form
    {
        public ThirdPartyLicensesDialog()
        {
            InitializeComponent();
            AddLicenses();
        }

        private void AddLicenses()
        {
            var licenses = new Dictionary<string, string> {{"Gameloop.Vdf", Resources.Licenses.Gameloop_Vdf}};
            
            foreach (var pair in licenses)
            {
                var item = new ListViewItem(pair.Key) {Tag = pair.Value};
                licensesListView.Items.Add(item);
            }
        }

        private void licensesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedItem(licensesListView.SelectedItems);
        }

        private void LoadSelectedItem(ListView.SelectedListViewItemCollection selectedItems)
        {
            if (selectedItems.Count != 1)
                return;

            var item = selectedItems[0];
            licenseRichTextBox.Text = item.Tag as string;
        }
    }
}