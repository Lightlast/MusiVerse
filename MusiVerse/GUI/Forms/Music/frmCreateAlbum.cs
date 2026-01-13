using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Music
{
    public partial class frmCreateAlbum : Form
    {
        private AlbumRepository albumRepository;
        private SongRepository songRepository;
        private string selectedCoverImage = "";
        private List<Song> albumSongs = new List<Song>();
        private int editAlbumID = -1;
        private const long MAX_IMAGE_SIZE = 5 * 1024 * 1024;

        public frmCreateAlbum()
        {
            InitializeComponent();
            albumRepository = new AlbumRepository();
            songRepository = new SongRepository();
        }

        public frmCreateAlbum(int albumID) : this()
        {
            editAlbumID = albumID;
        }

        private void frmCreateAlbum_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsArtist() && !SessionManager.IsAdmin())
            {
                MessageBox.Show(
                    "Ch? ngh? s? m?i có quy?n t?o album!",
                    "Không có quy?n",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            SetupUI();

            if (editAlbumID > 0)
            {
                LoadAlbumForEdit();
            }
            else
            {
                LoadAvailableSongs();
            }
        }

        private void SetupUI()
        {
            this.Size = new System.Drawing.Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            if (editAlbumID > 0)
            {
                lblTitle.Text = "Ch?nh s?a Album";
                this.Text = "Ch?nh s?a Album";
            }
        }

        private void LoadAlbumForEdit()
        {
            var album = albumRepository.GetAlbumById(editAlbumID);
            if (album == null)
            {
                MessageBox.Show("Không tìm th?y album!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Load album info
            txtAlbumTitle.Text = album.Title;
            dtpReleaseDate.Value = album.ReleaseDate;
            selectedCoverImage = album.CoverImage;

            // Load cover image
            if (!string.IsNullOrEmpty(album.CoverImage) && File.Exists(album.CoverImage))
            {
                try
                {
                    pictureBoxCover.Image = Image.FromFile(album.CoverImage);
                    lblCoverStatus.Text = "? ?ã ch?n ?nh bìa";
                    lblCoverStatus.ForeColor = Color.Green;
                }
                catch
                {
                    lblCoverStatus.Text = "L?i t?i ?nh bìa";
                    lblCoverStatus.ForeColor = Color.Red;
                }
            }

            // Load album songs
            albumSongs = albumRepository.GetAlbumSongs(editAlbumID);
            LoadAvailableSongs();
            LoadAlbumSongsToListView();
        }

        private void LoadAvailableSongs()
        {
            lvAvailableSongs.Items.Clear();

            var artistSongs = songRepository.GetSongsByArtist(SessionManager.GetCurrentUserID());

            foreach (var song in artistSongs)
            {
                bool isInAlbum = albumSongs.Exists(s => s.SongID == song.SongID);
                if (!isInAlbum)
                {
                    var item = new ListViewItem(new[] {
                        song.Title,
                        song.ArtistName,
                        TimeSpan.FromSeconds(song.Duration).ToString(@"mm\:ss")
                    });
                    item.Tag = song;
                    lvAvailableSongs.Items.Add(item);
                }
            }
        }

        private void LoadAlbumSongsToListView()
        {
            lvAlbumSongs.Items.Clear();

            foreach (var song in albumSongs)
            {
                var item = new ListViewItem(new[] {
                    song.Title,
                    song.ArtistName,
                    TimeSpan.FromSeconds(song.Duration).ToString(@"mm\:ss")
                });
                item.Tag = song;
                lvAlbumSongs.Items.Add(item);
            }

            UpdateSongCount();
        }

        private void UpdateSongCount()
        {
            lblSongCount.Text = $"T?ng bài hát: {albumSongs.Count}";
        }

        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Ch?n ?nh bìa album",
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                FileInfo fileInfo = new FileInfo(filePath);

                if (fileInfo.Length > MAX_IMAGE_SIZE)
                {
                    MessageBox.Show(
                        $"?nh quá l?n! Kích th??c t?i ?a: {MAX_IMAGE_SIZE / (1024 * 1024)}MB",
                        "L?i",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                selectedCoverImage = filePath;

                try
                {
                    var oldImage = pictureBoxCover.Image;
                    pictureBoxCover.Image = Image.FromFile(filePath);
                    oldImage?.Dispose();
                    lblCoverStatus.Text = "? ?ã ch?n ?nh bìa";
                    lblCoverStatus.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không th? load ?nh: {ex.Message}",
                        "L?i",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            selectedCoverImage = "";
            pictureBoxCover.Image = null;
            lblCoverStatus.Text = "Ch?a ch?n ?nh bìa";
            lblCoverStatus.ForeColor = Color.Gray;
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            if (lvAvailableSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem item in lvAvailableSongs.SelectedItems)
            {
                var song = (Song)item.Tag;
                albumSongs.Add(song);
            }

            LoadAvailableSongs();
            LoadAlbumSongsToListView();
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            if (lvAlbumSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát ?? xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem item in lvAlbumSongs.SelectedItems)
            {
                var song = (Song)item.Tag;
                albumSongs.Remove(song);
            }

            LoadAvailableSongs();
            LoadAlbumSongsToListView();
        }

        private void btnMoveSongUp_Click(object sender, EventArgs e)
        {
            if (lvAlbumSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = lvAlbumSongs.SelectedItems[0].Index;
            if (selectedIndex > 0)
            {
                var temp = albumSongs[selectedIndex];
                albumSongs[selectedIndex] = albumSongs[selectedIndex - 1];
                albumSongs[selectedIndex - 1] = temp;

                LoadAlbumSongsToListView();
                lvAlbumSongs.Items[selectedIndex - 1].Selected = true;
            }
        }

        private void btnMoveSongDown_Click(object sender, EventArgs e)
        {
            if (lvAlbumSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n bài hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = lvAlbumSongs.SelectedItems[0].Index;
            if (selectedIndex < albumSongs.Count - 1)
            {
                var temp = albumSongs[selectedIndex];
                albumSongs[selectedIndex] = albumSongs[selectedIndex + 1];
                albumSongs[selectedIndex + 1] = temp;

                LoadAlbumSongsToListView();
                lvAlbumSongs.Items[selectedIndex + 1].Selected = true;
            }
        }

        private void txtAlbumTitle_TextChanged(object sender, EventArgs e)
        {
            // Validation can be added here
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtAlbumTitle.Text))
            {
                MessageBox.Show("Vui lòng nh?p tên album!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlbumTitle.Focus();
                return;
            }

            if (albumSongs.Count == 0)
            {
                MessageBox.Show("Album ph?i có ít nh?t m?t bài hát!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm
            string action = editAlbumID < 0 ? "t?o" : "c?p nh?t";
            var result = MessageBox.Show(
                $"Xác nh?n {action} album '{txtAlbumTitle.Text}'?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                PerformSave();
            }
        }

        private void PerformSave()
        {
            try
            {
                btnSave.Enabled = false;

                string coverDestPath = null;

                // Copy cover image if selected
                if (!string.IsNullOrEmpty(selectedCoverImage) && File.Exists(selectedCoverImage))
                {
                    string coversFolder = Path.Combine(Application.StartupPath, "Covers");
                    if (!Directory.Exists(coversFolder))
                    {
                        Directory.CreateDirectory(coversFolder);
                    }

                    string coverFileName = $"Album_{SessionManager.GetCurrentUserID()}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(selectedCoverImage)}";
                    coverDestPath = Path.Combine(coversFolder, coverFileName);

                    File.Copy(selectedCoverImage, coverDestPath, true);
                }

                Album album;

                if (editAlbumID > 0)
                {
                    // Update existing album
                    album = albumRepository.GetAlbumById(editAlbumID);
                    album.Title = txtAlbumTitle.Text.Trim();
                    album.ReleaseDate = dtpReleaseDate.Value;
                    if (!string.IsNullOrEmpty(coverDestPath))
                    {
                        album.CoverImage = coverDestPath;
                    }

                    bool success = albumRepository.UpdateAlbum(album);

                    if (success)
                    {
                        // ? C?p nh?t AlbumID cho các bài hát
                        foreach (var song in albumSongs)
                        {
                            songRepository.UpdateSongAlbum(song.SongID, editAlbumID);
                        }

                        MessageBox.Show(
                            "C?p nh?t album thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("C?p nh?t album th?t b?i!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new album
                    album = new Album
                    {
                        Title = txtAlbumTitle.Text.Trim(),
                        ArtistID = SessionManager.GetCurrentUserID(),
                        ReleaseDate = dtpReleaseDate.Value,
                        CoverImage = coverDestPath,
                        IsActive = true
                    };

                    bool success = albumRepository.CreateAlbum(album);

                    if (success)
                    {
                        // ? L?y AlbumID v?a t?o
                        var newAlbum = albumRepository.GetAlbumByTitle(album.Title, album.ArtistID);
                        if (newAlbum != null)
                        {
                            // C?p nh?t AlbumID cho các bài hát
                            foreach (var song in albumSongs)
                            {
                                songRepository.UpdateSongAlbum(song.SongID, newAlbum.AlbumID);
                            }
                        }

                        MessageBox.Show(
                            "T?o album thành công!\nBài hát s? ???c thêm vào album.",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("T?o album th?t b?i!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"L?i: {ex.Message}",
                    "L?i",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "B?n có ch?c mu?n h?y?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lvAlbumSongs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
