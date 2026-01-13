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
        private PostService _postService;
        private int _currentUserID;
        private string _selectedMediaPath;

        public frmCreatePost(int userID)
        {
            _currentUserID = userID;
            _postService = new PostService();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "?? T?o bài vi?t m?i";
            this.Size = new Size(600, 700);
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
                Text = "?? T?o bài vi?t m?i",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);

            // Content panel with FlowLayoutPanel
            FlowLayoutPanel pnlContent = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(20),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            // User info
            Label lblUserInfo = new Label
            {
                Text = $"??ng b?ng: {SessionManager.GetCurrentUsername()}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Content label
            Label lblContent = new Label
            {
                Text = "N?i dung bài vi?t:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            // Content textbox
            TextBox txtContent = new TextBox
            {
                Name = "txtContent",
                Size = new Size(540, 120),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 15)
            };

            // Media label
            Label lblMedia = new Label
            {
                Text = "Hình ?nh/Video:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            Label lblMediaSelected = new Label
            {
                Name = "lblMediaSelected",
                Text = "Ch?a ch?n file",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            // Preview container
            Panel pnlMediaPreviewContainer = new Panel
            {
                Size = new Size(540, 110),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10)
            };

            PictureBox pbMediaPreview = new PictureBox
            {
                Name = "pbMediaPreview",
                Location = new Point(5, 5),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.None,
                Visible = false
            };

            pnlMediaPreviewContainer.Controls.Add(pbMediaPreview);

            // Buttons container
            Panel pnlMediaButtons = new Panel
            {
                Size = new Size(540, 40),
                Margin = new Padding(0, 0, 0, 15)
            };

            Button btnSelectMedia = new Button
            {
                Text = "?? Ch?n t?p",
                Location = new Point(0, 0),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSelectMedia.FlatAppearance.BorderSize = 0;
            btnSelectMedia.Click += (s, e) => SelectMedia(lblMediaSelected, pbMediaPreview);

            Button btnRemoveMedia = new Button
            {
                Text = "? Xóa t?p",
                Location = new Point(130, 0),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRemoveMedia.FlatAppearance.BorderSize = 0;
            btnRemoveMedia.Click += (s, e) => RemoveMedia(lblMediaSelected, pbMediaPreview);

            pnlMediaButtons.Controls.Add(btnSelectMedia);
            pnlMediaButtons.Controls.Add(btnRemoveMedia);

            // Add all to content panel
            pnlContent.Controls.Add(lblUserInfo);
            pnlContent.Controls.Add(lblContent);
            pnlContent.Controls.Add(txtContent);
            pnlContent.Controls.Add(lblMedia);
            pnlContent.Controls.Add(lblMediaSelected);
            pnlContent.Controls.Add(pnlMediaPreviewContainer);
            pnlContent.Controls.Add(pnlMediaButtons);

            // Footer buttons
            Panel pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Button btnPost = new Button
            {
                Text = "?? ??ng bài",
                Location = new Point(350, 10),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(30, 144, 255),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.Click += (s, e) => CreatePost(txtContent);

            Button btnCancel = new Button
            {
                Text = "? H?y",
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

            pnlFooter.Controls.Add(btnPost);
            pnlFooter.Controls.Add(btnCancel);

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }

        private void SelectMedia(Label lblMediaSelected, PictureBox pbMediaPreview)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image/Video Files|*.jpg;*.jpeg;*.png;*.gif;*.mp4;*.avi;*.mov|All files (*.*)|*.*",
                Title = "Ch?n hình ?nh ho?c video"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedMediaPath = openFileDialog.FileName;
                lblMediaSelected.Text = Path.GetFileName(openFileDialog.FileName);
                lblMediaSelected.ForeColor = Color.Green;

                // Display preview
                try
                {
                    string fileExtension = Path.GetExtension(_selectedMediaPath).ToLower();
                    bool isVideo = fileExtension == ".mp4" || fileExtension == ".avi" || fileExtension == ".mov";

                    if (isVideo)
                    {
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

        private void RemoveMedia(Label lblMediaSelected, PictureBox pbMediaPreview)
        {
            _selectedMediaPath = null;
            lblMediaSelected.Text = "Ch?a ch?n file";
            lblMediaSelected.ForeColor = Color.Gray;

            pbMediaPreview.Image = null;
            pbMediaPreview.Visible = false;
        }

        private void CreatePost(TextBox txtContent)
        {
            string content = txtContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) && string.IsNullOrEmpty(_selectedMediaPath))
            {
                MessageBox.Show("Vui lòng nh?p n?i dung ho?c ch?n t?p media",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
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
