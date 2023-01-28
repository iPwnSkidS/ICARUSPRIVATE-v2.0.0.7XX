using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class ThemedContainer : ContainerControl
    {
        public DrawUtils D = new DrawUtils();

        protected bool Drag = true;

        public MouseState State;

        protected bool TopCap;

        protected bool SizeCap;

        public Palette Pal;

        protected Point MouseP = new Point(0, 0);

        protected int TopGrip;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            if (e.Button == MouseButtons.Left)
            {
                if (new Rectangle(0, 0, base.Width, TopGrip).Contains(e.Location))
                {
                    TopCap = true;
                    MouseP = e.Location;
                }
                else if (Drag && new Rectangle(base.Width - 15, base.Height - 15, 15, 15).Contains(e.Location))
                {
                    SizeCap = true;
                    MouseP = e.Location;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            TopCap = false;
            if (Drag)
            {
                SizeCap = false;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (TopCap)
            {
                base.Parent.Location = new Point(Control.MousePosition.X - MouseP.X, Control.MousePosition.Y - MouseP.Y);
            }
            if (Drag && SizeCap)
            {
                MouseP = e.Location;
                base.Parent.Size = new Size(MouseP);
                Invalidate();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public ThemedContainer()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Trebuchet MS", 10f);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
        }
    }
}
