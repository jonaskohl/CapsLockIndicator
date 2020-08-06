/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */
using Microsoft.Win32;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
	internal sealed class Program
	{
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

        static void SetDisplay(DisplayType type, int keys)
        {
            switch (type)
            {
                case DisplayType.Icon:
                    Properties.Settings.Default.numIco    = (keys & (int)KeyType.NumLock)    != 0;
                    Properties.Settings.Default.capsIco   = (keys & (int)KeyType.CapsLock)   != 0;
                    Properties.Settings.Default.scrollIco = (keys & (int)KeyType.ScrollLock) != 0;
                    break;
                case DisplayType.Notification:
                    Properties.Settings.Default.numInd    = (keys & (int)KeyType.NumLock)    != 0;
                    Properties.Settings.Default.capsInd   = (keys & (int)KeyType.CapsLock)   != 0;
                    Properties.Settings.Default.scrollInd = (keys & (int)KeyType.ScrollLock) != 0;
                    break;
                default:
                    break;
            }
        }
        static void SetHideStartup(bool v)
        {
            Properties.Settings.Default.hideOnStartup = v;
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
            Properties.Settings.Default.checkForUpdates = v;
        }
        static void DisplayHelp(OptionSet p)
        {
            StringWriter sw = new StringWriter();
            
            sw.WriteLine("CapsLock Indicator");
            sw.WriteLine();
            sw.WriteLine("Options:");
            p.WriteOptionDescriptions(sw);
            sw.WriteLine();
            sw.WriteLine("For more information, visit: http://cli.jonaskohl.de/!/commandline");
            
            string result = sw.ToString();

            sw.Close();
            sw.Dispose();

            //MessageBox.Show(result, "CapsLock Indicator", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HelpWindow h = new HelpWindow(result);
            Application.Run(h);
        }
        static void SetLocale(string l)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(l);
        }
        static void SetDisplayLocation(string v)
        {
            if (Enum.TryParse(v, out IndicatorDisplayPosition position))
                Properties.Settings.Default.overlayPosition = position;
        }

        // Create a mutex to check if an instance is already running
        static Mutex mutex = new Mutex(true, "{6f54c357-0542-4d7d-9225-338bc3cd7834}");
        [STAThread]
		private static void Main(string[] args)
		{
            if (mutex.WaitOne(TimeSpan.Zero, true)) // No instance is open
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                #region Parse command line

                bool show_help = false;

                OptionSet oSet = new OptionSet()
                {
                    { "h|?|help", "Display help", v => show_help = v != null },
                    { "i|icons=", "The icons to show (Type: IconMask)", (int v) => SetDisplay(DisplayType.Icon, v) },
                    { "n|notifs=", "The notifications to show (Type: IconMask)", (int v) => SetDisplay(DisplayType.Notification, v) },
                    { "a|autostart=", "Enable auto start (Type: Boolean)", (bool v) => SetStartup(v) },
                    { "s|hidestarup=", "Enable or disable hide on startup setting (Type: Boolean)", (bool v) => SetHideStartup(v) },
                    { "v|disverchk=", "Disable the automatic version checking (Type: Boolean)", (bool v) => SetVerCheck(v) },
                    { "l|locale=", "Override the UI locale (Type: String)", (string v) => SetLocale(v) },
                    { "p|position=", "Set the indicator display position (Type: IndicatorDisplayPosition)", (string v) => SetDisplayLocation(v) }
                };

                List<string> extra;
                try
                {
                    extra = oSet.Parse(args);
                }
                catch (OptionException)
                {
                    //MessageBox.Show("Failed to parse command line:\n" + e.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (show_help)
                {
                    DisplayHelp(oSet);
                    return;
                }

                Properties.Settings.Default.Save();

                #endregion

                if (Environment.CurrentDirectory.ToLower() == Environment.ExpandEnvironmentVariables(@"%systemroot%\system32").ToLower() ||
                    Environment.CurrentDirectory.ToLower() == Environment.ExpandEnvironmentVariables(@"%systemroot%\system32\").ToLower())
                    Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                Application.Run(new MainForm());

                // Release the mutex
                mutex.ReleaseMutex();
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
