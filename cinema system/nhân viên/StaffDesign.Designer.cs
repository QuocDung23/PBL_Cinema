namespace cinema_system.nhân_viên
{
    partial class StaffDesign
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Giải phóng tài nguyên đang được sử dụng.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowTime = new System.Windows.Forms.Button();
            this.btnQuanLyPhim = new System.Windows.Forms.Button();
            this.panelTrangChu = new System.Windows.Forms.Panel();
            this.lblTrangChu = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.moviePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.detailPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelTrangChu.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.moviePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.button4);
            this.panelMenu.Controls.Add(this.button3);
            this.panelMenu.Controls.Add(this.button2);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnShowTime);
            this.panelMenu.Controls.Add(this.btnQuanLyPhim);
            this.panelMenu.Controls.Add(this.panelTrangChu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 611);
            this.panelMenu.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 45);
            this.button3.TabIndex = 6;
            this.button3.Text = "Quản lý nhân viên";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 45);
            this.button2.TabIndex = 5;
            this.button2.Text = "Quản lý ghế";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Quản lý suất chiếu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowTime
            // 
            this.btnShowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTime.Location = new System.Drawing.Point(0, 205);
            this.btnShowTime.Name = "btnShowTime";
            this.btnShowTime.Size = new System.Drawing.Size(180, 45);
            this.btnShowTime.TabIndex = 3;
            this.btnShowTime.Text = "Quản lý phòng chiếu";
            this.btnShowTime.UseVisualStyleBackColor = true;
            this.btnShowTime.Click += new System.EventHandler(this.btnShowTime_Click);
            // 
            // btnQuanLyPhim
            // 
            this.btnQuanLyPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyPhim.Location = new System.Drawing.Point(0, 154);
            this.btnQuanLyPhim.Name = "btnQuanLyPhim";
            this.btnQuanLyPhim.Size = new System.Drawing.Size(180, 45);
            this.btnQuanLyPhim.TabIndex = 2;
            this.btnQuanLyPhim.Text = "Quản lý phim";
            this.btnQuanLyPhim.UseVisualStyleBackColor = true;
            this.btnQuanLyPhim.Click += new System.EventHandler(this.btnQuanLyPhim_Click);
            // 
            // panelTrangChu
            // 
            this.panelTrangChu.BackColor = System.Drawing.Color.Sienna;
            this.panelTrangChu.Controls.Add(this.lblTrangChu);
            this.panelTrangChu.Location = new System.Drawing.Point(0, 100);
            this.panelTrangChu.Name = "panelTrangChu";
            this.panelTrangChu.Size = new System.Drawing.Size(180, 50);
            this.panelTrangChu.TabIndex = 1;
            // 
            // lblTrangChu
            // 
            this.lblTrangChu.AutoSize = true;
            this.lblTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrangChu.ForeColor = System.Drawing.Color.White;
            this.lblTrangChu.Location = new System.Drawing.Point(25, 12);
            this.lblTrangChu.Name = "lblTrangChu";
            this.lblTrangChu.Size = new System.Drawing.Size(109, 24);
            this.lblTrangChu.TabIndex = 0;
            this.lblTrangChu.Text = "Trang Chủ";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelContent.Controls.Add(this.moviePanel);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(180, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(854, 611);
            this.panelContent.TabIndex = 1;
            // 
            // moviePanel
            // 
            this.moviePanel.AutoScroll = true;
            this.moviePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.moviePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moviePanel.Controls.Add(this.detailPanel);
            this.moviePanel.Location = new System.Drawing.Point(0, 67);
            this.moviePanel.Name = "moviePanel";
            this.moviePanel.Size = new System.Drawing.Size(854, 541);
            this.moviePanel.TabIndex = 1;
            // 
            // detailPanel
            // 
            this.detailPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.detailPanel.Location = new System.Drawing.Point(2, 2);
            this.detailPanel.Margin = new System.Windows.Forms.Padding(2);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(150, 0);
            this.detailPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(54, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Phim Đang Chiếu";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 409);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 45);
            this.button4.TabIndex = 7;
            this.button4.Text = "Lịch sử";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // StaffDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 611);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StaffDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý rạp chiếu phim - Nhân viên";
            this.panelMenu.ResumeLayout(false);
            this.panelTrangChu.ResumeLayout(false);
            this.panelTrangChu.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.moviePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTrangChu;
        private System.Windows.Forms.Label lblTrangChu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel moviePanel;
        private System.Windows.Forms.FlowLayoutPanel detailPanel;
        private System.Windows.Forms.Button btnQuanLyPhim;
        private System.Windows.Forms.Button btnShowTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
