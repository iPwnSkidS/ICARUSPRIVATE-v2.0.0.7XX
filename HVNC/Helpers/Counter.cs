using System.Collections.Generic;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class Counter
    {
        public static int SavedWifiNetworks;

        public static bool ProductKey;

        public static bool DesktopScreenshot;

        public static bool WebcamScreenshot;

        public static int GrabberImages;

        public static int GrabberDocuments;

        public static int GrabberDatabases;

        public static int GrabberSourceCodes;

        public static string GetSValue(string application, bool value)
        {
            if (!value)
            {
                return "";
            }
            return "\n   ∟ " + application;
        }

        public static string GetIValue(string application, int value)
        {
            if (value == 0)
            {
                return "";
            }
            return "\n   ∟ " + application + ": " + value;
        }

        public static string GetLValue(string application, List<string> value, char separator = '∟')
        {
            value.Sort();
            if (value.Count == 0)
            {
                return "\n   " + separator + " " + application + " (No data)";
            }
            return "\n   " + separator + " " + application + ":\n\t\t" + separator + " " + string.Join("\n\t\t" + separator + " ", value);
        }

        public static string GetBValue(bool value, string success, string failed)
        {
            if (!value)
            {
                return "\n   ∟ " + failed;
            }
            return "\n   ∟ " + success;
        }
    }
}
