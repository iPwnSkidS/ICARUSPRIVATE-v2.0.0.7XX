using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.Microsoft.Office.Interop.Word
{
    [ComImport]
    [CompilerGenerated]
    [DefaultMember("Item")]
    [Guid("000209A9-0000-0000-C000-000000000046")]
    [TypeIdentifier]
    public interface InlineShapes : IEnumerable
    {
        void _VtblGap1_6();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [DispId(100)]
        [return: MarshalAs(UnmanagedType.Interface)]
        InlineShape AddPicture([In][MarshalAs(UnmanagedType.BStr)] string FileName, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object LinkToFile, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object SaveWithDocument, [Optional][In][MarshalAs(UnmanagedType.Struct)] ref object Range);
    }
}
