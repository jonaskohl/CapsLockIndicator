using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class LnComboBox : ComboBox
    {
        private int prevIndex = -1;

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
                    using (var brush = new SolidBrush(BackColor))
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    e.Graphics.DrawLine(SystemPens.GrayText, e.Bounds.X, e.Bounds.Top + e.Bounds.Height / 2, e.Bounds.Right, e.Bounds.Top + e.Bounds.Height / 2);
                }
                else
                    using (var brush = new SolidBrush(e.ForeColor))
                        e.Graphics.DrawString(args.Value.ToString(), e.Font, brush, e.Bounds);
            }

            base.OnDrawItem(e);
        }
    }
}
