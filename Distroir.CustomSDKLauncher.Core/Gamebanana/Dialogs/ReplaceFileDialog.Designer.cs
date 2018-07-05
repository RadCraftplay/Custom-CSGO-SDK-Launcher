namespace Distroir.CustomSDKLauncher.Core.Gamebanana.Dialogs
{
    partial class ReplaceFileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceFileDialog));
            this.YesAllButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.NoAllButton = new System.Windows.Forms.Button();
            this.promptLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // YesAllButton
            // 
            this.YesAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.YesAllButton.Location = new System.Drawing.Point(12, 155);
            this.YesAllButton.Name = "YesAllButton";
            this.YesAllButton.Size = new System.Drawing.Size(100, 25);
            this.YesAllButton.TabIndex = 2;
            this.YesAllButton.Text = "Yes, to all";
            this.YesAllButton.UseVisualStyleBackColor = true;
            this.YesAllButton.Click += new System.EventHandler(this.YesAllButton_Click);
            // 
            // YesButton
            // 
            this.YesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.YesButton.Location = new System.Drawing.Point(118, 155);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(100, 25);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NoButton.Location = new System.Drawing.Point(224, 155);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(100, 25);
            this.NoButton.TabIndex = 0;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // NoAllButton
            // 
            this.NoAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NoAllButton.Location = new System.Drawing.Point(330, 155);
            this.NoAllButton.Name = "NoAllButton";
            this.NoAllButton.Size = new System.Drawing.Size(100, 25);
            this.NoAllButton.TabIndex = 4;
            this.NoAllButton.Text = "No, to all";
            this.NoAllButton.UseVisualStyleBackColor = true;
            this.NoAllButton.Click += new System.EventHandler(this.NoAllButton_Click);
            // 
            // promptLabel
            // 
            this.promptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.promptLabel.Location = new System.Drawing.Point(12, 9);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(418, 143);
            this.promptLabel.TabIndex = 1;
            this.promptLabel.Text = "Replace file \"\"?";
            this.promptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReplaceFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 192);
            this.Controls.Add(this.promptLabel);
            this.Controls.Add(this.NoAllButton);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.YesAllButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReplaceFileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File with same filename already exists";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button YesAllButton;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.Button NoAllButton;
        private System.Windows.Forms.Label promptLabel;
    }
}