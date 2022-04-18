using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class BetterCheckBox : CheckBox
    {
        const int WIN11_CORNER_RADIUS = 2;

        private bool isWindows11 = Versions.IsWindows11;
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

        const int STARTX = 13;
        int StartX => (int)(DPIHelper.GetScalingFactorPercent(Handle) * STARTX);
        const int STARTY = 1;

        private TextFormatFlags TextRenderingFlags
        {
            get
            {
                var flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                if (!ShowKeyboardCues)
                    flags |= TextFormatFlags.HidePrefix;
                return flags;
            }
        }

        // Win10 style colors
        private static readonly Color N_Border = Color.FromArgb(137, 137, 137);
        private static readonly Color N_Background = Color.FromArgb(0, 0, 0);
        private static readonly Color N_Check = Color.FromArgb(222, 222, 222);
        private static readonly Color H_Border = Color.FromArgb(102, 132, 156);
        private static readonly Color H_Background = Color.FromArgb(0, 30, 53);
        private static readonly Color H_Check = Color.FromArgb(166, 196, 220);
        private static readonly Color A_Border = Color.FromArgb(74, 83, 91);
        private static readonly Color A_Background = Color.FromArgb(0, 9, 16);
        private static readonly Color A_Check = Color.FromArgb(120, 130, 187);

        // Win11 style colors
        private static readonly Color N_U_Background_11 = Color.FromArgb(unchecked((int)0xff383838));
        private static readonly Color H_U_Background_11 = Color.FromArgb(unchecked((int)0xff424242));
        private static readonly Color A_U_Background_11 = Color.FromArgb(unchecked((int)0xff202020));
        private static readonly Color N_C_Background_11 = Color.FromArgb(unchecked((int)0xff8FCBFF));
        private static readonly Color H_C_Background_11 = Color.FromArgb(unchecked((int)0xffBCE0FF));
        private static readonly Color A_C_Background_11 = Color.FromArgb(unchecked((int)0xff74ABDC));
        private static readonly Color N_C_Check_11 = Color.FromArgb(unchecked((int)0xff191919));
        private static readonly Color H_C_Check_11 = Color.FromArgb(unchecked((int)0xff202020));
        private static readonly Color A_C_Check_11 = Color.FromArgb(unchecked((int)0xff101010));
        private static readonly Color Border_11 = Color.FromArgb(unchecked((int)0xff8b8b8b));

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
                    var bounds = new Rectangle(StartX, 0, Width - StartX, Height);
                    e.Graphics.SetClip(bounds);
                    e.Graphics.Clear(bgColor);
                    e.Graphics.ResetClip();
                    // Use legacy "DrawText" to make it look exactly the same as default
                    TextRenderer.DrawText(e.Graphics, base.Text, base.Font, bounds, base.ForeColor.Blend(bgColor, 0.5d), TextRenderingFlags);
                }
            }
            else
            {
                Color border, background, check;

                var fg = ForeColor;
                var scaling = DPIHelper.GetScalingFactorPercent(Handle);
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

                var isChecked = CheckState != CheckState.Unchecked;
                var radius = (int)(WIN11_CORNER_RADIUS * scaling);

                if (isWindows11)
                {
                    e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    background = isChecked ? N_C_Background_11 : N_U_Background_11;
                    check = N_C_Check_11;
                    border = Border_11;

                    if (!Enabled)
                    {
                        border = border.Blend(bgColor, 0.5d);
                        background = background.Blend(bgColor, 0.5d);
                        check = check.Blend(bgColor, 0.5d);
                        fg = ForeColor.Blend(bgColor, 0.5d);
                    }
                    else if (Native.GetButtonFlag(this, Native.ButtonFlags.MouseDown))
                    {
                        background = isChecked ? A_C_Background_11 : A_U_Background_11;
                        check = A_C_Check_11;
                    }
                    else if (Native.GetButtonFlag(this, Native.ButtonFlags.MouseOver))
                    {
                        background = isChecked ? H_C_Background_11 : H_U_Background_11;
                        check = H_C_Check_11;
                    }

                    var innerBoxSize = (int)Math.Ceiling(boxRect.Width / 2d);

                    boxRectInner = new Rectangle(
                        boxRect.X + innerBoxSize / 2,
                        boxRect.Y + innerBoxSize / 2,
                        innerBoxSize,
                        innerBoxSize
                    );
                    var boxRectFPen = new RectangleF(
                        boxRect.X + 0.5f,
                        boxRect.Y + 0.5f,
                        boxRect.Width - 1.0f,
                        boxRect.Height - 1.0f
                    );
                    //checkPenWidth = (int)scaling / 2;

                    var checkPoints = new Point[]
                    {
                        new Point(boxRectInner.X, boxRectInner.Y + boxRectInner.Height / 2),
                        new Point(boxRectInner.X + boxRectInner.Width / 3, boxRectInner.Bottom - checkPenWidth),
                        new Point(boxRectInner.Right - (checkPenWidth / 2), boxRectInner.Y + (boxRectInner.Height / 4))
                    };

                    e.Graphics.Clear(bgColor);

                    using (var b = new SolidBrush(background))
                        FillRoundedRectangle(e.Graphics, b, boxRect, radius);

                    if (!isChecked)
                        using (var p = new Pen(border) { Alignment = PenAlignment.Center })
                            DrawRoundedRectangle(e.Graphics, p, boxRectFPen, radius);

                    if (CheckState == CheckState.Indeterminate)
                    {
                        //using (var b = new SolidBrush(check))
                        //    FillRoundedRectangle(e.Graphics, b, boxRectInner, WIN11_CORNER_RADIUS);
                        using (var b = new SolidBrush(check))
                            e.Graphics.FillRectangle(b, new Rectangle(
                                boxRectInner.X,
                                boxRectInner.Y + (boxRectInner.Height - checkPenWidth) / 2,
                                boxRectInner.Width,
                                checkPenWidth
                            ));
                    }
                    else if (CheckState == CheckState.Checked)
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        using (var p = new Pen(check, checkPenWidth))
                            e.Graphics.DrawLines(p, checkPoints);
                    }
                }
                else
                {
                    border = N_Border;
                    background = isWindows11 ? N_U_Background_11 : N_Background;
                    check = isWindows11 ? N_C_Check_11 : N_Check;

                    if (!Enabled)
                    {
                        border = background.Blend(N_Border, 0.5d);
                        background = background.Blend(N_Background, 0.5d);
                        check = check.Blend(N_Check, 0.5d);
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
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (var p = new Pen(check, checkPenWidth))
                            e.Graphics.DrawLines(p, checkPoints);
                        e.Graphics.SmoothingMode = _m;
                    }
                }

                var textSz = TextRenderer.MeasureText(e.Graphics, Text, Font);
                var textY = Height / 2 - textSz.Height / 2;
                var textPt = new Point(boxSize + textMargin, textY);

                TextRenderer.DrawText(e.Graphics, Text, Font, new Rectangle(StartX, 0, Width - StartX, Height), fg, TextRenderingFlags);

                var focusRect = new Rectangle(textPt, textSz);

                if (Focused && ShowFocusCues)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, focusRect, fg, bgColor);
                }
            }
        }
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        public static GraphicsPath RoundedRect(RectangleF bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            RectangleF arc = new RectangleF(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        public static void DrawRoundedRectangle(Graphics graphics, Pen pen, RectangleF bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }
    }
}
