using CapsLockIndicatorV3;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms
{
    /// <summary>
    /// A list view that draws its header and rows itself from an explicit light or
    /// dark palette. The system list view themes don't switch reliably at runtime and
    /// draw hovered rows with unreadable dark text in dark mode.
    /// </summary>
    public class DarkModeListView : ListView
    {
        private const int WM_THEMECHANGED = 0x031A;

        public IntPtr HeaderHandle => IsHandleCreated
            ? Native.SendMessage(Handle, Native.LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)
            : IntPtr.Zero;

        /// <summary>
        /// If true (and CheckBoxes is enabled), clicking anywhere in a row toggles its checkbox.
        /// </summary>
        public bool ToggleCheckOnRowClick { get; set; }

        private bool dark;
        private ListViewItem hotItem;

        private Color HeaderBackColor => dark ? Color.FromArgb(43, 43, 43) : SystemColors.Window;
        private Color HeaderTextColor => dark ? Color.FromArgb(222, 222, 222) : SystemColors.ControlText;
        private Color HeaderLineColor => dark ? Color.FromArgb(70, 70, 70) : Color.FromArgb(229, 229, 229);
        private Color HotBackColor => dark ? Color.FromArgb(68, 68, 68) : Color.FromArgb(229, 243, 255);
        private Color SelectedBackColor => dark ? Color.FromArgb(98, 98, 98) : Color.FromArgb(204, 232, 255);

        public DarkModeListView() : base()
        {
            DoubleBuffered = true;
            OwnerDraw = true;
        }

        public void SetDark(bool dark)
        {
            this.dark = dark;

            BackColor = dark ? Color.FromArgb(32, 32, 32) : SystemColors.Window;
            ForeColor = dark ? Color.White : SystemColors.WindowText;

            if (IsHandleCreated)
            {
                // Scroll bars and the empty part of the header are still drawn by the system
                Native.AllowDarkModeForWindow(Handle, dark);
                Native.SetWindowTheme(Handle, dark ? "DarkMode_Explorer" : "Explorer", null);

                var header = HeaderHandle;
                if (header != IntPtr.Zero)
                {
                    Native.AllowDarkModeForWindow(header, dark);
                    Native.SetWindowTheme(header, dark ? "DarkMode_ItemsView" : "ItemsView", null);
                    Native.SendMessage(header, WM_THEMECHANGED, IntPtr.Zero, IntPtr.Zero);
                }
            }

            Invalidate(true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetDark(dark);
        }

        #region Hot tracking and row click

        private void SetHotItem(ListViewItem item)
        {
            if (item == hotItem)
                return;

            var previous = hotItem;
            hotItem = item;

            if (previous != null && previous.ListView == this)
                Invalidate(previous.Bounds);
            if (item != null)
                Invalidate(item.Bounds);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            SetHotItem(GetItemAt(e.X, e.Y));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetHotItem(null);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (!ToggleCheckOnRowClick || !CheckBoxes || e.Button != MouseButtons.Left)
                return;

            // Clicks on the checkbox itself are already handled by the list view
            var hit = HitTest(e.Location);
            if (hit.Item != null && hit.Location != ListViewHitTestLocations.StateImage)
                hit.Item.Checked = !hit.Item.Checked;
        }

        protected override void OnItemChecked(ItemCheckedEventArgs e)
        {
            base.OnItemChecked(e);
            Invalidate(e.Item.Bounds);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        #endregion

        #region Drawing

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            var b = e.Bounds;

            using (var brush = new SolidBrush(HeaderBackColor))
                e.Graphics.FillRectangle(brush, b);

            using (var pen = new Pen(HeaderLineColor))
            {
                e.Graphics.DrawLine(pen, b.Left, b.Bottom - 1, b.Right, b.Bottom - 1);
                e.Graphics.DrawLine(pen, b.Right - 1, b.Top + 4, b.Right - 1, b.Bottom - 5);
            }

            var textBounds = new Rectangle(b.Left + 6, b.Top, b.Width - 12, b.Height);
            TextRenderer.DrawText(e.Graphics, e.Header.Text, Font, textBounds, HeaderTextColor,
                AlignmentFlags(e.Header.TextAlign) | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private Color RowBackColor(ListViewItem item)
        {
            if (item.Selected && Focused)
                return SelectedBackColor;
            if (item == hotItem || (item.Selected && !HideSelection))
                return HotBackColor;
            return BackColor;
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;

            using (var brush = new SolidBrush(RowBackColor(e.Item)))
                e.Graphics.FillRectangle(brush, e.Bounds);

            // In Details view the content is drawn per column in OnDrawSubItem
            if (View != View.Details)
                DrawCell(e.Graphics, e.Item, e.Item.Text, e.Bounds, true, HorizontalAlignment.Left);

            if (e.Item.Focused && Focused && ShowFocusCues)
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, ForeColor, RowBackColor(e.Item));
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;
            DrawCell(e.Graphics, e.Item, e.SubItem.Text, e.Bounds, e.ColumnIndex == 0, e.Header.TextAlign);
        }

        private void DrawCell(Graphics g, ListViewItem item, string text, Rectangle bounds, bool firstColumn, HorizontalAlignment align)
        {
            var x = bounds.Left + 6;

            if (firstColumn && CheckBoxes)
            {
                var state = item.Checked
                    ? (item == hotItem ? CheckBoxState.CheckedHot : CheckBoxState.CheckedNormal)
                    : (item == hotItem ? CheckBoxState.UncheckedHot : CheckBoxState.UncheckedNormal);

                var size = CheckBoxRenderer.GetGlyphSize(g, state);
                var pos = new Point(bounds.Left + 4, bounds.Top + (bounds.Height - size.Height) / 2);

                var element = dark ? DarkCheckBoxElement(state) : null;
                if (element != null)
                    new VisualStyleRenderer(element).DrawBackground(g, new Rectangle(pos, size));
                else
                    CheckBoxRenderer.DrawCheckBox(g, pos, state);

                x = pos.X + size.Width + 6;
            }

            var textBounds = new Rectangle(x, bounds.Top, Math.Max(bounds.Right - x - 4, 0), bounds.Height);
            TextRenderer.DrawText(g, text, Font, textBounds, ForeColor,
                AlignmentFlags(align) | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private static TextFormatFlags AlignmentFlags(HorizontalAlignment align)
        {
            switch (align)
            {
                case HorizontalAlignment.Center: return TextFormatFlags.HorizontalCenter;
                case HorizontalAlignment.Right: return TextFormatFlags.Right;
                default: return TextFormatFlags.Left;
            }
        }

        // Dark checkbox from the DarkMode_Explorer theme (Windows 10 1809+), or null if unavailable.
        // BP_CHECKBOX = 3; states: 1 unchecked normal, 2 unchecked hot, 5 checked normal, 6 checked hot
        private static VisualStyleElement DarkCheckBoxElement(CheckBoxState state)
        {
            if (!VisualStyleRenderer.IsSupported)
                return null;

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
                var element = VisualStyleElement.CreateElement("DarkMode_Explorer::Button", 3, s);
                return VisualStyleRenderer.IsElementDefined(element) ? element : null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        #endregion
    }
}
