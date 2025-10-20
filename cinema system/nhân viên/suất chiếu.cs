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
    public partial class ThemMovie : UserControl
    {
        string connectionString = @"Data Source=shanley\sqlexpress;Initial Catalog=movie;Integrated Security=True;Encrypt=False";
        private int selectedShowtimeID = -1;
        public ThemMovie()
        {
            InitializeComponent();
        }

        private void FormAddShowtime_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadShowtimes();
        }

        // 🔹 Chỉ load phim có sẵn trong database
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

        // 🔹 Hiển thị danh sách suất chiếu
        private void LoadShowtimes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT s.ShowtimeID, m.MovieName, s.ShowDate, s.ShowTime " +
                    "FROM Showtimes s JOIN Movies m ON s.MovieID = m.MovieID " +
                    "ORDER BY s.ShowDate DESC, s.ShowTime ASC", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShowtimes.DataSource = dt;
            }
        }

        // 🔹 Thêm suất chiếu mới cho phim đã có
        private void btnAddShowtime_Click(object sender, EventArgs e)
        {
            if (cbMovie.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phim từ danh sách có sẵn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int movieId = Convert.ToInt32(cbMovie.SelectedValue);
            DateTime showDate = dtpDate.Value.Date;
            TimeSpan showTime = dtpTime.Value.TimeOfDay;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Kiểm tra xem suất chiếu này có trùng không
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Showtimes WHERE MovieID=@MovieID AND ShowDate=@ShowDate AND ShowTime=@ShowTime", conn);
                checkCmd.Parameters.AddWithValue("@MovieID", movieId);
                checkCmd.Parameters.AddWithValue("@ShowDate", showDate);
                checkCmd.Parameters.AddWithValue("@ShowTime", showTime);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Suất chiếu này đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Thêm suất chiếu mới
                SqlCommand insertCmd = new SqlCommand(
                    "INSERT INTO Showtimes (MovieID, ShowDate, ShowTime) VALUES (@MovieID, @ShowDate, @ShowTime)", conn);
                insertCmd.Parameters.AddWithValue("@MovieID", movieId);
                insertCmd.Parameters.AddWithValue("@ShowDate", showDate);
                insertCmd.Parameters.AddWithValue("@ShowTime", showTime);
                insertCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Thêm suất chiếu thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadShowtimes();
        }

        private void dgvShowtimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvShowtimes.Rows[e.RowIndex];
                selectedShowtimeID = Convert.ToInt32(row.Cells["ShowtimeID"].Value);

                cbMovie.Text = row.Cells["MovieName"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(row.Cells["ShowDate"].Value);
                dtpTime.Value = DateTime.Today.Add((TimeSpan)row.Cells["ShowTime"].Value);
            }
        }
        private void btnDelShowtime_Click(object sender, EventArgs e)
        {
            if (selectedShowtimeID == -1)
            {
                MessageBox.Show("Hãy chọn một suất chiếu để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa suất chiếu này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Showtimes WHERE ShowtimeID=@ID", conn);
                    cmd.Parameters.AddWithValue("@ID", selectedShowtimeID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa thành công!");
                LoadShowtimes();
                selectedShowtimeID = -1;
            }
        }

        private void btnChangeShowtime_Click(object sender, EventArgs e)
        {
            if (selectedShowtimeID == -1)
            {
                MessageBox.Show("Hãy chọn một suất chiếu để sửa.");
                return;
            }

            int movieId = Convert.ToInt32(cbMovie.SelectedValue);
            DateTime showDate = dtpDate.Value.Date;
            TimeSpan showTime = dtpTime.Value.TimeOfDay;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Showtimes SET MovieID=@MovieID, ShowDate=@ShowDate, ShowTime=@ShowTime WHERE ShowtimeID=@ID", conn);
                cmd.Parameters.AddWithValue("@MovieID", movieId);
                cmd.Parameters.AddWithValue("@ShowDate", showDate);
                cmd.Parameters.AddWithValue("@ShowTime", showTime);
                cmd.Parameters.AddWithValue("@ID", selectedShowtimeID);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Sửa thành công!");
            LoadShowtimes();
        }
    }
}
