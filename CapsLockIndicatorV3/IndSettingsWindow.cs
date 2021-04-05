using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class IndSettingsWindow : DarkModeForm
    {
        ResourceManager resources;

        public IndSettingsWindow()
        {
            InitializeComponent();

            resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += IndSettingsWindow_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };

            MaximumSize = new Size(int.MaxValue, Screen.FromControl(this).WorkingArea.Height);
            AutoScroll = true;

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

            Text = strings.notificationSettingsTitle;
            displayTimeGroup.Text = strings.displayTime;
            opacityGroup.Text = strings.opacity;
            fontGroupBox.Text = strings.fontGroup;
            coloursGroup.Text = strings.coloursGroup;
            fontButton.Text = string.Format(strings.keyIsOff, strings.capsLock);
            saveButton.Text = strings.saveAndCloseButton;
            backgroundColourActivatedButton.Text = strings.backgroundColourActivatedButton;
            backgroundColourDeactivatedButton.Text = strings.backgroundColourDeactivatedButton;
            borderColourActivatedButton.Text = strings.borderColourActivatedButton;
            borderColourDeactivatedButton.Text = strings.borderColourDeactivatedButton;
            foregroundColourActivatedButton.Text = strings.foregroundColourActivatedButton;
            foregroundColourDeactivatedButton.Text = strings.foregroundColourDeactivatedButton;
            positionGroup.Text = strings.overlayPositionGroup;
            onlyShowWhenActiveCheckBox.Text = strings.showOverlayOnlyWhenActive;
            lnkLabel1.Text = strings.advancedSettings;
            borderGroup.Text = strings.borderThicknessGroup;
        }

        private void IndSettingsWindow_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkMode(Handle, dark);
            Native.UseImmersiveDarkModeColors(Handle, dark);
            Native.UseImmersiveDarkModeColors(mainColourPicker.PInstance, dark);

            Icon = (Icon)resources.GetObject("settings" + (dark ? "_dark" : ""));

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


            lnkLabel1.LinkColor = dark ? Color.White : SystemColors.HotTrack;

            onlyShowWhenActiveCheckBox.FlatStyle = dark ? FlatStyle.Standard : FlatStyle.System;

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

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
            ControlScheduleSetDarkMode(saveButton, dark);
        }

        private void displayTimeSlider_Scroll(object sender, EventArgs e)
        {
            SettingsManager.Set("indDisplayTime", displayTimeSlider.Value < 2001 ? displayTimeSlider.Value : -1);
            displayTimeLabel.Text = displayTimeSlider.Value < 2001 ? string.Format("{0} ms", displayTimeSlider.Value) : strings.permanentIndicator;
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
