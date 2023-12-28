using AudioLibrary.Core;

namespace AudioLibrary.Core.Abstract
{
    public interface IAudioDevice : IDisposable
    {
        event AudioEventHandler AudioEvent;
        bool IsOpen { get; }
        short DeviceIndex { get; }
        string Name { get; }
        int BufferSize { get; set; }
        int BufferCount { get; set; }

        void Open(ushort waveFormat = WaveFormat.PCM, ushort channels = 1, uint samplingRate = 44100, AudioBitrate audioBitrate = AudioBitrate._16Bit);
        public void Close();
    }
}
