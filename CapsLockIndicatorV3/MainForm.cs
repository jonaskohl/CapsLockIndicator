/*
 * Created 09.07.2017 18:16
 * 
 * Copyright (c) Jonas Kohl <http://jonaskohl.de/>
 */

// Use project namespace, for easier access to e.g helper classes
using CapsLockIndicatorV3;

using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Linq;

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
		
		public MainForm()
		{

            Properties.Settings.Default.beta_enableDarkMode = Properties.Settings.Default.beta_enableDarkMode;
            Properties.Settings.Default.Save();

			// Initialize component
			InitializeComponent();
			
			// Load "resources.resx" into a ResourceManager to access its resources
			resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());
			
			// Load the icons into variables
			CapsOff = (Icon)resources.GetObject("CLIv3_Caps_Off");
			CapsOn = (Icon)resources.GetObject("CLIv3_Caps_On");
			
			NumOff = (Icon)resources.GetObject("CLIv3_Num_Off");
			NumOn = (Icon)resources.GetObject("CLIv3_Num_On");
			
			ScrollOff = (Icon)resources.GetObject("CLIv3_Scroll_Off");
			ScrollOn = (Icon)resources.GetObject("CLIv3_Scroll_On");
			
			// Set the values
			numState = KeyHelper.isNumlockActive;
			capsState = KeyHelper.isCapslockActive;
			scrollState = KeyHelper.isScrolllockActive;

            // Load settings
            enableNumIcon.Checked = Properties.Settings.Default.numIco;
            enableCapsIcon.Checked = Properties.Settings.Default.capsIco;
            enableCapsIcon.Checked = Properties.Settings.Default.scrollIco;

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
				ShowOverlay("Numlock is " + (KeyHelper.isNumlockActive ? "on" : "off"));
			
			if (capsState != KeyHelper.isCapslockActive && enableCapsInd.Checked && !showNoNotification.Checked)
				ShowOverlay("Capslock is " + (KeyHelper.isCapslockActive ? "on" : "off"));
			
			if (scrollState != KeyHelper.isScrolllockActive && enableScrollInd.Checked && !showNoNotification.Checked)
				ShowOverlay("Scrolllock is " + (KeyHelper.isScrolllockActive ? "on" : "off"));
			
			// Reset the values
			numState = KeyHelper.isNumlockActive;
			capsState = KeyHelper.isCapslockActive;
			scrollState = KeyHelper.isScrolllockActive;
		}
		
		void ShowOverlay(string message)
		{
            int timeOut = Properties.Settings.Default.indDisplayTime;
            if (Application.OpenForms.OfType<IndicatorOverlay>().Any())
            {
                IndicatorOverlay indicatorOverlay = Application.OpenForms.OfType<IndicatorOverlay>().First();
                indicatorOverlay.UpdateIndicator(
                      message
                    , timeOut
                    , Properties.Settings.Default.indBgColour
                    , Properties.Settings.Default.indFgColour
                    , Properties.Settings.Default.indBdColour
                );
            }
            else
            {
                IndicatorOverlay indicatorOverlay = new IndicatorOverlay(
                      message
                    , timeOut
                    , Properties.Settings.Default.indBgColour
                    , Properties.Settings.Default.indFgColour
                    , Properties.Settings.Default.indBdColour
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

        void handleVersion(bool isCurrent)
        {
            if (!isCurrent)
            {
                if (MessageBox.Show("A new version is available (" + VersionCheck.newVersion + ")! Open the download page now?", "New version", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string version = fvi.FileVersion;
                    Process.Start(String.Format("http://cli.jonaskohl.de/_update.php?cv={0}", version));
                }
            }
        }

		void MainFormLoad(object sender, EventArgs e)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fvi.FileVersion;
			string copyright = fvi.LegalCopyright;
			aboutText.Text = String.Format(resources.GetString("aboutTextFormat"), version, copyright);
            VersionCheck.IsLatestVersion(handleVersion);
        }
		void ExitApplicationClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Exiting the application means the icons and notifications are no longer displayed. Exit anyway?", "CapsLock Indicator", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}
		void HideWindowClick(object sender, EventArgs e)
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
    }
}
