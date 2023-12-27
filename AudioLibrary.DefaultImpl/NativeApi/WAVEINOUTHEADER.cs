using System.Runtime.InteropServices;

namespace AudioLibrary.DefaultImpl.NativeApi
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WAVEINOUTHEADER
    {
        public IntPtr lpData;
        public uint dwBufferLength;
        public uint dwBytesRecorded;
        public IntPtr dwUser;
        public uint dwFlags;
        public uint dwLoops;
        public IntPtr lpNext;
        public IntPtr reserved;
    }
}
