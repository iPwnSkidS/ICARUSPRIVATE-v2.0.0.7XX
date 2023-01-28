using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVGroupbox : ThemedContainer
    {
        public PVGroupbox()
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
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.FromArgb(0, 0, 10))), rectangle2);
            graphics.DrawPath(new Pen(brush, 3f), path2);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            if (Text.Length > 0)
            {
                Rectangle rectangle3 = new Rectangle(1, 1, graphics.MeasureString(Text, Font).ToSize().Width, graphics.MeasureString(Text, Font).ToSize().Height + 5);
                Rectangle rectangle4 = new Rectangle(1, 2, graphics.MeasureString(Text, Font).ToSize().Width, graphics.MeasureString(Text, Font).ToSize().Height + 5 - 1);
                Rectangle rectangle5 = new Rectangle(1, 1, graphics.MeasureString(Text, Font).ToSize().Width, graphics.MeasureString(Text, Font).ToSize().Height + 5 - 1);
                Rectangle rectangle6 = new Rectangle(2, 2, graphics.MeasureString(Text, Font).ToSize().Width - 1, graphics.MeasureString(Text, Font).ToSize().Height + 4);
                GraphicsPath path3 = D.RoundRect(rectangle3, 3);
                GraphicsPath path4 = D.RoundRect(rectangle4, 3);
                GraphicsPath path5 = D.RoundRect(rectangle5, 3);
                GraphicsPath path6 = D.RoundRect(rectangle6, 3);
                graphics.DrawPath(new Pen(Color.Black, 2f), path6);
                graphics.FillPath(new SolidBrush(Pal.ColDim), path3);
                graphics.DrawPath(new Pen(Color.FromArgb(45, Pal.ColHighest)), path4);
                graphics.DrawPath(new Pen(Color.FromArgb(30, Pal.ColHighest)), path5);
                graphics.DrawPath(new Pen(Color.Black), path3);
                D.DrawTextWithShadow(graphics, new Rectangle(rectangle4.X - 10, rectangle4.Y + 1, rectangle4.Width + 20, rectangle4.Height - 4), Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
            }
        }
    }
}
