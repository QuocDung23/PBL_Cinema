using System.Drawing;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    partial class MovieItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private PictureBox picPoster;
        private Label lblMovieName;
        private FlowLayoutPanel flowTimes;

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
            this.components = new System.ComponentModel.Container();
            this.picPoster = new PictureBox();
            this.lblMovieName = new Label();
            this.flowTimes = new FlowLayoutPanel();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MovieItem";
            this.SuspendLayout();
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(10, 10);
            this.picPoster.Size = new System.Drawing.Size(120, 160);
            this.picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMovieName.Location = new System.Drawing.Point(140, 10);
            // 
            // flowTimes
            // 
            this.flowTimes.Location = new System.Drawing.Point(140, 40);
            this.flowTimes.Size = new System.Drawing.Size(300, 130);
            this.flowTimes.AutoScroll = true;
            // 
            // UC_MovieItem
            // 
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.picPoster);
            this.Controls.Add(this.lblMovieName);
            this.Controls.Add(this.flowTimes);
            this.Size = new System.Drawing.Size(460, 180);
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}