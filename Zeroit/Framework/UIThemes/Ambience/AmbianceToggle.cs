using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    [DefaultEvent("ToggledChanged")]
    public class AmbianceToggle : Control
    {
        public enum _Type
        {
            OnOff,
            YesNo,
            IO
        }

        public delegate void ToggledChangedEventHandler();

        private bool _Toggled;

        private _Type ToggleType;

        private Rectangle Bar;

        private Size cHandle = new Size(15, 20);

        public bool Toggled
        {
            get
            {
                return _Toggled;
            }
            set
            {
                _Toggled = value;
                Invalidate();
                if (ToggledChanged != null)
                {
                    ToggledChanged();
                }
            }
        }

        public _Type Type
        {
            get
            {
                return ToggleType;
            }
            set
            {
                ToggleType = value;
                Invalidate();
            }
        }

        public event ToggledChangedEventHandler ToggledChanged;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Width = 79;
            base.Height = 27;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Toggled = !Toggled;
            Focus();
        }

        public AmbianceToggle()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(base.Parent.BackColor);
            int num = 3;
            Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            GraphicsPath path = RoundRectangle.RoundRect(rectangle, 4);
            LinearGradientBrush linearGradientBrush = null;
            if (_Toggled)
            {
                num = 37;
                linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(231, 108, 58), Color.FromArgb(236, 113, 63), 90f);
            }
            else
            {
                num = 0;
                linearGradientBrush = new LinearGradientBrush(rectangle, Color.FromArgb(208, 208, 208), Color.FromArgb(226, 226, 226), 90f);
            }
            graphics.FillPath(linearGradientBrush, path);
            switch (ToggleType)
            {
                case _Type.OnOff:
                    if (Toggled)
                    {
                        graphics.DrawString("ON", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        graphics.DrawString("OFF", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case _Type.YesNo:
                    if (Toggled)
                    {
                        graphics.DrawString("YES", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        graphics.DrawString("NO", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case _Type.IO:
                    if (Toggled)
                    {
                        graphics.DrawString("I", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.WhiteSmoke, Bar.X + 18, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        graphics.DrawString("O", new Font("Segoe UI", 12f, FontStyle.Regular), Brushes.DimGray, Bar.X + 59, (float)((double)Bar.Y + 13.5), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }
            Rectangle rectangle2 = new Rectangle(num, 0, base.Width - 38, base.Height);
            GraphicsPath path2 = RoundRectangle.RoundRect(rectangle2, 4);
            LinearGradientBrush brush = new LinearGradientBrush(rectangle2, Color.FromArgb(253, 253, 253), Color.FromArgb(240, 238, 237), LinearGradientMode.Vertical);
            graphics.FillPath(brush, path2);
            if (_Toggled)
            {
                graphics.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), path2);
                graphics.DrawPath(new Pen(Color.FromArgb(185, 89, 55)), path);
            }
            else
            {
                graphics.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), path2);
                graphics.DrawPath(new Pen(Color.FromArgb(181, 181, 181)), path);
            }
        }
    }
}
