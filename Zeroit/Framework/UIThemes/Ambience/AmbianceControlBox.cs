using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceControlBox : Control
    {
        public enum MouseState
        {
            None,
            Over,
            Down
        }

        private MouseState State;

        private int X;

        private Rectangle CloseBtn = new Rectangle(3, 2, 17, 17);

        private Rectangle MinBtn = new Rectangle(23, 2, 17, 17);

        private Rectangle MaxBtn = new Rectangle(43, 2, 17, 17);

        private bool _EnableMaximize = true;

        public bool EnableMaximize
        {
            get
            {
                return _EnableMaximize;
            }
            set
            {
                _EnableMaximize = value;
                if (_EnableMaximize)
                {
                    base.Size = new Size(64, 22);
                }
                else
                {
                    base.Size = new Size(44, 22);
                }
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (X > 3 && X < 20)
            {
                FindForm().Close();
            }
            else if (X > 23 && X < 40)
            {
                FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 43 && X < 60 && _EnableMaximize)
            {
                if (FindForm().WindowState == FormWindowState.Maximized)
                {
                    FindForm().WindowState = FormWindowState.Minimized;
                    FindForm().WindowState = FormWindowState.Normal;
                }
                else
                {
                    FindForm().WindowState = FormWindowState.Minimized;
                    FindForm().WindowState = FormWindowState.Maximized;
                }
            }
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        public AmbianceControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.DoubleBuffer, value: true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = new Font("Marlett", 7f);
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_EnableMaximize)
            {
                base.Size = new Size(64, 22);
            }
            else
            {
                base.Size = new Size(44, 22);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            base.Location = new Point(5, 13);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            base.OnPaint(e);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90f);
            graphics.FillEllipse(brush, CloseBtn);
            graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
            graphics.DrawString("r", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
            LinearGradientBrush brush2 = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
            graphics.FillEllipse(brush2, MinBtn);
            graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
            graphics.DrawString("0", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
            if (_EnableMaximize)
            {
                LinearGradientBrush brush3 = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
                graphics.FillEllipse(brush3, MaxBtn);
                graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                graphics.DrawString("1", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
            }
            switch (State)
            {
                case MouseState.Over:
                    if (X > 3 && X < 20)
                    {
                        LinearGradientBrush brush7 = new LinearGradientBrush(CloseBtn, Color.FromArgb(248, 152, 124), Color.FromArgb(231, 92, 45), 90f);
                        graphics.FillEllipse(brush7, CloseBtn);
                        graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                        graphics.DrawString("r", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
                    }
                    else if (X > 23 && X < 40)
                    {
                        LinearGradientBrush brush8 = new LinearGradientBrush(MinBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90f);
                        graphics.FillEllipse(brush8, MinBtn);
                        graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                        graphics.DrawString("0", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
                    }
                    else if (X > 43 && X < 60 && _EnableMaximize)
                    {
                        LinearGradientBrush brush9 = new LinearGradientBrush(MaxBtn, Color.FromArgb(196, 196, 196), Color.FromArgb(173, 173, 173), 90f);
                        graphics.FillEllipse(brush9, MaxBtn);
                        graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                        graphics.DrawString("1", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                    }
                    break;
                case MouseState.None:
                {
                    LinearGradientBrush brush4 = new LinearGradientBrush(CloseBtn, Color.FromArgb(242, 132, 99), Color.FromArgb(224, 82, 33), 90f);
                    graphics.FillEllipse(brush4, CloseBtn);
                    graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), CloseBtn);
                    graphics.DrawString("r", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(6, 8, 0, 0));
                    LinearGradientBrush brush5 = new LinearGradientBrush(MinBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
                    graphics.FillEllipse(brush5, MinBtn);
                    graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MinBtn);
                    graphics.DrawString("0", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(26, 4, 0, 0));
                    if (_EnableMaximize)
                    {
                        LinearGradientBrush brush6 = new LinearGradientBrush(MaxBtn, Color.FromArgb(130, 129, 123), Color.FromArgb(103, 102, 96), 90f);
                        graphics.FillEllipse(brush6, MaxBtn);
                        graphics.DrawEllipse(new Pen(Color.FromArgb(57, 56, 53)), MaxBtn);
                        graphics.DrawString("1", new Font("Marlett", 7f), new SolidBrush(Color.FromArgb(52, 50, 46)), new Rectangle(46, 7, 0, 0));
                    }
                    break;
                }
            }
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            graphics.Dispose();
            bitmap.Dispose();
        }
    }
}
