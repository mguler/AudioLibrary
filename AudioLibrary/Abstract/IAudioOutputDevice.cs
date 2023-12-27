namespace AudioLibrary.Core.Abstract
{
    public interface IAudioOutputDevice: IAudioDevice
    {
        void Write(byte[] buffer);

    }
}
