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
    public partial class UpdateDialog : Form
    {
        private Version newVersion;

        public UpdateDialog()
        {
            InitializeComponent();

            Text = strings.updateAvailable;
            updateNowButton.Text = strings.updateNow;
            dismissButton.Text = strings.dismissButton;
            downloadManuallyButton.Text = strings.downloadManuallyButton;

            if (SettingsManager.Get<bool>("beta_enableDarkMode"))
            {
                HandleCreated += UpdateDialog_HandleCreated;

                lnkLabel1.ForeColor =
                lnkLabel1.LinkColor =
                Color.White;

                BackColor = Color.FromArgb(255, 32, 32, 32);
                ForeColor = Color.White;
                infoLabel.ForeColor = Color.FromArgb(255, 196, 204, 238);
                changelogRtf.BackColor = Color.FromArgb(255, 56, 56, 56);

                ControlScheduleSetDarkMode(dismissButton);
                ControlScheduleSetDarkMode(updateNowButton);
                ControlScheduleSetDarkMode(downloadManuallyButton);
            }
        }

        private void UpdateDialog_HandleCreated(object sender, EventArgs e)
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

        public void SetNewVersion(Version v)
        {
            newVersion = v;

            if (newVersion.Major >= 4 && Environment.OSVersion.Version.Major < 10)
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
            MessageBox.Show("Version 4.x or newer of CapsLock Indicator requires Windows 10! You are running " + FriendlyName(), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
