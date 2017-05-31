/*
Custom SDK Launcher
Copyright (C) 2017 Distroir

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
using Distroir.Configuration;
using System;
using System.Windows.Forms;

namespace Custom_SDK_Launcher
{
    [Obsolete("Use Dialogs.SettingsDialog instead")]
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
