using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Audiograms;
using C462.Shared;

namespace HTSController
{
    public static class AudiogramPlot
    {
        public static Rectangle Bounds { get; set; }

        private static AudiogramPlotForm _form;
        private static AudiogramData _audiogram;
        private static AudiogramData _ldlgram;
        private static string _subject;

        public static void SetData(AudiogramData audiogram, AudiogramData ldlgram, string subject)
        {
            _audiogram = audiogram;
            _ldlgram = ldlgram;
            _subject = subject;
            _form?.LoadData(_audiogram, _ldlgram, _subject);
        }

        public static void SetSubject(string subject)
        {
            if (subject == _subject) return;
            _subject = subject;
            Reset();
        }

        public static void Reset()
        {
            _audiogram = null;
            _ldlgram = null;
            _form?.LoadData(null, null, "");
        }

        public static void AddPoint(AudiogramType type, AudiogramTestEar ear, float frequency, float thresholdHL, float thresholdSPL)
        {
            if (type == AudiogramType.Threshold)
            {
                if (_audiogram == null)
                {
                    _audiogram = new AudiogramData();
                    _audiogram.Initialize(new float[] { frequency });
                }
                _audiogram.Insert(ear, frequency, thresholdHL, thresholdSPL, 0);
            }
            else
            {
                if (_ldlgram == null)
                {
                    _ldlgram = new AudiogramData();
                    _ldlgram.Initialize(new float[] { frequency });
                }
                _ldlgram.Insert(ear, frequency, thresholdHL, thresholdSPL, 0);
            }
            _form?.LoadData(_audiogram, _ldlgram, _subject);
        }

        public static void Show(IWin32Window owner = null)
        {
            if (_form != null && !_form.IsDisposed)
            {
                _form.BringToFront();
                return;
            }

            _form = new AudiogramPlotForm();
            _form.FormClosed += (s, e) => { SaveBounds(); _form = null; };
            RestoreBounds();

            _form.LoadData(_audiogram, _ldlgram, _subject);
            _form.Show(owner);
        }

        public static void Close()
        {
            if (_form != null && !_form.IsDisposed)
            {
                _form.Close();
            }
        }

        private static void RestoreBounds()
        {
            if (Bounds == Rectangle.Empty) return;

            bool onScreen = Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(Bounds));
            if (onScreen)
            {
                _form.StartPosition = FormStartPosition.Manual;
                _form.Bounds = Bounds;
            }
            // else: leave StartPosition at WindowsDefaultLocation
        }

        private static void SaveBounds()
        {
            if (_form == null || _form.WindowState != FormWindowState.Normal) return;
            Bounds = _form.Bounds;
        }

    }
}
