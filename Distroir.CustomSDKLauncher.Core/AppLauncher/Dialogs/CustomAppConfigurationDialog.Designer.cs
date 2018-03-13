namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Dialogs
{
    partial class CustomAppConfigurationDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.argumentsCheckBox = new System.Windows.Forms.CheckBox();
            this.customWorkingDirectoryCheckBox = new System.Windows.Forms.CheckBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.argumentsTextBox = new System.Windows.Forms.TextBox();
            this.customWorkingDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.iconLabel = new System.Windows.Forms.Label();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            this.overrideAppIconButton = new System.Windows.Forms.Button();
            this.defaultIconButton = new System.Windows.Forms.Button();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.selectCustomWorkingDirectoryButton = new System.Windows.Forms.Button();
            this.buttonLabelLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(295, 294);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 25);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(214, 294);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 25);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 55);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(41, 17);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Path:";
            // 
            // argumentsCheckBox
            // 
            this.argumentsCheckBox.AutoSize = true;
            this.argumentsCheckBox.Location = new System.Drawing.Point(11, 103);
            this.argumentsCheckBox.Name = "argumentsCheckBox";
            this.argumentsCheckBox.Size = new System.Drawing.Size(98, 21);
            this.argumentsCheckBox.TabIndex = 3;
            this.argumentsCheckBox.Text = "Arguments";
            this.argumentsCheckBox.UseVisualStyleBackColor = true;
            this.argumentsCheckBox.CheckedChanged += new System.EventHandler(this.argumentsCheckBox_CheckedChanged);
            // 
            // customWorkingDirectoryCheckBox
            // 
            this.customWorkingDirectoryCheckBox.AutoSize = true;
            this.customWorkingDirectoryCheckBox.Location = new System.Drawing.Point(11, 158);
            this.customWorkingDirectoryCheckBox.Name = "customWorkingDirectoryCheckBox";
            this.customWorkingDirectoryCheckBox.Size = new System.Drawing.Size(188, 21);
            this.customWorkingDirectoryCheckBox.TabIndex = 4;
            this.customWorkingDirectoryCheckBox.Text = "Custom working directory";
            this.customWorkingDirectoryCheckBox.UseVisualStyleBackColor = true;
            this.customWorkingDirectoryCheckBox.CheckedChanged += new System.EventHandler(this.customWorkingDirectoryCheckBox_CheckedChanged);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(11, 75);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(322, 22);
            this.pathTextBox.TabIndex = 5;
            // 
            // argumentsTextBox
            // 
            this.argumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.argumentsTextBox.Enabled = false;
            this.argumentsTextBox.Location = new System.Drawing.Point(11, 130);
            this.argumentsTextBox.Name = "argumentsTextBox";
            this.argumentsTextBox.Size = new System.Drawing.Size(358, 22);
            this.argumentsTextBox.TabIndex = 5;
            // 
            // customWorkingDirectoryTextBox
            // 
            this.customWorkingDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customWorkingDirectoryTextBox.Enabled = false;
            this.customWorkingDirectoryTextBox.Location = new System.Drawing.Point(11, 185);
            this.customWorkingDirectoryTextBox.Name = "customWorkingDirectoryTextBox";
            this.customWorkingDirectoryTextBox.Size = new System.Drawing.Size(322, 22);
            this.customWorkingDirectoryTextBox.TabIndex = 5;
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.Location = new System.Drawing.Point(12, 216);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(38, 17);
            this.iconLabel.TabIndex = 6;
            this.iconLabel.Text = "Icon:";
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Location = new System.Drawing.Point(56, 216);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(20, 20);
            this.IconPictureBox.TabIndex = 7;
            this.IconPictureBox.TabStop = false;
            // 
            // overrideAppIconButton
            // 
            this.overrideAppIconButton.Location = new System.Drawing.Point(92, 242);
            this.overrideAppIconButton.Name = "overrideAppIconButton";
            this.overrideAppIconButton.Size = new System.Drawing.Size(75, 25);
            this.overrideAppIconButton.TabIndex = 8;
            this.overrideAppIconButton.Text = "Override";
            this.overrideAppIconButton.UseVisualStyleBackColor = true;
            this.overrideAppIconButton.Click += new System.EventHandler(this.overrideAppIconButton_Click);
            // 
            // defaultIconButton
            // 
            this.defaultIconButton.Location = new System.Drawing.Point(11, 242);
            this.defaultIconButton.Name = "defaultIconButton";
            this.defaultIconButton.Size = new System.Drawing.Size(75, 25);
            this.defaultIconButton.TabIndex = 8;
            this.defaultIconButton.Text = "Default";
            this.defaultIconButton.UseVisualStyleBackColor = true;
            this.defaultIconButton.Click += new System.EventHandler(this.defaultIconButton_Click);
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(339, 75);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(30, 23);
            this.selectPathButton.TabIndex = 9;
            this.selectPathButton.Text = "...";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // selectCustomWorkingDirectoryButton
            // 
            this.selectCustomWorkingDirectoryButton.Location = new System.Drawing.Point(339, 184);
            this.selectCustomWorkingDirectoryButton.Name = "selectCustomWorkingDirectoryButton";
            this.selectCustomWorkingDirectoryButton.Size = new System.Drawing.Size(30, 23);
            this.selectCustomWorkingDirectoryButton.TabIndex = 9;
            this.selectCustomWorkingDirectoryButton.Text = "...";
            this.selectCustomWorkingDirectoryButton.UseVisualStyleBackColor = true;
            this.selectCustomWorkingDirectoryButton.Click += new System.EventHandler(this.selectCustomWorkingDirectoryButton_Click);
            // 
            // buttonLabelLabel
            // 
            this.buttonLabelLabel.AutoSize = true;
            this.buttonLabelLabel.Location = new System.Drawing.Point(12, 9);
            this.buttonLabelLabel.Name = "buttonLabelLabel";
            this.buttonLabelLabel.Size = new System.Drawing.Size(49, 17);
            this.buttonLabelLabel.TabIndex = 10;
            this.buttonLabelLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(11, 30);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(358, 22);
            this.nameTextBox.TabIndex = 11;
            // 
            // CustomAppConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 331);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.buttonLabelLabel);
            this.Controls.Add(this.selectCustomWorkingDirectoryButton);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.defaultIconButton);
            this.Controls.Add(this.overrideAppIconButton);
            this.Controls.Add(this.IconPictureBox);
            this.Controls.Add(this.iconLabel);
            this.Controls.Add(this.customWorkingDirectoryTextBox);
            this.Controls.Add(this.argumentsTextBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.customWorkingDirectoryCheckBox);
            this.Controls.Add(this.argumentsCheckBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomAppConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.CheckBox argumentsCheckBox;
        private System.Windows.Forms.CheckBox customWorkingDirectoryCheckBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox argumentsTextBox;
        private System.Windows.Forms.TextBox customWorkingDirectoryTextBox;
        private System.Windows.Forms.Label iconLabel;
        private System.Windows.Forms.PictureBox IconPictureBox;
        private System.Windows.Forms.Button overrideAppIconButton;
        private System.Windows.Forms.Button defaultIconButton;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button selectCustomWorkingDirectoryButton;
        private System.Windows.Forms.Label buttonLabelLabel;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}