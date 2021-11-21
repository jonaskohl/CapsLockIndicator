using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class ProgressDialog : DarkModeForm
    {
        public ProgressDialog()
        {
            InitializeComponent();

            DarkModeChanged += ProgressDialog_DarkModeChanged;
            DarkModeProvider.RegisterForm(this);
        }

        private void ProgressDialog_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            label1.ForeColor = dark ? Color.White : SystemColors.WindowText;

            ControlScheduleSetDarkMode(progressBar1, dark);
            ControlScheduleSetDarkMode(label1, dark);
        }

        [Obsolete("", true)]
        public static async void DoWorkAsync(Form parent, Action<IProgress<ProgressInfo>> work)
        {
            await Task.Run(() => _doWorkAsync(parent, work));
        }

        public static async Task DoWork(Form parent, Action<IProgress<ProgressInfo>> work)
        {
            var dialog = new ProgressDialog();
            Native.SetNativeEnabled(parent, false);
            dialog.Show(parent);
            var prog = new Progress<ProgressInfo>(p => dialog.ReportProgress(p));
            await Task.Run(() => work(prog));
            Native.SetNativeEnabled(parent, true);
            dialog.Close();
        }

        public void ReportProgress(ProgressInfo p)
        {
            progressBar1.Maximum = p.Total < 0 ? 0 : p.Total;
            progressBar1.Value = p.Current < 0 ? 0 : p.Current;
            if (p.Current < 0 && p.Total < 0)
            {
                label1.Text = p.Message;
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                label1.Text = $"{p.Message} - {p.Current} / {p.Total} ({Math.Round(p.Current / (double)p.Total * 100d, 2)}%)";
                progressBar1.Style = ProgressBarStyle.Continuous;
            }
            Application.DoEvents();
        }

        [Obsolete("", true)]
        private static void _doWorkAsync(Form parent, Action<IProgress<ProgressInfo>> work)
        {
            var dialog = new ProgressDialog();
            dialog.Invoke(new MethodInvoker(() =>
            {
                Native.SetNativeEnabled(parent, false);
                dialog.Show(parent);
            }));
            var prog = new Progress<ProgressInfo>(p =>
            {
                dialog.Invoke(new MethodInvoker(() =>
                {
                    dialog.progressBar1.Maximum = p.Total;
                    dialog.progressBar1.Value = p.Current;
                    dialog.label1.Text = $"{p.Message} - {p.Current} / {p.Total} ({Math.Round(p.Current / (double)p.Total, 2)}%)";
                    Application.DoEvents();
                }));
            });
            work(prog);
            dialog.Invoke(new MethodInvoker(() =>
            {
                Native.SetNativeEnabled(parent, true);
                dialog.Close();
            }));
        }
    }
}
