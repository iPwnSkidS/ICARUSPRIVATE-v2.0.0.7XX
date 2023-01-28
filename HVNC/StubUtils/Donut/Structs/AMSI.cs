using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AMSI
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] s;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] w;
    }
}
