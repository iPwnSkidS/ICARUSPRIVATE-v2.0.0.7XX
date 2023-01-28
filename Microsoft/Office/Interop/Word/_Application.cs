using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.Microsoft.Office.Interop.Word
{
    [ComImport]
    [CompilerGenerated]
    [DefaultMember("Name")]
    [Guid("00020970-0000-0000-C000-000000000046")]
    [TypeIdentifier]
    public interface _Application
    {
        void _VtblGap1_3();

        [DispId(0)]
        string Name
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(0)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        [DispId(6)]
        Documents Documents
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(6)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        void _VtblGap2_1();

        [DispId(3)]
        Document ActiveDocument
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(3)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        void _VtblGap3_19();

        [DispId(23)]
        bool Visible
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(23)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(23)]
            [param: In]
            set;
        }

        [DispId(24)]
        string Version
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(24)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        void _VtblGap4_61();

        [DispId(94)]
        WdAlertLevel DisplayAlerts
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(94)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(94)]
            [param: In]
            set;
        }

        void _VtblGap5_21();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(1105)]
        void Quit([Optional][In][MarshalAs(UnmanagedType.Struct)] ref object SaveChanges, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object OriginalFormat, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object RouteDocument);
    }
}
