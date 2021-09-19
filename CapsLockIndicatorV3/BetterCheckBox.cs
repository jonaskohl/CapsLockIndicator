using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class BetterCheckBox : CheckBox
    {
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

        const int STARTX = 16;
        const int STARTY = 1;

        private static readonly Color N_Border = Color.FromArgb(137, 137, 137);
        private static readonly Color N_Background = Color.FromArgb(0, 0, 0);
        private static readonly Color N_Check = Color.FromArgb(222, 222, 222);
        private static readonly Color H_Border = Color.FromArgb(102, 132, 156);
        private static readonly Color H_Background = Color.FromArgb(0, 30, 53);
        private static readonly Color H_Check = Color.FromArgb(166, 196, 220);
        private static readonly Color A_Border = Color.FromArgb(74, 83, 91);
        private static readonly Color A_Background = Color.FromArgb(0, 9, 16);
        private static readonly Color A_Check = Color.FromArgb(120, 130, 187);

        public BetterCheckBox() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (_darkMode)
                Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (_darkMode)
                Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var bgColor = Parent?.BackColor ?? BackColor;

            if (!_darkMode)
            {
                base.OnPaint(e);

                if (!Enabled && FlatStyle != FlatStyle.System)
                {
                    e.Graphics.SetClip(new Rectangle(STARTX, 0, Width - STARTX, Height));
                    e.Graphics.Clear(bgColor);
                    e.Graphics.ResetClip();
                    // Use legacy "DrawText" to make it look exactly the same as default
                    TextRenderer.DrawText(e.Graphics, Text, Font, new Point(STARTX, STARTY), ForeColor.Blend(bgColor, 0.5d));
                }
            }
            else
            {
                var scaling = DPIHelper.GetScalingFactorPercent(Handle);
                var border = N_Border;
                var background = N_Background;
                var check = N_Check;
                var fg = ForeColor;

                if (!Enabled)
                {
                    border = N_Border.Blend(bgColor, 0.5d);
                    background = N_Background.Blend(bgColor, 0.5d);
                    check = N_Check.Blend(bgColor, 0.5d);
                    fg = ForeColor.Blend(bgColor, 0.5d);
                }
                else if (Native.GetButtonFlag(this, Native.ButtonFlags.MouseDown))
                {
                    border = A_Border;
                    background = A_Background;
                    check = A_Check;
                }
                else if (Native.GetButtonFlag(this, Native.ButtonFlags.MouseOver))
                {
                    border = H_Border;
                    background = H_Background;
                    check = H_Check;
                }

                int boxSize = (int)(13 * scaling);
                int boxRectInnerMargin = (int)(2 * scaling);
                int checkPenWidth = (int)(2 * scaling);
                int textMargin = (int)(3 * scaling);

                var boxY = Height / 2 - boxSize / 2;

                var boxRect = new Rectangle(0, boxY, boxSize, boxSize);
                var boxRectPen = boxRect;
                var boxRectInner = boxRect;
                --boxRectPen.Width;
                --boxRectPen.Height;
                boxRectInner.X += boxRectInnerMargin;
                boxRectInner.Y += boxRectInnerMargin;
                boxRectInner.Width -= 2 * boxRectInnerMargin;
                boxRectInner.Height -= 2 * boxRectInnerMargin;

                var checkPoints = new Point[]
                {
                    new Point(boxRectInner.X, boxRectInner.Y + boxRectInner.Height / 2),
                    new Point(boxRectInner.X + boxRectInner.Width / 3, boxRectInner.Bottom - checkPenWidth),
                    new Point(boxRectInner.Right - (checkPenWidth / 2), boxRectInner.Y)
                };

                e.Graphics.Clear(bgColor);

                using (var b = new SolidBrush(background))
                    e.Graphics.FillRectangle(b, boxRect);

                using (var p = new Pen(border))
                    e.Graphics.DrawRectangle(p, boxRectPen);

                if (CheckState == CheckState.Indeterminate)
                {
                    using (var b = new SolidBrush(check))
                        e.Graphics.FillRectangle(b, boxRectInner);
                }
                else if (CheckState == CheckState.Checked)
                {
                    var _m = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var p = new Pen(check, checkPenWidth))
                        e.Graphics.DrawLines(p, checkPoints);
                    e.Graphics.SmoothingMode = _m;
                }

                var textSz = TextRenderer.MeasureText(e.Graphics, Text, Font);
                var textY = Height / 2 - textSz.Height / 2;
                var textPt = new Point(boxSize + textMargin, textY);

                TextRenderer.DrawText(e.Graphics, Text, Font, textPt, fg);

                var focusRect = new Rectangle(textPt, textSz);

                if (Focused && ShowFocusCues)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, focusRect, fg, bgColor);
                }
            }
        }
    }
}
