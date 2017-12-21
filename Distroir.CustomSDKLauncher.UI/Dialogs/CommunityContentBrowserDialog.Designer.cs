namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class CommunityContentBrowserDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunityContentBrowserDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contentTreeView = new System.Windows.Forms.TreeView();
            this.goButton = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.contentAuthorLabel = new System.Windows.Forms.Label();
            this.contentNameLabel = new System.Windows.Forms.Label();
            this.groupImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.contentTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.goButton);
            this.splitContainer1.Panel2.Controls.Add(this.descriptionTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.contentAuthorLabel);
            this.splitContainer1.Panel2.Controls.Add(this.contentNameLabel);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // contentTreeView
            // 
            this.contentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTreeView.Location = new System.Drawing.Point(0, 0);
            this.contentTreeView.Name = "contentTreeView";
            this.contentTreeView.Size = new System.Drawing.Size(180, 450);
            this.contentTreeView.TabIndex = 0;
            this.contentTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeView_NodeMouseClick);
            this.contentTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeView_NodeMouseClick);
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(560, 9);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(44, 44);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTextBox.Font = new System.Drawing.Font("Calibri", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.descriptionTextBox.Location = new System.Drawing.Point(7, 62);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(597, 376);
            this.descriptionTextBox.TabIndex = 2;
            this.descriptionTextBox.Text = "Click on one of items on left side of the control to get more info";
            this.descriptionTextBox.Enter += new System.EventHandler(this.descriptionTextBox_Enter);
            // 
            // contentAuthorLabel
            // 
            this.contentAuthorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentAuthorLabel.Font = new System.Drawing.Font("Calibri Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contentAuthorLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.contentAuthorLabel.Location = new System.Drawing.Point(3, 35);
            this.contentAuthorLabel.Name = "contentAuthorLabel";
            this.contentAuthorLabel.Size = new System.Drawing.Size(551, 23);
            this.contentAuthorLabel.TabIndex = 1;
            this.contentAuthorLabel.Text = "N/A | Unknown";
            // 
            // contentNameLabel
            // 
            this.contentNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contentNameLabel.Location = new System.Drawing.Point(3, 9);
            this.contentNameLabel.Name = "contentNameLabel";
            this.contentNameLabel.Size = new System.Drawing.Size(551, 24);
            this.contentNameLabel.TabIndex = 0;
            this.contentNameLabel.Text = "Community content gallery";
            // 
            // groupImageList
            // 
            this.groupImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("groupImageList.ImageStream")));
            this.groupImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.groupImageList.Images.SetKeyName(0, "blank.png");
            // 
            // CommunityContentBrowserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CommunityContentBrowserDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Community Content Gallery";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView contentTreeView;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label contentAuthorLabel;
        private System.Windows.Forms.Label contentNameLabel;
        private System.Windows.Forms.ImageList groupImageList;
    }
}