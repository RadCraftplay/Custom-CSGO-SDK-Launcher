namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class FirstLaunchDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.selectDirectoryButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.gameComboBox = new System.Windows.Forms.ComboBox();
            this.simpleLabel1 = new System.Windows.Forms.Label();
            this.simpleLabel2 = new System.Windows.Forms.Label();
            this.simpleRadioButton = new System.Windows.Forms.RadioButton();
            this.advancedRadioButton = new System.Windows.Forms.RadioButton();
            this.advancedLabel1 = new System.Windows.Forms.Label();
            this.advancedLabel2 = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.gameDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.advancedLabel3 = new System.Windows.Forms.Label();
            this.gameinfoDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.selectDirectoryAdvancedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Hello!";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(466, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "You are launching this application for the first time. You need to setup your fir" +
    "st game";
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTextBox.Location = new System.Drawing.Point(12, 181);
            this.directoryTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(417, 22);
            this.directoryTextBox.TabIndex = 2;
            this.directoryTextBox.TextChanged += new System.EventHandler(this.directoryTextBox_TextChanged);
            // 
            // selectDirectoryButton
            // 
            this.selectDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDirectoryButton.Location = new System.Drawing.Point(442, 178);
            this.selectDirectoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectDirectoryButton.Name = "selectDirectoryButton";
            this.selectDirectoryButton.Size = new System.Drawing.Size(33, 28);
            this.selectDirectoryButton.TabIndex = 3;
            this.selectDirectoryButton.Text = "...";
            this.selectDirectoryButton.UseVisualStyleBackColor = true;
            this.selectDirectoryButton.Click += new System.EventHandler(this.selectDirectoryButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(376, 430);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // gameComboBox
            // 
            this.gameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameComboBox.FormattingEnabled = true;
            this.gameComboBox.Location = new System.Drawing.Point(12, 129);
            this.gameComboBox.Name = "gameComboBox";
            this.gameComboBox.Size = new System.Drawing.Size(463, 24);
            this.gameComboBox.TabIndex = 1;
            this.gameComboBox.SelectedIndexChanged += new System.EventHandler(this.gameComboBox_SelectedIndexChanged);
            // 
            // simpleLabel1
            // 
            this.simpleLabel1.AutoSize = true;
            this.simpleLabel1.Location = new System.Drawing.Point(12, 109);
            this.simpleLabel1.Name = "simpleLabel1";
            this.simpleLabel1.Size = new System.Drawing.Size(106, 17);
            this.simpleLabel1.TabIndex = 6;
            this.simpleLabel1.Text = "1. Select game:";
            // 
            // simpleLabel2
            // 
            this.simpleLabel2.AutoSize = true;
            this.simpleLabel2.Location = new System.Drawing.Point(12, 160);
            this.simpleLabel2.Name = "simpleLabel2";
            this.simpleLabel2.Size = new System.Drawing.Size(158, 17);
            this.simpleLabel2.TabIndex = 7;
            this.simpleLabel2.Text = "2. Type game directory:";
            // 
            // simpleRadioButton
            // 
            this.simpleRadioButton.AutoSize = true;
            this.simpleRadioButton.Checked = true;
            this.simpleRadioButton.Location = new System.Drawing.Point(12, 85);
            this.simpleRadioButton.Name = "simpleRadioButton";
            this.simpleRadioButton.Size = new System.Drawing.Size(157, 21);
            this.simpleRadioButton.TabIndex = 0;
            this.simpleRadioButton.TabStop = true;
            this.simpleRadioButton.Text = "Simple configuration";
            this.simpleRadioButton.UseVisualStyleBackColor = true;
            this.simpleRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_Checked);
            // 
            // advancedRadioButton
            // 
            this.advancedRadioButton.AutoSize = true;
            this.advancedRadioButton.Location = new System.Drawing.Point(12, 222);
            this.advancedRadioButton.Name = "advancedRadioButton";
            this.advancedRadioButton.Size = new System.Drawing.Size(178, 21);
            this.advancedRadioButton.TabIndex = 4;
            this.advancedRadioButton.TabStop = true;
            this.advancedRadioButton.Text = "Advanced configuration";
            this.advancedRadioButton.UseVisualStyleBackColor = true;
            this.advancedRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_Checked);
            // 
            // advancedLabel1
            // 
            this.advancedLabel1.AutoSize = true;
            this.advancedLabel1.Enabled = false;
            this.advancedLabel1.Location = new System.Drawing.Point(13, 250);
            this.advancedLabel1.Name = "advancedLabel1";
            this.advancedLabel1.Size = new System.Drawing.Size(230, 17);
            this.advancedLabel1.TabIndex = 10;
            this.advancedLabel1.Text = "Game name (For example CS:GO):";
            // 
            // advancedLabel2
            // 
            this.advancedLabel2.Enabled = false;
            this.advancedLabel2.Location = new System.Drawing.Point(13, 295);
            this.advancedLabel2.Name = "advancedLabel2";
            this.advancedLabel2.Size = new System.Drawing.Size(467, 38);
            this.advancedLabel2.TabIndex = 11;
            this.advancedLabel2.Text = "Game directory path (for example C:\\Program Files\\Steam\\steamapps\\common\\Counter-" +
    "Strike Global Offensive):";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Enabled = false;
            this.gameNameTextBox.Location = new System.Drawing.Point(16, 270);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.Size = new System.Drawing.Size(459, 22);
            this.gameNameTextBox.TabIndex = 5;
            // 
            // gameDirectoryTextBox
            // 
            this.gameDirectoryTextBox.Enabled = false;
            this.gameDirectoryTextBox.Location = new System.Drawing.Point(16, 337);
            this.gameDirectoryTextBox.Name = "gameDirectoryTextBox";
            this.gameDirectoryTextBox.Size = new System.Drawing.Size(419, 22);
            this.gameDirectoryTextBox.TabIndex = 6;
            // 
            // advancedLabel3
            // 
            this.advancedLabel3.AutoSize = true;
            this.advancedLabel3.Enabled = false;
            this.advancedLabel3.Location = new System.Drawing.Point(16, 366);
            this.advancedLabel3.Name = "advancedLabel3";
            this.advancedLabel3.Size = new System.Drawing.Size(426, 17);
            this.advancedLabel3.TabIndex = 14;
            this.advancedLabel3.Text = "Name of directory containing \"gameinfo.txt\" file (for example csgo):";
            // 
            // gameinfoDirectoryTextBox
            // 
            this.gameinfoDirectoryTextBox.Enabled = false;
            this.gameinfoDirectoryTextBox.Location = new System.Drawing.Point(16, 387);
            this.gameinfoDirectoryTextBox.Name = "gameinfoDirectoryTextBox";
            this.gameinfoDirectoryTextBox.Size = new System.Drawing.Size(459, 22);
            this.gameinfoDirectoryTextBox.TabIndex = 8;
            // 
            // selectDirectoryAdvancedButton
            // 
            this.selectDirectoryAdvancedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDirectoryAdvancedButton.Enabled = false;
            this.selectDirectoryAdvancedButton.Location = new System.Drawing.Point(442, 334);
            this.selectDirectoryAdvancedButton.Margin = new System.Windows.Forms.Padding(4);
            this.selectDirectoryAdvancedButton.Name = "selectDirectoryAdvancedButton";
            this.selectDirectoryAdvancedButton.Size = new System.Drawing.Size(33, 28);
            this.selectDirectoryAdvancedButton.TabIndex = 7;
            this.selectDirectoryAdvancedButton.Text = "...";
            this.selectDirectoryAdvancedButton.UseVisualStyleBackColor = true;
            this.selectDirectoryAdvancedButton.Click += new System.EventHandler(this.selectDirectoryAdvancedButton_Click);
            // 
            // FirstLaunchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 473);
            this.Controls.Add(this.selectDirectoryAdvancedButton);
            this.Controls.Add(this.gameinfoDirectoryTextBox);
            this.Controls.Add(this.advancedLabel3);
            this.Controls.Add(this.gameDirectoryTextBox);
            this.Controls.Add(this.gameNameTextBox);
            this.Controls.Add(this.advancedLabel2);
            this.Controls.Add(this.advancedLabel1);
            this.Controls.Add(this.advancedRadioButton);
            this.Controls.Add(this.simpleRadioButton);
            this.Controls.Add(this.simpleLabel2);
            this.Controls.Add(this.simpleLabel1);
            this.Controls.Add(this.gameComboBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.selectDirectoryButton);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FirstLaunchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First launch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox gameComboBox;
        private System.Windows.Forms.Label simpleLabel1;
        private System.Windows.Forms.Label simpleLabel2;
        private System.Windows.Forms.RadioButton simpleRadioButton;
        private System.Windows.Forms.RadioButton advancedRadioButton;
        private System.Windows.Forms.Label advancedLabel1;
        private System.Windows.Forms.Label advancedLabel2;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.TextBox gameDirectoryTextBox;
        private System.Windows.Forms.Label advancedLabel3;
        private System.Windows.Forms.TextBox gameinfoDirectoryTextBox;
        private System.Windows.Forms.Button selectDirectoryAdvancedButton;
    }
}