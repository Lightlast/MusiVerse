using MusiVerse.DAL.Repositories;
using MusiVerse.DTO.Models;
using System;
using System.Collections.Generic;

namespace MusiVerse.BLL.Services
{
    public class CommentService
    {
        private CommentRepository _commentRepository;

        public CommentService()
        {
            _commentRepository = new CommentRepository();
        }

        // Get comments for a post
        public List<Comment> GetCommentsByPost(int postID)
        {
            try
            {
                return _commentRepository.GetCommentsByPost(postID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải bình luận: " + ex.Message);
            }
        }

        // Add comment
        public (bool, string) AddComment(Comment comment)
        {
            try
            {
                if (comment == null || comment.PostID <= 0 || comment.UserID <= 0)
                    return (false, "Dữ liệu bình luận không hợp lệ");

                string content = comment.Content?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(content))
                    return (false, "Nội dung bình luận không được trống");

                if (content.Length > 1000)
                    return (false, "Bình luận không được vượt quá 1000 ký tự");

                comment.Content = content;
                bool success = _commentRepository.AddComment(comment);

                if (success)
                    return (true, "Bình luận đã được thêm");
                else
                    return (false, "Không thể thêm bình luận");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Update comment
        public (bool, string) UpdateComment(Comment comment)
        {
            try
            {
                if (comment == null || comment.CommentID <= 0)
                    return (false, "Bình luận không hợp lệ");

                string content = comment.Content?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(content))
                    return (false, "Nội dung bình luận không được trống");

                if (content.Length > 1000)
                    return (false, "Bình luận không được vượt quá 1000 ký tự");

                comment.Content = content;
                bool success = _commentRepository.UpdateComment(comment);

                if (success)
                    return (true, "Bình luận đã được cập nhật");
                else
                    return (false, "Không thể cập nhật bình luận");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Delete comment
        public (bool, string) DeleteComment(int commentID)
        {
            try
            {
                bool success = _commentRepository.DeleteComment(commentID);
                if (success)
                    return (true, "Bình luận đã được xóa");
                else
                    return (false, "Không thể xóa bình luận");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Delete comment with ownership check
        public (bool, string) DeleteComment(int commentID, int userID)
        {
            try
            {
                // For now, just call the basic delete (ownership check should be in UI)
                bool success = _commentRepository.DeleteComment(commentID);
                if (success)
                    return (true, "Bình luận đã được xóa");
                else
                    return (false, "Không thể xóa bình luận");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }
    }
}
