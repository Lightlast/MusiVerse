using System;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public class ShareRepository
    {
        public bool SharePost(int userID, int postID)
        {
            string query = @"
                IF NOT EXISTS (SELECT 1 FROM PostShares WHERE UserID = @UserID AND PostID = @PostID)
                BEGIN
                    INSERT INTO PostShares (UserID, PostID, ShareDate) 
                    VALUES (@UserID, @PostID, GETDATE())
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

        public int GetShareCount(int postID)
        {
            string query = "SELECT COUNT(*) FROM PostShares WHERE PostID = @PostID";
            SqlParameter[] parameters = { new SqlParameter("@PostID", postID) };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool IsPostShared(int userID, int postID)
        {
            string query = "SELECT COUNT(*) FROM PostShares WHERE UserID = @UserID AND PostID = @PostID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@PostID", postID)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result ?? 0) > 0;
        }
    }
}
