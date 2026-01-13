using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucSongDetail : UserControl
    {
        private Song currentSong;
        private SongRepository songRepository;
        private AlbumRepository albumRepository;
        private int currentUserID;

        public event EventHandler OnPlaySongClicked;
        public event EventHandler OnLikeSongClicked;
        public event EventHandler OnEditSongClicked;
        public event EventHandler<Song> OnSongSelected; // Event khi click vào bài hát trong featured songs
        public event EventHandler<Album> OnAlbumSelected; // Event khi click vào album

        public ucSongDetail()
        {
            InitializeComponent();
            songRepository = new SongRepository();
            albumRepository = new AlbumRepository();
            currentUserID = SessionManager.GetCurrentUserID();
        }

        public void LoadSongDetail(Song song)
        {
            if (song == null) return;

            currentSong = song;
            
            // Set section titles
            lblFeaturedSongsTitle.Text = "?? Bài hát n?i b?t c?a " + currentSong.ArtistName;
            lblAlbumsTitle.Text = "?? Album n?i b?t c?a " + currentSong.ArtistName;
            
            LoadSongInfo();
            LoadArtistFeaturedSongs();
            LoadArtistAlbums();
        }

        #region Section 1: Song Information

        private void LoadSongInfo()
        {
            // Load cover image
            if (!string.IsNullOrEmpty(currentSong.CoverImage) && System.IO.File.Exists(currentSong.CoverImage))
            {
                try
                {
                    pbCover.Image = Image.FromFile(currentSong.CoverImage);
                }
                catch
                {
                    pbCover.Image = CreateDefaultCover();
                }
            }
            else
            {
                pbCover.Image = CreateDefaultCover();
            }

            // Song information
            lblTitle.Text = currentSong.Title;
            lblArtist.Text = $"Ngh? s?: {currentSong.ArtistName}";
            lblGenre.Text = $"Th? lo?i: {currentSong.Genre}";
            lblReleaseDate.Text = $"Ngày phát hành: {currentSong.ReleaseDate:dd/MM/yyyy}";
            lblDuration.Text = $"Th?i l??ng: {FormatDuration(currentSong.Duration)}";
            lblPlayCount.Text = $"? {currentSong.PlayCount:N0} l??t nghe";

            // Update like button
            btnLike.Text = currentSong.IsLiked ? "?? Yêu thích" : "?? Yêu thích";
            btnLike.BackColor = currentSong.IsLiked ? Color.FromArgb(220, 53, 69) : Color.FromArgb(108, 117, 125);

            // Show/hide edit button
            btnDowload.Visible = currentSong.ArtistID == currentUserID && 
                             (SessionManager.CurrentUser?.Role == "Artist" || SessionManager.CurrentUser?.Role == "IndieArtist");
        }

        #endregion

        #region Section 2: Artist Featured Songs

        private void LoadArtistFeaturedSongs()
        {
            flowPanelFeaturedSongs.Controls.Clear();

            List<Song> artistSongs = songRepository.GetSongsByArtist(currentSong.ArtistID, currentUserID);
            artistSongs.RemoveAll(s => s.SongID == currentSong.SongID);
            
            if (artistSongs.Count > 5)
            {
                artistSongs = artistSongs.GetRange(0, 5);
            }

            if (artistSongs.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có bài hát n?i b?t nào",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    AutoSize = true
                };
                flowPanelFeaturedSongs.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var song in artistSongs)
                {
                    Panel songCard = CreateFeaturedSongCard(song);
                    flowPanelFeaturedSongs.Controls.Add(songCard);
                }
            }
        }

        private Panel CreateFeaturedSongCard(Song song)
        {
            Panel card = new Panel
            {
                Size = new Size(180, 240),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = song
            };

            PictureBox pbCover = new PictureBox
            {
                Size = new Size(160, 160),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None
            };

            if (!string.IsNullOrEmpty(song.CoverImage) && System.IO.File.Exists(song.CoverImage))
            {
                try
                {
                    pbCover.Image = Image.FromFile(song.CoverImage);
                }
                catch
                {
                    pbCover.Image = CreateDefaultCover();
                }
            }
            else
            {
                pbCover.Image = CreateDefaultCover();
            }

            Label lblTitle = new Label
            {
                Text = song.Title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(5, 175),
                Size = new Size(170, 30),
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false
            };
            
            Label lblPlayCount = new Label
            {
                Text = $"? {song.PlayCount:N0}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(5, 210),
                Size = new Size(170, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                AutoSize = false
            };

            card.Controls.Add(pbCover);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblPlayCount);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(245, 245, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            card.Click += (s, e) => OnSongSelected?.Invoke(this, song);
            pbCover.Click += (s, e) => OnSongSelected?.Invoke(this, song);
            lblTitle.Click += (s, e) => OnSongSelected?.Invoke(this, song);
            lblPlayCount.Click += (s, e) => OnSongSelected?.Invoke(this, song);

            return card;
        }

        #endregion

        #region Section 3: Artist Albums

        private void LoadArtistAlbums()
        {
            flowPanelAlbums.Controls.Clear();

            List<Album> artistAlbums = albumRepository.GetAlbumsByArtist(currentSong.ArtistID);
            
            if (artistAlbums.Count > 5)
            {
                artistAlbums = artistAlbums.GetRange(0, 5);
            }

            if (artistAlbums.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có album n?i b?t nào",
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    AutoSize = true
                };
                flowPanelAlbums.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var album in artistAlbums)
                {
                    Panel albumCard = CreateAlbumCard(album);
                    flowPanelAlbums.Controls.Add(albumCard);
                }
            }
        }

        private Panel CreateAlbumCard(Album album)
        {
            Panel card = new Panel
            {
                Size = new Size(200, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = album
            };

            PictureBox pbCover = new PictureBox
            {
                Size = new Size(180, 180),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None
            };

            if (!string.IsNullOrEmpty(album.CoverImage) && System.IO.File.Exists(album.CoverImage))
            {
                try
                {
                    pbCover.Image = Image.FromFile(album.CoverImage);
                }
                catch
                {
                    pbCover.Image = CreateDefaultAlbumCover();
                }
            }
            else
            {
                pbCover.Image = CreateDefaultAlbumCover();
            }

            Label lblTitle = new Label
            {
                Text = album.Title,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(5, 195),
                Size = new Size(190, 40),
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false
            };

            Label lblSongCount = new Label
            {
                Text = $"?? {album.SongCount} bài hát",
                Font = new Font("Segoe UI", 9),
                Location = new Point(5, 240),
                Size = new Size(190, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                AutoSize = false
            };

            Label lblReleaseDate = new Label
            {
                Text = album.ReleaseDate.ToString("MMM yyyy"),
                Font = new Font("Segoe UI", 9),
                Location = new Point(5, 265),
                Size = new Size(190, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGray,
                AutoSize = false
            };

            card.Controls.Add(pbCover);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblSongCount);
            card.Controls.Add(lblReleaseDate);

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(245, 245, 250);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;
            card.Click += (s, e) => OnAlbumSelected?.Invoke(this, album);
            pbCover.Click += (s, e) => OnAlbumSelected?.Invoke(this, album);
            lblTitle.Click += (s, e) => OnAlbumSelected?.Invoke(this, album);

            return card;
        }

        #endregion

        #region Button Events

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnPlaySongClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            currentSong.IsLiked = !currentSong.IsLiked;
            btnLike.Text = currentSong.IsLiked ? "?? Yêu thích" : "?? Yêu thích";
            btnLike.BackColor = currentSong.IsLiked ? Color.FromArgb(220, 53, 69) : Color.FromArgb(108, 117, 125);
            OnLikeSongClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnEditSongClicked?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Helper Methods

        private string FormatDuration(int seconds)
        {
            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            return ts.Hours > 0 ? ts.ToString(@"hh\:mm\:ss") : ts.ToString(@"mm\:ss");
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(300, 300);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("?", new Font("Arial", 120), Brushes.White, new PointF(60, 70));
            }
            return bmp;
        }

        private Image CreateDefaultAlbumCover()
        {
            Bitmap bmp = new Bitmap(180, 180);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("??", new Font("Arial", 80), Brushes.White, new PointF(15, 30));
            }
            return bmp;
        }

        #endregion

        private void ucSongDetail_Load(object sender, EventArgs e)
        {
        }
    }
}
