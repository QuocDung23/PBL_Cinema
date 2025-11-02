using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.nhân_viên
{
    public partial class MovieDialog : Form
    {
        private Movie _movie;
        private string selectedPosterPath;

        public MovieDialog()
        {
            InitializeComponent();
        }
        public MovieDialog(Movie movie)
        {
            InitializeComponent();
            _movie = movie ?? new Movie();
            this.Text = _movie.MovieId > 0 ? "Sửa phim" : "Thêm phim mới";
            LoadData();
        }

        private void LoadData()
        {
            txtNameMovie.Text = _movie.NameMovie ?? "";
            txtGenreMovie.Text = _movie.GenreMovie ?? "";
            txtDescriptionMovie.Text = _movie.DescriptionMovie ?? "";
            txtDirectorMovie.Text = _movie.Director ?? "";

            int duration = _movie.DurationMovie;
            if (duration < 1) duration = 90;  
            if (duration > 300) duration = 300;  
            numDurationMovie.Value = duration;

            if (_movie.ReleaseDateMovie.HasValue)
            {
                dtpReleaseDateMovie.Value = _movie.ReleaseDateMovie.Value;
            }
            else
            {
                dtpReleaseDateMovie.Value = DateTime.Now;  
            }

            txtPosterURL.Text = _movie.PosterURL ?? "";
            // Load preview nếu có poster
            if (!string.IsNullOrEmpty(_movie.PosterURL))
            {
                string posterPath = Path.Combine("Posters", _movie.PosterURL);
                if (File.Exists(posterPath))
                {
                    try
                    {
                        picPosterPreview.Image?.Dispose();
                        picPosterPreview.Image = Image.FromFile(posterPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải ảnh preview: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void btnSelectPoster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    selectedPosterPath = openFile.FileName;
                    string fileName = Path.GetFileName(selectedPosterPath);

                    string targetDir = "Posters";
                    if (!Directory.Exists(targetDir))
                    {
                        Directory.CreateDirectory(targetDir);
                    }

                    string targetPath = Path.Combine(targetDir, fileName);
                    try
                    {
                        File.Copy(selectedPosterPath, targetPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi copy ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtPosterURL.Text = fileName;  

                    try
                    {
                        picPosterPreview.Image?.Dispose();
                        picPosterPreview.Image = Image.FromFile(targetPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi tải ảnh preview: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    selectedPosterPath = null;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNameMovie.Text))
            {
                MessageBox.Show("Tên phim không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameMovie.Focus();
                return;
            }

            using (var context = new CinemaDbContext())
            {
                if (_movie.MovieId == 0)
                {
                    _movie = new Movie();
                    context.Movies.Add(_movie);
                }
                else
                {
                    context.Movies.Attach(_movie);
                    context.Entry(_movie).State = EntityState.Modified;
                }

                _movie.NameMovie = txtNameMovie.Text.Trim();
                _movie.GenreMovie = txtGenreMovie.Text.Trim();
                _movie.DescriptionMovie = txtDescriptionMovie.Text.Trim();
                _movie.Director = txtDirectorMovie.Text.Trim();
                _movie.DurationMovie = (int)numDurationMovie.Value;
                _movie.ReleaseDateMovie = dtpReleaseDateMovie.Value;
                _movie.PosterURL = txtPosterURL.Text.Trim();

                try
                {
                    context.SaveChanges(); // ✅ Lưu thật sự vào DB
                    MessageBox.Show("Lưu phim thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi lưu phim: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}