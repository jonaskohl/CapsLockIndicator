using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// This class checks if a new version is available.
    /// </summary>
    public static class VersionCheck
    {
        public static string newVersion = null;

        private static string version;

        public static string UserAgent =>
            "Mozilla/4.0 (compatible; MSIE 7.0; " + Environment.OSVersion.ToString() + "; " + (Environment.Is64BitOperatingSystem? "Win64; x64" : "Win32; x86") + ") Trident 7.0 (KHTML, like Gecko) CapsLockIndicator/" + version;

        static VersionCheck()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            version = fvi.FileVersion;
        }

        public static async void IsLatestVersion(Action<string> callback, bool isManualCheck)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                string data = await client.DownloadStringTaskAsync(URLs.VersionCheck + (DarkModeProvider.IsDark ? "&dark=true" : ""));
                callback(data);
            }
            catch (Exception e)
            {
                if (isManualCheck)
                    MessageBox.Show("An error occured while searching for updates:\r\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            client.Dispose();
        }
    }
}
