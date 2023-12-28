using AudioLibrary.DefaultImpl.NativeApi;
using System.Runtime.InteropServices;

namespace AudioLibrary.DefaultImpl
{
    public class AudioDevices
    {
        public List<AudioOutputDevice> GetOutputDevices()
        {
            var devices = new List<AudioOutputDevice>();
            int deviceCount = Winmm.waveOutGetNumDevs();

            for (short deviceIndex = 0; deviceIndex < deviceCount; deviceIndex++)
            {
                var waveOutCaps = new WAVEINOUTCAPS();
                int result = Winmm.waveOutGetDevCaps(deviceIndex, ref waveOutCaps, (uint)Marshal.SizeOf(typeof(WAVEINOUTCAPS)));

                if (result == MMSYSERR.NO_ERROR)
                {
                    devices.Add(new AudioOutputDevice(deviceIndex, waveOutCaps));
                }
            }
            return devices;
        }
        public List<AudioInputDevice> GetInputDevices()
        {
            var devices = new List<AudioInputDevice>();
            int deviceCount = Winmm.waveOutGetNumDevs();

            for (short deviceIndex = 0; deviceIndex < deviceCount; deviceIndex++)
            {
                var waveOutCaps = new WAVEINOUTCAPS();
                int result = Winmm.waveInGetDevCaps(deviceIndex, ref waveOutCaps, (uint)Marshal.SizeOf(typeof(WAVEINOUTCAPS)));

                if (result == MMSYSERR.NO_ERROR)
                {
                   // devices.Add(new AudioInputDevice(deviceIndex, waveOutCaps));
                }
            }
            return devices;
        }
    }
}
