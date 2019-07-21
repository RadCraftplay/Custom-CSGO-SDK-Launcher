namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class GameListEditDialog
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
            this.gameListView = new System.Windows.Forms.ListView();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.moveToBottomButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveToTopButton = new System.Windows.Forms.Button();
            this.createFromTemplateButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameListView
            // 
            this.gameListView.HideSelection = false;
            this.gameListView.Location = new System.Drawing.Point(17, 16);
            this.gameListView.Margin = new System.Windows.Forms.Padding(4);
            this.gameListView.MultiSelect = false;
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(303, 383);
            this.gameListView.TabIndex = 0;
            this.gameListView.UseCompatibleStateImageBehavior = false;
            this.gameListView.View = System.Windows.Forms.View.List;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(263, 407);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // moveToBottomButton
            // 
            this.moveToBottomButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_skip_270;
            this.moveToBottomButton.Location = new System.Drawing.Point(329, 285);
            this.moveToBottomButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveToBottomButton.Name = "moveToBottomButton";
            this.moveToBottomButton.Size = new System.Drawing.Size(33, 31);
            this.moveToBottomButton.TabIndex = 10;
            this.buttonsToolTip.SetToolTip(this.moveToBottomButton, "Move to bottom");
            this.moveToBottomButton.UseVisualStyleBackColor = true;
            this.moveToBottomButton.Click += new System.EventHandler(this.MoveToBottomButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_270;
            this.moveDownButton.Location = new System.Drawing.Point(329, 246);
            this.moveDownButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(33, 31);
            this.moveDownButton.TabIndex = 9;
            this.buttonsToolTip.SetToolTip(this.moveDownButton, "Move down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_090;
            this.moveUpButton.Location = new System.Drawing.Point(329, 207);
            this.moveUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(33, 31);
            this.moveUpButton.TabIndex = 8;
            this.buttonsToolTip.SetToolTip(this.moveUpButton, "Move up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // moveToTopButton
            // 
            this.moveToTopButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.arrow_skip_090;
            this.moveToTopButton.Location = new System.Drawing.Point(329, 168);
            this.moveToTopButton.Margin = new System.Windows.Forms.Padding(4);
            this.moveToTopButton.Name = "moveToTopButton";
            this.moveToTopButton.Size = new System.Drawing.Size(33, 31);
            this.moveToTopButton.TabIndex = 7;
            this.buttonsToolTip.SetToolTip(this.moveToTopButton, "Move to top");
            this.moveToTopButton.UseVisualStyleBackColor = true;
            this.moveToTopButton.Click += new System.EventHandler(this.MoveToTopButton_Click);
            // 
            // createFromTemplateButton
            // 
            this.createFromTemplateButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.notebook__plus;
            this.createFromTemplateButton.Location = new System.Drawing.Point(329, 14);
            this.createFromTemplateButton.Margin = new System.Windows.Forms.Padding(4);
            this.createFromTemplateButton.Name = "createFromTemplateButton";
            this.createFromTemplateButton.Size = new System.Drawing.Size(33, 31);
            this.createFromTemplateButton.TabIndex = 5;
            this.buttonsToolTip.SetToolTip(this.createFromTemplateButton, "Add using template");
            this.createFromTemplateButton.UseVisualStyleBackColor = true;
            this.createFromTemplateButton.Click += new System.EventHandler(this.createFromTemplateButton_Click);
            // 
            // editButton
            // 
            this.editButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.pencil;
            this.editButton.Location = new System.Drawing.Point(329, 91);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(33, 31);
            this.editButton.TabIndex = 4;
            this.buttonsToolTip.SetToolTip(this.editButton, "Edit game");
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.notebook__minus;
            this.removeButton.Location = new System.Drawing.Point(329, 53);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(33, 31);
            this.removeButton.TabIndex = 3;
            this.buttonsToolTip.SetToolTip(this.removeButton, "Remove game");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.plus;
            this.addButton.Location = new System.Drawing.Point(329, 368);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(33, 31);
            this.addButton.TabIndex = 2;
            this.buttonsToolTip.SetToolTip(this.addButton, "Add game");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // GameListEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 450);
            this.Controls.Add(this.moveToBottomButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.moveToTopButton);
            this.Controls.Add(this.createFromTemplateButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gameListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameListEditDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit games";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView gameListView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ToolTip buttonsToolTip;
        private System.Windows.Forms.Button createFromTemplateButton;
        private System.Windows.Forms.Button moveToTopButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveToBottomButton;
    }
}