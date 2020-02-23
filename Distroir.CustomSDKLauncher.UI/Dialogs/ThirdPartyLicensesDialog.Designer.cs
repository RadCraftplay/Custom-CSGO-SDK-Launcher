using System.ComponentModel;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class ThirdPartyLicensesDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.licensesListView = new System.Windows.Forms.ListView();
            this.licenseRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(14, 14);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.licensesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.licenseRichTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(653, 389);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // licensesListView
            // 
            this.licensesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensesListView.HideSelection = false;
            this.licensesListView.Location = new System.Drawing.Point(0, 0);
            this.licensesListView.Name = "licensesListView";
            this.licensesListView.Size = new System.Drawing.Size(174, 389);
            this.licensesListView.TabIndex = 0;
            this.licensesListView.UseCompatibleStateImageBehavior = false;
            this.licensesListView.View = System.Windows.Forms.View.List;
            this.licensesListView.SelectedIndexChanged +=
                new System.EventHandler(this.licensesListView_SelectedIndexChanged);
            // 
            // licenseRichTextBox
            // 
            this.licenseRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.licenseRichTextBox.Name = "licenseRichTextBox";
            this.licenseRichTextBox.ReadOnly = true;
            this.licenseRichTextBox.Size = new System.Drawing.Size(474, 389);
            this.licenseRichTextBox.TabIndex = 0;
            this.licenseRichTextBox.Text = "";
            // 
            // ThirdPartyLicensesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 417);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "ThirdPartyLicensesDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Third-party libraries";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox licenseRichTextBox;
        private System.Windows.Forms.ListView licensesListView;
    }
}