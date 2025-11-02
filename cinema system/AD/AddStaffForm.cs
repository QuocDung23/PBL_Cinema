using cinema_system.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace cinema_system.nhân_viên
{
    public partial class AddStaffForm : Form
    {
        public AddStaffForm()
        {
            InitializeComponent();
            LoadStaffs(); // ⬅️ Tự động load khi form mở
        }

        private void LoadStaffs()
        {
            using (var db = new CinemaDbContext())
            {
                var staffList = db.Users
                    .Where(u => u.Role.NameRole == "Nhân viên") // chỉ load nhân viên
                    .Select(u => new
                    {
                        u.UserId,
                        u.UserName,
                        u.NameAccount,
                        u.Password
                    })
                    .ToList();

                dgvUsers.DataSource = staffList;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            string username = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new CinemaDbContext())
            {
                // Tìm role Nhân viên
                var role = db.Roles.FirstOrDefault(r => r.NameRole == "Nhân viên");
                if (role == null)
                {
                    MessageBox.Show("Chưa có vai trò 'Nhân viên' trong cơ sở dữ liệu!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔥 Kiểm tra trùng Username hoặc Account
                bool exists = db.Users.Any(u =>
                    u.UserName.ToLower() == name.ToLower() ||
                    u.NameAccount.ToLower() == username.ToLower());

                if (exists)
                {
                    MessageBox.Show("Tên nhân viên hoặc tài khoản đã tồn tại!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo user mới
                var newUser = new User
                {
                    UserName = name,
                    NameAccount = username,
                    Password = password,
                    RoleId = role.RoleId
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadStaffs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            int userId = (int)dgvUsers.SelectedRows[0].Cells["UserId"].Value;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            using (var db = new CinemaDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }

            MessageBox.Show("Xóa nhân viên thành công!");
            LoadStaffs(); // reload lại sau khi xóa
        }

        private void ClearFields()
        {
            txtUserName.Clear();
            txtAccount.Clear();
            txtPassword.Clear();
        }
    }
}
