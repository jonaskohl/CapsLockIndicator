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
            this.cancelButton = new System.Windows.Forms.Button();
            this.coloursGroup = new System.Windows.Forms.GroupBox();
            this.backgroundColourButton = new System.Windows.Forms.Button();
            this.backgroundColourPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourPreview = new System.Windows.Forms.PictureBox();
            this.foregroundColourButton = new System.Windows.Forms.Button();
            this.borderColourPreview = new System.Windows.Forms.PictureBox();
            this.borderColourButton = new System.Windows.Forms.Button();
            this.mainColourPicker = new System.Windows.Forms.ColorDialog();
            this.displayTimeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayTimeSlider)).BeginInit();
            this.coloursGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTimeGroup
            // 
            this.displayTimeGroup.Controls.Add(this.displayTimeLabel);
            this.displayTimeGroup.Controls.Add(this.displayTimeSlider);
            this.displayTimeGroup.Location = new System.Drawing.Point(12, 12);
            this.displayTimeGroup.Name = "displayTimeGroup";
            this.displayTimeGroup.Size = new System.Drawing.Size(217, 70);
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
            this.saveButton.Location = new System.Drawing.Point(141, 214);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 24);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "&Save && close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSize = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(78, 214);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(57, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // coloursGroup
            // 
            this.coloursGroup.Controls.Add(this.borderColourPreview);
            this.coloursGroup.Controls.Add(this.borderColourButton);
            this.coloursGroup.Controls.Add(this.foregroundColourPreview);
            this.coloursGroup.Controls.Add(this.foregroundColourButton);
            this.coloursGroup.Controls.Add(this.backgroundColourPreview);
            this.coloursGroup.Controls.Add(this.backgroundColourButton);
            this.coloursGroup.Location = new System.Drawing.Point(12, 88);
            this.coloursGroup.Name = "coloursGroup";
            this.coloursGroup.Size = new System.Drawing.Size(217, 117);
            this.coloursGroup.TabIndex = 3;
            this.coloursGroup.TabStop = false;
            this.coloursGroup.Text = "Colours";
            // 
            // backgroundColourButton
            // 
            this.backgroundColourButton.AutoSize = true;
            this.backgroundColourButton.Location = new System.Drawing.Point(53, 22);
            this.backgroundColourButton.Name = "backgroundColourButton";
            this.backgroundColourButton.Size = new System.Drawing.Size(158, 25);
            this.backgroundColourButton.TabIndex = 0;
            this.backgroundColourButton.Text = "Background colour";
            this.backgroundColourButton.UseVisualStyleBackColor = true;
            this.backgroundColourButton.Click += new System.EventHandler(this.backgroundColourButton_Click);
            // 
            // backgroundColourPreview
            // 
            this.backgroundColourPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.backgroundColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundColourPreview.Location = new System.Drawing.Point(6, 22);
            this.backgroundColourPreview.Name = "backgroundColourPreview";
            this.backgroundColourPreview.Size = new System.Drawing.Size(41, 25);
            this.backgroundColourPreview.TabIndex = 1;
            this.backgroundColourPreview.TabStop = false;
            // 
            // foregroundColourPreview
            // 
            this.foregroundColourPreview.BackColor = System.Drawing.Color.White;
            this.foregroundColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foregroundColourPreview.Location = new System.Drawing.Point(6, 53);
            this.foregroundColourPreview.Name = "foregroundColourPreview";
            this.foregroundColourPreview.Size = new System.Drawing.Size(41, 25);
            this.foregroundColourPreview.TabIndex = 3;
            this.foregroundColourPreview.TabStop = false;
            // 
            // foregroundColourButton
            // 
            this.foregroundColourButton.AutoSize = true;
            this.foregroundColourButton.Location = new System.Drawing.Point(53, 53);
            this.foregroundColourButton.Name = "foregroundColourButton";
            this.foregroundColourButton.Size = new System.Drawing.Size(158, 25);
            this.foregroundColourButton.TabIndex = 2;
            this.foregroundColourButton.Text = "Text colour";
            this.foregroundColourButton.UseVisualStyleBackColor = true;
            this.foregroundColourButton.Click += new System.EventHandler(this.foregroundColourButton_Click);
            // 
            // borderColourPreview
            // 
            this.borderColourPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.borderColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColourPreview.Location = new System.Drawing.Point(6, 84);
            this.borderColourPreview.Name = "borderColourPreview";
            this.borderColourPreview.Size = new System.Drawing.Size(41, 25);
            this.borderColourPreview.TabIndex = 5;
            this.borderColourPreview.TabStop = false;
            // 
            // borderColourButton
            // 
            this.borderColourButton.AutoSize = true;
            this.borderColourButton.Location = new System.Drawing.Point(53, 84);
            this.borderColourButton.Name = "borderColourButton";
            this.borderColourButton.Size = new System.Drawing.Size(158, 25);
            this.borderColourButton.TabIndex = 4;
            this.borderColourButton.Text = "Border colour";
            this.borderColourButton.UseVisualStyleBackColor = true;
            this.borderColourButton.Click += new System.EventHandler(this.borderColourButton_Click);
            // 
            // IndSettingsWindow
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(241, 250);
            this.Controls.Add(this.coloursGroup);
            this.Controls.Add(this.cancelButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColourPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox displayTimeGroup;
        private System.Windows.Forms.Label displayTimeLabel;
        private System.Windows.Forms.TrackBar displayTimeSlider;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox coloursGroup;
        private System.Windows.Forms.Button backgroundColourButton;
        private System.Windows.Forms.PictureBox backgroundColourPreview;
        private System.Windows.Forms.PictureBox borderColourPreview;
        private System.Windows.Forms.Button borderColourButton;
        private System.Windows.Forms.PictureBox foregroundColourPreview;
        private System.Windows.Forms.Button foregroundColourButton;
        private System.Windows.Forms.ColorDialog mainColourPicker;
    }
}