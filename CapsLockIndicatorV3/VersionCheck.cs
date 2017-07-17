using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// This class checks if a new version is awailable.
    /// </summary>
    static class VersionCheck
    {
        const string CheckURL = "http://cli.jonaskohl.de/version.php";
        public static string newVersion = null;

        public static async void IsLatestVersion(Action<bool> callback)
        {
            WebClient client = new WebClient();
            try
            {
                string data = await client.DownloadStringTaskAsync(CheckURL);
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                newVersion = data;
                callback(data == version);
            }
            catch (Exception)
            {
                callback(true);
            }
        }
    }
}
