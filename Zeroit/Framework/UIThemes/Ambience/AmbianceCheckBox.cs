using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    [DefaultEvent("CheckedChanged")]
    public class AmbianceCheckBox : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);

        private GraphicsPath Shape;

        private LinearGradientBrush GB;

        private Rectangle R1;

        private Rectangle R2;

        private bool _Checked;

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                if (this.CheckedChanged != null)
                {
                    this.CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;

        public AmbianceCheckBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12f);
            base.Size = new Size(171, 26);
        }

        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            if (this.CheckedChanged != null)
            {
                this.CheckedChanged(this);
            }
            Focus();
            Invalidate();
            base.OnClick(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (base.Width > 0 && base.Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(17, 0, base.Width, base.Height + 1);
                R2 = new Rectangle(0, 0, base.Width, base.Height);
                GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90f);
                GraphicsPath shape = Shape;
                shape.AddArc(0, 0, 7, 7, 180f, 90f);
                shape.AddArc(7, 0, 7, 7, -90f, 90f);
                shape.AddArc(7, 7, 7, 7, 0f, 90f);
                shape.AddArc(0, 7, 7, 7, 90f, 90f);
                shape.CloseAllFigures();
                base.Height = 15;
            }
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.Clear(base.Parent.BackColor);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(GB, Shape);
            graphics.DrawPath(new Pen(Color.FromArgb(182, 88, 55)), Shape);
            graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 95)), new Rectangle(17, 0, base.Width, base.Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center
            });
            if (Checked)
            {
                graphics.DrawString("ü", new Font("Wingdings", 12f), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-2, 1, base.Width, base.Height + 2), new StringFormat
                {
                    LineAlignment = StringAlignment.Center
                });
            }
            e.Dispose();
        }
    }
}
