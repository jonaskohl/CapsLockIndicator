/*
 * Created 09.07.2017 18:25
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */

using System.Globalization;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;


namespace CapsLockIndicatorV3
{


    /// <summary>
    /// A helper class for accessing the state of Caps/Num/Scroll lock
    /// </summary>
    public static class KeyHelper
    {
        
        const int WM_IME_CONTROL = 0x283;
        const int IMC_GETCONVERSIONMODE = 1;
        const int IMC_SETCONVERSIONMODE = 2;
        const int IMC_GETOPENSTATUS = 5;
        const int IMC_SETOPENSTATUS = 6;

        const int IME_CMODE_NATIVE = 1;
        const int IME_CMODE_KATAKANA = 2;
        const int IME_CMODE_FULLSHAPE = 8;
        const int IME_CMODE_ROMAN = 16;

        const int CMode_HankakuKana = IME_CMODE_ROMAN | IME_CMODE_KATAKANA | IME_CMODE_NATIVE;
        const int CMode_ZenkakuEisu = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE;
        const int CMode_Hiragana = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE | IME_CMODE_NATIVE;
        const int CMode_ZenkakuKana = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE | IME_CMODE_KATAKANA | IME_CMODE_NATIVE;
        // 実験してみた結果
        // 19 :カ 半角カナ                     0001 0011
        // 24 :Ａ 全角英数                     0001 1000
        // 25 :あ ひらがな（漢字変換モード）   0001 1001
        // 27 :   全角カナ                     0001 1011

        private static ImeMode[] japaneseTable = new ImeMode[10]
        {
            ImeMode.Inherit,
            ImeMode.Disable,
            ImeMode.Off,
            ImeMode.Off,
            ImeMode.Hiragana,
            ImeMode.Hiragana,
            ImeMode.Katakana,
            ImeMode.KatakanaHalf,
            ImeMode.AlphaFull,
            ImeMode.Alpha
        };

        private static ImeMode[] koreanTable = new ImeMode[10]
        {
            ImeMode.Inherit,
            ImeMode.Disable,
            ImeMode.Alpha,
            ImeMode.Alpha,
            ImeMode.HangulFull,
            ImeMode.Hangul,
            ImeMode.HangulFull,
            ImeMode.Hangul,
            ImeMode.AlphaFull,
            ImeMode.Alpha
        };

        private static ImeMode[] chineseTable = new ImeMode[10]
        {
            ImeMode.Inherit,
            ImeMode.Disable,
            ImeMode.Off,
            ImeMode.Close,
            ImeMode.On,
            ImeMode.OnHalf,
            ImeMode.On,
            ImeMode.OnHalf,
            ImeMode.Off,
            ImeMode.Off
        };
        /// <summary>
        /// This property indicates if num lock is active.
        /// </summary>
        public static bool isNumlockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.NumLock);
            }
        }

        /// <summary>
        /// This property indicates if caps lock is active.
        /// </summary>
        public static bool isCapslockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.CapsLock);
            }
        }

        /// <summary>
        /// This property indicates if scroll lock is active.
        /// </summary>
        public static bool isScrolllockActive
        {
            get
            {
                return Control.IsKeyLocked(Keys.Scroll);
            }
        }

        [DllImport("user32.dll")] static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);
        [DllImport("user32.dll")] static extern IntPtr GetKeyboardLayout(uint thread);
        
        [DllImport("user32.dll")] static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("imm32.dll")] static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll")] static extern bool GetGUIThreadInfo(uint dwthreadid, ref GUITHREADINFO lpguithreadinfo);

        /// <summary>
        /// This property indicates if num lock is active.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public System.Drawing.Rectangle rcCaret;
        }
        /// <summary>
        /// This Method Get Ime Mode Name
        /// </summary>
        public static String GetImeModeString(int keyboardLayout, int imemode)
        {
                switch (keyboardLayout)
                {
                    case 1028:
                    case 2052:
                    case 3076:
                    case 4100:
                    case 5124:
                        return ( IME_CMODE_NATIVE & imemode ) > 0 ? "Ch" : "En";
                        //return chineseTable[imemode];
                    case 1042:
                    case 2066:
                        return ( IME_CMODE_NATIVE & imemode ) > 0 ? "Ko" : "En";
                        //return koreanTable[imemode];
                    case 1041:
                    if (imemode == 0) return "En";
                    if ((IME_CMODE_FULLSHAPE & imemode) > 0)
                        return (IME_CMODE_KATAKANA & imemode) == 0 ? "ZenHira" : "ZenKata";
                    else
                        return (IME_CMODE_KATAKANA & imemode) == 0 ? "HanHira" : "HanKata";
                        // return japaneseTable[imemode];
                    default:
                        return "En";
                }

        }

        /// <summary>
        /// This property indicates if Ime Mode by int
        /// </summary>
        public static int GetImeMode()
        {
            //Get IME Condition
            GUITHREADINFO gti = new GUITHREADINFO();
            gti.cbSize = Marshal.SizeOf(gti);

            if (!GetGUIThreadInfo(0, ref gti))
            {
                return 0;
            }
            IntPtr imwd = ImmGetDefaultIMEWnd(gti.hwndFocus);

            int imeConvMode = SendMessage(imwd, WM_IME_CONTROL, (IntPtr)IMC_GETCONVERSIONMODE, IntPtr.Zero);
            bool imeEnabled = (SendMessage(imwd, WM_IME_CONTROL, (IntPtr)IMC_GETOPENSTATUS, IntPtr.Zero) != 0);
            if (imeEnabled)
            {
                return imeConvMode;
            }/* else 無変換(半角英数) */
            return 0;
        }

        /// <summary>
        /// This method indicates Keyboard Layout by int
        /// </summary>
        public static int GetCurrentKeyboardLayoutInt()
        {
            try
            {
                IntPtr foregroundWindow = GetForegroundWindow();
                uint foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
                int keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32();

                return keyboardLayout & 0xFFFF;
            }
            catch (Exception)
            {
                return 1033; // Assume English if something went wrong.
            }
        }

        /// <summary>
        /// This method return Keyboard Layout by CultureInfo
        /// </summary>
        public static CultureInfo GetCurrentKeyboardLayout()
        {
            try
            {
                int keyboardLayout = GetCurrentKeyboardLayoutInt();
                return new CultureInfo(keyboardLayout);
            }
            catch (Exception)
            {
                return new CultureInfo(1033); // Assume English if something went wrong.
            }
        }

        /// <summary>
        /// This method return KeyboardLayout name
        /// </summary>
        public static String getKeyboardLayoutName
        {
            get
            {
                return GetCurrentKeyboardLayout().NativeName;
            }
        }
    }
}
