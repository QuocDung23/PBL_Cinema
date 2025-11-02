using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string RowSeat { get; set; } // Hàng (A, B, C...)
        public string ColumnSeat { get; set; } // Cột (1, 2, 3...)
        public string TypeSeat { get; set; }

        public decimal PriceSeat { get; set; }

        // Foreign Key
        public int RoomId { get; set; }

        // Navigation Property
        public Room Room { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
