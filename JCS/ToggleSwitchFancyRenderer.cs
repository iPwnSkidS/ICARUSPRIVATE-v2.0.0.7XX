using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchFancyRenderer : ToggleSwitchRendererBase, IDisposable
    {
        private GraphicsPath _innerControlPath;

        public Color OuterBorderColor1 { get; set; }

        public Color OuterBorderColor2 { get; set; }

        public Color InnerBorderColor1 { get; set; }

        public Color InnerBorderColor2 { get; set; }

        public Color LeftSideBackColor1 { get; set; }

        public Color LeftSideBackColor2 { get; set; }

        public Color RightSideBackColor1 { get; set; }

        public Color RightSideBackColor2 { get; set; }

        public Color ButtonNormalBorderColor1 { get; set; }

        public Color ButtonNormalBorderColor2 { get; set; }

        public Color ButtonNormalUpperSurfaceColor1 { get; set; }

        public Color ButtonNormalUpperSurfaceColor2 { get; set; }

        public Color ButtonNormalLowerSurfaceColor1 { get; set; }

        public Color ButtonNormalLowerSurfaceColor2 { get; set; }

        public Color ButtonHoverBorderColor1 { get; set; }

        public Color ButtonHoverBorderColor2 { get; set; }

        public Color ButtonHoverUpperSurfaceColor1 { get; set; }

        public Color ButtonHoverUpperSurfaceColor2 { get; set; }

        public Color ButtonHoverLowerSurfaceColor1 { get; set; }

        public Color ButtonHoverLowerSurfaceColor2 { get; set; }

        public Color ButtonPressedBorderColor1 { get; set; }

        public Color ButtonPressedBorderColor2 { get; set; }

        public Color ButtonPressedUpperSurfaceColor1 { get; set; }

        public Color ButtonPressedUpperSurfaceColor2 { get; set; }

        public Color ButtonPressedLowerSurfaceColor1 { get; set; }

        public Color ButtonPressedLowerSurfaceColor2 { get; set; }

        public Color ButtonShadowColor1 { get; set; }

        public Color ButtonShadowColor2 { get; set; }

        public int ButtonShadowWidth { get; set; }

        public int CornerRadius { get; set; }

        public ToggleSwitchFancyRenderer()
        {
            OuterBorderColor1 = Color.FromArgb(255, 197, 199, 201);
            OuterBorderColor2 = Color.FromArgb(255, 207, 209, 212);
            InnerBorderColor1 = Color.FromArgb(200, 205, 208, 207);
            InnerBorderColor2 = Color.FromArgb(255, 207, 209, 212);
            LeftSideBackColor1 = Color.FromArgb(255, 61, 110, 6);
            LeftSideBackColor2 = Color.FromArgb(255, 93, 170, 9);
            RightSideBackColor1 = Color.FromArgb(255, 149, 0, 0);
            RightSideBackColor2 = Color.FromArgb(255, 198, 0, 0);
            ButtonNormalBorderColor1 = Color.FromArgb(255, 212, 209, 211);
            ButtonNormalBorderColor2 = Color.FromArgb(255, 197, 199, 201);
            ButtonNormalUpperSurfaceColor1 = Color.FromArgb(255, 252, 251, 252);
            ButtonNormalUpperSurfaceColor2 = Color.FromArgb(255, 247, 247, 247);
            ButtonNormalLowerSurfaceColor1 = Color.FromArgb(255, 233, 233, 233);
            ButtonNormalLowerSurfaceColor2 = Color.FromArgb(255, 225, 225, 225);
            ButtonHoverBorderColor1 = Color.FromArgb(255, 212, 207, 209);
            ButtonHoverBorderColor2 = Color.FromArgb(255, 223, 223, 223);
            ButtonHoverUpperSurfaceColor1 = Color.FromArgb(255, 240, 239, 240);
            ButtonHoverUpperSurfaceColor2 = Color.FromArgb(255, 235, 235, 235);
            ButtonHoverLowerSurfaceColor1 = Color.FromArgb(255, 221, 221, 221);
            ButtonHoverLowerSurfaceColor2 = Color.FromArgb(255, 214, 214, 214);
            ButtonPressedBorderColor1 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedBorderColor2 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedUpperSurfaceColor1 = Color.FromArgb(255, 189, 188, 189);
            ButtonPressedUpperSurfaceColor2 = Color.FromArgb(255, 185, 185, 185);
            ButtonPressedLowerSurfaceColor1 = Color.FromArgb(255, 175, 175, 175);
            ButtonPressedLowerSurfaceColor2 = Color.FromArgb(255, 169, 169, 169);
            ButtonShadowColor1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColor2 = Color.FromArgb(0, 0, 0, 0);
            ButtonShadowWidth = 7;
            CornerRadius = 6;
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
                Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? OuterBorderColor1 : OuterBorderColor1.ToGrayScale());
                Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? OuterBorderColor2 : OuterBorderColor2.ToGrayScale());
                using (Brush brush = new LinearGradientBrush(borderRectangle, color, color2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, graphicsPath);
                }
                g.ResetClip();
            }
            Rectangle rectangle = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 2, borderRectangle.Height - 2);
            using (GraphicsPath graphicsPath2 = GetRoundedRectanglePath(rectangle, CornerRadius))
            {
                g.SetClip(graphicsPath2);
                Color color3 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor1 : InnerBorderColor1.ToGrayScale());
                Color color4 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? InnerBorderColor2 : InnerBorderColor2.ToGrayScale());
                using (Brush brush2 = new LinearGradientBrush(borderRectangle, color3, color4, LinearGradientMode.Vertical))
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
            Color color = ButtonNormalUpperSurfaceColor1;
            Color color2 = ButtonNormalUpperSurfaceColor2;
            Color color3 = ButtonNormalLowerSurfaceColor1;
            Color color4 = ButtonNormalLowerSurfaceColor2;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color = ButtonPressedUpperSurfaceColor1;
                color2 = ButtonPressedUpperSurfaceColor2;
                color3 = ButtonPressedLowerSurfaceColor1;
                color4 = ButtonPressedLowerSurfaceColor2;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color = ButtonHoverUpperSurfaceColor1;
                color2 = ButtonHoverUpperSurfaceColor2;
                color3 = ButtonHoverLowerSurfaceColor1;
                color4 = ButtonHoverLowerSurfaceColor2;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
                color2 = color2.ToGrayScale();
                color3 = color3.ToGrayScale();
                color4 = color4.ToGrayScale();
            }
            buttonRectangle.Inflate(-1, -1);
            int num = buttonRectangle.Height / 2;
            Rectangle rect = new Rectangle(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Width, num);
            Rectangle rect2 = new Rectangle(buttonRectangle.X, buttonRectangle.Y + num, buttonRectangle.Width, buttonRectangle.Height - num);
            using GraphicsPath graphicsPath = GetRoundedRectanglePath(buttonRectangle, CornerRadius);
            g.SetClip(graphicsPath);
            g.IntersectClip(rect);
            using (Brush brush = new LinearGradientBrush(buttonRectangle, color, color2, LinearGradientMode.Vertical))
            {
                g.FillPath(brush, graphicsPath);
            }
            g.ResetClip();
            g.SetClip(graphicsPath);
            g.IntersectClip(rect2);
            using (Brush brush2 = new LinearGradientBrush(buttonRectangle, color3, color4, LinearGradientMode.Vertical))
            {
                g.FillPath(brush2, graphicsPath);
            }
            g.ResetClip();
            g.SetClip(graphicsPath);
            Color color5 = ButtonNormalBorderColor1;
            Color color6 = ButtonNormalBorderColor2;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color5 = ButtonPressedBorderColor1;
                color6 = ButtonPressedBorderColor2;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color5 = ButtonHoverBorderColor1;
                color6 = ButtonHoverBorderColor2;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
                color6 = color6.ToGrayScale();
            }
            using (Brush brush3 = new LinearGradientBrush(buttonRectangle, color5, color6, LinearGradientMode.Vertical))
            {
                using Pen pen = new Pen(brush3);
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
            float num = 1.61f * (float)base.ToggleSwitch.Height;
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
