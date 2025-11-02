using cinema_system.Models;
using System.Collections.Generic;
// Đặt trong namespace tương ứng với dự án của bạn
// namespace cinema_system.Models 

public class User
{
    public int UserId { get; set; }
    public string NameAccount { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }

    public int RoleId { get; set; }

    public Role Role { get; set; }

    public ICollection<Ticket> TicketsSold { get; set; }
}

//public class Role
//{
//    public int RoleId { get; set; }
//    public string NameRole { get; set; }
//    public ICollection<User> Users { get; set; }
//}

