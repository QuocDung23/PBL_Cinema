using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema_system.admin
{
    public partial class admin_design : Form
    {
        public admin_design()
        {
            InitializeComponent();
        }

        Panel indicator;

        private void highlight_Load(object sender, EventArgs e)
        {
            // Tạo thanh highlight
            indicator = new Panel();
            indicator.Size = new Size(5, Quanly.Height); // cao bằng đúng button
            indicator.BackColor = Color.Red;
            indicator.Visible = false;

            // sidebar = panel chứa menu (thay bằng tên panel của bạn)
            panel2.Controls.Add(indicator);
        }

        // Hàm dùng chung
        private void ActivateButton(Button btn)
        {
            indicator.Visible = true;
            indicator.Height = btn.Height;  // chiều cao bằng button
            indicator.Location = new Point(btn.Width - indicator.Width, btn.Top);
            indicator.BringToFront();
        }

        // Sự kiện các nút menu
        private void SuatChieu_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
            // load nội dung UserControl vào panelContent nếu cần
        }

        private void Ve_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void PhongChieu_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void Phim_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void HoannVe_Click(object sender, EventArgs e)
        {
            ActivateButton((Button)sender);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}