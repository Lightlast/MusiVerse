using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MusiVerse.BLL.Services
{
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly ConcertRepository _concertRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
            _concertRepository = new ConcertRepository();
        }

        // Lấy tất cả vé của một user
        public List<Ticket> GetUserTickets(int userID)
        {
            try
            {
                return _ticketRepository.GetUserTickets(userID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting user tickets: " + ex.Message);
            }
        }

        // Lấy vé theo ID
        public Ticket GetTicketById(int ticketID)
        {
            try
            {
                var ticket = _ticketRepository.GetTicketById(ticketID);
                if (ticket == null)
                    throw new Exception("Ticket not found");
                return ticket;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting ticket: " + ex.Message);
            }
        }

        // Lấy tất cả vé của một concert
        public List<Ticket> GetConcertTickets(int concertID)
        {
            try
            {
                return _ticketRepository.GetConcertTickets(concertID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting concert tickets: " + ex.Message);
            }
        }

        // Mua vé
        public int BuyTicket(int concertID, int userID, string seatClass = "")
        {
            try
            {
                // Lấy thông tin concert
                var concert = _concertRepository.GetConcertById(concertID);
                if (concert == null)
                    throw new Exception("Concert not found");

                if (concert.AvailableTickets <= 0)
                    throw new Exception("No tickets available");

                // Tạo mã vé duy nhất (5 chữ số)
                string ticketCode = GenerateTicketCode();
                while (_ticketRepository.TicketCodeExists(ticketCode))
                {
                    ticketCode = GenerateTicketCode();
                }

                // Tạo QR code
                string qrCodePath = GenerateQRCode(ticketCode);

                // Tạo vé mới
                var ticket = new Ticket
                {
                    ConcertID = concertID,
                    UserID = userID,
                    TicketCode = ticketCode,
                    PurchaseDate = DateTime.Now,
                    Price = concert.Price,
                    Status = "Active",
                    ConcertDate = concert.ConcertDate,
                    ConcertName = concert.Name,
                    Venue = concert.Venue,
                    TicketType = concert.TicketType,
                    SeatClass = concert.TicketType == 1 ? seatClass : "", // Chỉ lưu seat class nếu có sấp chỗ
                    QRCodeImage = qrCodePath
                };

                int ticketID = _ticketRepository.AddTicket(ticket);

                // Cập nhật số vé còn lại của concert
                concert.AvailableTickets--;
                _concertRepository.UpdateConcert(concert);

                return ticketID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error buying ticket: " + ex.Message);
            }
        }

        // Tạo mã vé ngẫu nhiên (5 chữ số)
        private string GenerateTicketCode()
        {
            Random random = new Random();
            return random.Next(10000, 99999).ToString();
        }

        // Tạo QR code cho vé
        private string GenerateQRCode(string ticketCode)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                string qrCodeDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QRCodes");
                if (!Directory.Exists(qrCodeDir))
                {
                    Directory.CreateDirectory(qrCodeDir);
                }

                // Tạo tên file
                string qrCodePath = Path.Combine(qrCodeDir, $"QR_{ticketCode}.png");

                // Tạo QR code bằng cách vẽ
                using (Bitmap qrBitmap = new Bitmap(200, 200))
                {
                    using (Graphics g = Graphics.FromImage(qrBitmap))
                    {
                        g.Clear(Color.White);
                        
                        // Vẽ nền
                        Pen pen = new Pen(Color.Black, 2);
                        g.DrawRectangle(pen, 5, 5, 190, 190);

                        // Vẽ mã vé ở giữa
                        Font font = new Font("Arial", 24, FontStyle.Bold);
                        SizeF textSize = g.MeasureString(ticketCode, font);
                        float x = (200 - textSize.Width) / 2;
                        float y = (200 - textSize.Height) / 2;
                        g.DrawString(ticketCode, font, Brushes.Black, x, y);
                    }

                    qrBitmap.Save(qrCodePath);
                }

                return qrCodePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating QR code: " + ex.Message);
            }
        }

        // Cập nhật trạng thái vé
        public bool UpdateTicketStatus(int ticketID, string status)
        {
            try
            {
                return _ticketRepository.UpdateTicketStatus(ticketID, status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ticket status: " + ex.Message);
            }
        }

        // Kiểm tra vé hết hạn
        public bool IsTicketExpired(Ticket ticket)
        {
            return DateTime.Now > ticket.ConcertDate;
        }

        // Lấy số vé đã bán của một concert
        public int GetSoldTicketsCount(int concertID)
        {
            try
            {
                return _ticketRepository.GetSoldTicketsCount(concertID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting sold tickets count: " + ex.Message);
            }
        }
    }
}
