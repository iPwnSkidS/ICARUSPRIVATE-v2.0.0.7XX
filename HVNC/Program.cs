using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ShitarusPrivate.HVNC
{
    internal static class Program
    {
        private static Mutex m;

        [STAThread]
        private static void Main()
        {
            m = new Mutex(initiallyOwned: true, "ICARUS", out var createdNew);
            if (!createdNew)
            {
                MessageBox.Show("Close ICARUS because another instance is already running.");
                return;
            }
            _ = (int)Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", 96);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(new Manager());
            GC.KeepAlive(m);
        }
    }
}
