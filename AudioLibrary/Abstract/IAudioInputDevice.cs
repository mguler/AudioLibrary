namespace AudioLibrary.Core.Abstract
{
    public delegate void DataAvailableEventHandler(byte[] audio);
    public interface IAudioInputDevice : IAudioDevice
    {
        public event DataAvailableEventHandler DataAvailable;
    }
}
