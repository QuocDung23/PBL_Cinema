using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.AD
{
    public partial class TicketHistoryForm : Form
    {
        public TicketHistoryForm()
        {
            InitializeComponent();
            LoadTicketHistory();
        }

        private void LoadTicketHistory()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    var tickets = db.Tickets
                        .Include(t => t.Seat)
                        .ThenInclude(s => s.Room)
                        .Include(t => t.ShowTime)
                        .ThenInclude(st => st.Movie)
                        .Include(t => t.Staff)
                        .Select(t => new
                        {
                            TicketId = t.TicketId,
                            Movie = t.ShowTime.Movie.NameMovie,
                            Room = t.Seat.Room.NameRoom,
                            Seat = t.Seat.RowSeat + t.Seat.ColumnSeat,
                            StartTime = t.ShowTime.StartTime,
                            EndTime = t.ShowTime.EndTime,
                            Price = t.Seat.PriceSeat,
                            Staff = t.Staff != null ? t.Staff.UserName : "N/A",
                            PurchaseDate = t.DateBooking
                        })
                        .OrderByDescending(t => t.PurchaseDate)
                        .ToList();

                    dgvTicketHistory.DataSource = tickets;
                    dgvTicketHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTicketHistory.ReadOnly = true;
                    dgvTicketHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvTicketHistory.Columns["TicketId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử vé: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            try
            {
                using (var db = new CinemaDbContext())
                {
                    var tickets = db.Tickets
                        .Include(t => t.Seat)
                        .ThenInclude(s => s.Room)
                        .Include(t => t.ShowTime)
                        .ThenInclude(st => st.Movie)
                        .Include(t => t.Staff)
                        .Where(t => t.ShowTime.Movie.NameMovie.ToLower().Contains(keyword)
                                || t.Seat.Room.NameRoom.ToLower().Contains(keyword)
                                || t.Staff.UserName.ToLower().Contains(keyword))
                        .Select(t => new
                        {
                            Movie = t.ShowTime.Movie.NameMovie,
                            Room = t.Seat.Room.NameRoom,
                            Seat = t.Seat.RowSeat + t.Seat.ColumnSeat,
                            StartTime = t.ShowTime.StartTime,
                            EndTime = t.ShowTime.EndTime,
                            Price = t.Seat.PriceSeat,
                            Staff = t.Staff != null ? t.Staff.UserName : "N/A",
                            PurchaseDate = t.DateBooking
                        })
                        .OrderByDescending(t => t.PurchaseDate)
                        .ToList();

                    dgvTicketHistory.DataSource = tickets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
