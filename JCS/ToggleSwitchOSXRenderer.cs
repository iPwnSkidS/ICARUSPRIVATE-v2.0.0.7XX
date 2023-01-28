using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchOSXRenderer : ToggleSwitchRendererBase, IDisposable
    {
        private GraphicsPath _innerControlPath;

        public Color OuterBorderColor { get; set; }

        public Color InnerBorderColor1 { get; set; }

        public Color InnerBorderColor2 { get; set; }

        public Color BackColor1 { get; set; }

        public Color BackColor2 { get; set; }

        public Color ButtonNormalBorderColor1 { get; set; }

        public Color ButtonNormalBorderColor2 { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ButtonHoverBorderColor1 { get; set; }

        public Color ButtonHoverBorderColor2 { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ButtonPressedBorderColor1 { get; set; }

        public Color ButtonPressedBorderColor2 { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public Color ButtonShadowColor1 { get; set; }

        public Color ButtonShadowColor2 { get; set; }

        public int ButtonShadowWidth { get; set; }

        public int CornerRadius { get; set; }

        public ToggleSwitchOSXRenderer()
        {
            OuterBorderColor = Color.FromArgb(255, 108, 108, 108);
            InnerBorderColor1 = Color.FromArgb(255, 137, 138, 139);
            InnerBorderColor2 = Color.FromArgb(255, 167, 168, 169);
            BackColor1 = Color.FromArgb(255, 108, 108, 108);
            BackColor2 = Color.FromArgb(255, 163, 163, 163);
            ButtonNormalBorderColor1 = Color.FromArgb(255, 147, 147, 148);
            ButtonNormalBorderColor2 = Color.FromArgb(255, 167, 168, 169);
            ButtonNormalSurfaceColor1 = Color.FromArgb(255, 250, 250, 250);
            ButtonNormalSurfaceColor2 = Color.FromArgb(255, 224, 224, 224);
            ButtonHoverBorderColor1 = Color.FromArgb(255, 145, 146, 147);
            ButtonHoverBorderColor2 = Color.FromArgb(255, 164, 165, 166);
            ButtonHoverSurfaceColor1 = Color.FromArgb(255, 238, 238, 238);
            ButtonHoverSurfaceColor2 = Color.FromArgb(255, 213, 213, 213);
            ButtonPressedBorderColor1 = Color.FromArgb(255, 138, 138, 140);
            ButtonPressedBorderColor2 = Color.FromArgb(255, 158, 158, 160);
            ButtonPressedSurfaceColor1 = Color.FromArgb(255, 187, 187, 187);
            ButtonPressedSurfaceColor2 = Color.FromArgb(255, 168, 168, 168);
            ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);
            ButtonShadowWidth = 7;
            CornerRadius = 4;
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
            g.SetClip(_innerControlPath);
            Color color4 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BackColor1 : BackColor1.ToGrayScale());
            Color color5 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BackColor2 : BackColor2.ToGrayScale());
            using (Brush brush3 = new LinearGradientBrush(borderRectangle, color4, color5, LinearGradientMode.Vertical))
            {
                g.FillPath(brush3, _innerControlPath);
            }
            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = leftRectangle.X + leftRectangle.Width - ButtonShadowWidth;
            rectangle.Y = leftRectangle.Y;
            rectangle.Width = ButtonShadowWidth + CornerRadius;
            rectangle.Height = leftRectangle.Height;
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle);
            }
            else
            {
                g.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, ButtonShadowColor2, ButtonShadowColor1, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rectangle);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle2);
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
                Color color = base.ToggleSwitch.OnForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                }
                using Brush brush2 = new SolidBrush(color);
                g.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush2, layoutRectangle);
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = rightRectangle.X - CornerRadius;
            rectangle.Y = rightRectangle.Y;
            rectangle.Width = ButtonShadowWidth + CornerRadius;
            rectangle.Height = rightRectangle.Height;
            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rectangle);
            }
            else
            {
                g.SetClip(rectangle);
            }
            using (Brush brush = new LinearGradientBrush(rectangle, ButtonShadowColor1, ButtonShadowColor2, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, rectangle);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2);
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
                    Rectangle rectangle2 = new Rectangle(x, (int)(rectangleF.Y + (rectangleF.Height - (float)size.Height) / 2f), size.Width, size.Height);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle2, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                    }
                    else
                    {
                        g.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle2);
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
                Color color = base.ToggleSwitch.OffForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color = color.ToGrayScale();
                }
                using Brush brush2 = new SolidBrush(color);
                g.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush2, layoutRectangle);
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            buttonRectangle.Inflate(-1, -1);
            using GraphicsPath graphicsPath = GetRoundedRectanglePath(buttonRectangle, CornerRadius);
            g.SetClip(graphicsPath);
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
                g.FillPath(brush, graphicsPath);
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
            using (Brush brush2 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical))
            {
                using Pen pen = new Pen(brush2);
                g.DrawPath(pen, graphicsPath);
            }
            g.ResetClip();
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            if (image == null)
            {
                return;
            }
            g.SetClip(graphicsPath);
            ToggleSwitch.ToggleSwitchButtonAlignment toggleSwitchButtonAlignment = ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonAlignment : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonAlignment : base.ToggleSwitch.OffButtonAlignment));
            Size size = image.Size;
            int x = buttonRectangle.X;
            if ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonScaleImageToFit : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonScaleImageToFit : base.ToggleSwitch.OffButtonScaleImageToFit))
            {
                Size size2 = buttonRectangle.Size;
                Size size3 = ImageHelper.RescaleImageToFit(size, size2);
                switch (toggleSwitchButtonAlignment)
                {
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                        x = (int)((float)buttonRectangle.X + ((float)buttonRectangle.Width - (float)size3.Width) / 2f);
                        break;
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                        x = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)size3.Width);
                        break;
                }
                Rectangle rectangle = new Rectangle(x, (int)((float)buttonRectangle.Y + ((float)buttonRectangle.Height - (float)size3.Height) / 2f), size3.Width, size3.Height);
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    g.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                }
                else
                {
                    g.DrawImage(image, rectangle);
                }
            }
            else
            {
                switch (toggleSwitchButtonAlignment)
                {
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                        x = (int)((float)buttonRectangle.X + ((float)buttonRectangle.Width - (float)size.Width) / 2f);
                        break;
                    case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                        x = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)size.Width);
                        break;
                }
                Rectangle rectangle = new Rectangle(x, (int)((float)buttonRectangle.Y + ((float)buttonRectangle.Height - (float)size.Height) / 2f), size.Width, size.Height);
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    g.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                }
                else
                {
                    g.DrawImageUnscaled(image, rectangle);
                }
            }
            g.ResetClip();
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

        public override int GetButtonWidth()
        {
            float num = 1.53f * (float)(base.ToggleSwitch.Height - 2);
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
