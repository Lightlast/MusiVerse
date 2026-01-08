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
            // TODO: Implement sorting
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
            ShowEmptyMessage("Tính năng Lịch sử nghe đang được phát triển");
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
                    MessageBox.Show("Không thể xóa playlist", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Tính năng thêm vào playlist đang được phát triển", "Thông báo");
        }

        private void ShowSongInfo(Song song)
        {
            string info = $"Tên bài hát: {song.Title}\n" +
                         $"Nghệ sĩ: {song.ArtistName}\n" +
                         $"Thể loại: {song.Genre ?? "N/A"}\n" +
                         $"Thời lượng: {TimeSpan.FromSeconds(song.Duration):mm\\:ss}\n" +
                         $"Lượt nghe: {song.PlayCount}\n" +
                         $"Ngày phát hành: {song.ReleaseDate:dd/MM/yyyy}";

            MessageBox.Show(info, "Thông tin bài hát",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditSong(Song song)
        {
            MessageBox.Show("Tính năng chỉnh sửa bài hát đang được phát triển", "Thông báo");
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

        #endregion

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

        private void btnUploadMS_Click(object sender, EventArgs e)
        {
            OpenUploadForm();
        }

        private void lblSearchIcon_Click(object sender, EventArgs e)
        {
        }
    }
}