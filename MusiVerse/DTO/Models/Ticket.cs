using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int ConcertID { get; set; }
        public string ConcertName { get; set; } // For display
        public int UserID { get; set; }
        public string TicketCode { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } // Active, Expired, Used
        public DateTime ConcertDate { get; set; } // For display
        public string Venue { get; set; } // For display
        
        // Thêm các trường mới
        public int TicketType { get; set; } // 0 = Không sấp chỗ, 1 = Có sấp chỗ
        public string SeatClass { get; set; } // "VIP", "Standard", "Economy" (nếu TicketType = 1)
        public string QRCodeImage { get; set; } // Đường dẫn file QR code
    }
}
