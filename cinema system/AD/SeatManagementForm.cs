using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;

namespace cinema_system.AD
{
    public partial class SeatManagementForm : Form
    {
        public SeatManagementForm()
        {
            InitializeComponent();
            LoadRooms();
            LoadSeatTypes();
        }



        private void LoadRooms()
        {
            using (var db = new CinemaDbContext())
            {
                cmbRoom.DataSource = db.Rooms.ToList();
                cmbRoom.DisplayMember = "NameRoom";
                cmbRoom.ValueMember = "RoomId";
            }
        }

        private void LoadSeatTypes()
        {
            cmbTypeSeat.Items.Clear();
            cmbTypeSeat.Items.AddRange(new string[] { "Thường", "VIP", "Couple" });
            cmbTypeSeat.SelectedIndex = 0;
        }

        private void btnGenerateSeats_Click(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            int roomId = (int)cmbRoom.SelectedValue;

            if (!int.TryParse(txtRowCount.Text, out int rowCount) || rowCount <= 0)
            {
                MessageBox.Show("Số hàng không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtColumnCount.Text, out int colCount) || colCount <= 0)
            {
                MessageBox.Show("Số cột không hợp lệ!");
                return;
            }

            if (colCount > 15)
            {
                MessageBox.Show("Số cột tối đa là 15!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá ghế không hợp lệ!");
                return;
            }

            // số hàng ghế đôi ở cuối
            int doubleRowCount = 0;
            int doubleSeatPerRow = 0;
            int.TryParse(txtDoubleRowCount.Text, out doubleRowCount);
            int.TryParse(txtDoubleSeatPerRow.Text, out doubleSeatPerRow);

            string defaultType = cmbTypeSeat.SelectedItem?.ToString() ?? "Thường";

            List<Seat> seatsToAdd = new List<Seat>();

            for (int r = 0; r < rowCount; r++)
            {
                char rowLetter = (char)('A' + r);
                bool isDoubleRow = (r >= rowCount - doubleRowCount); // hàng đôi ở cuối

                if (!isDoubleRow)
                {
                    // ===== HÀNG GHẾ THƯỜNG =====
                    for (int c = 1; c <= colCount; c++)
                    {
                        seatsToAdd.Add(new Seat
                        {
                            RowSeat = rowLetter.ToString(),
                            ColumnSeat = c.ToString(),
                            TypeSeat = defaultType,
                            PriceSeat = price,
                            RoomId = roomId
                        });
                    }
                }
                else
                {
                    // ===== HÀNG GHẾ ĐÔI =====
                    int totalDoubleCols = doubleSeatPerRow * 2;
                    int normalCols = colCount - totalDoubleCols;

                    int c = 1;

                    // phần ghế thường ở đầu hàng
                    for (; c <= normalCols; c++)
                    {
                        seatsToAdd.Add(new Seat
                        {
                            RowSeat = rowLetter.ToString(),
                            ColumnSeat = c.ToString(),
                            TypeSeat = defaultType,
                            PriceSeat = price,
                            RoomId = roomId
                        });
                    }

                    // phần ghế đôi ở cuối hàng
                    for (int i = 0; i < doubleSeatPerRow; i++)
                    {
                        int startCol = normalCols + 1 + i * 2;
                        int endCol = startCol + 1;

                        seatsToAdd.Add(new Seat
                        {
                            RowSeat = rowLetter.ToString(),
                            ColumnSeat = $"{startCol}-{endCol}",
                            TypeSeat = "Đôi",
                            PriceSeat = price * 2,
                            RoomId = roomId
                        });
                    }
                }
            }

            using (var db = new CinemaDbContext())
            {
                if (db.Seats.Any(s => s.RoomId == roomId))
                {
                    var confirm = MessageBox.Show("Phòng này đã có ghế. Bạn có muốn ghi đè?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.No) return;

                    db.Seats.RemoveRange(db.Seats.Where(s => s.RoomId == roomId));
                    db.SaveChanges();
                }

                db.Seats.AddRange(seatsToAdd);
                db.SaveChanges();
            }

            MessageBox.Show($"Đã tạo {seatsToAdd.Count} ghế cho phòng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSeats(roomId);
        }


        // 🧹 Thêm nút XÓA GHẾ riêng
        private void btnDeleteSeats_Click(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa ghế!");
                return;
            }

            int roomId = (int)cmbRoom.SelectedValue;

            using (var db = new CinemaDbContext())
            {
                var seatsToDelete = db.Seats.Where(s => s.RoomId == roomId).ToList();

                if (!seatsToDelete.Any())
                {
                    MessageBox.Show("Phòng này chưa có ghế nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa toàn bộ {seatsToDelete.Count} ghế trong phòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    db.Seats.RemoveRange(seatsToDelete);
                    db.SaveChanges();

                    MessageBox.Show($"🗑️ Đã xóa toàn bộ {seatsToDelete.Count} ghế trong phòng {roomId}.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSeats(roomId);
                }
            }
        }



        private void LoadSeats(int roomId)
        {
            using (var db = new CinemaDbContext())
            {
                var list = db.Seats
                    .Where(s => s.RoomId == roomId)
                    .Select(s => new
                    {
                        s.SeatId,
                        SeatName = s.RowSeat + s.ColumnSeat,
                        s.TypeSeat,
                        s.PriceSeat
                    })
                    .OrderBy(s => s.SeatName)
                    .ToList();

                dgvSeats.DataSource = list;
                dgvSeats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


    }
}
