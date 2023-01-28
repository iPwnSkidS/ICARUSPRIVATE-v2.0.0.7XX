using System;
using System.ComponentModel;
using System.Windows.Forms;
using ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience;

namespace ShitarusPrivate.HVNC
{
    public class HelpFTPPHP : Form
    {
        private IContainer components;

        private PrimeTheme primeTheme1;

        private StudioButton studioButton5;

        private AmbianceLabel ambianceLabel2;

        private AmbianceLabel ambianceLabel1;

        private Label label2;

        private Label label1;

        private Label label3;

        private PictureBox pictureBox1;

        public HelpFTPPHP()
        {
            InitializeComponent();
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
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
            Bloom bloom11 = new Bloom();
            Bloom bloom12 = new Bloom();
            Bloom bloom13 = new Bloom();
            Bloom bloom14 = new Bloom();
            Bloom bloom15 = new Bloom();
            Bloom bloom16 = new Bloom();
            Bloom bloom17 = new Bloom();
            Bloom bloom18 = new Bloom();
            Bloom bloom19 = new Bloom();
            Bloom bloom20 = new Bloom();
            Bloom bloom21 = new Bloom();
            Bloom bloom22 = new Bloom();
            Bloom bloom23 = new Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.HelpFTPPHP));
            this.primeTheme1 = new PrimeTheme();
            this.studioButton5 = new StudioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ambianceLabel1 = new Zeroit.Framework.UIThemes.Ambience.AmbianceLabel();
            this.ambianceLabel2 = new Zeroit.Framework.UIThemes.Ambience.AmbianceLabel();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            base.SuspendLayout();
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
            this.primeTheme1.Controls.Add(this.ambianceLabel2);
            this.primeTheme1.Controls.Add(this.ambianceLabel1);
            this.primeTheme1.Controls.Add(this.label2);
            this.primeTheme1.Controls.Add(this.label1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.MaximumSize = new System.Drawing.Size(800, 450);
            this.primeTheme1.MinimumSize = new System.Drawing.Size(800, 450);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(800, 450);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 0;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom11.Name = "DownGradient1";
            bloom11.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom12.Name = "DownGradient2";
            bloom12.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom13.Name = "NoneGradient1";
            bloom13.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom14.Name = "NoneGradient2";
            bloom14.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom15.Name = "Shine1";
            bloom15.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom16.Name = "Shine2A";
            bloom16.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom17.Name = "Shine2B";
            bloom17.Value = System.Drawing.Color.Transparent;
            bloom18.Name = "Shine3";
            bloom18.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom19.Name = "TextShade";
            bloom19.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom20.Name = "Text";
            bloom20.Value = System.Drawing.Color.White;
            bloom21.Name = "Glow";
            bloom21.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom22.Name = "Border";
            bloom22.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom23.Name = "Corners";
            bloom23.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[13]
            {
                bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
                bloom21, bloom22, bloom23
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(774, -7);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 52;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "PHP/FTP Help";
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 52);
            this.label1.TabIndex = 56;
            this.label1.Text = "1. Create a free hosting account\r\n2. Get you host/domain,ftp username \r\nand password\r\n3. Paste on your Icarus Stealer";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 39);
            this.label2.TabIndex = 57;
            this.label2.Text = "1. Generate your uploader\r\n2. Upload your uploader.php to your hosting\r\n3. Copy the link and paste it to your Icarus stealer";
            this.ambianceLabel1.AutoSize = true;
            this.ambianceLabel1.BackColor = System.Drawing.Color.Transparent;
            this.ambianceLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.ambianceLabel1.ForeColor = System.Drawing.Color.FromArgb(76, 76, 77);
            this.ambianceLabel1.Location = new System.Drawing.Point(186, 178);
            this.ambianceLabel1.Name = "ambianceLabel1";
            this.ambianceLabel1.Size = new System.Drawing.Size(71, 20);
            this.ambianceLabel1.TabIndex = 58;
            this.ambianceLabel1.Text = "FTP Help";
            this.ambianceLabel2.AutoSize = true;
            this.ambianceLabel2.BackColor = System.Drawing.Color.Transparent;
            this.ambianceLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.ambianceLabel2.ForeColor = System.Drawing.Color.FromArgb(76, 76, 77);
            this.ambianceLabel2.Location = new System.Drawing.Point(500, 178);
            this.ambianceLabel2.Name = "ambianceLabel2";
            this.ambianceLabel2.Size = new System.Drawing.Size(74, 20);
            this.ambianceLabel2.TabIndex = 59;
            this.ambianceLabel2.Text = "PHP Help";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(800, 450);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            base.Name = "HelpFTPPHP";
            this.Text = "Help FTP/PHP";
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            base.ResumeLayout(false);
        }
    }
}
