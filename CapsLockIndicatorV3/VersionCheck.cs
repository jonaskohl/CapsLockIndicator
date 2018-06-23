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
        const string CheckURL = "https://cli.jonaskohl.de/version.php?details&xml";
        public static string newVersion = null;

        public static async void IsLatestVersion(Action<string> callback)
        {
            WebClient client = new WebClient();
            try
            {
                string data = await client.DownloadStringTaskAsync(CheckURL);
                callback(data);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while searching for updates:\r\n" + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
