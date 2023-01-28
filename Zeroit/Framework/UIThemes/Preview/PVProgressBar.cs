using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVProgressBar : ThemedControl
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
                Invalidate();
                PValue = value;
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

        public PVProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            BackColor = Pal.ColDark;
            MinimumSize = new Size(21, 21);
            Font = new Font("Trebuchet MS", 10f);
            Value = 50;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            int num = 21;
            graphics.Clear(BackColor);
            try
            {
                string name = base.Parent.GetType().Name;
                if (name.Contains("PVGroupbox"))
                {
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(39, Pal.ColDim)), new Rectangle(0, 0, base.Width, base.Height));
                }
            }
            catch (Exception)
            {
            }
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, num - 1);
            Rectangle rectangle2 = new Rectangle(1, 1, base.Width - 3, num - 3);
            Rectangle rectangle3 = new Rectangle(5, 5, base.Width - 11, num - 11);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath graphicsPath = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, num), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.DrawPath(new Pen(brush, 3f), graphicsPath);
            D.FillDualGradPath(graphics, Color.FromArgb(100, Color.Black), Color.Transparent, rectangle, graphicsPath, GradientAlignment.Horizontal);
            Rectangle rectangle4 = new Rectangle(2, 2, Convert.ToInt32(ValueToPercentage(PValue) * (float)base.Width - 4f), num - 5);
            if (PValue > 0)
            {
                GraphicsPath graphicsPath2 = D.RoundRect(rectangle4, 3);
                GraphicsPath path2 = D.RoundRect(new Rectangle(rectangle4.X, rectangle4.Y, rectangle4.Width, Convert.ToInt32((double)rectangle4.Height / 2.0)), 4);
                LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, Convert.ToInt32((double)rectangle4.Height / 2.0 + 1.0)), Color.FromArgb(60, Color.AliceBlue), Color.FromArgb(100, Color.White));
                HatchBrush brush3 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(15, Color.AliceBlue));
                D.FillDualGradPath(graphics, Color.FromArgb(45, 75, 210), Color.FromArgb(65, 135, 255), rectangle4, graphicsPath2, GradientAlignment.Horizontal);
                graphics.FillPath(brush3, graphicsPath2);
                graphics.FillPath(brush2, path2);
                D.FillDualGradPath(graphics, Color.FromArgb(140, Color.FromArgb(10, 30, 100)), Color.FromArgb(10, Color.FromArgb(20, 50, 160)), rectangle4, graphicsPath2, GradientAlignment.Horizontal);
                graphics.DrawPath(new Pen(Pal.ColDark), graphicsPath2);
            }
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            string text = Strings.FormatPercent(ValueToPercentage(PValue)).Replace(".00", "");
            Size size = graphics.MeasureString(text, Font).ToSize();
            if (base.Height < 38)
            {
                int num2 = 0;
                num2 = Convert.ToInt32(ValueToPercentage(PValue) * 500f);
                if (num2 > 255)
                {
                    num2 = 255;
                }
                D.DrawTextWithShadow(graphics, new Rectangle(rectangle4.Width - size.Width, 0, 100, rectangle4.Height + 3), text, Font, HorizontalAlignment.Left, Color.FromArgb(num2, Color.White), Color.FromArgb(num2, Color.Black));
                return;
            }
            GraphicsPath graphicsPath3 = new GraphicsPath();
            int num3 = base.Width - 51;
            graphicsPath3.AddLine(new Point(num3, 20), new Point(num3 + 20, 38));
            graphicsPath3.AddLine(new Point(num3 + 20, 38), new Point(num3 + 50, 38));
            graphicsPath3.AddLine(new Point(num3 + 50, 38), new Point(num3 + 50, 19));
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.FillRectangle(new SolidBrush(Pal.ColDark), new Rectangle(num3, 20, 50, 1));
            graphics.DrawLine(new Pen(Pal.ColDark), new Point(num3 + 49, 17), new Point(num3 + 49, 19));
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            LinearGradientBrush brush4 = new LinearGradientBrush(new Point(0, 19), new Point(0, 39), Color.FromArgb(100, Pal.ColDim), Color.FromArgb(85, Color.Black));
            graphics.FillPath(brush4, graphicsPath3);
            D.DrawTextWithShadow(graphics, new Rectangle(base.Width - size.Width, 13, 100, 30), text, Font, HorizontalAlignment.Left, Color.FromArgb(140, Color.WhiteSmoke), Pal.ColDark);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), graphicsPath3);
        }

        private float ValueToPercentage(int val)
        {
            int minimum = Minimum;
            int maximum = Maximum;
            return (val - minimum) / (maximum - minimum);
        }
    }
}
