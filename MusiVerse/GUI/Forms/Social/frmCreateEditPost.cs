using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCreateEditPost : Form
    {
        private Post _post;
        private int _currentUserID;
        private PostService _postService;
        private string _selectedMediaPath = "";

        public frmCreateEditPost(Post post, int userID)
        {
            InitializeComponent();
            _post = post;
            _currentUserID = userID;
            _postService = new PostService();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = _post == null ? "?? T?o bài vi?t m?i" : "?? Ch?nh s?a bài vi?t";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Title
            Label lblTitle = new Label
            {
                Text = this.Text,
                Location = new Point(20, 20),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                AutoSize = true
            };
            this.Controls.Add(lblTitle);

            // User info
            Label lblUserInfo = new Label
            {
                Text = $"??ng b?ng: {SessionManager.GetCurrentUsername()}",
                Location = new Point(20, 50),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };
            this.Controls.Add(lblUserInfo);

            // Content TextBox
            Label lblContent = new Label
            {
                Text = "N?i dung bài vi?t:",
                Location = new Point(20, 80),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true
            };
            this.Controls.Add(lblContent);

            TextBox txtContent = new TextBox
            {
                Location = new Point(20, 110),
                Size = new Size(560, 120),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Text = _post?.Content ?? "",
                Name = "txtContent"
            };
            this.Controls.Add(txtContent);

            // Media section
            GroupBox gbMedia = new GroupBox
            {
                Text = "?? ?nh/Video",
                Location = new Point(20, 240),
                Size = new Size(560, 80),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };

            Label lblMediaPath = new Label
            {
                Text = _post?.MediaPath ?? "Ch?a ch?n ?nh/video",
                Location = new Point(10, 25),
                Size = new Size(480, 20),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                Name = "lblMediaPath"
            };

            Button btnBrowseMedia = new Button
            {
                Text = "Ch?n ?nh/video",
                Location = new Point(500, 22),
                Size = new Size(50, 25),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnBrowseMedia"
            };
            btnBrowseMedia.FlatAppearance.BorderSize = 0;
            btnBrowseMedia.Click += BtnBrowseMedia_Click;

            Button btnRemoveMedia = new Button
            {
                Text = "Xóa",
                Location = new Point(500, 50),
                Size = new Size(50, 25),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 8),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnRemoveMedia"
            };
            btnRemoveMedia.FlatAppearance.BorderSize = 0;
            btnRemoveMedia.Click += BtnRemoveMedia_Click;

            gbMedia.Controls.Add(lblMediaPath);
            gbMedia.Controls.Add(btnBrowseMedia);
            gbMedia.Controls.Add(btnRemoveMedia);
            this.Controls.Add(gbMedia);

            // Buttons
            Button btnPost = new Button
            {
                Text = _post == null ? "?? ??ng bài" : "?? C?p nh?t",
                Location = new Point(200, 340),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(30, 144, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.Click += BtnPost_Click;

            Button btnCancel = new Button
            {
                Text = "? H?y",
                Location = new Point(390, 340),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.Add(btnPost);
            this.Controls.Add(btnCancel);

            // Initialize media path
            if (_post != null && !string.IsNullOrEmpty(_post.MediaPath))
            {
                _selectedMediaPath = _post.MediaPath;
            }
        }

        private void BtnBrowseMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif|Video Files (*.mp4, *.avi, *.mov)|*.mp4;*.avi;*.mov|All Files (*.*)|*.*",
                Title = "Ch?n ?nh ho?c video"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedMediaPath = openFileDialog.FileName;
                Label lblMediaPath = this.Controls["lblMediaPath"] as Label;
                lblMediaPath.Text = Path.GetFileName(_selectedMediaPath);
            }
        }

        private void BtnRemoveMedia_Click(object sender, EventArgs e)
        {
            _selectedMediaPath = "";
            Label lblMediaPath = this.Controls["lblMediaPath"] as Label;
            lblMediaPath.Text = "Ch?a ch?n ?nh/video";
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            TextBox txtContent = this.Controls["txtContent"] as TextBox;
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show(
                    "Vui lòng nh?p n?i dung bài vi?t!",
                    "C?nh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                if (_post == null)
                {
                    // Create new post
                    Post newPost = new Post
                    {
                        UserID = _currentUserID,
                        Content = content,
                        MediaPath = _selectedMediaPath,
                        MediaType = GetMediaType(_selectedMediaPath),
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    var result = _postService.CreatePost(newPost);
                    if (result.Item1)
                    {
                        MessageBox.Show(result.Item2, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Item2, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Update existing post
                    _post.Content = content;
                    if (!string.IsNullOrEmpty(_selectedMediaPath))
                    {
                        _post.MediaPath = _selectedMediaPath;
                        _post.MediaType = GetMediaType(_selectedMediaPath);
                    }

                    var result = _postService.UpdatePost(_post);
                    if (result.Item1)
                    {
                        MessageBox.Show(result.Item2, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result.Item2, "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private string GetMediaType(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return "";

            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".mp4" || extension == ".avi" || extension == ".mov")
                return "video";
            else if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                return "image";

            return "";
        }
    }
}
