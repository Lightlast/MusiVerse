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
    public partial class frmProfile : Form
    {
        private int _userID;
        private User _user;
        private UserRepository _userRepository;
        private SongRepository _songRepository;
        private PostRepository _postRepository;
        private int _currentUserID;

        public frmProfile(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _currentUserID = SessionManager.GetCurrentUserID();
            _userRepository = new UserRepository();
            _songRepository = new SongRepository();
            _postRepository = new PostRepository();
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                _user = _userRepository.GetUserByID(_userID);
                if (_user == null)
                {
                    MessageBox.Show("Người dùng không tồn tại", "Lỗi");
                    this.Close();
                    return;
                }

                this.Text = _user.FullName ?? _user.Username;
                SetupUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin: " + ex.Message);
                this.Close();
            }
        }

        private void SetupUI()
        {
            this.Size = new System.Drawing.Size(1000, 800);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(250, 250, 250);

            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            // Header (profile info)
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 250,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(30)
            };

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 150,
                Height = 150,
                Location = new Point(30, 30),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle
            };

            if (!string.IsNullOrEmpty(_user.Avatar) && System.IO.File.Exists(_user.Avatar))
            {
                try
                {
                    pbAvatar.Image = Image.FromFile(_user.Avatar);
                }
                catch { }
            }
            else
            {
                pbAvatar.Image = CreateDefaultAvatar(_user.FullName);
            }

            // User info
            Label lblUsername = new Label
            {
                Text = _user.FullName ?? _user.Username,
                Location = new Point(200, 30),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true
            };

            Label lblRole = new Label
            {
                Text = _user.Role == "Artist" ? "🎤 Nghệ sĩ chính thức" :
                       _user.Role == "IndieArtist" ? "🎤 Nghệ sĩ độc lập" :
                       "👤 Người dùng",
                Location = new Point(200, 70),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            Label lblEmail = new Label
            {
                Text = "📧 " + _user.Email,
                Location = new Point(200, 100),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblBio = new Label
            {
                Text = _user.Bio ?? "Không có mô tả",
                Location = new Point(200, 130),
                Width = 650,
                Height = 70,
                Font = new Font("Segoe UI", 10),
                AutoSize = false
            };

            // Stats
            Panel pnlStats = new Panel
            {
                Location = new Point(200, 210),
                Width = 400,
                Height = 30,
                BackColor = Color.White
            };

            Label lblSongCount = new Label
            {
                Text = "🎵 0 bài hát",
                Location = new Point(0, 0),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblPostCount = new Label
            {
                Text = "📝 0 bài viết",
                Location = new Point(100, 0),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            pnlStats.Controls.Add(lblSongCount);
            pnlStats.Controls.Add(lblPostCount);

            pnlHeader.Controls.Add(pbAvatar);
            pnlHeader.Controls.Add(lblUsername);
            pnlHeader.Controls.Add(lblRole);
            pnlHeader.Controls.Add(lblEmail);
            pnlHeader.Controls.Add(lblBio);
            pnlHeader.Controls.Add(pnlStats);

            // Tabs for content
            TabControl tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                Padding = new System.Drawing.Point(20, 20)
            };

            // Tab 1: Songs
            TabPage tabSongs = new TabPage("🎵 Bài hát")
            {
                BackColor = Color.FromArgb(250, 250, 250)
            };

            FlowLayoutPanel pnlSongs = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            try
            {
                var songs = _songRepository.GetSongsByArtist(_userID, _currentUserID);
                lblSongCount.Text = $"🎵 {songs.Count} bài hát";

                if (songs.Count == 0)
                {
                    Label lblNoSongs = new Label
                    {
                        Text = "Không có bài hát nào",
                        Font = new Font("Segoe UI", 11),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };
                    pnlSongs.Controls.Add(lblNoSongs);
                }
                else
                {
                    foreach (var song in songs)
                    {
                        var songItem = new ucSongItem(song);
                        songItem.Width = 800;
                        songItem.Height = 80;
                        pnlSongs.Controls.Add(songItem);
                    }
                }
            }
            catch { }

            tabSongs.Controls.Add(pnlSongs);

            // Tab 2: Posts
            TabPage tabPosts = new TabPage("📝 Bài viết")
            {
                BackColor = Color.FromArgb(250, 250, 250)
            };

            FlowLayoutPanel pnlPosts = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            try
            {
                var posts = _postRepository.GetUserPosts(_userID, _currentUserID);
                lblPostCount.Text = $"📝 {posts.Count} bài viết";

                if (posts.Count == 0)
                {
                    Label lblNoPosts = new Label
                    {
                        Text = "Không có bài viết nào",
                        Font = new Font("Segoe UI", 11),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };
                    pnlPosts.Controls.Add(lblNoPosts);
                }
                else
                {
                    foreach (var post in posts)
                    {
                        var postCard = new ucPostCard();
                        postCard.LoadPost(post, _currentUserID);
                        postCard.Width = 850;
                        pnlPosts.Controls.Add(postCard);
                    }
                }
            }
            catch { }

            tabPosts.Controls.Add(pnlPosts);

            tabControl.TabPages.Add(tabSongs);
            tabControl.TabPages.Add(tabPosts);

            pnlMain.Controls.Add(tabControl);
            pnlMain.Controls.Add(pnlHeader);

            this.Controls.Add(pnlMain);
        }

        private Image CreateDefaultAvatar(string name)
        {
            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                string initial = string.IsNullOrEmpty(name) ? "?" : name.Substring(0, 1).ToUpper();
                g.DrawString(initial, new Font("Arial", 48, FontStyle.Bold), Brushes.White, new PointF(40, 40));
            }
            return bmp;
        }
    }
}
