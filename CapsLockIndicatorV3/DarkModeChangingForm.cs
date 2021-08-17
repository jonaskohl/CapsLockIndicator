using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class DarkModeChangingForm : Form
    {
        public DarkModeChangingForm()
        {
            InitializeComponent();
        }

        public static DarkModeChangingForm Show(IWin32Window owner, bool dark)
        {
            var f = new DarkModeChangingForm();

            f.BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            f.ForeColor = dark ? Color.White : SystemColors.WindowText;

            f.label1.Text = strings.adjustingColorScheme;

            f.Show(owner);

            return f;
        }
    }
}
