using cinema_system.Models;
using cinema_system.nhân_viên;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema_system
{
    public partial class BookingSeat: Form
    {
        private int _staffId;
        private int _showtimeId;
        private List<int> _selectedSeatIds = new List<int>();
        private ShowTime _showtime;

        private const int StandardSeatSize = 40;
        private const int DoubleSeatWidth = 85;
        public BookingSeat()
        {
            InitializeComponent();
        }

        public BookingSeat(int showtimeId, int staffId)
        {
            InitializeComponent();
            _showtimeId = showtimeId;
            _staffId = staffId;

            // Tìm FlowLayoutPanel container
            flpSeatsContainer = this.Controls.Find("flpSeatsContainer", true).FirstOrDefault() as FlowLayoutPanel;

            this.Text = "Sơ đồ Ghế và Đặt Vé";
            LoadBookingData();
            UpdateSummary();

            Button btnNext = this.Controls.Find("btnNext", true).FirstOrDefault() as Button;
            if (btnNext != null)
            {
                btnNext.Click += btnNext_Click; // Gắn sự kiện
            }
        }

        private void LoadBookingData()
        {
            try
            {
                using (var context = new CinemaDbContext())
                {
                    _showtime = context.ShowTimes.Include(st => st.Room).FirstOrDefault(st => st.ShowTimeId == _showtimeId);
                    if (_showtime == null || _showtime.Room == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin suất chiếu hoặc phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var bookedSeatIds = context.Tickets
                        .Where(t => t.ShowTimeId == _showtimeId && t.StatusTicket == "Đã bán")
                        .Select(t => t.SeatId)
                        .ToHashSet();

                    var seatsInRoom = context.Seats
                        .Where(s => s.RoomId == _showtime.RoomId)
                        .OrderBy(s => s.RowSeat).ThenBy(s => s.ColumnSeat)
                        .ToList();

                    GenerateSeatLayout(seatsInRoom, bookedSeatIds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sơ đồ ghế: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GenerateSeatLayout(List<Seat> seats, HashSet<int> bookedSeatIds)
        {
            // Giả định flpSeatsContainer là FlowLayoutPanel chính được kéo thả vào Form
            if (flpSeatsContainer == null) return;
            flpSeatsContainer.Controls.Clear();

            // Cấu hình chung
            const int StandardSeatSize = 40;
            const int DoubleSeatWidth = 85;
            const int SeatSpacingX = 5;
            //const int AisleSpacing = 30; // Vẫn giữ AisleSpacing nếu bạn muốn lối đi ở giữa
            const int RowLabelWidth = 10;

            // Đặt FlpSeatsContainer để căn giữa nội dung
            flpSeatsContainer.FlowDirection = FlowDirection.TopDown; // Đổi thành TopDown nếu muốn căn giữa tốt hơn
            flpSeatsContainer.AutoScroll = true;

            FlowLayoutPanel currentRowFlp = null;
            string lastRowSeat = "";

            foreach (var seat in seats)
            {
                // Xử lý khi chuyển sang hàng ghế mới
                if (seat.RowSeat != lastRowSeat)
                {
                    // 1. Kết thúc hàng cũ và thêm khoảng trống
                    if (lastRowSeat != "")
                    {
                        Panel rowSpacer = new Panel { Size = new Size(1, 3), BackColor = Color.Transparent };
                        flpSeatsContainer.Controls.Add(rowSpacer);
                    }

                    // 2. Tạo FLP mới cho hàng ghế này
                    currentRowFlp = new FlowLayoutPanel
                    {
                        AutoSize = true,
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = false,
                        Margin = new Padding(0)
                    };
                    flpSeatsContainer.Controls.Add(currentRowFlp);

                    // 3. Thêm Label tên hàng (A, B, C...)
                    Label lblRow = new Label
                    {
                        Text = seat.RowSeat,
                        Width = RowLabelWidth,
                        Height = StandardSeatSize,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(this.Font, FontStyle.Bold),
                        Margin = new Padding(0, 5, 10, 5) // Tăng margin phải để tách biệt
                    };
                    currentRowFlp.Controls.Add(lblRow);

                    lastRowSeat = seat.RowSeat;
                }

                // Tạo nút ghế
                Button btnSeat = new Button();
                btnSeat.Tag = seat.SeatId;
                btnSeat.Text = seat.RowSeat + seat.ColumnSeat;
                btnSeat.Click += Seat_Click;

                // 4. Thiết lập kích thước và Margin
                if (seat.TypeSeat.ToUpper() == "ĐÔI")
                {
                    btnSeat.Size = new Size(DoubleSeatWidth, StandardSeatSize);
                    btnSeat.BackColor = Color.HotPink;
                }
                else
                {
                    btnSeat.Size = new Size(StandardSeatSize, StandardSeatSize);
                    btnSeat.BackColor = Color.LightGreen;
                }
                btnSeat.Margin = new Padding(SeatSpacingX, 5, 0, 5); // Margin chỉ ở bên trái

                // 5. [LOẠI BỎ LOGIC LỐI ĐI SAU CỘT 8]

                // 6. Kiểm tra trạng thái đã bán
                if (bookedSeatIds.Contains(seat.SeatId))
                {
                    btnSeat.BackColor = Color.Gray;
                    btnSeat.Enabled = false;
                }

                // Thêm nút ghế vào FlowLayoutPanel của hàng hiện tại
                currentRowFlp.Controls.Add(btnSeat);
            }

            // Sau khi sinh UI, gọi hàm căn giữa
            CenterSeatLayout();
        }

        // ---------- HÀM CĂN GIỮA TOÀN BỘ SƠ ĐỒ GHẾ ----------
        private void CenterSeatLayout()
        {
            flpSeatsContainer.AutoSize = true;
            flpSeatsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            foreach (Control rowControl in flpSeatsContainer.Controls)
            {
                if (rowControl is FlowLayoutPanel rowFlp && rowControl.Controls.Count > 1)
                {
                    Label rowLabel = rowFlp.Controls[0] as Label;
                    if (rowLabel != null && rowLabel.Text.Equals("I", StringComparison.OrdinalIgnoreCase))
                    {
                        int totalRowWidth = rowFlp.Controls.Cast<Control>().Sum(c => c.Width + c.Margin.Horizontal);
                        int formWidth = flpSeatsContainer.Width;
                        int paddingLeft = (formWidth - totalRowWidth) / 2;

                        if (paddingLeft > 0)
                        {
                            Panel spacer = new Panel { Size = new Size(paddingLeft, StandardSeatSize), BackColor = Color.Transparent };
                            rowFlp.Controls.Add(spacer);
                            rowFlp.Controls.SetChildIndex(spacer, 0); 
                        }
                    }
                }
            }
        }

        // File BookingSeat.cs

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int seatId = (int)btn.Tag;
            char row = btn.Text.ToUpper()[0]; 

            if (_selectedSeatIds.Contains(seatId))
            {
                _selectedSeatIds.Remove(seatId);

                if (row == 'I')
                {
                    btn.BackColor = Color.HotPink; 
                }
                else
                {
                    btn.BackColor = Color.LightGreen; 
                }
            }
            else
            {
                _selectedSeatIds.Add(seatId);
                btn.BackColor = Color.Brown;
            }

            UpdateSummary();
        }
        // XÓA HOẶC KHÔNG SỬ DỤNG HÀM GetSeatColor NỮA

        private Color GetSeatColor(string seatLabel)
        {
            if (seatLabel.StartsWith("I")) return Color.HotPink; // Ghế đôi
                                                                 // Các hàng VIP của bạn là D, E, F
            if (seatLabel.StartsWith("D") || seatLabel.StartsWith("E") || seatLabel.StartsWith("F")) return Color.Orange; // Ghế VIP
            return Color.LightGreen; // Ghế thường
        }

        // File BookingSeat.cs

        private void UpdateSummary()
        {
            decimal totalRevenue = 0m;
            List<string> seatNames = new List<string>();

            // 1. Logic Tính Tổng Tiền từ DB
            if (_selectedSeatIds.Count > 0)
            {
                try
                {
                    using (var context = new CinemaDbContext())
                    {
                        // Lấy tất cả ghế đang chọn, bao gồm cả giá PriceSeat
                        var selectedSeats = context.Seats
                            .Where(s => _selectedSeatIds.Contains(s.SeatId))
                            .ToList();

                        foreach (var seat in selectedSeats)
                        {
                            // Cộng dồn giá PriceSeat đã lưu trong DB
                            totalRevenue += seat.PriceSeat;

                            // Thêm tên ghế vào danh sách (Ví dụ: A1 (75,000 đ))
                            seatNames.Add($"{seat.RowSeat}{seat.ColumnSeat}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tính tổng tiền: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 2. CẬP NHẬT GIAO DIỆN SỬ DỤNG TÊN CHUẨN CỦA BẠN
            // Tìm Label Tổng tiền (Giả định tên là lblTongTien hoặc lblTotal)
            Label lblTongTienControl = this.Controls.Find("lblTotal", true).FirstOrDefault() as Label;
            // Tìm Label Danh sách ghế (Giả định tên là lblDanhSachGhe)
            Label lblListSeats = this.Controls.Find("lblListSeats", true).FirstOrDefault() as Label;
            // CẬP NHẬT TỔNG TIỀN
            if (lblTongTienControl != null)
            {
                lblTongTienControl.Text = $"Tổng tiền: {totalRevenue:N0} đ";
            }
            // CẬP NHẬT DANH SÁCH GHẾ ĐÃ CHỌN
            if (lblListSeats != null)
            {
                string displaySeats = (seatNames.Any()
                                       ? string.Join(", ", seatNames)
                                       : "(chưa chọn)");

                lblListSeats.Text = "Ghế: " + displaySeats;
            }
        }

        // File BookingSeat.cs

        private void btnNext_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra ghế đã chọn
            if (_selectedSeatIds == null || _selectedSeatIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế để thanh toán.", "Lỗi thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tính tổng tiền cuối cùng (Lấy giá trị từ Label)
            Label lblTongTienControl = this.Controls.Find("lblTotal", true).FirstOrDefault() as Label;
            decimal finalAmount = 0m;

            if (lblTongTienControl != null &&
                Decimal.TryParse(lblTongTienControl.Text.Replace("Tổng tiền: ", "").Replace(" đ", "").Replace(",", ""), out finalAmount))
            {
                // 3. Mở Form Thanh toán (PaymentForm)

                // Đảm bảo Form PaymentForm có constructor: PaymentForm(List<int>, decimal, int, int)
                PaymentForm paymentForm = new PaymentForm(_selectedSeatIds, finalAmount, _showtimeId, _staffId);

                // Quản lý luồng Form: Ẩn Form Booking, mở Form Payment
                this.Hide();
                DialogResult result = paymentForm.ShowDialog();

                // 4. Xử lý sau khi PaymentForm đóng
                if (result == DialogResult.OK)
                {
                    // Nếu Payment/BillForm đóng với kết quả OK, đóng Form BookingSeat
                    this.Close();
                }
                else
                {
                    // Nếu hủy, hiện lại Form Booking
                    this.Show();
                    // Cập nhật lại sơ đồ ghế (vì có thể có lỗi hoặc ghế đã được bán)
                    LoadBookingData();
                }
            }
            else
            {
                MessageBox.Show("Không thể đọc tổng tiền. Vui lòng thử lại.", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
