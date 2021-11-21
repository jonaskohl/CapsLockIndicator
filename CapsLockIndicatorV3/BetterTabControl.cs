/**
 * Based on "A .NET Flat TabControl (CustomDraw)"
 * by Oscar Londono
 * published as Public Domain
 * 
 * https://www.codeproject.com/Articles/12185/A-NET-Flat-TabControl-CustomDraw
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public class BetterTabControl : TabControl
    {
        private System.ComponentModel.Container components = null;
        private SubClass scUpDown = null;
        private bool bUpDown; // true when the button UpDown is required
        private ImageList leftRightImages = null;
        private const int nMargin = 5;
        private Color mBackColor = SystemColors.Control;
        private int hoveredTab = -1;

        private Dictionary<int, Native.DRAWITEMSTRUCT> itemStates = new Dictionary<int, Native.DRAWITEMSTRUCT>();

        private bool _darkMode;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool DarkMode
        {
            get => _darkMode;
            set
            {
                _darkMode = value;
                UpdateDarkMode();
            }
        }

        private void UpdateDarkMode()
        {
            SetStyles();
            UpdateStyles();

            RecreateHandle();

            Application.DoEvents();

            if (_darkMode)
            {
                FindUpDown();
                UpdateUpDown();
            }
        }

        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, _darkMode);
            SetStyle(ControlStyles.AllPaintingInWmPaint, _darkMode);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public BetterTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            bUpDown = false;

            SetStyles();

            ControlAdded += new ControlEventHandler(FlatTabControl_ControlAdded);
            ControlRemoved += new ControlEventHandler(FlatTabControl_ControlRemoved);
            SelectedIndexChanged += new EventHandler(FlatTabControl_SelectedIndexChanged);

            leftRightImages = new ImageList();
            leftRightImages.ImageSize = new Size(16, 16); // default

            var resources = new ResourceManager("CapsLockIndicatorV3.resources", Assembly.GetExecutingAssembly());
            Bitmap updownImage = ((Bitmap)resources.GetObject("TabIcons"));

            if (updownImage != null)
            {
                updownImage.MakeTransparent(Color.Fuchsia);
                leftRightImages.Images.AddStrip(updownImage);
            }

            UpdateDarkMode();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                leftRightImages.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_darkMode)
                DrawControl(e.Graphics);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (Native.WM_REFLECT | Native.WM_DRAWITEM))
            {
                var dis = (Native.DRAWITEMSTRUCT)m.GetLParam(typeof(Native.DRAWITEMSTRUCT));
                var index = dis.itemID;
                itemStates[index] = dis;
            }

            base.WndProc(ref m);
        }

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle TabControlArea = ClientRectangle;
            Rectangle TabArea = DisplayRectangle;

            //----------------------------
            // fill client area
            using (Brush br = new SolidBrush(mBackColor))
                g.FillRectangle(br, TabControlArea);
            //----------------------------

            //----------------------------
            // draw border
            int nDelta = SystemInformation.Border3DSize.Width;

            TabArea.Inflate(nDelta, nDelta);
            using (Pen border = new Pen(SystemColors.ControlDark))
                g.DrawRectangle(border, TabArea);
            //----------------------------


            //----------------------------
            // clip region for drawing tabs
            using (Region rsaved = g.Clip)
            {
                Rectangle rreg;

                int nWidth = TabArea.Width + nMargin;
                if (bUpDown)
                {
                    // exclude updown control for painting
                    if (scUpDown?.Handle != null && Native.IsWindowVisible(scUpDown.Handle))
                    {
                        Rectangle rupdown = new Rectangle();
                        Native.GetWindowRect(scUpDown.Handle, ref rupdown);
                        Rectangle rupdown2 = RectangleToClient(rupdown);

                        nWidth = rupdown2.X;
                    }
                }

                rreg = new Rectangle(TabArea.Left, TabControlArea.Top, nWidth - nMargin, TabControlArea.Height);

                g.SetClip(rreg);

                // draw tabs
                for (int i = 0; i < TabCount; i++)
                    DrawTab(g, TabPages[i], i);

                g.Clip = rsaved;
            }
            //----------------------------


            //----------------------------
            // draw background to cover flat border areas
            if (SelectedTab != null)
            {
                TabPage tabPage = SelectedTab;
                Color color = tabPage.BackColor;
                using (Pen border = new Pen(color))
                {
                    TabArea.Offset(1, 1);
                    TabArea.Width -= 2;
                    TabArea.Height -= 2;

                    g.DrawRectangle(border, TabArea);
                    TabArea.Width -= 1;
                    TabArea.Height -= 1;
                    g.DrawRectangle(border, TabArea);
                }
            }
            //----------------------------
        }

        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            var tr = GetTabRectDPI(nIndex);
            Rectangle recBounds = tr;
            recBounds.Y -= 2;
            recBounds.Height += 2;
            RectangleF tabTextArea = recBounds;

            bool bSelected = (SelectedIndex == nIndex);

            var state = new Native.DRAWITEMSTRUCT();
            state.itemID = nIndex;
            state.hwndItem = tabPage.Handle;
            state.rcItem = new Native.RECT()
            {
                Left = recBounds.Left,
                Top = recBounds.Top,
                Right = recBounds.Right,
                Bottom = recBounds.Bottom
            };
            state.itemState = (int)(bSelected ? (DrawItemState.Selected | DrawItemState.NoFocusRect) : DrawItemState.Default);

            if (itemStates.ContainsKey(nIndex))
                state = itemStates[nIndex];

            if (!bSelected)
            {
                recBounds = new Rectangle(
                    recBounds.X,
                    recBounds.Y + 2,
                    recBounds.Width,
                    recBounds.Height - 2
                );
                tabTextArea = recBounds;
            }

            //----------------------------
            // fill this tab with background color
            using (Brush br = new SolidBrush(hoveredTab == nIndex && !bSelected ? Color.FromArgb(35, 66, 89) : tabPage.BackColor))
                g.FillRectangle(br, recBounds);
            //----------------------------

            //----------------------------
            // draw border
            g.DrawRectangle(SystemPens.ControlDark, recBounds);

            if (bSelected)
            {
                //----------------------------
                // clear bottom lines
                using (Pen pen = new Pen(tabPage.BackColor))
                {

                    switch (Alignment)
                    {
                        case TabAlignment.Top:
                            g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                            g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
                            break;

                        case TabAlignment.Bottom:
                            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                            g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                            break;
                    }

                }
                //----------------------------
            }
            //----------------------------

            //----------------------------
            // draw tab's icon
            if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
            {
                int nLeftMargin = 8;
                int nRightMargin = 2;

                Image img = ImageList.Images[tabPage.ImageIndex];

                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);

                // adjust rectangles
                float nAdj = nLeftMargin + img.Width + nRightMargin;

                rimage.Y += (recBounds.Height - img.Height) / 2;
                tabTextArea.X += nAdj;
                tabTextArea.Width -= nAdj;

                // draw icon
                g.DrawImage(img, rimage);
            }
            //----------------------------

            //----------------------------
            // draw string
            using (StringFormat stringFormat = new StringFormat())
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.FormatFlags |= StringFormatFlags.NoWrap;

                using (Brush br = new SolidBrush(tabPage.ForeColor))
                    g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
            }
            //----------------------------

            if (bSelected && !((DrawItemState)state.itemState).HasFlag(DrawItemState.NoFocusRect))
            {
                var focusRect = recBounds;
                focusRect.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(g, focusRect);
            }
        }

        private Rectangle GetTabRectDPI(int nIndex)
        {
            var rect = GetTabRect(nIndex);
            /*
            var scale = DPIHelper.GetScalingFactorPercent();
            rect = new Rectangle(
                (int)(rect.X * scale),
                (int)(rect.Y * scale),
                (int)(rect.Width * scale),
                (int)(rect.Height * scale)
            );
            */
            return rect;
        }

        internal void DrawIcons(Graphics g)
        {
            if (!_darkMode)
                return;
            if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
                return;

            //----------------------------
            // calc positions
            Rectangle TabControlArea = ClientRectangle;

            Rectangle r0 = new Rectangle();
            Native.GetClientRect(scUpDown.Handle, ref r0);

            Brush br = new SolidBrush(mBackColor);
            g.FillRectangle(br, r0);
            br.Dispose();

            Pen border = new Pen(SystemColors.ControlDark);
            Rectangle rborder = r0;
            rborder.Inflate(-1, -1);
            g.DrawRectangle(border, rborder);
            border.Dispose();

            int nMiddle = (r0.Width / 2);
            int nTop = (r0.Height - 16) / 2;
            int nLeft = (nMiddle - 16) / 2;

            Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
            Rectangle r2 = new Rectangle(nMiddle + nLeft, nTop, 16, 16);
            //----------------------------

            //----------------------------
            // draw buttons
            Image img = leftRightImages.Images[1];
            if (img != null)
            {
                if (TabCount > 0)
                {
                    Rectangle r3 = GetTabRectDPI(0);
                    if (r3.Left < TabControlArea.Left)
                        g.DrawImage(img, r1);
                    else
                    {
                        img = leftRightImages.Images[3];
                        if (img != null)
                            g.DrawImage(img, r1);
                    }
                }
            }

            img = leftRightImages.Images[0];
            if (img != null)
            {
                if (TabCount > 0)
                {
                    Rectangle r3 = GetTabRectDPI(TabCount - 1);
                    if (r3.Right > (TabControlArea.Width - r0.Width))
                        g.DrawImage(img, r2);
                    else
                    {
                        img = leftRightImages.Images[2];
                        if (img != null)
                            g.DrawImage(img, r2);
                    }
                }
            }
            //----------------------------
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FindUpDown();

            UpdateItemSize();
        }

        public void UpdateItemSize()
        {
            const int H_PAD = 4;

            var scale = DPIHelper.GetScalingFactorPercent(Handle);

            int w = 0;
            foreach (var tabText in TabPages.OfType<TabPage>().Select(p => p.Text).Where(p => p.Length > 0))
                w = Math.Max(w, TextRenderer.MeasureText(tabText, Font).Width);

            if (w < 1)
                return;

            w += H_PAD * 2;

            ItemSize = new Size(w, (int)(24 * scale));
            SizeMode = TabSizeMode.Fixed;
        }

        private void FlatTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (_darkMode)
            {
                FindUpDown();
                UpdateUpDown();
            }
        }

        private void FlatTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (_darkMode)
            {
                FindUpDown();
                UpdateUpDown();
            }
        }

        private void FlatTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_darkMode)
            {
                UpdateUpDown();
                Invalidate();   // we need to update border and background colors
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var pos = PointToClient(Cursor.Position);
            var index = -1;
            for (var i = 0; i < TabCount; ++i)
            {
                var rect = GetTabRectDPI(i);
                if (rect.Contains(pos))
                {
                    index = i;
                    break;
                }
            }

            if (index != hoveredTab)
            {
                hoveredTab = index;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            var prevIndex = hoveredTab;
            hoveredTab = -1;
            if (prevIndex != -1)
                Invalidate();
            base.OnMouseLeave(e);
        }

        private void FindUpDown()
        {
            bool bFound = false;

            // find the UpDown control
            IntPtr pWnd = Native.GetWindow(Handle, Native.GW_CHILD);

            while (pWnd != IntPtr.Zero)
            {
                //----------------------------
                // Get the window class name
                char[] className = new char[33];

                int length = Native.GetClassName(pWnd, className, 32);

                string s = new string(className, 0, length);
                //----------------------------

                if (s == "msctls_updown32")
                {
                    bFound = true;

                    if (!bUpDown)
                    {
                        //----------------------------
                        // Subclass it
                        scUpDown = new SubClass(pWnd, true);
                        scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
                        //----------------------------

                        bUpDown = true;
                    }
                    break;
                }

                pWnd = Native.GetWindow(pWnd, Native.GW_HWNDNEXT);
            }

            if ((!bFound) && (bUpDown))
                bUpDown = false;
        }

        private void UpdateUpDown()
        {
            if (!_darkMode)
                return;

            if (bUpDown)
            {
                if (scUpDown?.Handle != null && Native.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rect = new Rectangle();

                    Native.GetClientRect(scUpDown.Handle, ref rect);
                    Native.InvalidateRect(scUpDown.Handle, ref rect, true);
                }
            }
        }

        #region scUpDown_SubClassedWndProc Event Handler

        private int scUpDown_SubClassedWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Native.WM_PAINT:
                    {
                        //------------------------
                        // redraw
                        IntPtr hDC = Native.GetWindowDC(scUpDown.Handle);
                        using (Graphics g = Graphics.FromHdc(hDC))
                            DrawIcons(g);
                        Native.ReleaseDC(scUpDown.Handle, hDC);
                        //------------------------

                        // return 0 (processed)
                        m.Result = IntPtr.Zero;

                        //------------------------
                        // validate current rect
                        Rectangle rect = new Rectangle();

                        Native.GetClientRect(scUpDown.Handle, ref rect);
                        Native.ValidateRect(scUpDown.Handle, ref rect);
                        //------------------------
                    }
                    return 1;
            }

            return 0;
        }
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }


        #endregion

        #region Properties

        [Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                TabAlignment ta = value;
                if ((ta != TabAlignment.Top) && (ta != TabAlignment.Bottom))
                    ta = TabAlignment.Top;

                base.Alignment = ta;
            }
        }

        [Browsable(false)]
        new public bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = false; }
        }

        [Browsable(true), Category("Appearance")]
        public Color MyBackColor
        {
            get { return mBackColor; }
            set { mBackColor = value; Invalidate(); }
        }

        #endregion

        #region TabpageExCollectionEditor

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor(System.Type type) : base(type)
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(TabPage);
            }
        }

        #endregion
    }
}
