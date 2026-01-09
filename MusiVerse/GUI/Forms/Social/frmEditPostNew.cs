using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmEditPost : Form
    {
        private PostService _postService;
        private Post _post;
        private TextBox _txtContent;
        private PictureBox _pbMedia;
        private string _selectedMediaPath;
        private Button _btnRemoveMedia;

        public frmEditPost(Post post)
        {
            InitializeComponent();
            _post = post;
            _postService = new PostService();
            _selectedMediaPath = post.MediaPath ?? "";
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Ch?nh s?a bài vi?t";
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
                Text = "?? Ch?nh s?a bài vi?t",
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
                Text = _post.Username,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Label lblDate = new Label
            {
                Text = $"T?o lúc: {_post.CreatedDate:dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(10, 35)
            };

            pnlUserInfo.Controls.Add(lblUsername);
            pnlUserInfo.Controls.Add(lblDate);

            // Content textarea
            Label lblContent = new Label
            {
                Text = "N?i dung:",
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
                Font = new Font("Segoe UI", 10),
                Text = _post.Content ?? ""
            };

            // Media section
            Label lblMedia = new Label
            {
                Text = "Hình ?nh/Video:",
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
                BackColor = Color.FromArgb(240, 240, 240)
            };

            if (!string.IsNullOrWhiteSpace(_post.MediaPath) && System.IO.File.Exists(_post.MediaPath))
            {
                try
                {
                    _pbMedia.Image = Image.FromFile(_post.MediaPath);
                }
                catch { }
            }

            Button btnSelectMedia = new Button
            {
                Text = "?? Ch?n hình ?nh",
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

            _btnRemoveMedia = new Button
            {
                Text = "? Xóa",
                Location = new Point(240, 410),
                Size = new System.Drawing.Size(140, 35),
                BackColor = Color.FromArgb(220, 20, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = !string.IsNullOrWhiteSpace(_post.MediaPath)
            };
            _btnRemoveMedia.FlatAppearance.BorderSize = 0;
            _btnRemoveMedia.Click += (s, e) =>
            {
                _selectedMediaPath = "";
                _pbMedia.Image = null;
                _btnRemoveMedia.Enabled = false;
            };

            // Buttons panel
            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(250, 250, 250)
            };

            Button btnSave = new Button
            {
                Text = "?? L?u",
                Location = new Point(480, 10),
                Size = new System.Drawing.Size(200, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => SavePost();

            Button btnCancel = new Button
            {
                Text = "H?y",
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

            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);

            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(pnlUserInfo);
            pnlMain.Controls.Add(lblContent);
            pnlMain.Controls.Add(_txtContent);
            pnlMain.Controls.Add(lblMedia);
            pnlMain.Controls.Add(_pbMedia);
            pnlMain.Controls.Add(btnSelectMedia);
            pnlMain.Controls.Add(_btnRemoveMedia);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlButtons);
        }

        private void SelectMedia()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|Video Files|*.mp4;*.avi;*.mkv|All Files|*.*";
                ofd.Title = "Ch?n hình ?nh ho?c video";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedMediaPath = ofd.FileName;
                    try
                    {
                        _pbMedia.Image = Image.FromFile(_selectedMediaPath);
                        _btnRemoveMedia.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Không th? t?i hình ?nh", "L?i");
                        _selectedMediaPath = _post.MediaPath;
                    }
                }
            }
        }

        private void SavePost()
        {
            string content = _txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) && string.IsNullOrWhiteSpace(_selectedMediaPath))
            {
                MessageBox.Show("Bài vi?t ph?i có n?i dung ho?c hình ?nh/video", "C?nh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _post.Content = content;
                _post.MediaPath = _selectedMediaPath;

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
                    MessageBox.Show(result.Item2, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
