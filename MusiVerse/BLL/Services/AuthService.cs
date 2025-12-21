using MusiVerse.DAL.Repositories; 
using MusiVerse.DTO.Models;
using System;
using System.Text.RegularExpressions;

namespace MusiVerse.BLL.Services
{
    public class AuthService
    {
        private UserRepository userRepository;

        public AuthService()
        {
            userRepository = new UserRepository();
        }

        // Đăng nhập
        public (bool success, string message, User user) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return (false, "Vui lòng nhập tên đăng nhập!", null);
            if (string.IsNullOrWhiteSpace(password)) return (false, "Vui lòng nhập mật khẩu!", null);

            try
            {
                // Bây giờ hàm Login bên UserRepository đã trả về User object nên dòng này sẽ chạy đúng
                User user = userRepository.Login(username, password);

                if (user != null)
                {
                    return (true, "Đăng nhập thành công!", user);
                }
                else
                {
                    return (false, "Tên đăng nhập hoặc mật khẩu không đúng!", null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi hệ thống: " + ex.Message, null);
            }
        }

        // Đăng ký
        public (bool success, string message) Register(string username, string password,
                                                       string confirmPassword, string email,
                                                       string fullName, string role = "User")
        {
            if (string.IsNullOrWhiteSpace(username)) return (false, "Vui lòng nhập tên đăng nhập!");
            if (username.Length < 3) return (false, "Tên đăng nhập phải có ít nhất 3 ký tự!");
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$")) return (false, "Username không chứa ký tự đặc biệt!");

            if (string.IsNullOrWhiteSpace(password)) return (false, "Vui lòng nhập mật khẩu!");
            if (password.Length < 6) return (false, "Mật khẩu phải có ít nhất 6 ký tự!");
            if (password != confirmPassword) return (false, "Mật khẩu xác nhận không khớp!");

            if (string.IsNullOrWhiteSpace(email)) return (false, "Vui lòng nhập email!");
            if (!IsValidEmail(email)) return (false, "Email không hợp lệ!");
            if (string.IsNullOrWhiteSpace(fullName)) return (false, "Vui lòng nhập họ tên!");

            try
            {
                if (userRepository.IsUsernameExists(username)) return (false, "Tên đăng nhập đã tồn tại!");
                if (userRepository.IsEmailExists(email)) return (false, "Email đã được sử dụng!");

                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    FullName = fullName,
                    Role = role
                };

                bool result = userRepository.Register(newUser);
                return result ? (true, "Đăng ký thành công!") : (false, "Đăng ký thất bại!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi hệ thống: " + ex.Message);
            }
        }

        // Đổi mật khẩu
        public (bool success, string message) ChangePassword(int userID, string oldPassword,
                                                             string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword)) return (false, "Nhập mật khẩu cũ!");
            if (string.IsNullOrWhiteSpace(newPassword)) return (false, "Nhập mật khẩu mới!");
            if (newPassword.Length < 6) return (false, "Mật khẩu mới quá ngắn!");
            if (newPassword != confirmPassword) return (false, "Xác nhận mật khẩu không khớp!");
            if (oldPassword == newPassword) return (false, "Mật khẩu mới không được trùng mật khẩu cũ!");

            try
            {
                bool result = userRepository.ChangePassword(userID, oldPassword, newPassword);
                return result ? (true, "Đổi mật khẩu thành công!") : (false, "Mật khẩu cũ không đúng!");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Helper
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }
    }
}