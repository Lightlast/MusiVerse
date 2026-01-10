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
        public event EventHandler OnEditClicked;
        public event EventHandler OnShareClicked;
        public event EventHandler OnProfileClicked;

        public ucPostCard()
        {
            InitializeComponent();
        }

        public void LoadPost(Post post, int currentUserID)
        {
            _post = post;
            _currentUserID = currentUserID;
            DisplayPost();
        }

        private void DisplayPost()
        {
            if (_post == null) return;

            // Update Header
            pbAvatar.Image = LoadUserAvatar(_post.UserAvatar);
            lblUsername.Text = _post.Username;
            lblDate.Text = GetTimeAgo(_post.CreatedDate);
            pbAvatar.Click += (s, e) => OnProfileClicked?.Invoke(_post.UserID, EventArgs.Empty);

            // Show/Hide menu button
            btnMenu.Visible = (_currentUserID == _post.UserID);
            if (btnMenu.Visible)
            {
                btnMenu.Click += (s, e) => ShowPostMenu();
            }

            // Update Content
            lblContent.Text = !string.IsNullOrWhiteSpace(_post.Content) ? _post.Content : "";
            lblContent.Visible = !string.IsNullOrWhiteSpace(_post.Content);

            // Update Media
            if (!string.IsNullOrWhiteSpace(_post.MediaPath) && System.IO.File.Exists(_post.MediaPath))
            {
                try
                {
                    pbMedia.Image = Image.FromFile(_post.MediaPath);
                    pbMedia.Visible = true;
                }
                catch
                {
                    pbMedia.Visible = false;
                }
            }
            else
            {
                pbMedia.Visible = false;
            }

            // Update Stats
            lblLikes.Text = $"❤️ {_post.LikeCount}";
            lblComments.Text = $"💬 {_post.CommentCount}";
            lblShares.Text = $"📤 {_post.ShareCount}";

            // Update Action Buttons
            btnLike.Text = _post.IsLiked ? "❤️ Thích" : "🤍 Thích";
            btnLike.BackColor = _post.IsLiked ? Color.FromArgb(220, 20, 60) : Color.White;
            btnLike.ForeColor = _post.IsLiked ? Color.White : Color.Black;
            btnLike.Click += (s, e) => OnLikeClicked?.Invoke(this, EventArgs.Empty);

            btnComment.Click += (s, e) => OnCommentClicked?.Invoke(this, EventArgs.Empty);
            btnShare.Click += (s, e) => OnShareClicked?.Invoke(this, EventArgs.Empty);

            btnSave.Text = _post.IsSaved ? "📌 Đã lưu" : "📌 Lưu";
            btnSave.BackColor = _post.IsSaved ? Color.FromArgb(100, 149, 237) : Color.White;
            btnSave.ForeColor = _post.IsSaved ? Color.White : Color.Black;
            btnSave.Click += (s, e) => OnSaveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ShowPostMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("✏️ Chỉnh sửa", null, (s, e) => OnEditClicked?.Invoke(this, EventArgs.Empty));
            menu.Items.Add("🗑️ Xóa", null, (s, e) => OnDeleteClicked?.Invoke(this, EventArgs.Empty));
            menu.Show(Cursor.Position);
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

            Bitmap bmp = new Bitmap(40, 40);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("👤", new Font("Arial", 18), Brushes.White, new PointF(8, 8));
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
            lblLikes.Text = $"❤️ {_post.LikeCount}";
            btnLike.Text = isLiked ? "❤️ Thích" : "🤍 Thích";
            btnLike.BackColor = isLiked ? Color.FromArgb(220, 20, 60) : Color.White;
            btnLike.ForeColor = isLiked ? Color.White : Color.Black;
        }

        public void UpdateCommentCount(int newCount)
        {
            _post.CommentCount = newCount;
            lblComments.Text = $"💬 {_post.CommentCount}";
        }

        public void UpdateShareCount(int newCount)
        {
            _post.ShareCount = newCount;
            lblShares.Text = $"📤 {_post.ShareCount}";
        }

        public void UpdateSaveStatus(bool isSaved)
        {
            _post.IsSaved = isSaved;
            btnSave.Text = isSaved ? "📌 Đã lưu" : "📌 Lưu";
            btnSave.BackColor = isSaved ? Color.FromArgb(100, 149, 237) : Color.White;
            btnSave.ForeColor = isSaved ? Color.White : Color.Black;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            OpenCommentSection();
        }
    }
}
