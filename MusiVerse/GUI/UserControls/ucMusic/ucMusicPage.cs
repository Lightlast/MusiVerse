using MusiVerse.BLL.Services;
using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Forms.Music;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucMusicPage : System.Windows.Forms.UserControl
    {
        private SongRepository songRepository;
        private PlaylistService playlistService;
        private System.Windows.Forms.Button currentFilterButton;

        // Event để thông báo cho frmMain khi play song
        public event EventHandler<Song> OnSongRequested;
        public event EventHandler<Song> OnShowSongDetail; // Event mới để hiển thị chi tiết bài hát
        public event EventHandler<Playlist> OnShowPlaylistDetail; // Event mới để hiển thị chi tiết playlist

        public ucMusicPage()
        {
            InitializeComponent();
            songRepository = new SongRepository();
            playlistService = new PlaylistService();
        }

        private void ucMusicPage_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadAllSongs();
        }

        private void SetupUI()
        {
            SelectFilterButton(btnAllSongs);

            if (cmbGenre.Items.Count > 0) cmbGenre.SelectedIndex = 0;
            if (cmbSort.Items.Count > 0) cmbSort.SelectedIndex = 0;

            if (SessionManager.IsArtist() || SessionManager.IsAdmin())
            {
                btnUploadMS.Visible = true;
            }
            else
            {
                btnUploadMS.Visible = false;
            }

            // Hide btnNewPlaylist by default
            btnNewPlaylist.Visible = false;
            btnNewPlaylist.Click += btnNewPlaylist_Click;
        }

        private void OpenUploadForm()
        {
            frmUploadSong uploadForm = new frmUploadSong();

            if (uploadForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "✓ Upload thành công!\nBài hát đã được thêm vào thư viện.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                LoadAllSongs();
            }
        }

        #region Filter Buttons

        private void btnAllSongs_Click(object sender, EventArgs e)
        {
            SelectFilterButton(btnAllSongs);
            btnNewPlaylist.Visible = false;
            LoadAllSongs();
        }

        private void btnLikedSongs_Click(object sender, EventArgs e)
        {
            SelectFilterButton(btnLikedSongs);
            btnNewPlaylist.Visible = false;
            LoadLikedSongs();
        }

        private void btnMyPlaylists_Click(object sender, EventArgs e)
        {
            SelectFilterButton(btnMyPlaylists);
            btnNewPlaylist.Visible = true;
            LoadMyPlaylists();
        }

        private void btnRecentPlayed_Click(object sender, EventArgs e)
        {
            SelectFilterButton(btnRecentPlayed);
            btnNewPlaylist.Visible = false;
            LoadRecentPlayed();
        }

        private void SelectFilterButton(System.Windows.Forms.Button button)
        {
            if (currentFilterButton != null)
            {
                currentFilterButton.BackColor = Color.Transparent;
                currentFilterButton.ForeColor = Color.White;
            }

            button.BackColor = Color.FromArgb(30, 144, 255);
            button.ForeColor = Color.White;
            currentFilterButton = button;
        }

        #endregion

        #region Search & Filter

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadAllSongs();
            }
            else
            {
                SearchSongs(keyword);
            }
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGenre.SelectedIndex > 0)
            {
                string genre = cmbGenre.SelectedItem.ToString();
                FilterByGenre(genre);
            }
            else
            {
                LoadAllSongs();
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSort.SelectedIndex > 0)
            {
                string sortOption = cmbSort.SelectedItem.ToString();
                SortSongs(sortOption);
            }
        }

        #endregion

        #region Load Data

        private void LoadAllSongs()
        {
            ClearSongList();

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var songs = songRepository.GetAllSongs(currentUserID);

                if (songs.Count == 0)
                {
                    ShowEmptyMessage("Chưa có bài hát nào trong thư viện");
                    return;
                }

                PopulateSongList(songs);
                lblSongCount.Text = $"{songs.Count} bài hát";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bài hát: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLikedSongs()
        {
            ClearSongList();

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var songs = songRepository.GetLikedSongs(currentUserID);

                if (songs.Count == 0)
                {
                    ShowEmptyMessage("Bạn chưa có bài hát yêu thích nào");
                    return;
                }

                PopulateSongList(songs);
                lblSongCount.Text = $"{songs.Count} bài hát yêu thích";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bài hát: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyPlaylists()
        {
            ClearSongList();

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                List<Playlist> playlists = playlistService.GetUserPlaylists(currentUserID);

                if (playlists.Count == 0)
                {
                    ShowEmptyMessage("Bạn chưa có playlist nào. Tạo playlist mới để bắt đầu!");
                    lblSongCount.Text = "0 playlist";
                    return;
                }

                PopulatePlaylistList(playlists);
                lblSongCount.Text = $"{playlists.Count} playlist";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load playlist: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentPlayed()
        {
            ClearSongList();
            btnNewPlaylist.Visible = false;

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var songs = songRepository.GetRecentPlayedSongs(currentUserID);

                if (songs.Count == 0)
                {
                    ShowEmptyMessage("Bạn chưa nghe bài hát nào gần đây");
                    lblSongCount.Text = "0 bài hát";
                    return;
                }

                PopulateSongList(songs);
                lblSongCount.Text = $"{songs.Count} bài hát được nghe gần đây";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load lịch sử nghe: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchSongs(string keyword)
        {
            ClearSongList();

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var songs = songRepository.SearchSongs(keyword, currentUserID);

                if (songs.Count == 0)
                {
                    ShowEmptyMessage($"Không tìm thấy kết quả cho '{keyword}'");
                    return;
                }

                PopulateSongList(songs);
                lblSongCount.Text = $"{songs.Count} kết quả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterByGenre(string genre)
        {
            ClearSongList();

            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var allSongs = songRepository.GetAllSongs(currentUserID);
                var filteredSongs = (genre == "Tất cả thể loại")
                                    ? allSongs
                                    : allSongs.FindAll(s => s.Genre == genre);

                if (filteredSongs.Count == 0)
                {
                    ShowEmptyMessage($"Không có bài hát nào thuộc thể loại '{genre}'");
                    return;
                }

                PopulateSongList(filteredSongs);
                lblSongCount.Text = $"{filteredSongs.Count} bài hát - {genre}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc bài hát: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateSongList(System.Collections.Generic.List<Song> songs)
        {
            foreach (var song in songs)
            {
                ucSongItem item = new ucSongItem(song);

                item.OnPlayClicked += OnSongPlayClicked;
                item.OnLikeClicked += (s, e) => OnSongLikeClicked(item, song);
                item.OnMoreClicked += (s, e) => ShowSongOptions(song, item.btnMore);
                item.OnSongTitleClicked += (s, e) => ShowSongDetail(song);

                flowPanelSongs.Controls.Add(item);
            }
        }

        private void PopulatePlaylistList(List<Playlist> playlists)
        {
            foreach (var playlist in playlists)
            {
                ucPlaylistItem item = new ucPlaylistItem(playlist);

                item.OnPlayClicked += (s, e) => PlayPlaylist(playlist);
                item.OnEditClicked += (s, e) => EditPlaylist(playlist);
                item.OnDeleteClicked += (s, e) => DeletePlaylist(playlist);
                item.OnPlaylistSelected += (s, p) => ViewPlaylistDetail(playlist);

                flowPanelSongs.Controls.Add(item);
            }
        }

        private void OnSongPlayClicked(object sender, EventArgs e)
        {
            if (sender is ucSongItem item && item.SongData != null)
            {
                PlaySong(item.SongData);
            }
        }

        private void OnSongLikeClicked(ucSongItem item, Song song)
        {
            int userID = SessionManager.GetCurrentUserID();

            if (song.IsLiked)
            {
                if (songRepository.UnlikeSong(userID, song.SongID))
                {
                    item.UpdateLikeStatus(false);
                    MessageBox.Show("Đã xóa khỏi yêu thích", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (songRepository.LikeSong(userID, song.SongID))
                {
                    item.UpdateLikeStatus(true);
                    MessageBox.Show("Đã thêm vào yêu thích", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearSongList()
        {
            foreach (Control control in flowPanelSongs.Controls)
            {
                if (control is ucSongItem item)
                {
                    item.OnPlayClicked -= OnSongPlayClicked;
                    item.Dispose();
                }
            }
            flowPanelSongs.Controls.Clear();
        }

        private void ShowEmptyMessage(string message)
        {
            System.Windows.Forms.Label lblEmpty = new System.Windows.Forms.Label
            {
                Text = message,
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(300, 200)
            };
            flowPanelSongs.Controls.Add(lblEmpty);
        }

        #endregion

        #region Actions

        private void PlaySong(Song song)
        {
            bool isPlaying = MusicPlayerService.Instance.LoadAndPlay(song);

            if (isPlaying)
            {
                songRepository.IncrementPlayCount(song.SongID);
                OnSongRequested?.Invoke(this, song);
            }
        }

        private void PlayPlaylist(Playlist playlist)
        {
            try
            {
                List<Song> playlistSongs = playlistService.GetPlaylistSongs(playlist.PlaylistID);
                if (playlistSongs.Count > 0)
                {
                    PlaySong(playlistSongs[0]);
                    MessageBox.Show($"Đang phát playlist '{playlist.Name}'", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Playlist này không có bài hát nào", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPlaylist(Playlist playlist)
        {
            try
            {
                frmPlaylistEditor editor = new frmPlaylistEditor();
                editor.LoadPlaylistForEdit(playlist, SessionManager.GetCurrentUserID());

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadMyPlaylists();
                    MessageBox.Show("Playlist đã được cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa playlist: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePlaylist(Playlist playlist)
        {
            try
            {
                if (playlistService.DeletePlaylist(playlist.PlaylistID))
                {
                    LoadMyPlaylists();
                    MessageBox.Show("Playlist đã được xóa!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa playlist", "Lưu ý",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa playlist: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSongOptions(Song song, System.Windows.Forms.Button btnMore)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("▶ Phát ngay", null, (s, e) => PlaySong(song));
            menu.Items.Add("➕ Thêm vào playlist", null, (s, e) => AddToPlaylist(song));
            menu.Items.Add("ℹ️ Thông tin bài hát", null, (s, e) => ShowSongInfo(song));

            if (SessionManager.IsArtist() && song.ArtistID == SessionManager.GetCurrentUserID())
            {
                menu.Items.Add(new ToolStripSeparator());
                menu.Items.Add("✏️ Chỉnh sửa", null, (s, e) => EditSong(song));
                menu.Items.Add("🗑️ Xóa", null, (s, e) => DeleteSong(song));
            }

            menu.Show(btnMore, new Point(0, btnMore.Height));
        }

        private void AddToPlaylist(Song song)
        {
            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                List<Playlist> userPlaylists = playlistService.GetUserPlaylists(currentUserID);

                if (userPlaylists.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có playlist nào. Vui lòng tạo playlist trước!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create a dialog to select playlist
                Form playlistSelectForm = new Form
                {
                    Text = $"Thêm '{song.Title}' vào Playlist",
                    Size = new System.Drawing.Size(400, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                ListBox lstPlaylists = new ListBox
                {
                    Dock = DockStyle.Top,
                    Height = 200
                };

                foreach (var playlist in userPlaylists)
                {
                    lstPlaylists.Items.Add(playlist);
                    lstPlaylists.DisplayMember = "Name";
                }

                Panel panelButtons = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = Color.WhiteSmoke
                };

                Button btnAdd = new Button
                {
                    Text = "Thêm",
                    Location = new Point(100, 10),
                    Size = new Size(80, 30),
                    BackColor = Color.FromArgb(0, 150, 136),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand
                };

                Button btnCancel = new Button
                {
                    Text = "Hủy",
                    Location = new Point(200, 10),
                    Size = new Size(80, 30),
                    BackColor = Color.FromArgb(108, 117, 125),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand
                };

                btnAdd.Click += (s, e) =>
                {
                    if (lstPlaylists.SelectedItem is Playlist selectedPlaylist)
                    {
                        playlistService.AddSongToPlaylist(selectedPlaylist.PlaylistID, song.SongID);
                        MessageBox.Show($"✓ Đã thêm '{song.Title}' vào playlist '{selectedPlaylist.Name}'", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        playlistSelectForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một playlist!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                btnCancel.Click += (s, e) => playlistSelectForm.Close();

                panelButtons.Controls.Add(btnAdd);
                panelButtons.Controls.Add(btnCancel);

                playlistSelectForm.Controls.Add(panelButtons);
                playlistSelectForm.Controls.Add(lstPlaylists);

                playlistSelectForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSongInfo(Song song)
        {
            string info = $"Tên bài hát: {song.Title}\n" +
                         $"Nghệ sĩ: {song.ArtistName}\n" +
                         $"Thể loại: {song.Genre ?? "N/A"}\n" +
                         $"Thời lượng: {FormatDuration(song.Duration)}\n" +
                         $"Lượt nghe: {song.PlayCount}\n" +
                         $"Ngày phát hành: {song.ReleaseDate:dd/MM/yyyy}";

            MessageBox.Show(info, "Thông tin bài hát",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Hiển thị chi tiết bài hát trong một form riêng
        /// </summary>
        private void ShowSongDetail(Song song)
        {
            try
            {
                OnShowSongDetail?.Invoke(this, song);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết bài hát: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format thời lượng từ giây thành MM:SS hoặc HH:MM:SS
        /// </summary>
        private string FormatDuration(int seconds)
        {
            TimeSpan ts = TimeSpan.FromSeconds(seconds);
            
            if (ts.Hours > 0)
                return ts.ToString(@"hh\:mm\:ss");
            else
                return ts.ToString(@"mm\:ss");
        }

        private void EditSong(Song song)
        {
            try
            {
                frmEditSong editForm = new frmEditSong(song);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllSongs();
                    MessageBox.Show("Bài hát đã được cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa bài hát: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSong(Song song)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa bài hát '{song.Title}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                if (songRepository.DeleteSong(song.SongID))
                {
                    MessageBox.Show("Đã xóa bài hát", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllSongs();
                }
            }
        }

        private void btnNewPlaylist_Click(object sender, EventArgs e)
        {
            try
            {
                frmPlaylistEditor editor = new frmPlaylistEditor();
                editor.Initialize(SessionManager.GetCurrentUserID());

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadMyPlaylists();
                    MessageBox.Show("Playlist mới đã được tạo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo playlist: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                frmCreateAlbum createAlbumForm = new frmCreateAlbum();

                if (createAlbumForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAllSongs();
                    MessageBox.Show(
                        "✓ Album đã được tạo thành công!\nAlbum của bạn đã được thêm vào thư viện.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi tạo album: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLoadAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra quyền - chỉ Artist có thể xem album của mình
                if (!SessionManager.IsArtist() && !SessionManager.IsAdmin())
                {
                    MessageBox.Show(
                        "Chỉ nghệ sĩ mới có thể xem album!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                SelectFilterButton(btnLoadAlbum);
                btnNewPlaylist.Visible = false;
                ClearSongList();

                // ✅ Cấu hình flowPanelSongs cho grid layout 4 cột
                flowPanelSongs.FlowDirection = FlowDirection.LeftToRight;
                flowPanelSongs.WrapContents = true;
                flowPanelSongs.AutoScroll = true;

                int currentUserID = SessionManager.GetCurrentUserID();
                var albumRepository = new AlbumRepository();
                var albums = albumRepository.GetAlbumsByArtist(currentUserID);

                if (albums.Count == 0)
                {
                    ShowEmptyMessage("Bạn chưa có album nào. Tạo album mới để bắt đầu!");
                    lblSongCount.Text = "0 album";
                    return;
                }

                // Hiển thị các album
                foreach (var album in albums)
                {
                    PopulateAlbumList(album);
                }

                lblSongCount.Text = $"{albums.Count} album";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi tải album: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void PopulateAlbumList(Album album)
        {
            ucAlbumItem item = new ucAlbumItem(album);

            item.OnPlayClicked += (s, e) => PlayFirstSongInAlbum(album);
            item.OnViewClicked += (s, e) => ViewAlbumDetail(album);
            item.OnEditClicked += (s, e) => EditAlbum(album);
            item.OnDeleteClicked += (s, e) => DeleteAlbum(album);

            flowPanelSongs.Controls.Add(item);
        }

        private void PlayFirstSongInAlbum(Album album)
        {
            try
            {
                var albumRepository = new AlbumRepository();
                var songs = albumRepository.GetAlbumSongs(album.AlbumID);

                if (songs.Count > 0)
                {
                    PlaySong(songs[0]);
                    MessageBox.Show($"Đang phát album '{album.Title}'", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Album này không có bài hát nào", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditAlbum(Album album)
        {
            try
            {
                frmCreateAlbum editForm = new frmCreateAlbum(album.AlbumID);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    btnLoadAlbum_Click(null, null);
                    MessageBox.Show("Album đã được cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa album: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAlbum(Album album)
        {
            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa album '{album.Title}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var albumRepository = new AlbumRepository();
                    if (albumRepository.DeleteAlbum(album.AlbumID))
                    {
                        MessageBox.Show("Đã xóa album", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLoadAlbum_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa album: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ViewAlbumDetail(Album album)
        {
            try
            {
                var albumRepository = new AlbumRepository();
                var songs = albumRepository.GetAlbumSongs(album.AlbumID);

                ClearSongList();

                if (songs.Count == 0)
                {
                    ShowEmptyMessage($"Album '{album.Title}' không có bài hát nào");
                    lblSongCount.Text = "0 bài hát";
                    return;
                }

                Panel albumHeader = new Panel
                {
                    Size = new Size(flowPanelSongs.Width - 20, 150),
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(230, 240, 255),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pbAlbumCover = new PictureBox
                {
                    Size = new Size(120, 120),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (!string.IsNullOrEmpty(album.CoverImage) && System.IO.File.Exists(album.CoverImage))
                {
                    try
                    {
                        pbAlbumCover.Image = Image.FromFile(album.CoverImage);
                    }
                    catch
                    {
                        pbAlbumCover.Image = CreateDefaultAlbumCover();
                    }
                }
                else
                {
                    pbAlbumCover.Image = CreateDefaultAlbumCover();
                }

                albumHeader.Controls.Add(pbAlbumCover);

                Label lblAlbumTitle = new Label
                {
                    Text = album.Title,
                    Location = new Point(140, 15),
                    Size = new Size(300, 30),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 144, 255),
                    AutoSize = false
                };
                albumHeader.Controls.Add(lblAlbumTitle);

                Label lblReleaseDate = new Label
                {
                    Text = $"📅 Ngày phát hành: {album.ReleaseDate:dd/MM/yyyy}",
                    Location = new Point(140, 50),
                    Size = new Size(300, 25),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray
                };
                albumHeader.Controls.Add(lblReleaseDate);

                Label lblSongCountDetail = new Label
                {
                    Text = $"🎵 {album.SongCount} bài hát",
                    Location = new Point(140, 80),
                    Size = new Size(300, 25),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray
                };
                albumHeader.Controls.Add(lblSongCountDetail);

                flowPanelSongs.Controls.Add(albumHeader);

                PopulateSongList(songs);

                lblSongCount.Text = $"Album: {album.Title} - {songs.Count} bài hát";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi tải chi tiết album: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ViewPlaylistDetail(Playlist playlist)
        {
            try
            {
                ClearSongList();

                List<Song> playlistSongs = playlistService.GetPlaylistSongs(playlist.PlaylistID);

                if (playlistSongs.Count == 0)
                {
                    ShowEmptyMessage($"Playlist '{playlist.Name}' không có bài hát nào");
                    lblSongCount.Text = "0 bài hát";
                    return;
                }

                Panel playlistHeader = new Panel
                {
                    Size = new Size(flowPanelSongs.Width - 20, 150),
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(230, 240, 255),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pbPlaylistCover = new PictureBox
                {
                    Size = new Size(120, 120),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                // Use first song's cover if available
                if (playlistSongs.Count > 0 && !string.IsNullOrEmpty(playlistSongs[0].CoverImage) 
                    && System.IO.File.Exists(playlistSongs[0].CoverImage))
                {
                    try
                    {
                        pbPlaylistCover.Image = Image.FromFile(playlistSongs[0].CoverImage);
                    }
                    catch
                    {
                        pbPlaylistCover.Image = CreateDefaultPlaylistCover();
                    }
                }
                else
                {
                    pbPlaylistCover.Image = CreateDefaultPlaylistCover();
                }

                playlistHeader.Controls.Add(pbPlaylistCover);

                Label lblPlaylistTitle = new Label
                {
                    Text = playlist.Name,
                    Location = new Point(140, 15),
                    Size = new Size(300, 30),
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 144, 255),
                    AutoSize = false
                };
                playlistHeader.Controls.Add(lblPlaylistTitle);

                Label lblDescription = new Label
                {
                    Text = playlist.Description ?? "Không có mô tả",
                    Location = new Point(140, 50),
                    Size = new Size(300, 40),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray,
                    AutoSize = false
                };
                playlistHeader.Controls.Add(lblDescription);

                Label lblInfo = new Label
                {
                    Text = $"📅 Tạo: {playlist.CreatedDate:dd/MM/yyyy} | 🎵 {playlistSongs.Count} bài hát",
                    Location = new Point(140, 95),
                    Size = new Size(300, 25),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.DarkGray
                };
                playlistHeader.Controls.Add(lblInfo);

                Label lblVisibility = new Label
                {
                    Text = playlist.IsPublic ? "🌐 Public" : "🔒 Private",
                    Location = new Point(140, 125),
                    Size = new Size(300, 20),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = playlist.IsPublic ? Color.Green : Color.Red
                };
                playlistHeader.Controls.Add(lblVisibility);

                flowPanelSongs.Controls.Add(playlistHeader);

                PopulateSongList(playlistSongs);

                lblSongCount.Text = $"Playlist: {playlist.Name} - {playlistSongs.Count} bài hát";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi tải chi tiết playlist: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SortSongs(string sortBy)
        {
            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                var songs = songRepository.GetAllSongs(currentUserID);

                // Sort based on selected option
                switch (sortBy)
                {
                    case "Tên A-Z":
                        songs.Sort((a, b) => a.Title.CompareTo(b.Title));
                        break;
                    case "Tên Z-A":
                        songs.Sort((a, b) => b.Title.CompareTo(a.Title));
                        break;
                    case "Mới nhất":
                        songs.Sort((a, b) => b.ReleaseDate.CompareTo(a.ReleaseDate));
                        break;
                    case "Cũ nhất":
                        songs.Sort((a, b) => a.ReleaseDate.CompareTo(b.ReleaseDate));
                        break;
                    case "Nhiều lượt nghe":
                        songs.Sort((a, b) => b.PlayCount.CompareTo(a.PlayCount));
                        break;
                    default:
                        songs.Sort((a, b) => a.Title.CompareTo(b.Title));
                        break;
                }

                ClearSongList();
                PopulateSongList(songs);
                lblSongCount.Text = $"{songs.Count} bài hát";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sắp xếp bài hát: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnUploadMS_Click(object sender, EventArgs e)
        {
            OpenUploadForm();
        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm bài hát, nghệ sĩ...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm bài hát, nghệ sĩ...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void lblSongCount_Click(object sender, EventArgs e)
        {
        }

        private Image CreateDefaultAlbumCover()
        {
            Bitmap bmp = new Bitmap(180, 180);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("💿", new Font("Arial", 80), Brushes.White, new PointF(25, 30));
            }
            return bmp;
        }

        private Image CreateDefaultPlaylistCover()
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("🎵", new Font("Arial", 50), Brushes.White, new PointF(15, 20));
            }
            return bmp;
        }

        #endregion
    }
}