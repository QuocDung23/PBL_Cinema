using System;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.AD
{
    public partial class ShowTimeManagementForm : Form
    {
        private ShowTime _currentShowTime;
        private bool _isEditing = false;

        public ShowTimeManagementForm()
        {
            InitializeComponent();
            LoadMovies();
            LoadRooms();
            LoadShowTimes();
        }

        // =================== LOAD DỮ LIỆU ===================
        private void LoadShowTimes()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    var showTimesList = db.ShowTimes
                        .Include(st => st.Movie)
                        .Include(st => st.Room)
                        .Select(st => new
                        {
                            st.ShowTimeId,
                            MovieName = st.Movie.NameMovie,
                            RoomName = st.Room.NameRoom,
                            StartTime = st.StartTime,
                            EndTime = st.EndTime
                        })
                        .OrderBy(st => st.StartTime)
                        .ToList();

                    dgvShowTimes.DataSource = null;
                    dgvShowTimes.DataSource = showTimesList;
                    dgvShowTimes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvShowTimes.ReadOnly = true;
                    dgvShowTimes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Ẩn ID
                    if (dgvShowTimes.Columns["ShowTimeId"] != null)
                        dgvShowTimes.Columns["ShowTimeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách suất chiếu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMovies()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    var movies = db.Movies.ToList();
                    cmbMovie.DataSource = movies;
                    cmbMovie.DisplayMember = "NameMovie";
                    cmbMovie.ValueMember = "MovieId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phim: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    var rooms = db.Rooms.ToList();
                    cmbRoom.DataSource = rooms;
                    cmbRoom.DisplayMember = "NameRoom";
                    cmbRoom.ValueMember = "RoomId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phòng: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =================== XỬ LÝ FORM ===================
        private void ClearFields()
        {
            cmbMovie.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            dtpStartTime.Value = DateTime.Now;
        }

        private void LoadSelectedShowTimeToFields()
        {
            if (dgvShowTimes.SelectedRows.Count == 0) return;

            var selectedRow = dgvShowTimes.SelectedRows[0];
            int? id = selectedRow.Cells["ShowTimeId"]?.Value as int?;

            if (id == null) return;

            using (var db = new CinemaDbContext())
            {
                _currentShowTime = db.ShowTimes
                    .Include(st => st.Movie)
                    .Include(st => st.Room)
                    .FirstOrDefault(st => st.ShowTimeId == id);
                if (_currentShowTime == null) return;

                cmbMovie.SelectedValue = _currentShowTime.MovieId;
                cmbRoom.SelectedValue = _currentShowTime.RoomId;
                dtpStartTime.Value = _currentShowTime.StartTime;
            }
        }

        // =================== NÚT XỬ LÝ ===================
        private void btnAddShowTime_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            _currentShowTime = new ShowTime();
            ClearFields();
        }

        private void btnEditShowTime_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra lựa chọn
            if (dgvShowTimes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID của suất chiếu đang chọn từ DataGridView
            var selectedRow = dgvShowTimes.SelectedRows[0];
            int? id = selectedRow.Cells["ShowTimeId"]?.Value as int?;

            if (id == null)
            {
                MessageBox.Show("Không thể xác định ID suất chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new CinemaDbContext())
                {
                    // Lấy đối tượng ShowTime hiện tại từ DB để EF theo dõi và cập nhật
                    var showtimeToUpdate = db.ShowTimes
                                             .Include(st => st.Movie)
                                             .FirstOrDefault(st => st.ShowTimeId == id);

                    if (showtimeToUpdate == null)
                    {
                        MessageBox.Show("Không tìm thấy suất chiếu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy giá trị hiện tại (đã được người dùng chỉnh sửa) từ controls
                    int movieId = (int)cmbMovie.SelectedValue;
                    int roomId = (int)cmbRoom.SelectedValue;
                    DateTime startTime = dtpStartTime.Value;

                    // Lấy duration từ phim
                    var selectedMovie = db.Movies.FirstOrDefault(m => m.MovieId == movieId);
                    if (selectedMovie == null)
                    {
                        MessageBox.Show("Phim không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime endTime = startTime.AddMinutes(selectedMovie.DurationMovie);

                    // =================== KIỂM TRA TRÙNG LỊCH (LOẠI TRỪ SUẤT CHIẾU ĐANG SỬA) ===================
                    var overlap = db.ShowTimes
                        .Where(st => st.ShowTimeId != showtimeToUpdate.ShowTimeId && // QUAN TRỌNG: Loại trừ suất chiếu này
                                     st.RoomId == roomId &&
                                     ((startTime >= st.StartTime && startTime < st.EndTime) ||
                                      (endTime > st.StartTime && endTime <= st.EndTime) ||
                                      (startTime <= st.StartTime && endTime >= st.EndTime)))
                        .Any();

                    if (overlap)
                    {
                        MessageBox.Show("Phòng này đã có suất chiếu trùng thời gian!", "Lỗi trùng suất", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // =================== CẬP NHẬT VÀ LƯU DỮ LIỆU ===================
                    showtimeToUpdate.MovieId = movieId;
                    showtimeToUpdate.RoomId = roomId;
                    showtimeToUpdate.StartTime = startTime;
                    showtimeToUpdate.EndTime = endTime;

                    db.SaveChanges();
                    LoadShowTimes(); // Tải lại DataGridView
                    ClearFields(); // Xóa sạch các trường

                    MessageBox.Show("Sửa suất chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa suất chiếu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveShowTime_Click(object sender, EventArgs e)
        {
            // Đây là nút THÊM MỚI.

            if (cmbMovie.SelectedValue == null || cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new CinemaDbContext())
                {
                    int movieId = (int)cmbMovie.SelectedValue;
                    int roomId = (int)cmbRoom.SelectedValue;
                    DateTime startTime = dtpStartTime.Value;

                    // Lấy duration từ phim
                    var selectedMovie = db.Movies.FirstOrDefault(m => m.MovieId == movieId);
                    if (selectedMovie == null)
                    {
                        MessageBox.Show("Phim không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DateTime endTime = startTime.AddMinutes(selectedMovie.DurationMovie);

                    // =================== KIỂM TRA TRÙNG PHÒNG / GIỜ ===================
                    // Kiểm tra xem có bất kỳ suất chiếu nào trùng lịch với suất mới không
                    var overlap = db.ShowTimes
                        .Where(st => st.RoomId == roomId &&
                                     ((startTime >= st.StartTime && startTime < st.EndTime) ||
                                      (endTime > st.StartTime && endTime <= st.EndTime) ||
                                      (startTime <= st.StartTime && endTime >= st.EndTime)))
                        .Any();

                    if (overlap)
                    {
                        MessageBox.Show("Phòng này đã có suất chiếu trùng thời gian!", "Lỗi trùng suất", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // =================== LƯU DỮ LIỆU (THÊM MỚI) ===================
                    var newShowtime = new ShowTime
                    {
                        MovieId = movieId,
                        RoomId = roomId,
                        StartTime = startTime,
                        EndTime = endTime
                    };
                    db.ShowTimes.Add(newShowtime);

                    db.SaveChanges();
                    LoadShowTimes();
                    ClearFields();

                    MessageBox.Show("Thêm suất chiếu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu suất chiếu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteShowTime_Click(object sender, EventArgs e)
        {
            if (dgvShowTimes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvShowTimes.SelectedRows[0];
            int? id = selectedRow.Cells["ShowTimeId"]?.Value as int?;

            if (id == null) return;

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa suất chiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var db = new CinemaDbContext())
                {
                    var showtime = db.ShowTimes.FirstOrDefault(st => st.ShowTimeId == id);
                    if (showtime == null)
                    {
                        MessageBox.Show("Không tìm thấy suất chiếu để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    db.ShowTimes.Remove(showtime);
                    db.SaveChanges();
                    LoadShowTimes();
                    ClearFields();
                    MessageBox.Show("Đã xóa suất chiếu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa suất chiếu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchShowTime_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchShowTime.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadShowTimes();
                return;
            }

            try
            {
                using (var db = new CinemaDbContext())
                {
                    var showTimesList = db.ShowTimes
                        .Include(st => st.Movie)
                        .Include(st => st.Room)
                        .Where(st => EF.Functions.Like(st.Movie.NameMovie, $"%{searchText}%"))
                        .Select(st => new
                        {
                            st.ShowTimeId,
                            MovieName = st.Movie.NameMovie,
                            RoomName = st.Room.NameRoom,
                            StartTime = st.StartTime,
                            EndTime = st.EndTime
                        })
                        .ToList();

                    dgvShowTimes.DataSource = null;
                    dgvShowTimes.DataSource = showTimesList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvShowTimes_SelectionChanged(object sender, EventArgs e)
        {
            // Bỏ qua check if (!_isEditing) và gọi hàm load để nó hiển thị dữ liệu mới lên controls
            if (dgvShowTimes.SelectedRows.Count > 0)
                LoadSelectedShowTimeToFields();
        }

        private void dgvShowTimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                LoadSelectedShowTimeToFields();
        }
    }
}