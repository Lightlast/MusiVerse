using MusiVerse.BLL.Services;
using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Music
{
    public partial class frmPlaylistEditor : Form
    {
        private PlaylistService _playlistService;
        private SongRepository _songRepository;
        private Playlist _currentPlaylist;
        private int _currentUserID;
        private bool _isNewPlaylist;
        private List<Song> _playlistSongsInEditor;

        public frmPlaylistEditor()
        {
            InitializeComponent();
            _playlistService = new PlaylistService();
            _songRepository = new SongRepository();
            _playlistSongsInEditor = new List<Song>();
        }

        public void Initialize(int userID)
        {
            _currentUserID = userID;
            _isNewPlaylist = true;
            _currentPlaylist = null;
            this.Text = "T?o Playlist M?i";
            LoadAvailableSongs();
        }

        public void LoadPlaylistForEdit(Playlist playlist, int userID)
        {
            _currentUserID = userID;
            _currentPlaylist = playlist;
            _isNewPlaylist = false;
            this.Text = $"Ch?nh S?a Playlist - {playlist.Name}";

            // Load playlist info
            if (!string.IsNullOrEmpty(playlist.Name))
            {
                txtPlaylistName.Text = playlist.Name;
            }

            if (!string.IsNullOrEmpty(playlist.Description))
            {
                txtDescription.Text = playlist.Description;
            }

            chkPublic.Checked = playlist.IsPublic;

            LoadAvailableSongs();
            LoadPlaylistSongs();
        }

        private void LoadAvailableSongs()
        {
            try
            {
                lvAvailableSongs.Items.Clear();
                List<Song> allSongs = _songRepository.GetAllSongs();

                foreach (var song in allSongs)
                {
                    ListViewItem item = new ListViewItem(song.Title);
                    item.SubItems.Add(song.ArtistName ?? "");
                    item.SubItems.Add(TimeSpan.FromSeconds(song.Duration).ToString(@"mm\:ss"));
                    item.Tag = song;
                    lvAvailableSongs.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i bài hát: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlaylistSongs()
        {
            try
            {
                lvPlaylistSongs.Items.Clear();
                _playlistSongsInEditor.Clear();

                if (_currentPlaylist != null)
                {
                    List<Song> playlistSongs = _playlistService.GetPlaylistSongs(_currentPlaylist.PlaylistID);
                    _playlistSongsInEditor = new List<Song>(playlistSongs);

                    foreach (var song in playlistSongs)
                    {
                        ListViewItem item = new ListViewItem(song.Title);
                        item.SubItems.Add(song.ArtistName ?? "");
                        item.SubItems.Add(TimeSpan.FromSeconds(song.Duration).ToString(@"mm\:ss"));
                        item.Tag = song;
                        lvPlaylistSongs.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i bài hát: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            if (lvAvailableSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát ?? thêm", "Thông báo");
                return;
            }

            foreach (ListViewItem item in lvAvailableSongs.SelectedItems)
            {
                Song song = (Song)item.Tag;

                // Ki?m tra xem bài hát ?ã có trong playlist ch?a
                bool alreadyExists = false;
                foreach (var existingSong in _playlistSongsInEditor)
                {
                    if (existingSong.SongID == song.SongID)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if (!alreadyExists)
                {
                    ListViewItem newItem = new ListViewItem(song.Title);
                    newItem.SubItems.Add(song.ArtistName ?? "");
                    newItem.SubItems.Add(TimeSpan.FromSeconds(song.Duration).ToString(@"mm\:ss"));
                    newItem.Tag = song;
                    lvPlaylistSongs.Items.Add(newItem);
                    _playlistSongsInEditor.Add(song);
                }
            }

            MessageBox.Show("Bài hát ?ã ???c thêm", "Thành công");
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            if (lvPlaylistSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát ?? xóa", "Thông báo");
                return;
            }

            foreach (ListViewItem item in lvPlaylistSongs.SelectedItems)
            {
                Song song = (Song)item.Tag;
                _playlistSongsInEditor.RemoveAll(s => s.SongID == song.SongID);
                lvPlaylistSongs.Items.Remove(item);
            }

            MessageBox.Show("Bài hát ?ã ???c xóa", "Thành công");
        }

        private void btnMoveSongUp_Click(object sender, EventArgs e)
        {
            if (lvPlaylistSongs.SelectedItems.Count == 0 || lvPlaylistSongs.SelectedIndices[0] == 0)
            {
                return;
            }

            int selectedIndex = lvPlaylistSongs.SelectedIndices[0];
            ListViewItem item = lvPlaylistSongs.Items[selectedIndex];
            Song song = (Song)item.Tag;

            lvPlaylistSongs.Items.RemoveAt(selectedIndex);
            lvPlaylistSongs.Items.Insert(selectedIndex - 1, item);
            lvPlaylistSongs.Items[selectedIndex - 1].Selected = true;

            // Update in list
            _playlistSongsInEditor.RemoveAt(selectedIndex);
            _playlistSongsInEditor.Insert(selectedIndex - 1, song);
        }

        private void btnMoveSongDown_Click(object sender, EventArgs e)
        {
            if (lvPlaylistSongs.SelectedItems.Count == 0 || lvPlaylistSongs.SelectedIndices[0] == lvPlaylistSongs.Items.Count - 1)
            {
                return;
            }

            int selectedIndex = lvPlaylistSongs.SelectedIndices[0];
            ListViewItem item = lvPlaylistSongs.Items[selectedIndex];
            Song song = (Song)item.Tag;

            lvPlaylistSongs.Items.RemoveAt(selectedIndex);
            lvPlaylistSongs.Items.Insert(selectedIndex + 1, item);
            lvPlaylistSongs.Items[selectedIndex + 1].Selected = true;

            // Update in list
            _playlistSongsInEditor.RemoveAt(selectedIndex);
            _playlistSongsInEditor.Insert(selectedIndex + 1, song);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaylistName.Text))
            {
                MessageBox.Show("Vui lòng nh?p tên playlist", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_isNewPlaylist)
                {
                    // T?o playlist m?i
                    bool created = _playlistService.CreatePlaylist(
                        txtPlaylistName.Text,
                        txtDescription.Text ?? "",
                        _currentUserID,
                        chkPublic.Checked
                    );

                    if (!created)
                    {
                        MessageBox.Show("Không th? t?o playlist", "L?i");
                        return;
                    }

                    // Get the newly created playlist ID
                    var userPlaylists = _playlistService.GetUserPlaylists(_currentUserID);
                    if (userPlaylists.Count > 0)
                    {
                        // Assume the last created playlist is the newest
                        _currentPlaylist = userPlaylists[0];
                    }

                    MessageBox.Show("Playlist ?ã ???c t?o thành công!", "Thành công");
                }
                else
                {
                    // C?p nh?t playlist hi?n t?i
                    bool updated = _playlistService.UpdatePlaylist(
                        _currentPlaylist.PlaylistID,
                        txtPlaylistName.Text,
                        txtDescription.Text ?? "",
                        chkPublic.Checked
                    );

                    if (!updated)
                    {
                        MessageBox.Show("Không th? c?p nh?t playlist", "L?i");
                        return;
                    }

                    MessageBox.Show("Playlist ?ã ???c c?p nh?t thành công!", "Thành công");
                }

                // Save songs to playlist
                if (_currentPlaylist != null && _playlistSongsInEditor.Count > 0)
                {
                    // L?y ID c?a các bài hát
                    List<int> songIds = new List<int>();
                    foreach (var song in _playlistSongsInEditor)
                    {
                        songIds.Add(song.SongID);
                    }

                    // Reorder songs
                    _playlistService.ReorderPlaylistSongs(_currentPlaylist.PlaylistID, songIds);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
