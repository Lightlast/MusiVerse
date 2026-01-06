using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using MusiVerse.GUI.Forms.Main;
using MusiVerse.GUI.Utils;
using System;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Auth
{
    public partial class frmLogin : Form
    {
        private AuthService authService;

        public frmLogin()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Cấu hình form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Cấu hình TextBox password
            txtPassword.PasswordChar = '●';

            // Set focus vào username
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Hiển thị loading
            btnLogin.Enabled = false;
            btnLogin.Text = "Đang đăng nhập...";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var (success, message, user) = authService.Login(username, password);

                if (success)
                {
                    // Lưu session
                    SessionManager.CurrentUser = user;

                    MessageBox.Show(message, "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form chính - sử dụng BeginInvoke để defer transition
                    this.BeginInvoke(new Action(() =>
                    {
                        frmMain mainForm = new frmMain();
                        mainForm.FormClosed += (s, args) => this.Close();
                        this.Hide();
                        mainForm.Show();
                    }));
                }
                else
                {
                    MessageBox.Show(message, "Lỗi đăng nhập",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();

                    // Reset button immediately on error
                    btnLogin.Enabled = true;
                    btnLogin.Text = "Đăng nhập";
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
                this.Cursor = Cursors.Default;
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            // Defer the form navigation to avoid disposal race condition
            this.BeginInvoke(new Action(() =>
            {
                frmRegister registerForm = new frmRegister();
                this.Hide();
                DialogResult result = registerForm.ShowDialog(this);
                if (result != DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Show();
                }
            }));
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle hiển thị password
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter để đăng nhập
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng quên mật khẩu đang được phát triển!",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}