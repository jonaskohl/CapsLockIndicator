/**
 * Loosely based on https://sourceforge.net/projects/alpha-color-dialog/
 * by Opulos Inc.
 * Licensed under BSD license
 * 
 * Copyright 2015 Opulos Inc.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public class MFontPicker : System.Windows.Forms.FontDialog
    {
#if EXPERIMENTAL__USE_DARK_COMMON_DIALOGS
#region P/Invoke
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("gdi32.dll")]
        static extern uint SetBkColor(IntPtr hdc, int crColor);

        [DllImport("gdi32.dll")]
        static extern int SetBkMode(IntPtr hdc, int iBkMode);

        [DllImport("user32.dll")]
        static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private const int ACD_COLORCHANGED = 0x0400;
        private const int SRC = 0xCC0020;

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;

        private const int WM_CREATE = 0x0001;
        private const int WM_PAINT = 0x000F;
        private const int WM_ERASEBKGND = 0x0014;
        private const int WM_INITDIALOG = 0x110;
        private const int WM_SETFONT = 0x0030;
        private const int WM_GETFONT = 0x0031;
        private const int WM_SHOWWINDOW = 0x18;
        private const int GWL_STYLE = -16;
        private const int WM_COMMAND = 0x111;
        private const int WM_CHAR = 0x102;
        private const int WM_LBUTTONDOWN = 0x201;

        private const int TRANSPARENT = 1;
        private const int OPAQUE = 2;

        private const int WS_VISIBLE = 0x10000000;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x02000000;
        private const int WS_TABSTOP = 0x00010000;

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] rgbReserved;
        }
#endregion

        private IntPtr handle = IntPtr.Zero;
        private IntPtr hWndOkButon = IntPtr.Zero;
        private IntPtr hWndCancelButon = IntPtr.Zero;
        private IntPtr hWndEffectsGroup = IntPtr.Zero;
        private IntPtr hWndEffectsStrike = IntPtr.Zero;
        private IntPtr hWndEffectsUnder = IntPtr.Zero;
        private IntPtr hWndSampleGroup = IntPtr.Zero;
        private IntPtr hWndFontLabel = IntPtr.Zero;
        private IntPtr hWndWeightLabel = IntPtr.Zero;
        private IntPtr hWndSizeLabel = IntPtr.Zero;
        private IntPtr hWndUnknown = IntPtr.Zero;
        private IntPtr hWndScriptLabel = IntPtr.Zero;
        private IntPtr hWndFontComboBox = IntPtr.Zero;
        private IntPtr hWndWeightComboBox = IntPtr.Zero;
        private IntPtr hWndSizeComboBox = IntPtr.Zero;
        private IntPtr hWndScriptComboBox = IntPtr.Zero;

        protected override IntPtr OwnerWndProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            return base.OwnerWndProc(hWnd, msg, wparam, lparam);
        }

        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            if (msg == WM_INITDIALOG)
            {
                var prevStyle = GetWindowLong(hWnd, GWL_STYLE);
                SetWindowLong(hWnd, GWL_STYLE, prevStyle | WS_CLIPCHILDREN);

                hWndOkButon = GetDlgItem(hWnd, 0x0001);
                hWndCancelButon = GetDlgItem(hWnd, 0x0002);
                hWndEffectsGroup = GetDlgItem(hWnd, 0x0430);
                hWndEffectsStrike = GetDlgItem(hWnd, 0x0410);
                hWndEffectsUnder = GetDlgItem(hWnd, 0x0411);
                hWndSampleGroup = GetDlgItem(hWnd, 0x0431);
                hWndFontLabel = GetDlgItem(hWnd, 0x0440);
                hWndWeightLabel = GetDlgItem(hWnd, 0x0441);
                hWndSizeLabel = GetDlgItem(hWnd, 0x0442);
                hWndUnknown = GetDlgItem(hWnd, 0x0445);
                hWndScriptLabel = GetDlgItem(hWnd, 0x0446);
                hWndFontComboBox = GetDlgItem(hWnd, 0x0470);
                hWndWeightComboBox = GetDlgItem(hWnd, 0x0471);
                hWndSizeComboBox = GetDlgItem(hWnd, 0x0472);
                hWndScriptComboBox = GetDlgItem(hWnd, 0x0474);

                DarkMode();
            }
            else if (msg == WM_SHOWWINDOW)
            {
                //center the dialog on the parent window:
                RECT cr = new RECT();
                RECT r0 = new RECT();
                IntPtr parent = GetParent(hWnd);
                GetWindowRect(hWnd, ref r0);
                GetWindowRect(parent, ref cr);
                handle = hWnd;

                PrepareDarkMode(handle);

                int x = cr.Left + ((cr.Right - cr.Left) - (r0.Right - r0.Left)) / 2;
                int y = cr.Top + ((cr.Bottom - cr.Top) - (r0.Bottom - r0.Top)) / 2;
                SetWindowPos(hWnd, IntPtr.Zero, x, y, 0, 0, SWP_NOZORDER | SWP_NOSIZE);
            }
            else if (msg == WM_ERASEBKGND)
            {
                using (var g = Graphics.FromHwnd(handle))
                    g.Clear(Color.FromArgb(255, 32, 32, 32));
            }
            else if (msg == WM_PAINT)
            { }

            return base.HookProc(hWnd, msg, wparam, lparam);
        }

        private void PrepareDarkMode(IntPtr hWnd)
        {
            Native.UseImmersiveDarkModeColors(hWnd, true);
        }

        private void DarkMode()
        {
            Native.SetDarkMode(hWndOkButon, true);
            Native.SetDarkMode(hWndCancelButon, true);
            Native.SetDarkMode(hWndEffectsGroup, true);
            Native.SetDarkMode(hWndEffectsStrike, true);
            Native.SetDarkMode(hWndEffectsUnder, true);
            Native.SetDarkMode(hWndSampleGroup, true);
            Native.SetDarkMode(hWndFontLabel, true);
            Native.SetDarkMode(hWndWeightLabel, true);
            Native.SetDarkMode(hWndSizeLabel, true);
            Native.SetDarkMode(hWndUnknown, true);
            Native.SetDarkMode(hWndScriptLabel, true);
            Native.SetDarkMode(hWndFontComboBox, true);
            Native.SetDarkMode(hWndWeightComboBox, true);
            Native.SetDarkMode(hWndSizeComboBox, true);
            Native.SetDarkMode(hWndScriptComboBox, true);
        }
#endif
    }
}
