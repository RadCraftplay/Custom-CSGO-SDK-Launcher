namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class ResetSettingsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.gamesCheckBox = new System.Windows.Forms.CheckBox();
            this.launcherCheckBox = new System.Windows.Forms.CheckBox();
            this.otherCheckBox = new System.Windows.Forms.CheckBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Which settings would you like to reset?";
            // 
            // gamesCheckBox
            // 
            this.gamesCheckBox.AutoSize = true;
            this.gamesCheckBox.Location = new System.Drawing.Point(15, 33);
            this.gamesCheckBox.Name = "gamesCheckBox";
            this.gamesCheckBox.Size = new System.Drawing.Size(75, 21);
            this.gamesCheckBox.TabIndex = 0;
            this.gamesCheckBox.Text = "Games";
            this.gamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // launcherCheckBox
            // 
            this.launcherCheckBox.AutoSize = true;
            this.launcherCheckBox.Location = new System.Drawing.Point(15, 60);
            this.launcherCheckBox.Name = "launcherCheckBox";
            this.launcherCheckBox.Size = new System.Drawing.Size(158, 21);
            this.launcherCheckBox.TabIndex = 1;
            this.launcherCheckBox.Text = "Application launcher";
            this.launcherCheckBox.UseVisualStyleBackColor = true;
            // 
            // otherCheckBox
            // 
            this.otherCheckBox.AutoSize = true;
            this.otherCheckBox.Location = new System.Drawing.Point(15, 87);
            this.otherCheckBox.Name = "otherCheckBox";
            this.otherCheckBox.Size = new System.Drawing.Size(66, 21);
            this.otherCheckBox.TabIndex = 2;
            this.otherCheckBox.Text = "Other";
            this.otherCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.ForeColor = System.Drawing.Color.Red;
            this.resetButton.Location = new System.Drawing.Point(195, 116);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 25);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(12, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ResetSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 153);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.otherCheckBox);
            this.Controls.Add(this.launcherCheckBox);
            this.Controls.Add(this.gamesCheckBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "ResetSettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reset settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox gamesCheckBox;
        private System.Windows.Forms.CheckBox launcherCheckBox;
        private System.Windows.Forms.CheckBox otherCheckBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button cancelButton;
    }
}