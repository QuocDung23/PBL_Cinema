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
            this.panelTrangChu = new System.Windows.Forms.Panel();
            this.lblTrangChu = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.moviePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.detailPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnQuanLyPhim = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelTrangChu.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.moviePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.btnQuanLyPhim);
            this.panelMenu.Controls.Add(this.panelTrangChu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 611);
            this.panelMenu.TabIndex = 0;
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
            // btnQuanLyPhim
            // 
            this.btnQuanLyPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyPhim.Location = new System.Drawing.Point(0, 156);
            this.btnQuanLyPhim.Name = "btnQuanLyPhim";
            this.btnQuanLyPhim.Size = new System.Drawing.Size(180, 47);
            this.btnQuanLyPhim.TabIndex = 2;
            this.btnQuanLyPhim.Text = "Quản lý phim";
            this.btnQuanLyPhim.UseVisualStyleBackColor = true;
            this.btnQuanLyPhim.Click += new System.EventHandler(this.btnQuanLyPhim_Click);
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
    }
}
