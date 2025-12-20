using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SongCount { get; set; } // Calculated
    }
}
