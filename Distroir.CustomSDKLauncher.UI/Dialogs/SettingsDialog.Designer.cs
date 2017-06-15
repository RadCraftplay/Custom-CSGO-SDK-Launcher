namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class SettingsDialog
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.profilesTabPage = new System.Windows.Forms.TabPage();
            this.editListOfProfilesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.profileLabel = new System.Windows.Forms.Label();
            this.profileListComboBox = new System.Windows.Forms.ComboBox();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.displayCurrentlySelectedProfileCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.profilesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.profilesTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.Location = new System.Drawing.Point(13, 13);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(338, 183);
            this.tabControl.TabIndex = 0;
            // 
            // profilesTabPage
            // 
            this.profilesTabPage.Controls.Add(this.displayCurrentlySelectedProfileCheckBox);
            this.profilesTabPage.Controls.Add(this.editListOfProfilesLinkLabel);
            this.profilesTabPage.Controls.Add(this.profileLabel);
            this.profilesTabPage.Controls.Add(this.profileListComboBox);
            this.profilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.profilesTabPage.Name = "profilesTabPage";
            this.profilesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.profilesTabPage.Size = new System.Drawing.Size(330, 157);
            this.profilesTabPage.TabIndex = 0;
            this.profilesTabPage.Text = "Profiles";
            this.profilesTabPage.UseVisualStyleBackColor = true;
            // 
            // editListOfProfilesLinkLabel
            // 
            this.editListOfProfilesLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editListOfProfilesLinkLabel.AutoSize = true;
            this.editListOfProfilesLinkLabel.Location = new System.Drawing.Point(236, 30);
            this.editListOfProfilesLinkLabel.Name = "editListOfProfilesLinkLabel";
            this.editListOfProfilesLinkLabel.Size = new System.Drawing.Size(88, 13);
            this.editListOfProfilesLinkLabel.TabIndex = 3;
            this.editListOfProfilesLinkLabel.TabStop = true;
            this.editListOfProfilesLinkLabel.Text = "Edit list of profiles";
            this.editListOfProfilesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // profileLabel
            // 
            this.profileLabel.AutoSize = true;
            this.profileLabel.Location = new System.Drawing.Point(7, 9);
            this.profileLabel.Name = "profileLabel";
            this.profileLabel.Size = new System.Drawing.Size(39, 13);
            this.profileLabel.TabIndex = 2;
            this.profileLabel.Text = "Profile:";
            // 
            // profileListComboBox
            // 
            this.profileListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileListComboBox.FormattingEnabled = true;
            this.profileListComboBox.Location = new System.Drawing.Point(52, 6);
            this.profileListComboBox.Name = "profileListComboBox";
            this.profileListComboBox.Size = new System.Drawing.Size(272, 21);
            this.profileListComboBox.TabIndex = 1;
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(330, 157);
            this.aboutTabPage.TabIndex = 1;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(276, 202);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // displayCurrentlySelectedProfileCheckBox
            // 
            this.displayCurrentlySelectedProfileCheckBox.AutoSize = true;
            this.displayCurrentlySelectedProfileCheckBox.Location = new System.Drawing.Point(10, 46);
            this.displayCurrentlySelectedProfileCheckBox.Name = "displayCurrentlySelectedProfileCheckBox";
            this.displayCurrentlySelectedProfileCheckBox.Size = new System.Drawing.Size(206, 17);
            this.displayCurrentlySelectedProfileCheckBox.TabIndex = 4;
            this.displayCurrentlySelectedProfileCheckBox.Text = "Display currently selected profile name";
            this.displayCurrentlySelectedProfileCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 237);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.profilesTabPage.ResumeLayout(false);
            this.profilesTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage profilesTabPage;
        private System.Windows.Forms.LinkLabel editListOfProfilesLinkLabel;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.ComboBox profileListComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.CheckBox displayCurrentlySelectedProfileCheckBox;
    }
}