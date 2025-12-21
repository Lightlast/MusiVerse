using MusiVerse.DAL.Repositories;
using MusiVerse.GUI.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Auth
{
    public partial class frmUpgradeToArtist : Form
    {
        private readonly UserRepository userRepository;
        private Button selectedRoleButton;

        public frmUpgradeToArtist()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        private void frmUpgradeToArtist_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            if (!SessionManager.IsLoggedIn())
            {
                MessageBox.Show("Bạn cần đăng nhập!", "Thông báo");
                this.Close();
                return;
            }

            if (SessionManager.CurrentUser.Role != "User")
            {
                MessageBox.Show($"Bạn đã là {SessionManager.CurrentUser.Role} rồi!", "Thông báo");
                this.Close();
                return;
            }

            LoadUserInfo();
            CheckEligibility();
            SetupRoleOptions();
        }

        private void LoadUserInfo()
        {
            lblCurrentUsername.Text = $"👤 {SessionManager.CurrentUser.Username}";
            lblCurrentFullName.Text = SessionManager.CurrentUser.FullName;
            lblCurrentEmail.Text = $"📧 {SessionManager.CurrentUser.Email}";
            lblCurrentRole.Text = "Người dùng thường";
        }

        private void CheckEligibility()
        {
            int userID = SessionManager.GetCurrentUserID();
            var (eligible, reason) = userRepository.CheckUpgradeEligibility(userID);

            if (eligible)
            {
                panelEligibility.BackColor = Color.FromArgb(230, 255, 230);
                lblEligibilityIcon.Text = "✓";
                lblEligibilityIcon.ForeColor = Color.Green;
                lblEligibilityStatus.Text = "Bạn đủ điều kiện nâng cấp!";
                lblEligibilityStatus.ForeColor = Color.Green;
                btnUpgrade.Enabled = true;
            }
            else
            {
                panelEligibility.BackColor = Color.FromArgb(255, 230, 230);
                lblEligibilityIcon.Text = "✗";
                lblEligibilityIcon.ForeColor = Color.Red;
                lblEligibilityStatus.Text = reason;
                lblEligibilityStatus.ForeColor = Color.Red;
                btnUpgrade.Enabled = false;

                lblRoleOptionsTitle.Enabled = false;
                panelArtistOption.Enabled = false;
                panelIndieOption.Enabled = false;
            }
        }

        private void SetupRoleOptions()
        {
            // Setup Artist option
            panelArtistOption.Cursor = Cursors.Hand;
            panelArtistOption.Click += (s, e) => SelectRole(panelArtistOption, "Artist");

            foreach (Control ctrl in panelArtistOption.Controls)
            {
                ctrl.Click += (s, e) => SelectRole(panelArtistOption, "Artist");
            }

            // Setup IndieArtist option
            panelIndieOption.Cursor = Cursors.Hand;
            panelIndieOption.Click += (s, e) => SelectRole(panelIndieOption, "IndieArtist");

            foreach (Control ctrl in panelIndieOption.Controls)
            {
                ctrl.Click += (s, e) => SelectRole(panelIndieOption, "IndieArtist");
            }
        }

        private void SelectRole(Panel selectedPanel, string role)
        {
            // Reset tất cả panels
            panelArtistOption.BackColor = Color.White;
            panelArtistOption.BorderStyle = BorderStyle.FixedSingle;
            panelIndieOption.BackColor = Color.White;
            panelIndieOption.BorderStyle = BorderStyle.FixedSingle;

            // Highlight panel được chọn
            selectedPanel.BackColor = Color.FromArgb(230, 240, 255);
            selectedPanel.BorderStyle = BorderStyle.Fixed3D;

            // Cập nhật tag
            selectedPanel.Tag = role;

            // Hiển thị quyền lợi
            if (role == "Artist")
            {
                lblRoleDescription.Text =
                    "📌 QUYỀN LỢI NGHỆ SĨ CHÍNH THỨC:\n\n" +
                    "✓ Upload nhạc không giới hạn\n" +
                    "✓ Đăng bài viết trên Social Network\n" +
                    "✓ Tạo và bán vé Concert\n" +
                    "✓ Badge xác minh chính thức (✓)\n" +
                    "✓ Xem thống kê chi tiết\n" +
                    "✓ Nhận hoa hồng từ bán vé\n" +
                    "✓ Ưu tiên hiển thị trên trang chủ";
            }
            else
            {
                lblRoleDescription.Text =
                    "📌 QUYỀN LỢI NGHỆ SĨ ĐỘC LẬP:\n\n" +
                    "✓ Upload nhạc không giới hạn\n" +
                    "✓ Đăng bài viết trên Social Network\n" +
                    "✓ Badge nghệ sĩ indie\n" +
                    "✓ Xem thống kê cơ bản\n" +
                    "✓ Tự do sáng tác\n\n" +
                    "ℹ️ Không có quyền tạo concert";
            }
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn role chưa
            string selectedRole = null;

            if (panelArtistOption.BackColor == Color.FromArgb(230, 240, 255))
            {
                selectedRole = "Artist";
            }
            else if (panelIndieOption.BackColor == Color.FromArgb(230, 240, 255))
            {
                selectedRole = "IndieArtist";
            }

            if (selectedRole == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại nghệ sĩ!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Xác nhận
            string roleDisplay = selectedRole == "Artist" ? "Nghệ sĩ chính thức" : "Nghệ sĩ độc lập";
            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn nâng cấp lên {roleDisplay}?\n\n" +
                $"Sau khi nâng cấp, bạn sẽ có thể:\n" +
                $"• Upload và quản lý nhạc\n" +
                $"• Đăng bài trên Social Network\n" +
                (selectedRole == "Artist" ? "• Tạo và bán vé Concert\n" : "") +
                $"• Xem thống kê của mình",
                "Xác nhận nâng cấp",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                PerformUpgrade(selectedRole);
            }
        }

        private void PerformUpgrade(string newRole)
        {
            btnUpgrade.Enabled = false;
            btnUpgrade.Text = "Đang xử lý...";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                int userID = SessionManager.GetCurrentUserID();
                string bio = txtBio.Text.Trim();

                if (string.IsNullOrEmpty(bio))
                {
                    bio = $"{SessionManager.CurrentUser.FullName} - {(newRole == "Artist" ? "Nghệ sĩ" : "Nghệ sĩ độc lập")}";
                }

                // Thực hiện nâng cấp
                bool success = userRepository.UpgradeToArtist(userID, newRole, bio);

                if (success)
                {
                    // Cập nhật session
                    var updatedUser = userRepository.GetUserByID(userID);
                    SessionManager.UpdateCurrentUser(updatedUser);

                    // Hiển thị success message
                    ShowSuccessMessage(newRole);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Nâng cấp thất bại. Vui lòng thử lại sau.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnUpgrade.Enabled = true;
                btnUpgrade.Text = "XÁC NHẬN NÂNG CẤP";
                progressBar.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowSuccessMessage(string newRole)
        {
            string message = newRole == "Artist"
                ? "🎉 CHÚC MỪNG! 🎉\n\n" +
                  "Bạn đã trở thành NGHỆ SĨ CHÍNH THỨC!\n\n" +
                  "Bạn có thể:\n" +
                  "✓ Upload và quản lý nhạc của mình\n" +
                  "✓ Đăng bài viết chia sẻ với fans\n" +
                  "✓ Tạo và bán vé Concert\n" +
                  "✓ Xem thống kê chi tiết\n\n" +
                  "Hãy vào trang cá nhân và khám phá ngay!"
                : "🎉 CHÚC MỪNG! 🎉\n\n" +
                  "Bạn đã trở thành NGHỆ SĨ ĐỘC LẬP!\n\n" +
                  "Bạn có thể:\n" +
                  "✓ Upload nhạc không giới hạn\n" +
                  "✓ Đăng bài viết trên Social\n" +
                  "✓ Tự do sáng tác\n\n" +
                  "Hãy vào trang cá nhân và khám phá ngay!";

            MessageBox.Show(
                message,
                "Nâng cấp thành công!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLearnMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string info =
                "THÔNG TIN VỀ CÁC LOẠI TÀI KHOẢN:\n\n" +
                "🎤 NGHỆ SĨ CHÍNH THỨC:\n" +
                "• Dành cho nghệ sĩ chuyên nghiệp\n" +
                "• Có quyền tạo và bán vé Concert\n" +
                "• Nhận hoa hồng từ doanh thu\n" +
                "• Badge xác minh chính thức\n\n" +
                "🎸 NGHỆ SĨ ĐỘC LẬP:\n" +
                "• Dành cho nghệ sĩ tự do\n" +
                "• Upload và chia sẻ nhạc\n" +
                "• Không có quyền bán vé Concert\n" +
                "• Badge nghệ sĩ indie\n\n" +
                "ĐIỀU KIỆN NÂNG CẤP:\n" +
                "• Tài khoản tồn tại ít nhất 7 ngày\n" +
                "• Tuân thủ quy định cộng đồng";

            MessageBox.Show(info, "Thông tin chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}