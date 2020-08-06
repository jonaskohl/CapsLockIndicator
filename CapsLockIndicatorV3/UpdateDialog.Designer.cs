namespace CapsLockIndicatorV3
{
    partial class UpdateDialog
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
            this.updateNowButton = new System.Windows.Forms.Button();
            this.dismissButton = new System.Windows.Forms.Button();
            this.borderPanel = new System.Windows.Forms.Panel();
            this.changelogRtf = new CapsLockIndicatorV3.ViewOnlyRichTextBox();
            this.downloadManuallyButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.lnkLabel1 = new CapsLockIndicatorV3.LnkLabel();
            this.borderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateNowButton
            // 
            this.updateNowButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.updateNowButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updateNowButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.updateNowButton.Location = new System.Drawing.Point(102, 204);
            this.updateNowButton.Name = "updateNowButton";
            this.updateNowButton.Size = new System.Drawing.Size(87, 27);
            this.updateNowButton.TabIndex = 1;
            this.updateNowButton.Text = "&Update now";
            this.updateNowButton.UseVisualStyleBackColor = true;
            // 
            // dismissButton
            // 
            this.dismissButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dismissButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.dismissButton.Location = new System.Drawing.Point(195, 204);
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.Size = new System.Drawing.Size(87, 27);
            this.dismissButton.TabIndex = 2;
            this.dismissButton.Text = "&Dismiss";
            this.dismissButton.UseVisualStyleBackColor = true;
            // 
            // borderPanel
            // 
            this.borderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderPanel.Controls.Add(this.changelogRtf);
            this.borderPanel.Location = new System.Drawing.Point(12, 27);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(425, 171);
            this.borderPanel.TabIndex = 3;
            // 
            // changelogRtf
            // 
            this.changelogRtf.BackColor = System.Drawing.SystemColors.Window;
            this.changelogRtf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changelogRtf.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.changelogRtf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changelogRtf.Location = new System.Drawing.Point(0, 0);
            this.changelogRtf.Name = "changelogRtf";
            this.changelogRtf.ReadOnly = true;
            this.changelogRtf.Size = new System.Drawing.Size(423, 169);
            this.changelogRtf.TabIndex = 0;
            this.changelogRtf.TabStop = false;
            this.changelogRtf.Text = "";
            // 
            // downloadManuallyButton
            // 
            this.downloadManuallyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.downloadManuallyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.downloadManuallyButton.Location = new System.Drawing.Point(288, 204);
            this.downloadManuallyButton.Name = "downloadManuallyButton";
            this.downloadManuallyButton.Size = new System.Drawing.Size(148, 27);
            this.downloadManuallyButton.TabIndex = 4;
            this.downloadManuallyButton.Text = "Download &manually";
            this.downloadManuallyButton.UseVisualStyleBackColor = true;
            this.downloadManuallyButton.Click += new System.EventHandler(this.downloadManuallyButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.infoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(27, 15);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "null";
            // 
            // lnkLabel1
            // 
            this.lnkLabel1.AutoSize = true;
            this.lnkLabel1.LinkArea = new System.Windows.Forms.LinkArea(41, 10);
            this.lnkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(77)))), ((int)(((byte)(180)))));
            this.lnkLabel1.Location = new System.Drawing.Point(12, 210);
            this.lnkLabel1.Name = "lnkLabel1";
            this.lnkLabel1.Size = new System.Drawing.Size(286, 21);
            this.lnkLabel1.TabIndex = 6;
            this.lnkLabel1.TabStop = true;
            this.lnkLabel1.Text = "You cannot update to the latest version. Learn more";
            this.lnkLabel1.UseCompatibleTextRendering = true;
            this.lnkLabel1.Visible = false;
            this.lnkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel1_LinkClicked);
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.dismissButton;
            this.ClientSize = new System.Drawing.Size(449, 243);
            this.Controls.Add(this.lnkLabel1);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.downloadManuallyButton);
            this.Controls.Add(this.borderPanel);
            this.Controls.Add(this.dismissButton);
            this.Controls.Add(this.updateNowButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CapsLock Indicator Update available!";
            this.borderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button updateNowButton;
        private System.Windows.Forms.Button dismissButton;
        private System.Windows.Forms.Panel borderPanel;
        private System.Windows.Forms.Button downloadManuallyButton;
        public ViewOnlyRichTextBox changelogRtf;
        public System.Windows.Forms.Label infoLabel;
        private LnkLabel lnkLabel1;
    }
}
