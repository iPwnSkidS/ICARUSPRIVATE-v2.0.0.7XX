using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class NexusForm : ThemedContainer
    {
        private HorizontalAlignment _TextAlignment = HorizontalAlignment.Center;

        private int _TopSize = 57;

        public HorizontalAlignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
            }
        }

        public int TopSize
        {
            get
            {
                return _TopSize;
            }
            set
            {
                _TopSize = value;
            }
        }

        public int TextYOffset { get; set; }

        public NexusForm()
        {
            MinimumSize = new Size(305, 150);
            Dock = DockStyle.Fill;
            TopGrip = 57;
            TopSize = TopGrip;
            Font = new Font("Segoe UI", 10f);
            BackColor = Color.FromArgb(21, 23, 25);
            ForeColor = Color.FromArgb(160, Color.White);
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
            TextureBrush brush = new TextureBrush(D.CodeToImage(D.BGTexture), WrapMode.TileFlipXY);
            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), rect2);
            graphics.DrawRectangle(Pens.Black, rect);
            Rectangle rect3 = new Rectangle(0, 0, base.Width, TopSize / 2);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, Pal.ColMed)), rect3);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect3, Color.Black, Color.Black, 0f, isAngleScaleable: false);
            LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect3, Color.Black, Color.Black, 0f, isAngleScaleable: false);
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new float[4]
            {
                0f,
                1f / 3f,
                2f / 3f,
                1f
            };
            colorBlend.Colors = new Color[4]
            {
                Color.FromArgb(50, Color.Black),
                Color.FromArgb(150, Color.Black),
                Color.FromArgb(50, Color.Black),
                Color.Transparent
            };
            linearGradientBrush.InterpolationColors = colorBlend;
            linearGradientBrush.RotateTransform(45f);
            colorBlend.Colors = new Color[4]
            {
                Color.FromArgb(50, Pal.ColHighest),
                Color.FromArgb(150, Pal.ColHighest),
                Color.FromArgb(50, Pal.ColHighest),
                Color.Transparent
            };
            linearGradientBrush2.InterpolationColors = colorBlend;
            linearGradientBrush2.RotateTransform(45f);
            D.FillGradientBeam(graphics, Color.Transparent, Color.FromArgb(80, Pal.ColHighest), rect3, GradientAlignment.Vertical);
            graphics.DrawLine(new Pen(linearGradientBrush), new Point(1, rect3.Height), new Point(base.Width - 2, rect3.Height));
            graphics.DrawLine(new Pen(linearGradientBrush2), new Point(1, rect3.Height + 1), new Point(base.Width - 2, rect3.Height + 1));
            Rectangle rect4 = new Rectangle(0, rect3.Height, base.Width - 1, base.Height - 1 - rect3.Height);
            LinearGradientBrush brush2 = new LinearGradientBrush(rect4, Color.FromArgb(20, Color.Black), Color.FromArgb(100, Color.Black), 90f);
            graphics.FillRectangle(brush2, rect4);
            D.DrawTextWithShadow(graphics, new Rectangle(0, 0, base.Width, TopSize + TextYOffset), Text, Font, TextAlignment, ForeColor, Color.Black);
            Rectangle rect5 = new Rectangle(5, TopSize, base.Width - 11, base.Height - 6 - TopSize);
            Rectangle rect6 = new Rectangle(6, TopSize + 1, base.Width - 13, base.Height - 8 - TopSize);
            graphics.FillRectangle(brush, rect5);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, Pal.ColHigh)), rect5);
            graphics.DrawRectangle(new Pen(Color.FromArgb(40, Pal.ColHighest)), rect6);
            graphics.DrawRectangle(Pens.Black, rect5);
        }
    }
}
