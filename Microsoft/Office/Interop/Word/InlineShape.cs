using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShitarusPrivate.Microsoft.Office.Interop.Word
{
    [ComImport]
    [CompilerGenerated]
    [Guid("000209A8-0000-0000-C000-000000000046")]
    [TypeIdentifier]
    public interface InlineShape
    {
        void _VtblGap1_35();

        [DispId(131)]
        string AlternativeText
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(131)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            [DispId(131)]
            [param: In]
            [param: MarshalAs(UnmanagedType.BStr)]
            set;
        }
    }
}
