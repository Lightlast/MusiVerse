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

        public frmCommentDialog(Post post, int currentUserID)
        {
            InitializeComponent();
            _post = post;
            _currentUserID = currentUserID;
            _commentService = new CommentService();
            _comments = new List<Comment>();
            SetupUI();
            LoadComments();
        }

        private void SetupUI()
        {
            this.Text = "?? Bình lu?n";
            this.Size = new System.Drawing.Size(700, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Panel ch?a n?i dung bài vi?t
            Panel pnlPostInfo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            Label lblPostUser = new Label
            {
                Text = $"?? {_post.Username}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Label lblPostContent = new Label
            {
                Text = _post.Content,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(680, 40),
                Location = new Point(10, 35),
                ForeColor = Color.Gray
            };

            pnlPostInfo.Controls.Add(lblPostUser);
            pnlPostInfo.Controls.Add(lblPostContent);

            // Panel ch?a danh sách bình lu?n
            Panel pnlComments = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                AutoScroll = true,
                Padding = new Padding(10)
            };

            // Panel input bình lu?n
            Panel pnlInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            TextBox txtComment = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(620, 35),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                Text = "Vi?t bình lu?n..."
            };

            Button btnPostComment = new Button
            {
                Text = "G?i",
                Location = new Point(640, 10),
                Size = new Size(50, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPostComment.FlatAppearance.BorderSize = 0;
            btnPostComment.Click += (s, e) => AddComment(txtComment, pnlComments);

            pnlInput.Controls.Add(txtComment);
            pnlInput.Controls.Add(btnPostComment);

            this.Controls.Add(pnlComments);
            this.Controls.Add(pnlInput);
            this.Controls.Add(pnlPostInfo);
        }

        private void LoadComments()
        {
            try
            {
                _comments = _commentService.GetCommentsByPost(_post.PostID);

                Panel pnlComments = (Panel)this.Controls["pnlComments"];
                if (pnlComments != null)
                {
                    pnlComments.Controls.Clear();

                    if (_comments.Count == 0)
                    {
                        Label lblEmpty = new Label
                        {
                            Text = "Ch?a có bình lu?n nào. Hãy bình lu?n ??u tiên!",
                            Font = new Font("Segoe UI", 10),
                            ForeColor = Color.Gray,
                            AutoSize = true,
                            Location = new Point(10, 10)
                        };
                        pnlComments.Controls.Add(lblEmpty);
                    }
                    else
                    {
                        int yPos = 0;
                        foreach (var comment in _comments)
                        {
                            Panel commentCard = CreateCommentCard(comment, yPos);
                            pnlComments.Controls.Add(commentCard);
                            yPos += commentCard.Height + 10;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i bình lu?n: " + ex.Message, "L?i");
            }
        }

        private Panel CreateCommentCard(Comment comment, int yPos)
        {
            Panel card = new Panel
            {
                Size = new Size(680, 70),
                Location = new Point(0, yPos),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblAuthor = new Label
            {
                Text = comment.Username,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 8)
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(comment.CreatedDate),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(200, 8)
            };

            Label lblContent = new Label
            {
                Text = comment.Content,
                Font = new Font("Segoe UI", 9),
                AutoSize = false,
                Size = new Size(650, 40),
                Location = new Point(10, 28),
                ForeColor = Color.Black
            };

            // Delete button (for comment owner)
            if (_currentUserID == comment.UserID)
            {
                Button btnDelete = new Button
                {
                    Text = "???",
                    Size = new Size(30, 25),
                    Location = new Point(650, 8),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 10),
                    Cursor = Cursors.Hand
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += (s, e) => DeleteComment(comment);
                card.Controls.Add(btnDelete);
            }

            card.Controls.Add(lblAuthor);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblContent);

            return card;
        }

        private void AddComment(TextBox txtComment, Panel pnlComments)
        {
            string content = txtComment.Text.Trim();

            if (string.IsNullOrWhiteSpace(content) || content == "Vi?t bình lu?n...")
            {
                MessageBox.Show("Vui lòng nh?p bình lu?n", "C?nh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var comment = new Comment
                {
                    PostID = _post.PostID,
                    UserID = _currentUserID,
                    Content = content
                };

                var result = _commentService.AddComment(comment);

                if (result.Item1)
                {
                    txtComment.Text = "Vi?t bình lu?n...";
                    LoadComments();
                }
                else
                {
                    MessageBox.Show(result.Item2, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private void DeleteComment(Comment comment)
        {
            var result = MessageBox.Show(
                "B?n có ch?c mu?n xóa bình lu?n này?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                var deleteResult = _commentService.DeleteComment(comment.CommentID);
                if (deleteResult.Item1)
                {
                    LoadComments();
                }
                else
                {
                    MessageBox.Show(deleteResult.Item2, "L?i");
                }
            }
        }

        private string GetTimeAgo(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "v?a xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes}m";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours}h";
            else
                return date.ToString("dd/MM/yyyy");
        }
    }
}
