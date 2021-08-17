using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class LnComboBox : ComboBox
    {
        private readonly Color Dark_ItemBg_Normal = Color.FromArgb(56, 56, 56);
        private readonly Color Dark_ItemBg_Selected = SystemColors.Highlight;
        private readonly Color Dark_ItemFg_Normal = Color.White;
        private readonly Color Dark_ItemFg_Selected = SystemColors.HighlightText;
        private readonly Color Dark_Background_Normal = Color.FromArgb(51, 51, 51);
        private readonly Color Dark_Border_Normal = Color.FromArgb(155, 155, 155);
        private readonly Color Dark_Background_Hot = Color.FromArgb(69, 69, 69);
        private readonly Color Dark_Border_Hot = Color.FromArgb(155, 155, 155);
        private readonly Color Dark_Background_Pressed = Color.FromArgb(102, 102, 102);
        private readonly Color Dark_Border_Pressed = Color.FromArgb(155, 155, 155);

        private int prevIndex = -1;

        private bool _darkMode;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool DarkMode
        {
            get => _darkMode;
            set
            {
                _darkMode = value;
                Invalidate();
            }
        }

        public LnComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndex >= 0 && SelectedIndex < Items.Count)
            {
                var item = Items[SelectedIndex];
                var args = new ListControlConvertEventArgs(item, item.GetType(), item);
                OnFormat(args);

                if (args.Value.ToString() == "--LINE--")
                {
                    SelectedIndex = prevIndex;
                }
                else
                {
                    base.OnSelectedIndexChanged(e);
                    prevIndex = SelectedIndex;
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                var item = Items[e.Index];
                var args = new ListControlConvertEventArgs(item, item.GetType(), item);
                OnFormat(args);

                if (args.Value.ToString() == "--LINE--")
                {
                    using (var brush = new SolidBrush(_darkMode ? Dark_ItemBg_Normal : BackColor))
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    e.Graphics.DrawLine(SystemPens.GrayText, e.Bounds.X, e.Bounds.Top + e.Bounds.Height / 2, e.Bounds.Right, e.Bounds.Top + e.Bounds.Height / 2);
                }
                else
                {
                    var bg = _darkMode ? (
                        e.State.HasFlag(DrawItemState.Selected) ?
                        Dark_ItemBg_Selected :
                        Dark_ItemBg_Normal
                    ) : (
                        e.State.HasFlag(DrawItemState.Selected) ?
                        SystemColors.Highlight :
                        BackColor
                    );
                    var fg = _darkMode ? (
                        e.State.HasFlag(DrawItemState.Selected) ?
                        Dark_ItemFg_Selected :
                        Dark_ItemFg_Normal
                    ) : (
                        e.State.HasFlag(DrawItemState.Selected) ?
                        SystemColors.HighlightText :
                        ForeColor
                    );

                    using (var brush = new SolidBrush(bg))
                        e.Graphics.FillRectangle(brush, e.Bounds);

                    using (var brush = new SolidBrush(fg))
                        e.Graphics.DrawString(args.Value.ToString(), e.Font, brush, e.Bounds);
                }
            }

            base.OnDrawItem(e);
        }
    }
}
