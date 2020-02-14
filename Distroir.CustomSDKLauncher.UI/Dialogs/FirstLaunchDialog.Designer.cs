using System.ComponentModel;

namespace Distroir.CustomSDKLauncher.UI.Dialogs
{
    partial class FirstLaunchDialog
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
            this.informationLabel = new System.Windows.Forms.Label();
            this.automaticDetectionRadioButton = new System.Windows.Forms.RadioButton();
            this.manualDetectionRadioButton = new System.Windows.Forms.RadioButton();
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // informationLabel
            // 
            this.informationLabel.Location = new System.Drawing.Point(12, 9);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(360, 15);
            this.informationLabel.TabIndex = 0;
            this.informationLabel.Text = "How would you like to set-up your first game?";
            // 
            // automaticDetectionRadioButton
            // 
            this.automaticDetectionRadioButton.Checked = true;
            this.automaticDetectionRadioButton.Location = new System.Drawing.Point(12, 42);
            this.automaticDetectionRadioButton.Name = "automaticDetectionRadioButton";
            this.automaticDetectionRadioButton.Size = new System.Drawing.Size(360, 24);
            this.automaticDetectionRadioButton.TabIndex = 1;
            this.automaticDetectionRadioButton.TabStop = true;
            this.automaticDetectionRadioButton.Text = "Try to detect compatible games automatically";
            this.automaticDetectionRadioButton.UseVisualStyleBackColor = true;
            this.automaticDetectionRadioButton.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.radioButton_KeyDown);
            this.automaticDetectionRadioButton.MouseDown +=
                new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseDown);
            // 
            // manualDetectionRadioButton
            // 
            this.manualDetectionRadioButton.Location = new System.Drawing.Point(12, 72);
            this.manualDetectionRadioButton.Name = "manualDetectionRadioButton";
            this.manualDetectionRadioButton.Size = new System.Drawing.Size(360, 24);
            this.manualDetectionRadioButton.TabIndex = 2;
            this.manualDetectionRadioButton.Text = "Set-up yor first game manually";
            this.manualDetectionRadioButton.UseVisualStyleBackColor = true;
            this.manualDetectionRadioButton.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.radioButton_KeyDown);
            this.manualDetectionRadioButton.MouseDown +=
                new System.Windows.Forms.MouseEventHandler(this.radioButton_MouseDown);
            // 
            // continueButton
            // 
            this.continueButton.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.continueButton.Location = new System.Drawing.Point(297, 111);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // FirstLaunchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 147);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.manualDetectionRadioButton);
            this.Controls.Add(this.automaticDetectionRadioButton);
            this.Controls.Add(this.informationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FirstLaunchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First launch";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.RadioButton manualDetectionRadioButton;
        private System.Windows.Forms.RadioButton automaticDetectionRadioButton;
    }
}