using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusLabel : ThemedControl
    {
        public NexusLabel()
        {
            Font = new Font("Segoe UI", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(BackColor);
            base.Height = 20;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), rect);
            D.DrawTextWithShadow(graphics, new Rectangle(0, 0, base.Width, base.Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
