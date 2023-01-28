using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchPlainAndSimpleRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColorChecked { get; set; }

        public Color BorderColorUnchecked { get; set; }

        public int BorderWidth { get; set; }

        public int ButtonMargin { get; set; }

        public Color InnerBackgroundColor { get; set; }

        public Color ButtonColor { get; set; }

        public ToggleSwitchPlainAndSimpleRenderer()
        {
            BorderColorChecked = Color.Black;
            BorderColorUnchecked = Color.Black;
            BorderWidth = 2;
            ButtonMargin = 1;
            InnerBackgroundColor = Color.White;
            ButtonColor = Color.Black;
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GetButtonWidth();
            Rectangle controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(controlRectangle);
            g.SetClip(innerBorderClipPath);
            g.IntersectClip(leftRectangle);
            using (Brush brush = new SolidBrush(InnerBackgroundColor))
            {
                g.FillPath(brush, innerBorderClipPath);
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GetButtonWidth();
            Rectangle controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(controlRectangle);
            g.SetClip(innerBorderClipPath);
            g.IntersectClip(rightRectangle);
            using (Brush brush = new SolidBrush(InnerBackgroundColor))
            {
                g.FillPath(brush, innerBorderClipPath);
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            GraphicsPath buttonClipPath = GetButtonClipPath();
            Rectangle rectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath controlClipPath = GetControlClipPath(rectangle);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(rectangle);
            g.SetClip(innerBorderClipPath);
            g.IntersectClip(buttonRectangle);
            using (Brush brush = new SolidBrush(InnerBackgroundColor))
            {
                g.FillRectangle(brush, buttonRectangle);
            }
            g.ResetClip();
            g.SetClip(GetButtonClipPath());
            g.IntersectClip(rectangle);
            using (Brush brush2 = new SolidBrush(ButtonColor))
            {
                g.FillPath(brush2, buttonClipPath);
            }
            g.ResetClip();
            g.SetClip(controlClipPath);
            g.ExcludeClip(new Region(innerBorderClipPath));
            Color color = (base.ToggleSwitch.Checked ? BorderColorChecked : BorderColorUnchecked);
            using (Brush brush3 = new SolidBrush(color))
            {
                g.FillPath(brush3, controlClipPath);
            }
            g.ResetClip();
        }

        public GraphicsPath GetControlClipPath(Rectangle controlRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(controlRectangle.X, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 90f, 180f);
            graphicsPath.AddArc(controlRectangle.X + controlRectangle.Width - controlRectangle.Height, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetInnerBorderClipPath(Rectangle controlRectangle)
        {
            Rectangle rectangle = new Rectangle(controlRectangle.X + BorderWidth, controlRectangle.Y + BorderWidth, controlRectangle.Width - 2 * BorderWidth, controlRectangle.Height - 2 * BorderWidth);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rectangle.X, rectangle.Y, rectangle.Height, rectangle.Height, 90f, 180f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - rectangle.Height, rectangle.Y, rectangle.Height, rectangle.Height, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = GetButtonRectangle();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(buttonRectangle.X + ButtonMargin, buttonRectangle.Y + ButtonMargin, buttonRectangle.Height - 2 * ButtonMargin, buttonRectangle.Height - 2 * ButtonMargin, 0f, 360f);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            int num = base.ToggleSwitch.Height - 2 * BorderWidth;
            if (num <= 0)
            {
                return 0;
            }
            return num;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            if (buttonWidth <= 0)
            {
                return Rectangle.Empty;
            }
            Rectangle result = new Rectangle(base.ToggleSwitch.ButtonValue, BorderWidth, buttonWidth, buttonWidth);
            if (result.X < BorderWidth + ButtonMargin - 1)
            {
                result.X = BorderWidth + ButtonMargin - 1;
            }
            if (result.X + result.Width > base.ToggleSwitch.Width - BorderWidth - ButtonMargin + 1)
            {
                result.X = base.ToggleSwitch.Width - result.Width - BorderWidth - ButtonMargin + 1;
            }
            return result;
        }
    }
}
