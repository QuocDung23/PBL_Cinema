using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            managementForm.ShowDialog();  
            LoadMovies();  
        }
    }
}
