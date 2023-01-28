using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    [DefaultEvent("CheckedChanged")]
    public class AmbianceRadioButton : Control
    {
        public enum MouseState : byte
        {
            None,
            Over,
            Down,
            Block
        }

        public delegate void CheckedChangedEventHandler(object sender);

        private bool _Checked;

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (this.CheckedChanged != null)
                {
                    this.CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 15;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnMouseDown(e);
            Focus();
        }

        public AmbianceRadioButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12f);
            base.Width = 193;
        }

        private void InvalidateControls()
        {
            if (!base.IsHandleCreated || !_Checked)
            {
                return;
            }
            foreach (Control control in base.Parent.Controls)
            {
                if (control != this && control is AmbianceRadioButton)
                {
                    ((AmbianceRadioButton)control).Checked = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.Clear(base.Parent.BackColor);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), Color.FromArgb(213, 85, 32), Color.FromArgb(224, 123, 82), 90f);
            graphics.FillEllipse(brush, new Rectangle(new Point(0, 0), new Size(14, 14)));
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(new Rectangle(0, 0, 14, 14));
            graphics.SetClip(graphicsPath);
            graphics.ResetClip();
            graphics.DrawEllipse(new Pen(Color.FromArgb(182, 88, 55)), new Rectangle(new Point(0, 0), new Size(14, 14)));
            if (_Checked)
            {
                SolidBrush brush2 = new SolidBrush(Color.FromArgb(255, 255, 255));
                graphics.FillEllipse(brush2, new Rectangle(new Point(4, 4), new Size(6, 6)));
            }
            graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 95)), 16f, 7f, new StringFormat
            {
                LineAlignment = StringAlignment.Center
            });
            e.Dispose();
        }
    }
}
