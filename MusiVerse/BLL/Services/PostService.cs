using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using MusiVerse.BLL.Validators;
using System;
using System.Collections.Generic;

namespace MusiVerse.BLL.Services
{
    public class PostService
    {
        private PostRepository _postRepository;
        private PostValidator _validator;

        public PostService()
        {
            _postRepository = new PostRepository();
            _validator = new PostValidator();
        }

        // Get newsfeed posts
        public List<Post> GetNewsFeed(int currentUserID, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                return _postRepository.GetNewsFeed(currentUserID, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải newsfeed: " + ex.Message);
            }
        }

        // Get user's posts
        public List<Post> GetUserPosts(int userID, int currentUserID)
        {
            try
            {
                return _postRepository.GetUserPosts(userID, currentUserID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải bài viết: " + ex.Message);
            }
        }

        // Get saved posts
        public List<Post> GetSavedPosts(int userID)
        {
            try
            {
                return _postRepository.GetSavedPosts(userID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải bài viết đã lưu: " + ex.Message);
            }
        }

        // Create post
        public (bool, string) CreatePost(Post post)
        {
            try
            {
                var validation = _validator.ValidateCreatePost(post);
                if (!validation.Item1)
                    return validation;

                bool success = _postRepository.CreatePost(post);
                if (success)
                    return (true, "Bài viết đã được tạo thành công");
                else
                    return (false, "Không thể tạo bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Update post
        public (bool, string) UpdatePost(Post post)
        {
            try
            {
                var validation = _validator.ValidateUpdatePost(post);
                if (!validation.Item1)
                    return validation;

                bool success = _postRepository.UpdatePost(post);
                if (success)
                    return (true, "Bài viết đã được cập nhật");
                else
                    return (false, "Không thể cập nhật bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Delete post
        public (bool, string) DeletePost(int postID)
        {
            try
            {
                bool success = _postRepository.DeletePost(postID);
                if (success)
                    return (true, "Bài viết đã được xóa");
                else
                    return (false, "Không thể xóa bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Like post
        public (bool, string) LikePost(int userID, int postID)
        {
            try
            {
                bool success = _postRepository.LikePost(userID, postID);
                return (success, success ? "Đã thích bài viết" : "Lỗi thích bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Unlike post
        public (bool, string) UnlikePost(int userID, int postID)
        {
            try
            {
                bool success = _postRepository.UnlikePost(userID, postID);
                return (success, success ? "Đã bỏ thích bài viết" : "Lỗi bỏ thích bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Save post
        public (bool, string) SavePost(int userID, int postID)
        {
            try
            {
                bool success = _postRepository.SavePost(userID, postID);
                return (success, success ? "Đã lưu bài viết" : "Lỗi lưu bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Unsave post
        public (bool, string) UnsavePost(int userID, int postID)
        {
            try
            {
                bool success = _postRepository.UnsavePost(userID, postID);
                return (success, success ? "Đã bỏ lưu bài viết" : "Lỗi bỏ lưu bài viết");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }
    }
}
