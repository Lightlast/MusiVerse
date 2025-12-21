using MusiVerse.DAL.Repositories;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.UserControls
{
    public partial class ucPersonalPage : UserControl
    {
        private SongRepository songRepository;
        private bool isArtistMode = false;

        public ucPersonalPage()
        {
            InitializeComponent();
            songRepository = new SongRepository();
        }

        private void ucPersonalPage_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            SetupUIByRole();
            LoadDefaultTab();
        }

        private void LoadUserInfo()
        {
            var user = SessionManager.CurrentUser;
            if (user == null) return;

            // Avatar
            if (!string.IsNullOrEmpty(user.Avatar) && System.IO.File.Exists(user.Avatar))
            {
                pictureBoxAvatar.Image = Image.FromFile(user.Avatar);
            }
            else
            {
                pictureBoxAvatar.Image = CreateDefaultAvatar(user.FullName);
            }

            // Thông tin cơ bản
            lblUsername.Text = user.FullName ?? user.Username;
            lblEmail.Text = user.Email;

            // Role badge
            if (user.Role == "Artist" || user.Role == "IndieArtist")
            {
                lblVerifiedBadge.Text = "✓";
                lblVerifiedBadge.Visible = true;
                lblRoleDisplay.Text = user.Role == "Artist" ? "Nghệ sĩ chính thức" : "Nghệ sĩ độc lập";
            }
            else
            {
                lblVerifiedBadge.Visible = false;
                lblRoleDisplay.Text = "Người dùng";
            }
        }

        private void SetupUIByRole()
        {
            string role = SessionManager.CurrentUser?.Role ?? "User";

            // USER TABS (Tất cả user đều có)
            tabControlMain.TabPages.Clear();
            tabControlMain.TabPages.Add(tabMusic);
            tabControlMain.TabPages.Add(tabSocial);
            tabControlMain.TabPages.Add(tabShopping);

            // ARTIST TABS (Chỉ Artist mới có)
            if (role == "Artist" || role == "IndieArtist")
            {
                // Thêm nút chuyển đổi chế độ
                btnSwitchToArtistMode.Visible = true;
                btnSwitchToArtistMode.Text = "🎤 Chuyển sang chế độ Nghệ sĩ";
            }
            else
            {
                btnSwitchToArtistMode.Visible = false;
            }
        }

        #region User Mode Tabs

        private void LoadDefaultTab()
        {
            // Load tab Music mặc định
            tabControlMain.SelectedTab = tabMusic;
            LoadUserMusicTab();
        }

        // TAB MUSIC - User thường
        private void LoadUserMusicTab()
        {
            panelMusicContent.Controls.Clear();

            // Sub-tabs cho Music
            Panel panelSubTabs = CreateSubTabPanel();
            Button btnPlaylists = CreateSubTabButton("Danh sách phát", 20);
            Button btnLikedSongs = CreateSubTabButton("Bài hát yêu thích", 220);
            Button btnHistory = CreateSubTabButton("Lịch sử nghe", 420);

            btnPlaylists.Click += (s, e) => LoadUserPlaylists();
            btnLikedSongs.Click += (s, e) => LoadLikedSongs();
            btnHistory.Click += (s, e) => LoadListeningHistory();

            panelSubTabs.Controls.Add(btnPlaylists);
            panelSubTabs.Controls.Add(btnLikedSongs);
            panelSubTabs.Controls.Add(btnHistory);
            panelMusicContent.Controls.Add(panelSubTabs);

            // Load danh sách phát mặc định
            LoadUserPlaylists();
        }

        private void LoadUserPlaylists()
        {
            // Xóa content cũ (trừ sub-tabs)
            while (panelMusicContent.Controls.Count > 1)
            {
                panelMusicContent.Controls.RemoveAt(1);
            }

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 80),
                Size = new Size(900, 500),
                AutoScroll = true
            };

            // Nút tạo playlist mới
            Panel btnCreatePlaylist = CreatePlaylistCard("Tạo danh sách phát +", true);
            btnCreatePlaylist.Click += (s, e) => CreateNewPlaylist();
            flowPanel.Controls.Add(btnCreatePlaylist);

            // Load playlists từ DB
            // TODO: Implement PlaylistRepository
            for (int i = 1; i <= 5; i++)
            {
                Panel playlistCard = CreatePlaylistCard($"Danh sách {i}", false);
                flowPanel.Controls.Add(playlistCard);
            }

            panelMusicContent.Controls.Add(flowPanel);
        }

        private void LoadLikedSongs()
        {
            while (panelMusicContent.Controls.Count > 1)
            {
                panelMusicContent.Controls.RemoveAt(1);
            }

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 80),
                Size = new Size(900, 500),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            // Load bài hát đã like
            var likedSongs = songRepository.GetLikedSongs(SessionManager.GetCurrentUserID());

            foreach (var song in likedSongs)
            {
                Panel songCard = CreateSongCard(song);
                flowPanel.Controls.Add(songCard);
            }

            if (likedSongs.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Bạn chưa có bài hát yêu thích nào",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Color.Gray,
                    AutoSize = true
                };
                flowPanel.Controls.Add(lblEmpty);
            }

            panelMusicContent.Controls.Add(flowPanel);
        }

        private void LoadListeningHistory()
        {
            while (panelMusicContent.Controls.Count > 1)
            {
                panelMusicContent.Controls.RemoveAt(1);
            }

            Label lblTemp = new Label
            {
                Text = "Lịch sử nghe đang được phát triển",
                Font = new Font("Segoe UI", 14),
                Location = new Point(300, 200),
                AutoSize = true
            };
            panelMusicContent.Controls.Add(lblTemp);
        }

        // TAB SOCIAL
        private void LoadUserSocialTab()
        {
            panelSocialContent.Controls.Clear();

            Panel panelSubTabs = CreateSubTabPanel();
            Button btnSavedPosts = CreateSubTabButton("Post đã lưu", 20);
            Button btnLikedPosts = CreateSubTabButton("Post yêu thích", 220);

            btnSavedPosts.Click += (s, e) => LoadSavedPosts();
            btnLikedPosts.Click += (s, e) => LoadLikedPosts();

            panelSubTabs.Controls.Add(btnSavedPosts);
            panelSubTabs.Controls.Add(btnLikedPosts);
            panelSocialContent.Controls.Add(panelSubTabs);

            LoadSavedPosts();
        }

        private void LoadSavedPosts()
        {
            MessageBox.Show("Tính năng đang phát triển", "Thông báo");
        }

        private void LoadLikedPosts()
        {
            MessageBox.Show("Tính năng đang phát triển", "Thông báo");
        }

        // TAB SHOPPING
        private void LoadUserShoppingTab()
        {
            panelShoppingContent.Controls.Clear();

            Panel panelSubTabs = CreateSubTabPanel();
            Button btnActiveTickets = CreateSubTabButton("Vé đang hiệu lực", 20);
            Button btnPurchasedTickets = CreateSubTabButton("Vé đã mua", 250);

            btnActiveTickets.Click += (s, e) => LoadActiveTickets();
            btnPurchasedTickets.Click += (s, e) => LoadPurchasedTickets();

            panelSubTabs.Controls.Add(btnActiveTickets);
            panelSubTabs.Controls.Add(btnPurchasedTickets);
            panelShoppingContent.Controls.Add(panelSubTabs);

            LoadActiveTickets();
        }

        private void LoadActiveTickets()
        {
            MessageBox.Show("Tính năng đang phát triển", "Thông báo");
        }

        private void LoadPurchasedTickets()
        {
            MessageBox.Show("Tính năng đang phát triển", "Thông báo");
        }

        #endregion

        #region Artist Mode

        private void btnSwitchToArtistMode_Click(object sender, EventArgs e)
        {
            isArtistMode = !isArtistMode;

            if (isArtistMode)
            {
                SwitchToArtistMode();
            }
            else
            {
                SwitchToUserMode();
            }
        }

        private void SwitchToArtistMode()
        {
            // Đổi tabs sang chế độ Artist
            tabControlMain.TabPages.Clear();
            tabControlMain.TabPages.Add(tabArtistMusic);
            tabControlMain.TabPages.Add(tabArtistPost);
            tabControlMain.TabPages.Add(tabArtistConcert);
            tabControlMain.TabPages.Add(tabStatistics);

            btnSwitchToArtistMode.Text = "👤 Chuyển về chế độ User";
            btnSwitchToArtistMode.BackColor = Color.FromArgb(100, 100, 120);

            LoadArtistMusicTab();
        }

        private void SwitchToUserMode()
        {
            // Đổi về tabs User bình thường
            tabControlMain.TabPages.Clear();
            tabControlMain.TabPages.Add(tabMusic);
            tabControlMain.TabPages.Add(tabSocial);
            tabControlMain.TabPages.Add(tabShopping);

            btnSwitchToArtistMode.Text = "🎤 Chuyển sang chế độ Nghệ sĩ";
            btnSwitchToArtistMode.BackColor = Color.FromArgb(255, 140, 0);

            LoadUserMusicTab();
        }

        // ARTIST - TAB QUẢN LÝ NHẠC
        private void LoadArtistMusicTab()
        {
            panelArtistMusicContent.Controls.Clear();

            // Sub-tabs cho Artist Music
            Panel panelSubTabs = CreateSubTabPanel();
            Button btnAddSong = CreateSubTabButton("Thêm bài nhạc", 20);
            Button btnEditSong = CreateSubTabButton("Chỉnh sửa", 220);
            Button btnDeleteSong = CreateSubTabButton("Xóa", 370);

            btnAddSong.BackColor = Color.FromArgb(0, 150, 136);
            btnAddSong.Click += (s, e) => OpenUploadSongForm();
            btnEditSong.Click += (s, e) => EditSelectedSong();
            btnDeleteSong.Click += (s, e) => DeleteSelectedSong();

            panelSubTabs.Controls.Add(btnAddSong);
            panelSubTabs.Controls.Add(btnEditSong);
            panelSubTabs.Controls.Add(btnDeleteSong);
            panelArtistMusicContent.Controls.Add(panelSubTabs);

            // Load bài hát của nghệ sĩ
            LoadArtistSongs();
        }

        private void LoadArtistSongs()
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 80),
                Size = new Size(900, 500),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            var artistSongs = songRepository.GetSongsByArtist(
                SessionManager.GetCurrentUserID()
            );

            foreach (var song in artistSongs)
            {
                Panel songCard = CreateArtistSongCard(song);
                flowPanel.Controls.Add(songCard);
            }

            panelArtistMusicContent.Controls.Add(flowPanel);
        }

        private void OpenUploadSongForm()
        {
            MessageBox.Show("Mở form upload nhạc", "Thông báo");
            // frmUploadSong uploadForm = new frmUploadSong();
            // uploadForm.ShowDialog();
        }

        private void EditSelectedSong()
        {
            MessageBox.Show("Chỉnh sửa bài hát", "Thông báo");
        }

        private void DeleteSelectedSong()
        {
            MessageBox.Show("Xóa bài hát", "Thông báo");
        }

        // ARTIST - TAB QUẢN LÝ POST
        private void LoadArtistPostTab()
        {
            MessageBox.Show("Tab quản lý Post đang phát triển", "Thông báo");
        }

        // ARTIST - TAB QUẢN LÝ VÉ
        private void LoadArtistConcertTab()
        {
            MessageBox.Show("Tab quản lý Vé đang phát triển", "Thông báo");
        }

        // ARTIST - TAB THỐNG KÊ
        private void LoadStatisticsTab()
        {
            panelStatisticsContent.Controls.Clear();

            // Thống kê tổng quan
            Label lblTitle = new Label
            {
                Text = "THỐNG KÊ TỔNG QUAN",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelStatisticsContent.Controls.Add(lblTitle);

            // Cards thống kê
            int yPos = 80;
            AddStatCard("Tổng số bài hát", "0", yPos);
            AddStatCard("Tổng lượt nghe", "0", yPos + 100);
            AddStatCard("Tổng followers", "0", yPos + 200);
            AddStatCard("Doanh thu (VND)", "0đ", yPos + 300);
        }

        private void AddStatCard(string label, string value, int yPos)
        {
            Panel card = new Panel
            {
                Size = new Size(200, 80),
                Location = new Point(20, yPos),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblLabel = new Label
            {
                Text = label,
                Location = new Point(10, 10),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(10, 35),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                AutoSize = true
            };

            card.Controls.Add(lblLabel);
            card.Controls.Add(lblValue);
            panelStatisticsContent.Controls.Add(card);
        }

        #endregion

        #region Helper Methods

        private Panel CreateSubTabPanel()
        {
            return new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(950, 60),
                BackColor = Color.White
            };
        }

        private Button CreateSubTabButton(string text, int xPos)
        {
            return new Button
            {
                Text = text,
                Location = new Point(xPos, 10),
                Size = new Size(180, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(230, 230, 240),
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
        }

        private Panel CreatePlaylistCard(string name, bool isCreateNew)
        {
            Panel card = new Panel
            {
                Size = new Size(150, 180),
                BackColor = isCreateNew ? Color.FromArgb(100, 100, 120) : Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            Label lblName = new Label
            {
                Text = name,
                Location = new Point(10, 120),
                Size = new Size(130, 50),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = isCreateNew ? Color.White : Color.Black
            };

            card.Controls.Add(lblName);
            return card;
        }

        private Panel CreateSongCard(dynamic song)
        {
            Panel card = new Panel
            {
                Size = new Size(880, 60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblTitle = new Label
            {
                Text = song.Title,
                Location = new Point(15, 10),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true
            };

            Label lblArtist = new Label
            {
                Text = song.ArtistName,
                Location = new Point(15, 35),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblArtist);

            return card;
        }

        private Panel CreateArtistSongCard(dynamic song)
        {
            Panel card = new Panel
            {
                Size = new Size(200, 250),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblTitle = new Label
            {
                Text = song.Title,
                Location = new Point(10, 170),
                Size = new Size(180, 40),
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.TopCenter
            };

            Label lblPlays = new Label
            {
                Text = $"▶ {song.PlayCount} lượt nghe",
                Location = new Point(10, 215),
                Size = new Size(180, 20),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.TopCenter
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblPlays);

            return card;
        }

        private Image CreateDefaultAvatar(string name)
        {
            Bitmap bmp = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                string initial = string.IsNullOrEmpty(name) ? "?" : name.Substring(0, 1).ToUpper();
                g.DrawString(initial, new Font("Arial", 48, FontStyle.Bold), Brushes.White, new PointF(50, 40));
            }
            return bmp;
        }

        private void CreateNewPlaylist()
        {
            MessageBox.Show("Tính năng tạo playlist đang phát triển", "Thông báo");
        }

        #endregion

        #region Tab Events

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabMusic)
            {
                LoadUserMusicTab();
            }
            else if (tabControlMain.SelectedTab == tabSocial)
            {
                LoadUserSocialTab();
            }
            else if (tabControlMain.SelectedTab == tabShopping)
            {
                LoadUserShoppingTab();
            }
            else if (tabControlMain.SelectedTab == tabArtistMusic)
            {
                LoadArtistMusicTab();
            }
            else if (tabControlMain.SelectedTab == tabArtistPost)
            {
                LoadArtistPostTab();
            }
            else if (tabControlMain.SelectedTab == tabArtistConcert)
            {
                LoadArtistConcertTab();
            }
            else if (tabControlMain.SelectedTab == tabStatistics)
            {
                LoadStatisticsTab();
            }
        }

        #endregion
    }
}