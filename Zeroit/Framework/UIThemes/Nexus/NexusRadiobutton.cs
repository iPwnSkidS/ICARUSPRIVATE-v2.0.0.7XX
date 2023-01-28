using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusRadiobutton : ThemedControl
    {
        public bool Checked { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Control control in base.Parent.Controls)
            {
                if (control is NexusRadiobutton)
                {
                    ((NexusRadiobutton)control).Checked = false;
                    control.Invalidate();
                }
            }
            Checked = true;
        }

        public NexusRadiobutton()
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
            Rectangle rect2 = new Rectangle(0, 0, base.Height - 1, base.Height - 1);
            Rectangle rect3 = new Rectangle(1, 1, base.Height - 3, base.Height - 3);
            LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90f);
            graphics.FillEllipse(brush2, rect2);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawEllipse(new Pen(Color.FromArgb(40, Pal.ColHighest)), rect3);
            graphics.DrawEllipse(Pens.Black, rect2);
            if (Checked)
            {
                Rectangle rect4 = new Rectangle(3, 3, base.Height - 7, base.Height - 7);
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, Pal.ColHighest)), rect4);
                graphics.DrawEllipse(new Pen(Color.FromArgb(140, Pal.ColHighest)), rect4);
            }
            D.DrawTextWithShadow(graphics, new Rectangle(base.Height + 2, 0, base.Width, base.Height), Text, Font, HorizontalAlignment.Left, Color.FromArgb(155, 155, 160), Color.Black);
        }
    }
}
