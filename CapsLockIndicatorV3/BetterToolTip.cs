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
    public class BetterToolTip : ToolTip
    {
        private static readonly Color Background = Color.FromArgb(43, 43, 43);
        private static readonly Color Border = Color.FromArgb(118, 118, 118);
        private static readonly Color Text = Color.White;

        private bool _darkMode;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool DarkMode
        {
            get => _darkMode;
            set
            {
                _darkMode = value;
                OwnerDraw = value;
            }
        }

        public BetterToolTip() : base()
        {
            Popup += BetterToolTip_Popup;
            Draw += BetterToolTip_Draw;
        }

        public BetterToolTip(IContainer cont) : base(cont)
        {
            Popup += BetterToolTip_Popup;
            Draw += BetterToolTip_Draw;
        }

        private void BetterToolTip_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void BetterToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.Clear(Background);
            using (var p = new Pen(Border))
                e.Graphics.DrawRectangle(p, new Rectangle(
                    e.Bounds.X,
                    e.Bounds.Y,
                    e.Bounds.Width - 1,
                    e.Bounds.Height - 1
                ));
            var ts = TextRenderer.MeasureText(e.Graphics, e.ToolTipText, e.Font);
            var tpos = new Point(2, e.Bounds.Height / 2 - ts.Height / 2);
            TextRenderer.DrawText(e.Graphics, e.ToolTipText, e.Font, tpos, Text);
        }
    }
}
