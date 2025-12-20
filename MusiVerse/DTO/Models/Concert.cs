using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiVerse.DTO.Models
{
    public class Concert
    {
        public int ConcertID { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; } // For display
        public string Name { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime ConcertDate { get; set; }
        public string PosterImage { get; set; }
        public int TotalTickets { get; set; }
        public int AvailableTickets { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
