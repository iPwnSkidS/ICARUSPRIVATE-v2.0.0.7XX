using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbiancePanel : ContainerControl
    {
        public AmbiancePanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
            SetStyle(ControlStyles.Opaque, value: false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font = new Font("Tahoma", 9f);
            BackColor = Color.White;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, base.Width, base.Height));
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            graphics.DrawRectangle(new Pen(Color.FromArgb(211, 208, 205)), 0, 0, base.Width - 1, base.Height - 1);
        }
    }
}
