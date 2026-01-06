using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmNewsFeed : Form
    {
        private PostService _postService;
        private CommentService _commentService;
        private int _currentUserID;
        private int _currentPage = 1;
        private const int PAGE_SIZE = 10;
        private FlowLayoutPanel _flowPanelPosts;

        public frmNewsFeed()
        {
            InitializeComponent();
            _postService = new PostService();
            _commentService = new CommentService();
            _currentUserID = SessionManager.GetCurrentUserID();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "MusiVerse Newsfeed";
            this.Size = new System.Drawing.Size(1000, 800);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(250, 250, 250);

            // Main panel
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(250, 250, 250)
            };

            // Top bar with create post button
            Panel pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            Label lblTitle = new Label
            {
                Text = "📰 Newsfeed",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 20)
            };

            Button btnCreatePost = new Button
            {
                Text = "✍️ Tạo bài viết",
                Location = new Point(this.Width - 170, 20),
                Size = new Size(140, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCreatePost.FlatAppearance.BorderSize = 0;
            btnCreatePost.Click += (s, e) => OpenCreatePostForm();

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(btnCreatePost);
            pnlMain.Controls.Add(pnlTop);

            // Posts flow panel
            _flowPanelPosts = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(250, 250, 250)
            };
            pnlMain.Controls.Add(_flowPanelPosts);

            // Load more button
            Button btnLoadMore = new Button
            {
                Text = "📥 Tải thêm",
                Size = new Size(200, 40),
                Margin = new Padding(20),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLoadMore.FlatAppearance.BorderSize = 0;
            btnLoadMore.Click += (s, e) =>
            {
                _currentPage++;
                LoadNewsFeed();
            };
            pnlMain.Controls.Add(btnLoadMore);

            this.Controls.Add(pnlMain);

            // Load initial posts
            LoadNewsFeed();
        }

        private void LoadNewsFeed()
        {
            try
            {
                var posts = _postService.GetNewsFeed(_currentUserID, _currentPage, PAGE_SIZE);

                if (posts.Count == 0)
                {
                    if (_currentPage == 1)
                    {
                        Label lblEmpty = new Label
                        {
                            Text = "Không có bài viết nào",
                            Font = new Font("Segoe UI", 12),
                            ForeColor = Color.Gray,
                            AutoSize = true,
                            Margin = new Padding(20)
                        };
                        _flowPanelPosts.Controls.Add(lblEmpty);
                    }
                    return;
                }

                foreach (var post in posts)
                {
                    var postCard = new UserControls.ucPostCard();
                    postCard.LoadPost(post, _currentUserID);
                    postCard.Width = 650;
                    postCard.OnLikeClicked += (s, e) => HandleLikePost(post);
                    postCard.OnCommentClicked += (s, e) => HandleCommentPost(post);
                    postCard.OnSaveClicked += (s, e) => HandleSavePost(post);
                    postCard.OnDeleteClicked += (s, e) => HandleDeletePost(post);
                    postCard.OnProfileClicked += (s, e) => HandleProfileClick(post.UserID);

                    _flowPanelPosts.Controls.Add(postCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải newsfeed: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCreatePostForm()
        {
            if (!SessionManager.IsArtist())
            {
                MessageBox.Show("Chỉ Nghệ sĩ mới có thể tạo bài viết", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var frmCreate = new frmCreatePost();
            if (frmCreate.ShowDialog() == DialogResult.OK)
            {
                _currentPage = 1;
                _flowPanelPosts.Controls.Clear();
                LoadNewsFeed();
            }
        }

        private void HandleLikePost(Post post)
        {
            try
            {
                var result = post.IsLiked ?
                    _postService.UnlikePost(_currentUserID, post.PostID) :
                    _postService.LikePost(_currentUserID, post.PostID);

                if (result.Item1)
                {
                    post.IsLiked = !post.IsLiked;
                    post.LikeCount += post.IsLiked ? 1 : -1;
                    MessageBox.Show(result.Item2, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleCommentPost(Post post)
        {
            var frmComments = new Form
            {
                Text = "Bình luận",
                Size = new System.Drawing.Size(500, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Panel pnlComments = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };

            try
            {
                var comments = _commentService.GetCommentsByPost(post.PostID);
                foreach (var comment in comments)
                {
                    Panel pnlComment = new Panel
                    {
                        Width = 450,
                        Height = 80,
                        BackColor = Color.FromArgb(240, 240, 240),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(5)
                    };

                    Label lblCommentUser = new Label
                    {
                        Text = comment.Username,
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        AutoSize = true
                    };

                    Label lblCommentContent = new Label
                    {
                        Text = comment.Content,
                        Location = new Point(10, 35),
                        Width = 430,
                        Height = 35,
                        Font = new Font("Segoe UI", 9),
                        AutoSize = false
                    };

                    Label lblCommentDate = new Label
                    {
                        Text = comment.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                        Location = new Point(10, 60),
                        Font = new Font("Segoe UI", 8),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };

                    pnlComment.Controls.Add(lblCommentUser);
                    pnlComment.Controls.Add(lblCommentContent);
                    pnlComment.Controls.Add(lblCommentDate);
                    pnlComments.Controls.Add(pnlComment);
                }
            }
            catch { }

            // Add comment input
            Panel pnlInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            TextBox txtComment = new TextBox
            {
                Location = new Point(10, 10),
                Width = 360,
                Height = 35,
                Multiline = true,
                Font = new Font("Segoe UI", 9)
            };

            Button btnAddComment = new Button
            {
                Text = "Gửi",
                Location = new Point(380, 10),
                Size = new System.Drawing.Size(100, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnAddComment.FlatAppearance.BorderSize = 0;
            btnAddComment.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    var comment = new Comment
                    {
                        PostID = post.PostID,
                        UserID = _currentUserID,
                        Content = txtComment.Text
                    };

                    var result = _commentService.AddComment(comment);
                    if (result.Item1)
                    {
                        txtComment.Clear();
                        MessageBox.Show(result.Item2);
                        // Reload comments
                    }
                    else
                    {
                        MessageBox.Show(result.Item2, "Lỗi");
                    }
                }
            };

            pnlInput.Controls.Add(txtComment);
            pnlInput.Controls.Add(btnAddComment);

            frmComments.Controls.Add(pnlComments);
            frmComments.Controls.Add(pnlInput);
            frmComments.ShowDialog();
        }

        private void HandleSavePost(Post post)
        {
            try
            {
                var result = post.IsSaved ?
                    _postService.UnsavePost(_currentUserID, post.PostID) :
                    _postService.SavePost(_currentUserID, post.PostID);

                if (result.Item1)
                {
                    post.IsSaved = !post.IsSaved;
                    MessageBox.Show(result.Item2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void HandleDeletePost(Post post)
        {
            if (_currentUserID != post.UserID)
            {
                MessageBox.Show("Chỉ chủ bài viết mới có thể xóa");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa bài viết này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = _postService.DeletePost(post.PostID);
                if (result.Item1)
                {
                    _currentPage = 1;
                    _flowPanelPosts.Controls.Clear();
                    LoadNewsFeed();
                }
            }
        }

        private void HandleProfileClick(int userID)
        {
            var frmProfile = new frmProfile(userID);
            frmProfile.ShowDialog();
        }
    }
}
