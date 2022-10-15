using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;

namespace MidiSorcery
{
    public static class SongPlayer
    {
        private static OutputDevice outputDevice;
        private static  Playback playback;


        public static event Action OnNotePlayed;
        public static event Action OnFinish;


        public static int Elapsed => int.Parse(playback.GetCurrentTime(TimeSpanType.Midi).ToString());
        public static int Duration => int.Parse(playback.GetDuration(TimeSpanType.Midi).ToString());

        public static MetricTimeSpan ElaspedSpan => (MetricTimeSpan)playback.GetCurrentTime(TimeSpanType.Metric);
        public static MetricTimeSpan DurationSpan => (MetricTimeSpan)playback.GetDuration(TimeSpanType.Metric);
        public static bool IsRunning => playback.IsRunning;


        public static void Initialize(string location)
        {
            outputDevice = OutputDevice.GetByName("Microsoft GS Wavetable Synth");

            try
            {
                var midiFile = MidiFile.Read(location);
                playback = midiFile.GetPlayback(outputDevice);
                playback.NotesPlaybackStarted += Playback_NotesPlaybackStarted;
                playback.Finished += Playback_Finished;
                playback.InterruptNotesOnStop = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static void Playback_Finished(object? sender, EventArgs e)
        {
            OnFinish?.Invoke();
        }

        private static void Playback_NotesPlaybackStarted(object? sender, NotesEventArgs e)
        {
            OnNotePlayed?.Invoke();
        }

        public static void Play()
        {
            if (playback == null)
                return;

            playback.Start();
        }
        public static void Pause()
        {
            if (playback == null)
                return;

            playback.Stop();
        }

        public static void Search(int position)
        {
            if (playback == null)
                return;

            Pause();
            MidiTimeSpan span = new MidiTimeSpan(position);
            playback.MoveToTime(span);

            Play();
        }

        public static void Exit()
        {

            if (outputDevice == null || playback == null)
                return;

            outputDevice.Dispose();
            playback.Dispose();

            outputDevice = null;
            playback = null;
        }
    }
}
