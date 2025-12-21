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
        // Current selected menu button
        private System.Windows.Forms.Button currentSelectedButton;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập
            if (!SessionManager.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Thiết lập giao diện
            SetupUI();

            // Load trang Home mặc định
            LoadHomePage();
        }

        private void SetupUI()
        {
            // Hiển thị thông tin user
            lblAccountInfo.Text = SessionManager.GetCurrentUsername();

            // Phân quyền hiển thị menu
            SetupMenuByRole();

            // Tô màu nút Home mặc định
            SelectMenuButton(btnHome);
        }

        private void SetupMenuByRole()
        {
            string role = SessionManager.CurrentUser?.Role ?? "User";

            // Tất cả user đều thấy
            btnHome.Visible = true;
            btnMusic.Visible = true;
            btnSocialNetwork.Visible = true;
            btnShopping.Visible = true;
            btnPersonalPage.Visible = true;

            // ✅ TẤT CẢ USER ĐỀU THẤY NÚT VIP (Mua gói không quảng cáo)
            btnVIP.Visible = true;
            btnVIP.Text = "🎵 VIP - Không quảng cáo";
            btnVIP.BackColor = Color.FromArgb(255, 140, 0); // Orange
            // TODO: Kiểm tra nếu user đã mua VIP thì đổi màu/text
            if (SessionManager.CurrentUser.HasVIP)
            {
                btnVIP.Text = "⭐ VIP Active";
                btnVIP.BackColor = Color.FromArgb(218, 165, 32); // Gold
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
            // Hiển thị form mua gói VIP (không quảng cáo)
            ShowVIPPackageForm();
        }

        private void ShowVIPPackageForm()
        {
            // Form mua gói VIP - Không quảng cáo khi nghe nhạc
            // TODO: Tạo frmVIPPackage.cs

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
                // TODO: Mở form thanh toán
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
            // Form nâng cấp lên Artist (MIỄN PHÍ)
            // Chỉ dùng cho User thường muốn trở thành Artist
            frmUpgradeToArtist upgradeForm = new frmUpgradeToArtist();

            if (upgradeForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh UI sau khi nâng cấp thành công
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
            // Reset màu nút cũ
            if (currentSelectedButton != null)
            {
                currentSelectedButton.BackColor = Color.FromArgb(40, 40, 60);
            }

            // Tô màu nút mới
            button.BackColor = Color.FromArgb(255, 140, 0); // Orange
            currentSelectedButton = button;
        }

        #endregion

        #region Load Pages

        private void LoadHomePage()
        {
            // Xóa nội dung cũ
            panelContent.Controls.Clear();

            // Tạo welcome screen
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

            // Logo/Image placeholder
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

            // Quick info
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

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
            {
                Text = "🎵 THƯ VIỆN NHẠC",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 144, 255),
                Location = new Point(20, 20),
                AutoSize = true
            };
            panelContent.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblTemp = new System.Windows.Forms.Label
            {
                Text = "Tính năng Music đang được phát triển...\n\n" +
                       "Sẽ có:\n" +
                       "• Danh sách bài hát\n" +
                       "• Tìm kiếm & lọc\n" +
                       "• Quản lý playlist\n" +
                       "• Upload nhạc (Artist)",
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 80),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            panelContent.Controls.Add(lblTemp);
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

            // Load UserControl Personal Page
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
                // Nếu UserControl chưa tạo, hiển thị placeholder
                System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label
                {
                    Text = "👤 TRANG CÁ NHÂN",
                    Font = new Font("Segoe UI", 18, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 144, 255),
                    Location = new Point(20, 20),
                    AutoSize = true
                };
                panelContent.Controls.Add(lblTitle);

                System.Windows.Forms.Label lblUserInfo = new System.Windows.Forms.Label
                {
                    Text = $"Xin chào, {SessionManager.CurrentUser.FullName}!\n\n" +
                           $"Username: {SessionManager.CurrentUser.Username}\n" +
                           $"Email: {SessionManager.CurrentUser.Email}\n" +
                           $"Role: {SessionManager.CurrentUser.Role}\n\n" +
                           "UserControl ucPersonalPage đang được phát triển...",
                    Font = new Font("Segoe UI", 12),
                    Location = new Point(20, 80),
                    AutoSize = true
                };
                panelContent.Controls.Add(lblUserInfo);
            }
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
            // Hiển thị context menu
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
            // Confirm trước khi thoát
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
            }
        }

        // Public method để access music player (nếu có)
        public ucMusicPlayer GetMusicPlayer()
        {
            // TODO: Return music player khi đã tạo
            return null;
        }

        private void btnUpRole_Click(object sender, EventArgs e)
        {
            // Mở form nâng cấp
            frmUpgradeToArtist upgradeForm = new frmUpgradeToArtist();

            if (upgradeForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh UI sau khi nâng cấp thành công
                SetupUI();
                MessageBox.Show(
                    "Bạn đã trở thành nghệ sĩ! Khám phá các tính năng mới ngay!",
                    "Chào mừng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}