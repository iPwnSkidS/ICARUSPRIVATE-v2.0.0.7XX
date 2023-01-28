using System.Drawing;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchMetroRenderer : ToggleSwitchRendererBase
    {
        public Color BackColor { get; set; }

        public Color LeftSideColor { get; set; }

        public Color LeftSideColorHovered { get; set; }

        public Color LeftSideColorPressed { get; set; }

        public Color RightSideColor { get; set; }

        public Color RightSideColorHovered { get; set; }

        public Color RightSideColorPressed { get; set; }

        public Color BorderColor { get; set; }

        public Color ButtonColor { get; set; }

        public Color ButtonColorHovered { get; set; }

        public Color ButtonColorPressed { get; set; }

        public ToggleSwitchMetroRenderer()
        {
            BackColor = Color.White;
            LeftSideColor = Color.FromArgb(255, 23, 153, 0);
            LeftSideColorHovered = Color.FromArgb(255, 36, 182, 9);
            LeftSideColorPressed = Color.FromArgb(255, 121, 245, 100);
            RightSideColor = Color.FromArgb(255, 166, 166, 166);
            RightSideColorHovered = Color.FromArgb(255, 181, 181, 181);
            RightSideColorPressed = Color.FromArgb(255, 189, 189, 189);
            BorderColor = Color.FromArgb(255, 166, 166, 166);
            ButtonColor = Color.Black;
            ButtonColorHovered = Color.Black;
            ButtonColorPressed = Color.Black;
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BorderColor : BorderColor.ToGrayScale());
            g.SetClip(borderRectangle);
            using (Pen pen = new Pen(color))
            {
                g.DrawRectangle(pen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
            }
            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Rectangle rectangle = new Rectangle(leftRectangle.X + 2, 2, leftRectangle.Width - 2, leftRectangle.Height - 4);
            if (rectangle.Width <= 0)
            {
                return;
            }
            Color color = LeftSideColor;
            if (base.ToggleSwitch.IsLeftSidePressed)
            {
                color = LeftSideColorPressed;
            }
            else if (base.ToggleSwitch.IsLeftSideHovered)
            {
                color = LeftSideColorHovered;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            g.SetClip(rectangle);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rectangle);
            }
            if (base.ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(base.ToggleSwitch.OnText))
            {
                RectangleF rect = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
                g.IntersectClip(rect);
                if (base.ToggleSwitch.OnSideImage != null)
                {
                    Size size = base.ToggleSwitch.OnSideImage.Size;
                    int x = (int)rect.X;
                    if (base.ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect.Width, (int)rect.Height), imageSize: size);
                        if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                        {
                            x = (int)(rect.X + (rect.Width - (float)size2.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect.X + rect.Width - (float)size2.Width);
                        }
                        Rectangle rectangle2 = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                            x = (int)(rect.X + (rect.Width - (float)size.Width) / 2f);
                        }
                        else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                        {
                            x = (int)(rect.X + rect.Width - (float)size.Width);
                        }
                        Rectangle rectangle2 = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                    float x2 = rect.X;
                    if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x2 = rect.X + (rect.Width - sizeF.Width) / 2f;
                    }
                    else if (base.ToggleSwitch.OnSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Near)
                    {
                        x2 = rect.X + rect.Width - sizeF.Width;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, rect.Y + (rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    Color color2 = base.ToggleSwitch.OnForeColor;
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color2 = color2.ToGrayScale();
                    }
                    using Brush brush2 = new SolidBrush(color2);
                    g.DrawString(base.ToggleSwitch.OnText, base.ToggleSwitch.OnFont, brush2, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            Rectangle rectangle = new Rectangle(rightRectangle.X, 2, rightRectangle.Width - 2, rightRectangle.Height - 4);
            if (rectangle.Width <= 0)
            {
                return;
            }
            Color color = RightSideColor;
            if (base.ToggleSwitch.IsRightSidePressed)
            {
                color = RightSideColorPressed;
            }
            else if (base.ToggleSwitch.IsRightSideHovered)
            {
                color = RightSideColorHovered;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            g.SetClip(rectangle);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rectangle);
            }
            if (base.ToggleSwitch.OffSideImage == null && string.IsNullOrEmpty(base.ToggleSwitch.OffText))
            {
                return;
            }
            RectangleF rect = new RectangleF(rightRectangle.X, 2f, totalToggleFieldWidth - 2, base.ToggleSwitch.Height - 4);
            g.IntersectClip(rect);
            if (base.ToggleSwitch.OffSideImage != null)
            {
                Size size = base.ToggleSwitch.OffSideImage.Size;
                int x = (int)rect.X;
                if (base.ToggleSwitch.OffSideScaleImageToFit)
                {
                    Size size2 = ImageHelper.RescaleImageToFit(canvasSize: new Size((int)rect.Width, (int)rect.Height), imageSize: size);
                    if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                    {
                        x = (int)(rect.X + (rect.Width - (float)size2.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rect.X + rect.Width - (float)size2.Width);
                    }
                    Rectangle rectangle2 = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size2.Height) / 2f), size2.Width, size2.Height);
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
                        x = (int)(rect.X + (rect.Width - (float)size.Width) / 2f);
                    }
                    else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                    {
                        x = (int)(rect.X + rect.Width - (float)size.Width);
                    }
                    Rectangle rectangle2 = new Rectangle(x, (int)(rect.Y + (rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
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
                float x2 = rect.X;
                if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Center)
                {
                    x2 = rect.X + (rect.Width - sizeF.Width) / 2f;
                }
                else if (base.ToggleSwitch.OffSideAlignment == ToggleSwitch.ToggleSwitchAlignment.Far)
                {
                    x2 = rect.X + rect.Width - sizeF.Width;
                }
                RectangleF layoutRectangle = new RectangleF(x2, rect.Y + (rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                Color color2 = base.ToggleSwitch.OffForeColor;
                if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                {
                    color2 = color2.ToGrayScale();
                }
                using Brush brush2 = new SolidBrush(color2);
                g.DrawString(base.ToggleSwitch.OffText, base.ToggleSwitch.OffFont, brush2, layoutRectangle);
            }
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Color color = ButtonColor;
            if (base.ToggleSwitch.IsButtonPressed)
            {
                color = ButtonColorPressed;
            }
            else if (base.ToggleSwitch.IsButtonHovered)
            {
                color = ButtonColorHovered;
            }
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            g.SetClip(buttonRectangle);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, buttonRectangle);
            }
            g.ResetClip();
        }

        public override int GetButtonWidth()
        {
            return (int)((double)base.ToggleSwitch.Height / 3.0 * 2.0);
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
