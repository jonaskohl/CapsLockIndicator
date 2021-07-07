/*
 * Created by SharpDevelop.
 * User: Brennced
 * Date: 09.07.2017
 * Time: 18:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CapsLockIndicatorV3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.NotifyIcon numLockIcon;
		private System.Windows.Forms.NotifyIcon capsLockIcon;
		private System.Windows.Forms.NotifyIcon scrollLockIcon;
		private System.Windows.Forms.GroupBox iconsGroup;
		private System.Windows.Forms.CheckBox enableScrollIcon;
		private System.Windows.Forms.CheckBox enableCapsIcon;
		private System.Windows.Forms.CheckBox enableNumIcon;
		private System.Windows.Forms.GroupBox indicatorGroup;
		private System.Windows.Forms.CheckBox enableScrollInd;
		private System.Windows.Forms.CheckBox enableCapsInd;
		private System.Windows.Forms.CheckBox enableNumInd;
		private System.Windows.Forms.CheckBox showNoIcons;
		private System.Windows.Forms.CheckBox showNoNotification;
		private System.Windows.Forms.Panel aboutPanel;
		private System.Windows.Forms.Label aboutText;
		private System.Windows.Forms.PictureBox aboutPanelTopBorder;
		private System.Windows.Forms.Button exitApplication;
		private System.Windows.Forms.NotifyIcon generalIcon;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.numLockIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.generalIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capsLockIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.scrollLockIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconsGroup = new System.Windows.Forms.GroupBox();
            this.enableScrollIcon = new System.Windows.Forms.CheckBox();
            this.enableCapsIcon = new System.Windows.Forms.CheckBox();
            this.enableNumIcon = new System.Windows.Forms.CheckBox();
            this.indicatorGroup = new System.Windows.Forms.GroupBox();
            this.enableScrollInd = new System.Windows.Forms.CheckBox();
            this.enableCapsInd = new System.Windows.Forms.CheckBox();
            this.enableNumInd = new System.Windows.Forms.CheckBox();
            this.showNoIcons = new System.Windows.Forms.CheckBox();
            this.showNoNotification = new System.Windows.Forms.CheckBox();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.appNameLabel = new CapsLockIndicatorV3.LnkLabel();
            this.aboutPanelTopBorder = new System.Windows.Forms.PictureBox();
            this.aboutText = new System.Windows.Forms.Label();
            this.exitApplication = new System.Windows.Forms.Button();
            this.generalIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.indSettings = new System.Windows.Forms.Button();
            this.checkForUpdatesButton = new System.Windows.Forms.Button();
            this.startonlogonCheckBox = new System.Windows.Forms.CheckBox();
            this.hideOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.hideWindowTimer = new System.Windows.Forms.Timer(this.components);
            this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkForUpdatedCheckBox = new System.Windows.Forms.CheckBox();
            this.localeComboBox = new CapsLockIndicatorV3.LnComboBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.showMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hideWindow = new System.Windows.Forms.Button();
            this.advSettings = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.generalIconContextMenuStrip.SuspendLayout();
            this.iconsGroup.SuspendLayout();
            this.indicatorGroup.SuspendLayout();
            this.aboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPanelTopBorder)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 16;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimerTick);
            // 
            // numLockIcon
            // 
            this.numLockIcon.Text = "Num Lock";
            this.numLockIcon.Visible = true;
            this.numLockIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GeneralIconMouseDoubleClick);
            // 
            // generalIconContextMenuStrip
            // 
            this.generalIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.generalIconContextMenuStrip.Name = "generalIconContextMenuStrip";
            this.generalIconContextMenuStrip.Size = new System.Drawing.Size(104, 54);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // capsLockIcon
            // 
            this.capsLockIcon.Text = "Caps Lock";
            this.capsLockIcon.Visible = true;
            this.capsLockIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GeneralIconMouseDoubleClick);
            // 
            // scrollLockIcon
            // 
            this.scrollLockIcon.Text = "Scroll Lock";
            this.scrollLockIcon.Visible = true;
            this.scrollLockIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GeneralIconMouseDoubleClick);
            // 
            // iconsGroup
            // 
            this.iconsGroup.Controls.Add(this.enableScrollIcon);
            this.iconsGroup.Controls.Add(this.enableCapsIcon);
            this.iconsGroup.Controls.Add(this.enableNumIcon);
            this.iconsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconsGroup.Location = new System.Drawing.Point(12, 12);
            this.iconsGroup.Margin = new System.Windows.Forms.Padding(12, 12, 3, 3);
            this.iconsGroup.Name = "iconsGroup";
            this.iconsGroup.Size = new System.Drawing.Size(288, 97);
            this.iconsGroup.TabIndex = 0;
            this.iconsGroup.TabStop = false;
            this.iconsGroup.Text = "showIconsFor";
            // 
            // enableScrollIcon
            // 
            this.enableScrollIcon.AutoSize = true;
            this.enableScrollIcon.Checked = true;
            this.enableScrollIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableScrollIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableScrollIcon.Location = new System.Drawing.Point(6, 72);
            this.enableScrollIcon.Name = "enableScrollIcon";
            this.enableScrollIcon.Size = new System.Drawing.Size(85, 20);
            this.enableScrollIcon.TabIndex = 2;
            this.enableScrollIcon.Text = "scrollLock";
            this.enableScrollIcon.UseVisualStyleBackColor = true;
            this.enableScrollIcon.CheckedChanged += new System.EventHandler(this.enableScrollIcon_CheckedChanged);
            // 
            // enableCapsIcon
            // 
            this.enableCapsIcon.AutoSize = true;
            this.enableCapsIcon.Checked = true;
            this.enableCapsIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCapsIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableCapsIcon.Location = new System.Drawing.Point(6, 47);
            this.enableCapsIcon.Name = "enableCapsIcon";
            this.enableCapsIcon.Size = new System.Drawing.Size(81, 20);
            this.enableCapsIcon.TabIndex = 1;
            this.enableCapsIcon.Text = "capsLock";
            this.enableCapsIcon.UseVisualStyleBackColor = true;
            this.enableCapsIcon.CheckedChanged += new System.EventHandler(this.enableCapsIcon_CheckedChanged);
            // 
            // enableNumIcon
            // 
            this.enableNumIcon.AutoSize = true;
            this.enableNumIcon.Checked = true;
            this.enableNumIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableNumIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableNumIcon.Location = new System.Drawing.Point(6, 22);
            this.enableNumIcon.Name = "enableNumIcon";
            this.enableNumIcon.Size = new System.Drawing.Size(82, 20);
            this.enableNumIcon.TabIndex = 0;
            this.enableNumIcon.Text = "numLock";
            this.enableNumIcon.UseVisualStyleBackColor = true;
            this.enableNumIcon.CheckedChanged += new System.EventHandler(this.enableNumIcon_CheckedChanged);
            // 
            // indicatorGroup
            // 
            this.indicatorGroup.Controls.Add(this.enableScrollInd);
            this.indicatorGroup.Controls.Add(this.enableCapsInd);
            this.indicatorGroup.Controls.Add(this.enableNumInd);
            this.indicatorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indicatorGroup.Location = new System.Drawing.Point(306, 12);
            this.indicatorGroup.Margin = new System.Windows.Forms.Padding(3, 12, 12, 3);
            this.indicatorGroup.Name = "indicatorGroup";
            this.indicatorGroup.Size = new System.Drawing.Size(288, 97);
            this.indicatorGroup.TabIndex = 1;
            this.indicatorGroup.TabStop = false;
            this.indicatorGroup.Text = "showNotificationWhen";
            // 
            // enableScrollInd
            // 
            this.enableScrollInd.AutoSize = true;
            this.enableScrollInd.Checked = true;
            this.enableScrollInd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableScrollInd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableScrollInd.Location = new System.Drawing.Point(6, 72);
            this.enableScrollInd.Name = "enableScrollInd";
            this.enableScrollInd.Size = new System.Drawing.Size(130, 20);
            this.enableScrollInd.TabIndex = 2;
            this.enableScrollInd.Text = "scrolllockChanged";
            this.enableScrollInd.UseVisualStyleBackColor = true;
            this.enableScrollInd.CheckedChanged += new System.EventHandler(this.enableScrollInd_CheckedChanged);
            // 
            // enableCapsInd
            // 
            this.enableCapsInd.AutoSize = true;
            this.enableCapsInd.Checked = true;
            this.enableCapsInd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCapsInd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableCapsInd.Location = new System.Drawing.Point(6, 47);
            this.enableCapsInd.Name = "enableCapsInd";
            this.enableCapsInd.Size = new System.Drawing.Size(126, 20);
            this.enableCapsInd.TabIndex = 1;
            this.enableCapsInd.Text = "capslockChanged";
            this.enableCapsInd.UseVisualStyleBackColor = true;
            this.enableCapsInd.CheckedChanged += new System.EventHandler(this.enableCapsInd_CheckedChanged);
            // 
            // enableNumInd
            // 
            this.enableNumInd.AutoSize = true;
            this.enableNumInd.Checked = true;
            this.enableNumInd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableNumInd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableNumInd.Location = new System.Drawing.Point(6, 22);
            this.enableNumInd.Name = "enableNumInd";
            this.enableNumInd.Size = new System.Drawing.Size(127, 20);
            this.enableNumInd.TabIndex = 0;
            this.enableNumInd.Text = "numlockChanged";
            this.enableNumInd.UseVisualStyleBackColor = true;
            this.enableNumInd.CheckedChanged += new System.EventHandler(this.enableNumInd_CheckedChanged);
            // 
            // showNoIcons
            // 
            this.showNoIcons.AutoSize = true;
            this.showNoIcons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showNoIcons.Location = new System.Drawing.Point(3, 3);
            this.showNoIcons.Name = "showNoIcons";
            this.showNoIcons.Size = new System.Drawing.Size(104, 20);
            this.showNoIcons.TabIndex = 2;
            this.showNoIcons.Text = "showNoIcons";
            this.showNoIcons.UseVisualStyleBackColor = true;
            this.showNoIcons.CheckedChanged += new System.EventHandler(this.ShowNoIconsCheckedChanged);
            // 
            // showNoNotification
            // 
            this.showNoNotification.AutoSize = true;
            this.showNoNotification.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.showNoNotification.Location = new System.Drawing.Point(3, 29);
            this.showNoNotification.Name = "showNoNotification";
            this.showNoNotification.Size = new System.Drawing.Size(139, 20);
            this.showNoNotification.TabIndex = 3;
            this.showNoNotification.Text = "showNoNotification";
            this.showNoNotification.UseVisualStyleBackColor = true;
            this.showNoNotification.CheckedChanged += new System.EventHandler(this.ShowNoNotificationCheckedChanged);
            // 
            // aboutPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.aboutPanel, 2);
            this.aboutPanel.Controls.Add(this.logo);
            this.aboutPanel.Controls.Add(this.appNameLabel);
            this.aboutPanel.Controls.Add(this.aboutPanelTopBorder);
            this.aboutPanel.Controls.Add(this.aboutText);
            this.aboutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutPanel.Location = new System.Drawing.Point(0, 281);
            this.aboutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(606, 64);
            this.aboutPanel.TabIndex = 4;
            // 
            // appNameLabel
            // 
            this.appNameLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.appNameLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.appNameLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.appNameLabel.Location = new System.Drawing.Point(66, 5);
            this.appNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(111, 15);
            this.appNameLabel.TabIndex = 5;
            this.appNameLabel.TabStop = true;
            this.appNameLabel.Text = "CapsLock Indicator";
            this.mainToolTip.SetToolTip(this.appNameLabel, "Visit CapsLock Indicator website");
            this.appNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.appNameLabel_LinkClicked);
            // 
            // aboutPanelTopBorder
            // 
            this.aboutPanelTopBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.aboutPanelTopBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.aboutPanelTopBorder.Location = new System.Drawing.Point(0, 0);
            this.aboutPanelTopBorder.Name = "aboutPanelTopBorder";
            this.aboutPanelTopBorder.Size = new System.Drawing.Size(606, 2);
            this.aboutPanelTopBorder.TabIndex = 3;
            this.aboutPanelTopBorder.TabStop = false;
            // 
            // aboutText
            // 
            this.aboutText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutText.Location = new System.Drawing.Point(69, 25);
            this.aboutText.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(534, 32);
            this.aboutText.TabIndex = 2;
            this.aboutText.Text = "aboutText";
            // 
            // exitApplication
            // 
            this.exitApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.exitApplication.AutoSize = true;
            this.exitApplication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitApplication.Location = new System.Drawing.Point(159, 93);
            this.exitApplication.Name = "exitApplication";
            this.exitApplication.Size = new System.Drawing.Size(126, 25);
            this.exitApplication.TabIndex = 6;
            this.exitApplication.Text = "exitApplication";
            this.exitApplication.UseVisualStyleBackColor = true;
            this.exitApplication.Click += new System.EventHandler(this.ExitApplicationClick);
            // 
            // generalIcon
            // 
            this.generalIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.generalIcon.BalloonTipText = "You can show CapsLock Indicator again by double clicking on this icon.";
            this.generalIcon.BalloonTipTitle = "CapsLock Indicator";
            this.generalIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("generalIcon.Icon")));
            this.generalIcon.Text = "CapsLock Indicator";
            this.generalIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GeneralIconMouseDoubleClick);
            // 
            // indSettings
            // 
            this.indSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.indSettings.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.indSettings, 2);
            this.indSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.indSettings.Location = new System.Drawing.Point(27, 33);
            this.indSettings.Name = "indSettings";
            this.indSettings.Size = new System.Drawing.Size(258, 24);
            this.indSettings.TabIndex = 7;
            this.indSettings.Text = "notificationSettings";
            this.indSettings.UseVisualStyleBackColor = true;
            this.indSettings.Click += new System.EventHandler(this.indSettings_Click);
            // 
            // checkForUpdatesButton
            // 
            this.checkForUpdatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkForUpdatesButton.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.checkForUpdatesButton, 2);
            this.checkForUpdatesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkForUpdatesButton.Location = new System.Drawing.Point(27, 124);
            this.checkForUpdatesButton.Name = "checkForUpdatesButton";
            this.checkForUpdatesButton.Size = new System.Drawing.Size(258, 24);
            this.checkForUpdatesButton.TabIndex = 9;
            this.checkForUpdatesButton.Text = "checkForUpdates";
            this.checkForUpdatesButton.UseVisualStyleBackColor = true;
            this.checkForUpdatesButton.Click += new System.EventHandler(this.checkForUpdatesButton_Click);
            // 
            // startonlogonCheckBox
            // 
            this.startonlogonCheckBox.AutoSize = true;
            this.startonlogonCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startonlogonCheckBox.Location = new System.Drawing.Point(3, 55);
            this.startonlogonCheckBox.Name = "startonlogonCheckBox";
            this.startonlogonCheckBox.Size = new System.Drawing.Size(105, 20);
            this.startonlogonCheckBox.TabIndex = 10;
            this.startonlogonCheckBox.Text = "startOnLogon";
            this.startonlogonCheckBox.UseVisualStyleBackColor = true;
            this.startonlogonCheckBox.CheckedChanged += new System.EventHandler(this.startonlogonCheckBox_CheckedChanged);
            // 
            // hideOnStartupCheckBox
            // 
            this.hideOnStartupCheckBox.AutoSize = true;
            this.hideOnStartupCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hideOnStartupCheckBox.Location = new System.Drawing.Point(3, 81);
            this.hideOnStartupCheckBox.Name = "hideOnStartupCheckBox";
            this.hideOnStartupCheckBox.Size = new System.Drawing.Size(109, 20);
            this.hideOnStartupCheckBox.TabIndex = 11;
            this.hideOnStartupCheckBox.Text = "hideOnStartup";
            this.hideOnStartupCheckBox.UseVisualStyleBackColor = true;
            this.hideOnStartupCheckBox.CheckedChanged += new System.EventHandler(this.hideOnStartupCheckBox_CheckedChanged);
            // 
            // hideWindowTimer
            // 
            this.hideWindowTimer.Tick += new System.EventHandler(this.hideWindowTimer_Tick);
            // 
            // checkForUpdatedCheckBox
            // 
            this.checkForUpdatedCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkForUpdatedCheckBox.Checked = true;
            this.checkForUpdatedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkForUpdatedCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkForUpdatedCheckBox.Location = new System.Drawing.Point(6, 128);
            this.checkForUpdatedCheckBox.Name = "checkForUpdatedCheckBox";
            this.checkForUpdatedCheckBox.Size = new System.Drawing.Size(15, 15);
            this.checkForUpdatedCheckBox.TabIndex = 12;
            this.mainToolTip.SetToolTip(this.checkForUpdatedCheckBox, "autoCheckForUpdates");
            this.checkForUpdatedCheckBox.UseVisualStyleBackColor = true;
            this.checkForUpdatedCheckBox.CheckedChanged += new System.EventHandler(this.checkForUpdatedCheckBox_CheckedChanged);
            // 
            // localeComboBox
            // 
            this.localeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.localeComboBox, 2);
            this.localeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.localeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localeComboBox.FormattingEnabled = true;
            this.localeComboBox.Location = new System.Drawing.Point(27, 3);
            this.localeComboBox.Name = "localeComboBox";
            this.localeComboBox.Size = new System.Drawing.Size(258, 24);
            this.localeComboBox.TabIndex = 13;
            this.localeComboBox.SelectedIndexChanged += new System.EventHandler(this.localeComboBox_SelectedIndexChanged);
            this.localeComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.localeComboBox_Format);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showMenuItem,
            this.menuItem1,
            this.exitMenuItem});
            // 
            // showMenuItem
            // 
            this.showMenuItem.Index = 0;
            this.showMenuItem.Text = "&Show";
            this.showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 2;
            this.exitMenuItem.Text = "&Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.iconsGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.indicatorGroup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.aboutPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 345);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.showNoIcons);
            this.flowLayoutPanel1.Controls.Add(this.showNoNotification);
            this.flowLayoutPanel1.Controls.Add(this.startonlogonCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.hideOnStartupCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 115);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 157);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.exitApplication, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.localeComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.indSettings, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkForUpdatesButton, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkForUpdatedCheckBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.hideWindow, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.advSettings, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(306, 115);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 12, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(288, 157);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // hideWindow
            // 
            this.hideWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hideWindow.AutoSize = true;
            this.hideWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hideWindow.Location = new System.Drawing.Point(27, 93);
            this.hideWindow.Name = "hideWindow";
            this.hideWindow.Size = new System.Drawing.Size(126, 24);
            this.hideWindow.TabIndex = 5;
            this.hideWindow.Text = "hideWindow";
            this.hideWindow.UseVisualStyleBackColor = true;
            this.hideWindow.Click += new System.EventHandler(this.HideWindowClick);
            // 
            // advSettings
            // 
            this.advSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.advSettings.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.advSettings, 2);
            this.advSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.advSettings.Location = new System.Drawing.Point(27, 63);
            this.advSettings.Name = "advSettings";
            this.advSettings.Size = new System.Drawing.Size(258, 24);
            this.advSettings.TabIndex = 7;
            this.advSettings.Text = "advancedSettings";
            this.advSettings.UseVisualStyleBackColor = true;
            this.advSettings.Click += new System.EventHandler(this.advSettings_Click);
            // 
            // logo
            // 
            this.logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logo.Image = global::CapsLockIndicatorV3.resources.logo;
            this.logo.Location = new System.Drawing.Point(12, 9);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(48, 48);
            this.logo.TabIndex = 6;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.lnkLabel1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(606, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CapsLock Indicator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.generalIconContextMenuStrip.ResumeLayout(false);
            this.iconsGroup.ResumeLayout(false);
            this.iconsGroup.PerformLayout();
            this.indicatorGroup.ResumeLayout(false);
            this.indicatorGroup.PerformLayout();
            this.aboutPanel.ResumeLayout(false);
            this.aboutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPanelTopBorder)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.Button indSettings;
        private System.Windows.Forms.Button checkForUpdatesButton;
        private System.Windows.Forms.CheckBox startonlogonCheckBox;
        private System.Windows.Forms.CheckBox hideOnStartupCheckBox;
        private System.Windows.Forms.Timer hideWindowTimer;
        private System.Windows.Forms.ContextMenuStrip generalIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private LnkLabel appNameLabel;
        private System.Windows.Forms.ToolTip mainToolTip;
        private System.Windows.Forms.CheckBox checkForUpdatedCheckBox;
        private CapsLockIndicatorV3.LnComboBox localeComboBox;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem showMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button hideWindow;
        private System.Windows.Forms.Button advSettings;
        private System.Windows.Forms.PictureBox logo;
    }
}
