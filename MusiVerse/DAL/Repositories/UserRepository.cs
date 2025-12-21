using MusiVerse.DTO.Models; // Đảm bảo namespace đúng
using System;
using System.Data;
using System.Data.SqlClient;
using MusiVerse.DAL;

namespace MusiVerse.DAL.Repositories
{
    public class UserRepository
    {
        // 1. Hàm Login (Nâng cấp trả về User object thay vì bool)
        public User Login(string username, string password)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Username = @user AND Password = @pass";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Role = reader["Role"].ToString(),
                            Avatar = reader["Avatar"] != DBNull.Value ? reader["Avatar"].ToString() : null
                        };
                    }
                }
                return null; // Không tìm thấy user
            }
        }

        // 2. Hàm Register
        public bool Register(User user)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password, FullName, Email, Role, CreatedDate) VALUES (@u, @p, @fn, @e, @r, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@fn", user.FullName);
                cmd.Parameters.AddWithValue("@e", user.Email);
                cmd.Parameters.AddWithValue("@r", user.Role);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Các hàm kiểm tra trùng lặp
        public bool IsUsernameExists(string username)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @u", conn);
                cmd.Parameters.AddWithValue("@u", username);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public bool IsEmailExists(string email)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @e", conn);
                cmd.Parameters.AddWithValue("@e", email);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // 4. Hàm đổi mật khẩu
        public bool ChangePassword(int userId, string oldPass, string newPass)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Kiểm tra mật khẩu cũ có đúng không trước
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserID = @id AND Password = @old", conn);
                checkCmd.Parameters.AddWithValue("@id", userId);
                checkCmd.Parameters.AddWithValue("@old", oldPass);

                if ((int)checkCmd.ExecuteScalar() == 0) return false;

                // Cập nhật mật khẩu mới
                SqlCommand updateCmd = new SqlCommand("UPDATE Users SET Password = @new WHERE UserID = @id", conn);
                updateCmd.Parameters.AddWithValue("@new", newPass);
                updateCmd.Parameters.AddWithValue("@id", userId);

                return updateCmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Hàm kiểm tra đủ điều kiện nâng cấp
        public (bool, string) CheckUpgradeEligibility(int userId)
        {
            // Logic đơn giản: yêu cầu tài khoản ít nhất 5 bài hát (chưa triển khai) hoặc tuổi tài khoản trên 30 ngày
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CreatedDate FROM Users WHERE UserID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    object result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value) return (false, "Không tìm thấy tài khoản.");

                    DateTime created = Convert.ToDateTime(result);
                    if ((DateTime.Now - created).TotalDays < 1)
                        return (false, "Tài khoản chưa đủ 30 ngày để nâng cấp."); 

                    return (true, "Đủ điều kiện");
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi hệ thống: " + ex.Message);
            }
        }

        // 6. Hàm nâng cấp tài khoản
        public bool UpgradeToArtist(int userId, string newRole, string bio)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Role = @r, Bio = @b WHERE UserID = @id", conn);
                    cmd.Parameters.AddWithValue("@r", newRole);
                    cmd.Parameters.AddWithValue("@b", bio);
                    cmd.Parameters.AddWithValue("@id", userId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // 7. Lấy thông tin người dùng theo ID
        public User GetUserByID(int userId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE UserID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Role = reader["Role"].ToString(),
                            Avatar = reader["Avatar"] != DBNull.Value ? reader["Avatar"].ToString() : null,
                            Bio = reader["Bio"] != DBNull.Value ? reader["Bio"].ToString() : null
                        };
                    }
                }
                return null;
            }
        }
    }
}