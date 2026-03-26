// Originally: SpeechReception.ListDescription (Speech\Speech Reception\SpeechReception.ListDescription.cs)
// Stripped to data structure (nested Sentence class + fields) only.
// SetSequence method removed — depends on KMath.Permute, Sequence, and Order
// which are not available in this project.
using System.Collections.Generic;

namespace SpeechReception
{
    public class ListDescription
    {
        public class Sentence
        {
            public string wavfile;
            public float SNR = float.NaN;
            public string whole;
            public List<string> words = new List<string>();

            public Sentence() { }

            public Sentence(Sentence source, float SNR)
            {
                this.wavfile = source.wavfile;
                this.SNR = SNR;
                this.whole = source.whole;
                foreach (string w in source.words) this.words.Add(w);
            }
        }

        public string title;
        public string type;

        public List<Sentence> sentences = new List<Sentence>();

        public ListDescription() { }
    }
}
