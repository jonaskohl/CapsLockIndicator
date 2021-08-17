/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    internal sealed class Program
    {
        // Fix hand cursor
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
        private const int IDC_HAND = 32649;
        private static Cursor SystemHandCursor;

        private static void ApplyHandCursorFix()
        {
            try
            {
                SystemHandCursor = new Cursor(LoadCursor(IntPtr.Zero, IDC_HAND));

                typeof(Cursors).GetField("hand", BindingFlags.Static | BindingFlags.NonPublic)
                               .SetValue(null, SystemHandCursor);
            }
            catch { }
        }

        [Flags]
        enum KeyType
        {
            None = 0,
            NumLock = 1,
            CapsLock = 2,
            ScrollLock = 4
        }

        enum DisplayType
        {
            Icon,
            Notification
        }

        public static bool keepFirstRunDialogOpen = true;

        public static MainForm MainForm { get; private set; }

        static void SetDisplay(DisplayType type, int keys)
        {
            switch (type)
            {
                case DisplayType.Icon:
                    SettingsManager.Set("numIco", (keys & (int)KeyType.NumLock) != 0);
                    SettingsManager.Set("capsIco", (keys & (int)KeyType.CapsLock) != 0);
                    SettingsManager.Set("scrollIco", (keys & (int)KeyType.ScrollLock) != 0);
                    break;
                case DisplayType.Notification:
                    SettingsManager.Set("numInd", (keys & (int)KeyType.NumLock) != 0);
                    SettingsManager.Set("capsInd", (keys & (int)KeyType.CapsLock) != 0);
                    SettingsManager.Set("scrollInd", (keys & (int)KeyType.ScrollLock) != 0);
                    break;
                default:
                    break;
            }
        }
        static void SetHideStartup(bool v)
        {
            SettingsManager.Set("hideOnStartup", v);
        }
        static void SetStartup(bool v)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (v)
                rk.SetValue("CapsLock Indicator", Application.ExecutablePath);
            else
                rk.DeleteValue("CapsLock Indicator", false);
        }
        static void SetVerCheck(bool v)
        {
            SettingsManager.Set("checkForUpdates", v);
        }
        static void SetLocale(string l)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(l);
        }
        static void SetDisplayLocation(string v)
        {
            if (Enum.TryParse(v, out IndicatorDisplayPosition position))
                SettingsManager.Set("overlayPosition", position);
        }

        // Create a mutex to check if an instance is already running
        static Mutex mutex = new Mutex(true, "{6f54c357-0542-4d7d-9225-338bc3cd7834}");
        [STAThread]
        private static void Main(string[] args)
        {
            SettingsManager.Load();

            if (mutex.WaitOne(TimeSpan.Zero, true)) // No instance is open
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                SettingsManager.Save();

                if (DarkModeProvider.IsDark)
                    Native.SetPrefferDarkMode(true);

                var runApp = true;

                ApplyHandCursorFix();
                
                if (SettingsManager.Get<bool>("firstRun"))
                {
                    do
                    {
                        using (var d = new FirstRunDialog())
                        {
                            var res = d.ShowDialog();
                            if (res == DialogResult.OK)
                            {
                                SettingsManager.Set("firstRun", false);
                                runApp = true;
                            }
                            else
                                runApp = false;
                        }
                    } while (keepFirstRunDialogOpen);
                }

                if (runApp)
                {
                    MainForm = new MainForm();

                    Application.Run(MainForm);
                }

                // Release the mutex
                mutex.ReleaseMutex();

                SettingsManager.Save();
            }
            else // An instance is already open
            {
                Application.EnableVisualStyles();
                MessageBox.Show("An instance is already open!");
            }
        }

        public static void ReleaseMutex()
        {
            mutex.ReleaseMutex();
            mutex.Close();
            mutex.Dispose();
        }
    }
}
