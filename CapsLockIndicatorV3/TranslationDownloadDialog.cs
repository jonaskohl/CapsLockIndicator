using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// Lists the translations that are available on the server but not installed,
    /// and lets the user pick the ones to download.
    /// </summary>
    internal class TranslationDownloadDialog : DarkModeForm
    {
        private readonly Label hintLabel;
        private readonly Label statusLabel;
        private readonly DarkModeListView listView;
        private readonly Button downloadButton;
        private readonly Button cancelButton;

        /// <summary>
        /// The translations the user selected (valid when DialogResult is OK).
        /// </summary>
        public RemoteLanguage[] SelectedLanguages { get; private set; } = new RemoteLanguage[0];

        public TranslationDownloadDialog()
        {
            Text = strings.downloadTranslationsTitle;
            Font = SystemFonts.MessageBoxFont;
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(420, 360);
            Padding = new Padding(12);

            hintLabel = new Label()
            {
                Text = strings.translationsSelectHint,
                Dock = DockStyle.Fill,
                AutoSize = true,
                MaximumSize = new Size(396, 0),
                Margin = new Padding(0, 0, 0, 8)
            };

            listView = new DarkModeListView()
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                CheckBoxes = true,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.None,
                MultiSelect = false,
                ToggleCheckOnRowClick = true,
                Visible = false
            };
            listView.Columns.Add("", -2);
            listView.ItemChecked += (s, e) => downloadButton.Enabled = listView.CheckedItems.Count > 0;
            listView.Resize += (s, e) =>
            {
                if (listView.Columns.Count > 0)
                    listView.Columns[0].Width = listView.ClientSize.Width;
            };

            statusLabel = new Label()
            {
                Text = strings.translationsLoading,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            downloadButton = new Button()
            {
                Text = strings.translationsDownloadButton,
                AutoSize = true,
                MinimumSize = new Size(88, 26),
                FlatStyle = FlatStyle.System,
                Enabled = false
            };
            downloadButton.Click += DownloadButton_Click;

            cancelButton = new Button()
            {
                Text = strings.cancel,
                AutoSize = true,
                MinimumSize = new Size(88, 26),
                FlatStyle = FlatStyle.System,
                DialogResult = DialogResult.Cancel
            };

            var buttons = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true,
                Margin = new Padding(0, 8, 0, 0)
            };
            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(downloadButton);

            var listHost = new Panel() { Dock = DockStyle.Fill, Margin = new Padding(0) };
            listHost.Controls.Add(listView);
            listHost.Controls.Add(statusLabel);

            var layout = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(hintLabel, 0, 0);
            layout.Controls.Add(listHost, 0, 1);
            layout.Controls.Add(buttons, 0, 2);
            Controls.Add(layout);

            AcceptButton = downloadButton;
            CancelButton = cancelButton;

            HandleCreated += (s, e) =>
            {
                DarkModeChanged += (s2, e2) => ApplyDarkMode();
                DarkModeProvider.RegisterForm(this);
            };

            Shown += async (s, e) =>
            {
                try
                {
                    var installed = LanguageService.GetInstalledLocales();
                    var available = (await LanguageService.GetAvailableAsync())
                        .Where(l => !installed.Contains(l.Locale))
                        .OrderBy(l => l.DisplayName, StringComparer.CurrentCultureIgnoreCase)
                        .ToList();

                    if (IsDisposed)
                        return;

                    if (available.Count == 0)
                    {
                        statusLabel.Text = strings.translationsAllInstalled;
                        return;
                    }

                    listView.BeginUpdate();
                    foreach (var l in available)
                        listView.Items.Add(new ListViewItem(l.DisplayName) { Tag = l });
                    listView.Columns[0].Width = listView.ClientSize.Width;
                    listView.EndUpdate();

                    statusLabel.Hide();
                    listView.Show();
                    listView.Focus();
                }
                catch (Exception ex) when (ex is WebException || ex is System.Xml.XmlException || ex is NullReferenceException || ex is FormatException)
                {
                    if (!IsDisposed)
                        statusLabel.Text = string.Format(strings.translationsListError, ex.Message);
                }
            };
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            SelectedLanguages = listView.CheckedItems.Cast<ListViewItem>().Select(i => (RemoteLanguage)i.Tag).ToArray();
            if (SelectedLanguages.Length == 0)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplyDarkMode()
        {
            var dark = DarkModeProvider.IsDark;

            Native.UseImmersiveDarkModeColors(Handle, dark);

            BackColor = dark ? Color.FromArgb(255, 32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            ControlScheduleSetDarkMode(downloadButton, dark);
            ControlScheduleSetDarkMode(cancelButton, dark);
            listView.SetDark(dark);
        }
    }
}
