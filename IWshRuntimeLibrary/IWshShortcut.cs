using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.IWshRuntimeLibrary
{
    [ComImport]
    [CompilerGenerated]
    [DefaultMember("FullName")]
    [Guid("F935DC23-1CF0-11D0-ADB9-00C04FD58A0B")]
    [TypeIdentifier]
    public interface IWshShortcut
    {
        [DispId(0)]
        string FullName
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(0)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        [DispId(1000)]
        string Arguments
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1000)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1000)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(1001)]
        string Description
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1001)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1001)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(1002)]
        string Hotkey
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1002)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1002)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(1003)]
        string IconLocation
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1003)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        void _VtblGap1_1();

        [DispId(1005)]
        string TargetPath
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1005)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1005)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }

        [DispId(1006)]
        int WindowStyle
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1006)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(1006)]
            [param: In]
            set;
        }

        void _VtblGap2_3();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(2001)]
        void Save();
    }
}
