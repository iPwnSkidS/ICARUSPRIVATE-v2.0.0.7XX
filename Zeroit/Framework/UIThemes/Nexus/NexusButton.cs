using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusButton : ThemedControl
    {
        public Color OverlayCol { get; set; }

        public bool DrawSeparator { get; set; }

        public NexusButton()
        {
            Font = new Font("Segoe UI", 11f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(BackColor);
            Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rect2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            _ = OverlayCol;
            graphics.FillRectangle(new SolidBrush(OverlayCol), rect);
            int num = base.Height / 2;
            Rectangle rect3 = new Rectangle(0, 0, base.Width, num);
            Rectangle rect4 = new Rectangle(0, num, base.Width, num);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, Pal.ColMed)), rect3);
            D.FillGradientBeam(graphics, Color.Transparent, Color.FromArgb(60, Pal.ColHighest), rect3, GradientAlignment.Vertical);
            D.FillGradientBeam(graphics, Color.Transparent, Color.FromArgb(30, Pal.ColHighest), rect4, GradientAlignment.Vertical);
            if (DrawSeparator)
            {
                graphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black)), new Point(1, rect3.Height), new Point(base.Width - 2, rect3.Height));
                graphics.DrawLine(new Pen(Color.FromArgb(35, Pal.ColHighest)), new Point(1, rect3.Height + 1), new Point(base.Width - 2, rect3.Height + 1));
                graphics.DrawLine(new Pen(Color.FromArgb(50, Color.Black)), new Point(1, rect3.Height + 2), new Point(base.Width - 2, rect3.Height + 2));
            }
            LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90f);
            graphics.FillRectangle(brush2, rect);
            switch (State)
            {
                case MouseState.Down:
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(56, Color.Black)), rect);
                    break;
                case MouseState.Over:
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Pal.ColHighest)), rect);
                    break;
            }
            graphics.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), rect2);
            graphics.DrawRectangle(Pens.Black, rect);
            D.DrawTextWithShadow(graphics, new Rectangle(0, 0, base.Width, base.Height), Text, Font, HorizontalAlignment.Center, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
