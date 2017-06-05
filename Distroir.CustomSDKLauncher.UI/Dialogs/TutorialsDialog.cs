using Distroir.CustomSDKLauncher.Core;
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
    public partial class TutorialsDialog : Form
    {
        public TutorialsDialog()
        {
            //Create controls
            InitializeComponent();
            //Load tutorials
            LoadTutorials();
        }

        void LoadTutorials()
        {
            //TODO: Load tutorials
            foreach (Tutorial t in TutorialManager.Tutorials)
            {
                //Create listviewitem
                ListViewItem i = new ListViewItem(t.Name);
                i.SubItems.Add(t.Game);
                i.Tag = t;

                listView1.Items.Add(i);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //Close dialog
            Close();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected == true)
            {
                //Get tutorial
                Tutorial t = (Tutorial)e.Item.Tag;
                //Set text
                tutorialNameLabel.Text = t.Name;
                gameLabel.Text = t.Game;
                tutorialLinkLabel.Text = t.Url;
            }
        }

        private void tutorialLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tutorialLinkLabel.Text != string.Empty)
            {
                Utils.ShellLaunch(tutorialLinkLabel.Text);
            }
        }
    }
}
