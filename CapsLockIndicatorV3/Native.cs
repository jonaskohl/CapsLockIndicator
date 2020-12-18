using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    internal static class Native
    {
        [DllImport("uxtheme.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll")]
        static extern bool SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("uxtheme.dll", EntryPoint = "#133")]
        public static extern bool AllowDarkModeForWindow(IntPtr hWnd, bool allow);

        [DllImport("uxtheme.dll", EntryPoint = "#135")]
        static extern int SetPreferredAppMode(int i);

        [DllImport("dwmapi.dll")]
        static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        const int PREFFERED_APP_MODE__ALLOW_DARK = 1;
        const int PREFFERED_APP_MODE__DEFAULT = 0;

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        [StructLayout(LayoutKind.Sequential)]
        struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        public static void ControlSetDarkMode(Control control, bool v)
        {
            SetWindowTheme(control.Handle, v ? "DarkMode_Explorer" : "Explorer", null);
            if (control is Button)
                ((Button)control).FlatStyle = FlatStyle.System;
        }

        enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19,
            WCA_USEDARKMODECOLORS = 26
        }

        internal static bool UseImmersiveDarkModeColors(IntPtr handle, bool dark)
        {
            var size = Marshal.SizeOf(typeof(int));
            IntPtr pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteInt32(pBool, 0, dark ? 1 : 0);
            var data = new WindowCompositionAttributeData()
            {
                Attribute = WindowCompositionAttribute.WCA_USEDARKMODECOLORS,
                Data = pBool,
                SizeOfData = size
            };
            var res = SetWindowCompositionAttribute(handle, ref data);

            Marshal.FreeHGlobal(pBool);

            return res;
        }

        public static void SetPrefferDarkMode(bool dark)
        {
            SetPreferredAppMode(dark ? PREFFERED_APP_MODE__ALLOW_DARK : PREFFERED_APP_MODE__DEFAULT);
        }

        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {

                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        public static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        public static float GetScalingFactor()
        {
            float ScreenScalingFactor;

            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var desktop = g.GetHdc();
                var LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
                var PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

                ScreenScalingFactor = PhysicalScreenHeight / (float)LogicalScreenHeight;
            }

            return ScreenScalingFactor;
        }
    }
}
