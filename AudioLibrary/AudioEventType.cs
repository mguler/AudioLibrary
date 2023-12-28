namespace AudioLibrary.Core.Abstract
{
    public enum AudioEventType : uint
    {
        WaveOutOpen = 0x3BB, WaveOutClose = 0x3BC, WaveOutDone = 0x3BD, WaveInOpen = 0x3BE, WaveInClose = 0x3BF, WaveInDataAvailable = 0x3C0
    } 
}
