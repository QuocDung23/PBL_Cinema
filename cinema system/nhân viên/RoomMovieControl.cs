using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    public partial class RoomMovieControl : UserControl
    {
        string connectionString = @"Data Source=shanley\sqlexpress;Initial Catalog=movie;Integrated Security=True;Encrypt=False";
        public RoomMovieControl()
        {
            InitializeComponent();
            LoadRooms();
            LoadMovies();
            LoadRoomMovies();
        }

        private void LoadRooms()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT RoomID, RoomName FROM Rooms", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbRoom.DataSource = dt;
                cbRoom.DisplayMember = "RoomName";
                cbRoom.ValueMember = "RoomID";
            }
        }

        private void LoadMovies()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT MovieID, MovieName FROM Movies", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbMovie.DataSource = dt;
                cbMovie.DisplayMember = "MovieName";
                cbMovie.ValueMember = "MovieID";
            }
        }

        private void LoadRoomMovies()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT r.RoomName, m.MovieName 
                                 FROM RoomMovies rm
                                 JOIN Rooms r ON rm.RoomID = r.RoomID
                                 JOIN Movies m ON rm.MovieID = m.MovieID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRoomMovies.DataSource = dt;
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cbRoom.SelectedValue == null || cbMovie.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng và phim!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(cbRoom.SelectedValue);
            int movieId = Convert.ToInt32(cbMovie.SelectedValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra xem phòng này đã có phim gán chưa
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM RoomMovies WHERE RoomID=@RoomID AND MovieID=@MovieID", conn);
                checkCmd.Parameters.AddWithValue("@RoomID", roomId);
                checkCmd.Parameters.AddWithValue("@MovieID", movieId);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Phòng này đã có phim này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO RoomMovies (RoomID, MovieID) VALUES (@RoomID, @MovieID)", conn);
                insertCmd.Parameters.AddWithValue("@RoomID", roomId);
                insertCmd.Parameters.AddWithValue("@MovieID", movieId);
                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã gán phim cho phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRoomMovies();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (dgvRoomMovies.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRoom.SelectedValue == null || cbMovie.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng và phim mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(cbRoom.SelectedValue);
            int movieId = Convert.ToInt32(cbMovie.SelectedValue);

            // Lấy RoomName từ dòng đang chọn
            string selectedRoomName = dgvRoomMovies.CurrentRow.Cells["RoomName"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy RoomID từ tên phòng (hoặc bạn có thể thêm cột ẩn RoomID vào grid)
                SqlCommand getRoomCmd = new SqlCommand("SELECT RoomID FROM Rooms WHERE RoomName=@RoomName", conn);
                getRoomCmd.Parameters.AddWithValue("@RoomName", selectedRoomName);
                int selectedRoomId = (int)getRoomCmd.ExecuteScalar();

                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE RoomMovies SET MovieID=@MovieID WHERE RoomID=@RoomID", conn);
                updateCmd.Parameters.AddWithValue("@RoomID", selectedRoomId);
                updateCmd.Parameters.AddWithValue("@MovieID", movieId);
                updateCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật phim trong phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRoomMovies();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvRoomMovies.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedRoomName = dgvRoomMovies.CurrentRow.Cells["RoomName"].Value.ToString();
            string selectedMovieName = dgvRoomMovies.CurrentRow.Cells["MovieName"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa phim '{selectedMovieName}' khỏi phòng '{selectedRoomName}'?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand deleteCmd = new SqlCommand(
                        @"DELETE FROM RoomMovies
                  WHERE RoomID = (SELECT RoomID FROM Rooms WHERE RoomName=@RoomName)
                  AND MovieID = (SELECT MovieID FROM Movies WHERE MovieName=@MovieName)", conn);

                    deleteCmd.Parameters.AddWithValue("@RoomName", selectedRoomName);
                    deleteCmd.Parameters.AddWithValue("@MovieName", selectedMovieName);
                    deleteCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoomMovies();
            }
        }
    }
}
