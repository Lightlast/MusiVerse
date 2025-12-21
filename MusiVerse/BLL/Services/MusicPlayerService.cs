using MusiVerse.DTO.Models;
using NAudio.Wave;
using System;
using System.IO;

namespace MusiVerse.BLL.Services
{
    /// <summary>
    /// Service quản lý phát nhạc sử dụng NAudio
    /// Singleton pattern để đảm bảo chỉ có 1 instance
    /// </summary>
    public class MusicPlayerService : IDisposable
    {
        private static MusicPlayerService instance;
        private static readonly object lockObj = new object();

        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;

        // Current song info
        public Song CurrentSong { get; private set; }
        public bool IsPlaying { get; private set; }
        public bool IsPaused { get; private set; }
        public TimeSpan CurrentTime => audioFileReader?.CurrentTime ?? TimeSpan.Zero;
        public TimeSpan TotalTime => audioFileReader?.TotalTime ?? TimeSpan.Zero;
        public float Volume
        {
            get => audioFileReader?.Volume ?? 1.0f;
            set
            {
                if (audioFileReader != null)
                    audioFileReader.Volume = Math.Max(0f, Math.Min(1f, value));
            }
        }

        // Events
        public event EventHandler SongChanged;
        public event EventHandler PlaybackStopped;
        public event EventHandler PlaybackPaused;
        public event EventHandler PlaybackResumed;
        public event EventHandler<TimeSpan> PositionChanged;

        private MusicPlayerService()
        {
            wavePlayer = new WaveOutEvent();
            wavePlayer.PlaybackStopped += OnPlaybackStopped;
        }

        /// <summary>
        /// Get singleton instance
        /// </summary>
        public static MusicPlayerService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new MusicPlayerService();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Load và phát bài hát
        /// </summary>
        public bool LoadAndPlay(Song song)
        {
            try
            {
                // Kiểm tra file tồn tại
                if (!File.Exists(song.FilePath))
                {
                    throw new FileNotFoundException($"Không tìm thấy file nhạc: {song.FilePath}");
                }

                // Stop bài hát hiện tại
                Stop();

                // Load file mới
                audioFileReader = new AudioFileReader(song.FilePath);
                wavePlayer.Init(audioFileReader);

                // Cập nhật thông tin
                CurrentSong = song;

                // Phát nhạc
                wavePlayer.Play();
                IsPlaying = true;
                IsPaused = false;

                // Trigger event
                SongChanged?.Invoke(this, EventArgs.Empty);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading song: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Play bài hát hiện tại (từ vị trí pause)
        /// </summary>
        public void Play()
        {
            if (audioFileReader != null && IsPaused)
            {
                wavePlayer.Play();
                IsPlaying = true;
                IsPaused = false;
                PlaybackResumed?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Pause bài hát
        /// </summary>
        public void Pause()
        {
            if (IsPlaying && !IsPaused)
            {
                wavePlayer.Pause();
                IsPlaying = false;
                IsPaused = true;
                PlaybackPaused?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Stop hoàn toàn
        /// </summary>
        public void Stop()
        {
            wavePlayer?.Stop();

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            IsPlaying = false;
            IsPaused = false;
        }

        /// <summary>
        /// Toggle Play/Pause
        /// </summary>
        public void TogglePlayPause()
        {
            if (IsPlaying)
            {
                Pause();
            }
            else if (IsPaused)
            {
                Play();
            }
        }

        /// <summary>
        /// Seek đến vị trí cụ thể
        /// </summary>
        public void Seek(TimeSpan position)
        {
            if (audioFileReader != null)
            {
                audioFileReader.CurrentTime = position;
                PositionChanged?.Invoke(this, position);
            }
        }

        /// <summary>
        /// Seek theo phần trăm (0.0 - 1.0)
        /// </summary>
        public void SeekPercent(double percent)
        {
            if (audioFileReader != null)
            {
                percent = Math.Max(0, Math.Min(1, percent));
                var position = TimeSpan.FromSeconds(TotalTime.TotalSeconds * percent);
                Seek(position);
            }
        }

        /// <summary>
        /// Tua nhanh (forward)
        /// </summary>
        public void Forward(int seconds = 10)
        {
            if (audioFileReader != null)
            {
                var newTime = CurrentTime.Add(TimeSpan.FromSeconds(seconds));
                if (newTime < TotalTime)
                {
                    Seek(newTime);
                }
            }
        }

        /// <summary>
        /// Tua lùi (backward)
        /// </summary>
        public void Backward(int seconds = 10)
        {
            if (audioFileReader != null)
            {
                var newTime = CurrentTime.Subtract(TimeSpan.FromSeconds(seconds));
                if (newTime < TimeSpan.Zero)
                    newTime = TimeSpan.Zero;
                Seek(newTime);
            }
        }

        /// <summary>
        /// Set volume (0.0 - 1.0)
        /// </summary>
        public void SetVolume(float volume)
        {
            Volume = volume;
        }

        /// <summary>
        /// Mute/Unmute
        /// </summary>
        private float previousVolume = 1.0f;
        public void ToggleMute()
        {
            if (Volume > 0)
            {
                previousVolume = Volume;
                Volume = 0;
            }
            else
            {
                Volume = previousVolume;
            }
        }

        /// <summary>
        /// Get current position as percentage
        /// </summary>
        public double GetPositionPercent()
        {
            if (audioFileReader == null || TotalTime.TotalSeconds == 0)
                return 0;

            return CurrentTime.TotalSeconds / TotalTime.TotalSeconds;
        }

        /// <summary>
        /// Event khi playback stopped
        /// </summary>
        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            IsPlaying = false;
            IsPaused = false;
            PlaybackStopped?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            Stop();
            wavePlayer?.Dispose();
            wavePlayer = null;
        }
    }

    /// <summary>
    /// Helper class để format thời gian
    /// </summary>
    public static class TimeSpanExtensions
    {
        public static string ToMinutesSeconds(this TimeSpan timeSpan)
        {
            return $"{(int)timeSpan.TotalMinutes}:{timeSpan.Seconds:D2}";
        }
    }
}