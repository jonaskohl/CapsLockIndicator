using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public static class SysIcons
    {
        const int MAX_PATH = 0x100;

        public static int LAST_ERROR { get; private set; }
        public static int LAST_WIN32_ERROR { get; private set; }

        [DllImport("Shell32.dll", SetLastError = true)]
        static extern int SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        public enum SHSTOCKICONID : uint
        {
            SIID_WARNING = 78,
            SIID_ERROR = 80,
            SIID_SHIELD = 131,
        }

        [Flags]
        private enum SHGSI : uint
        {
            SHGSI_ICON = 0x000000100,
            SHGSI_LARGEICON = 0x000000000,
            SHGSI_SMALLICON = 0x000000001
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public long iSysIconIndex;
            public long iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szPath;
        }

        public static Icon GetSystemIcon(SHSTOCKICONID icon, IconSize size = IconSize.Unspecified)
        {
            var info = new SHSTOCKICONINFO();
            info.cbSize = (uint)unchecked(Marshal.SizeOf(info));
            var flags = SHGSI.SHGSI_ICON;
            if (size == IconSize.Small)
                flags |= SHGSI.SHGSI_SMALLICON;
            else if (size == IconSize.Large)
                flags |= SHGSI.SHGSI_LARGEICON;

            var r = SHGetStockIconInfo(icon, flags, ref info);
            LAST_ERROR = r;
            if (r != 0)
            {
                LAST_WIN32_ERROR = Marshal.GetLastWin32Error();
                return null;
            }

            return Icon.FromHandle(info.hIcon);
        }

        public enum IconSize
        {
            Unspecified,
            Small,
            Large
        }
    }
}
