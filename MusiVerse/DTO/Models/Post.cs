using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; } // For display
        public string UserAvatar { get; set; } // For display
        public string Content { get; set; }
        public string MediaPath { get; set; }
        public string MediaType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int ShareCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsLiked { get; set; } // By current user
        public bool IsSaved { get; set; } // By current user
    }
}
