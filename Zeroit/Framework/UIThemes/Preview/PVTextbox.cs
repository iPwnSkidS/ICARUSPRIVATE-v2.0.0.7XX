using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVTextbox : ThemedTextbox
    {
        private Color _BorderColor;

        private Color _InteriorColor = Color.FromArgb(150, Color.WhiteSmoke);

        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }

        public Color InteriorColor
        {
            get
            {
                return _InteriorColor;
            }
            set
            {
                _InteriorColor = value;
            }
        }

        public PVTextbox()
        {
            SetStyle(ControlStyles.UserPaint, value: true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
            _BorderColor = Color.FromArgb(200, Pal.ColHighest);
            BackColor = Pal.ColDark;
            base.BorderStyle = BorderStyle.None;
            Multiline = true;
            Font = new Font("Trebuchet MS", 10f);
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
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rectangle2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
            Rectangle rectangle3 = new Rectangle(5, 5, base.Width - 11, base.Height - 11);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), rectangle2);
            graphics.DrawPath(new Pen(brush, 3f), path2);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            graphics.DrawString(Text, Font, new SolidBrush(InteriorColor), new Point(3, 2));
        }
    }
}
