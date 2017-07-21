using System;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class IndSettingsWindow : Form
    {
        public IndSettingsWindow()
        {
            InitializeComponent();

            displayTimeSlider.Value = Properties.Settings.Default.indDisplayTime;
            displayTimeLabel.Text = String.Format("{0} ms", displayTimeSlider.Value);

            backgroundColourPreview.BackColor = Properties.Settings.Default.indBgColour;
            foregroundColourPreview.BackColor = Properties.Settings.Default.indFgColour;
            borderColourPreview.BackColor = Properties.Settings.Default.indBdColour;
        }

        private void displayTimeSlider_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.indDisplayTime = displayTimeSlider.Value;
            displayTimeLabel.Text = string.Format("{0} ms", displayTimeSlider.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Properties.Settings.Default.Save();
            Close();
        }

        private void displayTimeLabel_Click(object sender, EventArgs e)
        {
            NumberInputDialog numberInputDialog = new NumberInputDialog(displayTimeSlider.Value, displayTimeSlider.Minimum, displayTimeSlider.Maximum);
            if (numberInputDialog.ShowDialog() == DialogResult.OK)
            {
                displayTimeSlider.Value = numberInputDialog.Value;
                Properties.Settings.Default.indDisplayTime = numberInputDialog.Value;
                displayTimeLabel.Text = string.Format("{0} ms", displayTimeSlider.Value);
            }
        }

        private void backgroundColourButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBgColour;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBgColour = mainColourPicker.Color;
            }
            backgroundColourPreview.BackColor = mainColourPicker.Color;
        }

        private void foregroundColourButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indFgColour;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indFgColour = mainColourPicker.Color;
            }
            foregroundColourPreview.BackColor = mainColourPicker.Color;
        }

        private void borderColourButton_Click(object sender, EventArgs e)
        {
            mainColourPicker.Color = Properties.Settings.Default.indBdColour;
            if (mainColourPicker.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.indBdColour = mainColourPicker.Color;
            }
            borderColourPreview.BackColor = mainColourPicker.Color;
        }
    }
}
