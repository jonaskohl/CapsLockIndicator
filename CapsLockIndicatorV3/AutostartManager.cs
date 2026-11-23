using Microsoft.Win32;
using System;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// Manages the "start on logon" registry entry, including the
    /// enabled/disabled state Windows keeps in StartupApproved.
    /// </summary>
    internal static class AutostartManager
    {
        public const string AutostartArgument = "/autostart";

        private const string ValueName = "CapsLock Indicator";
        private const string RunKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string StartupApprovedKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run";

        /// <summary>
        /// True if the Run entry exists and has not been disabled via
        /// Task Manager or the Startup apps settings page.
        /// </summary>
        public static bool IsEnabled
        {
            get
            {
                using (var rk = Registry.CurrentUser.OpenSubKey(RunKeyPath, false))
                {
                    if (rk?.GetValue(ValueName) == null)
                        return false;
                }

                return !IsDisabledByWindows();
            }
        }

        /// <summary>
        /// True if a Run entry exists at all (enabled or disabled).
        /// </summary>
        public static bool IsRegistered
        {
            get
            {
                using (var rk = Registry.CurrentUser.OpenSubKey(RunKeyPath, false))
                    return rk?.GetValue(ValueName) != null;
            }
        }

        public static void Enable(string executablePath)
        {
            WriteRunValue(executablePath);
            ClearDisabledByWindows();
        }

        /// <summary>
        /// Points an existing Run entry at a new executable without
        /// changing whether Windows has it enabled or disabled.
        /// </summary>
        public static void UpdatePath(string executablePath)
        {
            if (IsRegistered)
                WriteRunValue(executablePath);
        }

        private static void WriteRunValue(string executablePath)
        {
            using (var rk = Registry.CurrentUser.CreateSubKey(RunKeyPath))
                rk.SetValue(ValueName, "\"" + executablePath + "\" " + AutostartArgument);
        }

        public static void Disable()
        {
            using (var rk = Registry.CurrentUser.OpenSubKey(RunKeyPath, true))
                rk?.DeleteValue(ValueName, false);
        }

        // StartupApproved values are 12-byte REG_BINARY blobs; an odd first
        // byte (0x03, 0x07) means the entry was disabled by the user.
        private static bool IsDisabledByWindows()
        {
            try
            {
                using (var rk = Registry.CurrentUser.OpenSubKey(StartupApprovedKeyPath, false))
                {
                    if (rk?.GetValue(ValueName) is byte[] data && data.Length > 0)
                        return (data[0] & 1) == 1;
                }
            }
            catch { }

            return false;
        }

        private static void ClearDisabledByWindows()
        {
            try
            {
                using (var rk = Registry.CurrentUser.OpenSubKey(StartupApprovedKeyPath, true))
                {
                    if (rk?.GetValue(ValueName) is byte[] data && data.Length > 0 && (data[0] & 1) == 1)
                        rk.SetValue(ValueName, new byte[12] { 0x02, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, RegistryValueKind.Binary);
                }
            }
            catch { }
        }
    }
}
