namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class TutorialsDialog
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.tutorialNameLabel = new System.Windows.Forms.Label();
            this.gameLabel = new System.Windows.Forms.Label();
            this.tutorialLinkLabel = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.tutorialNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tutorialGamecolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tutorialNameColumnHeader,
            this.tutorialGamecolumnHeader});
            this.listView1.Location = new System.Drawing.Point(13, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(427, 140);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // tutorialNameLabel
            // 
            this.tutorialNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tutorialNameLabel.AutoSize = true;
            this.tutorialNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tutorialNameLabel.Location = new System.Drawing.Point(10, 156);
            this.tutorialNameLabel.Name = "tutorialNameLabel";
            this.tutorialNameLabel.Size = new System.Drawing.Size(0, 16);
            this.tutorialNameLabel.TabIndex = 1;
            // 
            // gameLabel
            // 
            this.gameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(12, 172);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(0, 13);
            this.gameLabel.TabIndex = 2;
            // 
            // tutorialLinkLabel
            // 
            this.tutorialLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tutorialLinkLabel.Location = new System.Drawing.Point(10, 195);
            this.tutorialLinkLabel.Name = "tutorialLinkLabel";
            this.tutorialLinkLabel.Size = new System.Drawing.Size(430, 29);
            this.tutorialLinkLabel.TabIndex = 3;
            this.tutorialLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.tutorialLinkLabel_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(365, 227);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tutorialNameColumnHeader
            // 
            this.tutorialNameColumnHeader.Text = "Tutorial name";
            this.tutorialNameColumnHeader.Width = 240;
            // 
            // tutorialGamecolumnHeader
            // 
            this.tutorialGamecolumnHeader.Text = "Game";
            this.tutorialGamecolumnHeader.Width = 180;
            // 
            // TutorialsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 262);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tutorialLinkLabel);
            this.Controls.Add(this.gameLabel);
            this.Controls.Add(this.tutorialNameLabel);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "TutorialsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "More tutorials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label tutorialNameLabel;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.LinkLabel tutorialLinkLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ColumnHeader tutorialNameColumnHeader;
        private System.Windows.Forms.ColumnHeader tutorialGamecolumnHeader;
    }
}