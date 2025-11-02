using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int StaffId { get; set; }
        public int ShowTimeId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Status { get; set; } = "Hoàn thành";  

        public User Staff { get; set; }
        public ShowTime ShowTime { get; set; }

    }
}
