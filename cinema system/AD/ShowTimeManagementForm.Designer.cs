namespace cinema_system.AD
{
    partial class ShowTimeManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvShowTimes = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchShowTime = new System.Windows.Forms.TextBox();
            this.btnSearchShowTime = new System.Windows.Forms.Button();
            this.lblMovie = new System.Windows.Forms.Label();
            this.cmbMovie = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnAddShowTime = new System.Windows.Forms.Button();
            this.btnEditShowTime = new System.Windows.Forms.Button();
            this.btnSaveShowTime = new System.Windows.Forms.Button();
            this.btnDeleteShowTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowTimes
            // 
            this.dgvShowTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowTimes.Location = new System.Drawing.Point(20, 210);
            this.dgvShowTimes.Name = "dgvShowTimes";
            this.dgvShowTimes.Size = new System.Drawing.Size(800, 300);
            this.dgvShowTimes.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearchShowTime
            // 
            this.txtSearchShowTime.Location = new System.Drawing.Point(100, 17);
            this.txtSearchShowTime.Name = "txtSearchShowTime";
            this.txtSearchShowTime.Size = new System.Drawing.Size(200, 20);
            this.txtSearchShowTime.TabIndex = 16;
            // 
            // btnSearchShowTime
            // 
            this.btnSearchShowTime.Location = new System.Drawing.Point(310, 15);
            this.btnSearchShowTime.Name = "btnSearchShowTime";
            this.btnSearchShowTime.Size = new System.Drawing.Size(60, 25);
            this.btnSearchShowTime.TabIndex = 3;
            this.btnSearchShowTime.Text = "Tìm";
            this.btnSearchShowTime.UseVisualStyleBackColor = true;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Location = new System.Drawing.Point(20, 50);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(33, 13);
            this.lblMovie.TabIndex = 4;
            this.lblMovie.Text = "Phim:";
            // 
            // cmbMovie
            // 
            this.cmbMovie.FormattingEnabled = true;
            this.cmbMovie.Location = new System.Drawing.Point(100, 47);
            this.cmbMovie.Name = "cmbMovie";
            this.cmbMovie.Size = new System.Drawing.Size(200, 21);
            this.cmbMovie.TabIndex = 5;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(20, 80);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(41, 13);
            this.lblRoom.TabIndex = 6;
            this.lblRoom.Text = "Phòng:";
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(100, 77);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(200, 21);
            this.cmbRoom.TabIndex = 7;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(20, 110);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(94, 13);
            this.lblStartTime.TabIndex = 8;
            this.lblStartTime.Text = "Thời gian bắt đầu:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(120, 110);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(150, 20);
            this.dtpStartTime.TabIndex = 9;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 140);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 13);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "Giá vé:";
            // 
            // numPrice
            // 
            this.numPrice.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrice.Location = new System.Drawing.Point(100, 137);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(100, 20);
            this.numPrice.TabIndex = 11;
            // 
            // btnAddShowTime
            // 
            this.btnAddShowTime.Location = new System.Drawing.Point(20, 170);
            this.btnAddShowTime.Name = "btnAddShowTime";
            this.btnAddShowTime.Size = new System.Drawing.Size(75, 23);
            this.btnAddShowTime.TabIndex = 12;
            this.btnAddShowTime.Text = "Thêm";
            this.btnAddShowTime.UseVisualStyleBackColor = true;
            this.btnAddShowTime.Click += new System.EventHandler(this.btnSaveShowTime_Click);
            // 
            // btnEditShowTime
            // 
            this.btnEditShowTime.Location = new System.Drawing.Point(110, 170);
            this.btnEditShowTime.Name = "btnEditShowTime";
            this.btnEditShowTime.Size = new System.Drawing.Size(75, 23);
            this.btnEditShowTime.TabIndex = 13;
            this.btnEditShowTime.Text = "Sửa";
            this.btnEditShowTime.UseVisualStyleBackColor = true;
            this.btnEditShowTime.Click += new System.EventHandler(this.btnEditShowTime_Click);
            // 
            // btnSaveShowTime
            // 
            this.btnSaveShowTime.Location = new System.Drawing.Point(295, 170);
            this.btnSaveShowTime.Name = "btnSaveShowTime";
            this.btnSaveShowTime.Size = new System.Drawing.Size(75, 23);
            this.btnSaveShowTime.TabIndex = 14;
            this.btnSaveShowTime.Text = "Lưu";
            this.btnSaveShowTime.UseVisualStyleBackColor = true;
            // 
            // btnDeleteShowTime
            // 
            this.btnDeleteShowTime.Location = new System.Drawing.Point(214, 170);
            this.btnDeleteShowTime.Name = "btnDeleteShowTime";
            this.btnDeleteShowTime.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteShowTime.TabIndex = 15;
            this.btnDeleteShowTime.Text = "Xóa";
            this.btnDeleteShowTime.UseVisualStyleBackColor = true;
            this.btnDeleteShowTime.Click += new System.EventHandler(this.btnDeleteShowTime_Click);
            // 
            // ShowTimeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.Controls.Add(this.btnDeleteShowTime);
            this.Controls.Add(this.btnSaveShowTime);
            this.Controls.Add(this.btnEditShowTime);
            this.Controls.Add(this.btnAddShowTime);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbMovie);
            this.Controls.Add(this.lblMovie);
            this.Controls.Add(this.btnSearchShowTime);
            this.Controls.Add(this.txtSearchShowTime);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvShowTimes);
            this.Name = "ShowTimeManagementForm";
            this.Text = "Quản lý suất chiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowTimes;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchShowTime;
        private System.Windows.Forms.Button btnSearchShowTime;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.ComboBox cmbMovie;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnAddShowTime;
        private System.Windows.Forms.Button btnEditShowTime;
        private System.Windows.Forms.Button btnSaveShowTime;
        private System.Windows.Forms.Button btnDeleteShowTime;
    }
}