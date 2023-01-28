using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceButton1 : Control
    {
        private int MouseState;

        private GraphicsPath Shape;

        private LinearGradientBrush InactiveGB;

        private LinearGradientBrush PressedGB;

        private LinearGradientBrush PressedContourGB;

        private Rectangle R1;

        private Pen P1;

        private Pen P3;

        private Image _Image;

        private Size _ImageSize;

        private StringAlignment _TextAlignment = StringAlignment.Center;

        private Color _TextColor = Color.FromArgb(150, 150, 150);

        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }
                _Image = value;
                Invalidate();
            }
        }

        protected Size ImageSize => _ImageSize;

        public ContentAlignment ImageAlign
        {
            get
            {
                return _ImageAlign;
            }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        public StringAlignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
                Invalidate();
            }
        }

        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF result = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Near:
                    result.X = 2f;
                    break;
                case StringAlignment.Center:
                    result.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2f);
                    break;
                case StringAlignment.Far:
                    result.X = Area.Width - ImageArea.Width - 2f;
                    break;
            }
            switch (SF.LineAlignment)
            {
                case StringAlignment.Near:
                    result.Y = 2f;
                    break;
                case StringAlignment.Center:
                    result.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2f);
                    break;
                case StringAlignment.Far:
                    result.Y = Area.Height - ImageArea.Height - 2f;
                    break;
            }
            return result;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat stringFormat = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopLeft:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomLeft:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;
            }
            return stringFormat;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            Focus();
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        public AmbianceButton1()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12f);
            ForeColor = Color.FromArgb(76, 76, 76);
            base.Size = new Size(177, 30);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(Color.FromArgb(180, 180, 180));
        }

        protected override void OnResize(EventArgs e)
        {
            if (base.Width > 0 && base.Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, base.Width, base.Height);
                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90f);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(226, 226, 226), Color.FromArgb(237, 237, 237), 90f);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90f);
                P3 = new Pen(PressedContourGB);
            }
            GraphicsPath shape = Shape;
            shape.AddArc(0, 0, 10, 10, 180f, 90f);
            shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
            shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
            shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
            shape.CloseAllFigures();
            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            PointF pointF = ImageLocation(GetStringFormat(ImageAlign), base.Size, ImageSize);
            switch (MouseState)
            {
                case 1:
                    graphics.FillPath(PressedGB, Shape);
                    graphics.DrawPath(P3, Shape);
                    if (Image == null)
                    {
                        graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        graphics.DrawImage(_Image, pointF.X, pointF.Y, ImageSize.Width, ImageSize.Height);
                        graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 0:
                    graphics.FillPath(InactiveGB, Shape);
                    graphics.DrawPath(P1, Shape);
                    if (Image == null)
                    {
                        graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        graphics.DrawImage(_Image, pointF.X, pointF.Y, ImageSize.Width, ImageSize.Height);
                        graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }
            base.OnPaint(e);
        }
    }
}
