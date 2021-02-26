using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class FirstRunDialog : Form
    {
        public FirstRunDialog()
        {
            InitializeComponent();
            if (SettingsManager.Get<bool>("beta_enableDarkMode"))
            {
                HandleCreated += FirstRunDialog_HandleCreated;

                headerLabel.ForeColor =
                messageLabel.ForeColor =
                lnkLabel1.LinkColor =
                lnkLabel2.LinkColor =
                allowUpdatesCheckBox.ForeColor =
                Color.White;

                allowUpdatesCheckBox.FlatStyle = FlatStyle.Standard;

                BackColor = Color.FromArgb(255, 32, 32, 32);
                ForeColor = Color.White;

                ControlScheduleSetDarkMode(okButton);
                ControlScheduleSetDarkMode(exitButton);
            }

            headerLabel.Text = strings.firstRunHeading;
            messageLabel.Text = strings.firstRunMessage;
            allowUpdatesCheckBox.Text = strings.firstRunAllowUpdateCheck;
            lnkLabel1.Text = strings.firstRunPrivacyInfoLinkLabel;
            lnkLabel2.Text = strings.firstRunContribute;
            okButton.Text = strings.firstRunStart;
            exitButton.Text = strings.firstRunExit;
        }
        
        private void FirstRunDialog_HandleCreated(object sender, EventArgs e)
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

        private void allowUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("checkForUpdates", allowUpdatesCheckBox.Checked);
            SettingsManager.Save();
        }

        private void lnkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cli.jonaskohl.de/kb/?a=updatecheck");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SettingsManager.Set("checkForUpdates", allowUpdatesCheckBox.Checked);
            SettingsManager.Save();
        }

        private void lnkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jonaskohl/CapsLockIndicator");
        }
    }
}
