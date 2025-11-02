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
using cinema_system.admin;
using cinema_system.nhân_viên;
using Microsoft.EntityFrameworkCore;


namespace cinema_system.đăng_nhập
{
    public partial class Đăng_nhập : Form
    {
        private string captchaText;
        public Đăng_nhập()
        {
            InitializeComponent();

            UC_Đăng_ký ucDangKy = new UC_Đăng_ký();
            ucDangKy.Dock = DockStyle.Fill;

            tabRegister.Controls.Add(ucDangKy);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new CinemaDbContext())
                {
                    var user = context.Users
                        .Include(u => u.Role)
                        .FirstOrDefault(u => u.NameAccount == username && u.Password == password);

                    if (user != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công! Chào mừng {user.UserName} ({user.Role.NameRole})", "Thông báo");

                        Form targetForm = null;

                        switch (user.RoleId)
                        {
                            case 1: 
                                targetForm = new StaffDesign(user.UserId, user.RoleId, user.UserName);
                                break;
                            case 2: 
                                targetForm = new StaffDesign(user.UserId, user.RoleId, user.UserName);
                                break;
                            default:
                                MessageBox.Show("Vai trò không được hỗ trợ", "Lỗi đăng nhập", MessageBoxButtons.OK);
                                return;
                        }

                        targetForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi hệ thống: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle rect = e.Bounds;

            if (e.Index == tabControl.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.Red, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.Red, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

    }
}
