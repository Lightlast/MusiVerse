using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; } // For display
        public int Duration { get; set; }
        public string FilePath { get; set; }
        public string CoverImage { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PlayCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsLiked { get; set; } // For current user
    }
}
