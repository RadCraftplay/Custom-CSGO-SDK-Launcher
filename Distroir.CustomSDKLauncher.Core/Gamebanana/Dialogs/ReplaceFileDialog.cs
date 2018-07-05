using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distroir.CustomSDKLauncher.Core.Gamebanana.Dialogs
{
    public partial class ReplaceFileDialog : Form
    {
        public ModInstaller.DefaultDuplicateAction action;

        public ReplaceFileDialog(string filename)
        {
            InitializeComponent();
            promptLabel.Text = $"Replace file \"{filename}\"?";
        }

        private void YesAllButton_Click(object sender, EventArgs e)
        {
            action = ModInstaller.DefaultDuplicateAction.ReplaceAll;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            action = ModInstaller.DefaultDuplicateAction.Replace;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            action = ModInstaller.DefaultDuplicateAction.Skip;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NoAllButton_Click(object sender, EventArgs e)
        {
            action = ModInstaller.DefaultDuplicateAction.SkipAll;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
