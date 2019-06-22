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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMigrationConflictDialog));
            this.listPanel = new System.Windows.Forms.Panel();
            this.listSplitContainer = new System.Windows.Forms.SplitContainer();
            this.profilesListView = new System.Windows.Forms.ListView();
            this.profilesContentsLabel = new System.Windows.Forms.Label();
            this.gamesListView = new System.Windows.Forms.ListView();
            this.gamesContentsLabel = new System.Windows.Forms.Label();
            this.keepOnlyProfilesXmlRadioButton = new System.Windows.Forms.RadioButton();
            this.keepOnlyGamesXmlRadioButton = new System.Windows.Forms.RadioButton();
            this.keepAllGamesRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.ignoreFutureConflictsCheckBox = new System.Windows.Forms.CheckBox();
            this.doNotDoAnythingRadioButton = new System.Windows.Forms.RadioButton();
            this.listPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSplitContainer)).BeginInit();
            this.listSplitContainer.Panel1.SuspendLayout();
            this.listSplitContainer.Panel2.SuspendLayout();
            this.listSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPanel
            // 
            this.listPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.gamesListView.TabIndex = 2;
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
            // keepOnlyProfilesXmlRadioButton
            // 
            this.keepOnlyProfilesXmlRadioButton.AutoSize = true;
            this.keepOnlyProfilesXmlRadioButton.Location = new System.Drawing.Point(13, 411);
            this.keepOnlyProfilesXmlRadioButton.Name = "keepOnlyProfilesXmlRadioButton";
            this.keepOnlyProfilesXmlRadioButton.Size = new System.Drawing.Size(244, 21);
            this.keepOnlyProfilesXmlRadioButton.TabIndex = 3;
            this.keepOnlyProfilesXmlRadioButton.TabStop = true;
            this.keepOnlyProfilesXmlRadioButton.Text = "Keep only games from profiles.xml";
            this.keepOnlyProfilesXmlRadioButton.UseVisualStyleBackColor = true;
            this.keepOnlyProfilesXmlRadioButton.Click += new System.EventHandler(this.KeepOnlyProfilesXmlRadioButton_Click);
            // 
            // keepOnlyGamesXmlRadioButton
            // 
            this.keepOnlyGamesXmlRadioButton.AutoSize = true;
            this.keepOnlyGamesXmlRadioButton.Location = new System.Drawing.Point(12, 465);
            this.keepOnlyGamesXmlRadioButton.Name = "keepOnlyGamesXmlRadioButton";
            this.keepOnlyGamesXmlRadioButton.Size = new System.Drawing.Size(240, 21);
            this.keepOnlyGamesXmlRadioButton.TabIndex = 5;
            this.keepOnlyGamesXmlRadioButton.TabStop = true;
            this.keepOnlyGamesXmlRadioButton.Text = "Keep only games from games.xml";
            this.keepOnlyGamesXmlRadioButton.UseVisualStyleBackColor = true;
            this.keepOnlyGamesXmlRadioButton.Click += new System.EventHandler(this.KeepOnlyProfilesXmlRadioButton_Click);
            // 
            // keepAllGamesRadioButton
            // 
            this.keepAllGamesRadioButton.AutoSize = true;
            this.keepAllGamesRadioButton.Location = new System.Drawing.Point(12, 438);
            this.keepAllGamesRadioButton.Name = "keepAllGamesRadioButton";
            this.keepAllGamesRadioButton.Size = new System.Drawing.Size(126, 21);
            this.keepAllGamesRadioButton.TabIndex = 4;
            this.keepAllGamesRadioButton.TabStop = true;
            this.keepAllGamesRadioButton.Text = "Keep all games";
            this.keepAllGamesRadioButton.UseVisualStyleBackColor = true;
            this.keepAllGamesRadioButton.Click += new System.EventHandler(this.KeepOnlyProfilesXmlRadioButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(716, 522);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ignoreFutureConflictsCheckBox
            // 
            this.ignoreFutureConflictsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreFutureConflictsCheckBox.AutoSize = true;
            this.ignoreFutureConflictsCheckBox.Location = new System.Drawing.Point(12, 526);
            this.ignoreFutureConflictsCheckBox.Name = "ignoreFutureConflictsCheckBox";
            this.ignoreFutureConflictsCheckBox.Size = new System.Drawing.Size(488, 21);
            this.ignoreFutureConflictsCheckBox.TabIndex = 7;
            this.ignoreFutureConflictsCheckBox.Text = "Ignore game migration conflicts in the future (can be disabled in settings)";
            this.ignoreFutureConflictsCheckBox.UseVisualStyleBackColor = true;
            // 
            // doNotDoAnythingRadioButton
            // 
            this.doNotDoAnythingRadioButton.AutoSize = true;
            this.doNotDoAnythingRadioButton.Location = new System.Drawing.Point(12, 492);
            this.doNotDoAnythingRadioButton.Name = "doNotDoAnythingRadioButton";
            this.doNotDoAnythingRadioButton.Size = new System.Drawing.Size(149, 21);
            this.doNotDoAnythingRadioButton.TabIndex = 6;
            this.doNotDoAnythingRadioButton.TabStop = true;
            this.doNotDoAnythingRadioButton.Text = "Do not do anything";
            this.doNotDoAnythingRadioButton.UseVisualStyleBackColor = true;
            // 
            // GameMigrationConflictDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 559);
            this.Controls.Add(this.doNotDoAnythingRadioButton);
            this.Controls.Add(this.ignoreFutureConflictsCheckBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.keepAllGamesRadioButton);
            this.Controls.Add(this.keepOnlyGamesXmlRadioButton);
            this.Controls.Add(this.keepOnlyProfilesXmlRadioButton);
            this.Controls.Add(this.listPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameMigrationConflictDialog";
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.SplitContainer listSplitContainer;
        private System.Windows.Forms.ListView profilesListView;
        private System.Windows.Forms.Label profilesContentsLabel;
        private System.Windows.Forms.ListView gamesListView;
        private System.Windows.Forms.Label gamesContentsLabel;
        private System.Windows.Forms.RadioButton keepOnlyProfilesXmlRadioButton;
        private System.Windows.Forms.RadioButton keepOnlyGamesXmlRadioButton;
        private System.Windows.Forms.RadioButton keepAllGamesRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox ignoreFutureConflictsCheckBox;
        private System.Windows.Forms.RadioButton doNotDoAnythingRadioButton;
    }
}