using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVListbox : ThemedListControl
    {
        private HorizontalAlignment _TextAlignment = HorizontalAlignment.Center;

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

        public PVListbox()
        {
            base.IntegralHeight = false;
            ItemHeight = 24;
            Font = new Font("Segoe UI Semilight", 12f);
            ForeColor = Pal.ColHighest;
            DrawMode = DrawMode.OwnerDrawVariable;
            base.BorderStyle = BorderStyle.None;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
        }

        protected void OnItemPaint(Graphics G, int i)
        {
            int num = 0;
            int num2 = 1;
            if (i == 0)
            {
                num = 3;
            }
            Rectangle rectangle = new Rectangle(4, num2 + num + i * ItemHeight, base.Width - 10, ItemHeight - num2 * 2 - num);
            GraphicsPath path = D.RoundRect(rectangle, 4);
            GraphicsPath path2 = D.RoundRect(new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), 4);
            GraphicsPath path3 = D.RoundRect(new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height - 2), 4);
            G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), path);
            G.FillPath(new SolidBrush(Pal.ColDim), path2);
            if (i == SelectedIndex)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 170, 250)), path2);
            }
            if (i == SelectedIndex)
            {
                G.DrawPath(new Pen(Color.FromArgb(160, Pal.ColHighest)), path3);
                G.DrawPath(Pens.Black, path);
                D.FillGradientBeam(G, Color.FromArgb(40, Color.Black), Color.FromArgb(30, Pal.ColHighest), rectangle, GradientAlignment.Vertical);
            }
            else
            {
                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), path3);
                G.DrawPath(Pens.Black, path);
                D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), rectangle, GradientAlignment.Vertical);
            }
            Color tColor = Color.WhiteSmoke;
            if (i == SelectedIndex)
            {
                tColor = Color.FromArgb(50, 170, 250);
            }
            D.DrawTextWithShadow(G, rectangle, base.Items[i].ToString(), Font, TextAlignment, tColor, Color.Black);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(base.Parent.BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.BorderStyle = BorderStyle.None;
            Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
            Rectangle rectangle2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
            Rectangle rectangle3 = new Rectangle(3, 1, base.Width - 7, base.Height - 3);
            GraphicsPath path = D.RoundRect(rectangle, 3);
            GraphicsPath path2 = D.RoundRect(rectangle2, 5);
            LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), rectangle2);
            graphics.DrawPath(new Pen(brush, 3f), path2);
            graphics.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), path);
            D.RoundRect(rectangle3, 4);
            D.RoundRect(new Rectangle(rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height), 4);
            D.RoundRect(new Rectangle(rectangle3.X, rectangle3.Y + 1, rectangle3.Width, rectangle3.Height - 2), 4);
            int num = 0;
            foreach (object item in base.Items)
            {
                _ = item;
                OnItemPaint(graphics, num);
                num++;
            }
        }
    }
}
