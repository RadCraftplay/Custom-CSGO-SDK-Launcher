namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class GamesToKeepDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.gamesToKeepLabel = new System.Windows.Forms.Label();
            this.keptGamesListView = new System.Windows.Forms.ListView();
            this.discardedGamesListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 362);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.downButton);
            this.splitContainer1.Panel1.Controls.Add(this.upButton);
            this.splitContainer1.Panel1.Controls.Add(this.gamesToKeepLabel);
            this.splitContainer1.Panel1.Controls.Add(this.keptGamesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.discardedGamesListView);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(283, 362);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_270;
            this.downButton.Location = new System.Drawing.Point(12, 161);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(25, 25);
            this.downButton.TabIndex = 5;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_090;
            this.upButton.Location = new System.Drawing.Point(43, 161);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(25, 25);
            this.upButton.TabIndex = 4;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // gamesToKeepLabel
            // 
            this.gamesToKeepLabel.AutoSize = true;
            this.gamesToKeepLabel.Location = new System.Drawing.Point(12, 9);
            this.gamesToKeepLabel.Name = "gamesToKeepLabel";
            this.gamesToKeepLabel.Size = new System.Drawing.Size(82, 13);
            this.gamesToKeepLabel.TabIndex = 3;
            this.gamesToKeepLabel.Text = "Games to keep:";
            // 
            // keptGamesListView
            // 
            this.keptGamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keptGamesListView.HideSelection = false;
            this.keptGamesListView.Location = new System.Drawing.Point(12, 25);
            this.keptGamesListView.Name = "keptGamesListView";
            this.keptGamesListView.Size = new System.Drawing.Size(258, 130);
            this.keptGamesListView.TabIndex = 2;
            this.keptGamesListView.UseCompatibleStateImageBehavior = false;
            this.keptGamesListView.View = System.Windows.Forms.View.List;
            // 
            // discardedGamesListView
            // 
            this.discardedGamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discardedGamesListView.HideSelection = false;
            this.discardedGamesListView.Location = new System.Drawing.Point(12, 16);
            this.discardedGamesListView.Name = "discardedGamesListView";
            this.discardedGamesListView.Size = new System.Drawing.Size(258, 150);
            this.discardedGamesListView.TabIndex = 1;
            this.discardedGamesListView.UseCompatibleStateImageBehavior = false;
            this.discardedGamesListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Games to ignore:";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(220, 380);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // GamesToKeepDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 415);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GamesToKeepDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Found games";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Label gamesToKeepLabel;
        private System.Windows.Forms.ListView keptGamesListView;
        private System.Windows.Forms.ListView discardedGamesListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
    }
}