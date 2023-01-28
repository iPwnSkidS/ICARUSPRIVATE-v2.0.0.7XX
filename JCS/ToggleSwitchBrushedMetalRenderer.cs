using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchBrushedMetalRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColor1 { get; set; }

        public Color BorderColor2 { get; set; }

        public Color BackColor1 { get; set; }

        public Color BackColor2 { get; set; }

        public Color UpperShadowColor1 { get; set; }

        public Color UpperShadowColor2 { get; set; }

        public Color ButtonNormalBorderColor { get; set; }

        public Color ButtonNormalSurfaceColor { get; set; }

        public Color ButtonHoverBorderColor { get; set; }

        public Color ButtonHoverSurfaceColor { get; set; }

        public Color ButtonPressedBorderColor { get; set; }

        public Color ButtonPressedSurfaceColor { get; set; }

        public int UpperShadowHeight { get; set; }

        public ToggleSwitchBrushedMetalRenderer()
        {
            BorderColor1 = Color.FromArgb(255, 145, 146, 149);
            BorderColor2 = Color.FromArgb(255, 227, 229, 232);
            BackColor1 = Color.FromArgb(255, 125, 126, 128);
            BackColor2 = Color.FromArgb(255, 224, 226, 228);
            UpperShadowColor1 = Color.FromArgb(150, 0, 0, 0);
            UpperShadowColor2 = Color.FromArgb(5, 0, 0, 0);
            ButtonNormalBorderColor = Color.FromArgb(255, 144, 144, 145);
            ButtonNormalSurfaceColor = Color.FromArgb(255, 251, 251, 251);
            ButtonHoverBorderColor = Color.FromArgb(255, 166, 167, 168);
            ButtonHoverSurfaceColor = Color.FromArgb(255, 238, 238, 238);
            ButtonPressedBorderColor = Color.FromArgb(255, 123, 123, 123);
            ButtonPressedSurfaceColor = Color.FromArgb(255, 184, 184, 184);
            UpperShadowHeight = 8;
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            using (GraphicsPath graphicsPath = GetRectangleClipPath(borderRectangle))
            {
                g.SetClip(graphicsPath);
                Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BorderColor1 : BorderColor1.ToGrayScale());
                Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BorderColor2 : BorderColor2.ToGrayScale());
                using (Brush brush = new LinearGradientBrush(borderRectangle, color, color2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, graphicsPath);
                }
                g.ResetClip();
            }
            Rectangle rect = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 1, borderRectangle.Height - 2);
            using GraphicsPath graphicsPath2 = GetRectangleClipPath(rect);
            g.SetClip(graphicsPath2);
            Color color3 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BackColor1 : BackColor1.ToGrayScale());
            Color color4 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BackColor2 : BackColor2.ToGrayScale());
            using (Brush brush2 = new LinearGradientBrush(borderRectangle, color3, color4, LinearGradientMode.Horizontal))
            {
                g.FillPath(brush2, graphicsPath2);
            }
            Rectangle rect2 = new Rectangle(rect.X, rect.Y, rect.Width, UpperShadowHeight);
            g.IntersectClip(rect2);
            using (Brush brush3 = new LinearGradientBrush(rect2, UpperShadowColor1, UpperShadowColor2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush3, rect2);
            }
            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rect = new Rectangle(1, 1, base.ToggleSwitch.Width - 1, base.ToggleSwitch.Height - 2);
            using GraphicsPath clip = GetRectangleClipPath(rect);
            g.SetClip(clip);
            if (base.ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                RectangleF rect2 = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                g.IntersectClip(rect2);
                if (base.ToggleSwitch.OnSideImage != null)
                {
                    Size size = base.ToggleSwitch.OnSideImage.Size;
                    int x = (int)rect2.X;
                    if (base.ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect2.Width, (int)rect2.Height), imageSize: size);
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect2.X + (rect2.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect2.X + rect2.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect2.Y + (rect2.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                    else
                    {
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect2.X + (rect2.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect2.X + rect2.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect2.Y + (rect2.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            g.DrawImageUnscaled(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(base.ToggleSwitch.OnText))
                {
                    SizeF sizeF = g.MeasureString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont);
                    float x2 = rect2.X;
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect2.X + (rect2.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x2 = rect2.X + rect2.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect2.Y + (rect2.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color = base.ToggleSwitch.OnForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color = color.ToGrayScale();
                    }
                    using Brush brush = new SolidBrush(color);
                    g.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            Rectangle rect = new Rectangle(1, 1, base.ToggleSwitch.Width - 1, base.ToggleSwitch.Height - 2);
            using GraphicsPath clip = GetRectangleClipPath(rect);
            g.SetClip(clip);
            if (base.ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                RectangleF rect2 = new RectangleF(rightRectangle.X, 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                g.IntersectClip(rect2);
                if (base.ToggleSwitch.OffSideImage != null)
                {
                    Size size = base.ToggleSwitch.OffSideImage.Size;
                    int x = (int)rect2.X;
                    if (base.ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect2.Width, (int)rect2.Height), imageSize: size);
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect2.X + (rect2.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect2.X + rect2.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect2.Y + (rect2.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle);
                        }
                    }
                    else
                    {
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect2.X + (rect2.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect2.X + rect2.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect2.Y + (rect2.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            g.DrawImage(base.ToggleSwitch.OnSideImage, rectangle, 0, 0, base.ToggleSwitch.OnSideImage.Width, base.ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            g.DrawImageUnscaled(base.ToggleSwitch.OffSideImage, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(base.ToggleSwitch.OffText))
                {
                    SizeF sizeF = g.MeasureString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont);
                    float x2 = rect2.X;
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect2.X + (rect2.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x2 = rect2.X + rect2.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect2.Y + (rect2.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color = base.ToggleSwitch.OffForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color = color.ToGrayScale();
                    }
                    using Brush brush = new SolidBrush(color);
                    g.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.SetClip(buttonRectangle);
            Color color = ButtonNormalSurfaceColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color = ButtonPressedSurfaceColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color = ButtonHoverSurfaceColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            using (Brush brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, buttonRectangle);
            }
            using (PathGradientBrush brush2 = GetBrush(centerPoint: new PointF((float)buttonRectangle.X + (float)buttonRectangle.Width / 2f, (float)buttonRectangle.Y + 1.2f * ((float)buttonRectangle.Height / 2f)), Colors: new Color[13]
                   {
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, r: buttonRectangle))
            {
                g.FillEllipse(brush2, buttonRectangle);
            }
            using (PathGradientBrush brush3 = GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 0.8f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + (float)buttonRectangle.Height / 2f), Colors: new Color[9]
                   {
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 110, 110, 110)
                   }, r: buttonRectangle))
            {
                g.FillEllipse(brush3, buttonRectangle);
            }
            using (PathGradientBrush brush4 = GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 1.2f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + (float)buttonRectangle.Height / 2f), Colors: new Color[9]
                   {
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.FromArgb(255, 98, 98, 98),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, r: buttonRectangle))
            {
                g.FillEllipse(brush4, buttonRectangle);
            }
            using (PathGradientBrush brush5 = GetBrush(centerPoint: new PointF((float)buttonRectangle.X + 0.9f * ((float)buttonRectangle.Width / 2f), (float)buttonRectangle.Y + 0.9f * ((float)buttonRectangle.Height / 2f)), Colors: new Color[13]
                   {
                       Color.Transparent,
                       Color.FromArgb(255, 188, 188, 188),
                       Color.FromArgb(255, 110, 110, 110),
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent,
                       Color.Transparent
                   }, r: buttonRectangle))
            {
                g.FillEllipse(brush5, buttonRectangle);
            }
            Color color2 = ButtonNormalBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color2 = ButtonPressedBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color2 = ButtonHoverBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color2 = color2.ToGrayScale();
            }
            using (Pen pen = new Pen(color2))
            {
                g.DrawEllipse(pen, buttonRectangle);
            }
            g.ResetClip();
        }

        public GraphicsPath GetRectangleClipPath(Rectangle rect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(rect.X, rect.Y, rect.Height, rect.Height, 90f, 180f);
            graphicsPath.AddArc(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = GetButtonRectangle();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Height, buttonRectangle.Height, 0f, 360f);
            return graphicsPath;
        }

        public override int GetButtonWidth()
        {
            return base.ToggleSwitch.Height - 2;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            return new Rectangle(base.ToggleSwitch.ButtonValue, 1, buttonWidth, buttonWidth);
        }

        private PathGradientBrush GetBrush(Color[] Colors, RectangleF r, PointF centerPoint)
        {
            int num = Colors.Length - 1;
            PointF[] array = new PointF[num + 1];
            float num2 = 0f;
            int num3 = 0;
            float num4 = r.Width / 2f;
            float num5 = r.Height / 2f;
            int num6 = (int)Math.Floor(180.0 * ((double)num - 2.0) / (double)num / 2.0);
            double a = (double)num6 * Math.PI / 180.0;
            double num7 = 1.0 / Math.Sin(a);
            float num8 = (float)((double)num4 * num7);
            float num9 = (float)((double)num5 * num7);
            for (; (double)num2 <= Math.PI * 2.0; num2 += (float)(Math.PI * 2.0 / (double)num))
            {
                array[num3] = new PointF((float)((double)num4 + Math.Cos(num2) * (double)num8) + r.Left, (float)((double)num5 + Math.Sin(num2) * (double)num9) + r.Top);
                num3++;
            }
            array[num] = array[0];
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(array);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.CenterPoint = centerPoint;
            pathGradientBrush.CenterColor = Color.Transparent;
            pathGradientBrush.SurroundColors = new Color[1] { Color.White };
            try
            {
                pathGradientBrush.SurroundColors = Colors;
                return pathGradientBrush;
            }
            catch (Exception innerException)
            {
                throw new Exception("Too may colors!", innerException);
            }
        }
    }
}
