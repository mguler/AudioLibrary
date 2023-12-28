using AudioLibrary.Core.Abstract;

namespace AudioLibrary.DefaultImpl.Tests
{
    [TestClass]
    public class AudioOutTests
    {
        [TestMethod("Audio Play Test")]
        public void AudioPlay()
        {
            var result = false;
            var audioWave = FrequencyGenerator.Generate16BitSineWave(44100, 440, 1, 1);
            var audioDevices = new AudioDevices();
            var firstOutputDevice = audioDevices.GetOutputDevices().FirstOrDefault();
            var bufferSize = 4096;
            firstOutputDevice.AudioEvent += audioEventType => result = audioEventType == AudioEventType.WaveOutDone;
            firstOutputDevice.Open();

            var chunks = audioWave.Length / bufferSize;
            for (var index = 0; index < chunks; index++)
            {
                var data = new byte[bufferSize];
                Array.Copy(audioWave, index * bufferSize, data, 0, bufferSize);
                firstOutputDevice.Write(data);
            }

            Thread.Sleep(2000);
            Assert.IsTrue(result);

        }

        [TestMethod("Audio Output Open Test")]
        public void AudioOpen()
        {
            var result = false;
            var audioWave = FrequencyGenerator.Generate16BitSineWave(44100, 440, 1, 1);
            var audioDevices = new AudioDevices();
            var firstOutputDevice = audioDevices.GetOutputDevices().FirstOrDefault();
            var bufferSize = 4096;

            firstOutputDevice.AudioEvent += audioEventType => result = audioEventType == AudioEventType.WaveOutOpen;
            firstOutputDevice.Open();

            Thread.Sleep(2000);
            Assert.IsTrue(result);

        }

        [TestMethod("Audio Output Close Test")]
        public void AudioClose()
        {
            var result = false;
            var audioWave = FrequencyGenerator.Generate16BitSineWave(44100, 440, 1, 1);
            var audioDevices = new AudioDevices();
            var firstOutputDevice = audioDevices.GetOutputDevices().FirstOrDefault();
            var bufferSize = 4096;
            firstOutputDevice.Open();

            firstOutputDevice.AudioEvent += audioEventType => result = audioEventType == AudioEventType.WaveOutClose;
            firstOutputDevice.Close();

            Thread.Sleep(2000);
            Assert.IsTrue(result);

        }

    }
}