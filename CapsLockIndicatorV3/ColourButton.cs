using System;
using System.Windows.Forms;
using System.Drawing;

namespace CapsLockIndicatorV3
{
    class ColourButton : Button
    {
        public Color Colour { get; set; }

        const int COLOUR_MARGIN = 4;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            /*Bitmap b = new Bitmap(16, 16);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Colour);
            g.DrawRectangle(Pens.Black, 0, 0, 15, 15);
            Image = b;*/


            base.OnPaint(pevent);
            /*Rectangle rect = new Rectangle(
                COLOUR_MARGIN,
                COLOUR_MARGIN,
                Width - (COLOUR_MARGIN * 2) - 1,
                Height - (COLOUR_MARGIN * 2) - 1
            );
            pevent.Graphics.FillRectangle(new SolidBrush(Colour), rect);
            pevent.Graphics.DrawRectangle(Pens.Black, rect);*/
        }
    }
}
