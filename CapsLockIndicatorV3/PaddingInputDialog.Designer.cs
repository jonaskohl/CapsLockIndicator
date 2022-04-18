namespace CapsLockIndicatorV3
{
    partial class PaddingInputDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownLeft = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBottom = new System.Windows.Forms.NumericUpDown();
            this.centerControl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(178, 66);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(83, 33);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(-53, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(39, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.TabStop = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.okButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownTop, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownBottom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.centerControl, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 102);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // numericUpDownLeft
            // 
            this.numericUpDownLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownLeft.Location = new System.Drawing.Point(0, 21);
            this.numericUpDownLeft.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownLeft.Name = "numericUpDownLeft";
            this.numericUpDownLeft.Size = new System.Drawing.Size(87, 23);
            this.numericUpDownLeft.TabIndex = 2;
            // 
            // numericUpDownTop
            // 
            this.numericUpDownTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownTop.Location = new System.Drawing.Point(87, 0);
            this.numericUpDownTop.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownTop.Name = "numericUpDownTop";
            this.numericUpDownTop.Size = new System.Drawing.Size(88, 23);
            this.numericUpDownTop.TabIndex = 3;
            // 
            // numericUpDownRight
            // 
            this.numericUpDownRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownRight.Location = new System.Drawing.Point(175, 21);
            this.numericUpDownRight.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownRight.Name = "numericUpDownRight";
            this.numericUpDownRight.Size = new System.Drawing.Size(89, 23);
            this.numericUpDownRight.TabIndex = 4;
            // 
            // numericUpDownBottom
            // 
            this.numericUpDownBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownBottom.Location = new System.Drawing.Point(87, 42);
            this.numericUpDownBottom.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownBottom.Name = "numericUpDownBottom";
            this.numericUpDownBottom.Size = new System.Drawing.Size(88, 23);
            this.numericUpDownBottom.TabIndex = 5;
            // 
            // centerControl
            // 
            this.centerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerControl.Location = new System.Drawing.Point(87, 21);
            this.centerControl.Margin = new System.Windows.Forms.Padding(0);
            this.centerControl.Name = "centerControl";
            this.centerControl.Size = new System.Drawing.Size(88, 21);
            this.centerControl.TabIndex = 6;
            this.centerControl.Paint += new System.Windows.Forms.PaintEventHandler(this.centerControl_Paint);
            // 
            // PaddingInputDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(264, 102);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaddingInputDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDownLeft;
        private System.Windows.Forms.NumericUpDown numericUpDownTop;
        private System.Windows.Forms.NumericUpDown numericUpDownRight;
        private System.Windows.Forms.NumericUpDown numericUpDownBottom;
        private System.Windows.Forms.Label centerControl;
    }
}