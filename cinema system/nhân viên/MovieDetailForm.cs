using cinema_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    public partial class MovieDetailForm : Form
    {
        private Movie selectedMovie;

        public MovieDetailForm(Movie movie)
        {
            InitializeComponent();
            selectedMovie = movie;
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            // Thiết lập tiêu đề form
            this.Text = $"Chi tiết phim: {selectedMovie.NameMovie}";
            this.Size = new Size(400, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(40, 40, 40); // Nền tối như StaffDesign

            // Tạo controls để hiển thị thông tin
            int yPosition = 20;
            AddLabel("Tên phim:", selectedMovie.NameMovie, ref yPosition);
            AddLabel("Thể loại:", selectedMovie.GenreMovie ?? "Chưa có", ref yPosition);
            AddLabel("Mô tả:", selectedMovie.DescriptionMovie ?? "Chưa có", ref yPosition);
            AddLabel("Thời lượng:", $"{selectedMovie.DurationMovie} phút", ref yPosition);
            AddLabel("Ngày phát hành:", selectedMovie.ReleaseDateMovie?.ToString("dd/MM/yyyy") ?? "Chưa có", ref yPosition);
            AddLabel("Poster URL:", selectedMovie.PosterURL ?? "Chưa có", ref yPosition);
            AddLabel("ID phim:", selectedMovie.MovieId.ToString(), ref yPosition);
        }

        private void AddLabel(string labelText, string value, ref int yPosition)
        {
            Label lblTitle = new Label
            {
                Text = labelText,
                Location = new Point(20, yPosition),
                Size = new Size(100, 20),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblTitle);

            Label lblValue = new Label
            {
                Text = value,
                Location = new Point(130, yPosition),
                Size = new Size(240, 20),
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 9)
            };
            this.Controls.Add(lblValue);

            yPosition += 30;
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    this.AutoScaleDimensions = new SizeF(6F, 13F);
        //    this.AutoScaleMode = AutoScaleMode.Font;
        //    this.ClientSize = new Size(400, 300);
        //    this.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    this.MaximizeBox = false;
        //    this.MinimizeBox = false;
        //    this.Name = "MovieDetailForm";
        //    this.ShowIcon = false;
        //    this.ShowInTaskbar = false;
        //    this.Text = "Chi tiết phim";
        //    this.ResumeLayout(false);
        //}
    }
}
