using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    public partial class addmovie : UserControl
    {
        string connectionString = @"Data Source=shanley\sqlexpress;Initial Catalog=movie;Integrated Security=True;Encrypt=False";
        string imgPath = "";

        public addmovie ()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Movies", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovies.DataSource = dt;

                if (dgvMovies.Columns["Price"] != null)
                {
                    dgvMovies.Columns["Price"].DefaultCellStyle.FormatProvider =
                new System.Globalization.CultureInfo("vi-VN");
                    dgvMovies.Columns["Price"].DefaultCellStyle.Format = "c0";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Movies (MovieName, Price, PosterPath) VALUES (@name, @price, @img)", con);
                cmd.Parameters.AddWithValue("@name", txtMovieName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@img", imgPath);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Movie added successfully!");
                LoadMovies();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count > 0)
            {
                string id = dgvMovies.SelectedRows[0].Cells["MovieID"].Value.ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Movies SET MovieName=@name, Genre=@genre, Price=@price, PosterPath=@img WHERE MovieID=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", txtMovieName.Text);
                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@img", imgPath);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated successfully!");
                    LoadMovies();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count > 0)
            {
                string id = dgvMovies.SelectedRows[0].Cells["MovieID"].Value.ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE MovieID=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted successfully!");
                    LoadMovies();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMovieName.Clear();
            txtPrice.Clear();
            picPoster.Image = null;
            imgPath = "";
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgPath = ofd.FileName;
                picPoster.Image = Image.FromFile(imgPath);
            }
        }

        }
}
