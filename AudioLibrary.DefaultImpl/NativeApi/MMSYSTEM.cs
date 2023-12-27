namespace AudioLibrary.DefaultImpl.NativeApi
{
    public static class MMSYSTEM
    {
        public const int MM_WOM_OPEN = 0x3BB;           /* waveform output */
        public const int MM_WOM_CLOSE = 0x3BC;
        public const int MM_WOM_DONE = 0x3BD;

        public const int MM_WIM_OPEN = 0x3BE;           /* waveform input */
        public const int MM_WIM_CLOSE = 0x3BF;
        public const int MM_WIM_DATA = 0x3C0;

        public const int MM_MIM_OPEN = 0x3C1;          /* MIDI input */
        public const int MM_MIM_CLOSE = 0x3C2;
        public const int MM_MIM_DATA = 0x3C3;
        public const int MM_MIM_LONGDATA = 0x3C4;
        public const int MM_MIM_ERROR = 0x3C5;
        public const int MM_MIM_LONGERROR = 0x3C6;
        public const int MM_MIM_MOREDATA = 0x3CC;
    }
}
