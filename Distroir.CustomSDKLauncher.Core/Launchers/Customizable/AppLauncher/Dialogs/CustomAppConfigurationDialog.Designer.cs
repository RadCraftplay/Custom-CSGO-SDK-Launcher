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
            this.selectPathButton = new System.Windows.Forms.Button();
            this.selectCustomWorkingDirectoryButton = new System.Windows.Forms.Button();
            this.buttonLabelLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.iconSelector = new Distroir.CustomSDKLauncher.Core.AppLauncher.Controls.IconSelector();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(258, 276);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(65, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(187, 276);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(65, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(10, 52);
            this.pathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(34, 15);
            this.pathLabel.TabIndex = 2;
            this.pathLabel.Text = "Path:";
            // 
            // argumentsCheckBox
            // 
            this.argumentsCheckBox.AutoSize = true;
            this.argumentsCheckBox.Location = new System.Drawing.Point(9, 97);
            this.argumentsCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.argumentsCheckBox.Name = "argumentsCheckBox";
            this.argumentsCheckBox.Size = new System.Drawing.Size(85, 19);
            this.argumentsCheckBox.TabIndex = 3;
            this.argumentsCheckBox.Text = "Arguments";
            this.argumentsCheckBox.UseVisualStyleBackColor = true;
            this.argumentsCheckBox.CheckedChanged += new System.EventHandler(this.argumentsCheckBox_CheckedChanged);
            // 
            // customWorkingDirectoryCheckBox
            // 
            this.customWorkingDirectoryCheckBox.AutoSize = true;
            this.customWorkingDirectoryCheckBox.Location = new System.Drawing.Point(9, 148);
            this.customWorkingDirectoryCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customWorkingDirectoryCheckBox.Name = "customWorkingDirectoryCheckBox";
            this.customWorkingDirectoryCheckBox.Size = new System.Drawing.Size(164, 19);
            this.customWorkingDirectoryCheckBox.TabIndex = 5;
            this.customWorkingDirectoryCheckBox.Text = "Custom working directory";
            this.customWorkingDirectoryCheckBox.UseVisualStyleBackColor = true;
            this.customWorkingDirectoryCheckBox.CheckedChanged +=
                new System.EventHandler(this.customWorkingDirectoryCheckBox_CheckedChanged);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Location = new System.Drawing.Point(9, 70);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(282, 23);
            this.pathTextBox.TabIndex = 1;
            this.pathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            // 
            // argumentsTextBox
            // 
            this.argumentsTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.argumentsTextBox.Enabled = false;
            this.argumentsTextBox.Location = new System.Drawing.Point(9, 122);
            this.argumentsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.argumentsTextBox.Name = "argumentsTextBox";
            this.argumentsTextBox.Size = new System.Drawing.Size(314, 23);
            this.argumentsTextBox.TabIndex = 4;
            // 
            // customWorkingDirectoryTextBox
            // 
            this.customWorkingDirectoryTextBox.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.customWorkingDirectoryTextBox.Enabled = false;
            this.customWorkingDirectoryTextBox.Location = new System.Drawing.Point(9, 173);
            this.customWorkingDirectoryTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customWorkingDirectoryTextBox.Name = "customWorkingDirectoryTextBox";
            this.customWorkingDirectoryTextBox.Size = new System.Drawing.Size(282, 23);
            this.customWorkingDirectoryTextBox.TabIndex = 6;
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(296, 70);
            this.selectPathButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(26, 22);
            this.selectPathButton.TabIndex = 2;
            this.selectPathButton.Text = "...";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // selectCustomWorkingDirectoryButton
            // 
            this.selectCustomWorkingDirectoryButton.Location = new System.Drawing.Point(296, 173);
            this.selectCustomWorkingDirectoryButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectCustomWorkingDirectoryButton.Name = "selectCustomWorkingDirectoryButton";
            this.selectCustomWorkingDirectoryButton.Size = new System.Drawing.Size(26, 22);
            this.selectCustomWorkingDirectoryButton.TabIndex = 7;
            this.selectCustomWorkingDirectoryButton.Text = "...";
            this.selectCustomWorkingDirectoryButton.UseVisualStyleBackColor = true;
            this.selectCustomWorkingDirectoryButton.Click +=
                new System.EventHandler(this.selectCustomWorkingDirectoryButton_Click);
            // 
            // buttonLabelLabel
            // 
            this.buttonLabelLabel.AutoSize = true;
            this.buttonLabelLabel.Location = new System.Drawing.Point(10, 8);
            this.buttonLabelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buttonLabelLabel.Name = "buttonLabelLabel";
            this.buttonLabelLabel.Size = new System.Drawing.Size(42, 15);
            this.buttonLabelLabel.TabIndex = 10;
            this.buttonLabelLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(9, 28);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(314, 23);
            this.nameTextBox.TabIndex = 0;
            // 
            // iconSelector
            // 
            this.iconSelector.Location = new System.Drawing.Point(10, 200);
            this.iconSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iconSelector.MaximumSize = new System.Drawing.Size(0, 57);
            this.iconSelector.MinimumSize = new System.Drawing.Size(142, 57);
            this.iconSelector.Name = "iconSelector";
            this.iconSelector.Size = new System.Drawing.Size(142, 57);
            this.iconSelector.TabIndex = 8;
            // 
            // CustomAppConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 310);
            this.Controls.Add(this.iconSelector);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.buttonLabelLabel);
            this.Controls.Add(this.selectCustomWorkingDirectoryButton);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.customWorkingDirectoryTextBox);
            this.Controls.Add(this.argumentsTextBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.customWorkingDirectoryCheckBox);
            this.Controls.Add(this.argumentsCheckBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomAppConfigurationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
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
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.Button selectCustomWorkingDirectoryButton;
        private System.Windows.Forms.Label buttonLabelLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private Distroir.CustomSDKLauncher.Core.AppLauncher.Controls.IconSelector iconSelector;
    }
}