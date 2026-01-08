using MusiVerse.DTO.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucPostCard : UserControl
    {
        private Post _post;
        private int _currentUserID;

        public Post PostData { get => _post; set => _post = value; }

        public event EventHandler OnLikeClicked;
        public event EventHandler OnCommentClicked;
        public event EventHandler OnSaveClicked;
        public event EventHandler OnDeleteClicked;
        public event EventHandler OnProfileClicked;
        public event EventHandler OnPlaySongClicked;

        public ucPostCard()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(15);
            this.Margin = new Padding(0, 0, 0, 10);
        }

        public void LoadPost(Post post, int currentUserID)
        {
            _post = post;
            _currentUserID = currentUserID;
            DisplayPostData();
        }

        private void DisplayPostData()
        {
            if (_post == null) return;

            // Header: User info and date
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10)
            };

            // User avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 48,
                Height = 48,
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(_post.UserAvatar),
                Cursor = Cursors.Hand
            };
            pbAvatar.Click += (s, e) => OnProfileClicked?.Invoke(_post.UserID, EventArgs.Empty);

            // User info
            Label lblUsername = new Label
            {
                Text = _post.Username,
                Location = new Point(60, 5),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(_post.CreatedDate),
                Location = new Point(60, 28),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            // Delete button (for post owner)
            if (_currentUserID == _post.UserID)
            {
                Button btnDelete = new Button
                {
                    Text = "⋮",
                    Width = 40,
                    Height = 40,
                    Location = new Point(this.Width - 55, 10),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Gray,
                    Font = new Font("Arial", 14)
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += (s, e) => OnDeleteClicked?.Invoke(this, EventArgs.Empty);
                pnlHeader.Controls.Add(btnDelete);
            }

            pnlHeader.Controls.Add(pbAvatar);
            pnlHeader.Controls.Add(lblUsername);
            pnlHeader.Controls.Add(lblDate);
            this.Controls.Add(pnlHeader);

            // Content
            if (!string.IsNullOrWhiteSpace(_post.Content))
            {
                Label lblContent = new Label
                {
                    Text = _post.Content,
                    Dock = DockStyle.Top,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    MaximumSize = new Size(this.Width - 30, 0),
                    Margin = new Padding(0, 0, 0, 10)
                };
                this.Controls.Add(lblContent);
            }

            // Media (image/video)
            if (!string.IsNullOrWhiteSpace(_post.MediaPath) && System.IO.File.Exists(_post.MediaPath))
            {
                PictureBox pbMedia = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 300,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(0, 0, 0, 10)
                };

                try
                {
                    pbMedia.Image = Image.FromFile(_post.MediaPath);
                }
                catch { }

                this.Controls.Add(pbMedia);
            }

            // Engagement stats
            Panel pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.WhiteSmoke,
                Margin = new Padding(0, 10, 0, 0)
            };

            Label lblLikes = new Label
            {
                Text = $"❤️ {_post.LikeCount}",
                Location = new Point(10, 5),
                Font = new Font("Segoe UI", 9),
                AutoSize = true
            };

            Label lblComments = new Label
            {
                Text = $"💬 {_post.CommentCount}",
                Location = new Point(80, 5),
                Font = new Font("Segoe UI", 9),
                AutoSize = true
            };

            Label lblShares = new Label
            {
                Text = $"📤 {_post.ShareCount}",
                Location = new Point(150, 5),
                Font = new Font("Segoe UI", 9),
                AutoSize = true
            };

            pnlStats.Controls.Add(lblLikes);
            pnlStats.Controls.Add(lblComments);
            pnlStats.Controls.Add(lblShares);
            this.Controls.Add(pnlStats);

            // Action buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 10, 0, 0)
            };

            Button btnLike = new Button
            {
                Text = _post.IsLiked ? "❤️ Thích" : "🤍 Thích",
                Location = new Point(10, 8),
                Size = new Size(80, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = _post.IsLiked ? Color.FromArgb(220, 20, 60) : Color.White,
                ForeColor = _post.IsLiked ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9)
            };
            btnLike.FlatAppearance.BorderSize = 0;
            btnLike.Click += (s, e) => OnLikeClicked?.Invoke(this, EventArgs.Empty);

            Button btnComment = new Button
            {
                Text = "💬 Bình luận",
                Location = new Point(100, 8),
                Size = new Size(100, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };
            btnComment.FlatAppearance.BorderSize = 0;
            btnComment.Click += (s, e) => OnCommentClicked?.Invoke(this, EventArgs.Empty);

            Button btnSave = new Button
            {
                Text = _post.IsSaved ? "📌 Đã lưu" : "📌 Lưu",
                Location = new Point(210, 8),
                Size = new Size(80, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = _post.IsSaved ? Color.FromArgb(100, 149, 237) : Color.White,
                ForeColor = _post.IsSaved ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => OnSaveClicked?.Invoke(this, EventArgs.Empty);

            pnlActions.Controls.Add(btnLike);
            pnlActions.Controls.Add(btnComment);
            pnlActions.Controls.Add(btnSave);
            this.Controls.Add(pnlActions);
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

            // Default avatar
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

        public void UpdateLikeStatus(bool isLiked, int newLikeCount)
        {
            _post.IsLiked = isLiked;
            _post.LikeCount = newLikeCount;
            // Refresh UI
        }

        public void UpdateSaveStatus(bool isSaved)
        {
            _post.IsSaved = isSaved;
        }
    }
}
