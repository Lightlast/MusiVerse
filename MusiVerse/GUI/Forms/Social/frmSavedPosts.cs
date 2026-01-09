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
    public partial class frmSavedPosts : Form
    {
        private PostService _postService;
        private ShareService _shareService;
        private Panel _pnlPosts;

        public frmSavedPosts()
        {
            InitializeComponent();
            _postService = new PostService();
            _shareService = new ShareService();
            SetupUI();
            LoadSavedPosts();
        }

        private void SetupUI()
        {
            this.Text = "?? Bài vi?t ?ã l?u";
            this.Size = new System.Drawing.Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Header panel
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
                Text = "?? Bài vi?t ?ã l?u",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Button btnClose = new Button
            {
                Text = "?óng",
                Location = new Point(this.Width - 120, 15),
                Size = new System.Drawing.Size(100, 40),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);

            // Main panel
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(20)
            };

            // Posts panel
            _pnlPosts = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true
            };

            pnlMain.Controls.Add(_pnlPosts);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlHeader);
        }

        private void LoadSavedPosts()
        {
            try
            {
                int userID = SessionManager.GetCurrentUserID();
                List<Post> savedPosts = _postService.GetSavedPosts(userID);

                if (savedPosts.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "B?n ch?a l?u bài vi?t nào ??",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        Location = new Point(200, 150),
                        AutoSize = true
                    };
                    _pnlPosts.Controls.Add(lblEmpty);
                }
                else
                {
                    foreach (Post post in savedPosts)
                    {
                        AddPostToList(post);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPostToList(Post post)
        {
            ucPostCard postCard = new ucPostCard();
            postCard.Width = _pnlPosts.Width - 40;
            postCard.LoadPost(post, SessionManager.GetCurrentUserID());

            postCard.OnLikeClicked += (s, e) => HandleLikePost(post, postCard);
            postCard.OnCommentClicked += (s, e) => ShowCommentForm(post);
            postCard.OnSaveClicked += (s, e) => HandleRemoveFromSaved(post, postCard);
            postCard.OnDeleteClicked += (s, e) => HandleDeletePost(post, postCard);
            postCard.OnEditClicked += (s, e) => HandleEditPost(post, postCard);
            postCard.OnShareClicked += (s, e) => HandleSharePost(post);

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

        private void HandleRemoveFromSaved(Post post, ucPostCard postCard)
        {
            int userID = SessionManager.GetCurrentUserID();
            var result = _postService.UnsavePost(userID, post.PostID);
            if (result.Item1)
            {
                _pnlPosts.Controls.Remove(postCard);
                MessageBox.Show("Bài vi?t ?ã ???c b? l?u", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleDeletePost(Post post, ucPostCard postCard)
        {
            var result = MessageBox.Show("B?n có ch?c mu?n xóa bài vi?t này?", "Xác nh?n",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var deleteResult = _postService.DeletePost(post.PostID, SessionManager.GetCurrentUserID());
                if (deleteResult.Item1)
                {
                    _pnlPosts.Controls.Remove(postCard);
                    MessageBox.Show("Bài vi?t ?ã ???c xóa", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không th? xóa bài vi?t", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleEditPost(Post post, ucPostCard postCard)
        {
            frmEditPost editForm = new frmEditPost(post);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                postCard.LoadPost(post, SessionManager.GetCurrentUserID());
            }
        }

        private void HandleSharePost(Post post)
        {
            int userID = SessionManager.GetCurrentUserID();
            var result = _shareService.SharePost(userID, post.PostID);
            if (result.Item1)
            {
                post.ShareCount++;
                MessageBox.Show(result.Item2, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Item2, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCommentForm(Post post)
        {
            frmCommentSection commentForm = new frmCommentSection(post);
            commentForm.ShowDialog();
        }
    }
}
