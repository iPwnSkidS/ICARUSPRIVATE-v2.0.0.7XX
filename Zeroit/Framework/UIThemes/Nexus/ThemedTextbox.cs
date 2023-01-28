using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Nexus
{
    public class ThemedTextbox : TextBox
    {
        public DrawUtils D = new DrawUtils();

        public MouseState State;

        public Palette Pal;

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
            Invalidate();
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
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public ThemedTextbox()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10f);
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
