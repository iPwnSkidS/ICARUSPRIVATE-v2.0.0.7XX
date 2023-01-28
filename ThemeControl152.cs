using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ShitarusPrivate
{
    internal abstract class ThemeControl152 : Control
    {
        protected Graphics G;

        protected Bitmap B;

        private bool InPosition;

        protected MouseState State;

        private bool _BackColorU;

        private bool _NoRounding;

        private Image _Image;

        private Size _ImageSize;

        private int _LockWidth;

        private int _LockHeight;

        private bool _Transparent;

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();

        private string _Customization;

        private Point CenterReturn;

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;

        private SolidBrush DrawCornersBrush;

        private Point DrawTextPoint;

        private Size DrawTextSize;

        private Point DrawImagePoint;

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;

        [Category("Misc")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                if (!base.IsHandleCreated && value == Color.Transparent)
                {
                    _BackColorU = true;
                    return;
                }
                base.BackColor = value;
                if (base.Parent != null)
                {
                    ColorHook();
                }
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get
            {
                return Color.Empty;
            }
            set
            {
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return ImageLayout.None;
            }
            set
            {
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        public bool NoRounding
        {
            get
            {
                return _NoRounding;
            }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

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

        protected int LockWidth
        {
            get
            {
                return _LockWidth;
            }
            set
            {
                _LockWidth = value;
                if (LockWidth != 0 && base.IsHandleCreated)
                {
                    base.Width = LockWidth;
                }
            }
        }

        protected int LockHeight
        {
            get
            {
                return _LockHeight;
            }
            set
            {
                _LockHeight = value;
                if (LockHeight != 0 && base.IsHandleCreated)
                {
                    base.Height = LockHeight;
                }
            }
        }

        public bool Transparent
        {
            get
            {
                return _Transparent;
            }
            set
            {
                _Transparent = value;
                if (base.IsHandleCreated)
                {
                    if (!value && BackColor.A != byte.MaxValue)
                    {
                        throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                    }
                    SetStyle(ControlStyles.Opaque, !value);
                    SetStyle(ControlStyles.SupportsTransparentBackColor, value);
                    if (value)
                    {
                        InvalidateBitmap();
                    }
                    else
                    {
                        B = null;
                    }
                    Invalidate();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> list = new List<Bloom>();
                Dictionary<string, Color>.Enumerator enumerator = Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(new Bloom(enumerator.Current.Key, enumerator.Current.Value));
                }
                return list.ToArray();
            }
            set
            {
                foreach (Bloom bloom in value)
                {
                    if (Items.ContainsKey(bloom.Name))
                    {
                        Items[bloom.Name] = bloom.Value;
                    }
                }
                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        public string Customization
        {
            get
            {
                return _Customization;
            }
            set
            {
                if (value == _Customization)
                {
                    return;
                }
                byte[] array = null;
                Bloom[] colors = Colors;
                try
                {
                    array = Convert.FromBase64String(value);
                    for (int i = 0; i <= colors.Length - 1; i++)
                    {
                        colors[i].Value = Color.FromArgb(BitConverter.ToInt32(array, i * 4));
                    }
                }
                catch
                {
                    return;
                }
                _Customization = value;
                Colors = colors;
                ColorHook();
                Invalidate();
            }
        }

        public ThemeControl152()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            _ImageSize = Size.Empty;
            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);
            Font = new Font("Verdana", 8f);
            InvalidateCustimization();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (_LockWidth != 0)
            {
                width = _LockWidth;
            }
            if (_LockHeight != 0)
            {
                height = _LockHeight;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected sealed override void OnSizeChanged(EventArgs e)
        {
            if (_Transparent && base.Width != 0 && base.Height != 0)
            {
                B = new Bitmap(base.Width, base.Height);
                G = Graphics.FromImage(B);
            }
            Invalidate();
            base.OnSizeChanged(e);
        }

        protected sealed override void OnPaint(PaintEventArgs e)
        {
            if (base.Width != 0 && base.Height != 0)
            {
                if (_Transparent)
                {
                    PaintHook();
                    e.Graphics.DrawImage(B, 0, 0);
                }
                else
                {
                    G = e.Graphics;
                    PaintHook();
                }
            }
        }

        protected sealed override void OnHandleCreated(EventArgs e)
        {
            InvalidateCustimization();
            ColorHook();
            if (_LockWidth != 0)
            {
                base.Width = _LockWidth;
            }
            if (_LockHeight != 0)
            {
                base.Height = _LockHeight;
            }
            Transparent = _Transparent;
            if (_BackColorU && _Transparent)
            {
                BackColor = Color.Transparent;
            }
            base.OnHandleCreated(e);
        }

        protected sealed override void OnParentChanged(EventArgs e)
        {
            if (base.Parent != null)
            {
                OnCreation();
            }
            base.OnParentChanged(e);
        }

        protected virtual void OnCreation()
        {
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            InPosition = true;
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (InPosition)
            {
                SetState(MouseState.Over);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SetState(MouseState.Down);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            InPosition = false;
            SetState(MouseState.None);
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (base.Enabled)
            {
                SetState(MouseState.None);
            }
            else
            {
                SetState(MouseState.Block);
            }
            base.OnEnabledChanged(e);
        }

        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        private void InvalidateBitmap()
        {
            if (base.Width != 0 && base.Height != 0)
            {
                B = new Bitmap(base.Width, base.Height);
                G = Graphics.FromImage(B);
            }
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color value)
        {
            if (Items.ContainsKey(name))
            {
                Items[name] = value;
            }
            else
            {
                Items.Add(name, value);
            }
        }

        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }

        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }

        protected void SetColor(string name, byte a, Color value)
        {
            SetColor(name, Color.FromArgb(a, value));
        }

        private void InvalidateCustimization()
        {
            MemoryStream memoryStream = new MemoryStream(Items.Count * 4);
            Bloom[] colors = Colors;
            foreach (Bloom bloom in colors)
            {
                memoryStream.Write(BitConverter.GetBytes(bloom.Value.ToArgb()), 0, 4);
            }
            memoryStream.Close();
            _Customization = Convert.ToBase64String(memoryStream.ToArray());
        }

        protected abstract void ColorHook();

        protected abstract void PaintHook();

        protected Point Center(Rectangle r1, Size s1)
        {
            CenterReturn = new Point(r1.Width / 2 - s1.Width / 2 + r1.X, r1.Height / 2 - s1.Height / 2 + r1.Y);
            return CenterReturn;
        }

        protected Point Center(Rectangle r1, Rectangle r2)
        {
            return Center(r1, r2.Size);
        }

        protected Point Center(int w1, int h1, int w2, int h2)
        {
            CenterReturn = new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2);
            return CenterReturn;
        }

        protected Point Center(Size s1, Size s2)
        {
            return Center(s1.Width, s1.Height, s2.Width, s2.Height);
        }

        protected Point Center(Rectangle r1)
        {
            return Center(base.ClientRectangle.Width, base.ClientRectangle.Height, r1.Width, r1.Height);
        }

        protected Point Center(Size s1)
        {
            return Center(base.Width, base.Height, s1.Width, s1.Height);
        }

        protected Point Center(int w1, int h1)
        {
            return Center(base.Width, base.Height, w1, h1);
        }

        protected Size Measure(string text)
        {
            return MeasureGraphics.MeasureString(text, Font, base.Width).ToSize();
        }

        protected Size Measure()
        {
            return MeasureGraphics.MeasureString(Text, Font, base.Width).ToSize();
        }

        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, base.Width, base.Height);
        }

        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }

        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (!_NoRounding)
            {
                if (_Transparent)
                {
                    B.SetPixel(x, y, c1);
                    B.SetPixel(x + (width - 1), y, c1);
                    B.SetPixel(x, y + (height - 1), c1);
                    B.SetPixel(x + (width - 1), y + (height - 1), c1);
                }
                else
                {
                    DrawCornersBrush = new SolidBrush(c1);
                    G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                    G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                    G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                    G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
                }
            }
        }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - offset * 2, height - offset * 2);
        }

        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
        }

        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, base.Width, base.Height);
        }

        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }

        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }

        protected void DrawText(Brush b1, Point p1)
        {
            DrawText(b1, Text, p1.X, p1.Y);
        }

        protected void DrawText(Brush b1, int x, int y)
        {
            DrawText(b1, Text, x, y);
        }

        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length != 0)
            {
                DrawTextSize = Measure(text);
                DrawTextPoint = Center(DrawTextSize);
                switch (a)
                {
                    case HorizontalAlignment.Left:
                        DrawText(b1, text, x, DrawTextPoint.Y + y);
                        break;
                    case HorizontalAlignment.Right:
                        DrawText(b1, text, base.Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                        break;
                    case HorizontalAlignment.Center:
                        DrawText(b1, text, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                        break;
                }
            }
        }

        protected void DrawText(Brush b1, string text, Point p1)
        {
            DrawText(b1, text, p1.X, p1.Y);
        }

        protected void DrawText(Brush b1, string text, int x, int y)
        {
            if (text.Length != 0)
            {
                G.DrawString(text, Font, b1, x, y);
            }
        }

        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }

        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }

        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image != null)
            {
                DrawImagePoint = Center(image.Size);
                switch (a)
                {
                    case HorizontalAlignment.Left:
                        DrawImage(image, x, DrawImagePoint.Y + y);
                        break;
                    case HorizontalAlignment.Right:
                        DrawImage(image, base.Width - image.Width - x, DrawImagePoint.Y + y);
                        break;
                    case HorizontalAlignment.Center:
                        DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y);
                        break;
                }
            }
        }

        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }

        protected void DrawImage(Image image, int x, int y)
        {
            if (image != null)
            {
                G.DrawImage(image, x, y, image.Width, image.Height);
            }
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradient(blend, x, y, width, height, 90f);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradient(c1, c2, x, y, width, height, 90f);
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }
    }
}