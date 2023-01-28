using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class Report
    {
        public static bool CreateReport(string sSavePath)
        {
            List<Thread> list = new List<Thread>();
            try
            {
                Directory.CreateDirectory(sSavePath + "\\System");
                foreach (Thread item in list)
                {
                    item.Start();
                }
                foreach (Thread item2 in list)
                {
                    item2.Join();
                }
                return Logging.Log();
            }
            catch (Exception)
            {
                return Logging.Log(ret: false);
            }
        }
    }
}
