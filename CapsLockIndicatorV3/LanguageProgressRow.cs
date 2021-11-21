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
    public partial class LanguageProgressRow : UserControl
    {
        public new string Text
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public int Minimum
        {
            get => progressBar1.Minimum;
            set => progressBar1.Minimum = value;
        }

        public int Maximum
        {
            get => progressBar1.Maximum;
            set => progressBar1.Maximum = value;
        }

        public int Value
        {
            get => progressBar1.Value;
            set => progressBar1.Value = value;
        }

        public ProgressBarStyle Style
        {
            get => progressBar1.Style;
            set => progressBar1.Style = value;
        }

        public ProgressBar ProgressBar => progressBar1;
        public BetterToolTip ToolTip => betterToolTip1;

        public LanguageProgressRow()
        {
            InitializeComponent();
        }

        public void SetError(bool error, string errorMessage = null)
        {
            Native.SetProgressBarState(progressBar1, error ? ProgressBarState.Error : ProgressBarState.Normal);
            pictureBox1.Image = error ? (
                SysIcons.GetSystemIcon(SysIcons.SHSTOCKICONID.SIID_ERROR, SysIcons.IconSize.Small).ToBitmap()
            ) : null;
            betterToolTip1.SetToolTip(pictureBox1,
                (
                    (error ? strings.failedToDownloadTranslationToolTip : "")
                  + (errorMessage == null ? "" : ("\n" + errorMessage))
                ).Trim()
            );
        }
    }
}
