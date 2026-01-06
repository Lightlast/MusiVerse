using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.BLL.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucSongDetailPage : UserControl
    {
        private Song _currentSong;
        private SongRepository _songRepository;
        private int _currentUserID;
        private PlaylistService _playlistService;

        public event EventHandler OnPlayClicked;
        public event EventHandler OnAddToPlaylistClicked;
        public event EventHandler OnArtistClicked;

        public ucSongDetailPage()
        {
            InitializeComponent();
            _songRepository = new SongRepository();
            _playlistService = new PlaylistService();
        }

        public void LoadSong(Song song, int currentUserID)
        {
            _currentSong = song;
            _currentUserID = currentUserID;
            LoadSongDetails();
            LoadArtistSongs();
            LoadArtistAlbums();
        }

        private void LoadSongDetails()
        {
            if (_currentSong == null) return;

            lblSongTitle.Text = _currentSong.Title;
            lblArtistName.Text = _currentSong.ArtistName;
            lblGenre.Text = $"🎵 {_currentSong.Genre}";
            lblDuration.Text = $"⏱ {TimeSpan.FromSeconds(_currentSong.Duration):mm\\:ss}";
            lblPlayCount.Text = $"▶ {_currentSong.PlayCount} lượt nghe";
            lblReleaseDate.Text = $"📅 {_currentSong.ReleaseDate:dd/MM/yyyy}";

            btnLike.Text = _currentSong.IsLiked ? "❤️ Đã thích" : "🤍 Thích";

            if (!string.IsNullOrEmpty(_currentSong.CoverImage) && System.IO.File.Exists(_currentSong.CoverImage))
            {
                try
                {
                    pbSongCover.Image = Image.FromFile(_currentSong.CoverImage);
                }
                catch
                {
                    pbSongCover.Image = CreateDefaultCover();
                }
            }
            else
            {
                pbSongCover.Image = CreateDefaultCover();
            }
        }

        private void LoadArtistSongs()
        {
            try
            {
                pnlArtistSongs.Controls.Clear();
                List<Song> artistSongs = _songRepository.GetSongsByArtist(_currentSong.ArtistID, _currentUserID);

                if (artistSongs.Count == 0)
                {
                    Label lblNoSongs = new Label() 
                    { 
                        Text = "Chưa có bài hát nào",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.Gray
                    };
                    pnlArtistSongs.Controls.Add(lblNoSongs);
                    return;
                }

                int displayCount = Math.Min(5, artistSongs.Count);
                foreach (var song in artistSongs.GetRange(0, displayCount))
                {
                    if (song.SongID != _currentSong.SongID)
                    {
                        var songItem = new ucSongItem(song);
                        songItem.Dock = DockStyle.Top;
                        songItem.Height = 80;
                        songItem.OnPlayClicked += (s, ev) => OnPlayClicked?.Invoke(songItem, EventArgs.Empty);
                        pnlArtistSongs.Controls.Add(songItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài hát: " + ex.Message);
            }
        }

        private void LoadArtistAlbums()
        {
            try
            {
                pnlArtistAlbums.Controls.Clear();

                // TODO: Implement album loading when Album table is created
                for (int i = 0; i < 4; i++)
                {
                    var albumCard = new PictureBox()
                    {
                        Width = 150,
                        Height = 150,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Margin = new Padding(10),
                        Cursor = Cursors.Hand,
                        Image = CreateDefaultCover()
                    };

                    albumCard.Click += (s, ev) => OnArtistClicked?.Invoke(albumCard, EventArgs.Empty);
                    pnlArtistAlbums.Controls.Add(albumCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải album: " + ex.Message);
            }
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("♪", new Font("Arial", 48), Brushes.White, new PointF(40, 35));
            }
            return bmp;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnPlayClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddToPlaylist_Click(object sender, EventArgs e)
        {
            if (_currentSong == null) return;

            try
            {
                var playlists = _playlistService.GetUserPlaylists(_currentUserID);
                if (playlists.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có playlist nào. Tạo playlist trước!", "Thông báo");
                    return;
                }

                using (Form form = new Form())
                {
                    form.Text = "Chọn Playlist";
                    form.Width = 300;
                    form.Height = 300;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;

                    ListBox listBox = new ListBox
                    {
                        Dock = DockStyle.Top,
                        Height = 200
                    };

                    foreach (var playlist in playlists)
                    {
                        listBox.Items.Add(playlist);
                        listBox.DisplayMember = "Name";
                    }

                    Button btnOK = new Button
                    {
                        Text = "Thêm",
                        Width = 80,
                        Height = 30,
                        Location = new Point(60, 210)
                    };

                    Button btnCancel = new Button
                    {
                        Text = "Hủy",
                        Width = 80,
                        Height = 30,
                        Location = new Point(160, 210)
                    };

                    btnOK.Click += (s, ev) =>
                    {
                        if (listBox.SelectedItem is Playlist selectedPlaylist)
                        {
                            if (_playlistService.AddSongToPlaylist(selectedPlaylist.PlaylistID, _currentSong.SongID))
                            {
                                MessageBox.Show("Bài hát đã được thêm vào playlist!", "Thành công");
                                form.Close();
                            }
                            else
                            {
                                MessageBox.Show("Bài hát đã tồn tại trong playlist này!", "Thông báo");
                            }
                        }
                    };

                    btnCancel.Click += (s, ev) => form.Close();

                    form.Controls.Add(listBox);
                    form.Controls.Add(btnOK);
                    form.Controls.Add(btnCancel);

                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            OnAddToPlaylistClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            if (_currentSong != null)
            {
                _currentSong.IsLiked = !_currentSong.IsLiked;
                btnLike.Text = _currentSong.IsLiked ? "❤️ Đã thích" : "🤍 Thích";
            }
        }

        private void lblArtistName_Click(object sender, EventArgs e)
        {
            OnArtistClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
