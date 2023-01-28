using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVEmbeddedButton : ThemedControl
    {
        public PVEmbeddedButton()
        {
            Font = new Font("Trebuchet MS", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = base.Parent.BackColor;
            }
            catch (Exception)
            {
            }
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rectangle2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
            Rectangle rectangle3 = new Rectangle(5, 5, base.Width - 11, base.Height - 11);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), rectangle2);
            graphics.DrawPath(new Pen(brush, 3f), path2);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            GraphicsPath path3 = D.RoundRect(rectangle3, 4);
            GraphicsPath path4 = D.RoundRect(new Rectangle(rectangle3.X + 10, rectangle3.Y, rectangle3.Width - 20, rectangle3.Height), 4);
            GraphicsPath path5 = D.RoundRect(new Rectangle(rectangle3.X, rectangle3.Y + 1, rectangle3.Width, rectangle3.Height - 2), 4);
            switch (State)
            {
                case MouseState.None:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), path3);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path4);
                    D.FillGradientBeam(graphics, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle3, GradientAlignment.Vertical);
                    break;
                case MouseState.Over:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(255, Pal.ColDim)), path3);
                    graphics.FillPath(new SolidBrush(Color.FromArgb(Pal.ColDim.R + 10, Pal.ColDim.G + 10, Pal.ColDim.B + 10)), path4);
                    D.FillGradientBeam(graphics, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle3, GradientAlignment.Vertical);
                    break;
                case MouseState.Down:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), path3);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path4);
                    graphics.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), path4);
                    D.FillGradientBeam(graphics, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), rectangle3, GradientAlignment.Vertical);
                    break;
            }
            if (State == MouseState.Down)
            {
                path5 = D.RoundRect(new Rectangle(rectangle3.X, rectangle3.Y + 1, rectangle3.Width, rectangle3.Height - 1), 4);
                graphics.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3f), path5);
                D.DrawTextWithShadow(graphics, rectangle2, Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);
            }
            else
            {
                graphics.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), path5);
                D.DrawTextWithShadow(graphics, rectangle2, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
            }
            graphics.DrawPath(Pens.Black, path3);
        }
    }
}
