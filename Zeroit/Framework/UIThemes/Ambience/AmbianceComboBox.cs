using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceComboBox : ComboBox
    {
        private int _StartIndex;

        private Color _HoverSelectionColor;

        public int StartIndex
        {
            get
            {
                return _StartIndex;
            }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public Color HoverSelectionColor
        {
            get
            {
                return _HoverSelectionColor;
            }
            set
            {
                _HoverSelectionColor = value;
                Invalidate();
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90f);
            if (Convert.ToInt32(e.State & DrawItemState.Selected) == 1)
            {
                if (e.Index != -1)
                {
                    e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
                    e.Graphics.DrawString(GetItemText(base.Items[e.Index]), e.Font, Brushes.WhiteSmoke, e.Bounds);
                }
            }
            else if (e.Index != -1)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(242, 241, 240)), e.Bounds);
                e.Graphics.DrawString(GetItemText(base.Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
            }
            linearGradientBrush.Dispose();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SuspendLayout();
            Update();
            ResumeLayout();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!Focused)
            {
                base.SelectionLength = 0;
            }
        }

        public AmbianceComboBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            SetStyle(ControlStyles.Selectable, value: false);
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            BackColor = Color.FromArgb(246, 246, 246);
            ForeColor = Color.FromArgb(142, 142, 142);
            base.Size = new Size(135, 26);
            base.ItemHeight = 20;
            base.DropDownHeight = 100;
            Font = new Font("Segoe UI", 10f, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            LinearGradientBrush linearGradientBrush = null;
            GraphicsPath graphicsPath = null;
            e.Graphics.Clear(base.Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphicsPath = RoundRectangle.RoundRect(0, 0, base.Width - 1, base.Height - 1, 5);
            linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(253, 252, 252), Color.FromArgb(239, 237, 236), 90f);
            e.Graphics.SetClip(graphicsPath);
            e.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
            e.Graphics.ResetClip();
            e.Graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), graphicsPath);
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.FromArgb(76, 76, 97)), new Rectangle(3, 0, base.Width - 20, base.Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });
            e.Graphics.DrawString("6", new Font("Marlett", 13f, FontStyle.Regular), new SolidBrush(Color.FromArgb(119, 119, 118)), new Rectangle(3, 0, base.Width - 4, base.Height), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Far
            });
            e.Graphics.DrawLine(new Pen(Color.FromArgb(224, 222, 220)), base.Width - 24, 4, base.Width - 24, base.Height - 5);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(250, 249, 249)), base.Width - 25, 4, base.Width - 25, base.Height - 5);
            graphicsPath.Dispose();
            linearGradientBrush.Dispose();
        }
    }
}
