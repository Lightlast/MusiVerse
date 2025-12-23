using MusiVerse.BLL.Services;
using MusiVerse.GUI.Forms.Auth;
using MusiVerse.GUI.UserControls;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Main
{
    public partial class frmMain : Form
    {
        private System.Windows.Forms.Button currentSelectedButton;
        private ucMusicPage currentMusicPage;

        public frmMain()
        {
            InitializeComponent();
            MusicPlayerService.Instance.SongChanged += ShowMusicPlayer;
            musicPlayerBar.OnPlayerStopped += HideMusicPlayer;
            musicPlayerBar.Visible = false;
        }

        private void ShowMusicPlayer(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowMusicPlayer(sender, e)));
                return;
            }

            musicPlayerBar.Visible = true;
            musicPlayerBar.BringToFront();
        }

        private void HideMusicPlayer(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HideMusicPlayer(sender, e)));
                return;
            }

            musicPlayerBar.Visible = false;
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
            panelContent.Controls.Clear();

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
            panelContent.Controls.Clear();

            try
            {
                currentMusicPage = new ucMusicPage
                {
                    Dock = System.Windows.Forms.DockStyle.Fill
                };
                panelContent.Controls.Add(currentMusicPage);
            }
            catch (Exception ex)
            {
                ShowErrorPage("🎵 THƯ VIỆN NHẠC", $"Lỗi: {ex.Message}");
            }
        }

        private void LoadSocialNetworkPage()
        {
            panelContent.Controls.Clear();

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "📱 SOCIAL NETWORK",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelContent.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblTemp = new System.Windows.Forms.Label
            {
                Text = "Tính năng Social Network đang được phát triển...\n\n" +
                       "Sẽ có:\n" +
                       "• News feed\n" +
                       "• Đăng bài (Artist)\n" +
                       "• Like, Comment, Share\n" +
                       "• User profiles",
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 80),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            panelContent.Controls.Add(lblTemp);
        }

        private void LoadShoppingPage()
        {
            panelContent.Controls.Clear();

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "🛍️ MUA VÉ CONCERT",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelContent.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblTemp = new System.Windows.Forms.Label
            {
                Text = "Tính năng Shopping đang được phát triển...\n\n" +
                       "Sẽ có:\n" +
                       "• Danh sách concerts\n" +
                       "• Chi tiết concert\n" +
                       "• Mua vé online\n" +
                       "• Quản lý vé đã mua",
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 80),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            panelContent.Controls.Add(lblTemp);
        }

        private void LoadPersonalPage()
        {
            panelContent.Controls.Clear();

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