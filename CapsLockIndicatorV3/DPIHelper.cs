using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    internal static class DPIHelper
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private enum DeviceCap
        {
            VERTRES = 10,
            LOGPIXELSY = 90,
            DESKTOPVERTRES = 117
        }

        internal static decimal GetScalingFactorPercent()
        {
            var g = Graphics.FromHwnd(IntPtr.Zero);
            try
            {
                var desktop = g.GetHdc();
                var LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
                var PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
                var logpixelsy = GetDeviceCaps(desktop, (int)DeviceCap.LOGPIXELSY);
                var screenScalingFactor = PhysicalScreenHeight / (decimal)LogicalScreenHeight;
                var dpiScalingFactor = logpixelsy / 96.0M;

                return dpiScalingFactor;
            }
            finally
            {
                g?.ReleaseHdc();
            }
        }
    }
}
