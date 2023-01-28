using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShitarusPrivate
{
    public class FlatNumericUpDown : NumericUpDown
    {
        private class UpDownButtonRenderer : NativeWindow
        {
            public struct PAINTSTRUCT
            {
                public IntPtr hdc;

                public bool fErase;

                public int rcPaint_left;

                public int rcPaint_top;

                public int rcPaint_right;

                public int rcPaint_bottom;

                public bool fRestore;

                public bool fIncUpdate;

                public int reserved1;

                public int reserved2;

                public int reserved3;

                public int reserved4;

                public int reserved5;

                public int reserved6;

                public int reserved7;

                public int reserved8;
            }

            private Control updown;

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern IntPtr BeginPaint(IntPtr hWnd, [In][Out] ref PAINTSTRUCT lpPaint);

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

            public UpDownButtonRenderer(Control c)
            {
                updown = c;
                if (updown.IsHandleCreated)
                {
                    AssignHandle(updown.Handle);
                }
                else
                {
                    updown.HandleCreated += __002Ector_b__4_0;
                }
            }

            private Point[] GetDownArrow(Rectangle r)
            {
                Point point = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[3]
                {
                    new Point(point.X - 3, point.Y - 2),
                    new Point(point.X + 4, point.Y - 2),
                    new Point(point.X, point.Y + 2)
                };
            }

            private Point[] GetUpArrow(Rectangle r)
            {
                Point point = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new Point[3]
                {
                    new Point(point.X - 4, point.Y + 2),
                    new Point(point.X + 4, point.Y + 2),
                    new Point(point.X, point.Y - 3)
                };
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 15 && ((FlatNumericUpDown)updown.Parent).BorderStyle == BorderStyle.FixedSingle)
                {
                    PAINTSTRUCT lpPaint = default(PAINTSTRUCT);
                    BeginPaint(updown.Handle, ref lpPaint);
                    using (Graphics graphics = Graphics.FromHdc(lpPaint.hdc))
                    {
                        bool enabled;
                        using (SolidBrush brush = new SolidBrush((enabled = updown.Enabled) ? ((FlatNumericUpDown)updown.Parent).BackColor : SystemColors.Control))
                        {
                            graphics.FillRectangle(brush, updown.ClientRectangle);
                        }
                        Rectangle rectangle = new Rectangle(0, 0, updown.Width, updown.Height / 2);
                        Rectangle rectangle2 = new Rectangle(0, updown.Height / 2, updown.Width, updown.Height / 2 + 1);
                        Point pt = updown.PointToClient(Control.MousePosition);
                        if (enabled && updown.ClientRectangle.Contains(pt))
                        {
                            using (SolidBrush brush2 = new SolidBrush(((FlatNumericUpDown)updown.Parent).ButtonHighlightColor))
                            {
                                if (rectangle.Contains(pt))
                                {
                                    graphics.FillRectangle(brush2, rectangle);
                                }
                                else
                                {
                                    graphics.FillRectangle(brush2, rectangle2);
                                }
                            }
                            using Pen pen = new Pen(((FlatNumericUpDown)updown.Parent).BorderColor);
                            graphics.DrawLines(pen, new Point[4]
                            {
                                new Point(0, 0),
                                new Point(0, updown.Height),
                                new Point(0, updown.Height / 2),
                                new Point(updown.Width, updown.Height / 2)
                            });
                        }
                        graphics.FillPolygon(Brushes.Black, GetUpArrow(rectangle));
                        graphics.FillPolygon(Brushes.Black, GetDownArrow(rectangle2));
                    }
                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    EndPaint(updown.Handle, ref lpPaint);
                }
                else if (m.Msg == 20)
                {
                    using (Graphics graphics2 = Graphics.FromHdcInternal(m.WParam))
                    {
                        graphics2.FillRectangle(Brushes.White, updown.ClientRectangle);
                    }
                    m.Result = (IntPtr)1;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            [CompilerGenerated]
            private void __002Ector_b__4_0(object sender, EventArgs e)
            {
                AssignHandle(updown.Handle);
            }
        }

        private Color borderColor = Color.Gray;

        private Color buttonHighlightColor = Color.LightGray;

        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Color), "LightGray")]
        public Color ButtonHighlightColor
        {
            get
            {
                return buttonHighlightColor;
            }
            set
            {
                if (buttonHighlightColor != value)
                {
                    buttonHighlightColor = value;
                    Invalidate();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 33554432;
                return createParams;
            }
        }

        public FlatNumericUpDown()
        {
            new UpDownButtonRenderer(base.Controls[0]);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (base.BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen pen = new Pen(BorderColor, 1f))
                {
                    e.Graphics.DrawRectangle(pen, base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
                }
            }
        }
    }
}