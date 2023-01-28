using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    public struct DSCrypt
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] mk;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] ctr;
    }
}
