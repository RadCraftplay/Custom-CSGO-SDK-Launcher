namespace Distroir.CustomSDKLauncher.Core.AppLauncher.Controls
{
    partial class IconSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultIconButton = new System.Windows.Forms.Button();
            this.customAppIconButton = new System.Windows.Forms.Button();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.iconLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultIconButton
            // 
            this.defaultIconButton.Location = new System.Drawing.Point(0, 26);
            this.defaultIconButton.Name = "defaultIconButton";
            this.defaultIconButton.Size = new System.Drawing.Size(75, 25);
            this.defaultIconButton.TabIndex = 11;
            this.defaultIconButton.Text = "Default";
            this.defaultIconButton.UseVisualStyleBackColor = true;
            this.defaultIconButton.Click += new System.EventHandler(this.DefaultIconButton_Click);
            // 
            // customAppIconButton
            // 
            this.customAppIconButton.Location = new System.Drawing.Point(81, 26);
            this.customAppIconButton.Name = "customAppIconButton";
            this.customAppIconButton.Size = new System.Drawing.Size(75, 25);
            this.customAppIconButton.TabIndex = 12;
            this.customAppIconButton.Text = "Custom";
            this.customAppIconButton.UseVisualStyleBackColor = true;
            this.customAppIconButton.Click += new System.EventHandler(this.CustomAppIconButton_Click);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(40, 0);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox.TabIndex = 10;
            this.iconPictureBox.TabStop = false;
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.Location = new System.Drawing.Point(0, 1);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(38, 17);
            this.iconLabel.TabIndex = 9;
            this.iconLabel.Text = "Icon:";
            // 
            // IconSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.defaultIconButton);
            this.Controls.Add(this.customAppIconButton);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.iconLabel);
            this.MaximumSize = new System.Drawing.Size(0, 52);
            this.MinimumSize = new System.Drawing.Size(156, 52);
            this.Name = "IconSelector";
            this.Size = new System.Drawing.Size(156, 52);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button defaultIconButton;
        private System.Windows.Forms.Button customAppIconButton;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label iconLabel;
    }
}
