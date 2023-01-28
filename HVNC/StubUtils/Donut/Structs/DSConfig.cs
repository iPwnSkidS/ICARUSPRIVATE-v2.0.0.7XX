using System;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    public struct DSConfig
    {
        public int arch;

        public int bypass;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] domain;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] cls;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] method;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2304)]
        public char[] param;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] file;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] url;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] runtime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] modname;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] outfile;

        public int mod_type;

        public ulong mod_len;

        public DSModule mod;

        public int inst_type;

        public ulong inst_len;

        public DSInstance inst;

        public int pic_cnt;

        public ulong pic_len;

        public IntPtr pic;
    }
}
