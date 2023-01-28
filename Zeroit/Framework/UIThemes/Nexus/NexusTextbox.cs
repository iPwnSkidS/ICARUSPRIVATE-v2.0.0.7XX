using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusTextbox : ThemedTextbox
    {
        public NexusTextbox()
        {
            SetStyle(ControlStyles.UserPaint, value: true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
            BackColor = Pal.ColDark;
            base.BorderStyle = BorderStyle.None;
            Multiline = true;
            Font = new Font("Segoe UI", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            if (!Multiline)
            {
                base.Height = 21;
            }
            graphics.Clear(BackColor);
            base.Height = 20;
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            Rectangle rect2 = new Rectangle(1, 1, base.Width - 3, base.Height - 4);
            Rectangle rect3 = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rect4 = new Rectangle(0, 0, base.Width - 1, base.Height - 2);
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), rect);
            graphics.DrawRectangle(new Pen(Color.FromArgb(25, Color.WhiteSmoke)), rect2);
            graphics.DrawRectangle(new Pen(Color.FromArgb(200, Color.Black)), rect4);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.Black)), rect3);
            D.DrawTextWithShadow(graphics, new Rectangle(2, 0, base.Width, base.Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
