using MusiVerse.BLL.Services;
using MusiVerse.DAL.Repositories;
using MusiVerse.GUI.Forms.Auth;
using MusiVerse.GUI.UserControls;
using MusiVerse.GUI.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Main
{
    public partial class frmMain : Form
    {
        private System.Windows.Forms.Button currentSelectedButton;
        private ucMusicPage currentMusicPage;
        private ucSocialNetworkPage currentSocialNetworkPage;
        public frmMain()
        {
            InitializeComponent();
            MusicPlayerService.Instance.SongChanged += ShowMusicPlayer;
        }

        private void ShowMusicPlayer(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowMusicPlayer(sender, e)));
                return;
            }

            // Hiển thị music player (nó đã được add vào Designer)
            ucMusicPlayer1.Visible = true;
            ucMusicPlayer1.BringToFront();
        }

        private void HideMusicPlayer(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HideMusicPlayer(sender, e)));
                return;
            }

            ucMusicPlayer1.Visible = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Subscribe vào event OnPlayerStopped của ucMusicPlayer1
            ucMusicPlayer1.OnPlayerStopped += HideMusicPlayer;

            SetupUI();
            LoadHomePage();
        }

        private void SetupUI()
        {
            lblAccountInfo.Text = SessionManager.GetCurrentUsername();
            SetupMenuByRole();
            SelectMenuButton(btnHome);
        }

        private void SetupMenuByRole()
        {
            string role = SessionManager.CurrentUser?.Role ?? "User";

            btnHome.Visible = true;
            btnMusic.Visible = true;
            btnSocialNetwork.Visible = true;
            btnShopping.Visible = true;
            btnPersonalPage.Visible = true;
            btnVIP.Visible = true;
            btnVIP.Text = "🎵 VIP - Không quảng cáo";
            btnVIP.BackColor = Color.FromArgb(255, 140, 0);

            if (SessionManager.CurrentUser.HasVIP)
            {
                btnVIP.Text = "⭐ VIP Active";
                btnVIP.BackColor = Color.FromArgb(218, 165, 32);
            }

            if (role == "User")
            {
                btnUpRole.Text = "⬆ Nâng cấp Artist";
                btnUpRole.Visible = true;
            }
            else
            {
                btnUpRole.Visible = false;
            }
        }

        #region Menu Navigation

        private void btnHome_Click(object sender, EventArgs e)
        {
            SelectMenuButton(btnHome);
            LoadHomePage();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            SelectMenuButton(btnMusic);
            LoadMusicPage();
        }

        private void btnSocialNetwork_Click(object sender, EventArgs e)
        {
            SelectMenuButton(btnSocialNetwork);
            LoadSocialNetworkPage();
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            SelectMenuButton(btnShopping);
            LoadShoppingPage();
        }

        private void btnPersonalPage_Click(object sender, EventArgs e)
        {
            SelectMenuButton(btnPersonalPage);
            LoadPersonalPage();
        }

        private void btnVIP_Click(object sender, EventArgs e)
        {
            ShowVIPPackageForm();
        }

        private void btnUpRole_Click(object sender, EventArgs e)
        {
            ShowUpgradeToArtistForm();
        }

        private void ShowVIPPackageForm()
        {
            var result = MessageBox.Show(
                "🎵 GÓI VIP - KHÔNG QUẢNG CÁO\n\n" +
                "Quyền lợi:\n" +
                "✓ Nghe nhạc không bị quảng cáo\n" +
                "✓ Chất lượng âm thanh cao (320kbps)\n" +
                "✓ Tải nhạc offline\n" +
                "✓ Bỏ qua bài hát không giới hạn\n\n" +
                "💰 Giá: 59.000đ/tháng\n" +
                "💰 Giá: 590.000đ/năm (Tiết kiệm 15%)\n\n" +
                "Bạn có muốn mua gói VIP không?",
                "Mua gói VIP",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Chức năng thanh toán đang được phát triển!\n\n" +
                    "Sẽ tích hợp:\n" +
                    "• MoMo\n" +
                    "• VNPay\n" +
                    "• ZaloPay\n" +
                    "• Banking",
                    "Thanh toán",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void ShowUpgradeToArtistForm()
        {
            frmUpgradeToArtist upgradeForm = new frmUpgradeToArtist();

            if (upgradeForm.ShowDialog() == DialogResult.OK)
            {
                SetupUI();
                MessageBox.Show(
                    "🎉 Chúc mừng! Bạn đã trở thành nghệ sĩ!\n\n" +
                    "Bây giờ bạn có thể:\n" +
                    "✓ Upload nhạc không giới hạn\n" +
                    "✓ Đăng bài trên Social Network\n" +
                    "✓ Tạo và bán vé Concert\n\n" +
                    "Hãy vào trang cá nhân và khám phá ngay!",
                    "Nâng cấp thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void SelectMenuButton(System.Windows.Forms.Button button)
        {
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.FromArgb(40, 40, 60);
            }

            button.BackColor = Color.FromArgb(255, 140, 0);
            currentSelectedButton = button;
        }

        #endregion

        #region Load Pages

        private void LoadHomePage()
        {
            ClearContentExceptMusicPlayer();

            System.Windows.Forms.Label lblWelcome = new System.Windows.Forms.Label
            {
                Text = $"Chào mừng {SessionManager.GetCurrentUsername()}\nđến với Musiverse! 🎵",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                AutoSize = false,
                Size = new Size(800, 100),
                Location = new Point(200, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContent.Controls.Add(lblWelcome);

            System.Windows.Forms.Panel logoPanel = new System.Windows.Forms.Panel
            {
                Size = new Size(600, 400),
                Location = new Point(250, 180),
                BackColor = Color.FromArgb(20, 20, 40),
                BorderStyle = BorderStyle.FixedSingle
            };

            System.Windows.Forms.Label lblLogo = new System.Windows.Forms.Label
            {
                Text = "MUSIVERSE\n🎵 🎸 🎤",
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                ForeColor = Color.Cyan,
                AutoSize = false,
                Size = new Size(600, 400),
                TextAlign = ContentAlignment.MiddleCenter
            };
            logoPanel.Controls.Add(lblLogo);
            panelContent.Controls.Add(logoPanel);

            System.Windows.Forms.Label lblInfo = new System.Windows.Forms.Label
            {
                Text = "🎵 Khám phá âm nhạc  |  📱 Kết nối với nghệ sĩ  |  🎫 Mua vé concert",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.Gray,
                AutoSize = false,
                Size = new Size(800, 40),
                Location = new Point(150, 600),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContent.Controls.Add(lblInfo);
        }

        private void LoadMusicPage()
        {
            ClearContentExceptMusicPlayer();

            try
            {
                currentMusicPage = new ucMusicPage
                {
                    Dock = System.Windows.Forms.DockStyle.Fill
                };
                
                currentMusicPage.OnSongRequested += (sender, song) =>
                {
                };

                // Subscribe to show song detail event
                currentMusicPage.OnShowSongDetail += (sender, song) => ShowSongDetail(song);
                
                // Subscribe to show playlist detail event
                currentMusicPage.OnShowPlaylistDetail += (sender, playlist) => ShowPlaylistDetail(playlist);
                
                panelContent.Controls.Add(currentMusicPage);
            }
            catch (Exception ex)
            {
                ShowErrorPage("🎵 THƯ VIỆN NHẠC", $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Hiển thị chi tiết bài hát trong panelContent của frmMain
        /// </summary>
        public void ShowSongDetail(MusiVerse.DTO.Models.Song song)
        {
            try
            {
                ClearContentExceptMusicPlayer();

                ucSongDetail songDetailControl = new ucSongDetail
                {
                    Dock = DockStyle.Fill
                };

                // Subscribe to events
                songDetailControl.OnSongSelected += (s, selectedSong) => ShowSongDetail(selectedSong);
                songDetailControl.OnAlbumSelected += (s, album) => ShowAlbumDetail(album);

                songDetailControl.LoadSongDetail(song);
                
                panelContent.Controls.Add(songDetailControl);
            }
            catch (Exception ex)
            {
                ShowErrorPage("🎵 CHI TIẾT BÀI HÁT", $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Hiển thị chi tiết album trong panelContent của frmMain
        /// </summary>
        public void ShowAlbumDetail(MusiVerse.DTO.Models.Album album)
        {
            try
            {
                ClearContentExceptMusicPlayer();

                // TODO: Implement album detail view if needed
                MessageBox.Show($"Album: {album.Title}\n\nChức năng xem chi tiết album đang được phát triển",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadMusicPage();
            }
            catch (Exception ex)
            {
                ShowErrorPage("💿 CHI TIẾT ALBUM", $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Hiển thị chi tiết playlist trong panelContent của frmMain
        /// </summary>
        public void ShowPlaylistDetail(MusiVerse.DTO.Models.Playlist playlist)
        {
            try
            {
                ClearContentExceptMusicPlayer();

                Panel playlistHeader = new Panel
                {
                    Size = new Size(panelContent.Width - 20, 180),
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(230, 240, 255),
                    BorderStyle = BorderStyle.FixedSingle
                };

                PictureBox pbPlaylistCover = new PictureBox
                {
                    Size = new Size(140, 140),
                    Location = new Point(10, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                if (!string.IsNullOrEmpty(playlist.CoverImage) && System.IO.File.Exists(playlist.CoverImage))
                {
                    try
                    {
                        pbPlaylistCover.Image = Image.FromFile(playlist.CoverImage);
                    }
                    catch
                    {
                        pbPlaylistCover.Image = CreateDefaultPlaylistCover();
                    }
                }
                else
                {
                    pbPlaylistCover.Image = CreateDefaultPlaylistCover();
                }

                playlistHeader.Controls.Add(pbPlaylistCover);

                Label lblPlaylistTitle = new Label
                {
                    Text = playlist.Name,
                    Location = new Point(160, 15),
                    Size = new Size(400, 40),
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 144, 255),
                    AutoSize = false
                };
                playlistHeader.Controls.Add(lblPlaylistTitle);

                Label lblDescription = new Label
                {
                    Text = playlist.Description ?? "Không có mô tả",
                    Location = new Point(160, 60),
                    Size = new Size(400, 40),
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Color.Gray,
                    AutoSize = false
                };
                playlistHeader.Controls.Add(lblDescription);

                Label lblInfo = new Label
                {
                    Text = $"📅 Tạo: {playlist.CreatedDate:dd/MM/yyyy} | 🎵 {playlist.SongCount} bài hát",
                    Location = new Point(160, 105),
                    Size = new Size(400, 30),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.DarkGray
                };
                playlistHeader.Controls.Add(lblInfo);

                Label lblVisibility = new Label
                {
                    Text = playlist.IsPublic ? "🌐 Public" : "🔒 Private",
                    Location = new Point(160, 140),
                    Size = new Size(400, 25),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = playlist.IsPublic ? Color.Green : Color.Red
                };
                playlistHeader.Controls.Add(lblVisibility);

                panelContent.Controls.Add(playlistHeader);

                // Load songs in playlist
                FlowLayoutPanel flowPanelSongs = new FlowLayoutPanel
                {
                    Location = new Point(10, 200),
                    Size = new Size(panelContent.Width - 20, panelContent.Height - 220),
                    AutoScroll = true,
                    BackColor = Color.White
                };

                var playlistService = new MusiVerse.BLL.Services.PlaylistService();
                List<MusiVerse.DTO.Models.Song> playlistSongs = playlistService.GetPlaylistSongs(playlist.PlaylistID);

                if (playlistSongs.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "Playlist này không có bài hát nào",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(50, 50)
                    };
                    flowPanelSongs.Controls.Add(lblEmpty);
                }
                else
                {
                    var songRepository = new MusiVerse.DAL.Repositories.SongRepository();
                    foreach (var song in playlistSongs)
                    {
                        ucSongItem songItem = new ucSongItem(song);

                        songItem.OnPlayClicked += (s, e) =>
                        {
                            bool isPlaying = MusicPlayerService.Instance.LoadAndPlay(song);
                            if (isPlaying)
                            {
                                songRepository.IncrementPlayCount(song.SongID);
                            }
                        };

                        songItem.OnSongTitleClicked += (s, e) => ShowSongDetail(song);

                        flowPanelSongs.Controls.Add(songItem);
                    }
                }

                panelContent.Controls.Add(flowPanelSongs);
            }
            catch (Exception ex)
            {
                ShowErrorPage("📋 CHI TIẾT PLAYLIST", $"Lỗi: {ex.Message}");
            }
        }

        private Image CreateDefaultPlaylistCover()
        {
            Bitmap bmp = new Bitmap(140, 140);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(100, 100, 120));
                g.DrawString("🎵", new Font("Arial", 60), Brushes.White, new PointF(20, 20));
            }
            return bmp;
        }

        private void LoadSocialNetworkPage()
        {
            ClearContentExceptMusicPlayer();

            try
            {
                currentSocialNetworkPage = new ucSocialNetworkPage
                {
                    Dock = System.Windows.Forms.DockStyle.Fill
                };
                panelContent.Controls.Add(currentSocialNetworkPage);
            }
            catch (Exception ex)
            {
                ShowErrorPage("📱 SOCIAL NETWORK", $"Lỗi: {ex.Message}");
            }
        }

        private void LoadShoppingPage()
        {
            ClearContentExceptMusicPlayer();

            try
            {
                ucShopping shoppingPage = new ucShopping
                {
                    Dock = System.Windows.Forms.DockStyle.Fill
                };
                panelContent.Controls.Add(shoppingPage);
            }
            catch (Exception ex)
            {
                ShowErrorPage("🛍️ MUA VÉ CONCERT", $"Lỗi: {ex.Message}");
            }
        }

        private void LoadPersonalPage()
        {
            ClearContentExceptMusicPlayer();

            try
            {
                ucPersonalPage personalPage = new ucPersonalPage
                {
                    Dock = DockStyle.Fill
                };
                panelContent.Controls.Add(personalPage);
            }
            catch (Exception ex)
            {
                ShowErrorPage("👤 TRANG CÁ NHÂN", $"Lỗi: {ex.Message}");
            }
        }

        private void ShowErrorPage(string title, string message)
        {
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = title,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelContent.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblMessage = new System.Windows.Forms.Label
            {
                Text = message,
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 80),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            panelContent.Controls.Add(lblMessage);
        }

        /// <summary>
        /// Xóa tất cả controls trong panelContent NGOẠI TRỪ ucMusicPlayer1
        /// </summary>
        private void ClearContentExceptMusicPlayer()
        {
            // Lưu lại ucMusicPlayer1
            Control musicPlayer = ucMusicPlayer1;

            // Xóa tất cả controls
            panelContent.Controls.Clear();

            // Thêm lại ucMusicPlayer1
            panelContent.Controls.Add(musicPlayer);
        }
        #endregion

        #region Top Bar Actions

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show(
                    $"Tìm kiếm: {searchText}\n\n(Chức năng đang phát triển)",
                    "Tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Vui lòng nhập từ khóa tìm kiếm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "🔔 Bạn không có thông báo mới",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "⚙️ Cài đặt đang được phát triển",
                "Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void lblAccountInfo_Click(object sender, EventArgs e)
        {
            ContextMenuStrip accountMenu = new ContextMenuStrip();

            accountMenu.Items.Add("👤 Profile", null, (s, args) => LoadPersonalPage());
            accountMenu.Items.Add("⚙️ Cài đặt", null, (s, args) => btnSettings_Click(s, args));
            accountMenu.Items.Add(new ToolStripSeparator());
            accountMenu.Items.Add("🚪 Đăng xuất", null, btnLogout_Click);

            accountMenu.Show(lblAccountInfo, new Point(0, lblAccountInfo.Height));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();

                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                var result = MessageBox.Show(
                    "Bạn có chắc muốn thoát ứng dụng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    MusicPlayerService.Instance.Stop();
                }
            }
        }
    }
}