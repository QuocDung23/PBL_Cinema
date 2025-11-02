using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.nhân_viên
{
    public partial class PaymentForm : Form
    {
        private List<int> _seatIds;
        private decimal _totalAmount;
        private int _showtimeId;
        private int _staffId;
        private List<BillItem> _billDetails;

        public PaymentForm(List<int> seatIds, decimal totalAmount, int showtimeId, int staffId)
        {
            InitializeComponent();

            _seatIds = seatIds;
            _totalAmount = totalAmount;
            _showtimeId = showtimeId;
            _staffId = staffId;

            LoadBillDetails();
        }

        public class BillItem
        {
            public string NameSeat { get; set; }
            public string TypeSeat { get; set; }
            public decimal Price { get; set; }
        }

        private void LoadBillDetails()
        {
            try
            {
                using (var context = new CinemaDbContext())
                {
                    var seatsData = context.Seats
                        .Where(s => _seatIds.Contains(s.SeatId))
                        .Select(s => new BillItem
                        {
                            NameSeat = s.RowSeat + s.ColumnSeat,
                            TypeSeat = s.TypeSeat,
                            Price = s.PriceSeat
                        })
                        .ToList();

                    _billDetails = seatsData;

                    DataGridView dgvBillDetails = this.Controls.Find("dgvBillDetails", true).FirstOrDefault() as DataGridView;

                    if (dgvBillDetails != null)
                    {
                        dgvBillDetails.DataSource = null;
                        dgvBillDetails.DataSource = seatsData;
                        dgvBillDetails.AutoGenerateColumns = false;
                        dgvBillDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvBillDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        dgvBillDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        dgvBillDetails.RowHeadersVisible = false;
                        dgvBillDetails.ReadOnly = true;
                        dgvBillDetails.AllowUserToAddRows = false;
                        dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        if (dgvBillDetails.Columns.Count == 0)
                        {
                            dgvBillDetails.Columns.Add("NameSeat", "Ghế");
                            dgvBillDetails.Columns.Add("TypeSeat", "Loại Ghế");
                            dgvBillDetails.Columns.Add("Price", "Giá Tiền (VNĐ)");
                        }

                        if (dgvBillDetails.Columns.Contains("Price"))
                        {
                            dgvBillDetails.Columns["Price"].DefaultCellStyle.Format = "N0";
                            dgvBillDetails.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }

                        if (seatsData.Count == 0)
                        {
                            dgvBillDetails.Rows.Add("", "", "0");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy GridView 'dgvBillDetails'. Vui lòng kiểm tra designer.", "Lỗi Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Label lblTotalAmount = this.Controls.Find("lblTotalAmount", true).FirstOrDefault() as Label;
                    if (lblTotalAmount != null)
                    {
                        lblTotalAmount.Text = $"TỔNG TIỀN: {_totalAmount:N0} VNĐ";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lblTotalAmount trong form. Vui lòng kiểm tra designer hoặc thêm Label.", "Lỗi Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    Label lblDateTime = this.Controls.Find("lblDateTime", true).FirstOrDefault() as Label;
                    if (lblDateTime != null)
                    {
                        lblDateTime.Text = $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lblDateTime trong form. Vui lòng kiểm tra designer hoặc thêm Label.", "Lỗi Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    var showTime = context.ShowTimes
                        .Include(st => st.Movie)
                        .Include(st => st.Room)
                        .FirstOrDefault(st => st.ShowTimeId == _showtimeId);

                    var staff = context.Users.FirstOrDefault(u => u.UserId == _staffId);

                    Label lblMovieName = this.Controls.Find("lblMovieName", true).FirstOrDefault() as Label;
                    if (lblMovieName != null)
                    {
                        lblMovieName.Text = $"Phim: {showTime?.Movie?.NameMovie ?? "Không xác định"}";
                    }
                    else
                    {
                        lblMovieName = new Label { Name = "lblMovieName", Text = $"{showTime?.Movie?.NameMovie ?? "Không xác định"}" };
                        lblMovieName.Size = new Size(300, 20);
                        lblMovieName.ForeColor = Color.White;
                        this.Controls.Add(lblMovieName);
                    }

                    Label lblRoomName = this.Controls.Find("lblRoomName", true).FirstOrDefault() as Label;
                    if (lblRoomName != null)
                    {
                        lblRoomName.Text = $"Phòng: {showTime?.Room?.NameRoom ?? "Không xác định"}";
                    }
                    else
                    {
                        lblRoomName = new Label { Name = "lblRoomName", Text = $"Phòng: {showTime?.Room?.NameRoom ?? "Không xác định"}" };
                        lblRoomName.Size = new Size(300, 20);
                        lblRoomName.ForeColor = Color.LightGray;
                        this.Controls.Add(lblRoomName);
                    }

                    Label lblStaffName = this.Controls.Find("lblStaffName", true).FirstOrDefault() as Label;
                    if (lblStaffName != null)
                    {
                        lblStaffName.Text = $"Nhân viên bán: {staff?.UserName ?? "Không xác định"}";
                    }
                    else
                    {
                        lblStaffName = new Label { Name = "lblStaffName", Text = $"Nhân viên bán: {staff?.UserName ?? "Không xác định"}" };
                        lblStaffName.Size = new Size(300, 20);
                        lblStaffName.ForeColor = Color.LightGray;
                        this.Controls.Add(lblStaffName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chi tiết hóa đơn: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (_seatIds.Count == 0)
            {
                MessageBox.Show("Không có ghế nào được chọn để thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new CinemaDbContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (!context.Users.Any(u => u.UserId == _staffId))
                                throw new Exception($"StaffId {_staffId} không tồn tại.");
                            if (!context.ShowTimes.Any(st => st.ShowTimeId == _showtimeId))
                                throw new Exception($"ShowTimeId {_showtimeId} không tồn tại.");
                            foreach (var seatId in _seatIds)
                                if (!context.Seats.Any(s => s.SeatId == seatId))
                                    throw new Exception($"SeatId {seatId} không tồn tại.");

                            int savedTicketCount = 0;
                            foreach (var seatId in _seatIds)
                            {
                                var seat = context.Seats.FirstOrDefault(s => s.SeatId == seatId);
                                if (seat == null) continue;

                                var ticket = new Ticket
                                {
                                    ShowTimeId = _showtimeId,
                                    SeatId = seatId,
                                    DateBooking = DateTime.Now,
                                    PriceTicket = seat.PriceSeat,
                                    StatusTicket = "Đã bán",
                                    StaffId = _staffId
                                };
                                context.Tickets.Add(ticket);
                                savedTicketCount++;
                            }

                            context.SaveChanges();
                            transaction.Commit();

                            MessageBox.Show($"Thanh toán thành công!\nSố vé: {savedTicketCount}\nTổng tiền: {_totalAmount:N0} VNĐ", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();

                            StaffDesign staffForm = new StaffDesign(_staffId, 2, "Tên nhân viên");
                            staffForm.Show();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Lỗi lưu vé: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
