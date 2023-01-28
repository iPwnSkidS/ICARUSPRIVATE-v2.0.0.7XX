using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate
{
    internal class StudioTheme : ThemeContainer152
    {
        private GraphicsPath Path;

        private Color C1;

        private Color C2;

        private Color C3;

        private Color C4;

        private Color C5;

        private Pen P1;

        private Pen P2;

        private Pen P3;

        private Pen P4;

        private Pen P5;

        private HatchBrush B1;

        private SolidBrush B2;

        private Rectangle RT1;

        public StudioTheme()
        {
            base.MoveHeight = 30;
            BackColor = Color.FromArgb(20, 40, 70);
            base.TransparencyKey = Color.Fuchsia;
            SetColor("Sides", 50, 70, 100);
            SetColor("Gradient1", 65, 85, 115);
            SetColor("Gradient2", 50, 70, 100);
            SetColor("Hatch1", 20, 40, 70);
            SetColor("Hatch2", 40, 60, 90);
            SetColor("Shade1", 15, Color.Black);
            SetColor("Shade2", Color.Transparent);
            SetColor("Border1", 12, 32, 62);
            SetColor("Border2", 20, Color.Black);
            SetColor("Border3", 30, Color.White);
            SetColor("Border4", Color.Black);
            SetColor("Text", Color.White);
            Path = new GraphicsPath();
        }

        protected override void ColorHook()
        {
            P1 = new Pen(base.TransparencyKey, 3f);
            P2 = new Pen(GetColor("Border1"));
            P3 = new Pen(GetColor("Border2"), 2f);
            P4 = new Pen(GetColor("Border3"));
            P5 = new Pen(GetColor("Border4"));
            C1 = GetColor("Sides");
            C2 = GetColor("Gradient1");
            C3 = GetColor("Gradient2");
            C4 = GetColor("Shade1");
            C5 = GetColor("Shade2");
            B1 = new HatchBrush(HatchStyle.LightDownwardDiagonal, GetColor("Hatch1"), GetColor("Hatch2"));
            B2 = new SolidBrush(GetColor("Text"));
            BackColor = GetColor("Hatch2");
        }

        protected override void PaintHook()
        {
            G.DrawRectangle(P1, base.ClientRectangle);
            G.SetClip(Path);
            G.Clear(C1);
            DrawGradient(C2, C3, 0, 0, base.Width, 30);
            RT1 = new Rectangle(12, 30, base.Width - 24, base.Height - 12 - 30);
            G.FillRectangle(B1, RT1);
            DrawGradient(C4, C5, 12, 30, base.Width - 24, 30);
            DrawBorders(P2, RT1);
            DrawBorders(P3, 14, 32, base.Width - 26, base.Height - 12 - 32);
            DrawText(B2, HorizontalAlignment.Left, 12, 0);
            DrawBorders(P4, 1);
            G.ResetClip();
            G.DrawPath(P5, Path);
        }

        protected override void OnResize(EventArgs e)
        {
            Path.Reset();
            Path.AddLines(new Point[9]
            {
                new Point(2, 0),
                new Point(base.Width - 3, 0),
                new Point(base.Width - 1, 2),
                new Point(base.Width - 1, base.Height - 3),
                new Point(base.Width - 3, base.Height - 1),
                new Point(2, base.Height - 1),
                new Point(0, base.Height - 3),
                new Point(0, 2),
                new Point(2, 0)
            });
            base.OnResize(e);
        }
    }
}