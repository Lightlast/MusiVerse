using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusiVerse.DAL.Repositories
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// Get trending posts sorted by likes
        /// </summary>
        public static List<int> GetTrendingPostsByLikes(int limit = 50)
        {
            string query = @"
                SELECT TOP @Limit PostID
                FROM Posts
                WHERE IsActive = 1
                ORDER BY 
                    (SELECT COUNT(*) FROM PostLikes WHERE PostID = Posts.PostID) DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@Limit", limit)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<int> postIds = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                postIds.Add(Convert.ToInt32(row["PostID"]));
            }

            return postIds;
        }

        /// <summary>
        /// Get trending posts sorted by comments
        /// </summary>
        public static List<int> GetTrendingPostsByComments(int limit = 50)
        {
            string query = @"
                SELECT TOP @Limit PostID
                FROM Posts
                WHERE IsActive = 1
                ORDER BY 
                    (SELECT COUNT(*) FROM Comments WHERE PostID = Posts.PostID AND IsActive = 1) DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@Limit", limit)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<int> postIds = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                postIds.Add(Convert.ToInt32(row["PostID"]));
            }

            return postIds;
        }

        /// <summary>
        /// Get trending posts sorted by shares
        /// </summary>
        public static List<int> GetTrendingPostsByShares(int limit = 50)
        {
            string query = @"
                SELECT TOP @Limit PostID
                FROM Posts
                WHERE IsActive = 1
                ORDER BY 
                    (SELECT COUNT(*) FROM PostShares WHERE PostID = Posts.PostID) DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@Limit", limit)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            List<int> postIds = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                postIds.Add(Convert.ToInt32(row["PostID"]));
            }

            return postIds;
        }

        /// <summary>
        /// Check if user exists
        /// </summary>
        public static bool UserExists(int userID)
        {
            string query = "SELECT 1 FROM Users WHERE UserID = @UserID AND IsActive = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// Get total post count for user
        /// </summary>
        public static int GetUserPostCount(int userID)
        {
            string query = "SELECT COUNT(*) FROM Posts WHERE UserID = @UserID AND IsActive = 1";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }

            return 0;
        }

        /// <summary>
        /// Get total followers count for user
        /// </summary>
        public static int GetUserFollowerCount(int userID)
        {
            string query = @"
                SELECT COUNT(DISTINCT UserID)
                FROM (
                    SELECT UserID FROM PostLikes WHERE PostID IN (SELECT PostID FROM Posts WHERE UserID = @UserID)
                    UNION
                    SELECT UserID FROM Comments WHERE PostID IN (SELECT PostID FROM Posts WHERE UserID = @UserID)
                ) AS Followers";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }

            return 0;
        }

        /// <summary>
        /// Get engagement score for post (likes + comments + shares)
        /// </summary>
        public static int GetPostEngagementScore(int postID)
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM PostLikes WHERE PostID = @PostID) +
                    (SELECT COUNT(*) FROM Comments WHERE PostID = @PostID AND IsActive = 1) +
                    (SELECT COUNT(*) FROM PostShares WHERE PostID = @PostID) AS EngagementScore";

            SqlParameter[] parameters = {
                new SqlParameter("@PostID", postID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }

            return 0;
        }

        /// <summary>
        /// Mark notification as read
        /// </summary>
        public static bool MarkNotificationAsRead(int notificationID)
        {
            string query = "UPDATE Notifications SET IsRead = 1 WHERE NotificationID = @NotificationID";
            SqlParameter[] parameters = {
                new SqlParameter("@NotificationID", notificationID)
            };

            int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        /// <summary>
        /// Delete old notifications (older than specified days)
        /// </summary>
        public static bool DeleteOldNotifications(int daysOld)
        {
            string query = "DELETE FROM Notifications WHERE CreatedDate < DATEADD(DAY, -@Days, GETDATE())";
            SqlParameter[] parameters = {
                new SqlParameter("@Days", daysOld)
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

        /// <summary>
        /// Get user statistics
        /// </summary>
        public static (int postCount, int totalLikes, int totalComments) GetUserStatistics(int userID)
        {
            string query = @"
                SELECT 
                    COUNT(DISTINCT p.PostID) AS PostCount,
                    (SELECT COUNT(*) FROM PostLikes WHERE PostID IN (SELECT PostID FROM Posts WHERE UserID = @UserID)) AS TotalLikes,
                    (SELECT COUNT(*) FROM Comments WHERE PostID IN (SELECT PostID FROM Posts WHERE UserID = @UserID) AND IsActive = 1) AS TotalComments
                FROM Posts p
                WHERE p.UserID = @UserID AND p.IsActive = 1";

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID)
            };

            DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                int postCount = Convert.ToInt32(dt.Rows[0]["PostCount"]);
                int totalLikes = Convert.ToInt32(dt.Rows[0]["TotalLikes"]);
                int totalComments = Convert.ToInt32(dt.Rows[0]["TotalComments"]);
                return (postCount, totalLikes, totalComments);
            }

            return (0, 0, 0);
        }
    }
}
