using System;
using System.Drawing;
using ShitarusPrivate.ToggleSwitch;

namespace ShitarusPrivate.JCS
{
    public class ToggleSwitchAndroidRenderer : ToggleSwitchRendererBase
    {
        public Color BorderColor { get; set; }

        public Color BackColor { get; set; }

        public Color LeftSideColor { get; set; }

        public Color RightSideColor { get; set; }

        public Color OffButtonColor { get; set; }

        public Color OnButtonColor { get; set; }

        public Color OffButtonBorderColor { get; set; }

        public Color OnButtonBorderColor { get; set; }

        public int SlantAngle { get; set; }

        public ToggleSwitchAndroidRenderer()
        {
            BorderColor = Color.FromArgb(255, 166, 166, 166);
            BackColor = Color.FromArgb(255, 32, 32, 32);
            LeftSideColor = Color.FromArgb(255, 32, 32, 32);
            RightSideColor = Color.FromArgb(255, 32, 32, 32);
            OffButtonColor = Color.FromArgb(255, 70, 70, 70);
            OnButtonColor = Color.FromArgb(255, 27, 161, 226);
            OffButtonBorderColor = Color.FromArgb(255, 70, 70, 70);
            OnButtonBorderColor = Color.FromArgb(255, 27, 161, 226);
            SlantAngle = 8;
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            Color color = ((base.ToggleSwitch.Enabled || !base.ToggleSwitch.GrayWhenDisabled) ? BorderColor : BorderColor.ToGrayScale());
            g.SetClip(borderRectangle);
            using Pen pen = new Pen(color);
            g.DrawRectangle(pen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Color color = LeftSideColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            Rectangle innerControlRectangle = GetInnerControlRectangle();
            g.SetClip(innerControlRectangle);
            int halfCathetusLengthBasedOnAngle = GetHalfCathetusLengthBasedOnAngle();
            Rectangle rect = new Rectangle(leftRectangle.X, leftRectangle.Y, leftRectangle.Width + halfCathetusLengthBasedOnAngle, leftRectangle.Height);
            g.IntersectClip(rect);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rect);
            }
            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            Color color = RightSideColor;
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
            }
            Rectangle innerControlRectangle = GetInnerControlRectangle();
            g.SetClip(innerControlRectangle);
            int halfCathetusLengthBasedOnAngle = GetHalfCathetusLengthBasedOnAngle();
            Rectangle rect = new Rectangle(rightRectangle.X - halfCathetusLengthBasedOnAngle, rightRectangle.Y, rightRectangle.Width + halfCathetusLengthBasedOnAngle, rightRectangle.Height);
            g.IntersectClip(rect);
            using (Brush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, rect);
            }
            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Rectangle innerControlRectangle = GetInnerControlRectangle();
            g.SetClip(innerControlRectangle);
            int cathetusLengthBasedOnAngle = GetCathetusLengthBasedOnAngle();
            int num = 2 * cathetusLengthBasedOnAngle;
            Point[] array = new Point[4];
            Rectangle rect = new Rectangle(buttonRectangle.X - cathetusLengthBasedOnAngle, innerControlRectangle.Y, buttonRectangle.Width + num, innerControlRectangle.Height);
            if (SlantAngle > 0)
            {
                array[0] = new Point(rect.X + cathetusLengthBasedOnAngle, rect.Y);
                array[1] = new Point(rect.X + rect.Width - 1, rect.Y);
                array[2] = new Point(rect.X + rect.Width - cathetusLengthBasedOnAngle - 1, rect.Y + rect.Height - 1);
                array[3] = new Point(rect.X, rect.Y + rect.Height - 1);
            }
            else
            {
                array[0] = new Point(rect.X, rect.Y);
                array[1] = new Point(rect.X + rect.Width - cathetusLengthBasedOnAngle - 1, rect.Y);
                array[2] = new Point(rect.X + rect.Width - 1, rect.Y + rect.Height - 1);
                array[3] = new Point(rect.X + cathetusLengthBasedOnAngle, rect.Y + rect.Height - 1);
            }
            g.IntersectClip(rect);
            Color color = (base.ToggleSwitch.Checked ? OnButtonColor : OffButtonColor);
            Color color2 = (base.ToggleSwitch.Checked ? OnButtonBorderColor : OffButtonBorderColor);
            if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
            {
                color = color.ToGrayScale();
                color2 = color2.ToGrayScale();
            }
            using (Pen pen = new Pen(color2))
            {
                g.DrawPolygon(pen, array);
            }
            using (Brush brush = new SolidBrush(color))
            {
                g.FillPolygon(brush, array);
            }
            Image image = base.ToggleSwitch.ButtonImage ?? (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonImage : base.ToggleSwitch.OffButtonImage);
            string text = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnText : base.ToggleSwitch.OffText);
            if (image != null || !string.IsNullOrEmpty(text))
            {
                ToggleSwitch.ToggleSwitchButtonAlignment toggleSwitchButtonAlignment = ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonAlignment : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonAlignment : base.ToggleSwitch.OffButtonAlignment));
                if (image != null)
                {
                    Size size = image.Size;
                    int x = rect.X;
                    if ((base.ToggleSwitch.ButtonImage != null) ? base.ToggleSwitch.ButtonScaleImageToFit : (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnButtonScaleImageToFit : base.ToggleSwitch.OffButtonScaleImageToFit))
                    {
                        Size size2 = rect.Size;
                        Size size3 = ImageHelper.RescaleImageToFit(size, size2);
                        switch (toggleSwitchButtonAlignment)
                        {
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                                x = (int)((float)rect.X + ((float)rect.Width - (float)size3.Width) / 2f);
                                break;
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                                x = (int)((float)rect.X + (float)rect.Width - (float)size3.Width);
                                break;
                        }
                        Rectangle rectangle = new Rectangle(x, (int)((float)rect.Y + ((float)rect.Height - (float)size3.Height) / 2f), size3.Width, size3.Height);
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
                                x = (int)((float)rect.X + ((float)rect.Width - (float)size.Width) / 2f);
                                break;
                            case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                                x = (int)((float)rect.X + (float)rect.Width - (float)size.Width);
                                break;
                        }
                        Rectangle rectangle = new Rectangle(x, (int)((float)rect.Y + ((float)rect.Height - (float)size.Height) / 2f), size.Width, size.Height);
                        if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                        {
                            g.DrawImage(image, rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        }
                        else
                        {
                            g.DrawImageUnscaled(image, rectangle);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    Font font = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnFont : base.ToggleSwitch.OffFont);
                    Color color3 = (base.ToggleSwitch.Checked ? base.ToggleSwitch.OnForeColor : base.ToggleSwitch.OffForeColor);
                    if (!base.ToggleSwitch.Enabled && base.ToggleSwitch.GrayWhenDisabled)
                    {
                        color3 = color3.ToGrayScale();
                    }
                    SizeF sizeF = g.MeasureString(text, font);
                    float x2 = rect.X;
                    switch (toggleSwitchButtonAlignment)
                    {
                        case ToggleSwitch.ToggleSwitchButtonAlignment.Center:
                            x2 = (float)rect.X + ((float)rect.Width - sizeF.Width) / 2f;
                            break;
                        case ToggleSwitch.ToggleSwitchButtonAlignment.Right:
                            x2 = (float)rect.X + (float)rect.Width - sizeF.Width;
                            break;
                    }
                    RectangleF layoutRectangle = new RectangleF(x2, (float)rect.Y + ((float)rect.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
                    using Brush brush2 = new SolidBrush(color3);
                    g.DrawString(text, font, brush2, layoutRectangle);
                }
            }
            g.ResetClip();
        }

        public Rectangle GetInnerControlRectangle()
        {
            return new Rectangle(1, 1, base.ToggleSwitch.Width - 2, base.ToggleSwitch.Height - 2);
        }

        public int GetCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
            {
                return 0;
            }
            double num = Math.Abs(SlantAngle);
            double a = num * (Math.PI / 180.0);
            double num2 = Math.Tan(a) * (double)base.ToggleSwitch.Height;
            return (int)num2;
        }

        public int GetHalfCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
            {
                return 0;
            }
            double num = Math.Abs(SlantAngle);
            double a = num * (Math.PI / 180.0);
            double num2 = Math.Tan(a) * (double)base.ToggleSwitch.Height / 2.0;
            return (int)num2;
        }

        public override int GetButtonWidth()
        {
            double num = (double)base.ToggleSwitch.Width / 2.0;
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
