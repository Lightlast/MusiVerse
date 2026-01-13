using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCreatePost : Form
    {
        private Post _post;
        private int _currentUserID;
        private PostService _postService;
        private string _selectedMediaPath = "";
        private GroupBox _gbMedia;

        public frmCreatePost(int userID)
        {
            InitializeComponent();
            _currentUserID = userID;
            _postService = new PostService();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "?? T?o bài vi?t m?i";
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
                Text = "",
                Name = "txtContent"
            };
            this.Controls.Add(txtContent);

            // Media section
            _gbMedia = new GroupBox
            {
                Text = "?? ?nh/Video",
                Location = new Point(20, 240),
                Size = new Size(560, 150),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray
            };

            Label lblMediaPath = new Label
            {
                Text = "Ch?a ch?n ?nh/video",
                Location = new Point(10, 25),
                Size = new Size(480, 20),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                Name = "lblMediaPath"
            };

            PictureBox pbMediaPreview = new PictureBox
            {
                Name = "pbMediaPreview",
                Location = new Point(10, 50),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
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

            _gbMedia.Controls.Add(lblMediaPath);
            _gbMedia.Controls.Add(pbMediaPreview);
            _gbMedia.Controls.Add(btnBrowseMedia);
            _gbMedia.Controls.Add(btnRemoveMedia);
            this.Controls.Add(_gbMedia);

            // Buttons
            Button btnPost = new Button
            {
                Text = "?? ??ng bài",
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
                Text = "H?y",
                Location = new Point(390, 340),
                Size = new Size(180, 40),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += BtnCancel_Click;

            this.Controls.Add(btnPost);
            this.Controls.Add(btnCancel);

            // Initialize media path
            if (_post != null && !string.IsNullOrEmpty(_post.MediaPath))
            {
                _selectedMediaPath = _post.MediaPath;
                
                // Load existing media preview
                PictureBox pbPreview = _gbMedia.Controls["pbMediaPreview"] as PictureBox;
                Label lblPath = _gbMedia.Controls["lblMediaPath"] as Label;
                
                if (pbPreview != null && System.IO.File.Exists(_selectedMediaPath))
                {
                    try
                    {
                        string fileExtension = Path.GetExtension(_selectedMediaPath).ToLower();
                        bool isVideo = fileExtension == ".mp4" || fileExtension == ".avi" || fileExtension == ".mov";

                        if (isVideo)
                        {
                            // Show video icon
                            Bitmap bmp = new Bitmap(100, 100);
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.Clear(Color.FromArgb(50, 50, 50));
                                g.DrawString("?? VIDEO", new Font("Arial", 10, FontStyle.Bold), Brushes.White, new PointF(10, 40));
                            }
                            pbPreview.Image = bmp;
                        }
                        else
                        {
                            // Show image preview
                            pbPreview.Image = Image.FromFile(_selectedMediaPath);
                        }
                        pbPreview.Visible = true;
                    }
                    catch
                    {
                        pbPreview.Visible = false;
                    }
                }
                
                if (lblPath != null)
                {
                    lblPath.Text = Path.GetFileName(_selectedMediaPath);
                    lblPath.ForeColor = Color.Green;
                }
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
                Label lblMediaPath = _gbMedia.Controls["lblMediaPath"] as Label;
                lblMediaPath.Text = Path.GetFileName(_selectedMediaPath);
                lblMediaPath.ForeColor = Color.Green;

                // Display preview
                PictureBox pbMediaPreview = _gbMedia.Controls["pbMediaPreview"] as PictureBox;
                if (pbMediaPreview != null)
                {
                    try
                    {
                        string fileExtension = Path.GetExtension(_selectedMediaPath).ToLower();
                        bool isVideo = fileExtension == ".mp4" || fileExtension == ".avi" || fileExtension == ".mov";

                        if (isVideo)
                        {
                            // Show video icon
                            Bitmap bmp = new Bitmap(100, 100);
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                g.Clear(Color.FromArgb(50, 50, 50));
                                g.DrawString("?? VIDEO", new Font("Arial", 10, FontStyle.Bold), Brushes.White, new PointF(10, 40));
                            }
                            pbMediaPreview.Image = bmp;
                        }
                        else
                        {
                            // Show image preview
                            pbMediaPreview.Image = Image.FromFile(_selectedMediaPath);
                        }
                        pbMediaPreview.Visible = true;
                    }
                    catch
                    {
                        pbMediaPreview.Visible = false;
                    }
                }
            }
        }

        private void BtnRemoveMedia_Click(object sender, EventArgs e)
        {
            _selectedMediaPath = "";
            Label lblMediaPath = _gbMedia.Controls["lblMediaPath"] as Label;
            lblMediaPath.Text = "Ch?a ch?n ?nh/video";
            lblMediaPath.ForeColor = Color.Gray;

            PictureBox pbMediaPreview = _gbMedia.Controls["pbMediaPreview"] as PictureBox;
            if (pbMediaPreview != null)
            {
                pbMediaPreview.Image = null;
                pbMediaPreview.Visible = false;
            }
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            TextBox txtContent = this.Controls["txtContent"] as TextBox;
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) && string.IsNullOrEmpty(_selectedMediaPath))
            {
                MessageBox.Show(
                    "Vui lòng nh?p n?i dung bài vi?t ho?c ch?n ?nh/video!",
                    "C?nh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
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
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            // Optional: Add any text change handling here
        }

        private void lblContent_Click(object sender, EventArgs e)
        {
            // Optional: Add any label click handling here
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
