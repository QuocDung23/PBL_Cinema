using System;
using System.Drawing;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    partial class MovieDialog
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
            this.SuspendLayout();

            // Controls đã kéo thả (VS tự sinh, nhưng tôi viết lại để hoàn chỉnh)
            this.lblNameMovie = new Label { Text = "Tên phim:", Location = new Point(20, 20), Size = new Size(100, 20) };
            this.txtNameMovie = new TextBox { Location = new Point(130, 20), Size = new Size(200, 20) };

            this.lblAuthor = new Label { Text = "Tác giả:", Location = new Point(20, 240), Size = new Size(100, 20) };
            this.txtDirectorMovie = new TextBox { Location = new Point(130, 240), Size = new Size(200, 20) };

            this.lblGenreMovie = new Label { Text = "Thể loại:", Location = new Point(20, 50), Size = new Size(100, 20) };
            this.txtGenreMovie = new TextBox { Location = new Point(130, 50), Size = new Size(200, 20) };

            this.lblDescriptionMovie = new Label { Text = "Mô tả:", Location = new Point(20, 80), Size = new Size(100, 20) };
            this.txtDescriptionMovie = new TextBox { Location = new Point(130, 80), Size = new Size(200, 60), Multiline = true };

            this.lblDurationMovie = new Label { Text = "Thời lượng:", Location = new Point(20, 150), Size = new Size(100, 20) };
            this.numDurationMovie = new NumericUpDown { Location = new Point(130, 150), Size = new Size(80, 20), Minimum = 1, Maximum = 300 };

            this.lblReleaseDateMovie = new Label { Text = "Ngày phát hành:", Location = new Point(20, 180), Size = new Size(100, 20) };
            this.dtpReleaseDateMovie = new DateTimePicker { Location = new Point(130, 180), Size = new Size(120, 20), Format = DateTimePickerFormat.Short };

            this.lblPosterURL = new Label { Text = "Poster URL:", Location = new Point(20, 210), Size = new Size(100, 20) };
            this.txtPosterURL = new TextBox { Location = new Point(130, 210), Size = new Size(200, 20) };
            this.btnChoosePoster = new Button { Text = "Chọn ảnh", Location = new Point(335, 208), Size = new Size(80, 25) };
            this.btnChoosePoster.Click += new EventHandler(this.btnSelectPoster_Click);

            this.btnSave = new Button { Text = "Lưu", Location = new Point(20, 280), Size = new Size(80, 30) };
            this.btnSave.Click += btnSave_Click;

            this.btnCancel = new Button { Text = "Hủy", Location = new Point(110, 280), Size = new Size(80, 30) };
            this.btnCancel.Click += btnCancel_Click;

            // Thêm controls vào form
            this.Controls.AddRange(new Control[]
                       {
                lblNameMovie, txtNameMovie,
                lblGenreMovie, txtGenreMovie,
                lblDescriptionMovie, txtDescriptionMovie,
                lblDurationMovie, numDurationMovie,
                lblReleaseDateMovie, dtpReleaseDateMovie,
                lblPosterURL, txtPosterURL, btnChoosePoster, picPosterPreview,
                lblAuthor, txtDirectorMovie,
                btnSave, btnCancel
                       });
            // Form properties
            this.AutoScaleDimensions = new SizeF(8F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(430, 480);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Name = "MovieDialog";
            this.Text = "Thêm / Sửa phim";
            this.ResumeLayout(false);
        }

        // Controls
        private Label lblNameMovie, lblGenreMovie, lblDescriptionMovie, lblDurationMovie,
                      lblReleaseDateMovie, lblPosterURL, lblAuthor;
        private TextBox txtNameMovie, txtGenreMovie, txtDescriptionMovie, txtPosterURL, txtDirectorMovie;
        private NumericUpDown numDurationMovie;
        private DateTimePicker dtpReleaseDateMovie;
        private Button btnSave, btnCancel, btnChoosePoster;
        private PictureBox picPosterPreview;
    }

    #endregion
}