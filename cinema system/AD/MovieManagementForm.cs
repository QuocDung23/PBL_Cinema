using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using cinema_system.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_system.nhân_viên
{
    public partial class MovieManagementForm : Form
    {
        private CinemaDbContext context;

        public MovieManagementForm()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            try
            {
                context = new CinemaDbContext();
                var movies = context.Movies.ToList();

                dgvMovies.DataSource = movies;

                // Tùy chỉnh GridView
                dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMovies.ReadOnly = true;
                dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Ẩn cột navigation nếu có
                if (dgvMovies.Columns["ShowTimes"] != null)
                {
                    dgvMovies.Columns["ShowTimes"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phim: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            using (MovieDialog dialog = new MovieDialog(null))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadMovies();
                }
            }
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phim để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMovie = (Movie)dgvMovies.SelectedRows[0].DataBoundItem;
            MovieDialog dialog = new MovieDialog(selectedMovie);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadMovies();
            }
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phim để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMovie = (Movie)dgvMovies.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"Bạn có chắc muốn xóa phim '{selectedMovie.NameMovie}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    context = new CinemaDbContext();
                    context.Movies.Remove(selectedMovie);
                    context.SaveChanges();
                    LoadMovies();
                    MessageBox.Show("Xóa phim thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa phim: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchMovie.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadMovies();
                return;
            }

            try
            {
                context = new CinemaDbContext();
                var movies = context.Movies.Where(m => m.NameMovie.Contains(searchText)).ToList();
                dgvMovies.DataSource = movies;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}