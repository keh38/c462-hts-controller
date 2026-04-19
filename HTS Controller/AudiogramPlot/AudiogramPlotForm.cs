using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Audiograms;
using ScottPlot;
using ScottPlot.Plottables;

namespace HTSController
{
    public partial class AudiogramPlotForm : Form
    {
        private const int _fmin = 125;
        private const int _yvalueForInf = 115;
        private readonly double[] _frequencies = new double[] { 125, 250, 500, 1000, 2000, 4000, 8000, 12000, 16000 };

        public AudiogramPlotForm()
        {
            InitializeComponent();
        }

        private void AudiogramPlotForm_Shown(object sender, EventArgs e)
        {
            InitializePlot();
        }

        private void InitializePlot()
        {
            double[] xval = new double[_frequencies.Length];
            string[] labels = new string[_frequencies.Length];
            for (int i = 0; i < _frequencies.Length; i++)
            {
                xval[i] = (float)Math.Log10(_frequencies[i] / _fmin) + 1;
                if (_frequencies[i] >= 1000)
                {
                    labels[i] = (_frequencies[i] / 1000).ToString() + "k";
                }
                else
                {
                    labels[i] = _frequencies[i].ToString();
                }
            }
            var normalRange = formsPlot.Plot.Add.Rectangle(
                left: xval[0],
                right: xval[xval.Length - 1],
                top: 0,
                bottom: 25);

            normalRange.FillColor = Colors.LightGreen.WithAlpha(0.25);
            normalRange.LineWidth = 0;

            formsPlot.Plot.Axes.SetLimitsX(xval[0], xval[xval.Length - 1]);
            formsPlot.Plot.Axes.Bottom.SetTicks(xval, labels);
            formsPlot.Plot.Axes.Bottom.MinorTickStyle.Length = 0;
            formsPlot.Plot.XLabel("Frequency (Hz)");

            formsPlot.Plot.Axes.SetLimitsY(120, -10);
            formsPlot.Plot.Axes.Left.SetTicks(
                new double[] { -10, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 },
                new string[] { "-10", "0", "10", "20", "30", "40", "50", "60", "70", "80", "90", "100", "110", "120" });
            formsPlot.Plot.Axes.Left.MinorTickStyle.Length = 0;
            formsPlot.Plot.YLabel("Level (dB HL)");

            formsPlot.Refresh();
        }

        public void LoadData(AudiogramData audiogram, AudiogramData ldlgram, string subject)
        {
            var plot = formsPlot.Plot;

            // Remove only data plottables, not the normal range rectangle
            plot.Remove<Scatter>();

            if (audiogram != null)
                AddAudiogramSeries(plot, audiogram, ldlgram);

            formsPlot.Plot.Title(subject);
            formsPlot.Refresh();
        }

        private void AddAudiogramSeries(Plot plot, AudiogramData audiogram, AudiogramData ldlgram)
        {
            // Left audiogram
            var leftAudio = audiogram.Get(C462.Shared.AudiogramTestEar.Left);
            float[] freq = leftAudio.Frequency_Hz.Select(f => (float)Math.Log10(f / _fmin) + 1).ToArray();
            float[] threshold = leftAudio.Threshold_dBHL.Select(l => (float)Math.Min(l, _yvalueForInf)).ToArray();
            
            var scatter = plot.Add.Scatter(freq, threshold);
            scatter.MarkerShape = MarkerShape.Eks;
            scatter.MarkerLineColor = Colors.Blue;
            scatter.MarkerLineWidth = 2;
            scatter.MarkerSize = 12;
            scatter.LineStyle = LineStyle.None;

            // Right audiogram
            var rightAudio = audiogram.Get(C462.Shared.AudiogramTestEar.Right);
            freq = rightAudio.Frequency_Hz.Select(f => (float)Math.Log10(f / _fmin) + 1).ToArray();
            threshold = rightAudio.Threshold_dBHL.Select(l => (float)Math.Min(l, _yvalueForInf)).ToArray();
            
            scatter = plot.Add.Scatter(freq, threshold);
            scatter.MarkerShape = MarkerShape.OpenCircle;
            scatter.MarkerLineColor = Colors.Red;
            scatter.MarkerLineWidth = 2;
            scatter.MarkerSize = 12;
            scatter.LineStyle = LineStyle.None;

            if (ldlgram == null) return;

            // Left LDL
            var data = ldlgram.Get(C462.Shared.AudiogramTestEar.Left);

            for (int k=0; k<data.Frequency_Hz.Length; k++)
            {
                var x = (float)Math.Log10(data.Frequency_Hz[k] / _fmin) + 1;
                float ldl_sl = (float)data.Threshold_dBHL[k];
                float thr = leftAudio.GetHL(data.Frequency_Hz[k]);
                float ldl = (float)Math.Min(thr + ldl_sl, _yvalueForInf);

                var text = plot.Add.Text("U", x, ldl);
                text.LabelFontSize = 18;
                text.LabelBold = true;
                text.LabelFontColor = Colors.Blue;
                text.LabelAlignment = Alignment.MiddleCenter;
            }

            // Right LDL
            data = ldlgram.Get(C462.Shared.AudiogramTestEar.Right);
            for (int k = 0; k < data.Frequency_Hz.Length; k++)
            {
                float x = (float)Math.Log10(data.Frequency_Hz[k] / _fmin) + 1;

                float ldl_sl = (float)data.Threshold_dBHL[k];
                float thr = rightAudio.GetHL(data.Frequency_Hz[k]);
                float ldl = (float)Math.Min(thr + ldl_sl, _yvalueForInf);

                var text = plot.Add.Text("U", x, ldl);
                text.LabelFontSize = 18;
                text.LabelBold = true;
                text.LabelFontColor = Colors.Red;
                text.LabelAlignment = Alignment.MiddleCenter;
            }
        }
    }
}
