using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    [DefaultEvent("TextChanged")]
    public class AmbianceRichTextBox : Control
    {
        public RichTextBox AmbianceRTB = new RichTextBox();

        private bool _ReadOnly;

        private bool _WordWrap;

        private bool _AutoWordSelection;

        private GraphicsPath Shape;

        private Pen P1;

        public override string Text
        {
            get
            {
                return AmbianceRTB.Text;
            }
            set
            {
                AmbianceRTB.Text = value;
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
                if (AmbianceRTB != null)
                {
                    AmbianceRTB.ReadOnly = value;
                }
            }
        }

        public bool WordWrap
        {
            get
            {
                return _WordWrap;
            }
            set
            {
                _WordWrap = value;
                if (AmbianceRTB != null)
                {
                    AmbianceRTB.WordWrap = value;
                }
            }
        }

        public bool AutoWordSelection
        {
            get
            {
                return _AutoWordSelection;
            }
            set
            {
                _AutoWordSelection = value;
                if (AmbianceRTB != null)
                {
                    AmbianceRTB.AutoWordSelection = value;
                }
            }
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            AmbianceRTB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            AmbianceRTB.Font = Font;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AmbianceRTB.Size = new Size(base.Width - 13, base.Height - 11);
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
            Shape = new GraphicsPath();
            GraphicsPath shape = Shape;
            shape.AddArc(0, 0, 10, 10, 180f, 90f);
            shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
            shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
            shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
            shape.CloseAllFigures();
        }

        public void _TextChanged(object sender, EventArgs e)
        {
            AmbianceRTB.Text = Text;
        }

        public void AddRichTextBox()
        {
            RichTextBox ambianceRTB = AmbianceRTB;
            ambianceRTB.BackColor = Color.White;
            ambianceRTB.Size = new Size(base.Width - 10, 100);
            ambianceRTB.Location = new Point(7, 5);
            ambianceRTB.Text = string.Empty;
            ambianceRTB.BorderStyle = BorderStyle.None;
            ambianceRTB.Font = new Font("Tahoma", 10f);
            ambianceRTB.Multiline = true;
        }

        public AmbianceRichTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.UserPaint, value: true);
            AddRichTextBox();
            base.Controls.Add(AmbianceRTB);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(76, 76, 76);
            P1 = new Pen(Color.FromArgb(180, 180, 180));
            Text = null;
            Font = new Font("Tahoma", 10f);
            base.Size = new Size(150, 100);
            WordWrap = true;
            AutoWordSelection = false;
            DoubleBuffered = true;
            AmbianceRTB.Enter += _Enter;
            AmbianceRTB.Leave += _Leave;
            base.TextChanged += _TextChanged;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);
            graphics.FillPath(Brushes.White, Shape);
            graphics.DrawPath(P1, Shape);
            graphics.Dispose();
            e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
            bitmap.Dispose();
        }
    }
}
