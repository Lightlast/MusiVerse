using System;
using System.Collections.Generic;

namespace MusiVerse.DTO.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string CoverImage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SongCount { get; set; }
        public bool IsActive { get; set; }
    }
}
