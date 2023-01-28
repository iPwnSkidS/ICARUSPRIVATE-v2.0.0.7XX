using System;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace ShitarusPrivate.Icarus
{
    [StandardModule]
    internal sealed class Helper
    {
        public static byte[] SB(string s)
        {
            return Encoding.Default.GetBytes(s);
        }

        public static string BS(byte[] b)
        {
            return Encoding.Default.GetString(b);
        }

        public static string BytesToString(long byteCount)
        {
            string[] array = new string[7] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0L)
            {
                return "0" + array[0];
            }
            long num = Math.Abs(byteCount);
            _ = (double)num;
            int num2 = Convert.ToInt32(Math.Floor(6.931471805599453));
            double num3 = Math.Round((double)num / Math.Pow(1024.0, num2), 1);
            return (double)Math.Sign(byteCount) * num3 + array[num2];
        }
    }
}
