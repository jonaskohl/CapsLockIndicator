using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class DownloadDialog : Form
    {
        WebClient Client;
        Stopwatch sw = new Stopwatch();
        string newPath;

        public string DownloadURL;

        public DownloadDialog()
        {
            InitializeComponent();
        }

        public void Download(string url)
        {
            Uri uri = new Uri(url);
            string filename = Path.GetFileName(uri.LocalPath);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Jonas_Kohl\" + filename);

            sw.Start();

            Client = new WebClient();
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleteCallback);
            Client.DownloadFileAsync(new Uri(url), path);

            newPath = path;
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

            MainForm mainForm = (MainForm) Application.OpenForms["mainForm"];

            mainForm.askCancel = false;

            Process.Start(newPath);
            Application.Exit();
        }
    }
}
