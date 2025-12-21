using System;

namespace MusiVerse.DTO.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        // ✅ THÊM: Kiểm tra user đã mua VIP chưa
        public bool HasVIP { get; set; }
        public DateTime? VIPExpiryDate { get; set; } // Ngày hết hạn VIP
    }
}