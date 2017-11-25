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
            this.mainColourPicker = new System.Windows.Forms.ColorDialog();
            this.fontGroupBox = new System.Windows.Forms.GroupBox();
            this.fontButton = new System.Windows.Forms.Button();
            this.indFontChooser = new System.Windows.Forms.FontDialog();
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
            this.SuspendLayout();
            // 
            // displayTimeGroup
            // 
            this.displayTimeGroup.Controls.Add(this.displayTimeLabel);
            this.displayTimeGroup.Controls.Add(this.displayTimeSlider);
            this.displayTimeGroup.Location = new System.Drawing.Point(12, 12);
            this.displayTimeGroup.Name = "displayTimeGroup";
            this.displayTimeGroup.Size = new System.Drawing.Size(244, 70);
            this.displayTimeGroup.TabIndex = 0;
            this.displayTimeGroup.TabStop = false;
            this.displayTimeGroup.Text = "Display time";
            // 
            // displayTimeLabel
            // 
            this.displayTimeLabel.Location = new System.Drawing.Point(159, 35);
            this.displayTimeLabel.Name = "displayTimeLabel";
            this.displayTimeLabel.Size = new System.Drawing.Size(50, 15);
            this.displayTimeLabel.TabIndex = 1;
            this.displayTimeLabel.Text = "500 ms";
            this.displayTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.displayTimeLabel.Click += new System.EventHandler(this.displayTimeLabel_Click);
            // 
            // displayTimeSlider
            // 
            this.displayTimeSlider.LargeChange = 50;
            this.displayTimeSlider.Location = new System.Drawing.Point(6, 22);
            this.displayTimeSlider.Maximum = 2000;
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
            this.saveButton.Location = new System.Drawing.Point(168, 400);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 24);
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
            this.coloursGroup.Location = new System.Drawing.Point(12, 164);
            this.coloursGroup.Name = "coloursGroup";
            this.coloursGroup.Size = new System.Drawing.Size(244, 230);
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
            this.borderColourDeactivatedButton.AutoSize = true;
            this.borderColourDeactivatedButton.Location = new System.Drawing.Point(53, 177);
            this.borderColourDeactivatedButton.Name = "borderColourDeactivatedButton";
            this.borderColourDeactivatedButton.Size = new System.Drawing.Size(182, 25);
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
            this.foregroundColourDeactivatedButton.AutoSize = true;
            this.foregroundColourDeactivatedButton.Location = new System.Drawing.Point(53, 115);
            this.foregroundColourDeactivatedButton.Name = "foregroundColourDeactivatedButton";
            this.foregroundColourDeactivatedButton.Size = new System.Drawing.Size(182, 25);
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
            this.backgroundColourDeactivatedButton.AutoSize = true;
            this.backgroundColourDeactivatedButton.Location = new System.Drawing.Point(53, 53);
            this.backgroundColourDeactivatedButton.Name = "backgroundColourDeactivatedButton";
            this.backgroundColourDeactivatedButton.Size = new System.Drawing.Size(182, 25);
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
            this.borderColourActivatedButton.AutoSize = true;
            this.borderColourActivatedButton.Location = new System.Drawing.Point(53, 146);
            this.borderColourActivatedButton.Name = "borderColourActivatedButton";
            this.borderColourActivatedButton.Size = new System.Drawing.Size(182, 25);
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
            this.foregroundColourActivatedButton.AutoSize = true;
            this.foregroundColourActivatedButton.Location = new System.Drawing.Point(53, 84);
            this.foregroundColourActivatedButton.Name = "foregroundColourActivatedButton";
            this.foregroundColourActivatedButton.Size = new System.Drawing.Size(182, 25);
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
            this.backgroundColourActivatedButton.AutoSize = true;
            this.backgroundColourActivatedButton.Location = new System.Drawing.Point(53, 22);
            this.backgroundColourActivatedButton.Name = "backgroundColourActivatedButton";
            this.backgroundColourActivatedButton.Size = new System.Drawing.Size(182, 25);
            this.backgroundColourActivatedButton.TabIndex = 3;
            this.backgroundColourActivatedButton.Text = "Background colour activated";
            this.backgroundColourActivatedButton.UseVisualStyleBackColor = true;
            this.backgroundColourActivatedButton.Click += new System.EventHandler(this.backgroundColourActivatedButton_Click);
            // 
            // fontGroupBox
            // 
            this.fontGroupBox.Controls.Add(this.fontButton);
            this.fontGroupBox.Location = new System.Drawing.Point(12, 88);
            this.fontGroupBox.Name = "fontGroupBox";
            this.fontGroupBox.Size = new System.Drawing.Size(244, 70);
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
            // IndSettingsWindow
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(268, 436);
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
            this.coloursGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourDeactivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourActivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourActivatedPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourActivatedPreview)).EndInit();
            this.fontGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.ColorDialog mainColourPicker;
        private System.Windows.Forms.PictureBox backgroundColourDeactivatedPreview;
        private System.Windows.Forms.Button backgroundColourDeactivatedButton;
        private System.Windows.Forms.GroupBox fontGroupBox;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.PictureBox foregroundColourDeactivatedPreview;
        private System.Windows.Forms.Button foregroundColourDeactivatedButton;
        private System.Windows.Forms.PictureBox borderColourDeactivatedPreview;
        private System.Windows.Forms.Button borderColourDeactivatedButton;
        private System.Windows.Forms.FontDialog indFontChooser;
    }
}
