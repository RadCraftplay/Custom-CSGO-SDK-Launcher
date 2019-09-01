namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class EditGameDialog
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.gameDirLabel = new System.Windows.Forms.Label();
            this.gameDirTextBox = new System.Windows.Forms.TextBox();
            this.gameDirBrowseButton = new System.Windows.Forms.Button();
            this.gameInfoTextBox = new System.Windows.Forms.TextBox();
            this.gameInfoDirLabel = new System.Windows.Forms.Label();
            this.gameDirFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.nameLabel.Location = new System.Drawing.Point(16, 20);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.toolTip.SetToolTip(this.nameLabel, "Name of the game");
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(93, 16);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(227, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(221, 117);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // gameDirLabel
            // 
            this.gameDirLabel.AutoSize = true;
            this.gameDirLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.gameDirLabel.Location = new System.Drawing.Point(16, 53);
            this.gameDirLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameDirLabel.Name = "gameDirLabel";
            this.gameDirLabel.Size = new System.Drawing.Size(70, 17);
            this.gameDirLabel.TabIndex = 3;
            this.gameDirLabel.Text = "Game dir:";
            this.toolTip.SetToolTip(this.gameDirLabel, "Game directory. For example \"C:\\Program Files\\Steam\\steamapps\\common\\Counter-Stri" +
        "ke Global Offensive\"");
            // 
            // gameDirTextBox
            // 
            this.gameDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameDirTextBox.Location = new System.Drawing.Point(93, 49);
            this.gameDirTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.gameDirTextBox.Name = "gameDirTextBox";
            this.gameDirTextBox.Size = new System.Drawing.Size(185, 22);
            this.gameDirTextBox.TabIndex = 1;
            // 
            // gameDirBrowseButton
            // 
            this.gameDirBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameDirBrowseButton.Location = new System.Drawing.Point(288, 48);
            this.gameDirBrowseButton.Margin = new System.Windows.Forms.Padding(4);
            this.gameDirBrowseButton.Name = "gameDirBrowseButton";
            this.gameDirBrowseButton.Size = new System.Drawing.Size(33, 28);
            this.gameDirBrowseButton.TabIndex = 2;
            this.gameDirBrowseButton.Text = "...";
            this.gameDirBrowseButton.UseVisualStyleBackColor = true;
            this.gameDirBrowseButton.Click += new System.EventHandler(this.gameDirBrowseButton_Click);
            // 
            // gameInfoTextBox
            // 
            this.gameInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameInfoTextBox.Location = new System.Drawing.Point(116, 81);
            this.gameInfoTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.gameInfoTextBox.Name = "gameInfoTextBox";
            this.gameInfoTextBox.Size = new System.Drawing.Size(204, 22);
            this.gameInfoTextBox.TabIndex = 3;
            // 
            // gameInfoDirLabel
            // 
            this.gameInfoDirLabel.AutoSize = true;
            this.gameInfoDirLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.gameInfoDirLabel.Location = new System.Drawing.Point(16, 85);
            this.gameInfoDirLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameInfoDirLabel.Name = "gameInfoDirLabel";
            this.gameInfoDirLabel.Size = new System.Drawing.Size(93, 17);
            this.gameInfoDirLabel.TabIndex = 7;
            this.gameInfoDirLabel.Text = "Gameinfo dir:";
            this.toolTip.SetToolTip(this.gameInfoDirLabel, "Name of directory containing gameinfo.txt file. For example \"csgo\"");
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            // 
            // EditItemDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 160);
            this.Controls.Add(this.gameInfoDirLabel);
            this.Controls.Add(this.gameInfoTextBox);
            this.Controls.Add(this.gameDirBrowseButton);
            this.Controls.Add(this.gameDirTextBox);
            this.Controls.Add(this.gameDirLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1280, 207);
            this.MinimumSize = new System.Drawing.Size(355, 207);
            this.Name = "EditItemDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label gameDirLabel;
        private System.Windows.Forms.TextBox gameDirTextBox;
        private System.Windows.Forms.Button gameDirBrowseButton;
        private System.Windows.Forms.TextBox gameInfoTextBox;
        private System.Windows.Forms.Label gameInfoDirLabel;
        private System.Windows.Forms.FolderBrowserDialog gameDirFolderBrowserDialog;
        private System.Windows.Forms.ToolTip toolTip;
    }
}