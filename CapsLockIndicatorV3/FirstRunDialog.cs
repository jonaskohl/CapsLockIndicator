using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class FirstRunDialog : DarkModeForm
    {
        ResourceManager resources;

        public FirstRunDialog()
        {
            InitializeComponent();

            resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());

            HandleCreated += FirstRunDialog_HandleCreated;

            FormClosing += FirstRunDialog_FormClosing;

            Shown += FirstRunDialog_Shown;

            ControlScheduleSetDarkMode(darkButton, true);

            headerLabel.Text = strings.firstRunHeading;
            messageLabel.Text = strings.firstRunMessage;
            allowUpdatesCheckBox.Text = strings.firstRunAllowUpdateCheck;
            lnkLabel1.Text = strings.firstRunPrivacyInfoLinkLabel;
            lnkLabel2.Text = strings.firstRunContribute;
            okButton.Text = strings.firstRunStart;
            exitButton.Text = strings.firstRunExit;
            themeLabel.Text = strings.firstRunColorSchemePreference;
            lightButton.Text = strings.firstRunColorSchemeLight;
            darkButton.Text = strings.firstRunColorSchemeDark;

            if (!DarkModeProvider.SystemSupportsDarkMode)
            {
                darkButton.Enabled = false;
                darkButton.Text += "\r\n" + strings.firstRunColorSchemeWin10Only;
            }
        }

        private void FirstRunDialog_Shown(object sender, EventArgs e)
        {
            Width = Width + 1;
            Height = Height + 1;
        }

        private void FirstRunDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                Program.keepFirstRunDialogOpen = false;
        }

        private void FirstRunDialog_HandleCreated(object sender, EventArgs e)
        {
            DarkModeProvider.RegisterForm(this);
            DarkModeChanged += FirstRunDialog_DarkModeChanged;
        }

        private void FirstRunDialog_DarkModeChanged(object sender, EventArgs e)
        {
            //RecreateHandle();

            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            Opacity -= 0.0001;
            Opacity += 0.0001;

            headerLabel.ForeColor = dark ? Color.White : Color.FromArgb(255, 0, 51, 153);

            Icon = (Icon)resources.GetObject("CLIv3_Icon" + (dark ? "_Dark" : ""));

            lnkLabel1.LinkColor =
            lnkLabel2.LinkColor =
            dark ? Color.White : SystemColors.HotTrack;

            messageLabel.ForeColor =
            allowUpdatesCheckBox.ForeColor =
            dark ? Color.White : SystemColors.WindowText;

            allowUpdatesCheckBox.DarkMode = dark;
            allowUpdatesCheckBox.FlatStyle = dark ? FlatStyle.Standard : FlatStyle.System;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            ControlScheduleSetDarkMode(okButton, dark);
            ControlScheduleSetDarkMode(exitButton, dark);
        }

        private void allowUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("checkForUpdates", allowUpdatesCheckBox.Checked);
            SettingsManager.Save();
        }

        private void lnkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(URLs.KBUpdateCheck);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Program.keepFirstRunDialogOpen = false;
            SettingsManager.Set("checkForUpdates", allowUpdatesCheckBox.Checked);
            SettingsManager.Save();
        }

        private void lnkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(URLs.GithubRepo);
        }

        private void lightButton_Click(object sender, EventArgs e)
        {
            DarkModeProvider.SetDarkModeEnabled(false);
        }

        private void darkButton_Click(object sender, EventArgs e)
        {
            DarkModeProvider.SetDarkModeEnabled(true);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Program.keepFirstRunDialogOpen = false;
        }
    }
}
