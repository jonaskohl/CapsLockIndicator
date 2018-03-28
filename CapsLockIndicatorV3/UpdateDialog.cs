using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();

            Text = strings.updateAvailable;
            updateNowButton.Text = strings.updateNow;
            dismissButton.Text = strings.dismissButton;
            downloadManuallyButton.Text = strings.downloadManuallyButton;
        }

        private void downloadManuallyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }
    }
}
