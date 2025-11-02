using System.Windows.Forms;

namespace cinema_system.AD
{
    partial class SeatManagementForm
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
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtDoubleSeatPerRow = new System.Windows.Forms.TextBox();
            this.txtDoubleRowCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtColumnCount = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.txtRowCount = new System.Windows.Forms.TextBox();
            this.lblSeatType = new System.Windows.Forms.Label();
            this.cmbTypeSeat = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnGenerateSeats = new System.Windows.Forms.Button();
            this.dgvSeats = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteSeats = new System.Windows.Forms.Button();
            this.grpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.btnDeleteSeats);
            this.grpInput.Controls.Add(this.label3);
            this.grpInput.Controls.Add(this.label2);
            this.grpInput.Controls.Add(this.txtDoubleSeatPerRow);
            this.grpInput.Controls.Add(this.txtDoubleRowCount);
            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Controls.Add(this.txtPrice);
            this.grpInput.Controls.Add(this.txtColumnCount);
            this.grpInput.Controls.Add(this.lblRoom);
            this.grpInput.Controls.Add(this.cmbRoom);
            this.grpInput.Controls.Add(this.lblRow);
            this.grpInput.Controls.Add(this.txtRowCount);
            this.grpInput.Controls.Add(this.lblSeatType);
            this.grpInput.Controls.Add(this.cmbTypeSeat);
            this.grpInput.Controls.Add(this.lblPrice);
            this.grpInput.Controls.Add(this.btnGenerateSeats);
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInput.Location = new System.Drawing.Point(9, 9);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(257, 373);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Cấu hình Hàng ghế";
            // 
            // txtDoubleSeatPerRow
            // 
            this.txtDoubleSeatPerRow.Location = new System.Drawing.Point(128, 276);
            this.txtDoubleSeatPerRow.Name = "txtDoubleSeatPerRow";
            this.txtDoubleSeatPerRow.Size = new System.Drawing.Size(113, 23);
            this.txtDoubleSeatPerRow.TabIndex = 10;
            // 
            // txtDoubleRowCount
            // 
            this.txtDoubleRowCount.Location = new System.Drawing.Point(128, 224);
            this.txtDoubleRowCount.Name = "txtDoubleRowCount";
            this.txtDoubleRowCount.Size = new System.Drawing.Size(113, 23);
            this.txtDoubleRowCount.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số Cột:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(128, 177);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(112, 23);
            this.txtPrice.TabIndex = 7;
            // 
            // txtColumnCount
            // 
            this.txtColumnCount.Location = new System.Drawing.Point(128, 84);
            this.txtColumnCount.Name = "txtColumnCount";
            this.txtColumnCount.Size = new System.Drawing.Size(113, 23);
            this.txtColumnCount.TabIndex = 6;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(13, 29);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(76, 15);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "Chọn Phòng:";
            // 
            // cmbRoom
            // 
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(128, 26);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(113, 23);
            this.cmbRoom.TabIndex = 0;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(13, 63);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(53, 15);
            this.lblRow.TabIndex = 1;
            this.lblRow.Text = "Số Hàng";
            // 
            // txtRowCount
            // 
            this.txtRowCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRowCount.Location = new System.Drawing.Point(128, 55);
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.Size = new System.Drawing.Size(112, 23);
            this.txtRowCount.TabIndex = 1;
            // 
            // lblSeatType
            // 
            this.lblSeatType.AutoSize = true;
            this.lblSeatType.Location = new System.Drawing.Point(13, 135);
            this.lblSeatType.Name = "lblSeatType";
            this.lblSeatType.Size = new System.Drawing.Size(58, 15);
            this.lblSeatType.TabIndex = 3;
            this.lblSeatType.Text = "Loại Ghế:";
            // 
            // cmbTypeSeat
            // 
            this.cmbTypeSeat.FormattingEnabled = true;
            this.cmbTypeSeat.Location = new System.Drawing.Point(128, 127);
            this.cmbTypeSeat.Name = "cmbTypeSeat";
            this.cmbTypeSeat.Size = new System.Drawing.Size(113, 23);
            this.cmbTypeSeat.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(13, 180);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(93, 15);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Giá/Ghế (VNĐ):";
            // 
            // btnGenerateSeats
            // 
            this.btnGenerateSeats.Location = new System.Drawing.Point(143, 328);
            this.btnGenerateSeats.Name = "btnGenerateSeats";
            this.btnGenerateSeats.Size = new System.Drawing.Size(105, 39);
            this.btnGenerateSeats.TabIndex = 5;
            this.btnGenerateSeats.Text = "Tạo và Lưu Hàng ghế";
            this.btnGenerateSeats.UseVisualStyleBackColor = true;
            this.btnGenerateSeats.Click += new System.EventHandler(this.btnGenerateSeats_Click);
            // 
            // dgvSeats
            // 
            this.dgvSeats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeats.Location = new System.Drawing.Point(274, 9);
            this.dgvSeats.Name = "dgvSeats";
            this.dgvSeats.Size = new System.Drawing.Size(403, 373);
            this.dgvSeats.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Số Hàng Ghế Đôi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Số Lượng Ghế Đôi:";
            // 
            // btnDeleteSeats
            // 
            this.btnDeleteSeats.Location = new System.Drawing.Point(16, 328);
            this.btnDeleteSeats.Name = "btnDeleteSeats";
            this.btnDeleteSeats.Size = new System.Drawing.Size(100, 39);
            this.btnDeleteSeats.TabIndex = 13;
            this.btnDeleteSeats.Text = "Xóa Ghế";
            this.btnDeleteSeats.UseVisualStyleBackColor = true;
            this.btnDeleteSeats.Click += new System.EventHandler(this.btnDeleteSeats_Click);
            // 
            // SeatManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.dgvSeats);
            this.Controls.Add(this.grpInput);
            this.Name = "SeatManagementForm";
            this.Text = "Quản Lý Ghế Phòng Chiếu";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo các Controls (Đã sắp xếp lại)
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblSeatType;
        private System.Windows.Forms.Label lblPrice;

        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.TextBox txtRowCount;
        private System.Windows.Forms.ComboBox cmbTypeSeat;
        private System.Windows.Forms.Button btnGenerateSeats;
        private System.Windows.Forms.DataGridView dgvSeats;
        private TextBox txtColumnCount;
        private TextBox txtPrice;
        private Label label1;
        private TextBox txtDoubleRowCount;
        private TextBox txtDoubleSeatPerRow;
        private Label label3;
        private Label label2;
        private Button btnDeleteSeats;
    }
}