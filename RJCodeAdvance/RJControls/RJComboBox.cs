using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.RJCodeAdvance.RJControls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class RJComboBox : UserControl
    {
        private Color backColor = Color.WhiteSmoke;

        private Color iconColor = Color.MediumSlateBlue;

        private Color listBackColor = Color.FromArgb(230, 228, 245);

        private Color listTextColor = Color.DimGray;

        private Color borderColor = Color.MediumSlateBlue;

        private int borderSize = 1;

        private ComboBox cmbList;

        private Label lblText;

        private Button btnIcon;

        [Category("RJ Code - Appearance")]
        public new Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("RJ Code - Appearance")]
        public Color IconColor
        {
            get
            {
                return iconColor;
            }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }

        [Category("RJ Code - Appearance")]
        public Color ListBackColor
        {
            get
            {
                return listBackColor;
            }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("RJ Code - Appearance")]
        public Color ListTextColor
        {
            get
            {
                return listTextColor;
            }
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("RJ Code - Appearance")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }

        [Category("RJ Code - Appearance")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                base.Padding = new Padding(borderSize);
                AdjustComboBoxDimensions();
            }
        }

        [Category("RJ Code - Appearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        [Category("RJ Code - Appearance")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
            }
        }

        [Category("RJ Code - Appearance")]
        public string Texts
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        [Category("RJ Code - Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return cmbList.DropDownStyle;
            }
            set
            {
                if (cmbList.DropDownStyle != 0)
                {
                    cmbList.DropDownStyle = value;
                }
            }
        }

        [Category("RJ Code - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items => cmbList.Items;

        [Category("RJ Code - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get
            {
                return cmbList.DataSource;
            }
            set
            {
                cmbList.DataSource = value;
            }
        }

        [Category("RJ Code - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmbList.AutoCompleteCustomSource;
            }
            set
            {
                cmbList.AutoCompleteCustomSource = value;
            }
        }

        [Category("RJ Code - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmbList.AutoCompleteSource;
            }
            set
            {
                cmbList.AutoCompleteSource = value;
            }
        }

        [Category("RJ Code - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmbList.AutoCompleteMode;
            }
            set
            {
                cmbList.AutoCompleteMode = value;
            }
        }

        [Category("RJ Code - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                return cmbList.SelectedItem;
            }
            set
            {
                cmbList.SelectedItem = value;
            }
        }

        [Category("RJ Code - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return cmbList.SelectedIndex;
            }
            set
            {
                cmbList.SelectedIndex = value;
            }
        }

        [Category("RJ Code - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get
            {
                return cmbList.DisplayMember;
            }
            set
            {
                cmbList.DisplayMember = value;
            }
        }

        [Category("RJ Code - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get
            {
                return cmbList.ValueMember;
            }
            set
            {
                cmbList.ValueMember = value;
            }
        }

        public event EventHandler OnSelectedIndexChanged;

        public RJComboBox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            SuspendLayout();
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(Font.Name, 10f);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbList.TextChanged += ComboBox_TextChanged;
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += Icon_Click;
            btnIcon.Paint += Icon_Paint;
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(Font.Name, 10f);
            lblText.Click += Surface_Click;
            lblText.MouseEnter += Surface_MouseEnter;
            lblText.MouseLeave += Surface_MouseLeave;
            base.Controls.Add(lblText);
            base.Controls.Add(btnIcon);
            base.Controls.Add(cmbList);
            MinimumSize = new Size(200, 30);
            base.Size = new Size(200, 30);
            ForeColor = Color.DimGray;
            base.Padding = new Padding(borderSize);
            Font = new Font(Font.Name, 10f);
            base.BackColor = borderColor;
            ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point
            {
                X = base.Width - base.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OnSelectedIndexChanged != null)
            {
                this.OnSelectedIndexChanged(sender, e);
            }
            lblText.Text = cmbList.Text;
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int num = 14;
            Rectangle rectangle = new Rectangle((btnIcon.Width - 14) / 2, (btnIcon.Height - 6) / 2, 14, 6);
            Graphics graphics = e.Graphics;
            using GraphicsPath graphicsPath = new GraphicsPath();
            using Pen pen = new Pen(iconColor, 2f);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphicsPath.AddLine(rectangle.X, rectangle.Y, rectangle.X + num / 2, rectangle.Bottom);
            graphicsPath.AddLine(rectangle.X + num / 2, rectangle.Bottom, rectangle.Right, rectangle.Y);
            graphics.DrawPath(pen, graphicsPath);
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            OnClick(e);
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbList.DroppedDown = true;
            }
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
