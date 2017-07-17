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
    }
}
