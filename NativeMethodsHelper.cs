using System;

namespace ShitarusPrivate
{
    public static class NativeMethodsHelper
    {
        private const int LVM_FIRST = 4096;

        private const int LVM_SETITEMSTATE = 4139;

        private const int WM_VSCROLL = 277;

        private static readonly IntPtr SB_PAGEBOTTOM = new IntPtr(7);

        public static int MakeWin32Long(short wLow, short wHigh)
        {
            return (wLow << 16) | wHigh;
        }

        public static void SetItemState(IntPtr handle, int itemIndex, int mask, int value)
        {
            NativeMethods.LVITEM lVITEM = default(NativeMethods.LVITEM);
            lVITEM.stateMask = mask;
            lVITEM.state = value;
            NativeMethods.LVITEM lParam = lVITEM;
            NativeMethods.SendMessage_1(handle, 4139u, new IntPtr(itemIndex), ref lParam);
        }

        public static void ScrollToBottom(IntPtr handle)
        {
            NativeMethods.SendMessage(handle, 277u, SB_PAGEBOTTOM, IntPtr.Zero);
        }
    }
}