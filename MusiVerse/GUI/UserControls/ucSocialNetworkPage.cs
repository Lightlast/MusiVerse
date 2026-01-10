using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Forms.Social;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucSocialNetworkPage : UserControl
    {
        private PostService _postService;
        // private ShareService _shareService;  // Tạm comment lại
        private int _currentUserID;
        private int _currentPage = 1;

        public ucSocialNetworkPage()
        {
            InitializeComponent();
            _postService = new PostService();
            // _shareService = new ShareService();  // Tạm comment lại
            _currentUserID = SessionManager.GetCurrentUserID();
        }

        private void ucSocialNetworkPage_Load(object sender, EventArgs e)
        {
            LoadFeed();
        }

        private void LoadFeed()
        {
            try
            {
                pnlFeed.Controls.Clear();
                pnlFeed.Controls.Add(btnLoadMore);

                List<Post> posts = _postService.GetNewsFeed(_currentUserID, _currentPage, 10);

                if (posts.Count == 0 && _currentPage == 1)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Chưa có bài viết nào. Hãy tạo bài viết đầu tiên! 📝",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(250, 100)
                    };
                    pnlFeed.Controls.Add(lblEmpty);
                    return;
                }

                int yPos = 10;
                foreach (var post in posts)
                {
                    Panel postCard = CreatePostCard(post);
                    postCard.Location = new Point(50, yPos);
                    pnlFeed.Controls.Add(postCard);
                    yPos += postCard.Height + 15;
                }

                btnLoadMore.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải feed: " + ex.Message, "Lỗi");
            }
        }

        private Panel CreatePostCard(Post post)
        {
            Panel card = new Panel
            {
                Size = new Size(700, 0),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            int cardHeight = 80; // Header

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
            pbAvatar.Click += (s, e) => ShowUserProfile(post.UserID);

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

            // Menu button (for post owner)
            if (_currentUserID == post.UserID)
            {
                Button btnMenu = new Button
                {
                    Text = "?",
                    Width = 40,
                    Height = 40,
                    Location = new Point(650, 10),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Gray,
                    Font = new Font("Arial", 14),
                    Cursor = Cursors.Hand
                };
                btnMenu.FlatAppearance.BorderSize = 0;
                btnMenu.Click += (s, e) => ShowPostMenu(post, btnMenu);
                pnlHeader.Controls.Add(btnMenu);
            }

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

            // Media
            if (!string.IsNullOrWhiteSpace(post.MediaPath) && System.IO.File.Exists(post.MediaPath))
            {
                PictureBox pbMedia = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 300,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                try
                {
                    pbMedia.Image = Image.FromFile(post.MediaPath);
                }
                catch { }

                card.Controls.Add(pbMedia);
                cardHeight += 310;
            }

            // Stats
            Panel pnlStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(250, 250, 250),
                Padding = new Padding(15, 5, 15, 5)
            };

            Label lblStats = new Label
            {
                Text = $"?? {post.LikeCount}   ?? {post.CommentCount}   ?? {post.ShareCount}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true
            };

            pnlStats.Controls.Add(lblStats);
            card.Controls.Add(pnlStats);
            cardHeight += 40;

            // Action buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            Button btnLike = new Button
            {
                Text = post.IsLiked ? "?? Thích" : "?? Thích",
                Location = new Point(10, 8),
                Size = new Size(80, 30),
                BackColor = post.IsLiked ? Color.FromArgb(220, 20, 60) : Color.White,
                ForeColor = post.IsLiked ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLike.FlatAppearance.BorderSize = 0;
            btnLike.Click += (s, e) => HandleLike(post, btnLike);

            Button btnComment = new Button
            {
                Text = "?? Bình lu?n",
                Location = new Point(100, 8),
                Size = new Size(100, 30),
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnComment.FlatAppearance.BorderSize = 0;
            btnComment.Click += (s, e) => ShowCommentDialog(post);

            Button btnShare = new Button
            {
                Text = "?? Chia s?",
                Location = new Point(210, 8),
                Size = new Size(80, 30),
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnShare.FlatAppearance.BorderSize = 0;
            btnShare.Click += (s, e) => HandleShare(post);

            Button btnSave = new Button
            {
                Text = post.IsSaved ? "?? ?ã l?u" : "?? L?u",
                Location = new Point(300, 8),
                Size = new Size(80, 30),
                BackColor = post.IsSaved ? Color.FromArgb(100, 149, 237) : Color.White,
                ForeColor = post.IsSaved ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => HandleSave(post, btnSave);

            pnlActions.Controls.Add(btnLike);
            pnlActions.Controls.Add(btnComment);
            pnlActions.Controls.Add(btnShare);
            pnlActions.Controls.Add(btnSave);
            card.Controls.Add(pnlActions);
            cardHeight += 55;

            card.Height = cardHeight;
            return card;
        }

        private void HandleLike(Post post, Button btnLike)
        {
            try
            {
                if (post.IsLiked)
                {
                    var result = _postService.UnlikePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsLiked = false;
                        post.LikeCount--;
                        btnLike.Text = "?? Thích";
                        btnLike.BackColor = Color.White;
                        btnLike.ForeColor = Color.Black;
                    }
                }
                else
                {
                    var result = _postService.LikePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsLiked = true;
                        post.LikeCount++;
                        btnLike.Text = "?? Thích";
                        btnLike.BackColor = Color.FromArgb(220, 20, 60);
                        btnLike.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private void HandleSave(Post post, Button btnSave)
        {
            try
            {
                if (post.IsSaved)
                {
                    var result = _postService.UnsavePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsSaved = false;
                        btnSave.Text = "?? L?u";
                        btnSave.BackColor = Color.White;
                        btnSave.ForeColor = Color.Black;
                    }
                }
                else
                {
                    var result = _postService.SavePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsSaved = true;
                        btnSave.Text = "?? ?ã l?u";
                        btnSave.BackColor = Color.FromArgb(100, 149, 237);
                        btnSave.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private void HandleShare(Post post)
        {
            try
            {
                // var result = _shareService.SharePost(_currentUserID, post.PostID);
                // if (result.Item1)
                // {
                //     post.ShareCount++;
                //     MessageBox.Show(
                //         "Bài viết đã được chia sẻ!\n\n" +
                //         $"Tác giả: {post.Username}\n" +
                //         $"Nội dung: {post.Content.Substring(0, Math.Min(50, post.Content.Length))}...",
                //         "Chia sẻ bài viết",
                //         MessageBoxButtons.OK,
                //         MessageBoxIcon.Information
                //     );
                // }
                // else
                // {
                //     MessageBox.Show(result.Item2, "Lỗi");
                // }
                
                MessageBox.Show("Tính năng chia sẻ đang được phát triển", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void ShowCommentDialog(Post post)
        {
            frmCommentDialog commentDialog = new frmCommentDialog(post, _currentUserID);
            commentDialog.ShowDialog();
        }

        private void ShowPostMenu(Post post, Button btnMenu)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            menu.Items.Add("?? Ch?nh s?a", null, (s, e) => ShowEditPostForm(post));
            menu.Items.Add("??? Xóa", null, (s, e) => DeletePost(post));

            menu.Show(btnMenu, new Point(0, btnMenu.Height));
        }

        private void ShowEditPostForm(Post post)
        {
            frmCreateEditPost editForm = new frmCreateEditPost(post, _currentUserID);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadFeed();
            }
        }

        private void DeletePost(Post post)
        {
            var result = MessageBox.Show(
                "B?n có ch?c mu?n xóa bài vi?t này?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var deleteResult = _postService.DeletePost(post.PostID, _currentUserID);
                if (deleteResult.Item1)
                {
                    MessageBox.Show(deleteResult.Item2, "Thành công");
                    LoadFeed();
                }
                else
                {
                    MessageBox.Show(deleteResult.Item2, "L?i");
                }
            }
        }

        private void BtnCreatePost_Click(object sender, EventArgs e)
        {
            frmCreateEditPost createForm = new frmCreateEditPost(null, _currentUserID);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                _currentPage = 1;
                LoadFeed();
            }
        }

        private void BtnLoadMore_Click(object sender, EventArgs e)
        {
            _currentPage++;
            LoadFeed();
        }

        private void BtnSavedPosts_Click(object sender, EventArgs e)
        {
            frmSavedPosts savedPostsForm = new frmSavedPosts();
            savedPostsForm.ShowDialog();
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
                g.DrawString("??", new Font("Arial", 20), Brushes.White, new PointF(10, 10));
            }
            return bmp;
        }

        private void ShowUserProfile(int userID)
        {
            MessageBox.Show(
                "Tính n?ng xem profile ?ang ???c phát tri?n",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private string GetTimeAgo(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "v?a xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} phút tr??c";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} gi? tr??c";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} ngày tr??c";
            else
                return date.ToString("dd/MM/yyyy");
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
