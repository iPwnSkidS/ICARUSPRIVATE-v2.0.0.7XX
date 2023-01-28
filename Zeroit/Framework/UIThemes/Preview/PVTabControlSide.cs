using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVTabControlSide : ThemedTabControl
    {
        public PVTabControlSide()
        {
            base.Alignment = TabAlignment.Left;
            DoubleBuffered = true;
            base.SizeMode = TabSizeMode.Fixed;
            base.ItemSize = new Size(50, 100);
            Font = new Font("Trebuchet MS", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = base.Parent.BackColor;
                graphics.Clear(base.Parent.BackColor);
            }
            catch (Exception)
            {
                graphics.Clear(Pal.ColDim);
            }
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rectangle = new Rectangle(100, 0, base.Width - 1 - 100, base.Height - 1);
            Rectangle rectangle2 = new Rectangle(101, 1, base.Width - 3 - 100, base.Height - 3);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(200, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), rectangle2);
            graphics.DrawPath(new Pen(brush, 3f), path2);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            for (int i = 0; i < base.TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);
                Rectangle rectangle3 = new Rectangle(-2 + tabRect.X, 2 + tabRect.Y, tabRect.Width - 1 - 3, tabRect.Height - 1 - 2);
                Rectangle rectangle4 = new Rectangle(-2 + tabRect.X + 1, 2 + tabRect.Y + 1, tabRect.Width - 3 - 3, tabRect.Height - 3 - 2);
                Rectangle rectangle5 = new Rectangle(-2 + tabRect.X + 5, 2 + tabRect.Y + 5, tabRect.Width - 11 - 3, tabRect.Height - 11 - 2);
                GraphicsPath path3 = D.RoundRect(rectangle3, 3);
                GraphicsPath path4 = D.RoundRect(rectangle4, 5);
                LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), rectangle4);
                graphics.DrawPath(new Pen(brush2, 3f), path4);
                graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path3);
                GraphicsPath path5 = D.RoundRect(rectangle5, 4);
                GraphicsPath path6 = D.RoundRect(new Rectangle(rectangle5.X + 10, rectangle5.Y, rectangle5.Width - 20, rectangle5.Height), 4);
                GraphicsPath path7 = D.RoundRect(new Rectangle(rectangle5.X, rectangle5.Y + 1, rectangle5.Width, rectangle5.Height - 2), 4);
                if (i == base.SelectedIndex)
                {
                    graphics.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), path5);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path6);
                    graphics.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), path6);
                    D.FillGradientBeam(graphics, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), rectangle5, GradientAlignment.Vertical);
                    path7 = D.RoundRect(new Rectangle(rectangle5.X, rectangle5.Y + 1, rectangle5.Width, rectangle5.Height - 1), 4);
                    graphics.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3f), path7);
                    D.DrawTextWithShadow(graphics, rectangle4, base.TabPages[i].Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);
                }
                else
                {
                    graphics.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), path5);
                    graphics.FillPath(new SolidBrush(Pal.ColDim), path6);
                    D.FillGradientBeam(graphics, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle5, GradientAlignment.Vertical);
                    graphics.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), path7);
                    D.DrawTextWithShadow(graphics, rectangle4, base.TabPages[i].Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
                }
                graphics.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), path7);
                D.DrawTextWithShadow(graphics, rectangle4, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
                graphics.DrawPath(Pens.Black, path5);
                try
                {
                    Color backColor = base.Parent.BackColor;
                    Color colDark = Pal.ColDark;
                    colDark = Color.FromArgb((int)((double)(colDark.R + backColor.R) / 2.0), (int)((double)(colDark.G + backColor.G) / 2.0), (int)((double)(colDark.B + backColor.B) / 2.0));
                    base.TabPages[i].BackColor = colDark;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
