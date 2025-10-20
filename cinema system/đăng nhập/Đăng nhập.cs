using cinema_system.khách_hàng;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using cinema_system.Khách_hàng;
using cinema_system.admin;
using cinema_system.nhân_viên;

namespace cinema_system.đăng_nhập
{
    public partial class Đăng_nhập : Form
    {
        string conn = @"Data Source=shanley\sqlexpress;Initial Catalog=movie;Integrated Security=True;Encrypt=False";
        private string captchaText;
        public Đăng_nhập()
        {
            InitializeComponent();
            GenerateCaptcha();

            UC_Đăng_ký ucDangKy = new UC_Đăng_ký();
            ucDangKy.Dock = DockStyle.Fill;

            tabRegister.Controls.Add(ucDangKy);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // kiểm tra captcha trước
            if (txtCaptcha.Text != captchaText)
            {
                MessageBox.Show("Captcha sai, vui lòng thử lại!", "Thông báo");
                GenerateCaptcha();
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo");
                return;
            }

            // Chuỗi kết nối
            string connStr = "Data Source=shanley\\sqlexpress;Initial Catalog=movie;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                // Kiểm tra tài khoản trong bảng
                string query = "SELECT VaiTro FROM TaiKhoan WHERE TenDangNhap = @username AND Pass = @password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar(); // chỉ lấy 1 giá trị đầu tiên (VaiTro)

                if (result != null)
                {
                    string role = result.ToString();

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                    // chuyển hướng theo vai trò
                    if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // mở form admin
                        admin_design fAdmin = new admin_design();
                        fAdmin.Show();
                    }
                    else if (role.Equals("user", StringComparison.OrdinalIgnoreCase))
                    {
                        // mở form user
                        thông_tin_khách_hàng fUser = new thông_tin_khách_hàng();
                        fUser.Show();
                    }else if (role.Equals("staff", StringComparison.OrdinalIgnoreCase))
                    {
                        StaffDesign fStaff = new StaffDesign();
                        fStaff.Show();
                    }

                        this.Hide(); // ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo");
                    GenerateCaptcha();
                }
            }
        }


        private void GenerateCaptcha()
        {
            Bitmap bmp = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Random rnd = new Random();
            captchaText = "";
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 5; i++)
            {
                captchaText += chars[rnd.Next(chars.Length)];
            }

            using (Font font = new Font("Arial", 20, FontStyle.Bold))
            {
                g.DrawString(captchaText, font, Brushes.Black, new PointF(10, 10));
            }

            // vẽ thêm vài đường loằng ngoằng
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(Pens.Gray, rnd.Next(0, bmp.Width), rnd.Next(0, bmp.Height),
                                      rnd.Next(0, bmp.Width), rnd.Next(0, bmp.Height));
            }

            picCaptcha.Image = bmp;
        }
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle rect = e.Bounds;

            // nếu tab đang được chọn -> nền đỏ, chữ trắng
            if (e.Index == tabControl.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.Red, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                // tab chưa chọn -> nền trắng, chữ đỏ
                e.Graphics.FillRectangle(Brushes.White, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.Red, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            UserDesign ud = new UserDesign();
            ud.Show();
            this.Hide();
        }
    }
}
