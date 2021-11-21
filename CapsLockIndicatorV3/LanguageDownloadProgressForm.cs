using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public partial class LanguageDownloadProgressForm : DarkModeForm
    {
        public const string DLL_NAME = "CapsLockIndicatorV3.resources.dll";
        public const string DLL_UPDATE_DIR = "~update";

        private int totalOperations = 0;
        private int completedOperations = 0;

        private KeyValuePair<string, DllInfo>[] dlls;
        Dictionary<string, LanguageProgressRow> progs;

        public event EventHandler DownloadCompleted;

        public LanguageDownloadProgressForm()
        {
            InitializeComponent();

            HandleCreated += (s, e) =>
            {
                DarkModeChanged += LanguageDownloadProgressForm_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };

            button1.Text = strings.restart;
            button1.Enabled = false;

            Text = strings.downloadTranslationsTitle;

            Shown += LanguageDownloadProgressForm_Shown;
        }

        private void LanguageDownloadProgressForm_Shown(object sender, EventArgs e)
        {
            if (dlls != null)
                BeginDownload();
        }

        public void DownloadLangFiles(KeyValuePair<string, DllInfo>[] dlls)
        {
            this.dlls = dlls;

            Show();
        }

        private void BeginDownload()
        {
            Native.SetCloseButtonEnabled(this, false);

            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            progs = new Dictionary<string, LanguageProgressRow>();

            totalOperations = dlls.Length;

            panel1.SuspendLayout();

            foreach (var dll in dlls)
            {
                var row = new LanguageProgressRow();
                panel1.Controls.Add(row);
                panel1.Controls.SetChildIndex(row, 0);

                row.Dock = DockStyle.Top;
                row.Text = GetNameOfLocale(dll.Key) + " (" + dll.Key + ")";
                row.Name = "languageRow" + dll.Key;
                row.Style = ProgressBarStyle.Marquee;

                progs[dll.Key] = row;
            }

            progressBar1.Maximum = dlls.Length;

            PerformDarkModeUpdate();

            panel1.ResumeLayout(true);

            var updateDir = Path.Combine(exeDir, DLL_UPDATE_DIR);
            Directory.CreateDirectory(updateDir);

            Parallel.ForEach(dlls, new ParallelOptions()
            {
                MaxDegreeOfParallelism = 4
            }, (dll) =>
            {
                var tempFile = Path.GetTempFileName();
                var dllPath = Path.Combine(updateDir, dll.Key + ".dll");

                using (var wc = new WebClient())
                {
                    wc.Headers.Add(HttpRequestHeader.UserAgent, VersionCheck.UserAgent);

                    //Invoke((MethodInvoker)delegate
                    //{
                    //    var p = progs[dll.Key];
                    //    p.Style = ProgressBarStyle.Continuous;
                    //});

                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            var p = progs[dll.Key];

                            if (e.Error != null)
                            {
                                p.Style = ProgressBarStyle.Continuous;
                                p.Value = p.Maximum = 1;
                                p.SetError(true, e.Error.Message);

                                File.Delete(tempFile);
                            }
                            else
                            {
                                p.Value = p.Maximum;

                                if (File.Exists(dllPath))
                                    File.Delete(dllPath);

                                File.Move(tempFile, dllPath);
                            }


                            progressBar1.Value += 1;
                        });
                        UpdateCompletion();
                    };
                    wc.DownloadProgressChanged += (s, e) =>
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            var p = progs[dll.Key];
                            p.Style = ProgressBarStyle.Continuous;
                            p.Maximum = (int)e.TotalBytesToReceive;
                            p.Value = (int)e.BytesReceived;
                        });
                    };

                    wc.DownloadFileAsync(new Uri(dll.Value.Filepath), tempFile);
                }
            });
        }

        private static string GetNameOfLocale(string locale)
        {
            var culture = CultureInfo.GetCultureInfo(locale);
            return culture.NativeName;
        }

        private void UpdateCompletion()
        {
            ++completedOperations;

            if (completedOperations >= totalOperations)
            {
                Native.SetCloseButtonEnabled(this, true);
                button1.Enabled = true;
                DownloadCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        private void LanguageDownloadProgressForm_DarkModeChanged(object sender, EventArgs e)
        {
            PerformDarkModeUpdate();
        }

        private void PerformDarkModeUpdate()
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            panel1.BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            panel1.ForeColor = dark ? Color.White : SystemColors.WindowText;

            ControlScheduleSetDarkMode(progressBar1, dark);
            ControlScheduleSetDarkMode(button1, dark);
            ControlScheduleSetDarkMode(panel1, dark);

            if (progs != null)
            {
                foreach (var p in progs.Values)
                {
                    ControlScheduleSetDarkMode(p.ProgressBar, dark);
                    p.ToolTip.DarkMode = dark;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Restart();
        }
    }
}
