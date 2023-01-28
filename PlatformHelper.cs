using System;
using System.Management;
using System.Text.RegularExpressions;

namespace ShitarusPrivate
{
    public static class PlatformHelper
    {
        public static string FullName { get; }

        public static string Name { get; }

        public static bool Is64Bit { get; }

        public static bool RunningOnMono { get; }

        public static bool Win32NT { get; }

        public static bool XpOrHigher { get; }

        public static bool VistaOrHigher { get; }

        public static bool SevenOrHigher { get; }

        public static bool EightOrHigher { get; }

        public static bool EightPointOneOrHigher { get; }

        public static bool TenOrHigher { get; }

        static PlatformHelper()
        {
            Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
            XpOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 5;
            VistaOrHigher = Win32NT && Environment.OSVersion.Version.Major >= 6;
           SevenOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 1);
            EightOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 2, 9200);
           EightPointOneOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(6, 3);
            TenOrHigher = Win32NT && Environment.OSVersion.Version >= new Version(10, 0);
            RunningOnMono = Type.GetType("Mono.Runtime") != null;
            Name = "Unknown OS";
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
            {
                using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
                if (managementObjectEnumerator.MoveNext())
                {
                    ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
                    Name = managementObject["Caption"].ToString();
                }
            }
            Name = Regex.Replace(Name, "^.*(?=Windows)", "").TrimEnd().TrimStart();
            Is64Bit = Environment.Is64BitOperatingSystem;
            FullName = $"{Name} {(Is64Bit ? 64 : 32)} Bit";
        }
    }
}