using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class DrawUtils
    {
        public void FillGradientBeam(Graphics g, Color Col1, Color Col2, Rectangle rect, GradientAlignment align)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            ColorBlend colorBlend = new ColorBlend();
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (align)
            {
                case GradientAlignment.Horizontal:
                {
                    LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black);
                    colorBlend.Positions = new float[3] { 0f, 0.5f, 1f };
                    colorBlend.Colors = new Color[3] { Col1, Col2, Col1 };
                    linearGradientBrush2.InterpolationColors = colorBlend;
                    linearGradientBrush2.RotateTransform(0f);
                    g.FillRectangle(linearGradientBrush2, rect);
                    break;
                }
                case GradientAlignment.Vertical:
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black);
                    colorBlend.Positions = new float[3] { 0f, 0.5f, 1f };
                    colorBlend.Colors = new Color[3] { Col1, Col2, Col1 };
                    linearGradientBrush.InterpolationColors = colorBlend;
                    g.FillRectangle(linearGradientBrush, rect);
                    break;
                }
            }
            g.SmoothingMode = smoothingMode;
        }

        public void DrawTextWithShadow(Graphics G, Rectangle ContRect, string Text, Font TFont, HorizontalAlignment TAlign, Color TColor, Color BColor)
        {
            DrawText(G, new Rectangle(ContRect.X + 1, ContRect.Y + 1, ContRect.Width, ContRect.Height), Text, TFont, TAlign, BColor);
            DrawText(G, ContRect, Text, TFont, TAlign, TColor);
        }

        public void FillDualGradPath(Graphics g, Color Col1, Color Col2, Rectangle rect, GraphicsPath gp, GradientAlignment align)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            ColorBlend colorBlend = new ColorBlend();
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (align)
            {
                case GradientAlignment.Horizontal:
                {
                    LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black);
                    colorBlend.Positions = new float[3] { 0f, 0.5f, 1f };
                    colorBlend.Colors = new Color[3] { Col1, Col2, Col1 };
                    linearGradientBrush2.InterpolationColors = colorBlend;
                    linearGradientBrush2.RotateTransform(0f);
                    g.FillPath(linearGradientBrush2, gp);
                    break;
                }
                case GradientAlignment.Vertical:
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black);
                    colorBlend.Positions = new float[3] { 0f, 0.5f, 1f };
                    colorBlend.Colors = new Color[3] { Col1, Col2, Col1 };
                    linearGradientBrush.InterpolationColors = colorBlend;
                    g.FillPath(linearGradientBrush, gp);
                    break;
                }
            }
            g.SmoothingMode = smoothingMode;
        }

        public void DrawText(Graphics G, Rectangle ContRect, string Text, Font TFont, HorizontalAlignment TAlign, Color TColor)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                Size size = G.MeasureString(Text, TFont).ToSize();
                _ = ContRect.Height / 2 - size.Height / 2;
                switch (TAlign)
                {
                    case HorizontalAlignment.Left:
                    {
                        StringFormat stringFormat3 = new StringFormat();
                        stringFormat3.LineAlignment = StringAlignment.Near;
                        stringFormat3.Alignment = StringAlignment.Near;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), new Rectangle(ContRect.X, Convert.ToInt32((double)ContRect.Y + (double)ContRect.Height / 2.0 - (double)size.Height / 2.0), ContRect.Width, ContRect.Height), stringFormat3);
                        break;
                    }
                    case HorizontalAlignment.Right:
                    {
                        StringFormat stringFormat2 = new StringFormat();
                        stringFormat2.LineAlignment = StringAlignment.Far;
                        stringFormat2.Alignment = StringAlignment.Far;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), new Rectangle(ContRect.X, ContRect.Y, ContRect.Width, Convert.ToInt32((double)ContRect.Height / 2.0 + (double)size.Height / 2.0)), stringFormat2);
                        break;
                    }
                    case HorizontalAlignment.Center:
                    {
                        StringFormat stringFormat = new StringFormat();
                        stringFormat.LineAlignment = StringAlignment.Center;
                        stringFormat.Alignment = StringAlignment.Center;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), ContRect, stringFormat);
                        break;
                    }
                }
            }
        }

        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = Curve * 2;
            graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
            graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
            graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0f, 90f);
            graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
            graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - num + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return graphicsPath;
        }

        public GraphicsPath RoundedTopRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = Curve * 2;
            graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
            graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
            graphicsPath.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + num), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height));
            graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y + Curve));
            return graphicsPath;
        }
    }
}
