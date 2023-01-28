using System.IO;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class Logging
    {
        private static readonly string Logfile = Path.Combine(Path.GetTempPath(), "Icarus-Latest.log");

        public static bool Log(bool ret = true)
        {
            return ret;
        }

        public static void Save(string sSavePath)
        {
            if (!(Config.DebugMode != "1") && File.Exists(Logfile))
            {
                try
                {
                    File.Copy(Logfile, sSavePath);
                }
                catch
                {
                }
            }
        }
    }
}
