using MusiVerse.DTO.Models;
using MusiVerse.BLL.Services;
using MusiVerse.GUI.Utils;
using MusiVerse.GUI.UserControls;
using MusiVerse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Music
{
    public partial class frmPlaylistManager : Form
    {
        private PlaylistService _playlistService;
        private SongRepository _songRepository;
        private int _currentUserID;
        private Playlist _currentPlaylist;
        private List<Song> _currentPlaylistSongs;
        private List<ucSongItem> _songItemControls;

        public frmPlaylistManager()
        {
            InitializeComponent();
            _playlistService = new PlaylistService();
            _songRepository = new SongRepository();
            _currentUserID = SessionManager.CurrentUser?.UserID ?? 0;
            _currentPlaylistSongs = new List<Song>();
            _songItemControls = new List<ucSongItem>();
        }

        private void frmPlaylistManager_Load(object sender, EventArgs e)
        {
            LoadPlaylists();
        }

        private void LoadPlaylists()
        {
            try
            {
                pnlPlaylists.Controls.Clear();
                var playlists = _playlistService.GetUserPlaylists(_currentUserID);

                if (playlists.Count == 0)
                {
                    Label lblEmpty = new Label()
                    {
                        Text = "Bạn chưa tạo playlist nào. Hãy tạo một playlist mới!",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(300, 200)
                    };
                    pnlPlaylists.Controls.Add(lblEmpty);
                    return;
                }

                FlowLayoutPanel flowPanel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true
                };

                foreach (var playlist in playlists)
                {
                    var playlistCard = CreatePlaylistCard(playlist);
                    flowPanel.Controls.Add(playlistCard);
                }

                pnlPlaylists.Controls.Add(flowPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreatePlaylistCard(Playlist playlist)
        {
            Panel card = new Panel()
            {
                Width = 200,
                Height = 240,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            PictureBox pbCover = new PictureBox()
            {
                Width = 190,
                Height = 120,
                Location = new Point(5, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = CreateDefaultCover()
            };

            Label lblName = new Label()
            {
                Text = playlist.Name,
                Location = new Point(5, 130),
                Width = 190,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };

            Label lblCount = new Label()
            {
                Text = $"{playlist.SongCount} bài hát",
                Location = new Point(5, 160),
                Width = 190,
                Height = 20,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };

            Label lblVisibility = new Label()
            {
                Text = playlist.IsPublic ? "🌍 Công khai" : "🔒 Riêng tư",
                Location = new Point(5, 180),
                Width = 190,
                Height = 15,
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.DarkGreen,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };

            Button btnEdit = new Button()
            {
                Text = "✎ Sửa",
                Location = new Point(5, 200),
                Size = new Size(60, 30),
                BackColor = Color.FromArgb(100, 150, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnDelete = new Button()
            {
                Text = "🗑 Xóa",
                Location = new Point(70, 200),
                Size = new Size(60, 30),
                BackColor = Color.FromArgb(200, 50, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            Button btnPlay = new Button()
            {
                Text = "▶ Phát",
                Location = new Point(135, 200),
                Size = new Size(60, 30),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            card.Controls.Add(pbCover);
            card.Controls.Add(lblName);
            card.Controls.Add(lblCount);
            card.Controls.Add(lblVisibility);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);
            card.Controls.Add(btnPlay);

            // Events
            card.Click += (s, e) =>
            {
                _currentPlaylist = playlist;
                LoadPlaylistSongs(playlist.PlaylistID);
                tabControl.SelectedTab = tabSongsInPlaylist;
            };

            btnEdit.Click += (s, e) =>
            {
                EditPlaylist(playlist);
            };

            btnDelete.Click += (s, e) =>
            {
                DeletePlaylist(playlist);
            };

            btnPlay.Click += (s, e) =>
            {
                PlayPlaylist(playlist);
            };

            return card;
        }

        private void LoadPlaylistSongs(int playlistID)
        {
            try
            {
                pnlPlaylistSongs.Controls.Clear();
                _songItemControls.Clear();

                // Thông tin playlist
                Panel pnlHeader = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 60,
                    BackColor = Color.FromArgb(240, 240, 240),
                    Padding = new Padding(10)
                };

                Label lblPlaylistInfo = new Label()
                {
                    Text = $"📝 {_currentPlaylist.Name}",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblSongCount = new Label()
                {
                    Text = $"({_currentPlaylist.SongCount} bài hát)",
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(300, 15),
                    ForeColor = Color.Gray,
                    AutoSize = true
                };

                pnlHeader.Controls.Add(lblPlaylistInfo);
                pnlHeader.Controls.Add(lblSongCount);
                pnlPlaylistSongs.Controls.Add(pnlHeader);

                // Control buttons
                Panel pnlControls = new Panel()
                {
                    Dock = DockStyle.Top,
                    Height = 50,
                    Padding = new Padding(10)
                };

                Button btnAddSong = new Button()
                {
                    Text = "➕ Thêm Bài Hát",
                    Location = new Point(10, 5),
                    Size = new Size(120, 35),
                    BackColor = Color.FromArgb(100, 150, 50),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                Button btnEditPlaylist = new Button()
                {
                    Text = "✎ Sửa Playlist",
                    Location = new Point(140, 5),
                    Size = new Size(120, 35),
                    BackColor = Color.FromArgb(100, 150, 200),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                Button btnPlayAll = new Button()
                {
                    Text = "▶ Phát Tất Cả",
                    Location = new Point(270, 5),
                    Size = new Size(120, 35),
                    BackColor = Color.FromArgb(0, 150, 136),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                btnAddSong.Click += (s, e) => OpenPlaylistEditor(_currentPlaylist);
                btnEditPlaylist.Click += (s, e) => EditPlaylist(_currentPlaylist);
                btnPlayAll.Click += (s, e) => PlayPlaylist(_currentPlaylist);

                pnlControls.Controls.Add(btnAddSong);
                pnlControls.Controls.Add(btnEditPlaylist);
                pnlControls.Controls.Add(btnPlayAll);
                pnlPlaylistSongs.Controls.Add(pnlControls);

                // Load songs
                _currentPlaylistSongs = _playlistService.GetPlaylistSongs(playlistID);

                if (_currentPlaylistSongs.Count == 0)
                {
                    Label lblEmpty = new Label()
                    {
                        Text = "Playlist này chưa có bài hát nào",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(300, 150)
                    };
                    pnlPlaylistSongs.Controls.Add(lblEmpty);
                    return;
                }

                FlowLayoutPanel flowPanel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(5)
                };

                foreach (var song in _currentPlaylistSongs)
                {
                    var songItem = new ucSongItem(song);
                    songItem.Dock = DockStyle.Top;
                    songItem.Height = 80;
                    songItem.OnPlayClicked += (s, e) => PlaySong(song);
                    _songItemControls.Add(songItem);
                    flowPanel.Controls.Add(songItem);
                }

                pnlPlaylistSongs.Controls.Add(flowPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPlaylist(Playlist playlist)
        {
            frmPlaylistEditor editorForm = new frmPlaylistEditor();
            editorForm.LoadPlaylistForEdit(playlist, _currentUserID);

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylists();
                if (_currentPlaylist?.PlaylistID == playlist.PlaylistID)
                {
                    LoadPlaylistSongs(playlist.PlaylistID);
                }
            }
        }

        private void OpenPlaylistEditor(Playlist playlist)
        {
            frmPlaylistEditor editorForm = new frmPlaylistEditor();
            editorForm.LoadPlaylistForEdit(playlist, _currentUserID);

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylistSongs(playlist.PlaylistID);
            }
        }

        private void DeletePlaylist(Playlist playlist)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa playlist '{playlist.Name}' không?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_playlistService.DeletePlaylist(playlist.PlaylistID))
                    {
                        MessageBox.Show("Playlist đã được xóa thành công!", "Thành công");
                        LoadPlaylists();

                        if (_currentPlaylist?.PlaylistID == playlist.PlaylistID)
                        {
                            pnlPlaylistSongs.Controls.Clear();
                            _currentPlaylist = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa playlist", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PlayPlaylist(Playlist playlist)
        {
            try
            {
                var songs = _playlistService.GetPlaylistSongs(playlist.PlaylistID);
                if (songs.Count == 0)
                {
                    MessageBox.Show("Playlist này không có bài hát nào", "Thông báo");
                    return;
                }

                // Phát bài hát đầu tiên
                PlaySong(songs[0]);
                MessageBox.Show($"Đang phát playlist '{playlist.Name}'", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void PlaySong(Song song)
        {
            try
            {
                var musicService = BLL.Services.MusicPlayerService.Instance;
                if (musicService.LoadAndPlay(song))
                {
                    MessageBox.Show($"Đang phát: {song.Title}", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không thể phát bài hát này", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private Image CreateDefaultCover()
        {
            Bitmap bmp = new Bitmap(190, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("♪", new Font("Arial", 40), Brushes.White, new PointF(70, 30));
            }
            return bmp;
        }

        private void btnNewPlaylist_Click(object sender, EventArgs e)
        {
            frmPlaylistEditor editorForm = new frmPlaylistEditor();
            editorForm.Initialize(_currentUserID);

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylists();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPlaylists();
        }
    }
}
