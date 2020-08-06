using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class ViewOnlyRichTextBox : RichTextBox
    {
        // constants for the message sending
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;
        const int WM_SETCURSOR = 0x0020;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS) m.Msg = WM_KILLFOCUS;
            if (m.Msg == WM_SETCURSOR) return;

            base.WndProc(ref m);
        }
    }
}
