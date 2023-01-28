using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.JCS
{
    public abstract class ToggleSwitchRendererBase
    {
        private ToggleSwitch _toggleSwitch;

        internal ToggleSwitch ToggleSwitch => _toggleSwitch;

        internal void SetToggleSwitch(ToggleSwitch toggleSwitch)
        {
            _toggleSwitch = toggleSwitch;
        }

        public void RenderBackground(PaintEventArgs e)
        {
            if (_toggleSwitch != null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rectangle = new Rectangle(0, 0, _toggleSwitch.Width, _toggleSwitch.Height);
                FillBackground(e.Graphics, rectangle);
                RenderBorder(e.Graphics, rectangle);
            }
        }

        public void RenderControl(PaintEventArgs e)
        {
            if (_toggleSwitch == null)
            {
                return;
            }
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle buttonRectangle = GetButtonRectangle();
            int totalToggleFieldWidth = ToggleSwitch.Width - buttonRectangle.Width;
            if (buttonRectangle.X > 0)
            {
                Rectangle leftRectangle = new Rectangle(0, 0, buttonRectangle.X, ToggleSwitch.Height);
                if (leftRectangle.Width > 0)
                {
                    RenderLeftToggleField(e.Graphics, leftRectangle, totalToggleFieldWidth);
                }
            }
            if (buttonRectangle.X + buttonRectangle.Width < e.ClipRectangle.Width)
            {
                Rectangle rightRectangle = new Rectangle(buttonRectangle.X + buttonRectangle.Width, 0, ToggleSwitch.Width - buttonRectangle.X - buttonRectangle.Width, ToggleSwitch.Height);
                if (rightRectangle.Width > 0)
                {
                    RenderRightToggleField(e.Graphics, rightRectangle, totalToggleFieldWidth);
                }
            }
            RenderButton(e.Graphics, buttonRectangle);
        }

        public void FillBackground(Graphics g, Rectangle controlRectangle)
        {
            Color color = ((ToggleSwitch.Enabled || !ToggleSwitch.GrayWhenDisabled) ? ToggleSwitch.BackColor : ToggleSwitch.BackColor.ToGrayScale());
            using Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, controlRectangle);
        }

        public abstract void RenderBorder(Graphics g, Rectangle borderRectangle);

        public abstract void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth);

        public abstract void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth);

        public abstract void RenderButton(Graphics g, Rectangle buttonRectangle);

        public abstract int GetButtonWidth();

        public abstract Rectangle GetButtonRectangle();

        public abstract Rectangle GetButtonRectangle(int buttonWidth);
    }
}
