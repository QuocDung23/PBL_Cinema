using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class ShowTime
    {
        public int ShowTimeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Foreign Keys
        public int MovieId { get; set; }
        public int RoomId { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Room Room { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
