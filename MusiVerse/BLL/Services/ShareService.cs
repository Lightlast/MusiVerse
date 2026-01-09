using System;
using MusiVerse.DAL.Repositories;

namespace MusiVerse.BLL.Services
{
    public class ShareService
    {
        private ShareRepository _shareRepository;

        public ShareService()
        {
            _shareRepository = new ShareRepository();
        }

        // Share post
        public (bool, string) SharePost(int userID, int postID)
        {
            try
            {
                if (userID <= 0 || postID <= 0)
                    return (false, "D? li?u không h?p l?");

                bool success = _shareRepository.SharePost(userID, postID);
                return (success, success ? "Bài vi?t ?ã ???c chia s?" : "L?i chia s? bài vi?t");
            }
            catch (Exception ex)
            {
                return (false, "L?i: " + ex.Message);
            }
        }

        // Unshare post
        public (bool, string) UnsharePost(int userID, int postID)
        {
            try
            {
                if (userID <= 0 || postID <= 0)
                    return (false, "D? li?u không h?p l?");

                bool success = _shareRepository.UnsharePost(userID, postID);
                return (success, success ? "?ã b? chia s? bài vi?t" : "L?i b? chia s? bài vi?t");
            }
            catch (Exception ex)
            {
                return (false, "L?i: " + ex.Message);
            }
        }

        // Get share count
        public int GetShareCount(int postID)
        {
            try
            {
                return _shareRepository.GetShareCount(postID);
            }
            catch
            {
                return 0;
            }
        }

        // Check if shared
        public bool IsPostShared(int userID, int postID)
        {
            try
            {
                return _shareRepository.IsPostShared(userID, postID);
            }
            catch
            {
                return false;
            }
        }
    }
}
