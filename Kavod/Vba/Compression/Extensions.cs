using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShitarusPrivate.Kavod.Vba.Compression
{
    internal static class Extensions
    {
        [Serializable]
        [CompilerGenerated]
        private sealed class __c
        {
            public static readonly __c __9 = new __c();

            public static Func<int, bool> __9__1_0;

            internal bool _StringToByteArray_b__1_0(int x)
            {
                return x % 2 == 0;
            }
        }

        [CompilerGenerated]
        private sealed class __c__DisplayClass1_0
        {
            public string hex;

            internal byte _StringToByteArray_b__1(int x)
            {
                return Convert.ToByte(hex.Substring(x, 2), 16);
            }
        }

        [DebuggerStepThrough]
        internal static byte[] ToMcbsBytes(this string textToConvert, ushort codePage)
        {
            return Encoding.GetEncoding(codePage).GetBytes(textToConvert);
        }

        internal static byte[] StringToByteArray(string hex)
        {
            __c__DisplayClass1_0 _c__DisplayClass1_ = new __c__DisplayClass1_0();
            _c__DisplayClass1_.hex = hex;
            return Enumerable.Range(0, _c__DisplayClass1_.hex.Length).Where(__c.__9__1_0 ?? (__c.__9__1_0 = __c.__9._StringToByteArray_b__1_0)).Select(_c__DisplayClass1_._StringToByteArray_b__1)
                .ToArray();
        }
    }
}
