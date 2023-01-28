using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceTabControl : TabControl
    {
        public AmbianceTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            base.ItemSize = new Size(80, 24);
            base.Alignment = TabAlignment.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = default(Rectangle);
            graphics.Clear(base.Parent.BackColor);
            for (int i = 0; i <= base.TabCount - 1; i++)
            {
                rectangle = GetTabRect(i);
                if (i != base.SelectedIndex)
                {
                    graphics.DrawString(base.TabPages[i].Text, new Font(Font.Name, Font.Size - 1f, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 76, 76)), new Rectangle(GetTabRect(i).Location, GetTabRect(i).Size), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }
            graphics.FillPath(new SolidBrush(Color.White), RoundRectangle.RoundRect(0, 23, base.Width - 1, base.Height - 24, 2));
            graphics.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundRect(0, 23, base.Width - 1, base.Height - 24, 2));
            for (int j = 0; j <= base.TabCount - 1; j++)
            {
                rectangle = GetTabRect(j);
                if (j == base.SelectedIndex)
                {
                    graphics.DrawPath(new Pen(Color.FromArgb(201, 198, 195)), RoundRectangle.RoundedTopRect(new Rectangle(new Point(rectangle.X - 2, rectangle.Y - 2), new Size(rectangle.Width + 3, rectangle.Height)), 7));
                    graphics.FillPath(new SolidBrush(Color.White), RoundRectangle.RoundedTopRect(new Rectangle(new Point(rectangle.X - 1, rectangle.Y - 1), new Size(rectangle.Width + 2, rectangle.Height)), 7));
                    try
                    {
                        graphics.DrawString(base.TabPages[j].Text, new Font(Font.Name, Font.Size - 1f, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 76, 76)), new Rectangle(GetTabRect(j).Location, GetTabRect(j).Size), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                        base.TabPages[j].BackColor = Color.White;
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
