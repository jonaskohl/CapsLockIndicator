/*
 * Created 09.07.2017 20:22
 * 
 * Copyright (c) Jonas Kohl <http://jonaskohl.de/>
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
	/// <summary>
	/// A form that indicates if a keystate has changed.
	/// </summary>
	public partial class IndicatorOverlay : Form
	{
		const int WINDOW_MARGIN = 16;

        Color BorderColour = Color.FromArgb(
                0xFF,
                0x34,
                0x4D,
                0xB4
            );

        double opacity_timer_value = 2.0;
		
		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

        protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000008 | 0x80; //WS_EX_TOPMOST
				return cp;
			}
		}
		
		protected override void OnShown(EventArgs e)
		{
			Rectangle workingArea = Screen.GetWorkingArea(new Point(0, 0));
			Left = workingArea.X + workingArea.Left + (workingArea.Width - Width - WINDOW_MARGIN);
			Top = workingArea.Y + workingArea.Top + (workingArea.Height - Height - WINDOW_MARGIN);
			
			base.OnShown(e);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawRectangle(new Pen(BorderColour, 4), e.ClipRectangle);
		}
		
		public IndicatorOverlay(string content)
		{
			InitializeComponent();
			contentLabel.Text = content;
		}
		
		public IndicatorOverlay(string content, int timeoutInMs)
		{
			InitializeComponent();
			contentLabel.Text = content;
			windowCloseTimer.Interval = timeoutInMs;
            fadeTimer.Interval = (int)Math.Floor((decimal)(timeoutInMs / 20));
		}

        public IndicatorOverlay(string content, int timeoutInMs, Color bgColour, Color fgColour, Color bdColour, Font font)
        {
            InitializeComponent();
            contentLabel.Text = content;
            Font = font;
            windowCloseTimer.Interval = timeoutInMs;
            fadeTimer.Interval = (int)Math.Floor((decimal)(timeoutInMs / 20));
            BackColor = bgColour;
            ForeColor = fgColour;
            BorderColour = bdColour;
        }

        public void UpdateIndicator(string content)
        {
            Opacity = 1;
            contentLabel.Text = content;
            opacity_timer_value = 2.0;
            windowCloseTimer.Stop();
            windowCloseTimer.Start();
            fadeTimer.Stop();
            fadeTimer.Start();
        }

        public void UpdateIndicator(string content, int timeoutInMs)
        {
            Opacity = 1;
            contentLabel.Text = content;
            opacity_timer_value = 2.0;
            windowCloseTimer.Stop();
            windowCloseTimer.Interval = timeoutInMs;
            windowCloseTimer.Start();
            fadeTimer.Stop();
            fadeTimer.Start();
        }

        public void UpdateIndicator(string content, int timeoutInMs, Color bgColour, Color fgColour, Color bdColour, Font font)
        {
            Opacity = 1;
            contentLabel.Text = content;
            Font = font;
            opacity_timer_value = 2.0;
            windowCloseTimer.Stop();
            windowCloseTimer.Interval = timeoutInMs;
            windowCloseTimer.Start();
            fadeTimer.Stop();
            fadeTimer.Start();
            BackColor = bgColour;
            ForeColor = fgColour;
            BorderColour = bdColour;
            Invalidate();
        }

        void WindowCloseTimerTick(object sender, EventArgs e)
		{
			Close();
		}

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            opacity_timer_value -= 0.1;
            if (opacity_timer_value <= 1.0)
            {
                Opacity = opacity_timer_value;
            }
        }
    }
}
