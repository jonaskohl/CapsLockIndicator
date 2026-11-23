using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
                Visible = false
            };
            listView.Columns.Add("", -2);
            listView.ItemChecked += (s, e) =>
            {
                downloadButton.Enabled = listView.CheckedItems.Count > 0;
                listView.Invalidate(e.Item.Bounds);
            };

            // The themed default drawing renders hovered items with dark text on a
            // highlight that is unreadable in dark mode, so the rows are drawn here
            listView.DrawItem += ListView_DrawItem;
            listView.MouseMove += (s, e) => SetHotItem(listView.GetItemAt(e.X, e.Y));
            listView.MouseLeave += (s, e) => SetHotItem(null);
            listView.MouseClick += ListView_MouseClick;
            listView.Resize += (s, e) =>
            {
                if (listView.Columns.Count > 0)
                    listView.Columns[0].Width = listView.ClientSize.Width;
            };

            statusLabel = new Label()
            {
                Text = strings.translationsLoading,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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

        private ListViewItem hotItem;

        private void SetHotItem(ListViewItem item)
        {
            if (item == hotItem)
                return;

            var previous = hotItem;
            hotItem = item;

            if (previous != null && previous.ListView != null)
                listView.Invalidate(previous.Bounds);
            if (item != null)
                listView.Invalidate(item.Bounds);
        }

        // Clicking anywhere in a row toggles it. Clicks on the checkbox area itself are
        // already handled by the list view.
        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var hit = listView.HitTest(e.Location);
            if (hit.Item != null && hit.Location != ListViewHitTestLocations.StateImage)
                hit.Item.Checked = !hit.Item.Checked;
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;

            var dark = DarkModeProvider.IsDark;
            var g = e.Graphics;
            var bounds = e.Bounds;

            Color back;
            if (e.Item.Selected && listView.Focused)
                back = dark ? Color.FromArgb(98, 98, 98) : Color.FromArgb(204, 232, 255);
            else if (e.Item == hotItem || e.Item.Selected)
                back = dark ? Color.FromArgb(68, 68, 68) : Color.FromArgb(229, 243, 255);
            else
                back = listView.BackColor;

            using (var b = new SolidBrush(back))
                g.FillRectangle(b, bounds);

            // Checkbox: dark themed variant if Windows provides one, otherwise the normal one
            var state = e.Item.Checked
                ? (e.Item == hotItem ? CheckBoxState.CheckedHot : CheckBoxState.CheckedNormal)
                : (e.Item == hotItem ? CheckBoxState.UncheckedHot : CheckBoxState.UncheckedNormal);

            var glyphSize = CheckBoxRenderer.GetGlyphSize(g, state);
            var glyphPos = new Point(bounds.Left + 4, bounds.Top + (bounds.Height - glyphSize.Height) / 2);

            var darkCheckBox = dark ? GetDarkCheckBoxElement(state) : null;
            if (darkCheckBox != null && VisualStyleRenderer.IsElementDefined(darkCheckBox))
                new VisualStyleRenderer(darkCheckBox).DrawBackground(g, new Rectangle(glyphPos, glyphSize));
            else
                CheckBoxRenderer.DrawCheckBox(g, glyphPos, state);

            var textBounds = new Rectangle(glyphPos.X + glyphSize.Width + 6, bounds.Top, bounds.Right - glyphPos.X - glyphSize.Width - 8, bounds.Height);
            TextRenderer.DrawText(g, e.Item.Text, listView.Font, textBounds, listView.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            if (e.Item.Focused && listView.Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(g, bounds, listView.ForeColor, back);
        }

        private static VisualStyleElement GetDarkCheckBoxElement(CheckBoxState state)
        {
            if (!VisualStyleRenderer.IsSupported)
                return null;

            // BP_CHECKBOX = 3; states: 1 unchecked normal, 2 unchecked hot, 5 checked normal, 6 checked hot
            int s;
            switch (state)
            {
                case CheckBoxState.UncheckedHot: s = 2; break;
                case CheckBoxState.CheckedNormal: s = 5; break;
                case CheckBoxState.CheckedHot: s = 6; break;
                default: s = 1; break;
            }

            try
            {
                return VisualStyleElement.CreateElement("DarkMode_Explorer::Button", 3, s);
            }
            catch (ArgumentException)
            {
                return null;
            }
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

            ControlScheduleSetDarkMode(listView, dark);
            ControlScheduleSetDarkMode(downloadButton, dark);
            ControlScheduleSetDarkMode(cancelButton, dark);
            if (listView.IsHandleCreated)
                listView.SetDark(dark);
            else
                listView.HandleCreated += (s, e) => listView.SetDark(dark);
        }
    }
}
