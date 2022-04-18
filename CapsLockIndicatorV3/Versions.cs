using System;

namespace CapsLockIndicatorV3
{
    public class Versions
    {
        public static readonly Version SettingsToTabs = new Version(3, 13, 0, 0);

        public static bool IsWindows11 => Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000;
    }
}