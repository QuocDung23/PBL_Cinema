using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string NameRoom { get; set; }
        public int TotalSeat { get; set; }
        public string TypeRoom { get; set; }
        public bool? IsActive { get; set; }

        // Navigation Property
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    }
}
