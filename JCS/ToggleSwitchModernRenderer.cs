using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchModernRenderer : ToggleSwitchRendererBase, IDisposable
    {
        private GraphicsPath _innerControlPath;

        public Color OuterBorderColor { get; set; }

        public Color InnerBorderColor1 { get; set; }

        public Color InnerBorderColor2 { get; set; }

        public Color LeftSideBackColor1 { get; set; }

        public Color LeftSideBackColor2 { get; set; }

        public Color RightSideBackColor1 { get; set; }

        public Color RightSideBackColor2 { get; set; }

        public Color ButtonNormalBorderColor1 { get; set; }

        public Color ButtonNormalBorderColor2 { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ArrowNormalColor { get; set; }

        public Color ButtonHoverBorderColor1 { get; set; }

        public Color ButtonHoverBorderColor2 { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ArrowHoverColor { get; set; }

        public Color ButtonPressedBorderColor1 { get; set; }

        public Color ButtonPressedBorderColor2 { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public Color ArrowPressedColor { get; set; }

        public Color ButtonShadowColor1 { get; set; }

        public Color ButtonShadowColor2 { get; set; }

        public int ButtonShadowWidth { get; set; }

        public int CornerRadius { get; set; }

        public int ButtonCornerRadius { get; set; }

        public ToggleSwitchModernRenderer()
        {
            OuterBorderColor = Color.FromArgb(255, 31, 31, 31);
            InnerBorderColor1 = Color.FromArgb(255, 80, 80, 82);
            InnerBorderColor2 = Color.FromArgb(255, 109, 110, 112);
            LeftSideBackColor1 = Color.FromArgb(255, 57, 166, 222);
            LeftSideBackColor2 = Color.FromArgb(255, 53, 155, 229);
            RightSideBackColor1 = Color.FromArgb(255, 48, 49, 45);
            RightSideBackColor2 = Color.FromArgb(255, 51, 52, 48);
            ButtonNormalBorderColor1 = Color.FromArgb(255, 31, 31, 31);
            ButtonNormalBorderColor2 = Color.FromArgb(255, 31, 31, 31);
            ButtonNormalSurfaceColor1 = Color.FromArgb(255, 51, 52, 48);
            ButtonNormalSurfaceColor2 = Color.FromArgb(255, 51, 52, 48);
            ArrowNormalColor = Color.FromArgb(255, 53, 156, 230);
            ButtonHoverBorderColor1 = Color.FromArgb(255, 29, 29, 29);
            ButtonHoverBorderColor2 = Color.FromArgb(255, 29, 29, 29);
            ButtonHoverSurfaceColor1 = Color.FromArgb(255, 48, 49, 45);
            ButtonHoverSurfaceColor2 = Color.FromArgb(255, 48, 49, 45);
            ArrowHoverColor = Color.FromArgb(255, 50, 148, 219);
            ButtonPressedBorderColor1 = Color.FromArgb(255, 23, 23, 23);
            ButtonPressedBorderColor2 = Color.FromArgb(255, 23, 23, 23);
            ButtonPressedSurfaceColor1 = Color.FromArgb(255, 38, 39, 36);
            ButtonPressedSurfaceColor2 = Color.FromArgb(255, 38, 39, 36);
            ArrowPressedColor = Color.FromArgb(255, 39, 117, 172);
            ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);
            ButtonShadowWidth = 7;
            CornerRadius = 6;
            ButtonCornerRadius = 6;
        }

        public void Dispose()
        {
            if (_innerControlPath != null)
            {
                _innerControlPath.Dispose();
            }
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using (GraphicsPath graphicsPath = GetRoundedRectanglePath(borderRectangle, CornerRadius))
            {
                g.SetClip(graphicsPath);
                Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? OuterBorderColor : OuterBorderColor.ToGrayScale());
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillPath(brush, graphicsPath);
                }
                g.ResetClip();
            }
            Rectangle rectangle = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 2, borderRectangle.Height - 2);
            using (GraphicsPath graphicsPath2 = GetRoundedRectanglePath(rectangle, CornerRadius))
            {
                g.SetClip(graphicsPath2);
                Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor1 : InnerBorderColor1.ToGrayScale());
                Color color3 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor2 : InnerBorderColor2.ToGrayScale());
                using (Brush brush2 = new LinearGradientBrush(borderRectangle, color2, color3, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush2, graphicsPath2);
                }
                g.ResetClip();
            }
            Rectangle rectangle2 = new Rectangle(borderRectangle.X + 2, borderRectangle.Y + 2, borderRectangle.Width - 4, borderRectangle.Height - 4);
            _innerControlPath = GetRoundedRectanglePath(rectangle2, CornerRadius);
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            int buttonWidth = GetButtonWidth();
            int width = leftRectangle.Width + buttonWidth / 2;
            Rectangle rectangle = new Rectangle(leftRectangle.X, leftRectangle.Y, width, leftRectangle.Height);
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColor1 : LeftSideBackColor1.ToGrayScale());
            Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColor2 : LeftSideBackColor2.ToGrayScale());
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle);
            }
            else
            {
                g.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, color, color2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rectangle);
            }
            g.ResetClip();
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = leftRectangle.X + leftRectangle.Width - ButtonShadowWidth;
            rectangle2.Y = leftRectangle.Y;
            rectangle2.Width = ButtonShadowWidth + CornerRadius;
            rectangle2.Height = leftRectangle.Height;
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle2);
            }
            else
            {
                g.SetClip(rectangle2);
            }
            using (Brush brush2 = new LinearGradientBrush(rectangle2, ButtonShadowColor2, ButtonShadowColor1, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush2, rectangle2);
            }
            g.ResetClip();
            if (base.ToggleSwitch.OnSideImage == null && string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                return;
            }
            RectangleF rectangleF = new RectangleF(leftRectangle.X + 1 - (totalToggleFieldWidth - leftRectangle.Width), 1f, totalToggleFieldWidth - 1, base.ToggleSwitch.Height - 2);
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangleF);
            }
            else
            {
                g.SetClip(rectangleF);
            }
            if (base.ToggleSwitch.OnSideImage != null)
            {
                Size size = base.ToggleSwitch.OnSideImage.Size;
                int x = (int)rectangleF.X;
                if (base.ToggleSwitch.OnSideScaleImageToFit)
                {
                    Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rectangleF.Width, (int)rectangleF.Height), imageSize: size);
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size2.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size2.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
                else
                {
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                SizeF sizeF = g.MeasureString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont);
                float x2 = rectangleF.X;
                if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                {
                    x2 = rectangleF.X + (rectangleF.Width - sizeF.Width) / 2f;
                }
                else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                {
                    x2 = rectangleF.X + rectangleF.Width - sizeF.Width;
                }
                RectangleF layoutRectangle = new RectangleF(x2, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                Color color3 = base.ToggleSwitch.OnForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                }
                using Brush brush3 = new SolidBrush(color3);
                g.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush3, layoutRectangle);
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            int buttonWidth = GetButtonWidth();
            int width = rightRectangle.Width + buttonWidth / 2;
            Rectangle rectangle = new Rectangle(rightRectangle.X - buttonWidth / 2, rightRectangle.Y, width, rightRectangle.Height);
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideBackColor1 : RightSideBackColor1.ToGrayScale());
            Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideBackColor2 : RightSideBackColor2.ToGrayScale());
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle);
            }
            else
            {
                g.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, color, color2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, rectangle);
            }
            g.ResetClip();
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = rightRectangle.X - CornerRadius;
            rectangle2.Y = rightRectangle.Y;
            rectangle2.Width = ButtonShadowWidth + CornerRadius;
            rectangle2.Height = rightRectangle.Height;
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle2);
            }
            else
            {
                g.SetClip(rectangle2);
            }
            using (Brush brush2 = new LinearGradientBrush(rectangle2, ButtonShadowColor1, ButtonShadowColor2, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush2, rectangle2);
            }
            g.ResetClip();
            if (base.ToggleSwitch.OffSideImage == null && string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                return;
            }
            RectangleF rectangleF = new RectangleF(rightRectangle.X, 1f, totalToggleFieldWidth - 1, base.ToggleSwitch.Height - 2);
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangleF);
            }
            else
            {
                g.SetClip(rectangleF);
            }
            if (base.ToggleSwitch.OffSideImage != null)
            {
                Size size = base.ToggleSwitch.OffSideImage.Size;
                int x = (int)rectangleF.X;
                if (base.ToggleSwitch.OffSideScaleImageToFit)
                {
                    Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rectangleF.Width, (int)rectangleF.Height), imageSize: size);
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size2.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size2.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3);
                    }
                }
                else
                {
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rectangleF.X + (rectangleF.Width - (float)size.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rectangleF.X + rectangleF.Width - (float)size.Width);
                    }
                    Rectangle rectangle3 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle3, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle3);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                SizeF sizeF = g.MeasureString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont);
                float x2 = rectangleF.X;
                if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                {
                    x2 = rectangleF.X + (rectangleF.Width - sizeF.Width) / 2f;
                }
                else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                {
                    x2 = rectangleF.X + rectangleF.Width - sizeF.Width;
                }
                RectangleF layoutRectangle = new RectangleF(x2, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                Color color3 = base.ToggleSwitch.OffForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                }
                using Brush brush3 = new SolidBrush(color3);
                g.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush3, layoutRectangle);
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(buttonRectangle);
            }
            else
            {
                g.SetClip(buttonRectangle);
            }
            using (GraphicsPath path = GetRoundedRectanglePath(buttonRectangle, ButtonCornerRadius))
            {
                Color color = ButtonNormalSurfaceColor1;
                Color color2 = ButtonNormalSurfaceColor2;
                if (base.ToggleSwitch.IsButtonPressed)
                {
                    color = ButtonPressedSurfaceColor1;
                    color2 = ButtonPressedSurfaceColor2;
                }
                else if (base.ToggleSwitch.IsButtonHovered)
                {
                    color = ButtonHoverSurfaceColor1;
                    color2 = ButtonHoverSurfaceColor2;
                }
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                    color2 = color2.ToGrayScale();
                }
                using (Brush brush = new LinearGradientBrush(buttonRectangle, color, color2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }
                Color color3 = ButtonNormalBorderColor1;
                Color color4 = ButtonNormalBorderColor2;
                if (base.ToggleSwitch.IsButtonPressed)
                {
                    color3 = ButtonPressedBorderColor1;
                    color4 = ButtonPressedBorderColor2;
                }
                else if (base.ToggleSwitch.IsButtonHovered)
                {
                    color3 = ButtonHoverBorderColor1;
                    color4 = ButtonHoverBorderColor2;
                }
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color3 = color3.ToGrayScale();
                    color4 = color4.ToGrayScale();
                }
                using Brush brush2 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical);
                using Pen pen = new Pen(brush2);
                g.DrawPath(pen, path);
            }
            g.ResetClip();
            Color color5 = ArrowNormalColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color5 = ArrowPressedColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color5 = ArrowHoverColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            Rectangle arrowRectangle = default(Rectangle);
            arrowRectangle.Height = 9;
            arrowRectangle.Width = 22;
            arrowRectangle.X = buttonRectangle.X + (int)(((double)buttonRectangle.Width - (double)arrowRectangle.Width) / 2.0);
            arrowRectangle.Y = buttonRectangle.Y + (int)(((double)buttonRectangle.Height - (double)arrowRectangle.Height) / 2.0);
            using Brush brush3 = new SolidBrush(color5);
            using (GraphicsPath path2 = GetArrowLeftPath(arrowRectangle))
            {
                g.FillPath(brush3, path2);
            }
            using GraphicsPath path3 = GetArrowRightPath(arrowRectangle);
            g.FillPath(brush3, path3);
        }

        public GraphicsPath GetRoundedRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int num = 2 * radius;
            if (num > base.ToggleSwitch.Height)
            {
                num = base.ToggleSwitch.Height;
            }
            if (num > base.ToggleSwitch.Width)
            {
                num = base.ToggleSwitch.Width;
            }
            graphicsPath.AddArc(rectangle.X, rectangle.Y, num, num, 180f, 90f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y, num, num, 270f, 90f);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - num, rectangle.Y + rectangle.Height - num, num, num, 0f, 90f);
            graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - num, num, num, 90f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetArrowLeftPath(Rectangle arrowRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Point point = new Point(arrowRectangle.X + 8, arrowRectangle.Y);
            Point point2 = new Point(arrowRectangle.X + 8, arrowRectangle.Y + arrowRectangle.Height);
            Point point3 = new Point(arrowRectangle.X, arrowRectangle.Y + arrowRectangle.Height / 2);
            graphicsPath.AddLine(point, point2);
            graphicsPath.AddLine(point2, point3);
            graphicsPath.AddLine(point3, point);
            return graphicsPath;
        }

        public GraphicsPath GetArrowRightPath(Rectangle arrowRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Point point = new Point(arrowRectangle.X + 14, arrowRectangle.Y);
            Point point2 = new Point(arrowRectangle.X + 14, arrowRectangle.Y + arrowRectangle.Height);
            Point point3 = new Point(arrowRectangle.X + arrowRectangle.Width, arrowRectangle.Y + arrowRectangle.Height / 2);
            graphicsPath.AddLine(point, point2);
            graphicsPath.AddLine(point2, point3);
            graphicsPath.AddLine(point3, point);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            float num = 1.41f * (float)base.ToggleSwitch.Height;
            return (int)num;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            return new Rectangle(base.ToggleSwitch.ButtonValue, 0, buttonWidth, base.ToggleSwitch.Height);
        }
    }
}
