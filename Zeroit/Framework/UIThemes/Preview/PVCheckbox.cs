using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVCheckbox : ThemedControl
    {
        public bool Checked { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Checked = !Checked;
            BackColor = Color.FromArgb(21, 23, 25);
        }

        public PVCheckbox()
        {
            Font = new Font("Trebuchet MS", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                BackColor = base.Parent.BackColor;
            }
            catch (Exception)
            {
            }
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.Height = 20;
            Rectangle rectangle = new Rectangle(0, 0, base.Height - 2, base.Height - 2);
            Rectangle rectangle2 = new Rectangle(0, 1, base.Height - 2, base.Height - 2);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 3);
            graphics.DrawPath(new Pen(Pal.ColHigh), path2);
            graphics.FillPath(new SolidBrush(Pal.ColDark), path);
            graphics.DrawPath(new Pen(Color.FromArgb(200, Color.Black)), path);
            if (Checked)
            {
                Rectangle rectangle3 = new Rectangle(1 + (base.Height - 6) / 4, 1 + (base.Height - 6) / 4, Convert.ToInt32(Math.Truncate((double)(base.Height - 6) / 2.0) + 2.0), Convert.ToInt32(Math.Truncate((double)(base.Height - 6) / 2.0) + 4.0));
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(new Point(rectangle3.X, rectangle3.Y + rectangle3.Height / 2), new Point(rectangle3.X + rectangle3.Width / 2, rectangle3.Y + rectangle3.Height));
                graphicsPath.AddLine(new Point(rectangle3.X + rectangle3.Width / 2, rectangle3.Y + rectangle3.Height), new Point(rectangle3.X + rectangle3.Width, rectangle3.Y - 2));
                graphics.DrawPath(new Pen(Color.FromArgb(255, Pal.ColHighest), 2f), graphicsPath);
            }
            D.DrawTextWithShadow(graphics, new Rectangle(base.Height, 0, base.Width - base.Height, base.Height - 4), Text, Font, HorizontalAlignment.Left, Pal.ColHighest, Color.Black);
        }
    }
}
