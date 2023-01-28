using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    public struct P
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] param;
    }
}
