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

                int yPos = 15;
                foreach (var post in posts)
                {
                    ucPostCard postCard = new ucPostCard();
                    postCard.Width = 700;  // Fixed width
                    postCard.Height = 600; // Approximate height
                    postCard.Margin = new Padding(0, 0, 0, 10);
                    
                    // Center horizontally
                    int centerX = (pnlFeed.Width - postCard.Width) / 2;
                    postCard.Location = new Point(centerX, yPos);
                    
                    postCard.LoadPost(post, _currentUserID);
                    postCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    // Wire up events
                    postCard.OnLikeClicked += (s, e) => HandleLike(post, postCard);
                    postCard.OnCommentClicked += (s, e) => ShowCommentDialog(post);
                    postCard.OnSaveClicked += (s, e) => HandleSave(post, postCard);
                    postCard.OnDeleteClicked += (s, e) => DeletePost(post);
                    postCard.OnEditClicked += (s, e) => ShowEditPostForm(post);
                    postCard.OnShareClicked += (s, e) => HandleShare(post);
                    postCard.OnProfileClicked += (s, e) => ShowUserProfile(post.UserID);

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

        private void HandleLike(Post post, ucPostCard postCard)
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
                        postCard.UpdateLikeStatus(false, post.LikeCount);
                    }
                }
                else
                {
                    var result = _postService.LikePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsLiked = true;
                        post.LikeCount++;
                        postCard.UpdateLikeStatus(true, post.LikeCount);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void HandleSave(Post post, ucPostCard postCard)
        {
            try
            {
                if (post.IsSaved)
                {
                    var result = _postService.UnsavePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsSaved = false;
                        postCard.UpdateSaveStatus(false);
                    }
                }
                else
                {
                    var result = _postService.SavePost(_currentUserID, post.PostID);
                    if (result.Item1)
                    {
                        post.IsSaved = true;
                        postCard.UpdateSaveStatus(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
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

        private void ShowUserProfile(int userID)
        {
            MessageBox.Show(
                "Tính năng xem profile đang được phát triển",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
