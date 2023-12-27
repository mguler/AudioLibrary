using System.Runtime.InteropServices;

namespace AudioLibrary.DefaultImpl.NativeApi
{
    public delegate void WaveInOutCallback(IntPtr hwi, uint uMsg, IntPtr dwInstance, ref WAVEINOUTHEADER wavhdr, IntPtr dwReserved);
    static class Winmm
    {

        [DllImport("winmm.dll")]
        public static extern int waveInOpen(out IntPtr phwi, int uDeviceID, ref WAVEFORMATEX pwfx, WaveInOutCallback dwCallback, IntPtr dwInstance, int dwFlags);

        [DllImport("winmm.dll")]
        public static extern int waveInPrepareHeader(IntPtr hwi, ref WAVEINOUTHEADER pwh, int cbwh);

        [DllImport("winmm.dll")]
        public static extern int waveInAddBuffer(IntPtr hwi, ref WAVEINOUTHEADER pwh, int cbwh);
        [DllImport("winmm.dll")]
        public static extern int waveInStart(IntPtr hwi);
        [DllImport("winmm.dll")]
        public static extern int waveInUnprepareHeader(IntPtr hwi, ref WAVEINOUTHEADER pwh, int cbwh);
        [DllImport("winmm.dll")]
        public static extern int waveInStop(IntPtr hwi);

        [DllImport("winmm.dll")]
        public static extern int waveInClose(IntPtr hwi);


        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, ref WAVEFORMATEX lpFormat, WaveInOutCallback dwCallback, int dwInstance, int dwFlags);
        [DllImport("winmm.dll")]
        public static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WAVEINOUTHEADER lpWaveOutHdr, uint uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr hWaveOut, ref WAVEINOUTHEADER lpWaveOutHdr, uint uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(IntPtr hWaveOut, IntPtr lpWaveOutHdr, uint uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutUnprepareHeader(IntPtr hWaveOut, ref WAVEINOUTHEADER lpWaveOutHdr, uint uSize);
        [DllImport("winmm.dll")]
        public static extern int waveOutClose(IntPtr hWaveOut);
        [DllImport("winmm.dll")]
        public static extern int waveOutReset(IntPtr hWaveOut);


        [DllImport("winmm.dll")]
        public static extern int waveOutGetNumDevs();

        [DllImport("winmm.dll", CharSet = CharSet.Unicode)]
        public static extern int waveOutGetDevCaps(int uDeviceID, ref WAVEINOUTCAPS pwoc, uint cbwoc);


        [DllImport("winmm.dll")]
        public static extern int waveInGetNumDevs();

        [DllImport("winmm.dll", CharSet = CharSet.Ansi)]
        public static extern int waveInGetDevCaps(int uDeviceID, ref WAVEINOUTCAPS pwic, uint cbwic);

    }
}
