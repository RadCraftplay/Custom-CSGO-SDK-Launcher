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
            this.gamesTabPage = new System.Windows.Forms.TabPage();
            this.sendFeedbackButton = new System.Windows.Forms.Button();
            this.disableFeedbackCheckBox = new System.Windows.Forms.CheckBox();
            this.displayCurrentlySelectedGameCheckBox = new System.Windows.Forms.CheckBox();
            this.editListOfGamesLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gameLabel = new System.Windows.Forms.Label();
            this.gameListComboBox = new System.Windows.Forms.ComboBox();
            this.appLauncherTabPage = new System.Windows.Forms.TabPage();
            this.actionChangeLabel = new System.Windows.Forms.Label();
            this.launcherEditButton3 = new System.Windows.Forms.Button();
            this.launcherEditButton2 = new System.Windows.Forms.Button();
            this.launcherEditButton1 = new System.Windows.Forms.Button();
            this.useNewLauncherCheckBox = new System.Windows.Forms.CheckBox();
            this.configTabPage = new System.Windows.Forms.TabPage();
            this.backupsGroupBox = new System.Windows.Forms.GroupBox();
            this.createBackupButton = new System.Windows.Forms.Button();
            this.restoreBackupButton = new System.Windows.Forms.Button();
            this.advancedTabPage = new System.Windows.Forms.TabPage();
            this.ignoreGameMigrationConflictsCheckBox = new System.Windows.Forms.CheckBox();
            this.preLoadDataCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedWarningLabel = new System.Windows.Forms.Label();
            this.aboutTabPage = new System.Windows.Forms.TabPage();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gamebananaLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ViewLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.fugueIconsSetLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.gpl3LicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.appnameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.gamesTabPage.SuspendLayout();
            this.appLauncherTabPage.SuspendLayout();
            this.configTabPage.SuspendLayout();
            this.backupsGroupBox.SuspendLayout();
            this.advancedTabPage.SuspendLayout();
            this.aboutTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.gamesTabPage);
            this.tabControl.Controls.Add(this.appLauncherTabPage);
            this.tabControl.Controls.Add(this.configTabPage);
            this.tabControl.Controls.Add(this.advancedTabPage);
            this.tabControl.Controls.Add(this.aboutTabPage);
            this.tabControl.Location = new System.Drawing.Point(17, 16);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(451, 225);
            this.tabControl.TabIndex = 0;
            // 
            // gamesTabPage
            // 
            this.gamesTabPage.Controls.Add(this.sendFeedbackButton);
            this.gamesTabPage.Controls.Add(this.disableFeedbackCheckBox);
            this.gamesTabPage.Controls.Add(this.displayCurrentlySelectedGameCheckBox);
            this.gamesTabPage.Controls.Add(this.editListOfGamesLinkLabel);
            this.gamesTabPage.Controls.Add(this.gameLabel);
            this.gamesTabPage.Controls.Add(this.gameListComboBox);
            this.gamesTabPage.Location = new System.Drawing.Point(4, 25);
            this.gamesTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.gamesTabPage.Name = "gamesTabPage";
            this.gamesTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.gamesTabPage.Size = new System.Drawing.Size(443, 196);
            this.gamesTabPage.TabIndex = 0;
            this.gamesTabPage.Text = "Games";
            this.gamesTabPage.UseVisualStyleBackColor = true;
            // 
            // sendFeedbackButton
            // 
            this.sendFeedbackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendFeedbackButton.Location = new System.Drawing.Point(318, 82);
            this.sendFeedbackButton.Name = "sendFeedbackButton";
            this.sendFeedbackButton.Size = new System.Drawing.Size(112, 25);
            this.sendFeedbackButton.TabIndex = 7;
            this.sendFeedbackButton.Text = "Send feedback";
            this.sendFeedbackButton.UseVisualStyleBackColor = true;
            this.sendFeedbackButton.Visible = false;
            this.sendFeedbackButton.Click += new System.EventHandler(this.sendFeedbackButton_Click);
            // 
            // disableFeedbackCheckBox
            // 
            this.disableFeedbackCheckBox.AutoSize = true;
            this.disableFeedbackCheckBox.Location = new System.Drawing.Point(13, 85);
            this.disableFeedbackCheckBox.Name = "disableFeedbackCheckBox";
            this.disableFeedbackCheckBox.Size = new System.Drawing.Size(218, 21);
            this.disableFeedbackCheckBox.TabIndex = 5;
            this.disableFeedbackCheckBox.Text = "Disable feedback notifications";
            this.disableFeedbackCheckBox.UseVisualStyleBackColor = true;
            // 
            // displayCurrentlySelectedGameCheckBox
            // 
            this.displayCurrentlySelectedGameCheckBox.AutoSize = true;
            this.displayCurrentlySelectedGameCheckBox.Location = new System.Drawing.Point(13, 57);
            this.displayCurrentlySelectedGameCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.displayCurrentlySelectedGameCheckBox.Name = "displayCurrentlySelectedGameCheckBox";
            this.displayCurrentlySelectedGameCheckBox.Size = new System.Drawing.Size(286, 21);
            this.displayCurrentlySelectedGameCheckBox.TabIndex = 4;
            this.displayCurrentlySelectedGameCheckBox.Text = "Display name of currently selected game";
            this.displayCurrentlySelectedGameCheckBox.UseVisualStyleBackColor = true;
            // 
            // editListOfGamesLinkLabel
            // 
            this.editListOfGamesLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editListOfGamesLinkLabel.AutoSize = true;
            this.editListOfGamesLinkLabel.Location = new System.Drawing.Point(315, 37);
            this.editListOfGamesLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editListOfGamesLinkLabel.Name = "editListOfGamesLinkLabel";
            this.editListOfGamesLinkLabel.Size = new System.Drawing.Size(115, 17);
            this.editListOfGamesLinkLabel.TabIndex = 3;
            this.editListOfGamesLinkLabel.TabStop = true;
            this.editListOfGamesLinkLabel.Text = "Edit list of games";
            this.editListOfGamesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gameLabel
            // 
            this.gameLabel.AutoSize = true;
            this.gameLabel.Location = new System.Drawing.Point(9, 11);
            this.gameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(50, 17);
            this.gameLabel.TabIndex = 2;
            this.gameLabel.Text = "Game:";
            // 
            // gameListComboBox
            // 
            this.gameListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameListComboBox.FormattingEnabled = true;
            this.gameListComboBox.Location = new System.Drawing.Point(69, 7);
            this.gameListComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.gameListComboBox.Name = "gameListComboBox";
            this.gameListComboBox.Size = new System.Drawing.Size(361, 24);
            this.gameListComboBox.TabIndex = 1;
            // 
            // appLauncherTabPage
            // 
            this.appLauncherTabPage.Controls.Add(this.actionChangeLabel);
            this.appLauncherTabPage.Controls.Add(this.launcherEditButton3);
            this.appLauncherTabPage.Controls.Add(this.launcherEditButton2);
            this.appLauncherTabPage.Controls.Add(this.launcherEditButton1);
            this.appLauncherTabPage.Controls.Add(this.useNewLauncherCheckBox);
            this.appLauncherTabPage.Location = new System.Drawing.Point(4, 25);
            this.appLauncherTabPage.Name = "appLauncherTabPage";
            this.appLauncherTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.appLauncherTabPage.Size = new System.Drawing.Size(443, 196);
            this.appLauncherTabPage.TabIndex = 4;
            this.appLauncherTabPage.Text = "App launcher";
            this.appLauncherTabPage.UseVisualStyleBackColor = true;
            // 
            // actionChangeLabel
            // 
            this.actionChangeLabel.Location = new System.Drawing.Point(6, 133);
            this.actionChangeLabel.Name = "actionChangeLabel";
            this.actionChangeLabel.Size = new System.Drawing.Size(272, 23);
            this.actionChangeLabel.TabIndex = 7;
            this.actionChangeLabel.Text = "Click on a button to change an action";
            this.actionChangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // launcherEditButton3
            // 
            this.launcherEditButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton3.Location = new System.Drawing.Point(7, 102);
            this.launcherEditButton3.Name = "launcherEditButton3";
            this.launcherEditButton3.Size = new System.Drawing.Size(271, 28);
            this.launcherEditButton3.TabIndex = 6;
            this.launcherEditButton3.Text = "launcherEditButton3";
            this.launcherEditButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.launcherEditButton3.UseVisualStyleBackColor = true;
            this.launcherEditButton3.Click += new System.EventHandler(this.launcherButtonEdit_Click);
            // 
            // launcherEditButton2
            // 
            this.launcherEditButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton2.Location = new System.Drawing.Point(7, 68);
            this.launcherEditButton2.Name = "launcherEditButton2";
            this.launcherEditButton2.Size = new System.Drawing.Size(271, 28);
            this.launcherEditButton2.TabIndex = 5;
            this.launcherEditButton2.Text = "launcherEditButton2";
            this.launcherEditButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.launcherEditButton2.UseVisualStyleBackColor = true;
            this.launcherEditButton2.Click += new System.EventHandler(this.launcherButtonEdit_Click);
            // 
            // launcherEditButton1
            // 
            this.launcherEditButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton1.Location = new System.Drawing.Point(7, 34);
            this.launcherEditButton1.Name = "launcherEditButton1";
            this.launcherEditButton1.Size = new System.Drawing.Size(271, 28);
            this.launcherEditButton1.TabIndex = 4;
            this.launcherEditButton1.Text = "launcherEditButton1";
            this.launcherEditButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launcherEditButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.launcherEditButton1.UseVisualStyleBackColor = true;
            this.launcherEditButton1.Click += new System.EventHandler(this.launcherButtonEdit_Click);
            // 
            // useNewLauncherCheckBox
            // 
            this.useNewLauncherCheckBox.AutoSize = true;
            this.useNewLauncherCheckBox.Location = new System.Drawing.Point(6, 6);
            this.useNewLauncherCheckBox.Name = "useNewLauncherCheckBox";
            this.useNewLauncherCheckBox.Size = new System.Drawing.Size(143, 21);
            this.useNewLauncherCheckBox.TabIndex = 3;
            this.useNewLauncherCheckBox.Text = "Use new launcher";
            this.useNewLauncherCheckBox.UseVisualStyleBackColor = true;
            this.useNewLauncherCheckBox.CheckedChanged += new System.EventHandler(this.useNewLauncherCheckBox_CheckedChanged);
            // 
            // configTabPage
            // 
            this.configTabPage.Controls.Add(this.backupsGroupBox);
            this.configTabPage.Location = new System.Drawing.Point(4, 25);
            this.configTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.configTabPage.Name = "configTabPage";
            this.configTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.configTabPage.Size = new System.Drawing.Size(443, 196);
            this.configTabPage.TabIndex = 2;
            this.configTabPage.Text = "Configuration";
            this.configTabPage.UseVisualStyleBackColor = true;
            // 
            // backupsGroupBox
            // 
            this.backupsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backupsGroupBox.Controls.Add(this.createBackupButton);
            this.backupsGroupBox.Controls.Add(this.restoreBackupButton);
            this.backupsGroupBox.Location = new System.Drawing.Point(8, 7);
            this.backupsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.backupsGroupBox.Name = "backupsGroupBox";
            this.backupsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.backupsGroupBox.Size = new System.Drawing.Size(424, 97);
            this.backupsGroupBox.TabIndex = 2;
            this.backupsGroupBox.TabStop = false;
            this.backupsGroupBox.Text = "Backups";
            // 
            // createBackupButton
            // 
            this.createBackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createBackupButton.Location = new System.Drawing.Point(8, 23);
            this.createBackupButton.Margin = new System.Windows.Forms.Padding(4);
            this.createBackupButton.Name = "createBackupButton";
            this.createBackupButton.Size = new System.Drawing.Size(408, 28);
            this.createBackupButton.TabIndex = 0;
            this.createBackupButton.Text = "Create backup";
            this.createBackupButton.UseVisualStyleBackColor = true;
            this.createBackupButton.Click += new System.EventHandler(this.createBackupButton_Click);
            // 
            // restoreBackupButton
            // 
            this.restoreBackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreBackupButton.Location = new System.Drawing.Point(8, 59);
            this.restoreBackupButton.Margin = new System.Windows.Forms.Padding(4);
            this.restoreBackupButton.Name = "restoreBackupButton";
            this.restoreBackupButton.Size = new System.Drawing.Size(408, 28);
            this.restoreBackupButton.TabIndex = 0;
            this.restoreBackupButton.Text = "Restore backup";
            this.restoreBackupButton.UseVisualStyleBackColor = true;
            this.restoreBackupButton.Click += new System.EventHandler(this.restoreBackupButton_Click);
            // 
            // advancedTabPage
            // 
            this.advancedTabPage.Controls.Add(this.ignoreGameMigrationConflictsCheckBox);
            this.advancedTabPage.Controls.Add(this.preLoadDataCheckBox);
            this.advancedTabPage.Controls.Add(this.advancedWarningLabel);
            this.advancedTabPage.Location = new System.Drawing.Point(4, 25);
            this.advancedTabPage.Name = "advancedTabPage";
            this.advancedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.advancedTabPage.Size = new System.Drawing.Size(443, 196);
            this.advancedTabPage.TabIndex = 3;
            this.advancedTabPage.Text = "Advanced";
            this.advancedTabPage.UseVisualStyleBackColor = true;
            // 
            // ignoreGameMigrationConflictsCheckBox
            // 
            this.ignoreGameMigrationConflictsCheckBox.AutoSize = true;
            this.ignoreGameMigrationConflictsCheckBox.Location = new System.Drawing.Point(9, 72);
            this.ignoreGameMigrationConflictsCheckBox.Name = "ignoreGameMigrationConflictsCheckBox";
            this.ignoreGameMigrationConflictsCheckBox.Size = new System.Drawing.Size(226, 21);
            this.ignoreGameMigrationConflictsCheckBox.TabIndex = 2;
            this.ignoreGameMigrationConflictsCheckBox.Text = "Ignore game migration conflicts";
            this.ignoreGameMigrationConflictsCheckBox.UseVisualStyleBackColor = true;
            // 
            // preLoadDataCheckBox
            // 
            this.preLoadDataCheckBox.AutoSize = true;
            this.preLoadDataCheckBox.Location = new System.Drawing.Point(9, 44);
            this.preLoadDataCheckBox.Name = "preLoadDataCheckBox";
            this.preLoadDataCheckBox.Size = new System.Drawing.Size(184, 21);
            this.preLoadDataCheckBox.TabIndex = 1;
            this.preLoadDataCheckBox.Text = "Pre-load data on startup";
            this.preLoadDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // advancedWarningLabel
            // 
            this.advancedWarningLabel.Location = new System.Drawing.Point(6, 3);
            this.advancedWarningLabel.Name = "advancedWarningLabel";
            this.advancedWarningLabel.Size = new System.Drawing.Size(431, 38);
            this.advancedWarningLabel.TabIndex = 0;
            this.advancedWarningLabel.Text = "Changing these options may cause many negative consequences regarding performance" +
    ", and stability!";
            // 
            // aboutTabPage
            // 
            this.aboutTabPage.Controls.Add(this.githubLinkLabel);
            this.aboutTabPage.Controls.Add(this.gamebananaLinkLabel);
            this.aboutTabPage.Controls.Add(this.ViewLicenseLinkLabel);
            this.aboutTabPage.Controls.Add(this.fugueIconsSetLicenseLinkLabel);
            this.aboutTabPage.Controls.Add(this.gpl3LicenseLinkLabel);
            this.aboutTabPage.Controls.Add(this.versionLabel);
            this.aboutTabPage.Controls.Add(this.copyrightLabel);
            this.aboutTabPage.Controls.Add(this.pictureBox1);
            this.aboutTabPage.Controls.Add(this.appnameLabel);
            this.aboutTabPage.Location = new System.Drawing.Point(4, 25);
            this.aboutTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.aboutTabPage.Name = "aboutTabPage";
            this.aboutTabPage.Size = new System.Drawing.Size(443, 196);
            this.aboutTabPage.TabIndex = 1;
            this.aboutTabPage.Text = "About";
            this.aboutTabPage.UseVisualStyleBackColor = true;
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(4, 165);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(52, 17);
            this.githubLinkLabel.TabIndex = 8;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "GitHub";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // gamebananaLinkLabel
            // 
            this.gamebananaLinkLabel.AutoSize = true;
            this.gamebananaLinkLabel.Location = new System.Drawing.Point(4, 145);
            this.gamebananaLinkLabel.Name = "gamebananaLinkLabel";
            this.gamebananaLinkLabel.Size = new System.Drawing.Size(95, 17);
            this.gamebananaLinkLabel.TabIndex = 7;
            this.gamebananaLinkLabel.TabStop = true;
            this.gamebananaLinkLabel.Text = "GameBanana";
            this.gamebananaLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gamebananaLinkLabel_LinkClicked);
            // 
            // ViewLicenseLinkLabel
            // 
            this.ViewLicenseLinkLabel.AutoSize = true;
            this.ViewLicenseLinkLabel.Location = new System.Drawing.Point(4, 86);
            this.ViewLicenseLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ViewLicenseLinkLabel.Name = "ViewLicenseLinkLabel";
            this.ViewLicenseLinkLabel.Size = new System.Drawing.Size(57, 17);
            this.ViewLicenseLinkLabel.TabIndex = 6;
            this.ViewLicenseLinkLabel.TabStop = true;
            this.ViewLicenseLinkLabel.Text = "License";
            this.ViewLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ViewLicenseLinkLabel_LinkClicked);
            // 
            // fugueIconsSetLicenseLinkLabel
            // 
            this.fugueIconsSetLicenseLinkLabel.AutoSize = true;
            this.fugueIconsSetLicenseLinkLabel.Location = new System.Drawing.Point(4, 126);
            this.fugueIconsSetLicenseLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fugueIconsSetLicenseLinkLabel.Name = "fugueIconsSetLicenseLinkLabel";
            this.fugueIconsSetLicenseLinkLabel.Size = new System.Drawing.Size(156, 17);
            this.fugueIconsSetLicenseLinkLabel.TabIndex = 5;
            this.fugueIconsSetLicenseLinkLabel.TabStop = true;
            this.fugueIconsSetLicenseLinkLabel.Text = "Fugue icons set license";
            this.fugueIconsSetLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fugueIconsSetLicenseLinkLabel_LinkClicked);
            // 
            // gpl3LicenseLinkLabel
            // 
            this.gpl3LicenseLinkLabel.AutoSize = true;
            this.gpl3LicenseLinkLabel.Location = new System.Drawing.Point(4, 106);
            this.gpl3LicenseLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gpl3LicenseLinkLabel.Name = "gpl3LicenseLinkLabel";
            this.gpl3LicenseLinkLabel.Size = new System.Drawing.Size(96, 17);
            this.gpl3LicenseLinkLabel.TabIndex = 4;
            this.gpl3LicenseLinkLabel.TabStop = true;
            this.gpl3LicenseLinkLabel.Text = "GPL 3 license";
            this.gpl3LicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gpl3LicenseLinkLabel_LinkClicked);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(77, 44);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(56, 17);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "Version";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(77, 25);
            this.copyrightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(167, 17);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "Copyright © Distroir 2017";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Distroir.CustomSDKLauncher.UI.Properties.Resources.appicon;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // appnameLabel
            // 
            this.appnameLabel.AutoSize = true;
            this.appnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.appnameLabel.Location = new System.Drawing.Point(77, 5);
            this.appnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appnameLabel.Name = "appnameLabel";
            this.appnameLabel.Size = new System.Drawing.Size(170, 17);
            this.appnameLabel.TabIndex = 0;
            this.appnameLabel.Text = "Custom SDK Launcher";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(368, 249);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 292);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.tabControl.ResumeLayout(false);
            this.gamesTabPage.ResumeLayout(false);
            this.gamesTabPage.PerformLayout();
            this.appLauncherTabPage.ResumeLayout(false);
            this.appLauncherTabPage.PerformLayout();
            this.configTabPage.ResumeLayout(false);
            this.backupsGroupBox.ResumeLayout(false);
            this.advancedTabPage.ResumeLayout(false);
            this.advancedTabPage.PerformLayout();
            this.aboutTabPage.ResumeLayout(false);
            this.aboutTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage gamesTabPage;
        private System.Windows.Forms.LinkLabel editListOfGamesLinkLabel;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.ComboBox gameListComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage aboutTabPage;
        private System.Windows.Forms.CheckBox displayCurrentlySelectedGameCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label appnameLabel;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.LinkLabel fugueIconsSetLicenseLinkLabel;
        private System.Windows.Forms.LinkLabel gpl3LicenseLinkLabel;
        private System.Windows.Forms.LinkLabel ViewLicenseLinkLabel;
        private System.Windows.Forms.TabPage configTabPage;
        private System.Windows.Forms.GroupBox backupsGroupBox;
        private System.Windows.Forms.Button createBackupButton;
        private System.Windows.Forms.Button restoreBackupButton;
        private System.Windows.Forms.TabPage advancedTabPage;
        private System.Windows.Forms.CheckBox preLoadDataCheckBox;
        private System.Windows.Forms.Label advancedWarningLabel;
        private System.Windows.Forms.TabPage appLauncherTabPage;
        private System.Windows.Forms.Button launcherEditButton1;
        private System.Windows.Forms.CheckBox useNewLauncherCheckBox;
        private System.Windows.Forms.Button launcherEditButton3;
        private System.Windows.Forms.Button launcherEditButton2;
        private System.Windows.Forms.CheckBox disableFeedbackCheckBox;
        private System.Windows.Forms.Button sendFeedbackButton;
        private System.Windows.Forms.Label actionChangeLabel;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
        private System.Windows.Forms.LinkLabel gamebananaLinkLabel;
        private System.Windows.Forms.CheckBox ignoreGameMigrationConflictsCheckBox;
    }
}