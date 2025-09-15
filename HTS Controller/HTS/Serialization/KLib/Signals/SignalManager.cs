namespace KLib.Signals
{
    public class SignalManager
    {
        public List<Channel> Channels { get; set; }
        public float SamplingRate_Hz { get; set; }

        public SignalManager()
        {
            Channels = new List<Channel>();
            SamplingRate_Hz = 48000;
        }
    }
}