namespace Distroir.CustomSDKLauncher.Core.Gamebanana.Dialogs
{
    partial class ModDownloadDialog
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
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadProgressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(13, 13);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(250, 23);
            this.downloadProgressBar.TabIndex = 0;
            // 
            // downloadProgressLabel
            // 
            this.downloadProgressLabel.Location = new System.Drawing.Point(12, 39);
            this.downloadProgressLabel.Name = "downloadProgressLabel";
            this.downloadProgressLabel.Size = new System.Drawing.Size(251, 23);
            this.downloadProgressLabel.TabIndex = 1;
            this.downloadProgressLabel.Text = "0% (0b/0b)";
            this.downloadProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModDownloadDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 68);
            this.Controls.Add(this.downloadProgressLabel);
            this.Controls.Add(this.downloadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModDownloadDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading mod...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label downloadProgressLabel;
    }
}