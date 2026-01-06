using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class PlaylistRepository
    {
        public List<Playlist> GetUserPlaylists(int userID)
        {
            string query = @"SELECT PlaylistID, UserID, Name, Description, CoverImage, 
                                   IsPublic, CreatedDate,
                                   (SELECT COUNT(*) FROM PlaylistSongs WHERE PlaylistID = p.PlaylistID) AS SongCount
                           FROM Playlists p
                           WHERE UserID = @UserID
                           ORDER BY CreatedDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Playlist> playlists = new List<Playlist>();

            foreach (DataRow row in dt.Rows)
            {
                playlists.Add(MapRowToPlaylist(row));
            }

            return playlists;
        }

        public Playlist GetPlaylistById(int playlistID)
        {
            string query = @"SELECT PlaylistID, UserID, Name, Description, CoverImage, 
                                   IsPublic, CreatedDate,
                                   (SELECT COUNT(*) FROM PlaylistSongs WHERE PlaylistID = p.PlaylistID) AS SongCount
                           FROM Playlists p
                           WHERE PlaylistID = @PlaylistID";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlistID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapRowToPlaylist(dt.Rows[0]);
            }

            return null;
        }

        public List<Song> GetPlaylistSongs(int playlistID)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive, 0 AS IsLiked,
                                   ps.OrderIndex
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           INNER JOIN PlaylistSongs ps ON s.SongID = ps.SongID
                           WHERE ps.PlaylistID = @PlaylistID AND s.IsActive = 1
                           ORDER BY ps.OrderIndex ASC";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlistID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        public bool CreatePlaylist(Playlist playlist)
        {
            string query = @"INSERT INTO Playlists (UserID, Name, Description, CoverImage, IsPublic) 
                           VALUES (@UserID, @Name, @Description, @CoverImage, @IsPublic)";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", playlist.UserID),
                new SqlParameter("@Name", playlist.Name),
                new SqlParameter("@Description", playlist.Description ?? (object)DBNull.Value),
                new SqlParameter("@CoverImage", playlist.CoverImage ?? (object)DBNull.Value),
                new SqlParameter("@IsPublic", playlist.IsPublic)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            string query = @"UPDATE Playlists 
                           SET Name = @Name, 
                               Description = @Description, 
                               CoverImage = @CoverImage,
                               IsPublic = @IsPublic
                           WHERE PlaylistID = @PlaylistID";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlist.PlaylistID),
                new SqlParameter("@Name", playlist.Name),
                new SqlParameter("@Description", playlist.Description ?? (object)DBNull.Value),
                new SqlParameter("@CoverImage", playlist.CoverImage ?? (object)DBNull.Value),
                new SqlParameter("@IsPublic", playlist.IsPublic)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeletePlaylist(int playlistID)
        {
            string query = @"DELETE FROM PlaylistSongs WHERE PlaylistID = @PlaylistID;
                           DELETE FROM Playlists WHERE PlaylistID = @PlaylistID";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlistID)
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

        public bool AddSongToPlaylist(int playlistID, int songID)
        {
            string query = @"IF NOT EXISTS (SELECT 1 FROM PlaylistSongs WHERE PlaylistID = @PlaylistID AND SongID = @SongID)
                           BEGIN
                               DECLARE @NextOrder INT = (SELECT ISNULL(MAX(OrderIndex), 0) + 1 FROM PlaylistSongs WHERE PlaylistID = @PlaylistID)
                               INSERT INTO PlaylistSongs (PlaylistID, SongID, OrderIndex) 
                               VALUES (@PlaylistID, @SongID, @NextOrder)
                           END";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlistID),
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

        public bool RemoveSongFromPlaylist(int playlistID, int songID)
        {
            string query = "DELETE FROM PlaylistSongs WHERE PlaylistID = @PlaylistID AND SongID = @SongID";

            SqlParameter[] parameters = {
                new SqlParameter("@PlaylistID", playlistID),
                new SqlParameter("@SongID", songID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool ReorderSongs(int playlistID, List<int> songIDs)
        {
            try
            {
                string query = "DELETE FROM PlaylistSongs WHERE PlaylistID = @PlaylistID";
                SqlParameter[] parameters = { new SqlParameter("@PlaylistID", playlistID) };
                DatabaseConnection.ExecuteNonQuery(query, parameters);

                for (int i = 0; i < songIDs.Count; i++)
                {
                    query = @"INSERT INTO PlaylistSongs (PlaylistID, SongID, OrderIndex) 
                             VALUES (@PlaylistID, @SongID, @OrderIndex)";
                    parameters = new SqlParameter[] {
                        new SqlParameter("@PlaylistID", playlistID),
                        new SqlParameter("@SongID", songIDs[i]),
                        new SqlParameter("@OrderIndex", i)
                    };
                    DatabaseConnection.ExecuteNonQuery(query, parameters);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private Playlist MapRowToPlaylist(DataRow row)
        {
            return new Playlist
            {
                PlaylistID = Convert.ToInt32(row["PlaylistID"]),
                UserID = Convert.ToInt32(row["UserID"]),
                Name = row["Name"].ToString(),
                Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                CoverImage = row["CoverImage"] != DBNull.Value ? row["CoverImage"].ToString() : "",
                IsPublic = Convert.ToBoolean(row["IsPublic"]),
                CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                SongCount = Convert.ToInt32(row["SongCount"])
            };
        }

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
                IsLiked = false
            };
        }
    }
}
