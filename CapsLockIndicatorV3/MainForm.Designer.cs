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
            this.enableScrollIcon = new CapsLockIndicatorV3.BetterCheckBox();
            this.enableCapsIcon = new CapsLockIndicatorV3.BetterCheckBox();
            this.enableNumIcon = new CapsLockIndicatorV3.BetterCheckBox();
            this.indicatorGroup = new System.Windows.Forms.GroupBox();
            this.enableScrollInd = new CapsLockIndicatorV3.BetterCheckBox();
            this.enableCapsInd = new CapsLockIndicatorV3.BetterCheckBox();
            this.enableNumInd = new CapsLockIndicatorV3.BetterCheckBox();
            this.showNoIcons = new CapsLockIndicatorV3.BetterCheckBox();
            this.showNoNotification = new CapsLockIndicatorV3.BetterCheckBox();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.appNameLabel = new CapsLockIndicatorV3.LnkLabel();
            this.aboutPanelTopBorder = new System.Windows.Forms.PictureBox();
            this.aboutText = new System.Windows.Forms.Label();
            this.exitApplication = new System.Windows.Forms.Button();
            this.generalIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkForUpdatesButton = new System.Windows.Forms.Button();
            this.startonlogonCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.hideOnStartupCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.mainToolTip = new CapsLockIndicatorV3.BetterToolTip(this.components);
            this.checkForUpdatedCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.dismissButton = new System.Windows.Forms.Button();
            this.localeComboBox = new CapsLockIndicatorV3.LnComboBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.showMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hideWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.displayTimeGroup = new System.Windows.Forms.GroupBox();
            this.onlyShowWhenActiveCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.displayTimeLabel = new System.Windows.Forms.Label();
            this.displayTimeSlider = new System.Windows.Forms.TrackBar();
            this.coloursGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundColourActivatedButton = new System.Windows.Forms.Button();
            this.borderColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.backgroundColourDeactivatedButton = new System.Windows.Forms.Button();
            this.borderColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.borderColourDeactivatedButton = new System.Windows.Forms.Button();
            this.backgroundColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourActivatedButton = new System.Windows.Forms.Button();
            this.foregroundColourDeactivatedButton = new System.Windows.Forms.Button();
            this.borderColourActivatedButton = new System.Windows.Forms.Button();
            this.backgroundColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.mainColourPicker = new CapsLockIndicatorV3.MColorPicker();
            this.fontGroupBox = new System.Windows.Forms.GroupBox();
            this.fontButton = new System.Windows.Forms.Button();
            this.indFontChooser = new CapsLockIndicatorV3.MFontPicker();
            this.positionGroup = new System.Windows.Forms.GroupBox();
            this.positionButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.positionBottomRight = new System.Windows.Forms.RadioButton();
            this.positionBottomCenter = new System.Windows.Forms.RadioButton();
            this.positionBottomLeft = new System.Windows.Forms.RadioButton();
            this.positionMiddleRight = new System.Windows.Forms.RadioButton();
            this.positionMiddleCenter = new System.Windows.Forms.RadioButton();
            this.positionMiddleLeft = new System.Windows.Forms.RadioButton();
            this.positionTopRight = new System.Windows.Forms.RadioButton();
            this.positionTopCenter = new System.Windows.Forms.RadioButton();
            this.positionTopLeft = new System.Windows.Forms.RadioButton();
            this.opacityGroup = new System.Windows.Forms.GroupBox();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.borderGroup = new System.Windows.Forms.GroupBox();
            this.bdSizeLabel = new System.Windows.Forms.Label();
            this.bdSizeSlider = new System.Windows.Forms.TrackBar();
            this.downloadIcons = new CapsLockIndicatorV3.LnkLabel();
            this.tabControl1 = new CapsLockIndicatorV3.BetterTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1b = new System.Windows.Forms.FlowLayoutPanel();
            this.darkModeCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.searchOnResumeCheckBox = new CapsLockIndicatorV3.BetterCheckBox();
            this.advSettingsButton = new System.Windows.Forms.Button();
            this.tutorialToolTip = new CapsLockIndicatorV3.BetterToolTip(this.components);
            this.tutorialTimer = new System.Windows.Forms.Timer(this.components);
            this.generalIconContextMenuStrip.SuspendLayout();
            this.iconsGroup.SuspendLayout();
            this.indicatorGroup.SuspendLayout();
            this.aboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPanelTopBorder)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.displayTimeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayTimeSlider)).BeginInit();
            this.coloursGroup.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourActivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourActivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourActivatedPreview)).BeginInit();
            this.fontGroupBox.SuspendLayout();
            this.positionGroup.SuspendLayout();
            this.positionButtonLayout.SuspendLayout();
            this.opacityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.borderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSizeSlider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1b.SuspendLayout();
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
            this.iconsGroup.Size = new System.Drawing.Size(292, 103);
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
            this.indicatorGroup.Location = new System.Drawing.Point(310, 12);
            this.indicatorGroup.Margin = new System.Windows.Forms.Padding(3, 12, 12, 3);
            this.indicatorGroup.Name = "indicatorGroup";
            this.indicatorGroup.Size = new System.Drawing.Size(292, 103);
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
            this.aboutPanel.Location = new System.Drawing.Point(0, 236);
            this.aboutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(614, 65);
            this.aboutPanel.TabIndex = 4;
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
            this.aboutPanelTopBorder.Size = new System.Drawing.Size(614, 2);
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
            this.aboutText.Size = new System.Drawing.Size(542, 33);
            this.aboutText.TabIndex = 2;
            this.aboutText.Text = "aboutText";
            // 
            // exitApplication
            // 
            this.exitApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.exitApplication.AutoSize = true;
            this.exitApplication.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitApplication.Location = new System.Drawing.Point(161, 33);
            this.exitApplication.Name = "exitApplication";
            this.exitApplication.Size = new System.Drawing.Size(128, 24);
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
            // checkForUpdatesButton
            // 
            this.checkForUpdatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkForUpdatesButton.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.checkForUpdatesButton, 2);
            this.checkForUpdatesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkForUpdatesButton.Location = new System.Drawing.Point(27, 63);
            this.checkForUpdatesButton.Name = "checkForUpdatesButton";
            this.checkForUpdatesButton.Size = new System.Drawing.Size(262, 24);
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
            // checkForUpdatedCheckBox
            // 
            this.checkForUpdatedCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkForUpdatedCheckBox.Checked = true;
            this.checkForUpdatedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkForUpdatedCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkForUpdatedCheckBox.Location = new System.Drawing.Point(6, 67);
            this.checkForUpdatedCheckBox.Name = "checkForUpdatedCheckBox";
            this.checkForUpdatedCheckBox.Size = new System.Drawing.Size(15, 15);
            this.checkForUpdatedCheckBox.TabIndex = 12;
            this.mainToolTip.SetToolTip(this.checkForUpdatedCheckBox, "autoCheckForUpdates");
            this.checkForUpdatedCheckBox.UseVisualStyleBackColor = true;
            this.checkForUpdatedCheckBox.CheckedChanged += new System.EventHandler(this.checkForUpdatedCheckBox_CheckedChanged);
            // 
            // dismissButton
            // 
            this.dismissButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dismissButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dismissButton.Font = new System.Drawing.Font("Marlett", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.dismissButton.Location = new System.Drawing.Point(593, 11);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(24, 24);
            this.dismissButton.TabIndex = 1;
            this.dismissButton.Text = "r";
            this.mainToolTip.SetToolTip(this.dismissButton, "dismiss");
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.button1_Click);
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
            this.localeComboBox.Size = new System.Drawing.Size(262, 24);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 301);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 121);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(12, 3, 3, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(292, 106);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.localeComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.hideWindow, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.exitApplication, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkForUpdatesButton, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkForUpdatedCheckBox, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(310, 121);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 12, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(292, 106);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // hideWindow
            // 
            this.hideWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hideWindow.AutoSize = true;
            this.hideWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hideWindow.Location = new System.Drawing.Point(27, 33);
            this.hideWindow.Name = "hideWindow";
            this.hideWindow.Size = new System.Drawing.Size(128, 24);
            this.hideWindow.TabIndex = 5;
            this.hideWindow.Text = "hideWindow";
            this.hideWindow.UseVisualStyleBackColor = true;
            this.hideWindow.Click += new System.EventHandler(this.HideWindowClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(35, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "eolText";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(92)))));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dismissButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(622, 48);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(58)))), ((int)(((byte)(17)))));
            this.tableLayoutPanel3.SetColumnSpan(this.panel1, 3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 1);
            this.panel1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // displayTimeGroup
            // 
            this.displayTimeGroup.Controls.Add(this.onlyShowWhenActiveCheckBox);
            this.displayTimeGroup.Controls.Add(this.displayTimeLabel);
            this.displayTimeGroup.Controls.Add(this.displayTimeSlider);
            this.displayTimeGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayTimeGroup.Location = new System.Drawing.Point(3, 3);
            this.displayTimeGroup.Name = "displayTimeGroup";
            this.displayTimeGroup.Size = new System.Drawing.Size(298, 67);
            this.displayTimeGroup.TabIndex = 0;
            this.displayTimeGroup.TabStop = false;
            this.displayTimeGroup.Text = "displayTime";
            // 
            // onlyShowWhenActiveCheckBox
            // 
            this.onlyShowWhenActiveCheckBox.AutoSize = true;
            this.onlyShowWhenActiveCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.onlyShowWhenActiveCheckBox.Location = new System.Drawing.Point(6, 70);
            this.onlyShowWhenActiveCheckBox.Name = "onlyShowWhenActiveCheckBox";
            this.onlyShowWhenActiveCheckBox.Size = new System.Drawing.Size(148, 20);
            this.onlyShowWhenActiveCheckBox.TabIndex = 2;
            this.onlyShowWhenActiveCheckBox.Text = "onlyShowWhenActive";
            this.onlyShowWhenActiveCheckBox.UseVisualStyleBackColor = true;
            this.onlyShowWhenActiveCheckBox.CheckedChanged += new System.EventHandler(this.onlyShowWhenActiveCheckBox_CheckedChanged);
            // 
            // displayTimeLabel
            // 
            this.displayTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displayTimeLabel.Location = new System.Drawing.Point(216, 28);
            this.displayTimeLabel.Name = "displayTimeLabel";
            this.displayTimeLabel.Size = new System.Drawing.Size(76, 29);
            this.displayTimeLabel.TabIndex = 1;
            this.displayTimeLabel.Text = "500 ms";
            this.displayTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displayTimeLabel.Click += new System.EventHandler(this.displayTimeLabel_Click);
            // 
            // displayTimeSlider
            // 
            this.displayTimeSlider.LargeChange = 50;
            this.displayTimeSlider.Location = new System.Drawing.Point(6, 22);
            this.displayTimeSlider.Maximum = 2001;
            this.displayTimeSlider.Minimum = 50;
            this.displayTimeSlider.Name = "displayTimeSlider";
            this.displayTimeSlider.Size = new System.Drawing.Size(201, 45);
            this.displayTimeSlider.TabIndex = 0;
            this.displayTimeSlider.TickFrequency = 250;
            this.displayTimeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.displayTimeSlider.Value = 500;
            this.displayTimeSlider.Scroll += new System.EventHandler(this.displayTimeSlider_Scroll);
            // 
            // coloursGroup
            // 
            this.coloursGroup.Controls.Add(this.tableLayoutPanel5);
            this.coloursGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coloursGroup.Location = new System.Drawing.Point(307, 3);
            this.coloursGroup.Name = "coloursGroup";
            this.tableLayoutPanel4.SetRowSpan(this.coloursGroup, 3);
            this.coloursGroup.Size = new System.Drawing.Size(298, 213);
            this.coloursGroup.TabIndex = 3;
            this.coloursGroup.TabStop = false;
            this.coloursGroup.Text = "colours";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.backgroundColourActivatedButton, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.borderColourDeactivatedPreview, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.backgroundColourDeactivatedButton, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.borderColourActivatedPreview, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.foregroundColourDeactivatedPreview, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.borderColourDeactivatedButton, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.backgroundColourDeactivatedPreview, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.foregroundColourActivatedPreview, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.foregroundColourActivatedButton, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.foregroundColourDeactivatedButton, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.borderColourActivatedButton, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.backgroundColourActivatedPreview, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(292, 191);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // backgroundColourActivatedButton
            // 
            this.backgroundColourActivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backgroundColourActivatedButton.Location = new System.Drawing.Point(67, 3);
            this.backgroundColourActivatedButton.Name = "backgroundColourActivatedButton";
            this.backgroundColourActivatedButton.Size = new System.Drawing.Size(222, 25);
            this.backgroundColourActivatedButton.TabIndex = 3;
            this.backgroundColourActivatedButton.Text = "backgroundColourActivated";
            this.backgroundColourActivatedButton.UseVisualStyleBackColor = true;
            this.backgroundColourActivatedButton.Click += new System.EventHandler(this.backgroundColourActivatedButton_Click);
            // 
            // borderColourDeactivatedPreview
            // 
            this.borderColourDeactivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.borderColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColourDeactivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderColourDeactivatedPreview.Location = new System.Drawing.Point(3, 158);
            this.borderColourDeactivatedPreview.Name = "borderColourDeactivatedPreview";
            this.borderColourDeactivatedPreview.Size = new System.Drawing.Size(58, 30);
            this.borderColourDeactivatedPreview.TabIndex = 11;
            this.borderColourDeactivatedPreview.TabStop = false;
            // 
            // backgroundColourDeactivatedButton
            // 
            this.backgroundColourDeactivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backgroundColourDeactivatedButton.Location = new System.Drawing.Point(67, 34);
            this.backgroundColourDeactivatedButton.Name = "backgroundColourDeactivatedButton";
            this.backgroundColourDeactivatedButton.Size = new System.Drawing.Size(222, 25);
            this.backgroundColourDeactivatedButton.TabIndex = 4;
            this.backgroundColourDeactivatedButton.Text = "backgroundColourDeactivated";
            this.backgroundColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.backgroundColourDeactivatedButton.Click += new System.EventHandler(this.backgroundColourDeactivatedButton_Click);
            // 
            // borderColourActivatedPreview
            // 
            this.borderColourActivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(180)))), ((int)(((byte)(52)))));
            this.borderColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColourActivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderColourActivatedPreview.Location = new System.Drawing.Point(3, 127);
            this.borderColourActivatedPreview.Name = "borderColourActivatedPreview";
            this.borderColourActivatedPreview.Size = new System.Drawing.Size(58, 25);
            this.borderColourActivatedPreview.TabIndex = 5;
            this.borderColourActivatedPreview.TabStop = false;
            // 
            // foregroundColourDeactivatedPreview
            // 
            this.foregroundColourDeactivatedPreview.BackColor = System.Drawing.Color.White;
            this.foregroundColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foregroundColourDeactivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foregroundColourDeactivatedPreview.Location = new System.Drawing.Point(3, 96);
            this.foregroundColourDeactivatedPreview.Name = "foregroundColourDeactivatedPreview";
            this.foregroundColourDeactivatedPreview.Size = new System.Drawing.Size(58, 25);
            this.foregroundColourDeactivatedPreview.TabIndex = 9;
            this.foregroundColourDeactivatedPreview.TabStop = false;
            // 
            // borderColourDeactivatedButton
            // 
            this.borderColourDeactivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.borderColourDeactivatedButton.Location = new System.Drawing.Point(67, 158);
            this.borderColourDeactivatedButton.Name = "borderColourDeactivatedButton";
            this.borderColourDeactivatedButton.Size = new System.Drawing.Size(222, 30);
            this.borderColourDeactivatedButton.TabIndex = 8;
            this.borderColourDeactivatedButton.Text = "borderColourDecativated";
            this.borderColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.borderColourDeactivatedButton.Click += new System.EventHandler(this.borderColourDeactivatedButton_Click);
            // 
            // backgroundColourDeactivatedPreview
            // 
            this.backgroundColourDeactivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.backgroundColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColourDeactivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundColourDeactivatedPreview.Location = new System.Drawing.Point(3, 34);
            this.backgroundColourDeactivatedPreview.Name = "backgroundColourDeactivatedPreview";
            this.backgroundColourDeactivatedPreview.Size = new System.Drawing.Size(58, 25);
            this.backgroundColourDeactivatedPreview.TabIndex = 7;
            this.backgroundColourDeactivatedPreview.TabStop = false;
            // 
            // foregroundColourActivatedPreview
            // 
            this.foregroundColourActivatedPreview.BackColor = System.Drawing.Color.White;
            this.foregroundColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foregroundColourActivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foregroundColourActivatedPreview.Location = new System.Drawing.Point(3, 65);
            this.foregroundColourActivatedPreview.Name = "foregroundColourActivatedPreview";
            this.foregroundColourActivatedPreview.Size = new System.Drawing.Size(58, 25);
            this.foregroundColourActivatedPreview.TabIndex = 3;
            this.foregroundColourActivatedPreview.TabStop = false;
            // 
            // foregroundColourActivatedButton
            // 
            this.foregroundColourActivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foregroundColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.foregroundColourActivatedButton.Location = new System.Drawing.Point(67, 65);
            this.foregroundColourActivatedButton.Name = "foregroundColourActivatedButton";
            this.foregroundColourActivatedButton.Size = new System.Drawing.Size(222, 25);
            this.foregroundColourActivatedButton.TabIndex = 5;
            this.foregroundColourActivatedButton.Text = "textColourActivated";
            this.foregroundColourActivatedButton.UseVisualStyleBackColor = true;
            this.foregroundColourActivatedButton.Click += new System.EventHandler(this.foregroundColourActivatedButton_Click);
            // 
            // foregroundColourDeactivatedButton
            // 
            this.foregroundColourDeactivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foregroundColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.foregroundColourDeactivatedButton.Location = new System.Drawing.Point(67, 96);
            this.foregroundColourDeactivatedButton.Name = "foregroundColourDeactivatedButton";
            this.foregroundColourDeactivatedButton.Size = new System.Drawing.Size(222, 25);
            this.foregroundColourDeactivatedButton.TabIndex = 6;
            this.foregroundColourDeactivatedButton.Text = "textColourActivated";
            this.foregroundColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.foregroundColourDeactivatedButton.Click += new System.EventHandler(this.foregroundColourDeactivatedButton_Click);
            // 
            // borderColourActivatedButton
            // 
            this.borderColourActivatedButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.borderColourActivatedButton.Location = new System.Drawing.Point(67, 127);
            this.borderColourActivatedButton.Name = "borderColourActivatedButton";
            this.borderColourActivatedButton.Size = new System.Drawing.Size(222, 25);
            this.borderColourActivatedButton.TabIndex = 7;
            this.borderColourActivatedButton.Text = "borderColourActivated";
            this.borderColourActivatedButton.UseVisualStyleBackColor = true;
            this.borderColourActivatedButton.Click += new System.EventHandler(this.borderColourActivatedButton_Click);
            // 
            // backgroundColourActivatedPreview
            // 
            this.backgroundColourActivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.backgroundColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColourActivatedPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundColourActivatedPreview.Location = new System.Drawing.Point(3, 3);
            this.backgroundColourActivatedPreview.Name = "backgroundColourActivatedPreview";
            this.backgroundColourActivatedPreview.Size = new System.Drawing.Size(58, 25);
            this.backgroundColourActivatedPreview.TabIndex = 1;
            this.backgroundColourActivatedPreview.TabStop = false;
            // 
            // fontGroupBox
            // 
            this.fontGroupBox.Controls.Add(this.fontButton);
            this.fontGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontGroupBox.Location = new System.Drawing.Point(3, 76);
            this.fontGroupBox.Name = "fontGroupBox";
            this.fontGroupBox.Size = new System.Drawing.Size(298, 67);
            this.fontGroupBox.TabIndex = 2;
            this.fontGroupBox.TabStop = false;
            this.fontGroupBox.Text = "font";
            // 
            // fontButton
            // 
            this.fontButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fontButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.fontButton.Location = new System.Drawing.Point(3, 19);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(292, 45);
            this.fontButton.TabIndex = 2;
            this.fontButton.Text = "preview";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // indFontChooser
            // 
            this.indFontChooser.AllowScriptChange = false;
            this.indFontChooser.AllowSimulations = false;
            this.indFontChooser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.indFontChooser.FontMustExist = true;
            this.indFontChooser.ScriptsOnly = true;
            this.indFontChooser.ShowEffects = false;
            // 
            // positionGroup
            // 
            this.positionGroup.Controls.Add(this.positionButtonLayout);
            this.positionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionGroup.Location = new System.Drawing.Point(3, 149);
            this.positionGroup.Name = "positionGroup";
            this.positionGroup.Size = new System.Drawing.Size(298, 67);
            this.positionGroup.TabIndex = 11;
            this.positionGroup.TabStop = false;
            this.positionGroup.Text = "overlayPosition";
            // 
            // positionButtonLayout
            // 
            this.positionButtonLayout.ColumnCount = 3;
            this.positionButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.Controls.Add(this.positionBottomRight, 2, 2);
            this.positionButtonLayout.Controls.Add(this.positionBottomCenter, 1, 2);
            this.positionButtonLayout.Controls.Add(this.positionBottomLeft, 0, 2);
            this.positionButtonLayout.Controls.Add(this.positionMiddleRight, 2, 1);
            this.positionButtonLayout.Controls.Add(this.positionMiddleCenter, 1, 1);
            this.positionButtonLayout.Controls.Add(this.positionMiddleLeft, 0, 1);
            this.positionButtonLayout.Controls.Add(this.positionTopRight, 2, 0);
            this.positionButtonLayout.Controls.Add(this.positionTopCenter, 1, 0);
            this.positionButtonLayout.Controls.Add(this.positionTopLeft, 0, 0);
            this.positionButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionButtonLayout.Location = new System.Drawing.Point(3, 19);
            this.positionButtonLayout.Name = "positionButtonLayout";
            this.positionButtonLayout.RowCount = 3;
            this.positionButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.positionButtonLayout.Size = new System.Drawing.Size(292, 45);
            this.positionButtonLayout.TabIndex = 0;
            // 
            // positionBottomRight
            // 
            this.positionBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomRight.Location = new System.Drawing.Point(194, 30);
            this.positionBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomRight.Name = "positionBottomRight";
            this.positionBottomRight.Size = new System.Drawing.Size(98, 15);
            this.positionBottomRight.TabIndex = 8;
            this.positionBottomRight.UseVisualStyleBackColor = true;
            this.positionBottomRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionBottomCenter
            // 
            this.positionBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomCenter.Location = new System.Drawing.Point(97, 30);
            this.positionBottomCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomCenter.Name = "positionBottomCenter";
            this.positionBottomCenter.Size = new System.Drawing.Size(97, 15);
            this.positionBottomCenter.TabIndex = 7;
            this.positionBottomCenter.UseVisualStyleBackColor = true;
            this.positionBottomCenter.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionBottomLeft
            // 
            this.positionBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomLeft.Location = new System.Drawing.Point(0, 30);
            this.positionBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomLeft.Name = "positionBottomLeft";
            this.positionBottomLeft.Size = new System.Drawing.Size(97, 15);
            this.positionBottomLeft.TabIndex = 6;
            this.positionBottomLeft.UseVisualStyleBackColor = true;
            this.positionBottomLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleRight
            // 
            this.positionMiddleRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleRight.Location = new System.Drawing.Point(194, 15);
            this.positionMiddleRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleRight.Name = "positionMiddleRight";
            this.positionMiddleRight.Size = new System.Drawing.Size(98, 15);
            this.positionMiddleRight.TabIndex = 5;
            this.positionMiddleRight.UseVisualStyleBackColor = true;
            this.positionMiddleRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleCenter
            // 
            this.positionMiddleCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleCenter.Location = new System.Drawing.Point(97, 15);
            this.positionMiddleCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleCenter.Name = "positionMiddleCenter";
            this.positionMiddleCenter.Size = new System.Drawing.Size(97, 15);
            this.positionMiddleCenter.TabIndex = 4;
            this.positionMiddleCenter.UseVisualStyleBackColor = true;
            this.positionMiddleCenter.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleLeft
            // 
            this.positionMiddleLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleLeft.Location = new System.Drawing.Point(0, 15);
            this.positionMiddleLeft.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleLeft.Name = "positionMiddleLeft";
            this.positionMiddleLeft.Size = new System.Drawing.Size(97, 15);
            this.positionMiddleLeft.TabIndex = 3;
            this.positionMiddleLeft.UseVisualStyleBackColor = true;
            this.positionMiddleLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionTopRight
            // 
            this.positionTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionTopRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionTopRight.Location = new System.Drawing.Point(194, 0);
            this.positionTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionTopRight.Name = "positionTopRight";
            this.positionTopRight.Size = new System.Drawing.Size(98, 15);
            this.positionTopRight.TabIndex = 2;
            this.positionTopRight.UseVisualStyleBackColor = true;
            this.positionTopRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionTopCenter
            // 
            this.positionTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionTopCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionTopCenter.Location = new System.Drawing.Point(97, 0);
            this.positionTopCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionTopCenter.Name = "positionTopCenter";
            this.positionTopCenter.Size = new System.Drawing.Size(97, 15);
            this.positionTopCenter.TabIndex = 1;
            this.positionTopCenter.UseVisualStyleBackColor = true;
            this.positionTopCenter.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionTopLeft
            // 
            this.positionTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionTopLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionTopLeft.Location = new System.Drawing.Point(0, 0);
            this.positionTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.positionTopLeft.Name = "positionTopLeft";
            this.positionTopLeft.Size = new System.Drawing.Size(97, 15);
            this.positionTopLeft.TabIndex = 0;
            this.positionTopLeft.UseVisualStyleBackColor = true;
            this.positionTopLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // opacityGroup
            // 
            this.opacityGroup.Controls.Add(this.opacityLabel);
            this.opacityGroup.Controls.Add(this.opacitySlider);
            this.opacityGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opacityGroup.Location = new System.Drawing.Point(3, 222);
            this.opacityGroup.Name = "opacityGroup";
            this.opacityGroup.Size = new System.Drawing.Size(298, 70);
            this.opacityGroup.TabIndex = 2;
            this.opacityGroup.TabStop = false;
            this.opacityGroup.Text = "opacity";
            // 
            // opacityLabel
            // 
            this.opacityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.opacityLabel.Location = new System.Drawing.Point(216, 25);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(76, 31);
            this.opacityLabel.TabIndex = 1;
            this.opacityLabel.Text = "100%";
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opacityLabel.Click += new System.EventHandler(this.opacityLabel_Click);
            // 
            // opacitySlider
            // 
            this.opacitySlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.opacitySlider.LargeChange = 10;
            this.opacitySlider.Location = new System.Drawing.Point(6, 20);
            this.opacitySlider.Maximum = 100;
            this.opacitySlider.Minimum = 1;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(201, 45);
            this.opacitySlider.TabIndex = 0;
            this.opacitySlider.TickFrequency = 10;
            this.opacitySlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.opacitySlider.Value = 100;
            this.opacitySlider.Scroll += new System.EventHandler(this.opacitySlider_Scroll);
            // 
            // borderGroup
            // 
            this.borderGroup.Controls.Add(this.bdSizeLabel);
            this.borderGroup.Controls.Add(this.bdSizeSlider);
            this.borderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderGroup.Location = new System.Drawing.Point(307, 222);
            this.borderGroup.Name = "borderGroup";
            this.borderGroup.Size = new System.Drawing.Size(298, 70);
            this.borderGroup.TabIndex = 3;
            this.borderGroup.TabStop = false;
            this.borderGroup.Text = "borderThickness";
            // 
            // bdSizeLabel
            // 
            this.bdSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bdSizeLabel.Location = new System.Drawing.Point(213, 19);
            this.bdSizeLabel.Name = "bdSizeLabel";
            this.bdSizeLabel.Size = new System.Drawing.Size(76, 43);
            this.bdSizeLabel.TabIndex = 1;
            this.bdSizeLabel.Text = "4";
            this.bdSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bdSizeLabel.Click += new System.EventHandler(this.bdSizeLabel_Click);
            // 
            // bdSizeSlider
            // 
            this.bdSizeSlider.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bdSizeSlider.LargeChange = 10;
            this.bdSizeSlider.Location = new System.Drawing.Point(6, 20);
            this.bdSizeSlider.Maximum = 32;
            this.bdSizeSlider.Name = "bdSizeSlider";
            this.bdSizeSlider.Size = new System.Drawing.Size(201, 45);
            this.bdSizeSlider.TabIndex = 0;
            this.bdSizeSlider.TickFrequency = 4;
            this.bdSizeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.bdSizeSlider.Value = 32;
            this.bdSizeSlider.Scroll += new System.EventHandler(this.bdSizeSlider_Scroll);
            // 
            // downloadIcons
            // 
            this.downloadIcons.AutoSize = true;
            this.downloadIcons.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.downloadIcons.Location = new System.Drawing.Point(3, 58);
            this.downloadIcons.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.downloadIcons.Name = "downloadIcons";
            this.downloadIcons.Size = new System.Drawing.Size(88, 15);
            this.downloadIcons.TabIndex = 12;
            this.downloadIcons.TabStop = true;
            this.downloadIcons.Text = "downloadIcons";
            this.downloadIcons.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.downloadIcons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel2_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MyBackColor = System.Drawing.SystemColors.Control;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 329);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(614, 301);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "340";
            this.tabPage3.Text = "general";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "474";
            this.tabPage1.Text = "notification";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.displayTimeGroup, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.fontGroupBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.positionGroup, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.opacityGroup, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.coloursGroup, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.borderGroup, 1, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(608, 295);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1b);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "163";
            this.tabPage2.Text = "advancedOptions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1b
            // 
            this.flowLayoutPanel1b.Controls.Add(this.darkModeCheckBox);
            this.flowLayoutPanel1b.Controls.Add(this.searchOnResumeCheckBox);
            this.flowLayoutPanel1b.Controls.Add(this.downloadIcons);
            this.flowLayoutPanel1b.Controls.Add(this.advSettingsButton);
            this.flowLayoutPanel1b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1b.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1b.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1b.Name = "flowLayoutPanel1b";
            this.flowLayoutPanel1b.Size = new System.Drawing.Size(608, 295);
            this.flowLayoutPanel1b.TabIndex = 0;
            // 
            // darkModeCheckBox
            // 
            this.darkModeCheckBox.AutoSize = true;
            this.darkModeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.darkModeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.darkModeCheckBox.Name = "darkModeCheckBox";
            this.darkModeCheckBox.Size = new System.Drawing.Size(86, 20);
            this.darkModeCheckBox.TabIndex = 0;
            this.darkModeCheckBox.Text = "darkMode";
            this.darkModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchOnResumeCheckBox
            // 
            this.searchOnResumeCheckBox.AutoSize = true;
            this.searchOnResumeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.searchOnResumeCheckBox.Location = new System.Drawing.Point(3, 29);
            this.searchOnResumeCheckBox.Name = "searchOnResumeCheckBox";
            this.searchOnResumeCheckBox.Size = new System.Drawing.Size(184, 20);
            this.searchOnResumeCheckBox.TabIndex = 1;
            this.searchOnResumeCheckBox.Text = "searchForUpdatesOnResume";
            this.searchOnResumeCheckBox.UseVisualStyleBackColor = true;
            // 
            // advSettingsButton
            // 
            this.advSettingsButton.AutoSize = true;
            this.advSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.advSettingsButton.Location = new System.Drawing.Point(3, 82);
            this.advSettingsButton.Name = "advSettingsButton";
            this.advSettingsButton.Size = new System.Drawing.Size(82, 24);
            this.advSettingsButton.TabIndex = 2;
            this.advSettingsButton.Text = "advSettings";
            this.advSettingsButton.UseVisualStyleBackColor = true;
            this.advSettingsButton.Click += new System.EventHandler(this.advSettingsButton_Click);
            // 
            // tutorialToolTip
            // 
            this.tutorialToolTip.IsBalloon = true;
            this.tutorialToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tutorialToolTip.ToolTipTitle = "CapsLock Indicator";
            // 
            // tutorialTimer
            // 
            this.tutorialTimer.Interval = 1000;
            this.tutorialTimer.Tick += new System.EventHandler(this.tutorialTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(622, 329);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tabControl1);
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
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPanelTopBorder)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.displayTimeGroup.ResumeLayout(false);
            this.displayTimeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayTimeSlider)).EndInit();
            this.coloursGroup.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.borderColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourActivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourActivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourActivatedPreview)).EndInit();
            this.fontGroupBox.ResumeLayout(false);
            this.positionGroup.ResumeLayout(false);
            this.positionButtonLayout.ResumeLayout(false);
            this.opacityGroup.ResumeLayout(false);
            this.opacityGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            this.borderGroup.ResumeLayout(false);
            this.borderGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSizeSlider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1b.ResumeLayout(false);
            this.flowLayoutPanel1b.PerformLayout();
            this.ResumeLayout(false);

		}

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.NotifyIcon numLockIcon;
        private System.Windows.Forms.NotifyIcon capsLockIcon;
        private System.Windows.Forms.NotifyIcon scrollLockIcon;
        private System.Windows.Forms.GroupBox iconsGroup;
        private BetterCheckBox enableScrollIcon;
        private BetterCheckBox enableCapsIcon;
        private BetterCheckBox enableNumIcon;
        private System.Windows.Forms.GroupBox indicatorGroup;
        private BetterCheckBox enableScrollInd;
        private BetterCheckBox enableCapsInd;
        private BetterCheckBox enableNumInd;
        private BetterCheckBox showNoIcons;
        private BetterCheckBox showNoNotification;
        private System.Windows.Forms.Panel aboutPanel;
        private System.Windows.Forms.Label aboutText;
        private System.Windows.Forms.PictureBox aboutPanelTopBorder;
        private System.Windows.Forms.Button exitApplication;
        private System.Windows.Forms.NotifyIcon generalIcon;
        private System.Windows.Forms.Button checkForUpdatesButton;
        private BetterCheckBox startonlogonCheckBox;
        private BetterCheckBox hideOnStartupCheckBox;
        private System.Windows.Forms.ContextMenuStrip generalIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private LnkLabel appNameLabel;
        private BetterToolTip mainToolTip;
        private BetterCheckBox checkForUpdatedCheckBox;
        private CapsLockIndicatorV3.LnComboBox localeComboBox;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem showMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button hideWindow;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button dismissButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox displayTimeGroup;
        private System.Windows.Forms.Label displayTimeLabel;
        private System.Windows.Forms.TrackBar displayTimeSlider;
        private System.Windows.Forms.GroupBox coloursGroup;
        private System.Windows.Forms.Button backgroundColourActivatedButton;
        private System.Windows.Forms.PictureBox backgroundColourActivatedPreview;
        private System.Windows.Forms.PictureBox borderColourActivatedPreview;
        private System.Windows.Forms.Button borderColourActivatedButton;
        private System.Windows.Forms.PictureBox foregroundColourActivatedPreview;
        private System.Windows.Forms.Button foregroundColourActivatedButton;
        private CapsLockIndicatorV3.MColorPicker mainColourPicker;
        private System.Windows.Forms.PictureBox backgroundColourDeactivatedPreview;
        private System.Windows.Forms.Button backgroundColourDeactivatedButton;
        private System.Windows.Forms.GroupBox fontGroupBox;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.PictureBox foregroundColourDeactivatedPreview;
        private System.Windows.Forms.Button foregroundColourDeactivatedButton;
        private System.Windows.Forms.PictureBox borderColourDeactivatedPreview;
        private System.Windows.Forms.Button borderColourDeactivatedButton;
        private CapsLockIndicatorV3.MFontPicker indFontChooser;
        private System.Windows.Forms.GroupBox positionGroup;
        private System.Windows.Forms.TableLayoutPanel positionButtonLayout;
        private System.Windows.Forms.RadioButton positionBottomRight;
        private System.Windows.Forms.RadioButton positionBottomCenter;
        private System.Windows.Forms.RadioButton positionBottomLeft;
        private System.Windows.Forms.RadioButton positionMiddleRight;
        private System.Windows.Forms.RadioButton positionMiddleCenter;
        private System.Windows.Forms.RadioButton positionMiddleLeft;
        private System.Windows.Forms.RadioButton positionTopRight;
        private System.Windows.Forms.RadioButton positionTopCenter;
        private System.Windows.Forms.RadioButton positionTopLeft;
        private System.Windows.Forms.GroupBox opacityGroup;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.TrackBar opacitySlider;
        private BetterCheckBox onlyShowWhenActiveCheckBox;
        private System.Windows.Forms.GroupBox borderGroup;
        private System.Windows.Forms.Label bdSizeLabel;
        private System.Windows.Forms.TrackBar bdSizeSlider;
        private LnkLabel downloadIcons;
        private BetterTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1b;
        private BetterCheckBox darkModeCheckBox;
        private BetterCheckBox searchOnResumeCheckBox;
        private System.Windows.Forms.Button advSettingsButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private BetterToolTip tutorialToolTip;
        private System.Windows.Forms.Timer tutorialTimer;
    }
}
