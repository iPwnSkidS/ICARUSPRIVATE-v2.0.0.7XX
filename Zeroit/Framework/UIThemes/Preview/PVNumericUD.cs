using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShitarusPrivate.Zeroit.Framework.UIThemes.Preview
{
    public class PVNumericUD : ThemedControl
    {
        private PVTextbox TxtBox = new PVTextbox();

        private PVButton BtnUp = new PVButton();

        private PVButton BtnDown = new PVButton();

        private int _ButtonChange = 1;

        private int _Minimum = 1;

        private int _Maximum = 100;

        private bool EventsSubscribed;

        public int ButtonChange
        {
            get
            {
                return _ButtonChange;
            }
            set
            {
                _ButtonChange = value;
            }
        }

        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
            }
        }

        public int Value
        {
            get
            {
                int num = 0;
                return Convert.ToInt32(TxtBox.Text);
            }
            set
            {
                if (value <= Maximum && value >= Minimum)
                {
                    TxtBox.Text = value.ToString();
                    Invalidate();
                }
            }
        }

        protected void BtnUp_Down(object sender, EventArgs e)
        {
            Value += ButtonChange;
        }

        protected void BtnDown_Down(object sender, EventArgs e)
        {
            Value -= ButtonChange;
        }

        public PVNumericUD()
        {
            base.Size = new Size(300, 300);
            Font = new Font("Trebuchet MS", 10f);
            TxtBox.Text = 0.ToString();
            base.Controls.Add(TxtBox);
            base.Controls.Add(BtnUp);
            base.Controls.Add(BtnDown);
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            base.OnPaint(e);
            graphics.Clear(base.Parent.BackColor);
            base.Height = 30;
            BtnUp.MinimumSize = new Size(15, 15);
            BtnUp.Size = new Size(10, 10);
            BtnUp.Location = new Point(base.Size.Width - BtnUp.Width, 0);
            BtnUp.Font = new Font("Trebuchet MS", 10f);
            BtnUp.Text = "ᴧ";
            BtnDown.MinimumSize = new Size(15, 15);
            BtnDown.Size = new Size(10, 10);
            BtnDown.Location = new Point(base.Size.Width - BtnUp.Width, BtnUp.Size.Height);
            BtnDown.Font = new Font("Trebuchet MS", 10f, FontStyle.Bold);
            BtnDown.Text = "v";
            TxtBox.Location = new Point(0, 0);
            TxtBox.Multiline = true;
            TxtBox.Height = 30;
            TxtBox.Width = BtnUp.Location.X - 2;
        }

        private void SubscribeToEvents()
        {
            if (!EventsSubscribed)
            {
                EventsSubscribed = true;
                BtnUp.MouseDown += BtnUp_Down;
                BtnDown.MouseDown += BtnDown_Down;
            }
        }
    }
}
