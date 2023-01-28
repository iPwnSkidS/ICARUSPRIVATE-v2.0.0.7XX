using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct API
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public ulong[] hash;

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public unsafe void*[] addr;
    }
}
