/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
 */

//#define _DEBUG_FEATURE_EOL

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
using System.ComponentModel;
using System.Text;
using System.Net;

namespace CapsLockIndicatorV3
{
    public partial class MainForm : DarkModeForm
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

        const int UNSUPPORTED_REASON_CLI = 0;
        const int UNSUPPORTED_REASON_WIN = 1;

        readonly string version;
        readonly string oldVersion;

        private int unsupportedReason = -1;

        public MainForm()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            version = fvi.FileVersion;

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

            if (SettingsManager.Get<bool>("upgradeRequired"))
            {
                SettingsManager.Set("upgradeRequired", false);
            }

            oldVersion = SettingsManager.Get<string>("versionNo");

            SettingsManager.Set("versionNo", version);

            iconsGroup.Enabled = !showNoIcons.Checked;
            indicatorGroup.Enabled = !showNoNotification.Checked;

            generalIcon.ContextMenu =
                numLockIcon.ContextMenu =
                capsLockIcon.ContextMenu =
                scrollLockIcon.ContextMenu =
                contextMenu1;

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += MainForm_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };

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

#if DEBUG && _DEBUG_FEATURE_EOL
            unsupportedReason = 1;
            ApplyEOLStrings();
            tableLayoutPanel3.Visible = true;
#else
            tableLayoutPanel3.Visible = !SettingsManager.Get<bool>("supressEOLMessage") && Environment.OSVersion.Version < new Version(6, 3);
#endif
            label1.Text = string.Format(label1.Text, GetOSName());

            var scale = Native.GetScalingFactor();

            pictureBox1.Image = SysIcons.GetSystemIcon(SysIcons.SHSTOCKICONID.SIID_SHIELD, SysIcons.IconSize.Small).ToBitmap();

            if (Environment.OSVersion.Version >= new Version(6, 2))
            {
                var sz = (int)(scale * 16);
                dismissButton.Image = IconExtractor.GetIcon("imageres.dll", 235, sz)?.ToBitmap();
                dismissButton.FlatStyle = FlatStyle.Flat;
                dismissButton.FlatAppearance.BorderSize = 0;
                dismissButton.FlatAppearance.MouseOverBackColor =
                dismissButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                dismissButton.Padding = Padding.Empty;
                dismissButton.Width = dismissButton.Height = sz;
                dismissButton.Text = "";
                dismissButton.Cursor = Cursors.Hand;
            }

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

#if !DEBUG && _DEBUG_FEATURE_EOL
            if (!SettingsManager.Get<bool>("supressEOLMessage"))
                CheckSupport();
#endif

            displayTimeSlider.Value = SettingsManager.Get<int>("indDisplayTime") > 0 ? SettingsManager.Get<int>("indDisplayTime") : 2001;
            displayTimeLabel.Text = displayTimeSlider.Value < 2001 ? string.Format("{0} ms", displayTimeSlider.Value) : strings.permanentIndicator;

            opacitySlider.Value = SettingsManager.Get<int>("indOpacity");
            opacityLabel.Text = string.Format("{0} %", opacitySlider.Value);

            bdSizeSlider.Value = SettingsManager.Get<int>("bdSize");
            bdSizeLabel.Text = string.Format("{0}", bdSizeSlider.Value);

            backgroundColourActivatedPreview.BackColor = SettingsManager.Get<Color>("indBgColourActive");
            backgroundColourDeactivatedPreview.BackColor = SettingsManager.Get<Color>("indBgColourInactive");

            foregroundColourActivatedPreview.BackColor = SettingsManager.Get<Color>("indFgColourActive");
            foregroundColourDeactivatedPreview.BackColor = SettingsManager.Get<Color>("indFgColourInactive");

            borderColourActivatedPreview.BackColor = SettingsManager.Get<Color>("indBdColourActive");
            borderColourDeactivatedPreview.BackColor = SettingsManager.Get<Color>("indBdColourInactive");

            fontButton.Font = SettingsManager.GetOrDefault<Font>("indFont");

            onlyShowWhenActiveCheckBox.Checked = SettingsManager.Get<bool>("alwaysShowWhenActive");

            darkModeCheckBox.Enabled = DarkModeProvider.SystemSupportsDarkMode;

            switch (SettingsManager.Get<IndicatorDisplayPosition>("overlayPosition"))
            {
                case IndicatorDisplayPosition.TopLeft:
                    positionTopLeft.Checked = true;
                    break;
                case IndicatorDisplayPosition.TopCenter:
                    positionTopCenter.Checked = true;
                    break;
                case IndicatorDisplayPosition.TopRight:
                    positionTopRight.Checked = true;
                    break;
                case IndicatorDisplayPosition.MiddleLeft:
                    positionMiddleLeft.Checked = true;
                    break;
                case IndicatorDisplayPosition.MiddleCenter:
                    positionMiddleCenter.Checked = true;
                    break;
                case IndicatorDisplayPosition.MiddleRight:
                    positionMiddleRight.Checked = true;
                    break;
                case IndicatorDisplayPosition.BottomLeft:
                    positionBottomLeft.Checked = true;
                    break;
                case IndicatorDisplayPosition.BottomCenter:
                    positionBottomCenter.Checked = true;
                    break;
                case IndicatorDisplayPosition.BottomRight:
                    positionBottomRight.Checked = true;
                    break;
                default:
                    break;
            }

            darkModeCheckBox.Checked = DarkModeProvider.IsDark;
            searchOnResumeCheckBox.Checked = SettingsManager.Get<bool>("searchForUpdatesAfterResume");

            darkModeCheckBox.CheckedChanged += DarkModeCheckBox_CheckedChanged;
            searchOnResumeCheckBox.CheckedChanged += SearchOnResumeCheckBox_CheckedChanged;

            var oldVersionVer = Version.Parse(oldVersion);

            if (oldVersionVer < Versions.SettingsToTabs)
                tutorialTimer.Start();

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(tabControl1.SelectedTab.Text);
            var sz = ClientSize;
            sz.Height = int.Parse(tabControl1.SelectedTab.Tag.ToString());
            ClientSize = sz;
        }

        private void tutorialTimer_Tick(object sender, EventArgs e)
        {
            var pt = GetRectCenter(tabControl1.GetTabRect(1));
            tutorialTimer.Stop();
            tutorialToolTip.Active = true;
            // Hack to fix incorrect step/tip placement on first invokation
            // See: https://stackoverflow.com/a/8716963
            tutorialToolTip.Show(string.Empty, tabControl1, pt, 1);
            tutorialToolTip.Show(
                strings.settingsChangedToolTip,
                tabControl1,
                pt, 6000);
        }

        private Point GetRectCenter(Rectangle rectangle)
        {
            var p = new Point();
            p.X = rectangle.X + rectangle.Width / 2;
            p.Y = rectangle.Y + rectangle.Height / 2;
            return p;
        }

        private void CheckSupport()
        {
            var ub = new UriBuilder("https://cli.jonaskohl.de/clientsupported");
            var qb = new QueryBuilder();
#if DEBUG
            qb.Append("v", "dev");
#else
            qb.Append("v", version);
#endif
            qb.Append("w", GetOSVersion());
            ub.Query = qb.ToString();

            var wc = new WebClient();
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            wc.DownloadStringAsync(ub.Uri);
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            (sender as WebClient).Dispose();

            try
            {
                var (client, os, supportStatus, reason) = e.Result.Split('\n');
                var intReason = reason.Length > 0 ? int.Parse(reason) : -1;

                if (supportStatus == "YES")
                {
                    tableLayoutPanel3.Visible = false;
                    return;
                }
                else
                {
                    unsupportedReason = intReason;
                    ApplyEOLStrings();
                    tableLayoutPanel3.Visible = true;
                }
            }
            catch { }
        }

        private void ApplyEOLStrings()
        {
            string[] messages = new[]
            {
                strings.unsupportedCLI,
                strings.unsupportedWin
            };

            if (unsupportedReason < 0 || unsupportedReason >= messages.Length)
                return;

            var sf = new StringFormatter(messages[unsupportedReason]);
            sf.Add("os", GetOSName());
            sf.Add("version", version);
            label1.Text = sf;
        }

        private static string GetOSVersion()
        {
            var maj = Environment.OSVersion.Version.Major;
            var min = Environment.OSVersion.Version.Minor;
            var sb = new StringBuilder();
            sb.Append(maj);
            sb.Append(".");
            sb.Append(min);
            if (maj >= 10)
            {
                sb.Append(".");
                sb.Append(GetReleaseId());
            }

            return sb.ToString();
        }

        private static string GetReleaseId()
        {
            var id = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();
            if (id.Length < 4)
                return id;
            var year = id.Substring(0, 2);
            var intYear = int.Parse(year);
            if (intYear >= 20)
            {
                if (intYear > 20 && id.EndsWith("04"))
                    return year + "H1";
                else if (id.EndsWith("09"))
                    return year + "H2";
                else
                    return id;
            }
            return id;
        }

        private static string GetOSName()
        {
            var osVer = Environment.OSVersion.Version;
            var version = osVer.Major.ToString() + "." + osVer.Minor.ToString();
            switch (version)
            {
                case "10.0": return ("Windows 10 " + GetReleaseId()).Trim();
                case "6.3": return "Windows 8.1";
                case "6.2": return "Windows 8";
                case "6.1": return "Windows 7";
                case "6.0": return "Windows Vista";
                case "5.2": return "Windows XP 64-Bit Edition";
                case "5.1": return "Windows XP";
                case "5.0": return "Windows 2000";
            }
            return Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\", "ProductName", "unknown").ToString();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                if (SettingsManager.Get<bool>("searchForUpdatesAfterResume"))
                    doVersionCheck(false);

                foreach (var i in Application.OpenForms.OfType<IndicatorOverlay>().Where(f => !f.IsDisposed))
                    i.Close();
            }
        }

        private void MainForm_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);
            generalIcon.Icon = (Icon)resources.GetObject("generalIcon");
            Icon = (Icon)resources.GetObject("CLIv3_Icon" + (dark ? "_Dark" : ""));

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
            displayTimeGroup.ForeColor =
            displayTimeLabel.ForeColor =
            fontGroupBox.ForeColor =
            fontButton.ForeColor =
            positionGroup.ForeColor =
            opacityGroup.ForeColor =
            opacityLabel.ForeColor =
            coloursGroup.ForeColor =
            backgroundColourActivatedButton.ForeColor =
            backgroundColourDeactivatedButton.ForeColor =
            foregroundColourActivatedButton.ForeColor =
            foregroundColourDeactivatedButton.ForeColor =
            borderColourActivatedButton.ForeColor =
            borderColourDeactivatedButton.ForeColor =
            borderGroup.ForeColor =
            bdSizeLabel.ForeColor =
            onlyShowWhenActiveCheckBox.ForeColor =
            dark ? Color.White : SystemColors.WindowText;

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
            checkForUpdatedCheckBox.FlatStyle =
            localeComboBox.FlatStyle =
            onlyShowWhenActiveCheckBox.FlatStyle =
            darkModeCheckBox.FlatStyle =
            searchOnResumeCheckBox.FlatStyle =
            dark ? FlatStyle.Standard : FlatStyle.System;

            enableNumInd.DarkMode =
            enableCapsInd.DarkMode =
            enableScrollInd.DarkMode =
            enableNumIcon.DarkMode =
            enableCapsIcon.DarkMode =
            enableScrollIcon.DarkMode =
            showNoIcons.DarkMode =
            showNoNotification.DarkMode =
            startonlogonCheckBox.DarkMode =
            hideOnStartupCheckBox.DarkMode =
            checkForUpdatedCheckBox.DarkMode =
            mainToolTip.DarkMode =
            localeComboBox.DarkMode =
            onlyShowWhenActiveCheckBox.DarkMode =
            darkModeCheckBox.DarkMode =
            searchOnResumeCheckBox.DarkMode =
            dark;

            downloadIcons.LinkColor =
            dark ? Color.White : SystemColors.HotTrack;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;
            aboutPanelTopBorder.BackColor =
            appNameLabel.LinkColor =
            appNameLabel.ActiveLinkColor =
            dark ? Color.FromArgb(255, 196, 204, 238) : Color.FromArgb(255, 52, 77, 180); ;
            logo.Image = (Bitmap)resources.GetObject("logo" + (dark ? "_dark" : ""));

            foreach (TabPage p in tabControl1.TabPages)
            {
                p.BackColor = dark ? Color.FromArgb(255, 25, 25, 25) : SystemColors.Window;
                p.ForeColor = dark ? Color.White : SystemColors.WindowText;
            }
            tabControl1.MyBackColor = BackColor;
            tabControl1.DarkMode = dark;

            ControlScheduleSetDarkMode(checkForUpdatesButton, dark);
            ControlScheduleSetDarkMode(exitApplication, dark);
            ControlScheduleSetDarkMode(hideWindow, dark);
            ControlScheduleSetDarkMode(enableNumInd, dark);
            ControlScheduleSetDarkMode(enableCapsInd, dark);
            ControlScheduleSetDarkMode(enableScrollInd, dark);
            ControlScheduleSetDarkMode(enableNumIcon, dark);
            ControlScheduleSetDarkMode(enableCapsIcon, dark);
            ControlScheduleSetDarkMode(enableScrollIcon, dark);
            ControlScheduleSetDarkMode(localeComboBox, dark);
            ControlScheduleSetDarkMode(advSettingsButton, dark);
            ControlScheduleSetDarkMode(fontButton, dark);
            ControlScheduleSetDarkMode(backgroundColourActivatedButton, dark);
            ControlScheduleSetDarkMode(backgroundColourDeactivatedButton, dark);
            ControlScheduleSetDarkMode(foregroundColourActivatedButton, dark);
            ControlScheduleSetDarkMode(foregroundColourDeactivatedButton, dark);
            ControlScheduleSetDarkMode(borderColourActivatedButton, dark);
            ControlScheduleSetDarkMode(borderColourDeactivatedButton, dark);
            ControlScheduleSetDarkMode(positionTopLeft, dark);
            ControlScheduleSetDarkMode(positionTopCenter, dark);
            ControlScheduleSetDarkMode(positionTopRight, dark);
            ControlScheduleSetDarkMode(positionMiddleLeft, dark);
            ControlScheduleSetDarkMode(positionMiddleCenter, dark);
            ControlScheduleSetDarkMode(positionMiddleRight, dark);
            ControlScheduleSetDarkMode(positionBottomLeft, dark);
            ControlScheduleSetDarkMode(positionBottomCenter, dark);
            ControlScheduleSetDarkMode(positionBottomRight, dark);
            ControlScheduleSetDarkMode(displayTimeSlider, dark);
            ControlScheduleSetDarkMode(opacitySlider, dark);
            ControlScheduleSetDarkMode(bdSizeSlider, dark);
        }

        public void ReloadIcons(bool isUserInitiated = false)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            CapsOff = File.Exists(Path.Combine(dir, "caps0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "caps0.ico")) : (Icon)resources.GetObject("CLIv3_Caps_Off");
            CapsOn = File.Exists(Path.Combine(dir, "caps1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "caps1.ico")) : (Icon)resources.GetObject("CLIv3_Caps_On");

            NumOff = File.Exists(Path.Combine(dir, "num0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "num0.ico")) : (Icon)resources.GetObject("CLIv3_Num_Off");
            NumOn = File.Exists(Path.Combine(dir, "num1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "num1.ico")) : (Icon)resources.GetObject("CLIv3_Num_On");

            ScrollOff = File.Exists(Path.Combine(dir, "scroll0.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "scroll0.ico")) : (Icon)resources.GetObject("CLIv3_Scroll_Off");
            ScrollOn = File.Exists(Path.Combine(dir, "scroll1.ico")) ? Icon.ExtractAssociatedIcon(Path.Combine(dir, "scroll1.ico")) : (Icon)resources.GetObject("CLIv3_Scroll_On");

            if (isUserInitiated)
                ShowOverlayInfo(strings.reloadedIconsInfo);
        }

        private void AddCultures()
        {
            int index = 1;
            int selectIndex = 0;

            localeComboBox.Items.Clear();

            localeComboBox.Items.Add(new DropDownLocale("en-GB", "English (United Kingdom)"));

            var cultures = GetSupportedCulture();

            foreach (CultureInfo c in cultures)
            {
                if (c.Name.Trim().Length < 1)
                    continue;
                else
                {
                    localeComboBox.Items.Add(new DropDownLocale(c.Name, c.NativeName));

                    if (c.Name.Length > 2 ? c.Name == Thread.CurrentThread.CurrentUICulture.Name : c.TwoLetterISOLanguageName == Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
                        selectIndex = index;
                    // if (c.TwoLetterISOLanguageName == Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
                    index++;
                }
            }

            //if (SettingsManager.Get<int>("selectedUICulture") < 0)
            //    localeComboBox.SelectedIndex = selectIndex;
            //else if (SettingsManager.Get<int>("selectedUICulture") < localeComboBox.Items.Count)
            //    localeComboBox.SelectedIndex = SettingsManager.Get<int>("selectedUICulture");
            //else
            //    localeComboBox.SelectedIndex = 0;

            if (SettingsManager.Has("selectedUICulture"))
            {
                var legacySelectedUICulture = SettingsManager.Get<int>("selectedUICulture");
                SettingsManager.Unset("selectedUICulture");
                selectIndex = legacySelectedUICulture;
            }

            var cultureCodes = cultures.Select(c => c.Name.Length > 2 ? c.Name : c.TwoLetterISOLanguageName);
            var selLang = SettingsManager.Get<string>("selectedLanguage");

            if (selLang == "")
                localeComboBox.SelectedIndex = selectIndex;
            else if (cultureCodes.Contains(selLang))
                localeComboBox.SelectedIndex = cultureCodes.ToList().FindIndex(c => c == selLang);
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
            checkForUpdatesButton.Text = strings.checkForUpdates;
            startonlogonCheckBox.Text = strings.startOnLogon;
            generalIcon.BalloonTipText = strings.generalIconBalloonText;
            showToolStripMenuItem.Text = strings.contextMenuShow;
            showMenuItem.Text = strings.contextMenuShow;
            exitToolStripMenuItem.Text = strings.contextMenuExit;
            exitMenuItem.Text = strings.contextMenuExit;
            hideOnStartupCheckBox.Text = strings.hideOnStartup;
            mainToolTip.SetToolTip(checkForUpdatedCheckBox, strings.autoCheckForUpdates);
            displayTimeGroup.Text = strings.displayTime;
            opacityGroup.Text = strings.opacity;
            fontGroupBox.Text = strings.fontGroup;
            coloursGroup.Text = strings.coloursGroup;
            fontButton.Text = string.Format(strings.keyIsOff, strings.capsLock);
            backgroundColourActivatedButton.Text = strings.backgroundColourActivatedButton;
            backgroundColourDeactivatedButton.Text = strings.backgroundColourDeactivatedButton;
            borderColourActivatedButton.Text = strings.borderColourActivatedButton;
            borderColourDeactivatedButton.Text = strings.borderColourDeactivatedButton;
            foregroundColourActivatedButton.Text = strings.foregroundColourActivatedButton;
            foregroundColourDeactivatedButton.Text = strings.foregroundColourDeactivatedButton;
            positionGroup.Text = strings.overlayPositionGroup;
            onlyShowWhenActiveCheckBox.Text = strings.showOverlayOnlyWhenActive;
            borderGroup.Text = strings.borderThicknessGroup;
            downloadIcons.Text = strings.downloadIcons;
            advSettingsButton.Text = strings.advancedSettings;
            tabPage3.Text = strings.tabGeneral;
            tabPage1.Text = strings.tabNotification;
            tabPage2.Text = strings.tabAdvancedOptions;
            darkModeCheckBox.Text = strings.darkModeOption;
            searchOnResumeCheckBox.Text = strings.searchForUpdatesOnResumeOption;
            mainToolTip.SetToolTip(dismissButton, strings.dismiss);

            ApplyEOLStrings();
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
            var showOnAllScreens = SettingsManager.Get<bool>("showNotificationOnAllScreens");
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
            }
        }

        void ShowOverlayInfo(string message)
        {
            int timeOut = SettingsManager.Get<int>("indDisplayTime");
            if (timeOut < 0)
                timeOut = 2000;
            var alwaysShow = false;
            if (Application.OpenForms.OfType<IndicatorOverlay>().Any() && Application.OpenForms.OfType<IndicatorOverlay>().Where(f => !f.IsDisposed).Any())
            {
                IndicatorOverlay indicatorOverlay = Application.OpenForms.OfType<IndicatorOverlay>().Where(f => !f.IsDisposed).First();
                indicatorOverlay.UpdateIndicator(
                      message
                    , timeOut
                    , SettingsManager.Get<Color>("indBgColourInactive")
                    , SettingsManager.Get<Color>("indFgColourInactive")
                    , SettingsManager.Get<Color>("indFgColourInactive")
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
                    , SettingsManager.Get<Color>("indBgColourInactive")
                    , SettingsManager.Get<Color>("indFgColourInactive")
                    , SettingsManager.Get<Color>("indFgColourInactive")
                    , SettingsManager.Get<int>("bdSize")
                    , SettingsManager.GetOrDefault<Font>("indFont")
                    , SettingsManager.Get<IndicatorDisplayPosition>("overlayPosition")
                    , SettingsManager.Get<int>("indOpacity")
                    , alwaysShow
                );
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

                    var rdate = DateTime.Parse(release_date, CultureInfo.InvariantCulture);
                    var release_date_formatted = rdate.ToLongDateString();

                    UpdateDialog ud = new UpdateDialog();
                    ud.ShowInTaskbar = isHidden;
                    ud.SetNewVersion(lVersion);
                    ud.changelogRtf.Rtf = changelog;
                    ud.infoLabel.Text = string.Format(strings.updateInfoFormat, latestVersion, release_date_formatted);
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

            //SettingsManager.Set("selectedUICulture", localeComboBox.SelectedIndex);
            SettingsManager.Set("selectedLanguage", locale.localeString);
            SettingsManager.Save();

            ApplyLocales();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.P)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                ReloadIcons(true);
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

        private void advSettings_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Hide();
        }



        private void displayTimeSlider_Scroll(object sender, EventArgs e)
        {
            SettingsManager.Set("indDisplayTime", displayTimeSlider.Value < 2001 ? displayTimeSlider.Value : -1);
            displayTimeLabel.Text = displayTimeSlider.Value < 2001 ? string.Format("{0} ms", displayTimeSlider.Value) : strings.permanentIndicator;
        }

        private void button1b_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SettingsManager.Save();
            Close();
        }

        private void displayTimeLabel_Click(object sender, EventArgs e)
        {
            if (displayTimeSlider.Value > 2000)
                return;
            NumberInputDialog numberInputDialog = new NumberInputDialog(displayTimeSlider.Value, displayTimeSlider.Minimum, displayTimeSlider.Maximum - 1);
            if (numberInputDialog.ShowDialog() == DialogResult.OK)
            {
                displayTimeSlider.Value = numberInputDialog.Value;
                SettingsManager.Set("indDisplayTime", numberInputDialog.Value);
                displayTimeLabel.Text = string.Format("{0} ms", displayTimeSlider.Value);
            }
        }

        private void backgroundColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indBgColourActive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indBgColourActive", mainColourPicker.Color);
            }
            backgroundColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void backgroundColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indBgColourInactive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indBgColourInactive", mainColourPicker.Color);
            }
            backgroundColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void foregroundColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indFgColourActive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indFgColourActive", mainColourPicker.Color);
            }
            foregroundColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void foregroundColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indFgColourInactive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indFgColourInactive", mainColourPicker.Color);
            }
            foregroundColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void borderColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indBdColourActive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indBdColourActive", mainColourPicker.Color);
            }
            borderColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void borderColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = SettingsManager.Get<Color>("indBdColourInactive");
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indBdColourInactive", mainColourPicker.Color);
            }
            borderColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            indFontChooser.Font = SettingsManager.GetOrDefault<Font>("indFont");
            if (indFontChooser.ShowDialog() == DialogResult.OK)
            {
                SettingsManager.Set("indFont", indFontChooser.Font);
                fontButton.Font = indFontChooser.Font;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void positionButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton _sender = sender as RadioButton;
            string posName = _sender.Name.Substring(8);
            Enum.TryParse(posName, out IndicatorDisplayPosition position);
            SettingsManager.Set("overlayPosition", position);
        }

        private void opacityLabel_Click(object sender, EventArgs e)
        {
            NumberInputDialog numberInputDialog = new NumberInputDialog(opacitySlider.Value, opacitySlider.Minimum, opacitySlider.Maximum);
            if (numberInputDialog.ShowDialog() == DialogResult.OK)
            {
                opacitySlider.Value = numberInputDialog.Value;
                SettingsManager.Set("indOpacity", numberInputDialog.Value);
                opacityLabel.Text = string.Format("{0} %", opacitySlider.Value);
            }
        }

        private void opacitySlider_Scroll(object sender, EventArgs e)
        {
            SettingsManager.Set("indOpacity", opacitySlider.Value);
            opacityLabel.Text = string.Format("{0} %", opacitySlider.Value);
        }

        private void onlyShowWhenActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("alwaysShowWhenActive", onlyShowWhenActiveCheckBox.Checked);
        }

        private void bdSizeLabel_Click(object sender, EventArgs e)
        {
            NumberInputDialog numberInputDialog = new NumberInputDialog(bdSizeSlider.Value, bdSizeSlider.Minimum, bdSizeSlider.Maximum);
            if (numberInputDialog.ShowDialog() == DialogResult.OK)
            {
                bdSizeSlider.Value = numberInputDialog.Value;
                SettingsManager.Set("bdSize", numberInputDialog.Value);
                bdSizeLabel.Text = string.Format("{0}", bdSizeSlider.Value);
            }
        }

        private void bdSizeSlider_Scroll(object sender, EventArgs e)
        {
            SettingsManager.Set("bdSize", bdSizeSlider.Value);
            bdSizeLabel.Text = string.Format("{0}", bdSizeSlider.Value);
        }

        private void lnkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!SettingsManager.Get<bool>("advSettingsWarnShown"))
            {
                if (MessageBox.Show("Before you edit the settings, please exit CapsLock Indicator completely. This message will only be shown once. Do you wish to proceed?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                SettingsManager.Set("advSettingsWarnShown", true);
            }
            Process.Start("explorer", "/select,\"" + SettingsManager.GetActualPath() + "\"");
        }

        private void lnkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new IconPackBrowser())
                f.ShowDialog(this);
        }

        private void DarkModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var f = DarkModeChangingForm.Show(this, darkModeCheckBox.Checked);
            Opacity = 0;
            Enabled = false;
            Application.DoEvents();
            DarkModeProvider.SetDarkModeEnabled(darkModeCheckBox.Checked);
            Enabled = true;
            Opacity = 1;
            f.Close();
        }

        private void SearchOnResumeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SettingsManager.Set("searchForUpdatesAfterResume", searchOnResumeCheckBox.Checked);
        }

        private void advSettingsButton_Click(object sender, EventArgs e)
        {
            using (var f = new AdvancedSettings())
                f.ShowDialog(this);
        }
    }
}
