namespace KLib.Signals
{
    public static class WaveformFactory
    {
        public static Waveform Create(string? shape)
        {
            Waveform waveform = new Waveform();
            if (shape != null)
            {
                switch (shape)
                {
                    case "Sinusoid":
                        waveform = new Sinusoid();
                        break;
                    case "Noise":
                        waveform = new Noise();
                        break;
                }
            }
            return waveform;
        }
    }
}