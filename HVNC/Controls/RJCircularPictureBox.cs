using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.HVNC.Controls
{
    public class RJCircularPictureBox : PictureBox
    {
        private int borderSize = 2;

        private Color borderColor = Color.RoyalBlue;

        private Color borderColor2 = Color.HotPink;

        private DashStyle borderLineStyle;

        private DashCap borderCapStyle;

        private float gradientAngle = 50f;

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor2
        {
            get
            {
                return borderColor2;
            }
            set
            {
                borderColor2 = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashStyle BorderLineStyle
        {
            get
            {
                return borderLineStyle;
            }
            set
            {
                borderLineStyle = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public DashCap BorderCapStyle
        {
            get
            {
                return borderCapStyle;
            }
            set
            {
                borderCapStyle = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public float GradientAngle
        {
            get
            {
                return gradientAngle;
            }
            set
            {
                gradientAngle = value;
                Invalidate();
            }
        }

        public RJCircularPictureBox()
        {
            base.Size = new Size(100, 100);
            base.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Size = new Size(base.Width, base.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            Rectangle rect = Rectangle.Inflate(base.ClientRectangle, -1, -1);
            Rectangle rect2 = Rectangle.Inflate(rect, -borderSize, -borderSize);
            int num = ((borderSize <= 0) ? 1 : (borderSize * 3));
            using LinearGradientBrush brush = new LinearGradientBrush(rect2, borderColor, borderColor2, gradientAngle);
            using GraphicsPath graphicsPath = new GraphicsPath();
            using Pen pen2 = new Pen(base.Parent.BackColor, num);
            using Pen pen = new Pen(brush, borderSize);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pen.DashStyle = borderLineStyle;
            pen.DashCap = borderCapStyle;
            graphicsPath.AddEllipse(rect);
            base.Region = new Region(graphicsPath);
            graphics.DrawEllipse(pen2, rect);
            if (borderSize > 0)
            {
                graphics.DrawEllipse(pen, rect2);
            }
        }
    }
}
