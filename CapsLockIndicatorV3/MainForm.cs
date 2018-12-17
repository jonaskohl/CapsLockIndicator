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

        // Determines if Application Exit button is pressed
        bool exitsource;

		public MainForm()
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            if (Properties.Settings.Default.versionNo != version)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.versionNo = version;
                Properties.Settings.Default.Save();
            }


            Properties.Settings.Default.beta_enableDarkMode = Properties.Settings.Default.beta_enableDarkMode;
            Properties.Settings.Default.Save();

			// Initialize component
			InitializeComponent();
			
			// Load "resources.resx" into a ResourceManager to access its resources
			resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());

            // Load the icons into variables
            ReloadIcons();
			
			// Set the values
			numState = KeyHelper.isNumlockActive;
			capsState = KeyHelper.isCapslockActive;
			scrollState = KeyHelper.isScrolllockActive;

            // Load settings
            enableNumIcon.Checked = Properties.Settings.Default.numIco;
            enableCapsIcon.Checked = Properties.Settings.Default.capsIco;
            enableScrollIcon.Checked = Properties.Settings.Default.scrollIco;

            enableNumInd.Checked = Properties.Settings.Default.numInd;
            enableCapsInd.Checked = Properties.Settings.Default.capsInd;
            enableScrollInd.Checked = Properties.Settings.Default.scrollInd;

            showNoIcons.Checked = Properties.Settings.Default.noIco;
            showNoNotification.Checked = Properties.Settings.Default.noInd;

            iconsGroup.Enabled = !showNoIcons.Checked;
            indicatorGroup.Enabled = !showNoNotification.Checked;

            if (Properties.Settings.Default.beta_enableDarkMode)
            {
                const int value = 0x00000042;
                BackColor = Color.FromArgb(0x000000FF, value, value, value);
                ForeColor = Color.White;

                iconsGroup.ForeColor = Color.White;
                indicatorGroup.ForeColor = Color.White;
            }

            // Check if application is in startup
            startonlogonCheckBox.Checked = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "CapsLock Indicator", null) != null;

            // Hides the window on startup if enabled
            if (Properties.Settings.Default.hideOnStartup)
            {
                hideOnStartupCheckBox.Checked = true;
                hideWindowTimer.Start();
            }

            checkForUpdatedCheckBox.Checked = Properties.Settings.Default.checkForUpdates;

            AddCultures();

            ApplyLocales();
        }

        private void ReloadIcons()
        {
            CapsOff = File.Exists("caps0.ico") ? Icon.ExtractAssociatedIcon("caps0.ico") : (Icon)resources.GetObject("CLIv3_Caps_Off");
            CapsOn = File.Exists("caps1.ico") ? Icon.ExtractAssociatedIcon("caps1.ico") : (Icon)resources.GetObject("CLIv3_Caps_On");

            NumOff = File.Exists("num0.ico") ? Icon.ExtractAssociatedIcon("num0.ico") : (Icon)resources.GetObject("CLIv3_Num_Off");
            NumOn = File.Exists("num1.ico") ? Icon.ExtractAssociatedIcon("num1.ico") : (Icon)resources.GetObject("CLIv3_Num_On");

            ScrollOff = File.Exists("scroll0.ico") ? Icon.ExtractAssociatedIcon("scroll0.ico") : (Icon)resources.GetObject("CLIv3_Scroll_Off");
            ScrollOn = File.Exists("scroll1.ico") ? Icon.ExtractAssociatedIcon("scroll1.ico") : (Icon)resources.GetObject("CLIv3_Scroll_On");
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

            if (Properties.Settings.Default.selectedUICulture < 0)
                localeComboBox.SelectedIndex = selectIndex;
            else if (Properties.Settings.Default.selectedUICulture < localeComboBox.Items.Count)
                localeComboBox.SelectedIndex = Properties.Settings.Default.selectedUICulture;
            else
                localeComboBox.SelectedIndex = 0;
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
            exitToolStripMenuItem.Text = strings.contextMenuExit;
            hideOnStartupCheckBox.Text = strings.hideOnStartup;
        }
		
		// This timer ticks approx. 60 times a second (overkill?)
		void UpdateTimerTick(object sender, EventArgs e)
		{
			// Set the icons for the NotifyIcons depending on the key state
			if (enableNumIcon.Checked && !showNoIcons.Checked)
				numLockIcon.Icon = KeyHelper.isNumlockActive ? NumOn: NumOff;
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

            // Handle the overlay
            if (numState != KeyHelper.isNumlockActive && enableNumInd.Checked && !showNoNotification.Checked)
                ShowOverlay(string.Format(KeyHelper.isNumlockActive ? strings.keyIsOn : strings.keyIsOff, strings.numLock), KeyHelper.isNumlockActive);
				//ShowOverlay("Numlock is " + (KeyHelper.isNumlockActive ? "on" : "off"), KeyHelper.isNumlockActive);
			
			if (capsState != KeyHelper.isCapslockActive && enableCapsInd.Checked && !showNoNotification.Checked)
                ShowOverlay(string.Format(KeyHelper.isCapslockActive ? strings.keyIsOn : strings.keyIsOff, strings.capsLock), KeyHelper.isCapslockActive);

            if (scrollState != KeyHelper.isScrolllockActive && enableScrollInd.Checked && !showNoNotification.Checked)
                ShowOverlay(string.Format(KeyHelper.isScrolllockActive ? strings.keyIsOn : strings.keyIsOff, strings.scrollLock), KeyHelper.isScrolllockActive);

            // Reset the values
            numState = KeyHelper.isNumlockActive;
			capsState = KeyHelper.isCapslockActive;
			scrollState = KeyHelper.isScrolllockActive;
		}
		
		void ShowOverlay(string message, bool isActive)
		{
            int timeOut = Properties.Settings.Default.indDisplayTime;
            if (Application.OpenForms.OfType<IndicatorOverlay>().Any())
            {
                IndicatorOverlay indicatorOverlay = Application.OpenForms.OfType<IndicatorOverlay>().First();
                indicatorOverlay.UpdateIndicator(
                      message
                    , timeOut
                    , isActive ? Properties.Settings.Default.indBgColourActive : Properties.Settings.Default.indBgColourInactive
                    , isActive ? Properties.Settings.Default.indFgColourActive : Properties.Settings.Default.indFgColourInactive
                    , isActive ? Properties.Settings.Default.indBdColourActive : Properties.Settings.Default.indBdColourInactive
                    , Properties.Settings.Default.indFont
                    , Properties.Settings.Default.overlayPosition
                );
            }
            else
            {
                IndicatorOverlay indicatorOverlay = new IndicatorOverlay(
                      message
                    , timeOut
                    , isActive ? Properties.Settings.Default.indBgColourActive : Properties.Settings.Default.indBgColourInactive
                    , isActive ? Properties.Settings.Default.indFgColourActive : Properties.Settings.Default.indFgColourInactive
                    , isActive ? Properties.Settings.Default.indBdColourActive : Properties.Settings.Default.indBdColourInactive
                    , Properties.Settings.Default.indFont
                    , Properties.Settings.Default.overlayPosition
                );
                indicatorOverlay.Show();
            }
		}
		void ShowNoIconsCheckedChanged(object sender, EventArgs e)
		{
			iconsGroup.Enabled = !showNoIcons.Checked;
            Properties.Settings.Default.noIco = showNoIcons.Checked;
            Properties.Settings.Default.Save();
        }
		void ShowNoNotificationCheckedChanged(object sender, EventArgs e)
		{
			indicatorGroup.Enabled = !showNoNotification.Checked;
            Properties.Settings.Default.noInd = showNoNotification.Checked;
            Properties.Settings.Default.Save();
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

                if (lVersion > cVersion)
                {
                    UpdateDialog ud = new UpdateDialog();
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

        void doVersionCheck()
        {
            VersionCheck.IsLatestVersion(handleVersion);
        }

        void MainFormLoad(object sender, EventArgs e)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string copyright = fvi.LegalCopyright;
            aboutText.Text = String.Format(resources.GetString("aboutTextFormat"), version, copyright);

            if (Properties.Settings.Default.checkForUpdates)
                doVersionCheck();
        }

		void ExitApplicationClick(object sender, EventArgs e)
		{
            //Set exitsource to true signifying Exit Application button was pressed.
            exitsource = true;
            Close();
        }
		void HideWindowClick(object sender, EventArgs e)
		{
            //Call HideWindow to hide the window.
            HideWindow();
		}

        void HideWindow()
        {
            generalIcon.Visible = true;
            generalIcon.ShowBalloonTip(100);
            Hide();
            isHidden = true;
        }

		void GeneralIconMouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			Focus();
			generalIcon.Visible = false;
            isHidden = false;
		}

        private void enableNumIcon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.numIco = enableNumIcon.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableCapsIcon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.capsIco = enableCapsIcon.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableScrollIcon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.scrollIco = enableScrollIcon.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableNumInd_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.numInd = enableNumInd.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableCapsInd_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.capsInd = enableCapsInd.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableScrollInd_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.scrollInd = enableScrollInd.Checked;
            Properties.Settings.Default.Save();
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
            doVersionCheck();
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
            Properties.Settings.Default.hideOnStartup = hideOnStartupCheckBox.Checked;
            Properties.Settings.Default.Save();
        }


        // This timer is required for some reason
        private void hideWindowTimer_Tick(object sender, EventArgs e)
        {
            hideWindowTimer.Stop();
            hideWindow.PerformClick();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Check if user closed application. If not, then application should terminate in Program.cs and/or initial parent.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //If Exit Application button or Exit in context menu pressed, prompt the ask message. Else, application was closed via close window window control 
                if (exitsource == true)
                {
                    if (MessageBox.Show(strings.exitMessage, "CapsLock Indicator", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        Application.Exit();
                    else
                    {
                        //Stop application from exiting and change exitsource back to false.
                        e.Cancel = true;
                        exitsource = false;
                    }
                }
                else
                {
                    //Stop application from exiting and call HideWindow() to hide the window.
                    e.Cancel = true;
                    HideWindow();
                }
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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set exitsource to true signifying Exit item in notification icon was pressed.
            exitsource = true;
            Close();
        }

        private void appNameLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cli.jonaskohl.de/");
        }

        private void checkForUpdatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.checkForUpdates = checkForUpdatedCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void localeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownLocale locale = (DropDownLocale)localeComboBox.SelectedItem;

            if (locale.localeString == "__default")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;
            } else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locale.localeString);
            }

            Properties.Settings.Default.selectedUICulture = localeComboBox.SelectedIndex;
            Properties.Settings.Default.Save();

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

        private void generalIconContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
