using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public int ShowTimeId { get; set; }  // Join với ShowTime
        public int SeatId { get; set; }  // Join với Seat
        public int? StaffId { get; set; }  // Join với User (nhân viên bán)
        public int? BillId { get; set; }  // THÊM: Join với Bill (hóa đơn)

        public DateTime DateBooking { get; set; }  // Ngày đặt
        public decimal PriceTicket { get; set; }  // Giá vé
        public string StatusTicket { get; set; }  // Trạng thái (e.g., "Đã thanh toán")

        public ShowTime ShowTime { get; set; }
        public Seat Seat { get; set; }
        public User Staff { get; set; }  // Nhân viên
        public Bill Bill { get; set; }  // THÊM: Hóa đơn

        public Ticket()
        {
            DateBooking = DateTime.Now;
        }
    }
}
