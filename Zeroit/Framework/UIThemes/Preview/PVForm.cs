using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVForm : ThemedContainer
    {
        public PVForm()
        {
            MinimumSize = new Size(305, 150);
            Dock = DockStyle.Fill;
            TopGrip = 30;
            Font = new Font("Segoe UI", 10f);
            BackColor = Color.FromArgb(21, 23, 25);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            try
            {
                base.ParentForm.TransparencyKey = Color.Fuchsia;
                base.ParentForm.MinimumSize = MinimumSize;
                if (base.ParentForm.FormBorderStyle != 0)
                {
                    base.ParentForm.FormBorderStyle = FormBorderStyle.None;
                }
            }
            catch (Exception)
            {
            }
            graphics.Clear(base.ParentForm.TransparencyKey);
            Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rect2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
            graphics.FillRectangle(new SolidBrush(Pal.ColDim), rect);
            Rectangle rect3 = new Rectangle(0, 0, base.Width - 1, TopGrip);
            HatchBrush brush = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Pal.ColDim, Color.Transparent);
            LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, TopGrip), Pal.ColHigh, Pal.ColDim);
            Rectangle rect4 = new Rectangle(0, 0, base.Width - 1, (int)((double)TopGrip / 2.0));
            LinearGradientBrush brush3 = new LinearGradientBrush(new Point(0, 0), new Point(0, (int)((double)TopGrip * 0.6)), Color.FromArgb(120, Pal.ColHighest), Color.FromArgb(10, Pal.ColHighest));
            LinearGradientBrush brush4 = new LinearGradientBrush(new Point(0, 0), new Point(0, (int)((double)TopGrip * 0.6)), Color.FromArgb(60, Pal.ColDim), Color.FromArgb(10, Pal.ColDim));
            graphics.FillRectangle(brush2, rect3);
            graphics.FillRectangle(brush, rect3);
            graphics.FillRectangle(brush4, rect4);
            graphics.FillRectangle(brush3, rect4);
            graphics.DrawLine(new Pen(Color.FromArgb(150, Color.Black)), new Point(0, TopGrip), new Point(base.Width - 1, TopGrip));
            graphics.DrawLine(new Pen(Color.FromArgb(60, Pal.ColHighest)), new Point(0, TopGrip + 1), new Point(base.Width - 1, TopGrip + 1));
            int num = Convert.ToInt32((double)TopGrip * 2.4);
            Rectangle rectangle = new Rectangle(0, TopGrip, base.Width - 1, num);
            Rectangle rect5 = new Rectangle(0, num - 20, base.Width - 1, 22);
            LinearGradientBrush brush5 = new LinearGradientBrush(new Point(0, num - 20), new Point(0, num - 10 + 22), Pal.ColDim, Pal.ColDark);
            graphics.FillRectangle(brush5, rect5);
            graphics.DrawLine(new Pen(Color.FromArgb(150, Color.Black)), new Point(0, num), new Point(base.Width - 1, num));
            graphics.DrawLine(new Pen(Color.FromArgb(60, Pal.ColHighest)), new Point(0, num + 1), new Point(base.Width - 1, num + 1));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, Pal.ColDark)), new Rectangle(0, num, base.Width - 1, base.Height - num));
            graphics.DrawRectangle(Pens.Black, rect);
            graphics.DrawRectangle(new Pen(Color.FromArgb(60, Pal.ColHighest)), rect2);
            D.DrawTextWithShadow(graphics, new Rectangle(5, 0, base.Width - 31, TopGrip), Text, Font, HorizontalAlignment.Left, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
        }
    }
}
