using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Dsp;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private delegate void SafeCallDelegate(float[] soundData, Complex[] spectrum);
        private readonly SignalProcessor _signalProcessor = new SignalProcessor();
        private bool _scaleReset = false;
        private int _centralFreq = SignalProcessor.ToneGenerator;
        private int _windowFreq = 100;
        private int _amplification;
        private DirectBitmap dbmWave = null;
        private DirectBitmap dbmSpectrum = null;
        private readonly Font _drawFont = new Font("Arial", 16);

        public Form1()
        {
            InitializeComponent();
            trackBarCentralFreq.Value = _centralFreq;
            lbCentralFreq.Text = _centralFreq.ToString();
            trackBarWindowFreq.Value = _windowFreq;
            lbFreqWindow.Text = _windowFreq.ToString();
            _amplification = trackBarAmplification.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _signalProcessor.StartRecord((soundData, spectrum) 
                => Invoke(new SafeCallDelegate(UIOnAudioDataReceived), soundData, spectrum));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _signalProcessor.StopRecord();
        }
        
        private void UIOnAudioDataReceived(float[] soundData, Complex[] spectrum)
        {
            using (var g = Graphics.FromImage(dbmWave.Bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, dbmWave.Width, dbmWave.Height);
            }

            using (var g = Graphics.FromImage(dbmSpectrum.Bitmap))
            {
                g.FillRectangle(Brushes.Black, 0, 0, dbmSpectrum.Width, dbmSpectrum.Height);
            }

            using (var g = Graphics.FromImage(dbmWave.Bitmap))
            {
                g.CompositingQuality = CompositingQuality.HighSpeed;
                var prevX = 0;
                var prevY = dbmWave.Height / 2;
                var ratio = _scaleReset ? 1 : (float)soundData.Length / dbmWave.Width;
                for (var i = 0; i < dbmWave.Width; i++)
                {
                    var dataIndex = (int)(ratio * i);
                    if (dataIndex >= soundData.Length)
                        break;
                    var d = soundData[dataIndex] * _amplification;
                    //dbmWave.SetPixel(i, (dbmWave.Height / 2) + (int) (d * dbmWave.Height / 2), Color.Green);
                    var y = (dbmWave.Height / 2) + (int)(d * dbmWave.Height / 2);
                    g.DrawLine(Pens.LightGreen, prevX, prevY, i, y);
                    prevX = i;
                    prevY = y;
                    //data[i] = (float)(data[i] * FastFourierTransform.BlackmannHarrisWindow(i, data.Length));
                }
            }


            var frameFreq = (float)SignalProcessor.SampleRate / SignalProcessor.FftBlockSize;
            var lowFreqToShow = _centralFreq - _windowFreq;
            var highFreqToShow = _centralFreq + _windowFreq;
            var lowBinToShow = (int)(lowFreqToShow / frameFreq);
            var highBinToShow = (int)(highFreqToShow / frameFreq);

            float[] amplitudes = new float[highBinToShow - lowBinToShow];
            for (var i = 0; i < amplitudes.Length; i++)
            {
                var bin = spectrum[i + lowBinToShow];
                var binAmplitude = (float)Math.Sqrt(bin.X * bin.X + bin.Y * bin.Y);
                amplitudes[i] = binAmplitude;
            }

            var maxAmplitude = amplitudes.Max();
            var yScale = dbmSpectrum.Height / maxAmplitude;
            var xScale = (float)dbmSpectrum.Width / amplitudes.Length;

            using (var g = Graphics.FromImage(dbmSpectrum.Bitmap))
            {
                lbAmplitude.Text = maxAmplitude.ToString("N6");

                for (var i = 0; i < amplitudes.Length; i++)
                {
                    var scaledAmplitude = amplitudes[i] * yScale;
                    var toY = dbmSpectrum.Height - scaledAmplitude;
                    var toX = i * xScale;
                    g.DrawLine(Pens.White, 
                        i * xScale, dbmSpectrum.Height,toX ,
                        toY + 10);
                    if (scaledAmplitude > dbmSpectrum.Height / 3)
                    {
                        var caption = ((i + lowBinToShow) * frameFreq).ToString("F2");
                        g.DrawString(caption, _drawFont, Brushes.Yellow, toX, toY);
                    }
                }

            }
            pbxWave.Invalidate();
            pbxSpectrum.Invalidate();
        }

        private void pbxWave_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(dbmWave.Bitmap, 0, 0);
        }

        private void pbxWave_Resize(object sender, EventArgs e)
        {
            dbmWave = new DirectBitmap(pbxWave.Width, pbxWave.Height);
        }

        private void btnResetScale_Click(object sender, EventArgs e)
        {
            _scaleReset = !_scaleReset;
            if (_scaleReset)
            {
                btnResetScale.BackColor = Color.Crimson;
            }
            else
            {
                btnResetScale.BackColor = btnStop.BackColor;
            }
        }

        private void pbxSpectrum_Resize(object sender, EventArgs e)
        {
            dbmSpectrum = new DirectBitmap(pbxSpectrum.Width, pbxSpectrum.Height);
        }

        private void pbxSpectrum_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(dbmSpectrum.Bitmap, 0, 0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_signalProcessor.StopRecord();
        }

        private void trackBarCentralFreq_Scroll(object sender, EventArgs e)
        {
            if (trackBarCentralFreq.Value - trackBarWindowFreq.Value < 0)
            {
               trackBarWindowFreq.Value = trackBarCentralFreq.Value;
               _windowFreq = trackBarCentralFreq.Value;
               lbFreqWindow.Text = _windowFreq.ToString();
            }
            _centralFreq = trackBarCentralFreq.Value;
            lbCentralFreq.Text = _centralFreq.ToString();
        }

        private void trackBarWindowFreq_Scroll(object sender, EventArgs e)
        {
            if (trackBarCentralFreq.Value - trackBarWindowFreq.Value < 0)
            {
                trackBarCentralFreq.Value = trackBarWindowFreq.Value;
                _centralFreq = trackBarWindowFreq.Value;
                lbCentralFreq.Text = _centralFreq.ToString();
            }
            _windowFreq = trackBarWindowFreq.Value;
            lbFreqWindow.Text = _windowFreq.ToString();
        }

        private void trackBarAmplification_Scroll(object sender, EventArgs e)
        {
            _amplification = trackBarAmplification.Value;
        }
    }
}
