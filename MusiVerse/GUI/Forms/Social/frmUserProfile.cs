using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.UserControls;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmUserProfile : Form
    {
        private int _userID;
        private User _user;
        private UserRepository _userRepository;
        private PostRepository _postRepository;
        private Panel _pnlUserInfo;
        private Panel _pnlPosts;
        private Label _lblPostCount;

        public frmUserProfile(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _userRepository = new UserRepository();
            _postRepository = new PostRepository();
            SetupUI();
            LoadUserData();
        }

        private void SetupUI()
        {
            this.Text = "Hồ sơ người dùng";
            this.Size = new System.Drawing.Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Main panel
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            // Header panel
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 250,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20),
                Margin = new Padding(0, 0, 0, 20)
            };

            // User info section
            _pnlUserInfo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true
            };

            pnlHeader.Controls.Add(_pnlUserInfo);

            // Posts section
            Label lblPostsTitle = new Label
            {
                Text = "📝 Bài viết",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(0, 0),
                AutoSize = true,
                Dock = DockStyle.Top
            };

            Panel pnlPostsHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.FromArgb(240, 240, 245),
                Padding = new Padding(20, 10, 20, 10)
            };
            pnlPostsHeader.Controls.Add(lblPostsTitle);

            _lblPostCount = new Label
            {
                Text = "Tổng: 0 bài viết",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                Location = new Point(180, 20),
                AutoSize = true
            };
            pnlPostsHeader.Controls.Add(_lblPostCount);

            _pnlPosts = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(0, 0, 0, 20)
            };

            pnlMain.Controls.Add(_pnlPosts);
            pnlMain.Controls.Add(pnlPostsHeader);
            pnlMain.Controls.Add(pnlHeader);

            this.Controls.Add(pnlMain);
        }

        private void LoadUserData()
        {
            try
            {
                _user = _userRepository.GetUserByID(_userID);

                if (_user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                DisplayUserProfile();
                LoadUserPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayUserProfile()
        {
            _pnlUserInfo.Controls.Clear();

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 150,
                Height = 150,
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(_user.Avatar),
                BorderStyle = BorderStyle.None
            };
            _pnlUserInfo.Controls.Add(pbAvatar);

            // User info panel
            Panel pnlInfo = new Panel
            {
                Location = new Point(190, 20),
                Size = new System.Drawing.Size(650, 150),
                AutoScroll = true
            };

            // Username
            Label lblUsername = new Label
            {
                Text = _user.Username,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 0),
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            pnlInfo.Controls.Add(lblUsername);

            // Full Name
            Label lblFullName = new Label
            {
                Text = _user.FullName ?? "N/A",
                Font = new Font("Segoe UI", 12),
                AutoSize = true,
                Location = new Point(0, 35),
                ForeColor = Color.Gray
            };
            pnlInfo.Controls.Add(lblFullName);

            // Role
            Label lblRole = new Label
            {
                Text = GetRoleBadge(_user.Role),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 70),
                ForeColor = GetRoleColor(_user.Role),
                BackColor = GetRoleBackColor(_user.Role),
                Padding = new Padding(8, 4, 8, 4)
            };
            pnlInfo.Controls.Add(lblRole);

            // Bio
            if (!string.IsNullOrWhiteSpace(_user.Bio))
            {
                Label lblBio = new Label
                {
                    Text = _user.Bio,
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(0, 110),
                    Size = new Size(650, 40),
                    AutoSize = false,
                    ForeColor = Color.FromArgb(80, 80, 80)
                };
                pnlInfo.Controls.Add(lblBio);
            }

            _pnlUserInfo.Controls.Add(pnlInfo);
        }

        private void LoadUserPosts()
        {
            try
            {
                int currentUserID = SessionManager.GetCurrentUserID();
                List<Post> userPosts = _postRepository.GetUserPosts(_userID, currentUserID);

                _lblPostCount.Text = $"Tổng: {userPosts.Count} bài viết";

                if (userPosts.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Người dùng chưa đăng bài viết nào",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        Location = new Point(300, 100),
                        AutoSize = true
                    };
                    _pnlPosts.Controls.Add(lblEmpty);
                }
                else
                {
                    foreach (Post post in userPosts)
                    {
                        AddPostToList(post, currentUserID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài viết: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPostToList(Post post, int currentUserID)
        {
            ucPostCard postCard = new ucPostCard();
            postCard.Width = _pnlPosts.Width - 40;
            postCard.LoadPost(post, currentUserID);
            _pnlPosts.Controls.Add(postCard);
        }

        private Image LoadUserAvatar(string avatarPath)
        {
            if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
            {
                try
                {
                    return Image.FromFile(avatarPath);
                }
                catch { }
            }

            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 149, 237));
                g.DrawString("👤", new Font("Arial", 60), Brushes.White, new PointF(35, 40));
            }
            return bmp;
        }

        private string GetRoleBadge(string role)
        {
            if (role == "Admin") return "🔐 Admin";
            if (role == "Artist") return "🎤 Artist";
            if (role == "IndieArtist") return "🎸 Indie Artist";
            return "👤 User";
        }

        private Color GetRoleColor(string role)
        {
            if (role == "Admin") return Color.FromArgb(200, 0, 0);
            if (role == "Artist") return Color.FromArgb(0, 120, 215);
            if (role == "IndieArtist") return Color.FromArgb(255, 140, 0);
            return Color.FromArgb(100, 100, 100);
        }

        private Color GetRoleBackColor(string role)
        {
            if (role == "Admin") return Color.FromArgb(255, 200, 200);
            if (role == "Artist") return Color.FromArgb(200, 230, 255);
            if (role == "IndieArtist") return Color.FromArgb(255, 220, 180);
            return Color.FromArgb(230, 230, 230);
        }
    }
}
