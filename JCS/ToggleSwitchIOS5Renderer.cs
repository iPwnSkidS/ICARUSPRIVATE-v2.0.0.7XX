using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchIOS5Renderer : ToggleSwitchRendererBase
    {
        public Color BorderColor { get; set; }

        public Color LeftSideUpperColor1 { get; set; }

        public Color LeftSideUpperColor2 { get; set; }

        public Color LeftSideLowerColor1 { get; set; }

        public Color LeftSideLowerColor2 { get; set; }

        public Color LeftSideUpperBorderColor { get; set; }

        public Color LeftSideLowerBorderColor { get; set; }

        public Color RightSideUpperColor1 { get; set; }

        public Color RightSideUpperColor2 { get; set; }

        public Color RightSideLowerColor1 { get; set; }

        public Color RightSideLowerColor2 { get; set; }

        public Color RightSideUpperBorderColor { get; set; }

        public Color RightSideLowerBorderColor { get; set; }

        public Color ButtonShadowColor { get; set; }

        public Color ButtonNormalOuterBorderColor { get; set; }

        public Color ButtonNormalInnerBorderColor { get; set; }

        public Color ButtonNormalSurfaceColor1 { get; set; }

        public Color ButtonNormalSurfaceColor2 { get; set; }

        public Color ButtonHoverOuterBorderColor { get; set; }

        public Color ButtonHoverInnerBorderColor { get; set; }

        public Color ButtonHoverSurfaceColor1 { get; set; }

        public Color ButtonHoverSurfaceColor2 { get; set; }

        public Color ButtonPressedOuterBorderColor { get; set; }

        public Color ButtonPressedInnerBorderColor { get; set; }

        public Color ButtonPressedSurfaceColor1 { get; set; }

        public Color ButtonPressedSurfaceColor2 { get; set; }

        public ToggleSwitchIOS5Renderer()
        {
            BorderColor = Color.FromArgb(255, 202, 202, 202);
            LeftSideUpperColor1 = Color.FromArgb(255, 48, 115, 189);
            LeftSideUpperColor2 = Color.FromArgb(255, 17, 123, 220);
            LeftSideLowerColor1 = Color.FromArgb(255, 65, 143, 218);
            LeftSideLowerColor2 = Color.FromArgb(255, 130, 190, 243);
            LeftSideUpperBorderColor = Color.FromArgb(150, 123, 157, 196);
            LeftSideLowerBorderColor = Color.FromArgb(150, 174, 208, 241);
            RightSideUpperColor1 = Color.FromArgb(255, 191, 191, 191);
            RightSideUpperColor2 = Color.FromArgb(255, 229, 229, 229);
            RightSideLowerColor1 = Color.FromArgb(255, 232, 232, 232);
            RightSideLowerColor2 = Color.FromArgb(255, 251, 251, 251);
            RightSideUpperBorderColor = Color.FromArgb(150, 175, 175, 175);
            RightSideLowerBorderColor = Color.FromArgb(150, 229, 230, 233);
            ButtonShadowColor = Color.Transparent;
            ButtonNormalOuterBorderColor = Color.FromArgb(255, 149, 172, 194);
            ButtonNormalInnerBorderColor = Color.FromArgb(255, 235, 235, 235);
            ButtonNormalSurfaceColor1 = Color.FromArgb(255, 216, 215, 216);
            ButtonNormalSurfaceColor2 = Color.FromArgb(255, 251, 250, 251);
            ButtonHoverOuterBorderColor = Color.FromArgb(255, 141, 163, 184);
            ButtonHoverInnerBorderColor = Color.FromArgb(255, 223, 223, 223);
            ButtonHoverSurfaceColor1 = Color.FromArgb(255, 205, 204, 205);
            ButtonHoverSurfaceColor2 = Color.FromArgb(255, 239, 238, 239);
            ButtonPressedOuterBorderColor = Color.FromArgb(255, 111, 128, 145);
            ButtonPressedInnerBorderColor = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedSurfaceColor1 = Color.FromArgb(255, 162, 161, 162);
            ButtonPressedSurfaceColor2 = Color.FromArgb(255, 187, 187, 187);
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            int buttonWidth = GetButtonWidth();
            int width = leftRectangle.Width + buttonWidth / 2;
            int num = (int)(0.8 * (double)(leftRectangle.Height - 2));
            Rectangle controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath controlClipPath = GetControlClipPath(controlRectangle);
            Rectangle rect = new Rectangle(leftRectangle.X, leftRectangle.Y + 1, width, num - 1);
            g.SetClip(controlClipPath);
            g.IntersectClip(rect);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddArc(rect.X, rect.Y, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 135f, 135f);
                graphicsPath.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                graphicsPath.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                graphicsPath.AddLine(rect.X, rect.Y + rect.Height, rect.X + rect.Width, rect.Y + rect.Height);
                Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideUpperColor1 : LeftSideUpperColor1.ToGrayScale());
                Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideUpperColor2 : LeftSideUpperColor2.ToGrayScale());
                using Brush brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.Vertical);
                g.FillPath(brush, graphicsPath);
            }
            g.ResetClip();
            int height = (int)Math.Ceiling(0.5 * (double)(leftRectangle.Height - 2));
            Rectangle rect2 = new Rectangle(leftRectangle.X, leftRectangle.Y + leftRectangle.Height / 2, width, height);
            g.SetClip(controlClipPath);
            g.IntersectClip(rect2);
            using (GraphicsPath graphicsPath2 = new GraphicsPath())
            {
                graphicsPath2.AddArc(1, rect2.Y, (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), base.ToggleSwitch.Height - 1, 215f, 45f);
                graphicsPath2.AddLine(rect2.X + buttonWidth / 2, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                graphicsPath2.AddLine(rect2.X + rect2.Width, rect2.Y, rect2.X + rect2.Width, rect2.Y + rect2.Height);
                graphicsPath2.AddLine(rect2.X + buttonWidth / 4, rect2.Y + rect2.Height, rect2.X + rect2.Width, rect2.Y + rect2.Height);
                graphicsPath2.AddArc(1, 1, base.ToggleSwitch.Height - 1, base.ToggleSwitch.Height - 1, 90f, 70f);
                Color color3 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideLowerColor1 : LeftSideLowerColor1.ToGrayScale());
                Color color4 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? LeftSideLowerColor2 : LeftSideLowerColor2.ToGrayScale());
                using Brush brush2 = new LinearGradientBrush(rect2, color3, color4, LinearGradientMode.Vertical);
                g.FillPath(brush2, graphicsPath2);
            }
            g.ResetClip();
            controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            controlClipPath = GetControlClipPath(controlRectangle);
            g.SetClip(controlClipPath);
            Color color5 = LeftSideUpperBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            using (Pen pen = new Pen(color5))
            {
                g.DrawLine(pen, leftRectangle.X, leftRectangle.Y + 1, leftRectangle.X + leftRectangle.Width + buttonWidth / 2, leftRectangle.Y + 1);
            }
            Color color6 = LeftSideLowerBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color6 = color6.ToGrayScale();
            }
            using (Pen pen2 = new Pen(color6))
            {
                g.DrawLine(pen2, leftRectangle.X, leftRectangle.Y + leftRectangle.Height - 1, leftRectangle.X + leftRectangle.Width + buttonWidth / 2, leftRectangle.Y + leftRectangle.Height - 1);
            }
            if (base.ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                RectangleF rect3 = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                g.IntersectClip(rect3);
                if (base.ToggleSwitch.OnSideImage != null)
                {
                    Size size = base.ToggleSwitch.OnSideImage.Size;
                    int x = (int)rect3.X;
                    if (base.ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect3.Width, (int)rect3.Height), imageSize: size);
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect3.X + (rect3.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                            x = (int)(rect3.X + (rect3.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                    float x2 = rect3.X;
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect3.X + (rect3.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x2 = rect3.X + rect3.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect3.Y + (rect3.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color7 = base.ToggleSwitch.OnForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color7 = color7.ToGrayScale();
                    }
                    using Brush brush3 = new SolidBrush(color7);
                    g.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush3, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle buttonRectangle = GetButtonRectangle();
            Rectangle controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            GraphicsPath controlClipPath = GetControlClipPath(controlRectangle);
            int num = rightRectangle.Width + buttonRectangle.Width / 2;
            int num2 = (int)(0.8 * (double)(rightRectangle.Height - 2));
            Rectangle rect = new Rectangle(rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + 1, num - 1, num2 - 1);
            g.SetClip(controlClipPath);
            g.IntersectClip(rect);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y);
                graphicsPath.AddArc(rect.X + rect.Width - base.ToggleSwitch.Height + 1, rect.Y - 1, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 270f, 115f);
                graphicsPath.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height);
                graphicsPath.AddLine(rect.X, rect.Y + rect.Height, rect.X, rect.Y);
                Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideUpperColor1 : RightSideUpperColor1.ToGrayScale());
                Color color2 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideUpperColor2 : RightSideUpperColor2.ToGrayScale());
                using Brush brush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.Vertical);
                g.FillPath(brush, graphicsPath);
            }
            g.ResetClip();
            int height = (int)Math.Ceiling(0.5 * (double)(rightRectangle.Height - 2));
            Rectangle rect2 = new Rectangle(rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + rightRectangle.Height / 2, num - 1, height);
            g.SetClip(controlClipPath);
            g.IntersectClip(rect2);
            using (GraphicsPath graphicsPath2 = new GraphicsPath())
            {
                graphicsPath2.AddLine(rect2.X, rect2.Y, rect2.X + rect2.Width, rect2.Y);
                graphicsPath2.AddArc(rect2.X + rect2.Width - (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), rect2.Y, (int)(0.75 * (double)(base.ToggleSwitch.Height - 1)), base.ToggleSwitch.Height - 1, 270f, 45f);
                graphicsPath2.AddArc(base.ToggleSwitch.Width - base.ToggleSwitch.Height, 0, base.ToggleSwitch.Height, base.ToggleSwitch.Height, 20f, 70f);
                graphicsPath2.AddLine(rect2.X + rect2.Width, rect2.Y + rect2.Height, rect2.X, rect2.Y + rect2.Height);
                graphicsPath2.AddLine(rect2.X, rect2.Y + rect2.Height, rect2.X, rect2.Y);
                Color color3 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideLowerColor1 : RightSideLowerColor1.ToGrayScale());
                Color color4 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? RightSideLowerColor2 : RightSideLowerColor2.ToGrayScale());
                using Brush brush2 = new LinearGradientBrush(rect2, color3, color4, LinearGradientMode.Vertical);
                g.FillPath(brush2, graphicsPath2);
            }
            g.ResetClip();
            controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            controlClipPath = GetControlClipPath(controlRectangle);
            g.SetClip(controlClipPath);
            Color color5 = RightSideUpperBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            using (Pen pen = new Pen(color5))
            {
                g.DrawLine(pen, rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + 1);
            }
            Color color6 = RightSideLowerBorderColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color6 = color6.ToGrayScale();
            }
            using (Pen pen2 = new Pen(color6))
            {
                g.DrawLine(pen2, rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + rightRectangle.Height - 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + rightRectangle.Height - 1);
            }
            if (base.ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                RectangleF rect3 = new RectangleF(rightRectangle.X, 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                g.IntersectClip(rect3);
                if (base.ToggleSwitch.OffSideImage != null)
                {
                    Size size = base.ToggleSwitch.OffSideImage.Size;
                    int x = (int)rect3.X;
                    if (base.ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect3.Width, (int)rect3.Height), imageSize: size);
                        if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect3.X + (rect3.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size2.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                            x = (int)(rect3.X + (rect3.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                        {
                            x = (int)(rect3.X + rect3.Width - (float)size.Width);
                        }
                        Rectangle rectangle = new Rectangle(x, (int)(rect3.Y + (rect3.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                    float x2 = rect3.X;
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect3.X + (rect3.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x2 = rect3.X + rect3.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect3.Y + (rect3.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color7 = base.ToggleSwitch.OffForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color7 = color7.ToGrayScale();
                    }
                    using Brush brush3 = new SolidBrush(color7);
                    g.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush3, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            if (base.ToggleSwitch.IsButtonOnLeftSide)
            {
                buttonRectangle.X++;
            }
            else if (base.ToggleSwitch.IsButtonOnRightSide)
            {
                buttonRectangle.X--;
            }
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            buttonRectangle.Inflate(1, 1);
            Rectangle clip = new Rectangle(buttonRectangle.Location, buttonRectangle.Size);
            clip.Inflate(0, -1);
            if (base.ToggleSwitch.IsButtonOnLeftSide)
            {
                clip.X += clip.Width / 2;
                clip.Width /= 2;
            }
            else if (base.ToggleSwitch.IsButtonOnRightSide)
            {
                clip.Width /= 2;
            }
            g.SetClip(clip);
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? ButtonShadowColor : ButtonShadowColor.ToGrayScale());
            using (Pen pen = new Pen(color))
            {
                g.DrawEllipse(pen, buttonRectangle);
            }
            g.ResetClip();
            buttonRectangle.Inflate(-1, -1);
            Color color2 = ButtonNormalOuterBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color2 = ButtonPressedOuterBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color2 = ButtonHoverOuterBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color2 = color2.ToGrayScale();
            }
            using (Brush brush = new SolidBrush(color2))
            {
                g.FillEllipse(brush, buttonRectangle);
            }
            buttonRectangle.Inflate(-1, -1);
            Color color3 = ButtonNormalInnerBorderColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color3 = ButtonPressedInnerBorderColor;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color3 = ButtonHoverInnerBorderColor;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color3 = color3.ToGrayScale();
            }
            using (Brush brush2 = new SolidBrush(color3))
            {
                g.FillEllipse(brush2, buttonRectangle);
            }
            buttonRectangle.Inflate(-1, -1);
            Color color4 = ButtonNormalSurfaceColor1;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color4 = ButtonPressedSurfaceColor1;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color4 = ButtonHoverSurfaceColor1;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color4 = color4.ToGrayScale();
            }
            Color color5 = ButtonNormalSurfaceColor2;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color5 = ButtonPressedSurfaceColor2;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color5 = ButtonHoverSurfaceColor2;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color5 = color5.ToGrayScale();
            }
            using (Brush brush3 = new LinearGradientBrush(buttonRectangle, color4, color5, LinearGradientMode.Vertical))
            {
                g.FillEllipse(brush3, buttonRectangle);
            }
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;
            Rectangle controlRectangle = new Rectangle(0, 0, base.ToggleSwitch.Width, base.ToggleSwitch.Height);
            using (GraphicsPath path = GetControlClipPath(controlRectangle))
            {
                Color color6 = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BorderColor : BorderColor.ToGrayScale());
                using Pen pen2 = new Pen(color6);
                g.DrawPath(pen2, path);
            }
            g.ResetClip();
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            if (image == null)
            {
                return;
            }
            g.SetClip(GetButtonClipPath());
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

        public GraphicsPath GetControlClipPath(Rectangle controlRectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(controlRectangle.X, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 90f, 180f);
            graphicsPath.AddArc(controlRectangle.X + controlRectangle.Width - controlRectangle.Height, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 270f, 180f);
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
    }
}
