using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using cinema_system.Models;
using cinema_system.nhân_viên;
using Microsoft.EntityFrameworkCore;

namespace cinema_system
{
    public partial class MovieDetail : Form
    {
        private Movie _selectedMovie;
        private int _staffId;
        private FlowLayoutPanel flpShowtimes;


        public MovieDetail(Movie movie, int staffId)
        {
            InitializeComponent();
            _selectedMovie = movie;
            _staffId = staffId;

            this.Text = $"Chi tiết Phim: {movie.NameMovie}";

            LoadMovieDetailAndShowtimes();
        }

        public MovieDetail()
        {
            InitializeComponent();
        }

        private void LoadMovieDetailAndShowtimes()
        {
            this.Text = $"Chi tiết phim: {_selectedMovie.NameMovie}";
            LoadPoster(_selectedMovie.PosterURL);

            lblTitle.Text = _selectedMovie.NameMovie;

            lblDetail.Text =
        $"Nhà sản xuất: {_selectedMovie.Director ?? "Đang cập nhật"}\n" +
        $"Đạo diễn: {_selectedMovie.Director ?? "Đang cập nhật"}\n" +
        $"Thể loại: {_selectedMovie.GenreMovie ?? "Hành động, Lịch sử"}\n" +
        $"Thời lượng phim: {_selectedMovie.DurationMovie} phút";

            lblDes.Text = _selectedMovie.DescriptionMovie ?? "Nội dung đang được cập nhật";
                
                // 2. Load suất chiếu cho ngày hôm nay
            LoadShowtimesForMovie(DateTime.Today, _selectedMovie.MovieId);
        }

        private void LoadPoster(string fileName)
        {
            const string BASE_ASSET_PATH = @"C:\Users\admin\Pictures\cinema";

            PictureBox pb = this.Controls.Find("picPosterDetail",true).FirstOrDefault() as PictureBox;
            if (pb == null) return;
            string imgPath = Path.Combine(BASE_ASSET_PATH, fileName ?? "");

            if(!String.IsNullOrWhiteSpace(fileName) && File.Exists(imgPath))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imgPath);
                    using(MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pb.Image = Image.FromStream(ms);
                    }
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                } catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Lỗi tải ảnh chi tiết: {ex.Message}");
                }
            }else
            {
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void LoadShowtimesForMovie(DateTime date, int movieId)
        {
            // Tìm FlowLayoutPanel
            FlowLayoutPanel flpShowtimes = Controls.Find("flpShowtimes", true).FirstOrDefault() as FlowLayoutPanel;

            if (flpShowtimes == null) return;
            flpShowtimes.Controls.Clear();

            try
            {
                using (var context = new CinemaDbContext())
                {
                    var showtimes = context.ShowTimes
                        .Include(st => st.Room)
                        .Where(st => st.MovieId == movieId) 
                        .OrderBy(st => st.StartTime)
                        .ToList();

                    if (!showtimes.Any())
                    {
                        flpShowtimes.Controls.Add(new Label { Text = "Không có suất chiếu nào được đặt cho phim này.", ForeColor = Color.Red, AutoSize = true });
                        return;
                    }

                    // SINH UI: Tạo Button cho mỗi suất chiếu
                    foreach (var showtime in showtimes)
                    {
                        Button btn = new Button();

                        // Nội dung nút: Hiển thị Ngày và Giờ (để người dùng biết suất chiếu nào)
                        btn.Text = $"{showtime.StartTime:dd/MM HH:mm}\n{showtime.Room.NameRoom}";

                        btn.Tag = showtime.ShowTimeId;
                        btn.Width = 120;
                        btn.Height = 60;
                        btn.Margin = new Padding(5,5,5,5);
                        btn.BackColor = Color.White;
                        btn.Click += ShowtimeButton_Click; // Gắn sự kiện đặt vé

                        flpShowtimes.Controls.Add(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch chiếu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowtimeButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Tag is int showtimeId)
            {
                int staffId = this._staffId;

                BookingSeat bookingForm = new BookingSeat(showtimeId, staffId);

                this.Hide();
                bookingForm.ShowDialog();
                this.Close();
            }
        }
    }
}