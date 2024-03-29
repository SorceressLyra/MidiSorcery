using System.Diagnostics;
using System.Text.RegularExpressions;
using Melanchall.DryWetMidi.Interaction;
using WMPLib;

namespace MidiSorcery
{
    public partial class Form1 : Form
    {
        public Form1(string song)
        {
            InitializeComponent();

            //Window name
            string pattern = @"[\w-\s]+(?=\.)";
            Regex rx = new Regex(pattern);

            Match match = rx.Match(song);
            this.Text = match.Value;

            

            //Song init
            SongPlayer.Initialize(song);
            SongPlayer.Play();
            //SongPlayer.OnNotePlayed += SetProgress;
            SongPlayer.OnFinish += Application.Exit;
            SetProgress();

            

            //Update loop
            System.Timers.Timer timer = new(10);
            timer.AutoReset = true;
            timer.Elapsed += timerElapse;
            timer.Start();

        }

        private void timerElapse(object sender, System.Timers.ElapsedEventArgs e)
        {
            SetProgress();
        }

        private void SetProgress()
        {
            float percentage = ((float)SongPlayer.Elapsed / (float)SongPlayer.Duration) * 100;

            TimeSpan elapsed = TimeSpan.Parse($"{SongPlayer.ElaspedSpan.Hours}:{SongPlayer.ElaspedSpan.Minutes}:{SongPlayer.ElaspedSpan.Seconds}");
            TimeSpan duration = TimeSpan.Parse($"{SongPlayer.DurationSpan.Hours}:{SongPlayer.DurationSpan.Minutes}:{SongPlayer.DurationSpan.Seconds}");
            string output = $"{percentage.ToString("000.0")}% | {elapsed.ToString(@"mm\:ss")}/{duration.ToString(@"mm\:ss")}";

            if (this.ProgressText.InvokeRequired)
            {
                this.ProgressText.Invoke(() =>
                {
                    this.ProgressText.Text = output;
                });
            }


            int filled = (int)Math.Floor((float)SongPlayer.Elapsed / (float)((float)SongPlayer.Duration / (float)this.TrackBar.Maximum));

            if (this.TrackBar.InvokeRequired)
            {
                this.TrackBar.Invoke(() =>
                {
                    this.TrackBar.Value = filled;
                });
            }

        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (SongPlayer.IsRunning)
            {
                this.PlayPauseButton.Text = "Play";
                SongPlayer.Pause();
            }
            else
            {
                this.PlayPauseButton.Text = "Pause";
                SongPlayer.Play();
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            int chunkSize = SongPlayer.Duration / TrackBar.Maximum;
            SongPlayer.Search(TrackBar.Value * chunkSize);
        }
    }
}