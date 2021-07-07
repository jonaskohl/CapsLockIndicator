
namespace CapsLockIndicatorV3
{
    partial class FirstRunDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstRunDialog));
            this.headerLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lnkLabel2 = new CapsLockIndicatorV3.LnkLabel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.allowUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.lnkLabel1 = new CapsLockIndicatorV3.LnkLabel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.exitButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.themeLabel = new System.Windows.Forms.Label();
            this.lightButton = new System.Windows.Forms.Button();
            this.darkButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.headerLabel, 2);
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(227, 21);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Welcome to CapsLock Indicator";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lnkLabel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.headerLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.messageLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.themeLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lightButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.darkButton, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 319);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lnkLabel2
            // 
            this.lnkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lnkLabel2.AutoSize = true;
            this.lnkLabel2.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkLabel2.Location = new System.Drawing.Point(0, 297);
            this.lnkLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.lnkLabel2.Name = "lnkLabel2";
            this.lnkLabel2.Size = new System.Drawing.Size(64, 15);
            this.lnkLabel2.TabIndex = 4;
            this.lnkLabel2.TabStop = true;
            this.lnkLabel2.Text = "Contribute";
            this.lnkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel2_LinkClicked);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.messageLabel, 2);
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageLabel.Location = new System.Drawing.Point(0, 30);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(331, 75);
            this.messageLabel.TabIndex = 1;
            this.messageLabel.Text = resources.GetString("messageLabel.Text");
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.allowUpdatesCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.lnkLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 182);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 108);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // allowUpdatesCheckBox
            // 
            this.allowUpdatesCheckBox.Checked = true;
            this.allowUpdatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowUpdatesCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.allowUpdatesCheckBox.Location = new System.Drawing.Point(0, 0);
            this.allowUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.allowUpdatesCheckBox.Name = "allowUpdatesCheckBox";
            this.allowUpdatesCheckBox.Size = new System.Drawing.Size(312, 38);
            this.allowUpdatesCheckBox.TabIndex = 0;
            this.allowUpdatesCheckBox.Text = "Allow CapsLock Indicator to periodically check for updates online (can be changed" +
    " later)";
            this.allowUpdatesCheckBox.UseCompatibleTextRendering = true;
            this.allowUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.allowUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.allowUpdatesCheckBox_CheckedChanged);
            // 
            // lnkLabel1
            // 
            this.lnkLabel1.AutoSize = true;
            this.lnkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkLabel1.Location = new System.Drawing.Point(13, 38);
            this.lnkLabel1.Margin = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lnkLabel1.Name = "lnkLabel1";
            this.lnkLabel1.Size = new System.Drawing.Size(168, 15);
            this.lnkLabel1.TabIndex = 1;
            this.lnkLabel1.TabStop = true;
            this.lnkLabel1.Text = "What information will be sent?";
            this.lnkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLabel1_LinkClicked);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.exitButton);
            this.flowLayoutPanel2.Controls.Add(this.okButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(172, 290);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(159, 29);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exitButton.Location = new System.Drawing.Point(3, 3);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "&Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.okButton.Location = new System.Drawing.Point(81, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&Let\'s go!";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // themeLabel
            // 
            this.themeLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.themeLabel, 2);
            this.themeLabel.Location = new System.Drawing.Point(0, 113);
            this.themeLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(194, 15);
            this.themeLabel.TabIndex = 5;
            this.themeLabel.Text = "Which color scheme do you prefer?";
            // 
            // lightButton
            // 
            this.lightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lightButton.Location = new System.Drawing.Point(3, 131);
            this.lightButton.Name = "lightButton";
            this.lightButton.Size = new System.Drawing.Size(159, 42);
            this.lightButton.TabIndex = 6;
            this.lightButton.Text = "Light";
            this.lightButton.UseVisualStyleBackColor = true;
            this.lightButton.Click += new System.EventHandler(this.lightButton_Click);
            // 
            // darkButton
            // 
            this.darkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.darkButton.Location = new System.Drawing.Point(168, 131);
            this.darkButton.Name = "darkButton";
            this.darkButton.Size = new System.Drawing.Size(160, 42);
            this.darkButton.TabIndex = 7;
            this.darkButton.Text = "Dark";
            this.darkButton.UseVisualStyleBackColor = true;
            this.darkButton.Click += new System.EventHandler(this.darkButton_Click);
            // 
            // FirstRunDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(349, 337);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstRunDialog";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CapsLock Indicator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox allowUpdatesCheckBox;
        private LnkLabel lnkLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button exitButton;
        private LnkLabel lnkLabel2;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Button lightButton;
        private System.Windows.Forms.Button darkButton;
    }
}