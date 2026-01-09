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
            SetupUI();
            LoadPostData();
        }

        private void SetupUI()
        {
            this.Text = "✏️ Chỉnh sửa bài viết";
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Label lblTitle = new Label
            {
                Text = "✏️ Chỉnh sửa bài viết",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);

            // Content panel
            Panel pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(20),
                AutoScroll = true
            };

            // Content label
            Label lblContent = new Label
            {
                Text = "Nội dung bài viết:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Content textbox
            TextBox txtContent = new TextBox
            {
                Name = "txtContent",
                Location = new Point(20, 50),
                Size = new Size(540, 150),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Media label
            Label lblMedia = new Label
            {
                Text = "Hình ảnh/Video:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(20, 220),
                AutoSize = true
            };

            Label lblMediaSelected = new Label
            {
                Name = "lblMediaSelected",
                Text = "Chưa chọn file",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(20, 250),
                AutoSize = true
            };

            Button btnSelectMedia = new Button
            {
                Text = "📁 Chọn tệp",
                Location = new Point(20, 280),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSelectMedia.FlatAppearance.BorderSize = 0;
            btnSelectMedia.Click += (s, e) => SelectMedia(lblMediaSelected);

            Button btnRemoveMedia = new Button
            {
                Text = "❌ Xóa tệp",
                Location = new Point(150, 280),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRemoveMedia.FlatAppearance.BorderSize = 0;
            btnRemoveMedia.Click += (s, e) => RemoveMedia(lblMediaSelected);

            pnlContent.Controls.Add(lblContent);
            pnlContent.Controls.Add(txtContent);
            pnlContent.Controls.Add(lblMedia);
            pnlContent.Controls.Add(lblMediaSelected);
            pnlContent.Controls.Add(btnSelectMedia);
            pnlContent.Controls.Add(btnRemoveMedia);

            // Footer buttons
            Panel pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Button btnSave = new Button
            {
                Text = "✔️ Cập nhật",
                Location = new Point(350, 10),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => SavePost(txtContent);

            Button btnCancel = new Button
            {
                Text = "✘ Hủy",
                Location = new Point(480, 10),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();

            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Controls.Add(btnCancel);

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }

        private void LoadPostData()
        {
            TextBox txtContent = this.Controls.Find("txtContent", true).Length > 0
                ? (TextBox)this.Controls.Find("txtContent", true)[0]
                : null;

            if (txtContent != null)
            {
                txtContent.Text = _post.Content;
            }

            if (!string.IsNullOrEmpty(_post.MediaPath))
            {
                _selectedMediaPath = _post.MediaPath;
                Label lblMediaSelected = this.Controls.Find("lblMediaSelected", true).Length > 0
                    ? (Label)this.Controls.Find("lblMediaSelected", true)[0]
                    : null;

                if (lblMediaSelected != null)
                {
                    lblMediaSelected.Text = Path.GetFileName(_post.MediaPath);
                    lblMediaSelected.ForeColor = Color.Green;
                }
            }
        }

        private void SelectMedia(Label lblMediaSelected)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image/Video Files|*.jpg;*.jpeg;*.png;*.gif;*.mp4;*.avi;*.mov|All files (*.*)|*.*",
                Title = "Chọn hình ảnh hoặc video"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedMediaPath = openFileDialog.FileName;
                lblMediaSelected.Text = Path.GetFileName(openFileDialog.FileName);
                lblMediaSelected.ForeColor = Color.Green;
            }
        }

        private void RemoveMedia(Label lblMediaSelected)
        {
            _selectedMediaPath = null;
            lblMediaSelected.Text = "Chưa chọn file";
            lblMediaSelected.ForeColor = Color.Gray;
        }

        private void SavePost(TextBox txtContent)
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
