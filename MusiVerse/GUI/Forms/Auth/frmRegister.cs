using System;
using System.Windows.Forms;
using MusiVerse.BLL.Services;

namespace MusiVerse.GUI.Forms.Auth
{
    public partial class frmRegister : Form
    {
        private AuthService authService;

        public frmRegister()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            txtPassword.PasswordChar = '●';
            txtConfirmPassword.PasswordChar = '●';

            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            // Hiển thị loading
            btnRegister.Enabled = false;
            btnRegister.Text = "Đang đăng ký...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Gọi service đăng ký (mặc định role = "User")
                var (success, message) = authService.Register(
                    username,
                    password,
                    confirmPassword,
                    email,
                    fullName,
                    "User" // ← Mặc định là User thường
                );

                if (success)
                {
                    MessageBox.Show(
                        message + "\nBạn có thể đăng nhập ngay bây giờ!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Quay về form login
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi đăng ký",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "ĐĂNG KÝ";
                this.Cursor = Cursors.Default;
            }
        }

        private void lblBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
            txtConfirmPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnRegister_Click(sender, e);
            }
        }

        // Real-time validation
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtUsername.Text.Length < 3)
            {
                lblUsernameError.Text = "Tên đăng nhập phải có ít nhất 3 ký tự";
                lblUsernameError.Visible = true;
            }
            else
            {
                lblUsernameError.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0 && txtPassword.Text.Length < 6)
            {
                lblPasswordError.Text = "Mật khẩu phải có ít nhất 6 ký tự";
                lblPasswordError.Visible = true;
            }
            else
            {
                lblPasswordError.Visible = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Length > 0 &&
                txtPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmPasswordError.Text = "Mật khẩu không khớp";
                lblConfirmPasswordError.Visible = true;
            }
            else
            {
                lblConfirmPasswordError.Visible = false;
            }
        }
    }
}