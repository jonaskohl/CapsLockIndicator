/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */

// Use project namespace, for easier access to e.g helper classes
using CapsLockIndicatorV3;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Linq;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;
using System.IO;

namespace CapsLockIndicatorV3
{
    public partial class MainForm : Form
    {
        public bool isHidden = false;

        // Define variables used to load the icons from resources.resx
        ResourceManager resources;

        Icon CapsOff;
        Icon CapsOn;

        Icon NumOff;
        Icon NumOn;

        Icon ScrollOff;
        Icon ScrollOn;

        // Store the key states of the previous timer tick
        bool numState;
        bool capsState;
        bool scrollState;

        public bool askCancel = true;
        private bool shouldClose = false;

        private int previousLocaleIndex = -1;

        public MainForm()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            // Initialize component
            InitializeComponent();

            Opacity = 0;
            ShowInTaskbar = false;

            // Load "resources.resx" into a ResourceManager to access its resources
            resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());

            // Load the icons into variables
            ReloadIcons();

            // Set the values
            numState = KeyHelper.isNumlockActive;
            capsState = KeyHelper.isCapslockActive;
            scrollState = KeyHelper.isScrolllockActive;

            // Load settings
            enableNumIcon.Checked = SettingsManager.Get<bool>("numIco");
            enableCapsIcon.Checked = SettingsManager.Get<bool>("capsIco");
            enableScrollIcon.Checked = SettingsManager.Get<bool>("scrollIco");

            enableNumInd.Checked = SettingsManager.Get<bool>("numInd");
            enableCapsInd.Checked = SettingsManager.Get<bool>("capsInd");
            enableScrollInd.Checked = SettingsManager.Get<bool>("scrollInd");

            showNoIcons.Checked = SettingsManager.Get<bool>("noIco");
            showNoNotification.Checked = SettingsManager.Get<bool>("noInd");

            iconsGroup.Enabled = !showNoIcons.Checked;
            indicatorGroup.Enabled = !showNoNotification.Checked;

            generalIcon.ContextMenu =
                numLockIcon.ContextMenu =
                capsLockIcon.ContextMenu =
                scrollLockIcon.ContextMenu =
                contextMenu1;

            if (SettingsManager.Get<bool>("beta_enableDarkMode"))
            {
                HandleCreated += MainForm_HandleCreated;

                iconsGroup.ForeColor =
                indicatorGroup.ForeColor =
                enableNumInd.ForeColor =
                enableCapsInd.ForeColor =
                enableScrollInd.ForeColor =
                enableNumIcon.ForeColor =
                enableCapsIcon.ForeColor =
                enableScrollIcon.ForeColor =
                showNoIcons.ForeColor =
                showNoNotification.ForeColor =
                startonlogonCheckBox.ForeColor =
                hideOnStartupCheckBox.ForeColor =
                Color.White;

                enableNumInd.FlatStyle =
                enableCapsInd.FlatStyle =
                enableScrollInd.FlatStyle =
                enableNumIcon.FlatStyle =
                enableCapsIcon.FlatStyle =
                enableScrollIcon.FlatStyle =
                showNoIcons.FlatStyle =
                showNoNotification.FlatStyle =
                startonlogonCheckBox.FlatStyle =
                hideOnStartupCheckBox.FlatStyle =
                FlatStyle.Standard;

                BackColor = Color.FromArgb(255, 32, 32, 32);
                ForeColor = Color.White;
                aboutPanelTopBorder.BackColor = Color.FromArgb(255, 196, 204, 238);
                appNameLabel.LinkColor = 
                appNameLabel.ActiveLinkColor =
                Color.FromArgb(255, 196, 204, 238);
                logo.Image = (Bitmap)resources.GetObject("logo_dark");

                ControlScheduleSetDarkMode(checkForUpdatesButton);
                ControlScheduleSetDarkMode(indSettings);
                ControlScheduleSetDarkMode(exitApplication);
                ControlScheduleSetDarkMode(hideWindow);
                ControlScheduleSetDarkMode(enableNumInd);
                ControlScheduleSetDarkMode(enableCapsInd);
                ControlScheduleSetDarkMode(enableScrollInd);
                ControlScheduleSetDarkMode(enableNumIcon);
                ControlScheduleSetDarkMode(enableCapsIcon);
                ControlScheduleSetDarkMode(enableScrollIcon);
                ControlScheduleSetDarkMode(localeComboBox);
            }

            // Check if application is in startup
            startonlogonCheckBox.Checked = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "CapsLock Indicator", null) != null;

            // Hides the window on startup if enabled
            if (SettingsManager.Get<bool>("hideOnStartup"))
            {
                hideOnStartupCheckBox.Checked = true;
                hideWindowTimer.Start();
            }
            else
            {
                Opacity = 1;
                ShowInTaskbar = true;
            }

            checkForUpdatedCheckBox.Checked = SettingsManager.Get<bool>("checkForUpdates");

            AddCultures();

            ApplyLocales();
        }

        private void MainForm_HandleCreated(object sender, EventArgs e)
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

        private void ReloadIcons()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            CapsOff = File.Exists(Path.Combine(dir, "caps0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "caps0.ico")) : (Icon)resources.GetObject("CLIv3_Caps_Off");
            CapsOn = File.Exists(Path.Combine(dir, "caps1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "caps1.ico")) : (Icon)resources.GetObject("CLIv3_Caps_On");

            NumOff = File.Exists(Path.Combine(dir, "num0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "num0.ico")) : (Icon)resources.GetObject("CLIv3_Num_Off");
            NumOn = File.Exists(Path.Combine(dir, "num1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "num1.ico")) : (Icon)resources.GetObject("CLIv3_Num_On");

            ScrollOff = File.Exists(Path.Combine(dir, "scroll0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "scroll0.ico")) : (Icon)resources.GetObject("CLIv3_Scroll_Off");
            ScrollOn = File.Exists(Path.Combine(dir, "scroll1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "scroll1.ico")) : (Icon)resources.GetObject("CLIv3_Scroll_On");
        }

        private void AddCultures()
        {
            int index = 1;
            int selectIndex = 0;

            localeComboBox.Items.Clear();

            localeComboBox.Items.Add(new DropDownLocale("en-GB", "English (United Kingdom)"));

            foreach (CultureInfo c in GetSupportedCulture())
            {
                if (c.Name.Trim().Length < 1)
                    continue;
                else
                {
                    localeComboBox.Items.Add(new DropDownLocale(c.Name, c.NativeName));

                    if (c.TwoLetterISOLanguageName == Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
                        selectIndex = index;

                    index++;
                }
            }

            if (SettingsManager.Get<int>("selectedUICulture") < 0)
                localeComboBox.SelectedIndex = selectIndex;
            else if (SettingsManager.Get<int>("selectedUICulture") < localeComboBox.Items.Count)
                localeComboBox.SelectedIndex = SettingsManager.Get<int>("selectedUICulture");
            else
                localeComboBox.SelectedIndex = 0;

            localeComboBox.Items.Add(new DropDownLocale("--ln", ""));
            localeComboBox.Items.Add(new DropDownLocale("--get-more", strings.downloadMoreTranslations));
        }

        public IEnumerable<CultureInfo> GetSupportedCulture()
        {
            //Get all culture 
            CultureInfo[] culture = CultureInfo.GetCultures(CultureTypes.AllCultures);

            //Find the location where application installed.
            string exeLocation = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            //Return all culture for which satellite folder found with culture code.
            return culture.Where(cultureInfo => Directory.Exists(Path.Combine(exeLocation, cultureInfo.Name)));
        }

        void ApplyLocales()
        {
            iconsGroup.Text = strings.showIconsFor;
            indicatorGroup.Text = strings.showNotificationWhen;
            enableNumIcon.Text = strings.numLock;
            enableCapsIcon.Text = strings.capsLock;
            enableScrollIcon.Text = strings.scrollLock;
            enableNumInd.Text = string.Format(strings.keyChanged, strings.numLock);
            enableCapsInd.Text = string.Format(strings.keyChanged, strings.capsLock);
            enableScrollInd.Text = string.Format(strings.keyChanged, strings.scrollLock);
            showNoIcons.Text = strings.showNoIcons;
            showNoNotification.Text = strings.showNoNotification;
            hideWindow.Text = strings.hideWindow;
            exitApplication.Text = strings.exitApplication;
            indSettings.Text = strings.notificationSettings;
            checkForUpdatesButton.Text = strings.checkForUpdates;
            startonlogonCheckBox.Text = strings.startOnLogon;
            generalIcon.BalloonTipText = strings.generalIconBalloonText;
            showToolStripMenuItem.Text = strings.contextMenuShow;
            showMenuItem.Text = strings.contextMenuShow;
            exitToolStripMenuItem.Text = strings.contextMenuExit;
            exitMenuItem.Text = strings.contextMenuExit;
            hideOnStartupCheckBox.Text = strings.hideOnStartup;
        }

        // This timer ticks approx. 60 times a second (overkill?)
        void UpdateTimerTick(object sender, EventArgs e)
        {
            // Set the icons for the NotifyIcons depending on the key state
            if (enableNumIcon.Checked && !showNoIcons.Checked)
                numLockIcon.Icon = KeyHelper.isNumlockActive ? NumOn : NumOff;
            else
                numLockIcon.Icon = null;

            if (enableCapsIcon.Checked && !showNoIcons.Checked)
                capsLockIcon.Icon = KeyHelper.isCapslockActive ? CapsOn : CapsOff;
            else
                capsLockIcon.Icon = null;

            if (enableScrollIcon.Checked && !showNoIcons.Checked)
                scrollLockIcon.Icon = KeyHelper.isScrolllockActive ? ScrollOn : ScrollOff;
            else
                scrollLockIcon.Icon = null;

            generalIcon.Visible =
                !(enableNumIcon.Checked && !showNoIcons.Checked) &&
                !(enableCapsIcon.Checked && !showNoIcons.Checked) &&
                !(enableScrollIcon.Checked && !showNoIcons.Checked)
            ;

            // Handle the overlay
            if (numState != KeyHelper.isNumlockActive && enableNumInd.Checked && !showNoNotification.Checked)
                ShowOverlay(
                    KeyHelper.isNumlockActive ?
                        (SettingsManager.Get<string>("customMessageNumOn").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageNumOn") : string.Format(strings.keyIsOn, strings.numLock)) :
                        (SettingsManager.Get<string>("customMessageNumOff").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageNumOff") : string.Format(strings.keyIsOff, strings.numLock)),
                    KeyHelper.isNumlockActive);
            //ShowOverlay("Numlock is " + (KeyHelper.isNumlockActive ? "on" : "off"), KeyHelper.isNumlockActive);

            if (capsState != KeyHelper.isCapslockActive && enableCapsInd.Checked && !showNoNotification.Checked)
                ShowOverlay(
                    KeyHelper.isCapslockActive ?
                        (SettingsManager.Get<string>("customMessageCapsOn").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageCapsOn") : string.Format(strings.keyIsOn, strings.capsLock)) :
                        (SettingsManager.Get<string>("customMessageCapsOff").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageCapsOff") : string.Format(strings.keyIsOff, strings.capsLock)),
                    KeyHelper.isCapslockActive);

            if (scrollState != KeyHelper.isScrolllockActive && enableScrollInd.Checked && !showNoNotification.Checked)
                ShowOverlay(
                    KeyHelper.isScrolllockActive ?
                        (SettingsManager.Get<string>("customMessageScrollOn").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageScrollOn") : string.Format(strings.keyIsOn, strings.scrollLock)) :
                        (SettingsManager.Get<string>("customMessageScrollOff").Trim().Length > 0 ? SettingsManager.Get<string>("customMessageScrollOff") : string.Format(strings.keyIsOff, strings.scrollLock)),
                    KeyHelper.isScrolllockActive);

            // Reset the values
            numState = KeyHelper.isNumlockActive;
            capsState = KeyHelper.isCapslockActive;
            scrollState = KeyHelper.isScrolllockActive;
        }

        void ShowOverlay(string message, bool isActive)
        {
            int timeOut = SettingsManager.Get<int>("indDisplayTime");
            var alwaysShow = SettingsManager.Get<bool>("alwaysShowWhenActive") && isActive;
            if (Application.OpenForms.OfType<IndicatorOverlay>().Any() && Application.OpenForms.OfType<IndicatorOverlay>().Where(f => !f.IsDisposed).Any())
            {
                IndicatorOverlay indicatorOverlay = Application.OpenForms.OfType<IndicatorOverlay>().Where(f => !f.IsDisposed).First();
                indicatorOverlay.UpdateIndicator(
                      message
                    , timeOut
                    , isActive ? SettingsManager.Get<Color>("indBgColourActive") : SettingsManager.Get<Color>("indBgColourInactive")
                    , isActive ? SettingsManager.Get<Color>("indFgColourActive") : SettingsManager.Get<Color>("indFgColourInactive")
                    , isActive ? SettingsManager.Get<Color>("indBdColourActive") : SettingsManager.Get<Color>("indBdColourInactive")
                    , SettingsManager.Get<int>("bdSize")
                    , SettingsManager.GetOrDefault<Font>("indFont")
                    , SettingsManager.Get<IndicatorDisplayPosition>("overlayPosition")
                    , SettingsManager.Get<int>("indOpacity")
                    , alwaysShow
                );
            }
            else
            {
                    IndicatorOverlay indicatorOverlay = new IndicatorOverlay(
                          message
                        , timeOut
                        , isActive ? SettingsManager.Get<Color>("indBgColourActive") : SettingsManager.Get<Color>("indBgColourInactive")
                        , isActive ? SettingsManager.Get<Color>("indFgColourActive") : SettingsManager.Get<Color>("indFgColourInactive")
                        , isActive ? SettingsManager.Get<Color>("indBdColourActive") : SettingsManager.Get<Color>("indBdColourInactive")
                        , SettingsManager.Get<int>("bdSize")
                        , SettingsManager.GetOrDefault<Font>("indFont")
                        , SettingsManager.Get<IndicatorDisplayPosition>("overlayPosition")
                        , SettingsManager.Get<int>("indOpacity")
                        , alwaysShow
                    );
                    if (!indicatorOverlay.IsDisposed)
                        indicatorOverlay.Show();
            }
        }
        void ShowNoIconsCheckedChanged(object sender, EventArgs e)
        {
            iconsGroup.Enabled = !showNoIcons.Checked;
            SettingsManager.Set("noIco", showNoIcons.Checked);
            SettingsManager.Save();
        }
        void ShowNoNotificationCheckedChanged(object sender, EventArgs e)
        {
            indicatorGroup.Enabled = !showNoNotification.Checked;
            SettingsManager.Set("noInd", showNoNotification.Checked);
            SettingsManager.Save();
        }

        void handleVersion(string xmlData)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string currentVersion = fvi.FileVersion;

                XDocument doc = XDocument.Parse(xmlData);

                IEnumerable<XElement> parent = doc.Descendants("cli");

                string latestVersion = parent.Descendants()
                                             .Where(x => (string)x.Attribute("name") == "version_number")
                                             .FirstOrDefault()
                                             .Value;

                string release_date = parent.Descendants()
                                            .Where(x => (string)x.Attribute("name") == "release_date")
                                            .FirstOrDefault()
                                            .Value;

                string release_url = parent.Descendants()
                                           .Where(x => (string)x.Attribute("name") == "release_url")
                                           .FirstOrDefault()
                                           .Value;

                string download_url = parent.Descendants()
                                            .Where(x => (string)x.Attribute("name") == "download_url")
                                            .FirstOrDefault()
                                            .Value;

                string changelog = parent.Descendants()
                                         .Where(x => (string)x.Attribute("name") == "changelog")
                                         .FirstOrDefault()
                                         .Value;

                Version cVersion = new Version(currentVersion);
                Version lVersion = new Version(latestVersion);

#if !DEBUG
                if (lVersion > cVersion)
#endif
                {
                    UpdateDialog ud = new UpdateDialog();
                    ud.ShowInTaskbar = isHidden;
                    ud.SetNewVersion(lVersion);
                    ud.changelogRtf.Rtf = changelog;
                    ud.infoLabel.Text = string.Format(strings.updateInfoFormat, latestVersion, release_date);
                    DialogResult res = ud.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        DownloadDialog dd = new DownloadDialog();
                        dd.DownloadURL = download_url;
                        dd.ShowDialog();
                    }
                    else if (res == DialogResult.Ignore) // Download manually
                    {
                        Process.Start(release_url + "&ov=" + currentVersion);
                    }
                }
            }
            catch (Exception)
            {

            }

            checkForUpdatesButton.Text = strings.checkForUpdates;
            checkForUpdatesButton.Enabled = true;
        }

        void doVersionCheck(bool isManualCheck)
        {
            VersionCheck.IsLatestVersion(handleVersion, isManualCheck);
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string copyright = fvi.LegalCopyright;
            aboutText.Text = string.Format(resources.GetString("aboutTextFormat"), version, copyright);

            if (SettingsManager.Get<bool>("checkForUpdates"))
                doVersionCheck(false);
        }

        void ExitApplicationClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(strings.exitMessage, "CapsLock Indicator", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                shouldClose = true;
                Close();
            }
        }
        void HideWindowClick(object sender, EventArgs e)
        {
            HideForm();
        }

        private void HideForm()
        {
            //generalIcon.Visible = true;
            //generalIcon.ShowBalloonTip(100);
            Hide();
            isHidden = true;
            Opacity = 1;
        }

        void GeneralIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            Focus();
            generalIcon.Visible = false;
            isHidden = false;
            ShowInTaskbar = true;
        }

        private void enableNumIcon_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("numIco", enableNumIcon.Checked);
            SettingsManager.Save();
        }

        private void enableCapsIcon_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("capsIco", enableCapsIcon.Checked);
            SettingsManager.Save();
        }

        private void enableScrollIcon_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("scrollIco", enableScrollIcon.Checked);
            SettingsManager.Save();
        }

        private void enableNumInd_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("numInd", enableNumInd.Checked);
            SettingsManager.Save();
        }

        private void enableCapsInd_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("capsInd", enableCapsInd.Checked);
            SettingsManager.Save();
        }

        private void enableScrollInd_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("scrollInd", enableScrollInd.Checked);
            SettingsManager.Save();
        }

        private void indSettings_Click(object sender, EventArgs e)
        {
            IndSettingsWindow indSettingsWindow = new IndSettingsWindow();
            indSettingsWindow.ShowDialog();
        }

        private void checkForUpdatesButton_Click(object sender, EventArgs e)
        {
            checkForUpdatesButton.Enabled = false;
            checkForUpdatesButton.Text = strings.checkingForUpdates;
            doVersionCheck(true);
        }

        private void startonlogonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (startonlogonCheckBox.Checked)
                rk.SetValue("CapsLock Indicator", Application.ExecutablePath);
            else
                rk.DeleteValue("CapsLock Indicator", false);
        }

        private void hideOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("hideOnStartup", hideOnStartupCheckBox.Checked);
            SettingsManager.Save();
        }


        // This timer is required for some reason
        private void hideWindowTimer_Tick(object sender, EventArgs e)
        {
            hideWindowTimer.Stop();
            hideWindow.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !shouldClose)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        private void lnkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://jonaskohl.de/");
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            Focus();
            generalIcon.Visible = false;
            isHidden = false;
            ShowInTaskbar = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shouldClose = true;
            Close();
        }

        private void appNameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cli.jonaskohl.de/");
        }

        private void checkForUpdatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("checkForUpdates", checkForUpdatedCheckBox.Checked);
            SettingsManager.Save();
        }

        private void localeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownLocale locale = (DropDownLocale)localeComboBox.SelectedItem;

            if (locale.localeString == "__default")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
                previousLocaleIndex = localeComboBox.SelectedIndex;
            }
            else if (locale.localeString == "--get-more")
            {
                localeComboBox.SelectedIndex = previousLocaleIndex;
                Process.Start("https://cli.jonaskohl.de/!/translations#download-translations");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale.localeString);
                previousLocaleIndex = localeComboBox.SelectedIndex;
            }

            SettingsManager.Set("selectedUICulture", localeComboBox.SelectedIndex);
            SettingsManager.Save();

            ApplyLocales();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.P)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ReloadIcons();
            }
        }

        private void localeComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var itm = (DropDownLocale)e.ListItem;
            if (itm.localeString == "--get-more")
                e.Value = strings.downloadMoreTranslations;
            else if (itm.localeString == "__default")
                e.Value = itm.displayText;
            else if (itm.localeString == "--ln")
                e.Value = "--LINE--";
            else
                e.Value = string.Format("{0} ({1})", itm.displayText, itm.localeString);
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            Focus();
            generalIcon.Visible = false;
            isHidden = false;
            ShowInTaskbar = true;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            shouldClose = true;
            Close();
        }
    }
}
