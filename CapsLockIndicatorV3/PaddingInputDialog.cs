using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class PaddingInputDialog : DarkModeForm
    {
        private Color controlBackColor;

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0x0084) // WM_NCHITTEST
                message.Result = (IntPtr)1;
            else base.WndProc(ref message);
        }

        public Padding Value => new Padding(
            (int)numericUpDownLeft.Value,
            (int)numericUpDownTop.Value,
            (int)numericUpDownRight.Value,
            (int)numericUpDownBottom.Value
        );

        public PaddingInputDialog(Padding defaultValue)
        {
            InitializeComponent();
            numericUpDownLeft.Maximum =
            numericUpDownTop.Maximum =
            numericUpDownRight.Maximum =
            numericUpDownBottom.Maximum = int.MaxValue;

            numericUpDownLeft.Value = defaultValue.Left;
            numericUpDownTop.Value = defaultValue.Top;
            numericUpDownRight.Value = defaultValue.Right;
            numericUpDownBottom.Value = defaultValue.Bottom;

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += TextInputDialog_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };
        }

        private void TextInputDialog_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            ForeColor =
            numericUpDownLeft.ForeColor =
            numericUpDownTop.ForeColor =
            numericUpDownRight.ForeColor =
            numericUpDownBottom.ForeColor =
                dark ? Color.White : SystemColors.WindowText;


            numericUpDownLeft.BackColor =
            numericUpDownTop.BackColor =
            numericUpDownRight.BackColor =
            numericUpDownBottom.BackColor =
            controlBackColor =
                dark ? Color.FromArgb(255, 56, 56, 56) : SystemColors.Window;

            numericUpDownLeft.BorderStyle =
            numericUpDownTop.BorderStyle =
            numericUpDownRight.BorderStyle =
            numericUpDownBottom.BorderStyle =
                dark ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;

            ControlScheduleSetDarkMode(numericUpDownLeft, dark);
            ControlScheduleSetDarkMode(numericUpDownTop, dark);
            ControlScheduleSetDarkMode(numericUpDownRight, dark);
            ControlScheduleSetDarkMode(numericUpDownBottom, dark);
            ControlScheduleSetDarkMode(okButton, dark);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void centerControl_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder3D(e.Graphics, new Rectangle(Point.Empty, centerControl.Size));
            //ButtonRenderer.DrawButton(e.Graphics, new Rectangle(Point.Empty, centerControl.Size), )
            //ControlPaint.DrawButton(e.Graphics, new Rectangle(Point.Empty, centerControl.Size), ButtonState.Normal);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(Point.Empty, centerControl.Size), controlBackColor, ButtonBorderStyle.Outset);
        }
    }
}
