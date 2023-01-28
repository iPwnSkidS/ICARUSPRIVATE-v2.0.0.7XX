using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusImage : ThemedControl
    {
        private ImageMode _ImageMode;

        public Bitmap Image { get; set; }

        public ImageMode ImageMode
        {
            get
            {
                return _ImageMode;
            }
            set
            {
                _ImageMode = value;
            }
        }

        public NexusImage()
        {
            Font = new Font("Segoe UI", 10f);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(BackColor);
            Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), rect);
            if (Image != null)
            {
                if (ImageMode == ImageMode.Normal)
                {
                    graphics.DrawImage(Image, new Point(0, 0));
                }
                else
                {
                    graphics.DrawImage(Image, new Rectangle(0, 0, base.Width, base.Height));
                }
            }
        }
    }
}
