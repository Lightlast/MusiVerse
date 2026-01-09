using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Forms.Social;
using MusiVerse.GUI.UserControls;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmMyPosts : Form
    {
        private PostService _postService;
        private Panel _pnlPosts;
        private User _targetUser;

        public frmMyPosts(User user = null)
        {
            InitializeComponent();
            _postService = new PostService();
            _targetUser = user;
            SetupUI();
            LoadUserPosts();
        }

        private void SetupUI()
        {
            bool isOwnProfile = _targetUser == null || _targetUser.UserID == SessionManager.GetCurrentUserID();
            string title = isOwnProfile ? "My Posts" : $"Bài vi?t c?a {_targetUser.FullName}";

            this.Text = title;
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

            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Label lblTitle = new Label
            {
                Text = $"?? {title}",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 20),
                AutoSize = true
            };

            Button btnClose = new Button
            {
                Text = "?óng",
                Location = new Point(this.Width - 120, 20),
                Size = new System.Drawing.Size(100, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);

            // Posts panel
            _pnlPosts = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            pnlMain.Controls.Add(_pnlPosts);
            pnlMain.Controls.Add(pnlHeader);

            this.Controls.Add(pnlMain);
        }

        private void LoadUserPosts()
        {
            try
            {
                int targetUserID = _targetUser?.UserID ?? SessionManager.GetCurrentUserID();
                int currentUserID = SessionManager.GetCurrentUserID();

                List<Post> userPosts = _postService.GetUserPosts(targetUserID, currentUserID);

                if (userPosts.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Ch?a có bài vi?t nào ??",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.Gray,
                        Location = new Point(100, 100),
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
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPostToList(Post post, int currentUserID)
        {
            ucPostCard postCard = new ucPostCard();
            postCard.Width = _pnlPosts.Width - 40;
            postCard.LoadPost(post, currentUserID);

            postCard.OnLikeClicked += (s, e) => HandleLikePost(post, postCard);
            postCard.OnCommentClicked += (s, e) => ShowCommentForm(post);
            postCard.OnSaveClicked += (s, e) => HandleSavePost(post, postCard);
            postCard.OnShareClicked += (s, e) => HandleSharePost(post);

            // Only allow delete and edit for own posts
            if (currentUserID == post.UserID)
            {
                postCard.OnDeleteClicked += (s, e) => HandleDeletePost(post, postCard);
                postCard.OnEditClicked += (s, e) => ShowEditPostForm(post, postCard);
            }

            _pnlPosts.Controls.Add(postCard);
        }

        private void HandleLikePost(Post post, ucPostCard postCard)
        {
            int userID = SessionManager.GetCurrentUserID();
            if (post.IsLiked)
            {
                var result = _postService.UnlikePost(userID, post.PostID);
                if (result.Item1)
                {
                    post.IsLiked = false;
                    post.LikeCount--;
                    postCard.UpdateLikeStatus(false, post.LikeCount);
                }
            }
            else
            {
                var result = _postService.LikePost(userID, post.PostID);
                if (result.Item1)
                {
                    post.IsLiked = true;
                    post.LikeCount++;
                    postCard.UpdateLikeStatus(true, post.LikeCount);
                }
            }
        }

        private void HandleSavePost(Post post, ucPostCard postCard)
        {
            int userID = SessionManager.GetCurrentUserID();
            if (post.IsSaved)
            {
                var result = _postService.UnsavePost(userID, post.PostID);
                if (result.Item1)
                {
                    post.IsSaved = false;
                    postCard.UpdateSaveStatus(false);
                }
            }
            else
            {
                var result = _postService.SavePost(userID, post.PostID);
                if (result.Item1)
                {
                    post.IsSaved = true;
                    postCard.UpdateSaveStatus(true);
                }
            }
        }

        private void HandleDeletePost(Post post, ucPostCard postCard)
        {
            var result = MessageBox.Show("B?n có ch?c mu?n xóa bài vi?t này?", "Xác nh?n",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var deleteResult = _postService.DeletePost(post.PostID);
                if (deleteResult.Item1)
                {
                    _pnlPosts.Controls.Remove(postCard);
                    MessageBox.Show("Bài vi?t ?ã ???c xóa", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void HandleSharePost(Post post)
        {
            Clipboard.SetText($"Bài vi?t t? {post.Username}: {post.Content}");
            MessageBox.Show("Bài vi?t ?ã ???c sao chép vào clipboard", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowEditPostForm(Post post, ucPostCard postCard)
        {
            frmEditPost editForm = new frmEditPost(post);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _pnlPosts.Controls.Remove(postCard);
                LoadUserPosts();
            }
        }

        private void ShowCommentForm(Post post)
        {
            frmCommentSection commentForm = new frmCommentSection(post);
            commentForm.ShowDialog();
        }
    }
}
