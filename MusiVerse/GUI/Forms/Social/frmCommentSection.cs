using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCommentSection : Form
    {
        private Post _post;
        private CommentService _commentService;
        private int _currentUserID;
        private List<Comment> _comments;

        public frmCommentSection(Post post)
        {
            InitializeComponent();
            _post = post;
            _commentService = new CommentService();
            _currentUserID = SessionManager.GetCurrentUserID();
            _comments = new List<Comment>();
        }

        private void frmCommentSection_Load(object sender, EventArgs e)
        {
            LoadComments();
        }

        private void LoadComments()
        {
            try
            {
                flowLayoutPanelComments.Controls.Clear();
                _comments = _commentService.GetCommentsByPost(_post.PostID);

                if (_comments == null || _comments.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Chưa có bình luận nào",
                        Font = new Font("Segoe UI", 10),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    flowLayoutPanelComments.Controls.Add(lblEmpty);
                    return;
                }

                foreach (Comment comment in _comments)
                {
                    Panel commentPanel = CreateCommentPanel(comment);
                    flowLayoutPanelComments.Controls.Add(commentPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bình luận: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateCommentPanel(Comment comment)
        {
            Panel pnlComment = new Panel
            {
                Width = flowLayoutPanelComments.Width - 15,
                Height = 100,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Tag = comment.CommentID
            };

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 40,
                Height = 40,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(comment.UserAvatar),
                BorderStyle = BorderStyle.None
            };
            pnlComment.Controls.Add(pbAvatar);

            // Username
            Label lblUsername = new Label
            {
                Text = comment.Username ?? "Anonymous",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(60, 10),
                AutoSize = true
            };
            pnlComment.Controls.Add(lblUsername);

            // Date
            Label lblCommentDate = new Label
            {
                Text = FormatDate(comment.CreatedDate),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(60, 28),
                AutoSize = true
            };
            pnlComment.Controls.Add(lblCommentDate);

            // Content
            Label lblCommentContent = new Label
            {
                Text = comment.Content,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(80, 80, 80),
                Location = new Point(60, 50),
                Size = new Size(pnlComment.Width - 140, 40),
                AutoSize = false
            };
            pnlComment.Controls.Add(lblCommentContent);

            // Show edit/delete buttons only for comment owner
            if (comment.UserID == _currentUserID)
            {
                Button btnEdit = new Button
                {
                    Text = "✏️",
                    Location = new Point(pnlComment.Width - 90, 10),
                    Size = new Size(35, 35),
                    BackColor = Color.FromArgb(100, 149, 237),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = comment
                };
                btnEdit.FlatAppearance.BorderSize = 0;
                btnEdit.Click += (s, e) => EditComment(comment);
                pnlComment.Controls.Add(btnEdit);

                Button btnDelete = new Button
                {
                    Text = "❌",
                    Location = new Point(pnlComment.Width - 50, 10),
                    Size = new Size(35, 35),
                    BackColor = Color.FromArgb(220, 20, 60),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = comment.CommentID
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += (s, e) => DeleteComment(comment);
                pnlComment.Controls.Add(btnDelete);
            }

            return pnlComment;
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            string content = txtNewComment.Text.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Vui lòng nhập nội dung bình luận", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewComment.Focus();
                return;
            }

            try
            {
                Comment newComment = new Comment
                {
                    PostID = _post.PostID,
                    UserID = _currentUserID,
                    Content = content,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var result = _commentService.AddComment(newComment);
                if (result.Item1)
                {
                    MessageBox.Show(result.Item2, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewComment.Clear();
                    LoadComments();
                }
                else
                {
                    MessageBox.Show(result.Item2, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditComment(Comment comment)
        {
            frmEditComment editForm = new frmEditComment(comment);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadComments();
            }
        }

        private void DeleteComment(Comment comment)
        {
            DialogResult result = MessageBox.Show(
                "Bạn chắc chắn muốn xóa bình luận này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var deleteResult = _commentService.DeleteComment(comment.CommentID, _currentUserID);
                    if (deleteResult.Item1)
                    {
                        MessageBox.Show(deleteResult.Item2, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadComments();
                    }
                    else
                    {
                        MessageBox.Show(deleteResult.Item2, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Image LoadUserAvatar(string avatarPath)
        {
            if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
            {
                try
                {
                    return Image.FromFile(avatarPath);
                }
                catch { }
            }

            Bitmap bmp = new Bitmap(35, 35);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("👤", new Font("Arial", 16), Brushes.White, new PointF(4, 4));
            }
            return bmp;
        }

        private string FormatDate(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalMinutes < 1)
                return "Vừa xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} phút trước";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} giờ trước";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} ngày trước";
            else
                return date.ToString("dd/MM/yyyy");
        }

        private void lblCommentsTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
