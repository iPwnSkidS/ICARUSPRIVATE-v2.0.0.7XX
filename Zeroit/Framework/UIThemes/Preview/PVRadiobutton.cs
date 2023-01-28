using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVRadiobutton : ThemedControl
    {
        public bool Checked { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            foreach (Control control in base.Parent.Controls)
            {
                if (control is PVRadiobutton)
                {
                    ((PVRadiobutton)control).Checked = false;
                    control.Invalidate();
                }
            }
            Checked = true;
        }

        public PVRadiobutton()
        {
            Font = new Font("Trebuchet MS", 10f);
            BackColor = Color.FromArgb(21, 23, 25);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = base.Parent.BackColor;
            }
            catch (Exception)
            {
            }
            graphics.Clear(BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.Height = 20;
            Rectangle rect = new Rectangle(0, 0, base.Height - 2, base.Height - 2);
            graphics.DrawEllipse(rect: new Rectangle(0, 1, base.Height - 2, base.Height - 2), pen: new Pen(Pal.ColHigh));
            graphics.FillEllipse(new SolidBrush(Pal.ColDark), rect);
            graphics.DrawEllipse(new Pen(Color.FromArgb(200, Color.Black)), rect);
            if (Checked)
            {
                graphics.FillEllipse(rect: new Rectangle(3, 3, base.Height - 8, base.Height - 8), brush: new SolidBrush(Pal.ColHighest));
            }
            D.DrawTextWithShadow(graphics, new Rectangle(base.Height, 0, base.Width, base.Height - 4), Text, Font, HorizontalAlignment.Left, Pal.ColHighest, Color.Black);
        }
    }
}
