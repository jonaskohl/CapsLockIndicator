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
            this.panel1 = new System.Windows.Forms.Panel();
            this.downloadManuallyButton = new System.Windows.Forms.Button();
            this.changelogRtf = new CapsLockIndicatorV3.ViewOnlyRichTextBox();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.changelogRtf);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 186);
            this.panel1.TabIndex = 3;
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
            // changelogRtf
            // 
            this.changelogRtf.BackColor = System.Drawing.SystemColors.Window;
            this.changelogRtf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changelogRtf.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.changelogRtf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changelogRtf.Location = new System.Drawing.Point(0, 0);
            this.changelogRtf.Name = "changelogRtf";
            this.changelogRtf.ReadOnly = true;
            this.changelogRtf.Size = new System.Drawing.Size(423, 184);
            this.changelogRtf.TabIndex = 0;
            this.changelogRtf.TabStop = false;
            this.changelogRtf.Text = "";
            // 
            // UpdateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.dismissButton;
            this.ClientSize = new System.Drawing.Size(449, 243);
            this.Controls.Add(this.downloadManuallyButton);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button updateNowButton;
        private System.Windows.Forms.Button dismissButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button downloadManuallyButton;
        public ViewOnlyRichTextBox changelogRtf;
    }
}
