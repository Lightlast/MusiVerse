using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCommentDialog : Form
    {
        private Post _post;
        private int _currentUserID;
        private CommentService _commentService;
        private List<Comment> _comments;
        private Panel _pnlCommentsList;
        private TextBox _txtComment;

        public frmCommentDialog(Post post, int currentUserID)
        {
            InitializeComponent();
            _post = post;
            _currentUserID = currentUserID;
            _commentService = new CommentService();
            _comments = new List<Comment>();
        }

        private void frmCommentDialog_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadComments();
        }

        private void SetupUI()
        {
            this.Text = "?? Bình lu?n";
            this.Size = new System.Drawing.Size(800, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // ==================== HEADER ====================
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            Label lblTitle = new Label
            {
                Text = "?? Bình lu?n",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(15, 15),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);

            // ==================== POST PREVIEW ====================
            Panel pnlPostPreview = new Panel
            {
                Dock = DockStyle.Top,
                Height = 130,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            // Post header
            Label lblPostUser = new Label
            {
                Text = $"?? {_post.Username}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(15, 10),
                AutoSize = true
            };

            Label lblPostDate = new Label
            {
                Text = GetTimeAgo(_post.CreatedDate),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Location = new Point(250, 13),
                AutoSize = true
            };

            // Post content
            Label lblPostContent = new Label
            {
                Text = _post.Content,
                Font = new Font("Segoe UI", 9F),
                AutoSize = false,
                Size = new Size(750, 50),
                Location = new Point(15, 40),
                ForeColor = Color.FromArgb(60, 60, 60),
                Padding = new Padding(5)
            };

            // Post stats
            Label lblPostStats = new Label
            {
                Text = $"?? {_post.LikeCount}   ?? {_post.CommentCount}   ?? {_post.ShareCount}",
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Location = new Point(15, 95),
                AutoSize = true
            };

            pnlPostPreview.Controls.Add(lblPostUser);
            pnlPostPreview.Controls.Add(lblPostDate);
            pnlPostPreview.Controls.Add(lblPostContent);
            pnlPostPreview.Controls.Add(lblPostStats);

            // ==================== COMMENTS LIST ====================
            _pnlCommentsList = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                AutoScroll = true,
                Padding = new Padding(10)
            };

            // ==================== COMMENT INPUT ====================
            Panel pnlCommentInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 110,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            Label lblInputLabel = new Label
            {
                Text = "?? Vi?t bình lu?n:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Location = new Point(15, 8),
                AutoSize = true
            };

            _txtComment = new TextBox
            {
                Location = new Point(15, 32),
                Size = new Size(730, 60),
                Font = new Font("Segoe UI", 10F),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Name = "txtComment"
            };

            Button btnPostComment = new Button
            {
                Text = "?? G?i",
                Location = new Point(755, 32),
                Size = new Size(30, 60),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Name = "btnPostComment"
            };
            btnPostComment.FlatAppearance.BorderSize = 0;
            btnPostComment.Click += BtnPostComment_Click;

            pnlCommentInput.Controls.Add(lblInputLabel);
            pnlCommentInput.Controls.Add(_txtComment);
            pnlCommentInput.Controls.Add(btnPostComment);

            // Add all panels to form
            this.Controls.Add(_pnlCommentsList);
            this.Controls.Add(pnlCommentInput);
            this.Controls.Add(pnlPostPreview);
            this.Controls.Add(pnlHeader);
        }

        private void LoadComments()
        {
            try
            {
                _comments = _commentService.GetCommentsByPost(_post.PostID);
                RefreshCommentsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i bình lu?n: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCommentsList()
        {
            _pnlCommentsList.Controls.Clear();

            if (_comments.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "?? Ch?a có bình lu?n nào.\nHãy bình lu?n ??u tiên!",
                    Font = new Font("Segoe UI", 11F),
                    ForeColor = Color.Gray,
                    AutoSize = false,
                    Size = new Size(760, 80),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 100)
                };
                _pnlCommentsList.Controls.Add(lblEmpty);
                return;
            }

            int yPos = 10;
            foreach (var comment in _comments)
            {
                Panel commentCard = CreateCommentCard(comment, yPos);
                _pnlCommentsList.Controls.Add(commentCard);
                yPos += commentCard.Height + 10;
            }
        }

        private Panel CreateCommentCard(Comment comment, int yPos)
        {
            Panel card = new Panel
            {
                Size = new Size(760, 100),
                Location = new Point(0, yPos),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(12)
            };

            // User avatar
            Panel avatarPanel = new Panel
            {
                Size = new Size(45, 45),
                Location = new Point(12, 10),
                BackColor = Color.FromArgb(100, 149, 237),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            Label lblAvatar = new Label
            {
                Text = comment.Username.Length > 0 ? comment.Username[0].ToString().ToUpper() : "?",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            avatarPanel.Controls.Add(lblAvatar);

            // Author name
            Label lblAuthor = new Label
            {
                Text = comment.Username,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(70, 12),
                AutoSize = true
            };

            // Comment date
            Label lblDate = new Label
            {
                Text = GetTimeAgo(comment.CreatedDate),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray,
                Location = new Point(70, 32),
                AutoSize = true
            };

            // Comment content
            Label lblContent = new Label
            {
                Text = comment.Content,
                Font = new Font("Segoe UI", 9F),
                AutoSize = false,
                Size = new Size(630, 45),
                Location = new Point(70, 48),
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            // Delete button (for comment owner only)
            if (_currentUserID == comment.UserID)
            {
                Button btnDelete = new Button
                {
                    Text = "???",
                    Size = new Size(35, 35),
                    Location = new Point(710, 55),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 11),
                    Cursor = Cursors.Hand,
                    Tag = comment.CommentID
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 240, 240);
                btnDelete.Click += (s, e) => DeleteComment(comment, card);
                card.Controls.Add(btnDelete);
            }

            card.Controls.Add(avatarPanel);
            card.Controls.Add(lblAuthor);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblContent);

            return card;
        }

        private void BtnPostComment_Click(object sender, EventArgs e)
        {
            string content = _txtComment.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Vui lòng nh?p bình lu?n!", "C?nh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtComment.Focus();
                return;
            }

            if (content.Length > 1000)
            {
                MessageBox.Show("Bình lu?n không ???c quá 1000 ký t?!", "C?nh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var comment = new Comment
                {
                    PostID = _post.PostID,
                    UserID = _currentUserID,
                    Content = content,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var result = _commentService.AddComment(comment);

                if (result.Item1)
                {
                    _txtComment.Text = "";
                    _txtComment.Focus();
                    LoadComments();
                    _post.CommentCount++;
                    MessageBox.Show("Bình lu?n ?ã ???c g?i!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.Item2, "L?i", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteComment(Comment comment, Panel cardPanel)
        {
            var result = MessageBox.Show(
                "B?n có ch?c mu?n xóa bình lu?n này?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    var deleteResult = _commentService.DeleteComment(comment.CommentID);
                    if (deleteResult.Item1)
                    {
                        _pnlCommentsList.Controls.Remove(cardPanel);
                        _comments.Remove(comment);
                        _post.CommentCount--;
                        RefreshCommentsList();
                        MessageBox.Show("Bình lu?n ?ã ???c xóa", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(deleteResult.Item2, "L?i",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L?i: " + ex.Message, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetTimeAgo(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "v?a xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes}m tr??c";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours}h tr??c";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays}d tr??c";
            else if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)}w tr??c";
            else
                return date.ToString("dd/MM/yyyy");
        }
    }
}
