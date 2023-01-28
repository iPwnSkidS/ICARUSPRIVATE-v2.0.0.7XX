using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceNumericUpDown : Control
    {
        public enum _TextAlignment
        {
            Near,
            Center
        }

        private GraphicsPath Shape;

        private Pen P1;

        private long _Value;

        private long _Minimum;

        private long _Maximum;

        private int Xval;

        private bool KeyboardNum;

        private _TextAlignment MyStringAlignment;

        private Timer LongPressTimer = new Timer();

        public long Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if ((value <= _Maximum) & (value >= _Minimum))
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        public long Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value < _Maximum)
                {
                    _Minimum = value;
                }
                if (_Value < _Minimum)
                {
                    _Value = Minimum;
                }
                Invalidate();
            }
        }

        public long Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value > _Minimum)
                {
                    _Maximum = value;
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
                Invalidate();
            }
        }

        public _TextAlignment TextAlignment
        {
            get
            {
                return MyStringAlignment;
            }
            set
            {
                MyStringAlignment = value;
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 28;
            MinimumSize = new Size(93, 28);
            Shape = new GraphicsPath();
            Shape.AddArc(0, 0, 10, 10, 180f, 90f);
            Shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
            Shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
            Shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
            Shape.CloseAllFigures();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Xval = e.Location.X;
            Invalidate();
            if (e.X < base.Width - 50)
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Default;
            }
            if (e.X > base.Width - 25 && e.X < base.Width - 10)
            {
                Cursor = Cursors.Hand;
            }
            if (e.X > base.Width - 44 && e.X < base.Width - 33)
            {
                Cursor = Cursors.Hand;
            }
        }

        private void ClickButton()
        {
            if (Xval > base.Width - 25 && Xval < base.Width - 10)
            {
                if (Value + 1L <= _Maximum)
                {
                    _Value++;
                }
            }
            else
            {
                if (Xval > base.Width - 44 && Xval < base.Width - 33 && Value - 1L >= _Minimum)
                {
                    _Value--;
                }
                KeyboardNum = !KeyboardNum;
            }
            Focus();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            ClickButton();
            LongPressTimer.Start();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            LongPressTimer.Stop();
        }

        private void LongPressTimer_Tick(object sender, EventArgs e)
        {
            ClickButton();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (KeyboardNum)
                {
                    _Value = long.Parse(_Value + e.KeyChar.ToString().ToString());
                }
                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Back)
            {
                string text = _Value.ToString();
                text = text.Remove(Convert.ToInt32(text.Length - 1));
                if (text.Length == 0)
                {
                    text = "0";
                }
                _Value = Convert.ToInt32(text);
            }
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                if (Value + 1L <= _Maximum)
                {
                    _Value++;
                }
                Invalidate();
            }
            else
            {
                if (Value - 1L >= _Minimum)
                {
                    _Value--;
                }
                Invalidate();
            }
        }

        public AmbianceNumericUpDown()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            P1 = new Pen(Color.FromArgb(180, 180, 180));
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(76, 76, 76);
            _Minimum = 0L;
            _Maximum = 100L;
            Font = new Font("Tahoma", 11f);
            base.Size = new Size(70, 28);
            MinimumSize = new Size(62, 28);
            DoubleBuffered = true;
            LongPressTimer.Tick += LongPressTimer_Tick;
            LongPressTimer.Interval = 300;
        }

        public void Increment(int Value)
        {
            _Value += Value;
            Invalidate();
        }

        public void Decrement(int Value)
        {
            _Value -= Value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            LinearGradientBrush linearGradientBrush = null;
            linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(246, 246, 246), Color.FromArgb(254, 254, 254), 90f);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);
            graphics.FillPath(linearGradientBrush, Shape);
            graphics.DrawPath(P1, Shape);
            graphics.DrawString("+", new Font("Tahoma", 14f), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(base.Width - 25, 1, 19, 30));
            graphics.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), base.Width - 28, 1, base.Width - 28, base.Height - 2);
            graphics.DrawString("-", new Font("Tahoma", 14f), new SolidBrush(Color.FromArgb(75, 75, 75)), new Rectangle(base.Width - 44, 1, 19, 30));
            graphics.DrawLine(new Pen(Color.FromArgb(229, 228, 227)), base.Width - 48, 1, base.Width - 48, base.Height - 2);
            switch (MyStringAlignment)
            {
                case _TextAlignment.Center:
                    graphics.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(0, 0, base.Width - 1, base.Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case _TextAlignment.Near:
                    graphics.DrawString(Convert.ToString(Value), Font, new SolidBrush(ForeColor), new Rectangle(5, 0, base.Width - 1, base.Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            graphics.Dispose();
            bitmap.Dispose();
        }
    }
}
