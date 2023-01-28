using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.Microsoft.Office.Interop.Word
{
    [ComImport]
    [CompilerGenerated]
    [DefaultMember("Item")]
    [Guid("0002096C-0000-0000-C000-000000000046")]
    [TypeIdentifier]
    public interface Documents : IEnumerable
    {
        void _VtblGap1_10();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(14)]
        [return: MarshalAs(UnmanagedType.Interface)]
        Document Add([Optional][In][MarshalAs(UnmanagedType.Struct)] ref object Template, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object NewTemplate, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object DocumentType, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object Visible);
    }
}
