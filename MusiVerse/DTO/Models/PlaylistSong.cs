using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class PlaylistSong
    {
        public int PlaylistSongID { get; set; }
        public int PlaylistID { get; set; }
        public int SongID { get; set; }
        public int OrderIndex { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
