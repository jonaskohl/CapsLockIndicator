using CapsLockIndicatorV3;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace System.Windows.Forms
{
    public class DarkModeListView : ListView
    {
        private IntPtr headerPtr;
        private bool _headerPtr = false;
        public IntPtr HeaderHandle
        {
            get
            {
                if (!_headerPtr)
                    headerPtr = Native.SendMessage(Handle, Native.LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
                _headerPtr = true;
                return headerPtr;
            }
        }

        private Color headerBackColor;
        private Color headerTextColor;

        public DarkModeListView() : base()
        {
            DoubleBuffered = true;

            OwnerDraw = true;
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            var t = e.GetType();
            t.GetField("backColor", BindingFlags.NonPublic).SetValue(e, headerBackColor);
            t.GetField("foreColor", BindingFlags.NonPublic).SetValue(e, headerTextColor);
            //e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }

        public void SetDark(bool dark)
        {
            Native.AllowDarkModeForWindow(Handle, dark);
            Native.AllowDarkModeForWindow(HeaderHandle, dark);

            var theme = Native.OpenThemeData(IntPtr.Zero, "ItemsView");
            if (theme != IntPtr.Zero)
            {
                Native.COLORREF color;
                if (Native.GetThemeColor(theme, 0, 0, Native.TMT_TEXTCOLOR, out color) >= 0)
                    ForeColor = color.ToColor();
                if (Native.GetThemeColor(theme, 0, 0, Native.TMT_FILLCOLOR, out color) >= 0)
                    BackColor = color.ToColor();

                Native.CloseThemeData(theme);
            } else
            {
                Debug.Assert(false, "Theme is nullptr");
            }
            
            theme = Native.OpenThemeData(HeaderHandle, "Header");
            if (theme != IntPtr.Zero)
            {
                Native.COLORREF color;
                if (Native.GetThemeColor(theme, Native.HP_HEADERITEM, 0, Native.TMT_TEXTCOLOR, out color) >= 0)
                    headerTextColor = color.ToColor();

                if (Native.GetThemeColor(theme, Native.HP_HEADERITEM, 0, Native.TMT_FILLCOLOR, out color) >= 0)
                    headerBackColor = color.ToColor();

                Native.CloseThemeData(theme);
            }

            Invalidate();
        }
    }
}
