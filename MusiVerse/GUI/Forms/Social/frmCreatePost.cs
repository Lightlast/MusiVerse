using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCreatePost : Form
    {
        private PostService _postService;
        private TextBox _txtContent;
        private PictureBox _pbMedia;
        private string _selectedMediaPath = "";

        public frmCreatePost()
        {
            InitializeComponent();
            _postService = new PostService();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Tạo bài viết";
            this.Size = new System.Drawing.Size(700, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(250, 250, 250);

            // Main panel
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(20)
            };

            // Title
            Label lblTitle = new Label
            {
                Text = "✍️ Tạo bài viết mới",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            // User info
            Panel pnlUserInfo = new Panel
            {
                Size = new System.Drawing.Size(660, 60),
                Location = new Point(20, 60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            Label lblUsername = new Label
            {
                Text = SessionManager.GetCurrentUsername(),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Label lblRole = new Label
            {
                Text = SessionManager.IsArtist() ? "🎤 Nghệ sĩ" : "👤 Người dùng",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(10, 35)
            };

            pnlUserInfo.Controls.Add(lblUsername);
            pnlUserInfo.Controls.Add(lblRole);

            // Content textarea
            Label lblContent = new Label
            {
                Text = "Nội dung:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 140)
            };

            _txtContent = new TextBox
            {
                Location = new Point(20, 170),
                Size = new System.Drawing.Size(660, 150),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10)
            };
            _txtContent.Text = "Chia sẻ điều gì đó với cộng đồng...";

            // Media section
            Label lblMedia = new Label
            {
                Text = "Hình ảnh/Video:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 330)
            };

            _pbMedia = new PictureBox
            {
                Location = new Point(20, 360),
                Size = new System.Drawing.Size(200, 150),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 240, 240),
                Image = null
            };

            Button btnSelectMedia = new Button
            {
                Text = "📁 Chọn hình ảnh",
                Location = new Point(240, 360),
                Size = new System.Drawing.Size(140, 35),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSelectMedia.FlatAppearance.BorderSize = 0;
            btnSelectMedia.Click += (s, e) => SelectMedia();

            Button btnRemoveMedia = new Button
            {
                Text = "❌ Xóa",
                Location = new Point(240, 410),
                Size = new System.Drawing.Size(140, 35),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnRemoveMedia.FlatAppearance.BorderSize = 0;
            btnRemoveMedia.Click += (s, e) =>
            {
                _selectedMediaPath = "";
                _pbMedia.Image = null;
                btnRemoveMedia.Enabled = false;
            };

            // Buttons panel
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(250, 250, 250)
            };

            Button btnPublish = new Button
            {
                Text = "📤 Đăng bài",
                Location = new Point(480, 10),
                Size = new System.Drawing.Size(200, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPublish.FlatAppearance.BorderSize = 0;
            btnPublish.Click += (s, e) => PublishPost();

            Button btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(20, 10),
                Size = new System.Drawing.Size(100, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            pnlButtons.Controls.Add(btnPublish);
            pnlButtons.Controls.Add(btnCancel);

            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(pnlUserInfo);
            pnlMain.Controls.Add(lblContent);
            pnlMain.Controls.Add(_txtContent);
            pnlMain.Controls.Add(lblMedia);
            pnlMain.Controls.Add(_pbMedia);
            pnlMain.Controls.Add(btnSelectMedia);
            pnlMain.Controls.Add(btnRemoveMedia);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlButtons);
        }

        private void SelectMedia()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|Video Files|*.mp4;*.avi;*.mkv|All Files|*.*";
                ofd.Title = "Chọn hình ảnh hoặc video";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedMediaPath = ofd.FileName;
                    try
                    {
                        _pbMedia.Image = Image.FromFile(_selectedMediaPath);
                        ((Button)this.Controls.Find("btnRemoveMedia", true)[0]).Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Không thể tải hình ảnh", "Lỗi");
                        _selectedMediaPath = "";
                    }
                }
            }
        }

        private void PublishPost()
        {
            string content = _txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) && string.IsNullOrWhiteSpace(_selectedMediaPath))
            {
                MessageBox.Show("Bài viết phải có nội dung hoặc hình ảnh/video", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var post = new Post
                {
                    UserID = SessionManager.GetCurrentUserID(),
                    Content = content,
                    MediaPath = _selectedMediaPath,
                    MediaType = GetMediaType(_selectedMediaPath)
                };

                var result = _postService.CreatePost(post);

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
            if (string.IsNullOrWhiteSpace(filePath))
                return "";

            string ext = System.IO.Path.GetExtension(filePath).ToLower();

            if (".jpg.jpeg.png.gif.bmp".Contains(ext))
                return "image";
            else if (".mp4.avi.mkv.mov.flv".Contains(ext))
                return "video";

            return "unknown";
        }
    }
}
