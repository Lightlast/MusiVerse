using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class ConcertRepository
    {
        // Lấy tất cả concert còn hiệu lực
        public List<Concert> GetAllActiveConcerts()
        {
            string query = @"SELECT c.ConcertID, c.ArtistID, u.FullName AS ArtistName, c.Name, 
                                   c.Description, c.Venue, c.ConcertDate, c.PosterImage, 
                                   c.TotalTickets, c.AvailableTickets, c.Price, c.CreatedDate, 
                                   c.IsActive, c.TicketType
                           FROM Concerts c
                           INNER JOIN Users u ON c.ArtistID = u.UserID
                           WHERE c.IsActive = 1 AND c.ConcertDate > GETDATE()
                           ORDER BY c.ConcertDate ASC";

            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            List<Concert> concerts = new List<Concert>();

            foreach (DataRow row in dt.Rows)
            {
                concerts.Add(MapRowToConcert(row));
            }

            return concerts;
        }

        // Lấy concert theo ID
        public Concert GetConcertById(int concertID)
        {
            string query = @"SELECT c.ConcertID, c.ArtistID, u.FullName AS ArtistName, c.Name, 
                                   c.Description, c.Venue, c.ConcertDate, c.PosterImage, 
                                   c.TotalTickets, c.AvailableTickets, c.Price, c.CreatedDate, 
                                   c.IsActive, c.TicketType
                           FROM Concerts c
                           INNER JOIN Users u ON c.ArtistID = u.UserID
                           WHERE c.ConcertID = @ConcertID";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", concertID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return MapRowToConcert(dt.Rows[0]);
            }

            return null;
        }

        // Lấy concert của một nghệ sĩ
        public List<Concert> GetConcertsByArtist(int artistID)
        {
            string query = @"SELECT c.ConcertID, c.ArtistID, u.FullName AS ArtistName, c.Name, 
                                   c.Description, c.Venue, c.ConcertDate, c.PosterImage, 
                                   c.TotalTickets, c.AvailableTickets, c.Price, c.CreatedDate, 
                                   c.IsActive, c.TicketType
                           FROM Concerts c
                           INNER JOIN Users u ON c.ArtistID = u.UserID
                           WHERE c.ArtistID = @ArtistID AND c.IsActive = 1
                           ORDER BY c.ConcertDate ASC";

            SqlParameter[] parameters = {
                new SqlParameter("@ArtistID", artistID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Concert> concerts = new List<Concert>();

            foreach (DataRow row in dt.Rows)
            {
                concerts.Add(MapRowToConcert(row));
            }

            return concerts;
        }

        // Thêm concert mới
        public int AddConcert(Concert concert)
        {
            string query = @"INSERT INTO Concerts (ArtistID, Name, Description, Venue, ConcertDate, 
                                                  PosterImage, TotalTickets, AvailableTickets, 
                                                  Price, IsActive, TicketType, CreatedDate)
                           VALUES (@ArtistID, @Name, @Description, @Venue, @ConcertDate, 
                                   @PosterImage, @TotalTickets, @AvailableTickets, 
                                   @Price, @IsActive, @TicketType, @CreatedDate);
                           SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@ArtistID", concert.ArtistID),
                new SqlParameter("@Name", concert.Name),
                new SqlParameter("@Description", concert.Description ?? (object)DBNull.Value),
                new SqlParameter("@Venue", concert.Venue),
                new SqlParameter("@ConcertDate", concert.ConcertDate),
                new SqlParameter("@PosterImage", concert.PosterImage ?? (object)DBNull.Value),
                new SqlParameter("@TotalTickets", concert.TotalTickets),
                new SqlParameter("@AvailableTickets", concert.AvailableTickets),
                new SqlParameter("@Price", concert.Price),
                new SqlParameter("@IsActive", concert.IsActive),
                new SqlParameter("@TicketType", concert.TicketType),
                new SqlParameter("@CreatedDate", DateTime.Now)
            };

            var result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // Cập nhật concert
        public bool UpdateConcert(Concert concert)
        {
            string query = @"UPDATE Concerts 
                           SET Name = @Name, Description = @Description, Venue = @Venue,
                               ConcertDate = @ConcertDate, PosterImage = @PosterImage,
                               TotalTickets = @TotalTickets, AvailableTickets = @AvailableTickets,
                               Price = @Price, TicketType = @TicketType
                           WHERE ConcertID = @ConcertID";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", concert.ConcertID),
                new SqlParameter("@Name", concert.Name),
                new SqlParameter("@Description", concert.Description ?? (object)DBNull.Value),
                new SqlParameter("@Venue", concert.Venue),
                new SqlParameter("@ConcertDate", concert.ConcertDate),
                new SqlParameter("@PosterImage", concert.PosterImage ?? (object)DBNull.Value),
                new SqlParameter("@TotalTickets", concert.TotalTickets),
                new SqlParameter("@AvailableTickets", concert.AvailableTickets),
                new SqlParameter("@Price", concert.Price),
                new SqlParameter("@TicketType", concert.TicketType)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa concert (soft delete)
        public bool DeleteConcert(int concertID)
        {
            string query = "UPDATE Concerts SET IsActive = 0 WHERE ConcertID = @ConcertID";

            SqlParameter[] parameters = {
                new SqlParameter("@ConcertID", concertID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Helper method
        private Concert MapRowToConcert(DataRow row)
        {
            return new Concert
            {
                ConcertID = Convert.ToInt32(row["ConcertID"]),
                ArtistID = Convert.ToInt32(row["ArtistID"]),
                ArtistName = row["ArtistName"].ToString(),
                Name = row["Name"].ToString(),
                Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                Venue = row["Venue"].ToString(),
                ConcertDate = Convert.ToDateTime(row["ConcertDate"]),
                PosterImage = row["PosterImage"] != DBNull.Value ? row["PosterImage"].ToString() : "",
                TotalTickets = Convert.ToInt32(row["TotalTickets"]),
                AvailableTickets = Convert.ToInt32(row["AvailableTickets"]),
                Price = Convert.ToDecimal(row["Price"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                TicketType = Convert.ToInt32(row["TicketType"])
            };
        }
    }
}
