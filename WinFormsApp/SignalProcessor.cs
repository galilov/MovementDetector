using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Dsp;
using NAudio.Wave;

namespace WinFormsApp
{
    class SignalProcessor
    {
        public const int SampleRate = 48000; // Bin/s
        public const int Log2OfBinCount = 13;
        public const int ToneGenerator = 18222; // Hz
        private const int MaxDiscoverDelta = 50; // Hz
        private const double NoiseMagnitude = 1E-8;
        public const int FftBlockSize = 1 << Log2OfBinCount;
        private const int MinDiscoverDelta = SampleRate * 2 / FftBlockSize; // Hz
        private const string AlarmAudioFile = "buzzer.mp3";

        private readonly BlockingCollection<float[]> _dataFromAsioCollection = new BlockingCollection<float[]>();
        private readonly AutoResetEvent _alarmEvent = new AutoResetEvent(false);
        private readonly List<float> _collectedSoundData = new List<float>(FftBlockSize);
        private CancellationTokenSource _cancellationTokenSource = null;
        private AsioOut _asioOut = null;
        private Task _recordTask = null;

        public SignalProcessor()
        {
        }

        private Action<float[], Complex[]> _action;

        public void StartRecord(Action<float[], Complex[]> action)
        {
            if (_asioOut != null) return;
            _action = action;
            _cancellationTokenSource = new CancellationTokenSource();
            _asioOut = PrepareAsioOut();
            _asioOut.AudioAvailable += delegate(object o, AsioAudioAvailableEventArgs args)
            {
                _dataFromAsioCollection.Add(args.GetAsInterleavedSamples(), _cancellationTokenSource.Token);
            };
            _recordTask = Task.Run(ProcessAudioData, _cancellationTokenSource.Token)
                .ContinueWith(t => { t.Exception?.Handle(e => true); }, TaskContinuationOptions.OnlyOnCanceled);
            ;
            _asioOut.Play();
        }

        public void StopRecord()
        {
            if (_asioOut == null) return;
            _asioOut.Stop();
            _cancellationTokenSource.Cancel();
            _recordTask.Wait();
            _asioOut.Dispose();
            _asioOut = null;
            _action = null;
        }

        private void ProcessAudioData()
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                var data = _dataFromAsioCollection.Take(_cancellationTokenSource.Token);
                var remainedElements = FftBlockSize - _collectedSoundData.Count;
                for (var i = 0; i < Math.Min(remainedElements, data.Length); i++)
                {
                    //var multiplier = FastFourierTransform.BlackmannHarrisWindow(collectedData.Count, blockSize); 
                    //var multiplier =
                    //    Gausse(_collectedData.Count, FftBlockSize); // показывает меньше растекания в соседние гармоники
                    //_collectedData.Add((float)(multiplier * data[i]));
                    _collectedSoundData.Add(data[i]);
                }

                if (_collectedSoundData.Count == FftBlockSize)
                {
                    var complexData = 
                        _collectedSoundData
                        .Select(x => new Complex {X = x, Y = 0,})
                        .ToArray();
                    FastFourierTransform.FFT(true, SignalProcessor.Log2OfBinCount, complexData);
                    _action(_collectedSoundData.ToArray(), complexData);
                    _collectedSoundData.Clear();
                }
            }
        }


        private static AsioOut PrepareAsioOut()
        {
            var names = AsioOut.GetDriverNames();

            var asioDriverName = names[0];
            var asioOut = new AsioOut(asioDriverName);
            //var inputChannels = asioOut.DriverInputChannelCount;
            asioOut.InputChannelOffset = 0;
            asioOut.InitRecordAndPlayback(null, 1, SampleRate);
            return asioOut;
        }
    }
}