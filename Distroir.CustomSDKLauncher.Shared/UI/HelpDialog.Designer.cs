namespace Distroir.CustomSDKLauncher.Shared.UI
{
    partial class HelpDialog
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
            this.topicNameLabel = new System.Windows.Forms.Label();
            this.topicTextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // topicNameLabel
            // 
            this.topicNameLabel.AutoSize = true;
            this.topicNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.topicNameLabel.Location = new System.Drawing.Point(13, 13);
            this.topicNameLabel.Name = "topicNameLabel";
            this.topicNameLabel.Size = new System.Drawing.Size(151, 29);
            this.topicNameLabel.TabIndex = 0;
            this.topicNameLabel.Text = "Topic name";
            // 
            // topicTextRichTextBox
            // 
            this.topicTextRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topicTextRichTextBox.Location = new System.Drawing.Point(13, 46);
            this.topicTextRichTextBox.Name = "topicTextRichTextBox";
            this.topicTextRichTextBox.Size = new System.Drawing.Size(757, 495);
            this.topicTextRichTextBox.TabIndex = 1;
            this.topicTextRichTextBox.Text = "";
            // 
            // HelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.topicTextRichTextBox);
            this.Controls.Add(this.topicNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HelpDialog";
            this.Text = "Custom SDK Launcher - Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topicNameLabel;
        private System.Windows.Forms.RichTextBox topicTextRichTextBox;
    }
}