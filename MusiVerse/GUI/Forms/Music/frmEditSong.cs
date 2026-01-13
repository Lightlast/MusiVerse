using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Music
{
    public partial class frmEditSong : Form
    {
        private SongRepository songRepository;
        private Song originalSong;
        private string selectedCoverImage = "";
        private const long MAX_IMAGE_SIZE = 5 * 1024 * 1024;

        public frmEditSong(Song song)
        {
            InitializeComponent();
            originalSong = song;
            songRepository = new SongRepository();
            LoadSongData();
            PopulateGenreCombo();
        }

        private void PopulateGenreCombo()
        {
            cmbGenre.Items.AddRange(new string[]
            {
                "Pop",
                "Rock",
                "Ballad",
                "Rap/Hip-hop",
                "EDM",
                "Jazz",
                "Classical",
                "Country",
                "R&B",
                "Indie",
                "Khác"
            });
            cmbGenre.SelectedIndex = 0;
        }

        private void LoadSongData()
        {
            txtTitle.Text = originalSong.Title;
            
            if (!string.IsNullOrEmpty(originalSong.Genre))
            {
                int index = cmbGenre.Items.IndexOf(originalSong.Genre);
                if (index >= 0)
                {
                    cmbGenre.SelectedIndex = index;
                }
            }

            if (!string.IsNullOrEmpty(originalSong.CoverImage) && File.Exists(originalSong.CoverImage))
            {
                try
                {
                    selectedCoverImage = originalSong.CoverImage;
                    pictureBoxCover.Image = Image.FromFile(originalSong.CoverImage);
                    lblCoverStatus.Text = Path.GetFileName(originalSong.CoverImage);
                    lblCoverStatus.ForeColor = Color.Green;
                }
                catch
                {
                    lblCoverStatus.Text = "Ch?a ch?n file";
                    lblCoverStatus.ForeColor = Color.Gray;
                }
            }
        }

        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Ch?n ?nh bìa",
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
                    lblCoverStatus.Text = Path.GetFileName(filePath);
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

        private void btnRemoveCover_Click(object sender, EventArgs e)
        {
            selectedCoverImage = "";
            pictureBoxCover.Image = null;
            lblCoverStatus.Text = "Ch?a ch?n file";
            lblCoverStatus.ForeColor = Color.Gray;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string genre = cmbGenre.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Vui lòng nh?p tên bài hát!", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            var result = MessageBox.Show(
                $"Xác nh?n c?p nh?t bài hát '{title}'?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                PerformUpdate(title, genre);
            }
        }

        private void PerformUpdate(string title, string genre)
        {
            try
            {
                originalSong.Title = title;
                originalSong.Genre = genre;

                if (!string.IsNullOrEmpty(selectedCoverImage) && File.Exists(selectedCoverImage))
                {
                    if (selectedCoverImage != originalSong.CoverImage)
                    {
                        string coversFolder = Path.Combine(Application.StartupPath, "Covers");
                        if (!Directory.Exists(coversFolder))
                        {
                            Directory.CreateDirectory(coversFolder);
                        }

                        string coverFileName = $"Song_{originalSong.SongID}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(selectedCoverImage)}";
                        string coverDestPath = Path.Combine(coversFolder, coverFileName);

                        File.Copy(selectedCoverImage, coverDestPath, true);
                        originalSong.CoverImage = coverDestPath;
                    }
                }

                bool success = songRepository.UpdateSong(originalSong);

                if (success)
                {
                    MessageBox.Show(
                        "C?p nh?t bài hát thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("C?p nh?t bài hát th?t b?i!", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
