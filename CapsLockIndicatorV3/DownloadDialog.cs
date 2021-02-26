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
    public partial class DownloadDialog : Form
    {
        WebClient Client;
        Stopwatch sw = new Stopwatch();
        string newPath;

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

            if (SettingsManager.Get<bool>("beta_enableDarkMode"))
            {
                HandleCreated += DownloadDialog_HandleCreated;

                statusLabel.ForeColor =
                infoLabel.ForeColor =
                Color.White;

                BackColor = Color.FromArgb(255, 32, 32, 32);
                ForeColor = Color.White;

                ControlScheduleSetDarkMode(downloadProgress);
                ControlScheduleSetDarkMode(restartButton);
                ControlScheduleSetDarkMode(closeButton);
                ControlScheduleSetDarkMode(cancelButton);
            }
        }

        private void DownloadDialog_HandleCreated(object sender, EventArgs e)
        {
            Native.UseImmersiveDarkModeColors(Handle, true);
        }

        private void ControlScheduleSetDarkMode(Control control)
        {
            control.HandleCreated += (sender, e) =>
            {
                Native.ControlSetDarkMode(control, true);
            };
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
                restartButton.Show();
                restartButton.Enabled = true;
                statusLabel.Text = "Download completed.";
            }
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            Download(DownloadURL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.CancelAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
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
        }
    }
}
