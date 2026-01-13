using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmEditPost : Form
    {
        private PostService _postService;
        private Post _post;
        private string _selectedMediaPath;

        public frmEditPost(Post post)
        {
            InitializeComponent();
            _post = post;
            _postService = new PostService();
            LoadPostData();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnSelectMedia.Click += (s, e) => SelectMedia();
            btnRemoveMedia.Click += (s, e) => RemoveMedia();
            btnSave.Click += (s, e) => SavePost();
        }

        private void LoadPostData()
        {
            if (_post == null) return;

            this.Text = "✏️ Chỉnh sửa bài viết";
            txtContent.Text = _post.Content ?? "";

            if (!string.IsNullOrEmpty(_post.MediaPath) && File.Exists(_post.MediaPath))
            {
                _selectedMediaPath = _post.MediaPath;
                DisplayMediaPreview(_selectedMediaPath);
                btnRemoveMedia.Enabled = true;
            }
        }

        private void SelectMedia()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image/Video Files|*.jpg;*.jpeg;*.png;*.gif;*.mp4;*.avi;*.mov|All files (*.*)|*.*",
                Title = "Chọn hình ảnh hoặc video"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedMediaPath = openFileDialog.FileName;
                DisplayMediaPreview(_selectedMediaPath);
                btnRemoveMedia.Enabled = true;
            }
        }

        private void DisplayMediaPreview(string filePath)
        {
            try
            {
                string fileExtension = Path.GetExtension(filePath).ToLower();
                bool isVideo = fileExtension == ".mp4" || fileExtension == ".avi" || fileExtension == ".mov";

                if (isVideo)
                {
                    Bitmap bmp = new Bitmap(pbMedia.Width, pbMedia.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.FromArgb(50, 50, 50));
                        g.DrawString("▶️ VIDEO", new Font("Arial", 16, FontStyle.Bold), Brushes.White, new PointF(40, 85));
                    }
                    pbMedia.Image = bmp;
                }
                else
                {
                    pbMedia.Image = Image.FromFile(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải preview: {ex.Message}", "Lỗi");
            }
        }

        private void RemoveMedia()
        {
            _selectedMediaPath = null;
            pbMedia.Image = null;
            btnRemoveMedia.Enabled = false;
        }

        private void SavePost()
        {
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) && string.IsNullOrEmpty(_selectedMediaPath))
            {
                MessageBox.Show("Vui lòng nhập nội dung hoặc chọn tệp media",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _post.Content = content;
                _post.MediaPath = _selectedMediaPath;
                _post.MediaType = GetMediaType(_selectedMediaPath);

                var result = _postService.UpdatePost(_post);
                if (result.Item1)
                {
                    MessageBox.Show(result.Item2, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Item2, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMediaType(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".mp4" || extension == ".avi" || extension == ".mov")
                return "Video";
            else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                return "Image";

            return null;
        }
    }
}
