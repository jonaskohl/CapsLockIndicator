using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class UpdateDialog : DarkModeForm
    {
        private Version newVersion;
        private Version minOsVersion;

        public UpdateDialog()
        {
            InitializeComponent();

            Text = strings.updateAvailable;
            updateNowButton.Text = strings.updateNow;
            dismissButton.Text = strings.dismissButton;
            downloadManuallyButton.Text = strings.downloadManuallyButton;

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += UpdateDialog_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };
        }

        private void UpdateDialog_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            lnkLabel1.ForeColor =
            lnkLabel1.LinkColor =
            dark ? Color.White : SystemColors.HotTrack;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;
            infoLabel.ForeColor = dark ? Color.FromArgb(255, 196, 204, 238) : Color.FromArgb(255, 52, 77, 180);
            changelogRtf.BackColor = dark ? Color.FromArgb(255, 56, 56, 56) : SystemColors.Window;

            ControlScheduleSetDarkMode(changelogRtf, dark);
            ControlScheduleSetDarkMode(dismissButton, dark);
            ControlScheduleSetDarkMode(updateNowButton, dark);
            ControlScheduleSetDarkMode(downloadManuallyButton, dark);
        }

        public void SetNewVersion(Version v, Version minOsVersion = null)
        {
            newVersion = v;
            this.minOsVersion = minOsVersion;

            if (minOsVersion != null && Environment.OSVersion.Version < minOsVersion)
            {
                lnkLabel1.Show();
                downloadManuallyButton.Enabled = false;
                updateNowButton.Enabled = false;
                downloadManuallyButton.Hide();
                updateNowButton.Hide();
                dismissButton.Location = new Point(
                    downloadManuallyButton.Location.X + downloadManuallyButton.Width - dismissButton.Width,
                    downloadManuallyButton.Location.Y
                );
            }
        }

        private void downloadManuallyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void lnkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Version " + newVersion + " of ImeModeIndicator requires at least Windows " + minOsVersion + "! You are running " + FriendlyName(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return ProductName + (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "an unknown OS";
        }
    }
}
