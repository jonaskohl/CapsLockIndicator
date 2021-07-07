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
    public partial class TextInputDialog : DarkModeForm
    {
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0x0084) // WM_NCHITTEST
                message.Result = (IntPtr)1;
            else base.WndProc(ref message);
        }

        public string Value => inputTextBox.Text;

        public TextInputDialog(string defaultValue)
        {
            InitializeComponent();
            inputTextBox.Text = defaultValue;

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
            inputTextBox.ForeColor = dark ? Color.White : SystemColors.WindowText;

            inputTextBox.BackColor = dark ? Color.FromArgb(255, 56, 56, 56) : SystemColors.Window;
            inputTextBox.BorderStyle = dark ? BorderStyle.FixedSingle : BorderStyle.Fixed3D;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;

            ControlScheduleSetDarkMode(inputTextBox, dark);
            ControlScheduleSetDarkMode(okButton, dark);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextInputDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
