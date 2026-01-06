using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class CommentRepository
    {
        // Get all comments for a post
        public List<Comment> GetCommentsByPost(int postID)
        {
            string query = @"
                SELECT c.CommentID, c.PostID, c.UserID, u.FullName AS Username, u.Avatar AS UserAvatar,
                       c.Content, c.CreatedDate, c.IsActive
                FROM Comments c
                INNER JOIN Users u ON c.UserID = u.UserID
                WHERE c.PostID = @PostID AND c.IsActive = 1
                ORDER BY c.CreatedDate ASC";

            SqlParameter[] parameters = {
                new SqlParameter("@PostID", postID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return MapRowsToCommentList(dt);
        }

        // Add comment to post
        public bool AddComment(Comment comment)
        {
            string query = @"
                INSERT INTO Comments (PostID, UserID, Content, CreatedDate, IsActive)
                VALUES (@PostID, @UserID, @Content, GETDATE(), 1)";

            SqlParameter[] parameters = {
                new SqlParameter("@PostID", comment.PostID),
                new SqlParameter("@UserID", comment.UserID),
                new SqlParameter("@Content", comment.Content)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Update comment
        public bool UpdateComment(Comment comment)
        {
            string query = @"
                UPDATE Comments
                SET Content = @Content
                WHERE CommentID = @CommentID";

            SqlParameter[] parameters = {
                new SqlParameter("@CommentID", comment.CommentID),
                new SqlParameter("@Content", comment.Content)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // Delete comment (soft delete)
        public bool DeleteComment(int commentID)
        {
            string query = "UPDATE Comments SET IsActive = 0 WHERE CommentID = @CommentID";
            SqlParameter[] parameters = { new SqlParameter("@CommentID", commentID) };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        private List<Comment> MapRowsToCommentList(DataTable dt)
        {
            List<Comment> comments = new List<Comment>();

            foreach (DataRow row in dt.Rows)
            {
                comments.Add(new Comment
                {
                    CommentID = Convert.ToInt32(row["CommentID"]),
                    PostID = Convert.ToInt32(row["PostID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    UserAvatar = row["UserAvatar"] != DBNull.Value ? row["UserAvatar"].ToString() : "",
                    Content = row["Content"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    IsActive = Convert.ToBoolean(row["IsActive"])
                });
            }

            return comments;
        }
    }
}
