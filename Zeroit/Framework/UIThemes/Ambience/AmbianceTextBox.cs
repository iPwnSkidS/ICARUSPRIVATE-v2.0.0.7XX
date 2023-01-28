using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    [DefaultEvent("TextChanged")]
    public class AmbianceTextBox : Control
    {
        public TextBox AmbianceTB = new TextBox();

        private GraphicsPath Shape;

        private int _maxchars = 32767;

        private bool _ReadOnly;

        private bool _Multiline;

        private HorizontalAlignment ALNType;

        private bool isPasswordMasked;

        private Pen P1;

        private SolidBrush B1;

        public HorizontalAlignment TextAlignment
        {
            get
            {
                return ALNType;
            }
            set
            {
                ALNType = value;
                Invalidate();
            }
        }

        public int MaxLength
        {
            get
            {
                return _maxchars;
            }
            set
            {
                _maxchars = value;
                AmbianceTB.MaxLength = MaxLength;
                Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return isPasswordMasked;
            }
            set
            {
                AmbianceTB.UseSystemPasswordChar = UseSystemPasswordChar;
                isPasswordMasked = value;
                Invalidate();
            }
        }

        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (AmbianceTB != null)
                {
                    AmbianceTB.ReadOnly = value;
                }
            }
        }

        public bool Multiline
        {
            get
            {
                return _Multiline;
            }
            set
            {
                _Multiline = value;
                if (AmbianceTB != null)
                {
                    AmbianceTB.Multiline = value;
                    if (value)
                    {
                        AmbianceTB.Height = base.Height - 10;
                    }
                    else
                    {
                        base.Height = AmbianceTB.Height + 10;
                    }
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AmbianceTB.Text = Text;
            Invalidate();
        }

        private void OnBaseTextChanged(object sender, EventArgs e)
        {
            Text = AmbianceTB.Text;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            AmbianceTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            AmbianceTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void _OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                AmbianceTB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                AmbianceTB.Copy();
                e.SuppressKeyPress = true;
            }
        }

        private void _Enter(object sender, EventArgs e)
        {
            P1 = new Pen(Color.FromArgb(205, 87, 40));
            Refresh();
        }

        private void _Leave(object sender, EventArgs e)
        {
            P1 = new Pen(Color.FromArgb(180, 180, 180));
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_Multiline)
            {
                AmbianceTB.Height = base.Height - 10;
            }
            else
            {
                base.Height = AmbianceTB.Height + 10;
            }
            Shape = new GraphicsPath();
            GraphicsPath shape = Shape;
            shape.AddArc(0, 0, 10, 10, 180f, 90f);
            shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
            shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
            shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
            shape.CloseAllFigures();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            AmbianceTB.Focus();
        }

        public void AddTextBox()
        {
            TextBox ambianceTB = AmbianceTB;
            ambianceTB.Size = new Size(base.Width - 10, 33);
            ambianceTB.Location = new Point(7, 4);
            ambianceTB.Text = string.Empty;
            ambianceTB.BorderStyle = BorderStyle.None;
            ambianceTB.TextAlign = HorizontalAlignment.Left;
            ambianceTB.Font = new Font("Tahoma", 11f);
            ambianceTB.UseSystemPasswordChar = UseSystemPasswordChar;
            ambianceTB.Multiline = false;
            AmbianceTB.KeyDown += _OnKeyDown;
            AmbianceTB.Enter += _Enter;
            AmbianceTB.Leave += _Leave;
            AmbianceTB.TextChanged += OnBaseTextChanged;
        }

        public AmbianceTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            AddTextBox();
            base.Controls.Add(AmbianceTB);
            P1 = new Pen(Color.FromArgb(180, 180, 180));
            B1 = new SolidBrush(Color.White);
            BackColor = Color.Transparent;
            ForeColor = Color.DimGray;
            Text = null;
            Font = new Font("Tahoma", 11f);
            base.Size = new Size(135, 33);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            TextBox ambianceTB = AmbianceTB;
            ambianceTB.Width = base.Width - 10;
            ambianceTB.TextAlign = TextAlignment;
            ambianceTB.UseSystemPasswordChar = UseSystemPasswordChar;
            graphics.Clear(Color.Transparent);
            graphics.FillPath(B1, Shape);
            graphics.DrawPath(P1, Shape);
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            graphics.Dispose();
            bitmap.Dispose();
        }
    }
}
