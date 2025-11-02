using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using cinema_system.Models;

namespace cinema_system
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public CinemaDbContext() : base() {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // 2. Cấu hình Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["CinemaDb"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        // 3. Cấu hình mối quan hệ (Tùy chọn, EF Core tự suy luận phần lớn)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình rõ ràng mối quan hệ N:1 giữa Ticket và User (StaffId)
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Staff)
                .WithMany(u => u.TicketsSold)
                .HasForeignKey(t => t.StaffId)
                .IsRequired(false); 
        }
    }
}
