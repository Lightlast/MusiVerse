using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class AlbumRepository
    {
        public Album GetAlbumById(int albumID)
        {
            string query = @"SELECT a.AlbumID, a.Title, a.ArtistID, u.FullName AS ArtistName, 
                                   a.CoverImage, a.ReleaseDate, a.IsActive,
                                   (SELECT COUNT(*) FROM Songs WHERE AlbumID = a.AlbumID) AS SongCount
                           FROM Albums a
                           INNER JOIN Users u ON a.ArtistID = u.UserID
                           WHERE a.AlbumID = @AlbumID";

            SqlParameter[] parameters = {
                new SqlParameter("@AlbumID", albumID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return MapRowToAlbum(dt.Rows[0]);
            }

            return null;
        }

        public List<Album> GetAlbumsByArtist(int artistID)
        {
            string query = @"SELECT a.AlbumID, a.Title, a.ArtistID, u.FullName AS ArtistName, 
                                   a.CoverImage, a.ReleaseDate, a.IsActive,
                                   (SELECT COUNT(*) FROM Songs WHERE AlbumID = a.AlbumID) AS SongCount
                           FROM Albums a
                           INNER JOIN Users u ON a.ArtistID = u.UserID
                           WHERE a.ArtistID = @ArtistID AND a.IsActive = 1
                           ORDER BY a.ReleaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@ArtistID", artistID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Album> albums = new List<Album>();

            foreach (DataRow row in dt.Rows)
            {
                albums.Add(MapRowToAlbum(row));
            }

            return albums;
        }

        public List<Song> GetAlbumSongs(int albumID)
        {
            string query = @"SELECT s.SongID, s.Title, s.ArtistID, u.FullName AS ArtistName, 
                                   s.Duration, s.FilePath, s.CoverImage, s.Genre, 
                                   s.ReleaseDate, s.PlayCount, s.IsActive, 0 AS IsLiked
                           FROM Songs s
                           INNER JOIN Users u ON s.ArtistID = u.UserID
                           WHERE s.AlbumID = @AlbumID AND s.IsActive = 1
                           ORDER BY s.ReleaseDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@AlbumID", albumID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<Song> songs = new List<Song>();

            foreach (DataRow row in dt.Rows)
            {
                songs.Add(MapRowToSong(row));
            }

            return songs;
        }

        private Album MapRowToAlbum(DataRow row)
        {
            return new Album
            {
                AlbumID = Convert.ToInt32(row["AlbumID"]),
                Title = row["Title"].ToString(),
                ArtistID = Convert.ToInt32(row["ArtistID"]),
                ArtistName = row["ArtistName"].ToString(),
                CoverImage = row["CoverImage"] != DBNull.Value ? row["CoverImage"].ToString() : "",
                ReleaseDate = Convert.ToDateTime(row["ReleaseDate"]),
                IsActive = Convert.ToBoolean(row["IsActive"]),
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
