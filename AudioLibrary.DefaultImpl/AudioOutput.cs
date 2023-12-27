using AudioLibrary.Core;
using AudioLibrary.Core.Abstract;
using AudioLibrary.DefaultImpl.NativeApi;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AudioLibrary.DefaultImpl
{
    public class AudioOutputDevice : IAudioOutputDevice
    {
        public bool IsOpen { get; private set; }
        public short DeviceIndex { get; private set; }
        public string Name { get => _waveInOutCaps.szPname; }
        public int BufferSize { get; set; } = 4096;
        public int BufferCount { get; set; } = 4;

        internal IntPtr Handle  = IntPtr.Zero;

        private readonly WAVEINOUTCAPS _waveInOutCaps;
        private WAVEFORMATEX _waveFormat;
        private WAVEINOUTHEADER[] _headers;
        private readonly WaveInOutCallback _callback;
        private int _currentHeaderIndex = 0;
        private bool _disposedValue;

        internal AudioOutputDevice(short deviceIndex, WAVEINOUTCAPS waveInOutcaps)
        {
            DeviceIndex = deviceIndex;
            _waveInOutCaps = waveInOutcaps;
            _callback = new WaveInOutCallback(WaveOutProc);
            //Headerlari bu noktada (yada muhtemelen class disinda) olusturmazsak calma aninda header serbest kalmiyor (dwFlags 16 | 2 = 18 olarak kaliyor)
            _headers = new WAVEINOUTHEADER[BufferCount];
        }

        public void Open(ushort waveFormat = WaveFormat.PCM, ushort channels = 1, uint samplingRate = 44100, AudioBitrate audioBitrate = AudioBitrate._16Bit)
        {
            _waveFormat = new WAVEFORMATEX()
            {
                wFormatTag = waveFormat,
                nChannels = channels,
                nSamplesPerSec = samplingRate,
                wBitsPerSample = (ushort)audioBitrate,
                nBlockAlign = 2,
                nAvgBytesPerSec = samplingRate * 2
            };

            int result = Winmm.waveOutOpen(out Handle, DeviceIndex, ref _waveFormat, _callback, 0, 0x00030000);
            if (result != MMSYSERR.NO_ERROR)
            {
                throw new Exception($"Couldn't open audio output device. Error code : {result}");
            }

            for (var index = 0; index < _headers.Length; index++)
            {
                result = Winmm.waveOutPrepareHeader(Handle, ref _headers[index], (uint)Marshal.SizeOf(typeof(WAVEINOUTHEADER)));

                if (result != MMSYSERR.NO_ERROR)
                {
                    throw new Exception($"An error occured : waveOutPrepareHeader ({result})");
                }
            }
        }
        public void Write(byte[] buffer)
        {
            if (_currentHeaderIndex == _headers.Length)
            {
                _currentHeaderIndex = 0;
            }

            if ((_headers[_currentHeaderIndex].dwFlags & 16) == 16)
            {
                return;
            }

            Debug.WriteLine(_headers[_currentHeaderIndex].dwFlags);
            try
            {
                _headers[_currentHeaderIndex].lpData = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                _headers[_currentHeaderIndex].dwBufferLength = (uint)buffer.Length;

                var result = Winmm.waveOutWrite(Handle, ref _headers[_currentHeaderIndex], (uint)Marshal.SizeOf(typeof(WAVEINOUTHEADER)));
                if (result != 0)
                {
                    throw new Exception($"An error occured : waveOutWrite ({result})");
                }
            }
            finally
            {
                _currentHeaderIndex++;
            }        }

        public void Close()
        {
            var result = 0;
            for (var index = 0; index < _headers.Length; index++)
            {
                result = Winmm.waveOutPrepareHeader(Handle, ref _headers[index], (uint)Marshal.SizeOf(typeof(WAVEINOUTHEADER)));
            }

            result = Winmm.waveOutClose(Handle);
            if (result != 0)
            {
                throw new Exception($"An error occured : waveOutClose ({result})");
            }
        }

        private void WaveOutProc(IntPtr hwi, uint uMsg, IntPtr dwInstance, ref WAVEINOUTHEADER waveOutHeader, IntPtr dwReserved)
        {
            Debug.WriteLine(uMsg);
            switch (uMsg)
            {
                case MMSYSTEM.MM_WOM_OPEN:
                    IsOpen = true;
                    Debug.WriteLine("Wave Out Open");
                    break;
                case MMSYSTEM.MM_WOM_DONE:
                    Debug.WriteLine("Wave Out Done");
                    break;
                case MMSYSTEM.MM_WOM_CLOSE:
                    IsOpen = false;
                    Debug.WriteLine("Wave Out Close");
                    break;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
