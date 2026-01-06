using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Music
{
    public partial class frmUploadSong : Form
    {
        private SongRepository songRepository;
        private string selectedAudioFile = "";
        private string selectedCoverImage = "";
        private const long MAX_AUDIO_SIZE = 50 * 1024 * 1024; // 50MB
        private const long MAX_IMAGE_SIZE = 5 * 1024 * 1024;  // 5MB

        public frmUploadSong()
        {
            InitializeComponent();
            songRepository = new SongRepository();
        }

        private void frmUploadSong_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền Artist
            if (!SessionManager.IsArtist() && !SessionManager.IsAdmin())
            {
                MessageBox.Show(
                    "Chỉ nghệ sĩ mới có quyền upload nhạc!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Close();
                return;
            }

            SetupUI();
        }

        private void SetupUI()
        {
            this.Size = new Size(610, 610);

            // Cách 2: Hoặc nếu muốn nó phóng to toàn màn hình luôn thì dùng dòng này:
            // this.WindowState = FormWindowState.Maximized;

            // Căn giữa màn hình cho đẹp
            this.StartPosition = FormStartPosition.CenterScreen;

            // Cho phép người dùng tự kéo to nhỏ thêm nếu muốn
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Populate genre dropdown
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

            // Hide progress bar
            progressBar.Visible = false;
            lblProgress.Visible = false;

            // Display artist name
            lblArtistName.Text = $"Nghệ sĩ: {SessionManager.GetCurrentUsername()}";
        }

        #region Select Files

        private void btnSelectAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Chọn file nhạc",
                Filter = "Audio Files (*.mp3;*.wav;*.m4a)|*.mp3;*.wav;*.m4a|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                FileInfo fileInfo = new FileInfo(filePath);

                // Validate file size
                if (fileInfo.Length > MAX_AUDIO_SIZE)
                {
                    MessageBox.Show(
                        $"File quá lớn! Kích thước tối đa: {MAX_AUDIO_SIZE / (1024 * 1024)}MB",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                selectedAudioFile = filePath;
                txtAudioFile.Text = Path.GetFileName(filePath);
                lblFileSize.Text = $"Kích thước: {FormatFileSize(fileInfo.Length)}";

                // Extract metadata (ID3 tags)
                ExtractMetadata(filePath);

                // Enable upload button
                ValidateForm();
            }
        }

        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Chọn ảnh bìa",
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFile.FileName;
                FileInfo fileInfo = new FileInfo(filePath);

                // Validate image size
                if (fileInfo.Length > MAX_IMAGE_SIZE)
                {
                    MessageBox.Show(
                        $"Ảnh quá lớn! Kích thước tối đa: {MAX_IMAGE_SIZE / (1024 * 1024)}MB",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                selectedCoverImage = filePath;

                // Display preview
                try
                {
                    pictureBoxCover.Image = Image.FromFile(filePath);
                    lblCoverStatus.Text = "✓ Đã chọn ảnh bìa";
                    lblCoverStatus.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Không thể load ảnh: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        #endregion

        #region Extract Metadata

        private void ExtractMetadata(string filePath)
        {
            try
            {
                // Basic metadata from filename if no ID3 tags
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                // Try to extract title
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    txtTitle.Text = fileName;
                }

                // Try to get duration using TagLib (if available)
                // For now, estimate based on file size
                FileInfo fileInfo = new FileInfo(filePath);
                int estimatedDuration = EstimateDuration(fileInfo.Length);

                lblDuration.Text = $"Thời lượng: ~{TimeSpan.FromSeconds(estimatedDuration):mm\\:ss}";

                // TODO: Implement TagLib-Sharp for proper ID3 tag extraction
                /*
                var file = TagLib.File.Create(filePath);
                txtTitle.Text = file.Tag.Title ?? fileName;
                txtAlbum.Text = file.Tag.Album ?? "";
                lblDuration.Text = $"Thời lượng: {file.Properties.Duration:mm\\:ss}";
                */
            }
            catch (Exception ex)
            {
                // If extraction fails, just use filename
                lblMetadataStatus.Text = "Không thể đọc metadata";
                lblMetadataStatus.ForeColor = Color.Orange;
            }
        }

        private int EstimateDuration(long fileSize)
        {
            // Rough estimate: 1MB ≈ 8 seconds for 128kbps MP3
            long fileSizeKB = fileSize / 1024;
            return (int)(fileSizeKB / 128); // seconds
        }

        #endregion

        #region Validation

        private void ValidateForm()
        {
            bool isValid = !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                          !string.IsNullOrWhiteSpace(selectedAudioFile);

            btnUpload.Enabled = isValid;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        #endregion

        #region Upload

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Final validation
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài hát!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedAudioFile))
            {
                MessageBox.Show("Vui lòng chọn file nhạc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm upload
            var result = MessageBox.Show(
                $"Xác nhận upload bài hát '{txtTitle.Text}'?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                PerformUpload();
            }
        }

        private void PerformUpload()
        {
            // Disable controls
            btnUpload.Enabled = false;
            btnSelectAudio.Enabled = false;
            btnSelectCover.Enabled = false;
            txtTitle.Enabled = false;
            cmbGenre.Enabled = false;

            // Show progress
            progressBar.Visible = true;
            lblProgress.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            lblProgress.Text = "Đang upload...";

            try
            {
                // Step 1: Copy audio file to server folder
                lblProgress.Text = "Đang sao chép file nhạc...";
                string musicFolder = Path.Combine(Application.StartupPath, "Music");
                if (!Directory.Exists(musicFolder))
                {
                    Directory.CreateDirectory(musicFolder);
                }

                string audioFileName = $"{SessionManager.GetCurrentUserID()}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(selectedAudioFile)}";
                string audioDestPath = Path.Combine(musicFolder, audioFileName);

                File.Copy(selectedAudioFile, audioDestPath, true);

                // Step 2: Copy cover image (if selected)
                lblProgress.Text = "Đang sao chép ảnh bìa...";
                string coverDestPath = null;
                if (!string.IsNullOrEmpty(selectedCoverImage))
                {
                    string coversFolder = Path.Combine(Application.StartupPath, "Covers");
                    if (!Directory.Exists(coversFolder))
                    {
                        Directory.CreateDirectory(coversFolder);
                    }

                    string coverFileName = $"{SessionManager.GetCurrentUserID()}_{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(selectedCoverImage)}";
                    coverDestPath = Path.Combine(coversFolder, coverFileName);

                    File.Copy(selectedCoverImage, coverDestPath, true);
                }

                // Step 3: Save to database
                lblProgress.Text = "Đang lưu vào database...";

                Song newSong = new Song
                {
                    Title = txtTitle.Text.Trim(),
                    ArtistID = SessionManager.GetCurrentUserID(),
                    Duration = EstimateDuration(new FileInfo(selectedAudioFile).Length),
                    FilePath = audioDestPath,
                    CoverImage = coverDestPath,
                    Genre = cmbGenre.SelectedItem?.ToString(),
                    ReleaseDate = DateTime.Now
                };

                bool success = songRepository.AddSong(newSong);

                if (success)
                {
                    progressBar.Style = ProgressBarStyle.Continuous;
                    progressBar.Value = 100;
                    lblProgress.Text = "✓ Upload thành công!";
                    lblProgress.ForeColor = Color.Green;

                    MessageBox.Show(
                        "Đã upload bài hát thành công!\n" +
                        "Bài hát của bạn đã được thêm vào thư viện.",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    throw new Exception("Không thể lưu thông tin bài hát vào database");
                }
            }
            catch (Exception ex)
            {
                progressBar.Visible = false;
                lblProgress.Visible = false;

                MessageBox.Show(
                    $"Lỗi khi upload: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Re-enable controls
                btnUpload.Enabled = true;
                btnSelectAudio.Enabled = true;
                btnSelectCover.Enabled = true;
                txtTitle.Enabled = true;
                cmbGenre.Enabled = true;
            }
        }

        #endregion

        #region Helpers

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn hủy?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            selectedCoverImage = "";
            pictureBoxCover.Image = null;
            lblCoverStatus.Text = "Chưa chọn ảnh bìa";
            lblCoverStatus.ForeColor = Color.Gray;
        }
    }
}