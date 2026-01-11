using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class TicketRepository
    {
        // Lấy tất cả vé của một user
        public List<Ticket> GetUserTickets(int userID)
        {
            string query = @"SELECT t.TicketID, t.ConcertID, c.Name AS ConcertName, t.UserID, 
                                   t.TicketCode, t.PurchaseDate, t.Price, t.Status, 
                                   c.ConcertDate, c.Venue, t.TicketType, t.SeatClass, t.QRCodeImage
                           FROM Tickets t
                           INNER JOIN Concerts c ON t.ConcertID = c.ConcertID
                           WHERE t.UserID = @UserID AND c.ConcertDate > DATEADD(DAY, -1, GETDATE())
                           ORDER BY c.ConcertDate ASC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Ticket> tickets = new List<Ticket>();

            foreach (DataRow row in dt.Rows)
            {
                tickets.Add(MapRowToTicket(row));
            }

            return tickets;
        }

        // Lấy vé theo ID
        public Ticket GetTicketById(int ticketID)
        {
            string query = @"SELECT t.TicketID, t.ConcertID, c.Name AS ConcertName, t.UserID, 
                                   t.TicketCode, t.PurchaseDate, t.Price, t.Status, 
                                   c.ConcertDate, c.Venue, t.TicketType, t.SeatClass, t.QRCodeImage
                           FROM Tickets t
                           INNER JOIN Concerts c ON t.ConcertID = c.ConcertID
                           WHERE t.TicketID = @TicketID";

            SqlParameter[] parameters = {
                new SqlParameter("@TicketID", ticketID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return MapRowToTicket(dt.Rows[0]);
            }

            return null;
        }

        // Lấy tất cả vé còn hiệu lực của một concert
        public List<Ticket> GetConcertTickets(int concertID)
        {
            string query = @"SELECT t.TicketID, t.ConcertID, c.Name AS ConcertName, t.UserID, 
                                   t.TicketCode, t.PurchaseDate, t.Price, t.Status, 
                                   c.ConcertDate, c.Venue, t.TicketType, t.SeatClass, t.QRCodeImage
                           FROM Tickets t
                           INNER JOIN Concerts c ON t.ConcertID = c.ConcertID
                           WHERE t.ConcertID = @ConcertID
                           ORDER BY t.PurchaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", concertID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Ticket> tickets = new List<Ticket>();

            foreach (DataRow row in dt.Rows)
            {
                tickets.Add(MapRowToTicket(row));
            }

            return tickets;
        }

        // Thêm vé mới
        public int AddTicket(Ticket ticket)
        {
            string query = @"INSERT INTO Tickets (ConcertID, UserID, TicketCode, PurchaseDate, 
                                                Price, Status, TicketType, SeatClass, QRCodeImage)
                           VALUES (@ConcertID, @UserID, @TicketCode, @PurchaseDate, 
                                   @Price, @Status, @TicketType, @SeatClass, @QRCodeImage);
                           SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", ticket.ConcertID),
                new SqlParameter("@UserID", ticket.UserID),
                new SqlParameter("@TicketCode", ticket.TicketCode),
                new SqlParameter("@PurchaseDate", DateTime.Now),
                new SqlParameter("@Price", ticket.Price),
                new SqlParameter("@Status", "Active"),
                new SqlParameter("@TicketType", ticket.TicketType),
                new SqlParameter("@SeatClass", ticket.SeatClass ?? (object)DBNull.Value),
                new SqlParameter("@QRCodeImage", ticket.QRCodeImage ?? (object)DBNull.Value)
            };

            var result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // Cập nhật trạng thái vé
        public bool UpdateTicketStatus(int ticketID, string status)
        {
            string query = "UPDATE Tickets SET Status = @Status WHERE TicketID = @TicketID";

            SqlParameter[] parameters = {
                new SqlParameter("@TicketID", ticketID),
                new SqlParameter("@Status", status)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Kiểm tra vé đã tồn tại chưa (theo mã vé)
        public bool TicketCodeExists(string ticketCode)
        {
            string query = "SELECT COUNT(*) FROM Tickets WHERE TicketCode = @TicketCode";

            SqlParameter[] parameters = {
                new SqlParameter("@TicketCode", ticketCode)
            };

            var result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        // Lấy số vé đã bán của một concert
        public int GetSoldTicketsCount(int concertID)
        {
            string query = "SELECT COUNT(*) FROM Tickets WHERE ConcertID = @ConcertID AND Status = 'Active'";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", concertID)
            };

            var result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // Helper method
        private Ticket MapRowToTicket(DataRow row)
        {
            return new Ticket
            {
                TicketID = Convert.ToInt32(row["TicketID"]),
                ConcertID = Convert.ToInt32(row["ConcertID"]),
                ConcertName = row["ConcertName"].ToString(),
                UserID = Convert.ToInt32(row["UserID"]),
                TicketCode = row["TicketCode"].ToString(),
                PurchaseDate = Convert.ToDateTime(row["PurchaseDate"]),
                Price = Convert.ToDecimal(row["Price"]),
                Status = row["Status"].ToString(),
                ConcertDate = Convert.ToDateTime(row["ConcertDate"]),
                Venue = row["Venue"].ToString(),
                TicketType = Convert.ToInt32(row["TicketType"]),
                SeatClass = row["SeatClass"] != DBNull.Value ? row["SeatClass"].ToString() : "",
                QRCodeImage = row["QRCodeImage"] != DBNull.Value ? row["QRCodeImage"].ToString() : ""
            };
        }
    }
}
