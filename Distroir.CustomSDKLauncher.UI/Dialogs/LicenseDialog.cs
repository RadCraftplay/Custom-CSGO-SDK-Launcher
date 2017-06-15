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
    public partial class LicenseDialog : Form
    {
        public LicenseDialog(string license)
        {
            InitializeComponent();
            licenseRichTextBox.Text = license;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Close dialog
            this.Close();
        }
    }
}
