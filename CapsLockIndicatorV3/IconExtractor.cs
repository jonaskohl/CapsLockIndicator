using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public class IconExtractor
    {
        [DllImport("User32.dll")]
        private extern static int PrivateExtractIcons(string libraryName, int iconIndex, int iconWidth, int iconHeight, out IntPtr iconHandles, out IntPtr iconID, int numberIcons, IntPtr flags);

        public static Icon GetIcon(string libraryName, int iconIndex, int size)
        {
            PrivateExtractIcons(libraryName, iconIndex, size, size, out IntPtr iconHandle, out IntPtr iconID, 1, IntPtr.Zero);
            if (iconHandle != IntPtr.Zero)
                return Icon.FromHandle(iconHandle);
            return null;
        }
    }
}
