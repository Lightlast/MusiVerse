using MusiVerse.DTO.Models;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucUserProfile : UserControl
    {
        private User _user;

        public User UserData { get => _user; set => _user = value; }

        public event EventHandler OnFollowClicked;
        public event EventHandler OnMessageClicked;
        public event EventHandler OnViewPostsClicked;

        public ucUserProfile()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(350, 400);
        }

        public void LoadUserProfile(User user)
        {
            _user = user;
            DisplayUserProfile();
        }

        private void DisplayUserProfile()
        {
            if (_user == null) return;

            this.Controls.Clear();

            // Avatar
            PictureBox pbAvatar = new PictureBox
            {
                Width = 120,
                Height = 120,
                Location = new Point(115, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = LoadUserAvatar(_user.Avatar),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(pbAvatar);

            // Username
            Label lblUsername = new Label
            {
                Text = _user.Username,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(15, 160),
                AutoSize = true,
                ForeColor = Color.FromArgb(30, 30, 30)
            };
            this.Controls.Add(lblUsername);

            // Full Name
            Label lblFullName = new Label
            {
                Text = _user.FullName ?? "N/A",
                Font = new Font("Segoe UI", 11),
                Location = new Point(15, 190),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblFullName);

            // Role Badge
            Label lblRole = new Label
            {
                Text = GetRoleBadge(_user.Role),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(15, 220),
                AutoSize = true,
                ForeColor = GetRoleColor(_user.Role),
                BackColor = GetRoleBackColor(_user.Role),
                Padding = new Padding(5, 2, 5, 2)
            };
            this.Controls.Add(lblRole);

            // Bio
            if (!string.IsNullOrWhiteSpace(_user.Bio))
            {
                Label lblBio = new Label
                {
                    Text = _user.Bio,
                    Font = new Font("Segoe UI", 10),
                    Location = new Point(15, 260),
                    Size = new Size(320, 60),
                    AutoSize = false,
                    ForeColor = Color.FromArgb(80, 80, 80)
                };
                this.Controls.Add(lblBio);
            }

            // Action Buttons
            Panel pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.FromArgb(240, 240, 245),
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnFollow = new Button
            {
                Text = "🔔 Follow",
                Location = new Point(10, 10),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnFollow.FlatAppearance.BorderSize = 0;
            btnFollow.Click += (s, e) => OnFollowClicked?.Invoke(this, EventArgs.Empty);
            pnlActions.Controls.Add(btnFollow);

            Button btnMessage = new Button
            {
                Text = "💬 Message",
                Location = new Point(120, 10),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnMessage.FlatAppearance.BorderSize = 0;
            btnMessage.Click += (s, e) => OnMessageClicked?.Invoke(this, EventArgs.Empty);
            pnlActions.Controls.Add(btnMessage);

            Button btnPosts = new Button
            {
                Text = "📝 Posts",
                Location = new Point(230, 10),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(255, 140, 0),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPosts.FlatAppearance.BorderSize = 0;
            btnPosts.Click += (s, e) => OnViewPostsClicked?.Invoke(this, EventArgs.Empty);
            pnlActions.Controls.Add(btnPosts);

            this.Controls.Add(pnlActions);
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

            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 149, 237));
                g.DrawString("👤", new Font("Arial", 48), Brushes.White, new PointF(25, 25));
            }
            return bmp;
        }

        private string GetRoleBadge(string role)
        {
            if (role == "Admin") return "🔐 Admin";
            if (role == "Artist") return "🎤 Artist";
            if (role == "IndieArtist") return "🎸 Indie Artist";
            return "👤 User";
        }

        private Color GetRoleColor(string role)
        {
            if (role == "Admin") return Color.FromArgb(200, 0, 0);
            if (role == "Artist") return Color.FromArgb(0, 120, 215);
            if (role == "IndieArtist") return Color.FromArgb(255, 140, 0);
            return Color.FromArgb(100, 100, 100);
        }

        private Color GetRoleBackColor(string role)
        {
            if (role == "Admin") return Color.FromArgb(255, 200, 200);
            if (role == "Artist") return Color.FromArgb(200, 230, 255);
            if (role == "IndieArtist") return Color.FromArgb(255, 220, 180);
            return Color.FromArgb(230, 230, 230);
        }
    }
}
