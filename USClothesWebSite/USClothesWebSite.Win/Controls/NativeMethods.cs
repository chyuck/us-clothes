using System;
using System.Runtime.InteropServices;

namespace USClothesWebSite.Win.Controls
{
    internal static class NativeMethods
    {
        private const uint ECM_FIRST = 0x1500;
        internal const uint EM_SETWATERMARKBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
    }
}
