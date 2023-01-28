using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience
{
    public class AmbianceListBox : ListBox
    {
        public AmbianceListBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, value: true);
            DrawMode = DrawMode.OwnerDrawFixed;
            base.IntegralHeight = false;
            ItemHeight = 18;
            Font = new Font("Seoge UI", 11f, FontStyle.Regular);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.Bounds, Color.FromArgb(246, 132, 85), Color.FromArgb(231, 108, 57), 90f);
            if (Convert.ToInt32(e.State & DrawItemState.Selected) == 1)
            {
                e.Graphics.FillRectangle(linearGradientBrush, e.Bounds);
            }
            using (SolidBrush brush = new SolidBrush(e.ForeColor))
            {
                if (base.Items.Count == 0)
                {
                    return;
                }
                e.Graphics.DrawString(GetItemText(base.Items[e.Index]), e.Font, brush, e.Bounds);
            }
            linearGradientBrush.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Region region = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(BackColor), region);
            if (base.Items.Count <= 0)
            {
                return;
            }
            for (int i = 0; i <= base.Items.Count - 1; i++)
            {
                Rectangle itemRectangle = GetItemRectangle(i);
                if (e.ClipRectangle.IntersectsWith(itemRectangle))
                {
                    if ((SelectionMode == SelectionMode.One && SelectedIndex == i) || (SelectionMode == SelectionMode.MultiSimple && base.SelectedIndices.Contains(i)) || (SelectionMode == SelectionMode.MultiExtended && base.SelectedIndices.Contains(i)))
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, Font, itemRectangle, i, DrawItemState.Selected, ForeColor, BackColor));
                    }
                    else
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, Font, itemRectangle, i, DrawItemState.Default, Color.FromArgb(60, 60, 60), BackColor));
                    }
                    region.Complement(itemRectangle);
                }
            }
        }
    }
}
