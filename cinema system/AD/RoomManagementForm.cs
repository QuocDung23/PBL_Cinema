using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.AD
{
    public partial class RoomManagementForm : Form
    {
        private Room _currentRoom;  // Room đang edit/add
        private bool _isEditing = false;  // Trạng thái edit hay add

        public RoomManagementForm()
        {
            InitializeComponent();
            _currentRoom = new Room();  // Mặc định cho add
            LoadRooms();
            LoadRoomTypes();  // Load options cho ComboBox

            // ✅ Fix: Đảm bảo grid có thể chọn khi click
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.MultiSelect = false;
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.RowHeadersVisible = false;  // Ẩn header row nếu không cần
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void LoadRooms()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    // Kiểm tra connection và dữ liệu null
                    if (db.Rooms == null)
                    {
                        MessageBox.Show("DbSet Rooms chưa được khởi tạo. Kiểm tra DbContext.", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Sử dụng projection để tránh NULL values khi bind (tạo anonymous type với defaults)
                    var roomsList = db.Rooms
                        .Where(r => r.IsActive == true)  // Chỉ load active rooms
                        .Select(r => new  // Projection để handle NULL
                        {
                            RoomId = r.RoomId,
                            NameRoom = r.NameRoom ?? "Chưa đặt tên",  // Default nếu NULL
                            TotalSeat = r.TotalSeat > 0 ? r.TotalSeat : 100,  // Default nếu 0 hoặc NULL
                            TypeRoom = r.TypeRoom ?? "2D",  // Default nếu NULL
                            IsActive = r.IsActive  // Giữ nguyên
                        })
                        .ToList();

                    // Bind DataSource và refresh grid (không cần check null vì ToList() luôn trả list)
                    dgvRooms.DataSource = null;  // Clear trước để tránh cache cũ
                    dgvRooms.DataSource = roomsList;
                    dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRooms.ReadOnly = true;
                    dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvRooms.Refresh();  // Force refresh để hiển thị data mới
                    dgvRooms.Update();   // Thêm Update để đảm bảo UI sync
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phòng: {ex.Message}\nKiểm tra connection string và migration. Có thể do NULL values trong DB - chạy migration để set defaults.", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomTypes()
        {
            // Chỉ 2 loại: 2D và 3D
            var types = new List<string> { "2D", "3D" };
            cmbTypeRoom.DataSource = types;
            cmbTypeRoom.DropDownStyle = ComboBoxStyle.DropDownList;  // Không cho nhập tự do
        }

        private void ClearFields()
        {
            txtNameRoom.Clear();
            numTotalSeat.Value = 100;
            cmbTypeRoom.SelectedIndex = 0;  // Mặc định "2D"
        }

        private void LoadSelectedRoomToFields()
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                // Lấy ID từ grid (vì grid dùng projection)
                if (dgvRooms.SelectedRows[0].Cells["RoomId"]?.Value is int selectedId)
                {
                    using (var db = new CinemaDbContext())
                    {
                        _currentRoom = db.Rooms.FirstOrDefault(r => r.RoomId == selectedId && r.IsActive == true);
                        if (_currentRoom != null)
                        {
                            txtNameRoom.Text = _currentRoom.NameRoom ?? "";
                            numTotalSeat.Value = _currentRoom.TotalSeat > 0 ? _currentRoom.TotalSeat : 100;

                            // Set ComboBox theo TypeRoom (chỉ 2 lựa chọn)
                            if (!string.IsNullOrEmpty(_currentRoom.TypeRoom) && (cmbTypeRoom.Items.Contains(_currentRoom.TypeRoom)))
                            {
                                cmbTypeRoom.SelectedItem = _currentRoom.TypeRoom;
                            }
                            else
                            {
                                cmbTypeRoom.SelectedIndex = 0;  // Mặc định "2D" nếu không khớp
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy phòng để load dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không lấy được ID phòng từ grid.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearFields();
            txtNameRoom.Focus();
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditing = true;
            LoadSelectedRoomToFields();
            txtNameRoom.Focus();
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameRoom.Text))
            {
                MessageBox.Show("Tên phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameRoom.Focus();
                return;
            }

            if (cmbTypeRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTypeRoom.Focus();
                return;
            }

            if (_isEditing && _currentRoom == null)
            {
                MessageBox.Show("Không có phòng được chọn để sửa. Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new CinemaDbContext())
            {
                try
                {
                    if (!_isEditing)
                    {
                        // Kiểm tra trùng tên phòng (chỉ kiểm tra active rooms)
                        var existingRoom = db.Rooms.FirstOrDefault(r => r.NameRoom.Trim().ToLower() == txtNameRoom.Text.Trim().ToLower() && r.IsActive == true);
                        if (existingRoom != null)
                        {
                            MessageBox.Show("Trùng tên phòng! Không thể thêm phòng có tên trùng lặp.", "Lỗi trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNameRoom.Focus();
                            return;
                        }

                        // Add new - INSERT
                        _currentRoom = new Room
                        {
                            NameRoom = txtNameRoom.Text.Trim(),
                            TotalSeat = (int)numTotalSeat.Value,
                            TypeRoom = cmbTypeRoom.SelectedItem.ToString(),
                            IsActive = true  // Mặc định active khi add mới
                        };
                        db.Rooms.Add(_currentRoom);
                        db.SaveChanges();  // Lưu ngay để có ID nếu cần
                    }
                    else
                    {
                        // Edit existing - UPDATE
                        // Kiểm tra trùng tên với phòng khác (không tính chính nó)
                        var existingRoom = db.Rooms.FirstOrDefault(r => r.NameRoom.Trim().ToLower() == txtNameRoom.Text.Trim().ToLower() && r.IsActive == true && r.RoomId != _currentRoom.RoomId);
                        if (existingRoom != null)
                        {
                            MessageBox.Show("Trùng tên phòng với phòng khác! Không thể sửa thành tên trùng lặp.", "Lỗi trùng tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNameRoom.Focus();
                            return;
                        }

                        // Update ngay lập tức
                        db.Rooms.Attach(_currentRoom);
                        db.Entry(_currentRoom).State = EntityState.Modified;
                        _currentRoom.NameRoom = txtNameRoom.Text.Trim();
                        _currentRoom.TotalSeat = (int)numTotalSeat.Value;
                        _currentRoom.TypeRoom = cmbTypeRoom.SelectedItem.ToString();
                        _currentRoom.IsActive = true;  // Giữ active khi edit
                        db.SaveChanges();  // Lưu ngay để update data
                    }

                    LoadRooms();  // Reload và refresh grid
                    ClearFields();
                    _isEditing = false;
                    MessageBox.Show("Lưu phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi lưu phòng: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID từ grid (vì grid dùng projection, không cast trực tiếp)
            if (dgvRooms.SelectedRows[0].Cells["RoomId"]?.Value is int selectedId)
            {
                using (var db = new CinemaDbContext())
                {
                    var selectedRoom = db.Rooms.FirstOrDefault(r => r.RoomId == selectedId && r.IsActive == true);
                    if (selectedRoom != null)
                    {
                        var result = MessageBox.Show($"Bạn có chắc muốn xóa phòng '{selectedRoom.NameRoom}'? (Xóa mềm - có thể khôi phục)", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                // Soft delete: Chỉ set IsActive = false
                                selectedRoom.IsActive = false;
                                db.Entry(selectedRoom).State = EntityState.Modified;
                                db.SaveChanges();
                                LoadRooms();  // Reload để loại bỏ khỏi grid
                                ClearFields();
                                MessageBox.Show("Xóa phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi xóa phòng: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không lấy được ID phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchRoom.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadRooms();
                return;
            }

            try
            {
                using (var db = new CinemaDbContext())
                {
                    // Projection cho search để tránh NULL
                    var roomsList = db.Rooms
                        .Where(r => r.NameRoom.Contains(searchText) && r.IsActive == true)
                        .Select(r => new
                        {
                            RoomId = r.RoomId,
                            NameRoom = r.NameRoom ?? "Chưa đặt tên",
                            TotalSeat = r.TotalSeat > 0 ? r.TotalSeat : 100,
                            TypeRoom = r.TypeRoom ?? "2D",
                            IsActive = r.IsActive
                        })
                        .ToList();

                    dgvRooms.DataSource = null;  // Clear trước
                    dgvRooms.DataSource = roomsList;
                    dgvRooms.Refresh();  // Force refresh
                    dgvRooms.Update();   // Sync UI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                LoadSelectedRoomToFields();
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvRooms.ClearSelection();
                dgvRooms.Rows[e.RowIndex].Selected = true;
                LoadSelectedRoomToFields();  // Load data khi click row
            }
        }
    }
}