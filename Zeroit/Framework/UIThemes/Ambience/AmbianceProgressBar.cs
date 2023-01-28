using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceProgressBar : Control
    {
        public enum Alignment
        {
            Right,
            Center
        }

        private int _Minimum;

        private int _Maximum = 100;

        private int _Value;

        private Alignment ALN;

        private bool _DrawHatch;

        private bool _ShowPercentage;

        private GraphicsPath GP1;

        private GraphicsPath GP2;

        private GraphicsPath GP3;

        private Rectangle R1;

        private Rectangle R2;

        private LinearGradientBrush GB1;

        private LinearGradientBrush GB2;

        private int I1;

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                if (value > _Value)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public Alignment ValueAlignment
        {
            get
            {
                return ALN;
            }
            set
            {
                ALN = value;
                Invalidate();
            }
        }

        public bool DrawHatch
        {
            get
            {
                return _DrawHatch;
            }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }

        public bool ShowPercentage
        {
            get
            {
                return _ShowPercentage;
            }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 20;
            Size minimumSize = new Size(58, 20);
            MinimumSize = minimumSize;
        }

        public AmbianceProgressBar()
        {
            _Maximum = 100;
            _ShowPercentage = true;
            _DrawHatch = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        public void Increment(int value)
        {
            _Value += value;
            Invalidate();
        }

        public void Deincrement(int value)
        {
            _Value -= value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            GP1 = RoundRectangle.RoundRect(new Rectangle(0, 0, base.Width - 1, base.Height - 1), 4);
            GP2 = RoundRectangle.RoundRect(new Rectangle(1, 1, base.Width - 3, base.Height - 3), 4);
            R1 = new Rectangle(0, 2, base.Width - 1, base.Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), R1);
            graphics.SetClip(GP1);
            graphics.FillPath(new SolidBrush(Color.FromArgb(244, 241, 243)), RoundRectangle.RoundRect(new Rectangle(1, 1, base.Width - 3, base.Height / 2 - 2), 4));
            I1 = (int)Math.Round((double)(_Value - _Minimum) / (double)(_Maximum - _Minimum) * (double)(base.Width - 3));
            if (I1 > 1)
            {
                GP3 = RoundRectangle.RoundRect(new Rectangle(1, 1, I1, base.Height - 3), 4);
                R2 = new Rectangle(1, 1, I1, base.Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(214, 89, 37), Color.FromArgb(223, 118, 75), 90f);
                graphics.FillPath(GB2, GP3);
                if (_DrawHatch)
                {
                    for (int i = 0; i <= (base.Width - 1) * _Maximum / _Value; i += 20)
                    {
                        graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10f), new Point(Convert.ToInt32(i), 0), new Point(i - 10, base.Height));
                    }
                }
                graphics.SetClip(GP3);
                graphics.SmoothingMode = SmoothingMode.None;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.ResetClip();
            }
            string s = Convert.ToString(Convert.ToInt32(Value)) + "%";
            int num = (int)((float)base.Width - graphics.MeasureString(s, Font).Width - 1f);
            int num2 = base.Height / 2 - (Convert.ToInt32(graphics.MeasureString(s, Font).Height / 2f) - 2);
            if (_ShowPercentage)
            {
                switch (ValueAlignment)
                {
                    case Alignment.Center:
                        graphics.DrawString(s, new Font("Segoe UI", 8f), Brushes.DimGray, new Rectangle(0, 0, base.Width, base.Height + 2), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case Alignment.Right:
                        graphics.DrawString(s, new Font("Segoe UI", 8f), Brushes.DimGray, new Point(num, num2));
                        break;
                }
            }
            graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), GP2);
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            graphics.Dispose();
            bitmap.Dispose();
        }
    }
}
