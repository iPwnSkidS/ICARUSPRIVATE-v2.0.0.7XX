using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate
{
    internal class StudioButton : ThemeControl152
    {
        private Color C1;

        private Color C2;

        private Color C3;

        private Color C4;

        private Color C5;

        private Color C6;

        private Color C7;

        private Pen P1;

        private Pen P2;

        private Pen P3;

        private SolidBrush B1;

        private SolidBrush B2;

        private SolidBrush B3;

        public StudioButton()
        {
            base.Transparent = true;
            BackColor = Color.Transparent;
            SetColor("DownGradient1", 45, 65, 95);
            SetColor("DownGradient2", 65, 85, 115);
            SetColor("NoneGradient1", 65, 85, 115);
            SetColor("NoneGradient2", 45, 65, 95);
            SetColor("Shine1", 30, Color.White);
            SetColor("Shine2A", 30, Color.White);
            SetColor("Shine2B", Color.Transparent);
            SetColor("Shine3", 20, Color.White);
            SetColor("TextShade", 50, Color.Black);
            SetColor("Text", Color.White);
            SetColor("Glow", 10, Color.White);
            SetColor("Border", 20, 40, 70);
            SetColor("Corners", 20, 40, 70);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");
            C5 = GetColor("Shine2A");
            C6 = GetColor("Shine2B");
            C7 = GetColor("Corners");
            P1 = new Pen(GetColor("Shine1"));
            P2 = new Pen(GetColor("Shine3"));
            P3 = new Pen(GetColor("Border"));
            B1 = new SolidBrush(GetColor("TextShade"));
            B2 = new SolidBrush(GetColor("Text"));
            B3 = new SolidBrush(GetColor("Glow"));
        }

        protected override void PaintHook()
        {
            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, base.ClientRectangle, 90f);
            }
            else
            {
                DrawGradient(C3, C4, base.ClientRectangle, 90f);
            }
            G.DrawLine(P1, 1, 1, base.Width, 1);
            DrawGradient(C5, C6, 1, 1, 1, base.Height);
            DrawGradient(C5, C6, base.Width - 2, 1, 1, base.Height);
            G.DrawLine(P2, 1, base.Height - 2, base.Width, base.Height - 2);
            if (State == MouseState.Down)
            {
                DrawText(B1, HorizontalAlignment.Center, 2, 2);
                DrawText(B2, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                DrawText(B1, HorizontalAlignment.Center, 1, 1);
                DrawText(B2, HorizontalAlignment.Center, 0, 0);
            }
            if (State == MouseState.Over)
            {
                G.FillRectangle(B3, base.ClientRectangle);
            }
            DrawBorders(P3);
            DrawCorners(C7, 1, 1, base.Width - 2, base.Height - 2);
            DrawCorners(BackColor);
        }
    }
}