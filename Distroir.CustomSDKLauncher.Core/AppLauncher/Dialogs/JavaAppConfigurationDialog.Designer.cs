namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    partial class JavaAppConfigurationDialog
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
            this.selectJarPathButton = new System.Windows.Forms.Button();
            this.jarFilePathTextBox = new System.Windows.Forms.TextBox();
            this.jarFileLabel = new System.Windows.Forms.Label();
            this.javaExecutablePathGroupBox = new System.Windows.Forms.GroupBox();
            this.selectJavaExePathButton = new System.Windows.Forms.Button();
            this.customPathRadioButton = new System.Windows.Forms.RadioButton();
            this.customPathTextBox = new System.Windows.Forms.TextBox();
            this.tryToFindJavaExeRadioButton = new System.Windows.Forms.RadioButton();
            this.usePathVariableRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.profileNameLabel = new System.Windows.Forms.Label();
            this.profileNameTextBox = new System.Windows.Forms.TextBox();
            this.javaExecutablePathGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectJarPathButton
            // 
            this.selectJarPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectJarPathButton.Location = new System.Drawing.Point(270, 74);
            this.selectJarPathButton.Name = "selectJarPathButton";
            this.selectJarPathButton.Size = new System.Drawing.Size(30, 23);
            this.selectJarPathButton.TabIndex = 12;
            this.selectJarPathButton.Text = "...";
            this.selectJarPathButton.UseVisualStyleBackColor = true;
            this.selectJarPathButton.Click += new System.EventHandler(this.selectJarPathButton_Click);
            // 
            // jarFilePathTextBox
            // 
            this.jarFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jarFilePathTextBox.Location = new System.Drawing.Point(12, 74);
            this.jarFilePathTextBox.Name = "jarFilePathTextBox";
            this.jarFilePathTextBox.Size = new System.Drawing.Size(252, 22);
            this.jarFilePathTextBox.TabIndex = 11;
            // 
            // jarFileLabel
            // 
            this.jarFileLabel.AutoSize = true;
            this.jarFileLabel.Location = new System.Drawing.Point(12, 54);
            this.jarFileLabel.Name = "jarFileLabel";
            this.jarFileLabel.Size = new System.Drawing.Size(54, 17);
            this.jarFileLabel.TabIndex = 13;
            this.jarFileLabel.Text = "Jar file:";
            // 
            // javaExecutablePathGroupBox
            // 
            this.javaExecutablePathGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.javaExecutablePathGroupBox.Controls.Add(this.selectJavaExePathButton);
            this.javaExecutablePathGroupBox.Controls.Add(this.customPathRadioButton);
            this.javaExecutablePathGroupBox.Controls.Add(this.customPathTextBox);
            this.javaExecutablePathGroupBox.Controls.Add(this.tryToFindJavaExeRadioButton);
            this.javaExecutablePathGroupBox.Controls.Add(this.usePathVariableRadioButton);
            this.javaExecutablePathGroupBox.Location = new System.Drawing.Point(12, 103);
            this.javaExecutablePathGroupBox.Name = "javaExecutablePathGroupBox";
            this.javaExecutablePathGroupBox.Size = new System.Drawing.Size(288, 146);
            this.javaExecutablePathGroupBox.TabIndex = 14;
            this.javaExecutablePathGroupBox.TabStop = false;
            this.javaExecutablePathGroupBox.Text = "Java executable path";
            // 
            // selectJavaExePathButton
            // 
            this.selectJavaExePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectJavaExePathButton.Enabled = false;
            this.selectJavaExePathButton.Location = new System.Drawing.Point(252, 104);
            this.selectJavaExePathButton.Name = "selectJavaExePathButton";
            this.selectJavaExePathButton.Size = new System.Drawing.Size(30, 23);
            this.selectJavaExePathButton.TabIndex = 16;
            this.selectJavaExePathButton.Text = "...";
            this.selectJavaExePathButton.UseVisualStyleBackColor = true;
            this.selectJavaExePathButton.Click += new System.EventHandler(this.selectJavaExePathButton_Click);
            // 
            // customPathRadioButton
            // 
            this.customPathRadioButton.AutoSize = true;
            this.customPathRadioButton.Location = new System.Drawing.Point(7, 78);
            this.customPathRadioButton.Name = "customPathRadioButton";
            this.customPathRadioButton.Size = new System.Drawing.Size(108, 21);
            this.customPathRadioButton.TabIndex = 3;
            this.customPathRadioButton.Text = "Custom path";
            this.customPathRadioButton.UseVisualStyleBackColor = true;
            this.customPathRadioButton.Click += new System.EventHandler(this.UpdateRadioButtons);
            // 
            // customPathTextBox
            // 
            this.customPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPathTextBox.Enabled = false;
            this.customPathTextBox.Location = new System.Drawing.Point(6, 105);
            this.customPathTextBox.Name = "customPathTextBox";
            this.customPathTextBox.Size = new System.Drawing.Size(240, 22);
            this.customPathTextBox.TabIndex = 2;
            // 
            // tryToFindJavaExeRadioButton
            // 
            this.tryToFindJavaExeRadioButton.AutoSize = true;
            this.tryToFindJavaExeRadioButton.Checked = true;
            this.tryToFindJavaExeRadioButton.Location = new System.Drawing.Point(7, 50);
            this.tryToFindJavaExeRadioButton.Name = "tryToFindJavaExeRadioButton";
            this.tryToFindJavaExeRadioButton.Size = new System.Drawing.Size(268, 21);
            this.tryToFindJavaExeRadioButton.TabIndex = 1;
            this.tryToFindJavaExeRadioButton.TabStop = true;
            this.tryToFindJavaExeRadioButton.Text = "Try to find java home folder in registry";
            this.tryToFindJavaExeRadioButton.UseVisualStyleBackColor = true;
            this.tryToFindJavaExeRadioButton.Click += new System.EventHandler(this.UpdateRadioButtons);
            // 
            // usePathVariableRadioButton
            // 
            this.usePathVariableRadioButton.AutoSize = true;
            this.usePathVariableRadioButton.Location = new System.Drawing.Point(7, 22);
            this.usePathVariableRadioButton.Name = "usePathVariableRadioButton";
            this.usePathVariableRadioButton.Size = new System.Drawing.Size(149, 21);
            this.usePathVariableRadioButton.TabIndex = 0;
            this.usePathVariableRadioButton.Text = "Use PATH variable";
            this.usePathVariableRadioButton.UseVisualStyleBackColor = true;
            this.usePathVariableRadioButton.Click += new System.EventHandler(this.UpdateRadioButtons);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(225, 255);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // profileNameLabel
            // 
            this.profileNameLabel.AutoSize = true;
            this.profileNameLabel.Location = new System.Drawing.Point(12, 9);
            this.profileNameLabel.Name = "profileNameLabel";
            this.profileNameLabel.Size = new System.Drawing.Size(91, 17);
            this.profileNameLabel.TabIndex = 16;
            this.profileNameLabel.Text = "Profile name:";
            // 
            // profileNameTextBox
            // 
            this.profileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileNameTextBox.Location = new System.Drawing.Point(12, 29);
            this.profileNameTextBox.Name = "profileNameTextBox";
            this.profileNameTextBox.Size = new System.Drawing.Size(288, 22);
            this.profileNameTextBox.TabIndex = 10;
            // 
            // JavaAppConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 290);
            this.Controls.Add(this.profileNameTextBox);
            this.Controls.Add(this.profileNameLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.javaExecutablePathGroupBox);
            this.Controls.Add(this.jarFileLabel);
            this.Controls.Add(this.selectJarPathButton);
            this.Controls.Add(this.jarFilePathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "JavaAppConfigurationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.javaExecutablePathGroupBox.ResumeLayout(false);
            this.javaExecutablePathGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectJarPathButton;
        private System.Windows.Forms.TextBox jarFilePathTextBox;
        private System.Windows.Forms.Label jarFileLabel;
        private System.Windows.Forms.GroupBox javaExecutablePathGroupBox;
        private System.Windows.Forms.Button selectJavaExePathButton;
        private System.Windows.Forms.RadioButton customPathRadioButton;
        private System.Windows.Forms.TextBox customPathTextBox;
        private System.Windows.Forms.RadioButton tryToFindJavaExeRadioButton;
        private System.Windows.Forms.RadioButton usePathVariableRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label profileNameLabel;
        private System.Windows.Forms.TextBox profileNameTextBox;
    }
}