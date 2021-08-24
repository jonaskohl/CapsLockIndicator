using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class DownloadDialog : DarkModeForm
    {
        Stopwatch sw = new Stopwatch();
#if !DEBUG
        WebClient Client;
        string newPath;
#endif

        public string DownloadURL;

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0x0084) // WM_NCHITTEST
                message.Result = (IntPtr)1;
            else base.WndProc(ref message);
        }

        public DownloadDialog()
        {
            InitializeComponent();

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += DownloadDialog_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };
        }

        private void DownloadDialog_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            statusLabel.ForeColor =
            infoLabel.ForeColor =
            ForeColor =
            dark ? Color.White : SystemColors.WindowText;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;

            ControlScheduleSetDarkMode(downloadProgress, dark);
            ControlScheduleSetDarkMode(restartButton, dark);
            ControlScheduleSetDarkMode(closeButton, dark);
            ControlScheduleSetDarkMode(cancelButton, dark);
        }

        public void Download(string url)
        {
#if !DEBUG
            Uri uri = new Uri(url);
            string filename = Path.GetFileName(uri.LocalPath);
            string currentPath = Path.GetDirectoryName(Application.ExecutablePath);
            string path = Path.Combine(currentPath, filename);
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Jonas_Kohl\" + filename);

            sw.Start();

            Client = new WebClient();
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleteCallback);
            //without adding RequestHeader with UserAgent will show 403 forbidden in old version with random situation, though now seems not happend anymore... :/
            // Client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; " + Environment.OSVersion.ToString() + "; " + (Environment.Is64BitOperatingSystem ? "Win64; x64" : "Win32; x86") + ") Trident 7.0 (KHTML, like Gecko) CapsLockIndicator/" + FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion);
            Client.DownloadFileAsync(new Uri(url), path);

            newPath = path;
#endif
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            downloadProgress.Value = e.ProgressPercentage;

            infoLabel.Text = string.Format("Downloaded {0}/{1}KB ({2}%) @ {3} KB/s", (e.BytesReceived / 1024d).ToString("0.0"), (e.TotalBytesToReceive / 1024d).ToString("0.0"), e.ProgressPercentage, (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));
        }

        private void DownloadFileCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            infoLabel.Text = "";
            cancelButton.Hide();
            cancelButton.Enabled = false;

            if (e.Cancelled == true)
            {
                closeButton.Show();
                closeButton.Enabled = true;
                statusLabel.Text = "Download aborted.";
                downloadProgress.Value = 0;
            }
            else
            {
                if (e.Error == null)
                {
                    restartButton.Show();
                    restartButton.Enabled = true;
                    statusLabel.Text = "Download completed.";
                }
                else
                {
                    MessageBox.Show("An error occured while downloading update:\r\n" + e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeButton.Show();
                    closeButton.Enabled = true;
                    statusLabel.Text = "Download error, aborted.";
                }
            }
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            Download(DownloadURL);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
#if !DEBUG
            Client?.CancelAsync();
#endif
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
#if !DEBUG
            bool runAtStarup = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "CapsLock Indicator", null) != null;

            if (runAtStarup)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                rk.SetValue("CapsLock Indicator", newPath);
            }

            MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();

            mainForm.askCancel = false;
            Program.ReleaseMutex();

            Thread.Sleep(100);

            Process.Start(newPath);
            Application.Exit();
#endif
        }
    }
}
