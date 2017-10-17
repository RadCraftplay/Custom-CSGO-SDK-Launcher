namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class ChooseTemplateDialog
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
            this.templateListView = new System.Windows.Forms.ListView();
            this.useButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // templateListView
            // 
            this.templateListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateListView.Location = new System.Drawing.Point(17, 36);
            this.templateListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.templateListView.MultiSelect = false;
            this.templateListView.Name = "templateListView";
            this.templateListView.Size = new System.Drawing.Size(344, 235);
            this.templateListView.TabIndex = 0;
            this.templateListView.UseCompatibleStateImageBehavior = false;
            this.templateListView.View = System.Windows.Forms.View.List;
            // 
            // useButton
            // 
            this.useButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.useButton.Location = new System.Drawing.Point(263, 279);
            this.useButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useButton.Name = "useButton";
            this.useButton.Size = new System.Drawing.Size(100, 28);
            this.useButton.TabIndex = 1;
            this.useButton.Text = "Use";
            this.useButton.UseVisualStyleBackColor = true;
            this.useButton.Click += new System.EventHandler(this.useButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select template:";
            // 
            // ChooseTemplateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useButton);
            this.Controls.Add(this.templateListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChooseTemplateDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView templateListView;
        private System.Windows.Forms.Button useButton;
        private System.Windows.Forms.Label label1;
    }
}