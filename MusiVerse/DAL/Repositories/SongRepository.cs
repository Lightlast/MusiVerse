using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MusiVerse.DAL;

namespace MusiVerse.DAL.Repositories
{
    public class SongRepository
    {
        // Lấy tất cả bài hát
        public List<Song> GetAllSongs(int? currentUserID = null)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive,
                                   CASE WHEN ls.LikedSongID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           LEFT JOIN LikedSongs ls ON s.SongID = ls.SongID AND ls.UserID = @CurrentUserID
                           WHERE s.IsActive = 1
                           ORDER BY s.ReleaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@CurrentUserID", currentUserID ?? (object)DBNull.Value)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        // Lấy bài hát theo nghệ sĩ
        public List<Song> GetSongsByArtist(int artistID, int? currentUserID = null)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive,
                                   CASE WHEN ls.LikedSongID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           LEFT JOIN LikedSongs ls ON s.SongID = ls.SongID AND ls.UserID = @CurrentUserID
                           WHERE s.ArtistID = @ArtistID AND s.IsActive = 1
                           ORDER BY s.ReleaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@ArtistID", artistID),
                new SqlParameter("@CurrentUserID", currentUserID ?? (object)DBNull.Value)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        // Tìm kiếm bài hát
        public List<Song> SearchSongs(string keyword, int? currentUserID = null)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive,
                                   CASE WHEN ls.LikedSongID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           LEFT JOIN LikedSongs ls ON s.SongID = ls.SongID AND ls.UserID = @CurrentUserID
                           WHERE (s.Title LIKE @Keyword OR u.FullName LIKE @Keyword OR s.Genre LIKE @Keyword)
                                 AND s.IsActive = 1
                           ORDER BY s.PlayCount DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", "%" + keyword + "%"),
                new SqlParameter("@CurrentUserID", currentUserID ?? (object)DBNull.Value)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        // Thêm bài hát mới
        public bool AddSong(Song song)
        {
            string query = @"INSERT INTO Songs (Title, ArtistID, Duration, FilePath, CoverImage, Genre) 
                           VALUES (@Title, @ArtistID, @Duration, @FilePath, @CoverImage, @Genre)";

            SqlParameter[] parameters = {
                new SqlParameter("@Title", song.Title),
                new SqlParameter("@ArtistID", song.ArtistID),
                new SqlParameter("@Duration", song.Duration),
                new SqlParameter("@FilePath", song.FilePath),
                new SqlParameter("@CoverImage", song.CoverImage ?? (object)DBNull.Value),
                new SqlParameter("@Genre", song.Genre ?? (object)DBNull.Value)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Cập nhật bài hát
        public bool UpdateSong(Song song)
        {
            string query = @"UPDATE Songs 
                           SET Title = @Title, 
                               Duration = @Duration, 
                               CoverImage = @CoverImage, 
                               Genre = @Genre 
                           WHERE SongID = @SongID";

            SqlParameter[] parameters = {
                new SqlParameter("@SongID", song.SongID),
                new SqlParameter("@Title", song.Title),
                new SqlParameter("@Duration", song.Duration),
                new SqlParameter("@CoverImage", song.CoverImage ?? (object)DBNull.Value),
                new SqlParameter("@Genre", song.Genre ?? (object)DBNull.Value)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Xóa bài hát (soft delete)
        public bool DeleteSong(int songID)
        {
            string query = "UPDATE Songs SET IsActive = 0 WHERE SongID = @SongID";

            SqlParameter[] parameters = {
                new SqlParameter("@SongID", songID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Like bài hát
        public bool LikeSong(int userID, int songID)
        {
            string query = @"IF NOT EXISTS (SELECT 1 FROM LikedSongs WHERE UserID = @UserID AND SongID = @SongID)
                           BEGIN
                               INSERT INTO LikedSongs (UserID, SongID) VALUES (@UserID, @SongID)
                           END";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@SongID", songID)
            };

            try
            {
                DatabaseConnection.ExecuteNonQuery(query, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Unlike bài hát
        public bool UnlikeSong(int userID, int songID)
        {
            string query = "DELETE FROM LikedSongs WHERE UserID = @UserID AND SongID = @SongID";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@SongID", songID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Lấy danh sách bài hát đã like
        public List<Song> GetLikedSongs(int userID)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive, 1 AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           INNER JOIN LikedSongs ls ON s.SongID = ls.SongID
                           WHERE ls.UserID = @UserID AND s.IsActive = 1
                           ORDER BY ls.LikedDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        // Tăng lượt nghe
        public bool IncrementPlayCount(int songID)
        {
            string query = "UPDATE Songs SET PlayCount = PlayCount + 1 WHERE SongID = @SongID";

            SqlParameter[] parameters = {
                new SqlParameter("@SongID", songID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Lấy bài hát được nghe gần đây (Top 20 bài hát được phát nhiều nhất trong 30 ngày gần đây)
        public List<Song> GetRecentPlayedSongs(int userID)
        {
            string query = @"SELECT TOP 20 s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive,
                                   CASE WHEN ls.LikedSongID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           LEFT JOIN LikedSongs ls ON s.SongID = ls.SongID AND ls.UserID = @UserID
                           WHERE s.IsActive = 1
                           ORDER BY s.PlayCount DESC, s.ReleaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        // Helper method
        private Song MapRowToSong(DataRow row)
        {
            return new Song
            {
                SongID = Convert.ToInt32(row["SongID"]),
                Title = row["Title"].ToString(),
                ArtistID = Convert.ToInt32(row["ArtistID"]),
                ArtistName = row["ArtistName"].ToString(),
                Duration = Convert.ToInt32(row["Duration"]),
                FilePath = row["FilePath"].ToString(),
                CoverImage = row["CoverImage"] != DBNull.Value ? row["CoverImage"].ToString() : "",
                Genre = row["Genre"] != DBNull.Value ? row["Genre"].ToString() : "",
                ReleaseDate = Convert.ToDateTime(row["ReleaseDate"]),
                PlayCount = Convert.ToInt32(row["PlayCount"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                IsLiked = row["IsLiked"] != DBNull.Value && Convert.ToBoolean(row["IsLiked"])
            };
        }
    }
}