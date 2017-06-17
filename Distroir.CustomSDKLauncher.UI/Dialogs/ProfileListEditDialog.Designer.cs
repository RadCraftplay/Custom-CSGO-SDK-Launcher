﻿namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class ProfileListEditDialog
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
            this.components = new System.ComponentModel.Container();
            this.profileListView = new System.Windows.Forms.ListView();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.createFromTemplateButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // profileListView
            // 
            this.profileListView.Location = new System.Drawing.Point(13, 13);
            this.profileListView.MultiSelect = false;
            this.profileListView.Name = "profileListView";
            this.profileListView.Size = new System.Drawing.Size(228, 312);
            this.profileListView.TabIndex = 0;
            this.profileListView.UseCompatibleStateImageBehavior = false;
            this.profileListView.View = System.Windows.Forms.View.List;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(197, 331);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // createFromTemplateButton
            // 
            this.createFromTemplateButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.notebook__plus;
            this.createFromTemplateButton.Location = new System.Drawing.Point(247, 300);
            this.createFromTemplateButton.Name = "createFromTemplateButton";
            this.createFromTemplateButton.Size = new System.Drawing.Size(25, 25);
            this.createFromTemplateButton.TabIndex = 5;
            this.buttonsToolTip.SetToolTip(this.createFromTemplateButton, "Add using template");
            this.createFromTemplateButton.UseVisualStyleBackColor = true;
            this.createFromTemplateButton.Click += new System.EventHandler(this.createFromTemplateButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.pencil;
            this.editButton.Location = new System.Drawing.Point(247, 74);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(25, 25);
            this.editButton.TabIndex = 4;
            this.buttonsToolTip.SetToolTip(this.editButton, "Edit profile");
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.minus;
            this.removeButton.Location = new System.Drawing.Point(247, 43);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(25, 25);
            this.removeButton.TabIndex = 3;
            this.buttonsToolTip.SetToolTip(this.removeButton, "Remove profile");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.plus;
            this.addButton.Location = new System.Drawing.Point(247, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(25, 25);
            this.addButton.TabIndex = 2;
            this.buttonsToolTip.SetToolTip(this.addButton, "Add profile");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ProfileListEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 366);
            this.Controls.Add(this.createFromTemplateButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.profileListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfileListEditDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit profiles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView profileListView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ToolTip buttonsToolTip;
        private System.Windows.Forms.Button createFromTemplateButton;
    }
}