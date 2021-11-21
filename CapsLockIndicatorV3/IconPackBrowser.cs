using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CapsLockIndicatorV3
{
    public partial class IconPackBrowser : DarkModeForm
    {
        struct IconPackMetadata
        {
            public string AuthorName;
            public string AuthorGithub;
            public string Name;
            public string Version;
            public int Format;
            public bool OnDark;

            public static IconPackMetadata FromXMLString(string xmlString)
            {
                var doc = XDocument.Parse(xmlString);
                var root = doc.Root;
                _assert(root.Name == "metadata", "Root tag must me metadata");

                var authorNode = root.Element("author");

                var authorNameNode = authorNode.Element("name");
                var authorName = authorNameNode.Value;
                _assert(authorNameNode.Attribute("type").Value == "string", "author/name must be of type string");

                var authorGitHubNode = authorNode.Element("github");
                var authorGitHub = authorGitHubNode.Value;
                _assert(authorGitHubNode.Attribute("type").Value == "string", "author/github must be of type string");

                var nameNode = root.Element("name");
                var name = nameNode.Value;
                _assert(nameNode.Attribute("type").Value == "string", "name must be of type string");

                var versionNode = root.Element("version");
                var version = versionNode.Value;
                _assert(versionNode.Attribute("type").Value == "string", "version must be of type string");

                var formatNode = root.Element("format");
                var formatStr = formatNode.Value;
                _assert(formatNode.Attribute("type").Value == "number", "format must be of type number");
                _assert(int.TryParse(formatStr, out int format), "Invalid number format: " + formatStr);
                _assert(format == 1, "Value of format must be 1");

                var ondarkNode = root.Element("ondark");
                var ondarkStr = ondarkNode.Value;
                var ondark = ondarkStr.ToLower() == "true";
                _assert(ondarkNode.Attribute("type").Value == "boolean", "ondark must be of type boolean");

                return new IconPackMetadata()
                {
                    AuthorName = authorName,
                    AuthorGithub = authorGitHub,
                    Name = name,
                    Version = version,
                    Format = format,
                    OnDark = ondark
                };
            }

            private static void _assert(bool condition, string message = "")
            {
                if (!condition)
                    throw new AssertionFailedException(message);
            }
        }

        public IconPackBrowser()
        {
            InitializeComponent();

            HandleCreated += (sender, e) =>
            {
                DarkModeChanged += IconPackBrowser_DarkModeChanged;
                DarkModeProvider.RegisterForm(this);
            };

            var ofs = new IconGalleryObjectForScripting();
            ofs.OnDownloadRequested += Ofs_OnDownloadRequested;
            ofs.OnCloseWindowRequested += Ofs_OnCloseWindowRequested;
            webBrowser1.ObjectForScripting = ofs;
        }

        private void Ofs_OnCloseWindowRequested(object sender, EventArgs e)
        {
            Close();
        }

        private void Ofs_OnDownloadRequested(object sender, string id)
        {
            if (id == ":reset:")
            {
                if (MessageBox.Show(this, strings.iconPackResetPrompt, "CapsLock Indicator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var thisDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    foreach (var n in new[] { "caps", "num", "scroll" })
                        for (var i = 0; i < 2; ++i)
                        {
                            var f = Path.Combine(thisDir, n + i.ToString() + ".ico");
                            if (File.Exists(f))
                                File.Delete(f);
                        }

                    Program.MainForm.ReloadIcons();
                    MessageBox.Show(this, strings.iconPackResetSuccess, "CapsLock Indicator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            string xmlMetadata = "-";
            bool cancelled = false;

            var progressDialog = new ProgressDialog();
            progressDialog.Show(this);
            progressDialog.ReportProgress(new ProgressInfo()
            {
                Current = -1,
                Total = -1,
                Message = strings.iconPackDownloadingMetadata
            });
            Native.SetNativeEnabled(this, false);

            using (var w = new WebClient())
            {
                w.DownloadProgressChanged += (object wcsender, DownloadProgressChangedEventArgs e) =>
                {
                    progressDialog.ReportProgress(new ProgressInfo()
                    {
                        Current = (int)e.BytesReceived,
                        Total = (int)e.TotalBytesToReceive,
                        Message = strings.iconPackDownloadingMetadata
                    });
                };
                w.DownloadStringCompleted += (object wcsender, DownloadStringCompletedEventArgs e) =>
                {
                    xmlMetadata = e.Result;
                    cancelled = e.Cancelled;

                    progressDialog.Close();
                    Native.SetNativeEnabled(this, true);
                    Show();
                    Focus();

                    if (cancelled)
                        return;

                    var metadata = IconPackMetadata.FromXMLString(xmlMetadata);

                    var message = new StringFormatter(strings.iconPackPrompt);
                    message.Add("name", metadata.Name);
                    message.Add("version", metadata.Version);
                    message.Add("authorName", metadata.AuthorName);
                    if (MessageBox.Show(this, message.ToString(), "CapsLock Indicator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        DownloadPack(id, metadata);
                };

                var url = "https://cli.jonaskohl.de/icongallery/getmeta.php?id=" + id;
                w.DownloadStringAsync(new Uri(url));
            }
        }

        private void DownloadPack(string id, IconPackMetadata metadata)
        {
            var progressDialog = new ProgressDialog();
            var thisDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            progressDialog.Show(this);
            progressDialog.ReportProgress(new ProgressInfo()
            {
                Current = -1,
                Total = -1,
                Message = strings.iconPackDownloadingPack
            });
            Native.SetNativeEnabled(this, false);

            using (var w = new WebClient())
            {
                w.DownloadProgressChanged += (object wcsender, DownloadProgressChangedEventArgs e) =>
                {
                    progressDialog.ReportProgress(new ProgressInfo()
                    {
                        Current = (int)e.BytesReceived,
                        Total = (int)e.TotalBytesToReceive,
                        Message = strings.iconPackDownloadingPack
                    });
                };
                w.DownloadDataCompleted += (object wcsender, DownloadDataCompletedEventArgs e) =>
                {
                    progressDialog.Close();
                    Native.SetNativeEnabled(this, true);
                    Show();
                    Focus();

                    if (e.Cancelled)
                        return;

                    using (var stream = new MemoryStream(e.Result))
                    using (var zip = new ZipArchive(stream))
                    {
                        var dict = zip.Entries.ToDictionary(z => z.FullName);

                        foreach (var n in new[] {"caps","num","scroll"})
                            for (var i = 0; i < 2; ++i)
                                dict[n + i.ToString() + ".ico"].ExtractToFile(Path.Combine(thisDir, n + i.ToString() + ".ico"), true);
                    }

                    Program.MainForm.ReloadIcons();
                    
                    var message = new StringFormatter(strings.iconPackSuccess);
                    message.Add("name", metadata.Name);
                    message.Add("version", metadata.Version);
                    MessageBox.Show(this, message.ToString(), "CapsLock Indicator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                var url = "https://cli.jonaskohl.de/icongallery/?download=" + id;
                w.DownloadDataAsync(new Uri(url));
            }
        }

        private void IconPackBrowser_DarkModeChanged(object sender, EventArgs e)
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            ControlScheduleSetDarkMode(webBrowser1, dark);

            webBrowser1.Navigate("https://cli.jonaskohl.de/icongallery/embedded.php?dark=" + (dark ? "true" : "false") + "&scale=" + ((int)(DPIHelper.GetScalingFactorPercent(Handle) * 100)).ToString());
        }
    }
}
