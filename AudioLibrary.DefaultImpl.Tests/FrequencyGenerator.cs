namespace AudioLibrary.DefaultImpl.Tests
{
    public class FrequencyGenerator
    {
        public static byte[] Generate16BitSineWave(int sampleRate, double frequency, double duration, double amplitude)
        {
            int numSamples = (int)(sampleRate * duration);
            byte[] waveData = new byte[numSamples * 2]; // 16 bits = 2 bytes

            double timeIncrement = 1.0 / sampleRate;

            for (int i = 0; i < numSamples; i++)
            {
                double t = i * timeIncrement;
                double sinValue = amplitude * Math.Sin(2 * Math.PI * frequency * t);

                // Scale to short range
                short sampleValue = (short)(short.MaxValue * sinValue);

                // Convert short to bytes (little-endian)
                byte[] sampleBytes = BitConverter.GetBytes(sampleValue);
                waveData[i * 2] = sampleBytes[0]; // Low byte
                waveData[i * 2 + 1] = sampleBytes[1]; // High byte
            }

            return waveData;
        }
    }
}
