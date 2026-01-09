using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmCommentSection : Form
    {
        private CommentService _commentService;
        private PostService _postService;
        private Post _post;
        private Panel _pnlComments;
        private TextBox _txtComment;
        private Label _lblCommentCount;

        public frmCommentSection(Post post)
        {
            InitializeComponent();
            _post = post;
            _commentService = new CommentService();
            _postService = new PostService();
            SetupUI();
            LoadComments();
        }

        private void SetupUI()
        {
            this.Text = $"Bình lu?n - {_post.Username}";
            this.Size = new System.Drawing.Size(600, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 245);

            // Main panel
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(10)
            };

            // Post preview header
            Panel pnlPostHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            Label lblUsername = new Label
            {
                Text = $"?? {_post.Username}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblContent = new Label
            {
                Text = _post.Content.Length > 100 ? _post.Content.Substring(0, 100) + "..." : _post.Content,
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 35),
                AutoSize = true,
                MaximumSize = new Size(560, 50)
            };

            _lblCommentCount = new Label
            {
                Text = $"?? {_post.LikeCount}  ?? {_post.CommentCount}  ?? {_post.ShareCount}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(10, 85),
                AutoSize = true
            };

            pnlPostHeader.Controls.Add(lblUsername);
            pnlPostHeader.Controls.Add(lblContent);
            pnlPostHeader.Controls.Add(_lblCommentCount);

            // Comments list
            _pnlComments = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 245),
                AutoScroll = true,
                Padding = new Padding(0, 10, 0, 0)
            };

            // Comment input section
            Panel pnlCommentInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            _txtComment = new TextBox
            {
                Location = new Point(10, 10),
                Size = new System.Drawing.Size(490, 35),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10)
            };

            Button btnSend = new Button
            {
                Text = "G?i",
                Location = new Point(510, 10),
                Size = new System.Drawing.Size(70, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.Click += (s, e) => SendComment();

            pnlCommentInput.Controls.Add(_txtComment);
            pnlCommentInput.Controls.Add(btnSend);

            pnlMain.Controls.Add(_pnlComments);
            pnlMain.Controls.Add(pnlPostHeader);
            pnlMain.Controls.Add(pnlCommentInput);

            this.Controls.Add(pnlMain);
        }

        private void LoadComments()
        {
            try
            {
                _pnlComments.Controls.Clear();

                List<Comment> comments = _commentService.GetCommentsByPost(_post.PostID);

                if (comments.Count == 0)
                {
                    Label lblNoComments = new Label
                    {
                        Text = "Ch?a có bình lu?n nào. Hãy là ng??i bình lu?n ??u tiên! ??",
                        Font = new Font("Segoe UI", 10),
                        ForeColor = Color.Gray,
                        Location = new Point(20, 20),
                        AutoSize = true
                    };
                    _pnlComments.Controls.Add(lblNoComments);
                }
                else
                {
                    foreach (Comment comment in comments)
                    {
                        AddCommentControl(comment);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i t?i bình lu?n: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCommentControl(Comment comment)
        {
            Panel pnlComment = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 5)
            };

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 40,
                Height = 40,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(comment.UserAvatar),
                Cursor = Cursors.Hand
            };

            // Username
            Label lblUsername = new Label
            {
                Text = comment.Username,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(60, 10),
                AutoSize = true
            };

            // Date
            Label lblDate = new Label
            {
                Text = GetTimeAgo(comment.CreatedDate),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(60, 30),
                AutoSize = true
            };

            // Content
            Label lblContent = new Label
            {
                Text = comment.Content,
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 55),
                AutoSize = true,
                MaximumSize = new Size(520, 50)
            };

            pnlComment.Controls.Add(pbAvatar);
            pnlComment.Controls.Add(lblUsername);
            pnlComment.Controls.Add(lblDate);
            pnlComment.Controls.Add(lblContent);

            // Menu button (for comment owner)
            int currentUserID = SessionManager.GetCurrentUserID();
            if (currentUserID == comment.UserID)
            {
                Button btnMenu = new Button
                {
                    Text = "?",
                    Width = 35,
                    Height = 30,
                    Location = new Point(545, 10),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = Color.Gray,
                    Font = new Font("Arial", 12),
                    Cursor = Cursors.Hand
                };
                btnMenu.FlatAppearance.BorderSize = 0;
                btnMenu.Click += (s, e) => ShowCommentMenu(comment, pnlComment);
                pnlComment.Controls.Add(btnMenu);
            }

            _pnlComments.Controls.Add(pnlComment);
        }

        private void ShowCommentMenu(Comment comment, Panel pnlComment)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            
            ToolStripMenuItem editItem = new ToolStripMenuItem("?? Ch?nh s?a", null, (s, e) => EditComment(comment, pnlComment));
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("??? Xóa", null, (s, e) => DeleteComment(comment, pnlComment));
            
            menu.Items.Add(editItem);
            menu.Items.Add(deleteItem);
            
            menu.Show(Cursor.Position);
        }

        private void EditComment(Comment comment, Panel pnlComment)
        {
            Form frmEdit = new Form
            {
                Text = "Ch?nh s?a bình lu?n",
                Size = new System.Drawing.Size(400, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            TextBox txtEditContent = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 10),
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                Text = comment.Content
            };

            Panel pnlButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = SystemColors.Control
            };

            Button btnSave = new Button
            {
                Text = "L?u",
                Location = new Point(220, 10),
                Size = new System.Drawing.Size(80, 35),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.OK
            };
            btnSave.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button
            {
                Text = "H?y",
                Location = new Point(310, 10),
                Size = new System.Drawing.Size(80, 35),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);

            frmEdit.Controls.Add(txtEditContent);
            frmEdit.Controls.Add(pnlButtons);

            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                string newContent = txtEditContent.Text.Trim();
                if (string.IsNullOrWhiteSpace(newContent))
                {
                    MessageBox.Show("N?i dung bình lu?n không ???c tr?ng", "C?nh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                comment.Content = newContent;
                var result = _commentService.UpdateComment(comment);
                if (result.Item1)
                {
                    LoadComments();
                }
                else
                {
                    MessageBox.Show(result.Item2, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmEdit.Dispose();
        }

        private void SendComment()
        {
            string content = _txtComment.Text.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Bình lu?n không ???c tr?ng", "C?nh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Comment comment = new Comment
                {
                    PostID = _post.PostID,
                    UserID = SessionManager.GetCurrentUserID(),
                    Username = SessionManager.GetCurrentUsername(),
                    UserAvatar = SessionManager.GetCurrentUserAvatar(),
                    Content = content,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var result = _commentService.AddComment(comment);

                if (result.Item1)
                {
                    _txtComment.Clear();
                    _post.CommentCount++;
                    _lblCommentCount.Text = $"?? {_post.LikeCount}  ?? {_post.CommentCount}  ?? {_post.ShareCount}";
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
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteComment(Comment comment, Panel pnlComment)
        {
            var result = MessageBox.Show("B?n có ch?c mu?n xóa bình lu?n này?", "Xác nh?n",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var deleteResult = _commentService.DeleteComment(comment.CommentID, SessionManager.GetCurrentUserID());
                if (deleteResult.Item1)
                {
                    _pnlComments.Controls.Remove(pnlComment);
                    _post.CommentCount--;
                    _lblCommentCount.Text = $"?? {_post.LikeCount}  ?? {_post.CommentCount}  ?? {_post.ShareCount}";
                }
                else
                {
                    MessageBox.Show(deleteResult.Item2, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                g.DrawString("??", new Font("Arial", 16), Brushes.White, new PointF(8, 6));
            }
            return bmp;
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
            else
                return date.ToString("dd/MM/yyyy");
        }
    }
}
