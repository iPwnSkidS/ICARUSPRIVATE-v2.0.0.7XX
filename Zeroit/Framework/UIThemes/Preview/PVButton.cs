using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVButton : ThemedControl
    {
        public PVButton()
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
            int curve = 4;
            if (base.Size.Width <= 30 && base.Size.Height <= 30)
            {
                curve = 2;
            }
            GraphicsPath path = D.RoundRect(rectangle, curve);
            GraphicsPath path2 = D.RoundRect(new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height - 2), 4);
            switch (State)
            {
                case MouseState.None:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), path);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path);
                    D.FillGradientBeam(graphics, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle, GradientAlignment.Vertical);
                    break;
                case MouseState.Over:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(255, Pal.ColDim)), path);
                    graphics.FillPath(new SolidBrush(Color.FromArgb(Pal.ColDim.R + 10, Pal.ColDim.G + 10, Pal.ColDim.B + 10)), path);
                    D.FillGradientBeam(graphics, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle, GradientAlignment.Vertical);
                    break;
                case MouseState.Down:
                    graphics.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), path);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path);
                    graphics.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), path);
                    D.FillGradientBeam(graphics, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), rectangle, GradientAlignment.Vertical);
                    break;
            }
            if (State == MouseState.Down)
            {
                path2 = D.RoundRect(new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height - 1), 4);
                graphics.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3f), path2);
                D.DrawTextWithShadow(graphics, rectangle, Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);
            }
            else
            {
                graphics.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), path2);
                D.DrawTextWithShadow(graphics, rectangle, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
            }
            graphics.DrawPath(Pens.Black, path);
        }
    }
}
