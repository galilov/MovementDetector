#nullable enable
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Dsp;
using NAudio.Wave;

namespace MovementDetector
{
    public static class App
    {
        private const int SampleRate = 48000; // Bin/s
        private const int Log2OfBinCount = 13;
        private const int ToneGenerator = 18222; // Hz
        private const int MaxDiscoverDelta = 50; // Hz
        private const double NoiseMagnitude = 1E-8;
        private const int FftBlockSize = 1 << Log2OfBinCount;
        private const int MinDiscoverDelta = SampleRate * 2 / FftBlockSize; // Hz
        private const string AlarmAudioFile = "buzzer.mp3";

        private static readonly BlockingCollection<float[]> Collection = new BlockingCollection<float[]>();
        private static readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        private static readonly AutoResetEvent AlarmEvent = new AutoResetEvent(false);

        [STAThread]
        public static void Main(string[] args)
        {
            var names = AsioOut.GetDriverNames();

            var asioDriverName = names[0];
            Console.WriteLine("Selected ASIO driver: {0}", asioDriverName);

            var asioOut = new AsioOut(asioDriverName);
            //var inputChannels = asioOut.DriverInputChannelCount;
            asioOut.InputChannelOffset = 0;
            asioOut.InitRecordAndPlayback(null, 1, SampleRate);
            asioOut.AudioAvailable += OnAsioOutAudioAvailable;
            var soundProcessTask = Task.Run(ProcessAudioData, CancellationTokenSource.Token)
                .ContinueWith(t =>
                {
                    t.Exception?.Handle(e => true);
                    Console.WriteLine("You have canceled the Sound Process task");
                }, TaskContinuationOptions.OnlyOnCanceled);
            var playerTask = Task.Run(PlayAlarm, CancellationTokenSource.Token)
                .ContinueWith(t =>
                {
                    t.Exception?.Handle(e => true);
                    Console.WriteLine("You have canceled the PlayAlarm task");
                }, TaskContinuationOptions.OnlyOnCanceled);
            ;
            asioOut.Play(); // start recording
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();

            asioOut.Stop();
            CancellationTokenSource.Cancel();

            Task.WaitAll(soundProcessTask, playerTask);
        }

        private static void PlayAlarm()
        {
            using var audioFile = new AudioFileReader(AlarmAudioFile);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);

            bool isStopped = true;
            for (;;)
            {
                var wr = WaitHandle.WaitAny(new[]
                {
                    AlarmEvent,
                    CancellationTokenSource.Token.WaitHandle
                });
                if (wr == 1)
                {
                    // cancelled through token
                    break;
                }

                if (wr == 0)
                {
                    if (isStopped)
                    {
                        isStopped = false;
                        outputDevice.PlaybackStopped += (sender, args) =>
                        {
                            isStopped = true;
                            audioFile.Position = 0;
                        };
                        outputDevice.Play();
                    }
                }
            }

            CancellationTokenSource.Token.ThrowIfCancellationRequested();
        }

        private static void OnAsioOutAudioAvailable(object? sender, AsioAudioAvailableEventArgs e)
        {
            Collection.Add(e.GetAsInterleavedSamples());
        }

        private static double Gausse(double n, double frameSize)
        {
            const double Q = 0.5;
            var a = (frameSize - 1) / 2;
            var t = (n - a) / (Q * a);
            t = t * t;
            return Math.Exp(-t / 2);
        }

        private static IDictionary<double, double> ComplexToFreqSpectrum(Complex[] spectrum,
            double minMagnitude, int minFreqHz, int maxFreqHz)
        {
            if (spectrum.Length != FftBlockSize)
                throw new ArgumentException("Wrong length of data block", nameof(spectrum));
            var frameFreq = SampleRate / (double) FftBlockSize;
            var result = new Dictionary<double, double>();
            var minMagnitude2 = minMagnitude * minMagnitude;
            var spectrumLength2 = spectrum.Length * spectrum.Length;
            for (var i = (int) (minFreqHz / frameFreq);
                i < spectrum.Length / 2 && i < (int) (maxFreqHz / frameFreq);
                i++)
            {
                var bin = spectrum[i];
                var normalizedM2 = (bin.X * bin.X + bin.Y * bin.Y) / spectrumLength2;
                if (normalizedM2 > minMagnitude2)
                {
                    result.Add(i * frameFreq, Math.Sqrt(normalizedM2));
                }
            }

            return result;
        }

        private static readonly List<float> CollectedData = new List<float>(FftBlockSize);

        private static void ProcessAudioData()
        {
            while (!CancellationTokenSource.Token.IsCancellationRequested)
            {
                var data = Collection.Take(CancellationTokenSource.Token);
                var remainedElements = FftBlockSize - CollectedData.Count;
                for (var i = 0; i < Math.Min(remainedElements, data.Length); i++)
                {
                    //var multiplier = FastFourierTransform.BlackmannHarrisWindow(collectedData.Count, blockSize); 
                    var multiplier =
                        Gausse(CollectedData.Count, FftBlockSize); // показывает меньше растекания в соседние гармоники
                    CollectedData.Add((float) (multiplier * data[i]));
                }

                if (CollectedData.Count == FftBlockSize)
                {
                    var complexData = CollectedData.Select(x => new Complex {X = x, Y = 0,}).ToArray();
                    CollectedData.Clear();
                    FastFourierTransform.FFT(true, Log2OfBinCount, complexData);
                    var freqs = ComplexToFreqSpectrum(complexData, NoiseMagnitude,
                        ToneGenerator - MaxDiscoverDelta * 2,
                        ToneGenerator + MaxDiscoverDelta * 2);
                    if (freqs.Any())
                    {
                        var loudestFreqs = freqs.OrderByDescending(f => f.Value);
#if DEBUG
                        Console.WriteLine(topFreqs.Aggregate(">>>",
                            (a, f) => a + ", " + (int) f.Key));
#endif
                        if (!loudestFreqs.Any(f =>
                            Math.Abs(f.Key - ToneGenerator) <= (double) SampleRate / FftBlockSize))
                        {
                            Console.WriteLine(DateTime.Now.ToLocalTime() + " WRONG SIGNAL FREQUENCY");
                        }
                        else
                        {
                            var movementIsDiscovered = loudestFreqs.Any(f =>
                            {
                                var delta = Math.Abs(f.Key - ToneGenerator);
                                return delta >= MinDiscoverDelta && delta < MaxDiscoverDelta;
                            });
                            if (movementIsDiscovered)
                            {
                                AlarmEvent.Set();
                                Console.WriteLine(DateTime.Now.ToLocalTime() + " ALERT");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToLocalTime() + " NO SIGNAL");
                    }
                }
            }

            CancellationTokenSource.Token.ThrowIfCancellationRequested();
        }
    }
}