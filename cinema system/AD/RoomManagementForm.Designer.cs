namespace cinema_system.AD
{
    partial class RoomManagementForm
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
            this.lblSearchRoom = new System.Windows.Forms.Label();
            this.txtSearchRoom = new System.Windows.Forms.TextBox();
            this.btnSearchRoom = new System.Windows.Forms.Button();
            this.btnEditRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.lblNameRoom = new System.Windows.Forms.Label();
            this.txtNameRoom = new System.Windows.Forms.TextBox();
            this.lblTotalSeat = new System.Windows.Forms.Label();
            this.numTotalSeat = new System.Windows.Forms.NumericUpDown();
            this.lblTypeRoom = new System.Windows.Forms.Label();
            this.cmbTypeRoom = new System.Windows.Forms.ComboBox();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearchRoom
            // 
            this.lblSearchRoom.AutoSize = true;
            this.lblSearchRoom.Location = new System.Drawing.Point(20, 20);
            this.lblSearchRoom.Name = "lblSearchRoom";
            this.lblSearchRoom.Size = new System.Drawing.Size(52, 13);
            this.lblSearchRoom.TabIndex = 0;
            this.lblSearchRoom.Text = "Tìm kiếm:";
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Location = new System.Drawing.Point(100, 20);
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(200, 20);
            this.txtSearchRoom.TabIndex = 1;
            // 
            // btnSearchRoom
            // 
            this.btnSearchRoom.Location = new System.Drawing.Point(310, 20);
            this.btnSearchRoom.Name = "btnSearchRoom";
            this.btnSearchRoom.Size = new System.Drawing.Size(60, 25);
            this.btnSearchRoom.TabIndex = 2;
            this.btnSearchRoom.Text = "Tìm";
            this.btnSearchRoom.UseVisualStyleBackColor = true;
            this.btnSearchRoom.Click += new System.EventHandler(this.btnSearchRoom_Click);
            // 
            // btnEditRoom
            // 
            this.btnEditRoom.Location = new System.Drawing.Point(110, 50);
            this.btnEditRoom.Name = "btnEditRoom";
            this.btnEditRoom.Size = new System.Drawing.Size(80, 30);
            this.btnEditRoom.TabIndex = 4;
            this.btnEditRoom.Text = "Sửa";
            this.btnEditRoom.UseVisualStyleBackColor = true;
            this.btnEditRoom.Click += new System.EventHandler(this.btnEditRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(200, 50);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteRoom.TabIndex = 5;
            this.btnDeleteRoom.Text = "Xóa";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // dgvRooms
            // 
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(20, 220);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.Size = new System.Drawing.Size(800, 280);
            this.dgvRooms.TabIndex = 6;
            this.dgvRooms.SelectionChanged += new System.EventHandler(this.dgvRooms_SelectionChanged);
            // 
            // lblNameRoom
            // 
            this.lblNameRoom.AutoSize = true;
            this.lblNameRoom.Location = new System.Drawing.Point(20, 90);
            this.lblNameRoom.Name = "lblNameRoom";
            this.lblNameRoom.Size = new System.Drawing.Size(62, 13);
            this.lblNameRoom.TabIndex = 7;
            this.lblNameRoom.Text = "Tên phòng:";
            // 
            // txtNameRoom
            // 
            this.txtNameRoom.Location = new System.Drawing.Point(100, 87);
            this.txtNameRoom.Name = "txtNameRoom";
            this.txtNameRoom.Size = new System.Drawing.Size(200, 20);
            this.txtNameRoom.TabIndex = 8;
            // 
            // lblTotalSeat
            // 
            this.lblTotalSeat.AutoSize = true;
            this.lblTotalSeat.Location = new System.Drawing.Point(20, 120);
            this.lblTotalSeat.Name = "lblTotalSeat";
            this.lblTotalSeat.Size = new System.Drawing.Size(56, 13);
            this.lblTotalSeat.TabIndex = 9;
            this.lblTotalSeat.Text = "Tổng ghế:";
            // 
            // numTotalSeat
            // 
            this.numTotalSeat.Location = new System.Drawing.Point(100, 118);
            this.numTotalSeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalSeat.Name = "numTotalSeat";
            this.numTotalSeat.Size = new System.Drawing.Size(80, 20);
            this.numTotalSeat.TabIndex = 10;
            this.numTotalSeat.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblTypeRoom
            // 
            this.lblTypeRoom.AutoSize = true;
            this.lblTypeRoom.Location = new System.Drawing.Point(20, 150);
            this.lblTypeRoom.Name = "lblTypeRoom";
            this.lblTypeRoom.Size = new System.Drawing.Size(63, 13);
            this.lblTypeRoom.TabIndex = 11;
            this.lblTypeRoom.Text = "Loại phòng:";
            // 
            // cmbTypeRoom
            // 
            this.cmbTypeRoom.FormattingEnabled = true;
            this.cmbTypeRoom.Location = new System.Drawing.Point(100, 147);
            this.cmbTypeRoom.Name = "cmbTypeRoom";
            this.cmbTypeRoom.Size = new System.Drawing.Size(180, 21);
            this.cmbTypeRoom.TabIndex = 12;
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Location = new System.Drawing.Point(20, 50);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(80, 30);
            this.btnSaveRoom.TabIndex = 13;
            this.btnSaveRoom.Text = "Thêm";
            this.btnSaveRoom.UseVisualStyleBackColor = true;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // RoomManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 520);
            this.Controls.Add(this.btnSaveRoom);
            this.Controls.Add(this.cmbTypeRoom);
            this.Controls.Add(this.lblTypeRoom);
            this.Controls.Add(this.numTotalSeat);
            this.Controls.Add(this.lblTotalSeat);
            this.Controls.Add(this.txtNameRoom);
            this.Controls.Add(this.lblNameRoom);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.btnSearchRoom);
            this.Controls.Add(this.txtSearchRoom);
            this.Controls.Add(this.lblSearchRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RoomManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng chiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchRoom;
        private System.Windows.Forms.TextBox txtSearchRoom;
        private System.Windows.Forms.Button btnSearchRoom;
        private System.Windows.Forms.Button btnEditRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.Label lblNameRoom;
        private System.Windows.Forms.TextBox txtNameRoom;
        private System.Windows.Forms.Label lblTotalSeat;
        private System.Windows.Forms.NumericUpDown numTotalSeat;
        private System.Windows.Forms.Label lblTypeRoom;
        private System.Windows.Forms.ComboBox cmbTypeRoom;  // Đổi tên từ txtTypeRoom
        private System.Windows.Forms.Button btnSaveRoom;
    }
}