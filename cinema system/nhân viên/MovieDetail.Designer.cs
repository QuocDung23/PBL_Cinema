namespace cinema_system
{
    partial class MovieDetail
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
            this.flpShowtimes = new System.Windows.Forms.FlowLayoutPanel();
            this.picPosterDetail = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblDes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picPosterDetail)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpShowtimes
            // 
            this.flpShowtimes.Location = new System.Drawing.Point(345, 380);
            this.flpShowtimes.Margin = new System.Windows.Forms.Padding(2);
            this.flpShowtimes.Name = "flpShowtimes";
            this.flpShowtimes.Size = new System.Drawing.Size(653, 87);
            this.flpShowtimes.TabIndex = 0;
            // 
            // picPosterDetail
            // 
            this.picPosterDetail.Location = new System.Drawing.Point(33, 58);
            this.picPosterDetail.Name = "picPosterDetail";
            this.picPosterDetail.Size = new System.Drawing.Size(283, 430);
            this.picPosterDetail.TabIndex = 1;
            this.picPosterDetail.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(343, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(106, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "label1";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetail.Location = new System.Drawing.Point(373, 92);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(51, 20);
            this.lblDetail.TabIndex = 3;
            this.lblDetail.Text = "label1";
            // 
            // lblDes
            // 
            this.lblDes.AutoSize = true;
            this.lblDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDes.Location = new System.Drawing.Point(3, 0);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(44, 16);
            this.lblDes.TabIndex = 4;
            this.lblDes.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(345, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 2);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nội dung phim:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblDes);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(345, 238);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(678, 133);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // MovieDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 611);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picPosterDetail);
            this.Controls.Add(this.flpShowtimes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MovieDetail";
            this.Text = "MovieDetail";
            ((System.ComponentModel.ISupportInitialize)(this.picPosterDetail)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picPosterDetail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}