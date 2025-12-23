using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucMusicPlayer : UserControl
    {
        private MusicPlayerService player;
        private Timer updateTimer;
        private bool isDraggingSeekBar = false;

        // Event để thông báo cho frmMain khi stop music
        public event EventHandler OnPlayerStopped;

        public ucMusicPlayer()
        {
            InitializeComponent();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            player = MusicPlayerService.Instance;

            // Subscribe to events
            player.SongChanged += Player_SongChanged;
            player.PlaybackStopped += Player_PlaybackStopped;
            player.PlaybackPaused += Player_PlaybackPaused;
            player.PlaybackResumed += Player_PlaybackResumed;

            // Timer để update UI
            updateTimer = new Timer();
            updateTimer.Interval = 100; // Update mỗi 100ms
            updateTimer.Tick += UpdateTimer_Tick;
        }

        private void ucMusicPlayer_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                updateTimer.Start();

                // Initialize volume
                trackBarVolume.Value = (int)(player.Volume * 100);
                UpdateUI();
            }
        }

        #region Player Events

        private void Player_SongChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Player_SongChanged(sender, e)));
                return;
            }

            UpdateSongInfo(); // Cập nhật tên bài hát, ảnh bìa...
            UpdateUI();
        }

        private void Player_PlaybackStopped(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateUI()));
                return;
            }
            UpdateUI();
        }

        private void Player_PlaybackPaused(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateUI()));
                return;
            }
            UpdateUI();
        }

        private void Player_PlaybackResumed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => UpdateUI()));
                return;
            }
            UpdateUI();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (player.IsPlaying && !isDraggingSeekBar)
            {
                UpdateTimeLabels();
                UpdateSeekBar();
            }
        }

        #endregion

        #region Button Events

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (player.CurrentSong == null)
            {
                MessageBox.Show("Chưa có bài hát nào được chọn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            player.TogglePlayPause();
            UpdateUI();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
            UpdateUI();
            UpdateSongInfo();
            
            // Phát event để frmMain biết cần ẩn music player
            OnPlayerStopped?.Invoke(this, EventArgs.Empty);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // TODO: Implement previous song in playlist
            MessageBox.Show("Chức năng Previous đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // TODO: Implement next song in playlist
            MessageBox.Show("Chức năng Next đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            if (player.CurrentSong != null)
                player.Backward(10);
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (player.CurrentSong != null)
                player.Forward(10);
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            bool isActive = btnShuffle.BackColor != Color.FromArgb(0, 150, 136);
            btnShuffle.BackColor = isActive
                ? Color.FromArgb(0, 150, 136)
                : Color.Gray;

            // TODO: Implement shuffle logic
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            bool isActive = btnRepeat.BackColor != Color.FromArgb(0, 150, 136);
            btnRepeat.BackColor = isActive
                ? Color.FromArgb(0, 150, 136)
                : Color.Gray;

            // TODO: Implement repeat logic
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            player.ToggleMute();
            trackBarVolume.Value = (int)(player.Volume * 100);
            UpdateVolumeIcon();
        }

        #endregion

        #region TrackBar Events

        private void trackBarSeek_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingSeekBar = true;
        }

        private void trackBarSeek_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingSeekBar = false;

            if (player.CurrentSong != null)
            {
                double percent = (double)trackBarSeek.Value / trackBarSeek.Maximum;
                player.SeekPercent(percent);
            }
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            if (isDraggingSeekBar && player.CurrentSong != null)
            {
                // Show preview time while dragging
                double percent = (double)trackBarSeek.Value / trackBarSeek.Maximum;
                TimeSpan previewTime = TimeSpan.FromSeconds(player.TotalTime.TotalSeconds * percent);
                lblCurrentTime.Text = previewTime.ToMinutesSeconds();
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            float volume = trackBarVolume.Value / 100f;
            player.SetVolume(volume);
            UpdateVolumeIcon();
        }

        #endregion

        #region UI Update Methods

        private void UpdateUI()
        {
            btnPlayPause.Enabled = player.CurrentSong != null;
            btnStop.Enabled = player.CurrentSong != null;
            btnBackward.Enabled = player.CurrentSong != null;
            btnForward.Enabled = player.CurrentSong != null;

            if (player.CurrentSong == null)
            {
                btnPlayPause.Text = "▶";
                btnPlayPause.BackColor = Color.FromArgb(30, 144, 255);
                return;
            }

            // Update play/pause button
            btnPlayPause.Text = player.IsPlaying ? "⏸" : "▶";
            btnPlayPause.BackColor = player.IsPlaying 
                ? Color.FromArgb(0, 150, 136) 
                : Color.FromArgb(30, 144, 255);
        }

        private void UpdateSongInfo()
        {
            if (player.CurrentSong != null)
            {
                lblSongTitle.Text = player.CurrentSong.Title;
                lblArtistName.Text = player.CurrentSong.ArtistName;

                // Load cover image
                if (!string.IsNullOrEmpty(player.CurrentSong.CoverImage) 
                    && System.IO.File.Exists(player.CurrentSong.CoverImage))
                {
                    try
                    {
                        var oldImage = pictureBoxCover.Image;
                        pictureBoxCover.Image = Image.FromFile(player.CurrentSong.CoverImage);
                        oldImage?.Dispose();
                    }
                    catch
                    {
                        pictureBoxCover.Image = CreateDefaultCover();
                    }
                }
                else
                {
                    pictureBoxCover.Image = CreateDefaultCover();
                }

                // Update total time
                lblTotalTime.Text = player.TotalTime.ToMinutesSeconds();
                trackBarSeek.Value = 0;
                lblCurrentTime.Text = "0:00";
            }
            else
            {
                lblSongTitle.Text = "Chưa có bài hát";
                lblArtistName.Text = "";
                lblCurrentTime.Text = "0:00";
                lblTotalTime.Text = "0:00";
                pictureBoxCover.Image = CreateDefaultCover();
            }
        }

        private void UpdateTimeLabels()
        {
            lblCurrentTime.Text = player.CurrentTime.ToMinutesSeconds();
            lblTotalTime.Text = player.TotalTime.ToMinutesSeconds();
        }

        private void UpdateSeekBar()
        {
            if (player.TotalTime.TotalSeconds > 0)
            {
                int value = (int)(player.GetPositionPercent() * trackBarSeek.Maximum);
                trackBarSeek.Value = Math.Min(value, trackBarSeek.Maximum);
            }
        }

        private void UpdateVolumeIcon()
        {
            if (player.Volume == 0)
                btnMute.Text = "🔇";
            else if (player.Volume < 0.5f)
                btnMute.Text = "🔉";
            else
                btnMute.Text = "🔊";
        }

        #endregion

        #region Helper Methods

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(50, 50, 70));
                g.DrawString("♪", new Font("Arial", 36), Brushes.White, new PointF(30, 20));
            }
            return bmp;
        }

        /// <summary>
        /// Public method để load và play bài hát từ bên ngoài
        /// </summary>
        public void LoadAndPlaySong(Song song)
        {
            bool success = player.LoadAndPlay(song);

            if (success)
            {
                UpdateUI();
                UpdateSongInfo();
            }
            else
            {
                MessageBox.Show("Không thể phát bài hát này!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (updateTimer != null)
                {
                    updateTimer.Stop();
                    updateTimer.Dispose();
                }

                pictureBoxCover?.Image?.Dispose();

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}