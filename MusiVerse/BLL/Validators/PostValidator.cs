using MusiVerse.DTO.Models;
using System;

namespace MusiVerse.BLL.Validators
{
    public class PostValidator
    {
        private const int MAX_CONTENT_LENGTH = 5000;
        private const int MIN_CONTENT_LENGTH = 1;

        public (bool, string) ValidateCreatePost(Post post)
        {
            if (post == null)
                return (false, "Bài viết không hợp lệ");

            if (post.UserID <= 0)
                return (false, "Người dùng không hợp lệ");

            // Either content or media must exist
            bool hasContent = !string.IsNullOrWhiteSpace(post.Content);
            bool hasMedia = !string.IsNullOrWhiteSpace(post.MediaPath);

            if (!hasContent && !hasMedia)
                return (false, "Bài viết phải có nội dung hoặc hình ảnh/video");

            if (hasContent)
            {
                string content = post.Content.Trim();

                if (content.Length < MIN_CONTENT_LENGTH)
                    return (false, "Nội dung quá ngắn");

                if (content.Length > MAX_CONTENT_LENGTH)
                    return (false, $"Nội dung không được vượt quá {MAX_CONTENT_LENGTH} ký tự");
            }

            if (hasMedia && string.IsNullOrWhiteSpace(post.MediaType))
                return (false, "Loại media không hợp lệ");

            return (true, "OK");
        }

        public (bool, string) ValidateUpdatePost(Post post)
        {
            if (post == null)
                return (false, "Bài viết không hợp lệ");

            if (post.PostID <= 0)
                return (false, "ID bài viết không hợp lệ");

            // Same validation as create
            return ValidateCreatePost(post);
        }
    }
}
