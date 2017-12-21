using Distroir.CustomSDKLauncher.Core;
using Distroir.CustomSDKLauncher.Core.CommunityContent;
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
    public partial class CommunityContentBrowserDialog : Form
    {
        public CommunityContentBrowserDialog()
        {
            InitializeComponent();

            LoadContent();
            BuildTree();
        }

        private void LoadContent()
        {
            if (ContentManager.ContentGroups == null)
                ContentManager.LoadContentGroups();
        }

        void BuildTree()
        {
            //We may add option to disable thumbnails in the future
            //contentTreeView.ImageList = groupImageList;
            splitContainer1.FixedPanel = FixedPanel.Panel1;

            foreach (ContentGroup g in ContentManager.ContentGroups)
            {
                AddGroup(g);
            }
        }

        /// <summary>
        /// Adds ContentGroup
        /// </summary>
        /// <param name="g">Content group to add</param>
        void AddGroup(ContentGroup g)
        {
            TreeNode n = AddItem(g.Name);
            n.Expand();

            foreach (ContentInfo i in g.Contents)
            {
                AddItem(i.Name, i, n);
            }
        }

        /// <summary>
        /// Adds item to contentTreeView
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Added node</returns>
        TreeNode AddItem(string name)
        {
            return AddItem(name, null);
        }

        /// <summary>
        /// Adds item to contentTreeView
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Added node</returns>
        TreeNode AddItem(string name, Image thumbnail)
        {
            return AddItem(name, null, thumbnail);
        }

        /// <summary>
        /// Adds item to contentTreeView
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="tag">Item tag</param>
        /// <returns>Added node</returns>
        TreeNode AddItem(string name, object tag)
        {
            TreeNode n = new TreeNode(name);
            n.Tag = tag;

            contentTreeView.Nodes.Add(n);

            return n;
        }

        /// <summary>
        /// Adds item to parent node
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="tag">Item tag</param>
        /// <param name="parent">Parent node</param>
        /// <returns>Added node</returns>
        TreeNode AddItem(string name, object tag, TreeNode parent)
        {
            TreeNode n = new TreeNode(name);
            n.Tag = tag;

            parent.Nodes.Add(n);

            return n;
        }

        /// <summary>
        /// Adds item to contentTreeView
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="tag">Item tag</param>
        /// <param name="thumbnail"></param>
        /// <returns></returns>
        TreeNode AddItem(string name, object tag, Image thumbnail)
        {
            TreeNode n = AddItem(name, tag);

            /*
            groupImageList.Images.Add(thumbnail);
            n.ImageIndex = groupImageList.Images.Count - 1;
            n.SelectedImageIndex = n.ImageIndex;
            */

            return n;
        }

        void LoadContent(TreeNode n)
        {
            string name = null;
            string text = null;
            string desc = null;

            if (n.Tag != null)
            {
                ContentInfo info = (ContentInfo)n.Tag;
                name = info.Name;
                text = info.Game == "" ? $"{info.Author} | {info.Engine}" : $"{info.Author} | {info.Game}";
                desc = info.Description;
            }

            contentNameLabel.Text = name;
            contentAuthorLabel.Text = text;
            descriptionTextBox.Text = desc;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            TreeNode n = contentTreeView.SelectedNode;

            if (n.Tag == null)
                return;

            ContentInfo info = (ContentInfo)n.Tag;
            Utils.ShellLaunch(info.url);
        }

        private void contentTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                LoadContent(((TreeView)sender).GetNodeAt(e.Location));
        }

        private void descriptionTextBox_Enter(object sender, EventArgs e)
        {
            contentTreeView.Focus();
        }
    }
}
