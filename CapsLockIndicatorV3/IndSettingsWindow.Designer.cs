namespace CapsLockIndicatorV3
{
    partial class IndSettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndSettingsWindow));
            this.displayTimeGroup = new System.Windows.Forms.GroupBox();
            this.onlyShowWhenActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.displayTimeLabel = new System.Windows.Forms.Label();
            this.displayTimeSlider = new System.Windows.Forms.TrackBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.coloursGroup = new System.Windows.Forms.GroupBox();
            this.borderColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.borderColourDeactivatedButton = new System.Windows.Forms.Button();
            this.foregroundColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourDeactivatedButton = new System.Windows.Forms.Button();
            this.backgroundColourDeactivatedPreview = new System.Windows.Forms.PictureBox();
            this.backgroundColourDeactivatedButton = new System.Windows.Forms.Button();
            this.borderColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.borderColourActivatedButton = new System.Windows.Forms.Button();
            this.foregroundColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourActivatedButton = new System.Windows.Forms.Button();
            this.backgroundColourActivatedPreview = new System.Windows.Forms.PictureBox();
            this.backgroundColourActivatedButton = new System.Windows.Forms.Button();
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
            this.displayTimeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayTimeSlider)).BeginInit();
            this.coloursGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourDeactivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourActivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourActivatedPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourActivatedPreview)).BeginInit();
            this.fontGroupBox.SuspendLayout();
            this.positionGroup.SuspendLayout();
            this.positionButtonLayout.SuspendLayout();
            this.opacityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            this.borderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdSizeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTimeGroup
            // 
            this.displayTimeGroup.Controls.Add(this.onlyShowWhenActiveCheckBox);
            this.displayTimeGroup.Controls.Add(this.displayTimeLabel);
            this.displayTimeGroup.Controls.Add(this.displayTimeSlider);
            this.displayTimeGroup.Location = new System.Drawing.Point(12, 12);
            this.displayTimeGroup.Name = "displayTimeGroup";
            this.displayTimeGroup.Size = new System.Drawing.Size(276, 95);
            this.displayTimeGroup.TabIndex = 0;
            this.displayTimeGroup.TabStop = false;
            this.displayTimeGroup.Text = "Display time";
            // 
            // onlyShowWhenActiveCheckBox
            // 
            this.onlyShowWhenActiveCheckBox.AutoSize = true;
            this.onlyShowWhenActiveCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.onlyShowWhenActiveCheckBox.Location = new System.Drawing.Point(6, 70);
            this.onlyShowWhenActiveCheckBox.Name = "onlyShowWhenActiveCheckBox";
            this.onlyShowWhenActiveCheckBox.Size = new System.Drawing.Size(195, 20);
            this.onlyShowWhenActiveCheckBox.TabIndex = 2;
            this.onlyShowWhenActiveCheckBox.Text = "Only show overlay when active";
            this.onlyShowWhenActiveCheckBox.UseVisualStyleBackColor = true;
            this.onlyShowWhenActiveCheckBox.CheckedChanged += new System.EventHandler(this.onlyShowWhenActiveCheckBox_CheckedChanged);
            // 
            // displayTimeLabel
            // 
            this.displayTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayTimeLabel.Location = new System.Drawing.Point(194, 22);
            this.displayTimeLabel.Name = "displayTimeLabel";
            this.displayTimeLabel.Size = new System.Drawing.Size(76, 45);
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
            this.displayTimeSlider.Size = new System.Drawing.Size(147, 45);
            this.displayTimeSlider.TabIndex = 0;
            this.displayTimeSlider.TickFrequency = 250;
            this.displayTimeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.displayTimeSlider.Value = 500;
            this.displayTimeSlider.Scroll += new System.EventHandler(this.displayTimeSlider_Scroll);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.AutoSize = true;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.saveButton.Location = new System.Drawing.Point(435, 344);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(132, 24);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "&Save && close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // coloursGroup
            // 
            this.coloursGroup.Controls.Add(this.borderColourDeactivatedPreview);
            this.coloursGroup.Controls.Add(this.borderColourDeactivatedButton);
            this.coloursGroup.Controls.Add(this.foregroundColourDeactivatedPreview);
            this.coloursGroup.Controls.Add(this.foregroundColourDeactivatedButton);
            this.coloursGroup.Controls.Add(this.backgroundColourDeactivatedPreview);
            this.coloursGroup.Controls.Add(this.backgroundColourDeactivatedButton);
            this.coloursGroup.Controls.Add(this.borderColourActivatedPreview);
            this.coloursGroup.Controls.Add(this.borderColourActivatedButton);
            this.coloursGroup.Controls.Add(this.foregroundColourActivatedPreview);
            this.coloursGroup.Controls.Add(this.foregroundColourActivatedButton);
            this.coloursGroup.Controls.Add(this.backgroundColourActivatedPreview);
            this.coloursGroup.Controls.Add(this.backgroundColourActivatedButton);
            this.coloursGroup.Location = new System.Drawing.Point(297, 12);
            this.coloursGroup.Name = "coloursGroup";
            this.coloursGroup.Size = new System.Drawing.Size(270, 230);
            this.coloursGroup.TabIndex = 3;
            this.coloursGroup.TabStop = false;
            this.coloursGroup.Text = "Colours";
            // 
            // borderColourDeactivatedPreview
            // 
            this.borderColourDeactivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.borderColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColourDeactivatedPreview.Location = new System.Drawing.Point(6, 177);
            this.borderColourDeactivatedPreview.Name = "borderColourDeactivatedPreview";
            this.borderColourDeactivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.borderColourDeactivatedPreview.TabIndex = 11;
            this.borderColourDeactivatedPreview.TabStop = false;
            // 
            // borderColourDeactivatedButton
            // 
            this.borderColourDeactivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.borderColourDeactivatedButton.Location = new System.Drawing.Point(53, 177);
            this.borderColourDeactivatedButton.Name = "borderColourDeactivatedButton";
            this.borderColourDeactivatedButton.Size = new System.Drawing.Size(208, 25);
            this.borderColourDeactivatedButton.TabIndex = 8;
            this.borderColourDeactivatedButton.Text = "Border colour decativated";
            this.borderColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.borderColourDeactivatedButton.Click += new System.EventHandler(this.borderColourDeactivatedButton_Click);
            // 
            // foregroundColourDeactivatedPreview
            // 
            this.foregroundColourDeactivatedPreview.BackColor = System.Drawing.Color.White;
            this.foregroundColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foregroundColourDeactivatedPreview.Location = new System.Drawing.Point(6, 115);
            this.foregroundColourDeactivatedPreview.Name = "foregroundColourDeactivatedPreview";
            this.foregroundColourDeactivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.foregroundColourDeactivatedPreview.TabIndex = 9;
            this.foregroundColourDeactivatedPreview.TabStop = false;
            // 
            // foregroundColourDeactivatedButton
            // 
            this.foregroundColourDeactivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foregroundColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.foregroundColourDeactivatedButton.Location = new System.Drawing.Point(53, 115);
            this.foregroundColourDeactivatedButton.Name = "foregroundColourDeactivatedButton";
            this.foregroundColourDeactivatedButton.Size = new System.Drawing.Size(208, 25);
            this.foregroundColourDeactivatedButton.TabIndex = 6;
            this.foregroundColourDeactivatedButton.Text = "Text colour activated";
            this.foregroundColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.foregroundColourDeactivatedButton.Click += new System.EventHandler(this.foregroundColourDeactivatedButton_Click);
            // 
            // backgroundColourDeactivatedPreview
            // 
            this.backgroundColourDeactivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.backgroundColourDeactivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColourDeactivatedPreview.Location = new System.Drawing.Point(6, 53);
            this.backgroundColourDeactivatedPreview.Name = "backgroundColourDeactivatedPreview";
            this.backgroundColourDeactivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.backgroundColourDeactivatedPreview.TabIndex = 7;
            this.backgroundColourDeactivatedPreview.TabStop = false;
            // 
            // backgroundColourDeactivatedButton
            // 
            this.backgroundColourDeactivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundColourDeactivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backgroundColourDeactivatedButton.Location = new System.Drawing.Point(53, 53);
            this.backgroundColourDeactivatedButton.Name = "backgroundColourDeactivatedButton";
            this.backgroundColourDeactivatedButton.Size = new System.Drawing.Size(208, 25);
            this.backgroundColourDeactivatedButton.TabIndex = 4;
            this.backgroundColourDeactivatedButton.Text = "Background colour deactivated";
            this.backgroundColourDeactivatedButton.UseVisualStyleBackColor = true;
            this.backgroundColourDeactivatedButton.Click += new System.EventHandler(this.backgroundColourDeactivatedButton_Click);
            // 
            // borderColourActivatedPreview
            // 
            this.borderColourActivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(180)))), ((int)(((byte)(52)))));
            this.borderColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColourActivatedPreview.Location = new System.Drawing.Point(6, 146);
            this.borderColourActivatedPreview.Name = "borderColourActivatedPreview";
            this.borderColourActivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.borderColourActivatedPreview.TabIndex = 5;
            this.borderColourActivatedPreview.TabStop = false;
            // 
            // borderColourActivatedButton
            // 
            this.borderColourActivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.borderColourActivatedButton.Location = new System.Drawing.Point(53, 146);
            this.borderColourActivatedButton.Name = "borderColourActivatedButton";
            this.borderColourActivatedButton.Size = new System.Drawing.Size(208, 25);
            this.borderColourActivatedButton.TabIndex = 7;
            this.borderColourActivatedButton.Text = "Border colour activated";
            this.borderColourActivatedButton.UseVisualStyleBackColor = true;
            this.borderColourActivatedButton.Click += new System.EventHandler(this.borderColourActivatedButton_Click);
            // 
            // foregroundColourActivatedPreview
            // 
            this.foregroundColourActivatedPreview.BackColor = System.Drawing.Color.White;
            this.foregroundColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foregroundColourActivatedPreview.Location = new System.Drawing.Point(6, 84);
            this.foregroundColourActivatedPreview.Name = "foregroundColourActivatedPreview";
            this.foregroundColourActivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.foregroundColourActivatedPreview.TabIndex = 3;
            this.foregroundColourActivatedPreview.TabStop = false;
            // 
            // foregroundColourActivatedButton
            // 
            this.foregroundColourActivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foregroundColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.foregroundColourActivatedButton.Location = new System.Drawing.Point(53, 84);
            this.foregroundColourActivatedButton.Name = "foregroundColourActivatedButton";
            this.foregroundColourActivatedButton.Size = new System.Drawing.Size(208, 25);
            this.foregroundColourActivatedButton.TabIndex = 5;
            this.foregroundColourActivatedButton.Text = "Text colour activated";
            this.foregroundColourActivatedButton.UseVisualStyleBackColor = true;
            this.foregroundColourActivatedButton.Click += new System.EventHandler(this.foregroundColourActivatedButton_Click);
            // 
            // backgroundColourActivatedPreview
            // 
            this.backgroundColourActivatedPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.backgroundColourActivatedPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColourActivatedPreview.Location = new System.Drawing.Point(6, 22);
            this.backgroundColourActivatedPreview.Name = "backgroundColourActivatedPreview";
            this.backgroundColourActivatedPreview.Size = new System.Drawing.Size(41, 25);
            this.backgroundColourActivatedPreview.TabIndex = 1;
            this.backgroundColourActivatedPreview.TabStop = false;
            // 
            // backgroundColourActivatedButton
            // 
            this.backgroundColourActivatedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundColourActivatedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backgroundColourActivatedButton.Location = new System.Drawing.Point(53, 22);
            this.backgroundColourActivatedButton.Name = "backgroundColourActivatedButton";
            this.backgroundColourActivatedButton.Size = new System.Drawing.Size(208, 25);
            this.backgroundColourActivatedButton.TabIndex = 3;
            this.backgroundColourActivatedButton.Text = "Background colour activated";
            this.backgroundColourActivatedButton.UseVisualStyleBackColor = true;
            this.backgroundColourActivatedButton.Click += new System.EventHandler(this.backgroundColourActivatedButton_Click);
            // 
            // fontGroupBox
            // 
            this.fontGroupBox.Controls.Add(this.fontButton);
            this.fontGroupBox.Location = new System.Drawing.Point(12, 113);
            this.fontGroupBox.Name = "fontGroupBox";
            this.fontGroupBox.Size = new System.Drawing.Size(276, 70);
            this.fontGroupBox.TabIndex = 2;
            this.fontGroupBox.TabStop = false;
            this.fontGroupBox.Text = "Font";
            // 
            // fontButton
            // 
            this.fontButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fontButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.fontButton.Location = new System.Drawing.Point(6, 22);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(232, 42);
            this.fontButton.TabIndex = 2;
            this.fontButton.Text = "Capslock is off";
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
            this.positionGroup.Location = new System.Drawing.Point(12, 189);
            this.positionGroup.Name = "positionGroup";
            this.positionGroup.Size = new System.Drawing.Size(276, 100);
            this.positionGroup.TabIndex = 11;
            this.positionGroup.TabStop = false;
            this.positionGroup.Text = "Overlay position";
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
            this.positionButtonLayout.Size = new System.Drawing.Size(270, 78);
            this.positionButtonLayout.TabIndex = 0;
            // 
            // positionBottomRight
            // 
            this.positionBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomRight.Location = new System.Drawing.Point(180, 52);
            this.positionBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomRight.Name = "positionBottomRight";
            this.positionBottomRight.Size = new System.Drawing.Size(90, 26);
            this.positionBottomRight.TabIndex = 8;
            this.positionBottomRight.UseVisualStyleBackColor = true;
            this.positionBottomRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionBottomCenter
            // 
            this.positionBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomCenter.Location = new System.Drawing.Point(90, 52);
            this.positionBottomCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomCenter.Name = "positionBottomCenter";
            this.positionBottomCenter.Size = new System.Drawing.Size(90, 26);
            this.positionBottomCenter.TabIndex = 7;
            this.positionBottomCenter.UseVisualStyleBackColor = true;
            this.positionBottomCenter.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionBottomLeft
            // 
            this.positionBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionBottomLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionBottomLeft.Location = new System.Drawing.Point(0, 52);
            this.positionBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.positionBottomLeft.Name = "positionBottomLeft";
            this.positionBottomLeft.Size = new System.Drawing.Size(90, 26);
            this.positionBottomLeft.TabIndex = 6;
            this.positionBottomLeft.UseVisualStyleBackColor = true;
            this.positionBottomLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleRight
            // 
            this.positionMiddleRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleRight.Location = new System.Drawing.Point(180, 26);
            this.positionMiddleRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleRight.Name = "positionMiddleRight";
            this.positionMiddleRight.Size = new System.Drawing.Size(90, 26);
            this.positionMiddleRight.TabIndex = 5;
            this.positionMiddleRight.UseVisualStyleBackColor = true;
            this.positionMiddleRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleCenter
            // 
            this.positionMiddleCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleCenter.Location = new System.Drawing.Point(90, 26);
            this.positionMiddleCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleCenter.Name = "positionMiddleCenter";
            this.positionMiddleCenter.Size = new System.Drawing.Size(90, 26);
            this.positionMiddleCenter.TabIndex = 4;
            this.positionMiddleCenter.UseVisualStyleBackColor = true;
            this.positionMiddleCenter.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionMiddleLeft
            // 
            this.positionMiddleLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionMiddleLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionMiddleLeft.Location = new System.Drawing.Point(0, 26);
            this.positionMiddleLeft.Margin = new System.Windows.Forms.Padding(0);
            this.positionMiddleLeft.Name = "positionMiddleLeft";
            this.positionMiddleLeft.Size = new System.Drawing.Size(90, 26);
            this.positionMiddleLeft.TabIndex = 3;
            this.positionMiddleLeft.UseVisualStyleBackColor = true;
            this.positionMiddleLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionTopRight
            // 
            this.positionTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionTopRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionTopRight.Location = new System.Drawing.Point(180, 0);
            this.positionTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.positionTopRight.Name = "positionTopRight";
            this.positionTopRight.Size = new System.Drawing.Size(90, 26);
            this.positionTopRight.TabIndex = 2;
            this.positionTopRight.UseVisualStyleBackColor = true;
            this.positionTopRight.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // positionTopCenter
            // 
            this.positionTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.positionTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionTopCenter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.positionTopCenter.Location = new System.Drawing.Point(90, 0);
            this.positionTopCenter.Margin = new System.Windows.Forms.Padding(0);
            this.positionTopCenter.Name = "positionTopCenter";
            this.positionTopCenter.Size = new System.Drawing.Size(90, 26);
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
            this.positionTopLeft.Size = new System.Drawing.Size(90, 26);
            this.positionTopLeft.TabIndex = 0;
            this.positionTopLeft.UseVisualStyleBackColor = true;
            this.positionTopLeft.CheckedChanged += new System.EventHandler(this.positionButton_CheckedChanged);
            // 
            // opacityGroup
            // 
            this.opacityGroup.Controls.Add(this.opacityLabel);
            this.opacityGroup.Controls.Add(this.opacitySlider);
            this.opacityGroup.Location = new System.Drawing.Point(12, 298);
            this.opacityGroup.Name = "opacityGroup";
            this.opacityGroup.Size = new System.Drawing.Size(276, 70);
            this.opacityGroup.TabIndex = 2;
            this.opacityGroup.TabStop = false;
            this.opacityGroup.Text = "Opacity";
            // 
            // opacityLabel
            // 
            this.opacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityLabel.Location = new System.Drawing.Point(191, 35);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(76, 15);
            this.opacityLabel.TabIndex = 1;
            this.opacityLabel.Text = "100%";
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.opacityLabel.Click += new System.EventHandler(this.opacityLabel_Click);
            // 
            // opacitySlider
            // 
            this.opacitySlider.LargeChange = 10;
            this.opacitySlider.Location = new System.Drawing.Point(6, 22);
            this.opacitySlider.Maximum = 100;
            this.opacitySlider.Minimum = 1;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(147, 45);
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
            this.borderGroup.Location = new System.Drawing.Point(297, 248);
            this.borderGroup.Name = "borderGroup";
            this.borderGroup.Size = new System.Drawing.Size(270, 70);
            this.borderGroup.TabIndex = 3;
            this.borderGroup.TabStop = false;
            this.borderGroup.Text = "Border thickness";
            // 
            // bdSizeLabel
            // 
            this.bdSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bdSizeLabel.Location = new System.Drawing.Point(185, 35);
            this.bdSizeLabel.Name = "bdSizeLabel";
            this.bdSizeLabel.Size = new System.Drawing.Size(76, 15);
            this.bdSizeLabel.TabIndex = 1;
            this.bdSizeLabel.Text = "4";
            this.bdSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bdSizeLabel.Click += new System.EventHandler(this.bdSizeLabel_Click);
            // 
            // bdSizeSlider
            // 
            this.bdSizeSlider.LargeChange = 10;
            this.bdSizeSlider.Location = new System.Drawing.Point(6, 22);
            this.bdSizeSlider.Maximum = 32;
            this.bdSizeSlider.Name = "bdSizeSlider";
            this.bdSizeSlider.Size = new System.Drawing.Size(147, 45);
            this.bdSizeSlider.TabIndex = 0;
            this.bdSizeSlider.TickFrequency = 4;
            this.bdSizeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.bdSizeSlider.Value = 32;
            this.bdSizeSlider.Scroll += new System.EventHandler(this.bdSizeSlider_Scroll);
            // 
            // downloadIcons
            // 
            this.downloadIcons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadIcons.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.downloadIcons.Location = new System.Drawing.Point(294, 321);
            this.downloadIcons.Name = "downloadIcons";
            this.downloadIcons.Size = new System.Drawing.Size(135, 44);
            this.downloadIcons.TabIndex = 12;
            this.downloadIcons.TabStop = true;
            this.downloadIcons.Text = "downloadIcons";
            this.downloadIcons.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.downloadIcons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel2_LinkClicked);
            // 
            // IndSettingsWindow
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(579, 380);
            this.Controls.Add(this.downloadIcons);
            this.Controls.Add(this.borderGroup);
            this.Controls.Add(this.opacityGroup);
            this.Controls.Add(this.positionGroup);
            this.Controls.Add(this.fontGroupBox);
            this.Controls.Add(this.coloursGroup);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.displayTimeGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndSettingsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification Settings";
            this.displayTimeGroup.ResumeLayout(false);
            this.displayTimeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayTimeSlider)).EndInit();
            this.coloursGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.borderColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourActivatedPreview)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox displayTimeGroup;
        private System.Windows.Forms.Label displayTimeLabel;
        private System.Windows.Forms.TrackBar displayTimeSlider;
        private System.Windows.Forms.Button saveButton;
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
        private System.Windows.Forms.CheckBox onlyShowWhenActiveCheckBox;
        private System.Windows.Forms.GroupBox borderGroup;
        private System.Windows.Forms.Label bdSizeLabel;
        private System.Windows.Forms.TrackBar bdSizeSlider;
        private LnkLabel downloadIcons;
    }
}
