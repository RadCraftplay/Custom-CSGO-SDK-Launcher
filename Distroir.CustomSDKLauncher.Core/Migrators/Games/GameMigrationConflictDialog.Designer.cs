namespace Distroir.CustomSDKLauncher.Core.Migrators.Games
{
    partial class GameMigrationConflictDialog
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
            this.listPanel = new System.Windows.Forms.Panel();
            this.listSplitContainer = new System.Windows.Forms.SplitContainer();
            this.profilesListView = new System.Windows.Forms.ListView();
            this.profilesContentsLabel = new System.Windows.Forms.Label();
            this.gamesListView = new System.Windows.Forms.ListView();
            this.gamesContentsLabel = new System.Windows.Forms.Label();
            this.keepProfilesButton = new System.Windows.Forms.Button();
            this.keepAllButton = new System.Windows.Forms.Button();
            this.keepGamesButton = new System.Windows.Forms.Button();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSplitContainer)).BeginInit();
            this.listSplitContainer.Panel1.SuspendLayout();
            this.listSplitContainer.Panel2.SuspendLayout();
            this.listSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPanel.Controls.Add(this.listSplitContainer);
            this.listPanel.Location = new System.Drawing.Point(13, 13);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(778, 394);
            this.listPanel.TabIndex = 0;
            // 
            // listSplitContainer
            // 
            this.listSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.listSplitContainer.Name = "listSplitContainer";
            // 
            // listSplitContainer.Panel1
            // 
            this.listSplitContainer.Panel1.Controls.Add(this.profilesListView);
            this.listSplitContainer.Panel1.Controls.Add(this.profilesContentsLabel);
            // 
            // listSplitContainer.Panel2
            // 
            this.listSplitContainer.Panel2.Controls.Add(this.gamesListView);
            this.listSplitContainer.Panel2.Controls.Add(this.gamesContentsLabel);
            this.listSplitContainer.Size = new System.Drawing.Size(778, 394);
            this.listSplitContainer.SplitterDistance = 389;
            this.listSplitContainer.TabIndex = 0;
            // 
            // profilesListView
            // 
            this.profilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilesListView.Location = new System.Drawing.Point(3, 25);
            this.profilesListView.Name = "profilesListView";
            this.profilesListView.Size = new System.Drawing.Size(383, 366);
            this.profilesListView.TabIndex = 1;
            this.profilesListView.UseCompatibleStateImageBehavior = false;
            this.profilesListView.View = System.Windows.Forms.View.List;
            // 
            // profilesContentsLabel
            // 
            this.profilesContentsLabel.AutoSize = true;
            this.profilesContentsLabel.Location = new System.Drawing.Point(4, 4);
            this.profilesContentsLabel.Name = "profilesContentsLabel";
            this.profilesContentsLabel.Size = new System.Drawing.Size(190, 17);
            this.profilesContentsLabel.TabIndex = 0;
            this.profilesContentsLabel.Text = "Contents of \"profiles.xml\" file:";
            // 
            // gamesListView
            // 
            this.gamesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamesListView.Location = new System.Drawing.Point(3, 25);
            this.gamesListView.Name = "gamesListView";
            this.gamesListView.Size = new System.Drawing.Size(379, 366);
            this.gamesListView.TabIndex = 1;
            this.gamesListView.UseCompatibleStateImageBehavior = false;
            this.gamesListView.View = System.Windows.Forms.View.List;
            // 
            // gamesContentsLabel
            // 
            this.gamesContentsLabel.AutoSize = true;
            this.gamesContentsLabel.Location = new System.Drawing.Point(4, 4);
            this.gamesContentsLabel.Name = "gamesContentsLabel";
            this.gamesContentsLabel.Size = new System.Drawing.Size(186, 17);
            this.gamesContentsLabel.TabIndex = 0;
            this.gamesContentsLabel.Text = "Contents of \"games.xml\" file:";
            // 
            // keepProfilesButton
            // 
            this.keepProfilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keepProfilesButton.Location = new System.Drawing.Point(12, 413);
            this.keepProfilesButton.Name = "keepProfilesButton";
            this.keepProfilesButton.Size = new System.Drawing.Size(250, 25);
            this.keepProfilesButton.TabIndex = 1;
            this.keepProfilesButton.Text = "Keep only games from profiles.xml";
            this.keepProfilesButton.UseVisualStyleBackColor = true;
            this.keepProfilesButton.Click += new System.EventHandler(this.KeepProfilesButton_Click);
            // 
            // keepAllButton
            // 
            this.keepAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keepAllButton.Location = new System.Drawing.Point(268, 413);
            this.keepAllButton.Name = "keepAllButton";
            this.keepAllButton.Size = new System.Drawing.Size(264, 25);
            this.keepAllButton.TabIndex = 2;
            this.keepAllButton.Text = "Keep all games";
            this.keepAllButton.UseVisualStyleBackColor = true;
            this.keepAllButton.Click += new System.EventHandler(this.KeepAllButton_Click);
            // 
            // keepGamesButton
            // 
            this.keepGamesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.keepGamesButton.Location = new System.Drawing.Point(538, 413);
            this.keepGamesButton.Name = "keepGamesButton";
            this.keepGamesButton.Size = new System.Drawing.Size(250, 25);
            this.keepGamesButton.TabIndex = 3;
            this.keepGamesButton.Text = "Keep only games from games.xml";
            this.keepGamesButton.UseVisualStyleBackColor = true;
            this.keepGamesButton.Click += new System.EventHandler(this.KeepGamesButton_Click);
            // 
            // GameMigrationConflictDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.keepGamesButton);
            this.Controls.Add(this.keepAllButton);
            this.Controls.Add(this.keepProfilesButton);
            this.Controls.Add(this.listPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameMigrationConflictDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Version conflict";
            this.listPanel.ResumeLayout(false);
            this.listSplitContainer.Panel1.ResumeLayout(false);
            this.listSplitContainer.Panel1.PerformLayout();
            this.listSplitContainer.Panel2.ResumeLayout(false);
            this.listSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSplitContainer)).EndInit();
            this.listSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.SplitContainer listSplitContainer;
        private System.Windows.Forms.ListView profilesListView;
        private System.Windows.Forms.Label profilesContentsLabel;
        private System.Windows.Forms.ListView gamesListView;
        private System.Windows.Forms.Label gamesContentsLabel;
        private System.Windows.Forms.Button keepProfilesButton;
        private System.Windows.Forms.Button keepAllButton;
        private System.Windows.Forms.Button keepGamesButton;
    }
}