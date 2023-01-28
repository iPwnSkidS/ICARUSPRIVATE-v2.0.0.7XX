using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusProgressBar : ThemedControl
    {
        private int PValue = 50;

        private int _Maximum = 100;

        public int Value
        {
            get
            {
                return PValue;
            }
            set
            {
                PValue = value;
                Invalidate();
            }
        }

        public int Minimum { get; set; }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }

        public NexusProgressBar()
        {
            Font = new Font("Segoe UI", 11f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(BackColor);
            base.Height = 24;
            Rectangle rectangle = new Rectangle(2, 2, Convert.ToInt32(ValueToPercentage(PValue) * (float)base.Width - 5f), base.Height - 5);
            int num = Convert.ToInt32(ValueToPercentage(PValue) * (float)base.Width - 5f);
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Rectangle rect2 = new Rectangle(1, 1, base.Width - 3, base.Height - 4);
            Rectangle rect3 = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rect4 = new Rectangle(0, 0, base.Width - 1, base.Height - 2);
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), rect);
            graphics.DrawRectangle(new Pen(Color.FromArgb(25, Color.WhiteSmoke)), rect2);
            graphics.DrawRectangle(new Pen(Color.FromArgb(200, Color.Black)), rect4);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.Black)), rect3);
            LinearGradientBrush brush2 = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(100, 51, 159, 231), Color.FromArgb(33, 128, 206), LinearGradientMode.Vertical);
            Rectangle rect5 = new Rectangle(1, 1, num + 2, base.Height - 4);
            Rectangle rectangle2 = new Rectangle(3, 3, num, base.Height / 2 - 3);
            if (num > 1)
            {
                TextureBrush brush3 = new TextureBrush(D.CodeToImage(D.BlueTexture), WrapMode.TileFlipXY);
                graphics.FillRectangle(brush3, rect5);
                graphics.FillRectangle(brush2, rect5);
            }
            if (num > 1)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(130, 131, 197, 241)), new Point(4, 3), new Point(num, 3));
                D.FillGradientBeam(graphics, Color.Transparent, Color.FromArgb(60, Color.White), new Rectangle(3, 3, num, base.Height / 2 - 3), GradientAlignment.Vertical);
                graphics.DrawRectangle(new Pen(Color.FromArgb(12, 33, 55), 1f), new Rectangle(1, 1, num + 2, base.Height - 4));
            }
        }

        private float ValueToPercentage(int val)
        {
            int minimum = Minimum;
            int maximum = Maximum;
            return (val - minimum) / (maximum - minimum);
        }
    }
}
