using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class PostRepository
    {
        // Get all posts for newsfeed (paginated)
        public List<Post> GetNewsFeed(int currentUserID, int pageNumber = 1, int pageSize = 10)
        {
            string query = @"
                SELECT p.PostID, p.UserID, u.FullName AS Username, u.Avatar AS UserAvatar,
                       p.Content, p.MediaPath, p.MediaType, p.CreatedDate, p.IsActive,
                       (SELECT COUNT(*) FROM PostLikes WHERE PostID = p.PostID) AS LikeCount,
                       (SELECT COUNT(*) FROM Comments WHERE PostID = p.PostID AND IsActive = 1) AS CommentCount,
                       (SELECT COUNT(*) FROM PostShares WHERE PostID = p.PostID) AS ShareCount,
                       CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked,
                       CASE WHEN ps.SaveID IS NOT NULL THEN 1 ELSE 0 END AS IsSaved
                FROM Posts p
                INNER JOIN Users u ON p.UserID = u.UserID
                LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
                LEFT JOIN PostSaves ps ON p.PostID = ps.PostID AND ps.UserID = @CurrentUserID
                WHERE p.IsActive = 1
                ORDER BY p.CreatedDate DESC
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            int offset = (pageNumber - 1) * pageSize;
            SqlParameter[] parameters = {
                new SqlParameter("@CurrentUserID", currentUserID),
                new SqlParameter("@Offset", offset),
                new SqlParameter("@PageSize", pageSize)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return MapRowsToPostList(dt);
        }

        // Get posts by specific user
        public List<Post> GetUserPosts(int userID, int currentUserID)
        {
            string query = @"
                SELECT p.PostID, p.UserID, u.FullName AS Username, u.Avatar AS UserAvatar,
                       p.Content, p.MediaPath, p.MediaType, p.CreatedDate, p.IsActive,
                       (SELECT COUNT(*) FROM PostLikes WHERE PostID = p.PostID) AS LikeCount,
                       (SELECT COUNT(*) FROM Comments WHERE PostID = p.PostID AND IsActive = 1) AS CommentCount,
                       (SELECT COUNT(*) FROM PostShares WHERE PostID = p.PostID) AS ShareCount,
                       CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked,
                       CASE WHEN ps.SaveID IS NOT NULL THEN 1 ELSE 0 END AS IsSaved
                FROM Posts p
                INNER JOIN Users u ON p.UserID = u.UserID
                LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @CurrentUserID
                LEFT JOIN PostSaves ps ON p.PostID = ps.PostID AND ps.UserID = @CurrentUserID
                WHERE p.UserID = @UserID AND p.IsActive = 1
                ORDER BY p.CreatedDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@CurrentUserID", currentUserID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return MapRowsToPostList(dt);
        }

        // Get saved posts
        public List<Post> GetSavedPosts(int userID)
        {
            string query = @"
                SELECT p.PostID, p.UserID, u.FullName AS Username, u.Avatar AS UserAvatar,
                       p.Content, p.MediaPath, p.MediaType, p.CreatedDate, p.IsActive,
                       (SELECT COUNT(*) FROM PostLikes WHERE PostID = p.PostID) AS LikeCount,
                       (SELECT COUNT(*) FROM Comments WHERE PostID = p.PostID AND IsActive = 1) AS CommentCount,
                       (SELECT COUNT(*) FROM PostShares WHERE PostID = p.PostID) AS ShareCount,
                       CASE WHEN pl.LikeID IS NOT NULL THEN 1 ELSE 0 END AS IsLiked, 1 AS IsSaved
                FROM Posts p
                INNER JOIN Users u ON p.UserID = u.UserID
                INNER JOIN PostSaves ps ON p.PostID = ps.PostID
                LEFT JOIN PostLikes pl ON p.PostID = pl.PostID AND pl.UserID = @UserID
                WHERE ps.UserID = @UserID AND p.IsActive = 1
                ORDER BY ps.SaveDate DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return MapRowsToPostList(dt);
        }

        // Create new post
        public bool CreatePost(Post post)
        {
            string query = @"
                INSERT INTO Posts (UserID, Content, MediaPath, MediaType, CreatedDate, IsActive)
                VALUES (@UserID, @Content, @MediaPath, @MediaType, GETDATE(), 1)";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", post.UserID),
                new SqlParameter("@Content", post.Content ?? (object)DBNull.Value),
                new SqlParameter("@MediaPath", post.MediaPath ?? (object)DBNull.Value),
                new SqlParameter("@MediaType", post.MediaType ?? (object)DBNull.Value)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Update post
        public bool UpdatePost(Post post)
        {
            string query = @"
                UPDATE Posts
                SET Content = @Content, MediaPath = @MediaPath, MediaType = @MediaType
                WHERE PostID = @PostID";

            SqlParameter[] parameters = {
                new SqlParameter("@PostID", post.PostID),
                new SqlParameter("@Content", post.Content ?? (object)DBNull.Value),
                new SqlParameter("@MediaPath", post.MediaPath ?? (object)DBNull.Value),
                new SqlParameter("@MediaType", post.MediaType ?? (object)DBNull.Value)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Delete post (soft delete)
        public bool DeletePost(int postID)
        {
            string query = "UPDATE Posts SET IsActive = 0 WHERE PostID = @PostID";
            SqlParameter[] parameters = { new SqlParameter("@PostID", postID) };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Like post
        public bool LikePost(int userID, int postID)
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM PostLikes WHERE UserID = @UserID AND PostID = @PostID)
                BEGIN
                    INSERT INTO PostLikes (UserID, PostID, LikeDate) VALUES (@UserID, @PostID, GETDATE())
                END";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@PostID", postID)
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

        // Unlike post
        public bool UnlikePost(int userID, int postID)
        {
            string query = "DELETE FROM PostLikes WHERE UserID = @UserID AND PostID = @PostID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@PostID", postID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Save post
        public bool SavePost(int userID, int postID)
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM PostSaves WHERE UserID = @UserID AND PostID = @PostID)
                BEGIN
                    INSERT INTO PostSaves (UserID, PostID, SaveDate) VALUES (@UserID, @PostID, GETDATE())
                END";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@PostID", postID)
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

        // Unsave post
        public bool UnsavePost(int userID, int postID)
        {
            string query = "DELETE FROM PostSaves WHERE UserID = @UserID AND PostID = @PostID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@PostID", postID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        private List<Post> MapRowsToPostList(DataTable dt)
        {
            List<Post> posts = new List<Post>();

            foreach (DataRow row in dt.Rows)
            {
                posts.Add(new Post
                {
                    PostID = Convert.ToInt32(row["PostID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    UserAvatar = row["UserAvatar"] != DBNull.Value ? row["UserAvatar"].ToString() : "",
                    Content = row["Content"] != DBNull.Value ? row["Content"].ToString() : "",
                    MediaPath = row["MediaPath"] != DBNull.Value ? row["MediaPath"].ToString() : "",
                    MediaType = row["MediaType"] != DBNull.Value ? row["MediaType"].ToString() : "",
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    LikeCount = Convert.ToInt32(row["LikeCount"]),
                    CommentCount = Convert.ToInt32(row["CommentCount"]),
                    ShareCount = Convert.ToInt32(row["ShareCount"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    IsLiked = row["IsLiked"] != DBNull.Value && Convert.ToBoolean(row["IsLiked"]),
                    IsSaved = row["IsSaved"] != DBNull.Value && Convert.ToBoolean(row["IsSaved"])
                });
            }

            return posts;
        }
    }
}
