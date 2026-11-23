using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class CustomPictureBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.Default;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(e);
        }
    }
}
