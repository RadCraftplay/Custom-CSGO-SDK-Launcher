using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Distroir.Configuration;

namespace Custom_SDK_Launcher
{
    [Obsolete("Use Dialogs.SettingsDialog")]
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
            textBox1.Text = (string)Config.TryReadString("CSGO_DIR");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            Config.AddVariable("CSGO_DIR", textBox1.Text);
            Utils.UpdateGamedirs(textBox1.Text);
            Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox1.Text;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }
    }
}
