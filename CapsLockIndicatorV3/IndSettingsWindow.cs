using System;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class IndSettingsWindow : Form
    {
        public IndSettingsWindow()
        {
            InitializeComponent();

            displayTimeSlider.Value = Properties.Settings.Default.indDisplayTime > 0 ? Properties.Settings.Default.indDisplayTime : 2001;
            displayTimeLabel.Text = displayTimeSlider.Value < 2001 ? string.Format("{0} ms", displayTimeSlider.Value) : strings.permanentIndicator;

            backgroundColourActivatedPreview.BackColor = Properties.Settings.Default.indBgColourActive;
            backgroundColourDeactivatedPreview.BackColor = Properties.Settings.Default.indBgColourInactive;

            foregroundColourActivatedPreview.BackColor = Properties.Settings.Default.indFgColourActive;
            foregroundColourDeactivatedPreview.BackColor = Properties.Settings.Default.indFgColourInactive;

            borderColourActivatedPreview.BackColor = Properties.Settings.Default.indBdColourActive;
            borderColourDeactivatedPreview.BackColor = Properties.Settings.Default.indBdColourInactive;

            fontButton.Font = Properties.Settings.Default.indFont;

            switch (Properties.Settings.Default.overlayPosition)
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

            displayTimeGroup.Text = strings.displayTime;
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
        }

        private void displayTimeSlider_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.indDisplayTime = displayTimeSlider.Value < 2001 ? displayTimeSlider.Value : -1;
            displayTimeLabel.Text = displayTimeSlider.Value < 2001 ? string.Format("{0} ms", displayTimeSlider.Value) : strings.permanentIndicator;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Properties.Settings.Default.Save();
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
                Properties.Settings.Default.indDisplayTime = numberInputDialog.Value;
                displayTimeLabel.Text = string.Format("{0} ms", displayTimeSlider.Value);
            }
        }

        private void backgroundColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBgColourActive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBgColourActive = mainColourPicker.Color;
            }
            backgroundColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void backgroundColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBgColourInactive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBgColourInactive = mainColourPicker.Color;
            }
            backgroundColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void foregroundColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indFgColourActive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indFgColourActive = mainColourPicker.Color;
            }
            foregroundColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void foregroundColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indFgColourInactive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indFgColourInactive = mainColourPicker.Color;
            }
            foregroundColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void borderColourActivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBdColourActive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBdColourActive = mainColourPicker.Color;
            }
            borderColourActivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void borderColourDeactivatedButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBdColourInactive;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBdColourInactive = mainColourPicker.Color;
            }
            borderColourDeactivatedPreview.BackColor = mainColourPicker.Color;
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            indFontChooser.Font = Properties.Settings.Default.indFont;
            if (indFontChooser.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indFont = indFontChooser.Font;
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
            Properties.Settings.Default.overlayPosition = position;
        }
    }
}
