﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class NumberInputDialog : DarkModeForm
    {
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0x0084) // WM_NCHITTEST
                message.Result = (IntPtr)1;
            else base.WndProc(ref message);
        }

        int min;
        int max;

        public int Value;

        public NumberInputDialog(int defaultValue, int minValue, int maxValue)
        {
            InitializeComponent();
            min = minValue;
            max = maxValue;
            inputTextBox.Text = defaultValue.ToString();

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += NumberInputDialog_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };
        }

        private void NumberInputDialog_DarkModeChanged(object sender, EventArgs e)
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
            int res;
            if (int.TryParse(inputTextBox.Text, out res))
            {
                if (res >= min && res <= max)
                {
                    Value = res;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(string.Format("Please enter a number with the range [{0}; {1}]!", min, max));
                }
            }
            else
            {
                MessageBox.Show("Please enter a number!");
            }
        }

        private void NumberInputDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
