/*
 * Created 09.07.2017 20:22
 * 
 * Copyright (c) Jonas Kohl <https://jonaskohl.de/>
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
        private IndicatorDisplayPosition pos = IndicatorDisplayPosition.BottomRight;

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
            UpdatePosition();

            base.OnShown(e);
		}

        void UpdatePosition()
        {
            Rectangle workingArea = Screen.GetWorkingArea(new Point(0, 0));

            switch (pos)
            {
                case IndicatorDisplayPosition.TopLeft:
                    Left = workingArea.X + WINDOW_MARGIN;
                    Top = workingArea.Y + WINDOW_MARGIN;
                    break;
                case IndicatorDisplayPosition.TopCenter:
                    Left = workingArea.X + (workingArea.Width / 2 - Width / 2);
                    Top = workingArea.Y + WINDOW_MARGIN;
                    break;
                case IndicatorDisplayPosition.TopRight:
                    Left = workingArea.X + workingArea.Left + (workingArea.Width - Width - WINDOW_MARGIN - workingArea.Left);
                    Top = workingArea.Y + WINDOW_MARGIN;
                    break;
                case IndicatorDisplayPosition.MiddleLeft:
                    Left = workingArea.X + WINDOW_MARGIN;
                    Top = workingArea.Y + (workingArea.Height / 2 - Height / 2);
                    break;
                case IndicatorDisplayPosition.MiddleCenter:
                    Left = workingArea.X + (workingArea.Width / 2 - Width / 2);
                    Top = workingArea.Y + (workingArea.Height / 2 - Height / 2);
                    break;
                case IndicatorDisplayPosition.MiddleRight:
                    Left = workingArea.X + workingArea.Left + (workingArea.Width - Width - WINDOW_MARGIN - workingArea.Left);
                    Top = workingArea.Y + (workingArea.Height / 2 - Height / 2);
                    break;
                case IndicatorDisplayPosition.BottomLeft:
                    Left = workingArea.X + WINDOW_MARGIN;
                    Top = workingArea.Y + workingArea.Top + (workingArea.Height - Height - WINDOW_MARGIN - workingArea.Top);
                    break;
                case IndicatorDisplayPosition.BottomCenter:
                    Left = workingArea.X + (workingArea.Width / 2 - Width / 2);
                    Top = workingArea.Y + workingArea.Top + (workingArea.Height - Height - WINDOW_MARGIN - workingArea.Top);
                    break;
                case IndicatorDisplayPosition.BottomRight:
                    Left = workingArea.X + workingArea.Left + (workingArea.Width - Width - WINDOW_MARGIN - workingArea.Left);
                    Top = workingArea.Y + workingArea.Top + (workingArea.Height - Height - WINDOW_MARGIN - workingArea.Top);
                    break;
                default:
                    break;
            }
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
		
		public IndicatorOverlay(string content, int timeoutInMs, IndicatorDisplayPosition position)
        {
            pos = position;
            InitializeComponent();
			contentLabel.Text = content;
            if (timeoutInMs < 0)
            {
                windowCloseTimer.Enabled = false;
                fadeTimer.Enabled = false;
            }
            else
            {
                windowCloseTimer.Interval = timeoutInMs;
                fadeTimer.Interval = (int)Math.Floor((decimal)(timeoutInMs / 20));
            }
		}

        public IndicatorOverlay(string content, int timeoutInMs, Color bgColour, Color fgColour, Color bdColour, Font font, IndicatorDisplayPosition position)
        {
            pos = position;
            InitializeComponent();
            contentLabel.Text = content;
            Font = font;
            if (timeoutInMs < 0)
            {
                windowCloseTimer.Enabled = false;
                fadeTimer.Enabled = false;
            }
            else
            {
                windowCloseTimer.Interval = timeoutInMs;
                fadeTimer.Interval = (int)Math.Floor((decimal)(timeoutInMs / 20));
            }
            BackColor = bgColour;
            ForeColor = fgColour;
            BorderColour = bdColour;
        }

        public void UpdateIndicator(string content, IndicatorDisplayPosition position)
        {
            pos = position;
            Opacity = 1;
            contentLabel.Text = content;
            opacity_timer_value = 2.0;
            windowCloseTimer.Stop();
            windowCloseTimer.Start();
            fadeTimer.Stop();
            fadeTimer.Start();
            UpdatePosition();
        }

        public void UpdateIndicator(string content, int timeoutInMs, IndicatorDisplayPosition position)
        {
            pos = position;
            Opacity = 1;
            contentLabel.Text = content;
            opacity_timer_value = 2.0;
            if (timeoutInMs < 0)
            {
                windowCloseTimer.Enabled = false;
                fadeTimer.Enabled = false;
            }
            else
            {
                windowCloseTimer.Stop();
                windowCloseTimer.Interval = timeoutInMs;
                windowCloseTimer.Start();
                fadeTimer.Stop();
                fadeTimer.Start();
            }
            UpdatePosition();
        }

        public void UpdateIndicator(string content, int timeoutInMs, Color bgColour, Color fgColour, Color bdColour, Font font, IndicatorDisplayPosition position)
        {
            pos = position;
            Opacity = 1;
            contentLabel.Text = content;
            Font = font;
            opacity_timer_value = 2.0;
            if (timeoutInMs < 0)
            {
                windowCloseTimer.Enabled = false;
                fadeTimer.Enabled = false;
            }
            else
            {
                windowCloseTimer.Stop();
                windowCloseTimer.Interval = timeoutInMs;
                windowCloseTimer.Start();
                fadeTimer.Stop();
                fadeTimer.Start();
            }
            BackColor = bgColour;
            ForeColor = fgColour;
            BorderColour = bdColour;
            Invalidate();
            UpdatePosition();
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
