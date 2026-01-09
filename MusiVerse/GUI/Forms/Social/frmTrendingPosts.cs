using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmTrendingPosts : Form
    {
        private PostService _postService;
        private int _currentUserID;
        private Panel _pnlPosts;
        private string _currentFilter = "likes"; // likes, comments, shares

        public frmTrendingPosts()
        {
            InitializeComponent();
            _postService = new PostService();
            _currentUserID = SessionManager.GetCurrentUserID();
            SetupUI();
            LoadTrendingPosts();
        }

        private void SetupUI()
        {
            this.Text = "🔥 Bài viết xu hướng";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Label lblTitle = new Label
            {
                Text = "🔥 Bài viết xu hướng",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 140, 0),
                Location = new Point(20, 15),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);

            // Filter buttons
            Panel pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            Button btnFilterLikes = new Button
            {
                Text = "❤️ Thích nhất",
                Location = new Point(15, 10),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(255, 140, 0),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = "likes"
            };
            btnFilterLikes.FlatAppearance.BorderSize = 0;
            btnFilterLikes.Click += (s, e) => FilterByLikes();

            Button btnFilterComments = new Button
            {
                Text = "💬 Bình luận nhiều",
                Location = new Point(145, 10),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(100, 100, 120),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = "comments"
            };
            btnFilterComments.FlatAppearance.BorderSize = 0;
            btnFilterComments.Click += (s, e) => FilterByComments();

            Button btnFilterShares = new Button
            {
                Text = "📤 Chia sẻ nhiều",
                Location = new Point(295, 10),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(100, 100, 120),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = "shares"
            };
            btnFilterShares.FlatAppearance.BorderSize = 0;
            btnFilterShares.Click += (s, e) => FilterByShares();

            pnlFilters.Controls.Add(btnFilterLikes);
            pnlFilters.Controls.Add(btnFilterComments);
            pnlFilters.Controls.Add(btnFilterShares);

            // Posts panel
            _pnlPosts = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                AutoScroll = true,
                Padding = new Padding(0)
            };

            this.Controls.Add(_pnlPosts);
            this.Controls.Add(pnlFilters);
            this.Controls.Add(pnlHeader);
        }

        private void LoadTrendingPosts()
        {
            try
            {
                _pnlPosts.Controls.Clear();

                // Get all newsfeed posts and sort by engagement
                List<Post> posts = _postService.GetNewsFeed(_currentUserID, 1, 100);

                // Sort based on current filter
                switch (_currentFilter)
                {
                    case "likes":
                        posts.Sort((a, b) => b.LikeCount.CompareTo(a.LikeCount));
                        break;
                    case "comments":
                        posts.Sort((a, b) => b.CommentCount.CompareTo(a.CommentCount));
                        break;
                    case "shares":
                        posts.Sort((a, b) => b.ShareCount.CompareTo(a.ShareCount));
                        break;
                }

                if (posts.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Chưa có bài viết nào 😢",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(350, 150)
                    };
                    _pnlPosts.Controls.Add(lblEmpty);
                    return;
                }

                int yPos = 10;
                foreach (var post in posts.GetRange(0, Math.Min(50, posts.Count)))
                {
                    Panel postCard = CreateTrendingPostCard(post);
                    postCard.Location = new Point(50, yPos);
                    _pnlPosts.Controls.Add(postCard);
                    yPos += postCard.Height + 15;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private Panel CreateTrendingPostCard(Post post)
        {
            Panel card = new Panel
            {
                Size = new Size(700, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            int cardHeight = 80;

            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            PictureBox pbAvatar = new PictureBox
            {
                Width = 48,
                Height = 48,
                Location = new Point(10, 6),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(post.UserAvatar),
                Cursor = Cursors.Hand
            };

            Label lblUsername = new Label
            {
                Text = post.Username,
                Location = new Point(70, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(post.CreatedDate),
                Location = new Point(70, 32),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            pnlHeader.Controls.Add(pbAvatar);
            pnlHeader.Controls.Add(lblUsername);
            pnlHeader.Controls.Add(lblDate);
            card.Controls.Add(pnlHeader);

            // Content
            if (!string.IsNullOrWhiteSpace(post.Content))
            {
                Label lblContent = new Label
                {
                    Text = post.Content,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = false,
                    Height = 60,
                    Padding = new Padding(15),
                    ForeColor = Color.Black
                };
                card.Controls.Add(lblContent);
                cardHeight += 80;
            }

            // Stats with highlight
            Panel pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(15, 5, 15, 5)
            };

            Label lblStats = new Label
            {
                Text = $"❤️ {post.LikeCount}   💬 {post.CommentCount}   📤 {post.ShareCount}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true
            };

            pnlStats.Controls.Add(lblStats);
            card.Controls.Add(pnlStats);
            cardHeight += 40;

            // Trending indicator
            Panel pnlTrending = new Panel
            {
                Dock = DockStyle.Top,
                Height = 25,
                BackColor = Color.FromArgb(255, 240, 200),
                Padding = new Padding(15, 5, 15, 5)
            };

            string trendingText;
            if (_currentFilter == "likes")
                trendingText = $"🔥 Được yêu thích bởi {post.LikeCount} người";
            else if (_currentFilter == "comments")
                trendingText = $"🔥 Có {post.CommentCount} bình luận";
            else if (_currentFilter == "shares")
                trendingText = $"🔥 Được chia sẻ {post.ShareCount} lần";
            else
                trendingText = "🔥 Bài viết xu hướng";

            Label lblTrending = new Label
            {
                Text = trendingText,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                ForeColor = Color.FromArgb(255, 140, 0)
            };

            pnlTrending.Controls.Add(lblTrending);
            card.Controls.Add(pnlTrending);
            cardHeight += 25;

            card.Height = cardHeight;
            return card;
        }

        private void FilterByLikes()
        {
            _currentFilter = "likes";
            LoadTrendingPosts();
        }

        private void FilterByComments()
        {
            _currentFilter = "comments";
            LoadTrendingPosts();
        }

        private void FilterByShares()
        {
            _currentFilter = "shares";
            LoadTrendingPosts();
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

            Bitmap bmp = new Bitmap(48, 48);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("👤", new Font("Arial", 20), Brushes.White, new PointF(10, 10));
            }
            return bmp;
        }

        private string GetTimeAgo(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "vừa xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} phút trước";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} giờ trước";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} ngày trước";
            else
                return date.ToString("dd/MM/yyyy");
        }
    }
}
