using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using cinema_system.AD;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.nhân_viên
{
    public partial class StaffDesign : Form
    {
        private int CurrentUserId;
        private int CurrentRoleId;
        private string CurrentUserName;

        public StaffDesign(int userId, int roleId, string userName)
        {
            InitializeComponent();
            LoadMovies();
            CurrentUserId = userId;
            CurrentRoleId = roleId;
            CurrentUserName = userName;

            this.Text = $"Nhân viên - {userName}";
            this.BackColor = Color.FromArgb(40, 40, 40);

            ApplyRolePermissions();
        }

        private List<Movie> GetMoviesFromDb()
        {
            try
            {
                using (var db = new CinemaDbContext())
                {
                    Debug.WriteLine($"Chuỗi kết nối: {db.Database.GetDbConnection().ConnectionString}");

                    var movies = db.Movies.AsNoTracking()
                        .OrderByDescending(m => m.MovieId)
                        .ToList();

                    foreach (var movie in movies)
                    {
                        Debug.WriteLine($"Phim: {movie.NameMovie}, PosterURL: {movie.PosterURL}");
                    }

                    return movies;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi truy vấn dữ liệu: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Movie>();
            }
        }

        private void LoadMovies()
        {
            moviePanel.Controls.Clear();
            List<Movie> movies = GetMoviesFromDb();

            bool hasShownError = false;
            const string BASE_ASSET_PATH = @"C:\Users\admin\Pictures\cinema";

            if (!Directory.Exists(BASE_ASSET_PATH))
            {
                Directory.CreateDirectory(BASE_ASSET_PATH);
            }

            foreach (var movie in movies)
            {
                string fileName = movie.PosterURL;
                string imgdbPath = Path.Combine(BASE_ASSET_PATH, fileName ?? "");

                Panel movieCard = new Panel
                {
                    Size = new Size(150, 220),
                    BackColor = Color.FromArgb(60, 60, 60),
                    Margin = new Padding(10),
                    Tag = movie,
                    Cursor = Cursors.Hand
                };

                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top,
                    Height = 170,
                    BackColor = Color.Black
                };

                Image image = null;

                if (!string.IsNullOrEmpty(fileName) && File.Exists(imgdbPath))
                {
                    try
                    {
                        using (var stream = new FileStream(imgdbPath, FileMode.Open, FileAccess.Read))
                        {
                            image = new Bitmap(Image.FromStream(stream));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!hasShownError)
                        {
                            MessageBox.Show($"Lỗi tải ảnh cho '{movie.NameMovie}': {ex.Message}", "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasShownError = true;
                        }
                    }
                }

                if (image != null)
                {
                    pb.Image = image;
                }
                else
                {
                    pb.Image = new Bitmap(pb.Width, pb.Height);
                    using (Graphics g = Graphics.FromImage(pb.Image))
                    {
                        g.FillRectangle(Brushes.DarkGray, 0, 0, pb.Width, pb.Height);
                        g.DrawString("NO POSTER", new Font("Arial", 12), Brushes.White, new Point(10, 70));
                    }
                }

                Label lbl = new Label
                {
                    Text = movie.NameMovie,
                    Dock = DockStyle.Bottom,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White,
                    Height = 30
                };

                movieCard.Click += MovieCard_Click;
                pb.Click += MovieCard_Click;
                lbl.Click += MovieCard_Click;

                movieCard.Controls.Add(lbl);
                movieCard.Controls.Add(pb);
                moviePanel.Controls.Add(movieCard);
            }
        }

        private void MovieCard_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            Panel movieCardPanel = clickedControl as Panel ?? clickedControl.Parent as Panel;

            if (movieCardPanel != null && movieCardPanel.Tag is Movie selectedMovie)
            {
                int staffId = this.CurrentUserId;
                MovieDetail detailForm = new MovieDetail(selectedMovie, staffId);
                this.Hide();
                detailForm.ShowDialog();
                this.Show();
            }
        }

        private void btnQuanLyPhim_Click(object sender, EventArgs e)
        {
            MovieManagementForm managementForm = new MovieManagementForm();
            this.Hide();
            managementForm.ShowDialog();  
            LoadMovies();
            this.Show();
        }

        private void btnShowTime_Click(object sender, EventArgs e)
        {
            RoomManagementForm roomManagementForm = new RoomManagementForm();
            this.Hide();
            roomManagementForm.ShowDialog();
            LoadMovies();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTimeManagementForm showTimeManagementForm = new ShowTimeManagementForm();
            this.Hide();
            showTimeManagementForm.ShowDialog();
            LoadMovies();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeatManagementForm seatManagementForm = new SeatManagementForm();
            this.Hide();
            seatManagementForm.ShowDialog();
            LoadMovies();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStaffForm addStaffForm = new AddStaffForm();
            this.Hide();
            addStaffForm.ShowDialog();
            LoadMovies();
            this.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // 1. Tạo thể hiện của Form Lịch sử Vé
            TicketHistoryForm ticketHistoryForm = new TicketHistoryForm();
            this.Hide();
            ticketHistoryForm.ShowDialog();
            this.Show();
            LoadMovies();
        }
        private void ApplyRolePermissions()
        {
            // Giả sử RoleId = 1 là Admin, còn lại là nhân viên
            bool isAdmin = CurrentRoleId == 1;

            // Nếu không phải admin => disable các chức năng quản lý
            btnQuanLyPhim.Enabled = isAdmin;
            btnShowTime.Enabled = isAdmin;
            button1.Enabled = isAdmin; // ShowTimeManagement
            button2.Enabled = isAdmin; // SeatManagement
            button3.Enabled = isAdmin; // AddStaffForm

            if (!isAdmin)
            {
                // Cho giao diện dễ hiểu hơn — làm mờ nút
                btnQuanLyPhim.BackColor = Color.Gray;
                btnShowTime.BackColor = Color.Gray;
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;

                // Thêm tooltip cho biết lý do bị khóa
                ToolTip tip = new ToolTip();
                tip.SetToolTip(btnQuanLyPhim, "Chỉ quản trị viên mới có thể sử dụng chức năng này");
                tip.SetToolTip(btnShowTime, "Chỉ quản trị viên mới có thể sử dụng chức năng này");
                tip.SetToolTip(button1, "Chỉ quản trị viên mới có thể sử dụng chức năng này");
                tip.SetToolTip(button2, "Chỉ quản trị viên mới có thể sử dụng chức năng này");
                tip.SetToolTip(button3, "Chỉ quản trị viên mới có thể sử dụng chức năng này");
            }
        }
    }
}
