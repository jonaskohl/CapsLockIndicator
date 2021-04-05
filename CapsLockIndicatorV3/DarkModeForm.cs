using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class DarkModeForm : Form
    {
        public event EventHandler DarkModeChanged;

        internal void OnDarkModeChanged()
        {
            DarkModeChanged?.Invoke(this, EventArgs.Empty);
        }

        protected void ControlScheduleSetDarkMode(Control control, bool isDark)
        {
            if (control.IsHandleCreated)
                Native.ControlSetDarkMode(control, isDark);
            else
                control.HandleCreated += (sender, e) =>
                {
                    Native.ControlSetDarkMode(control, isDark);
                };
        }
    }
}
