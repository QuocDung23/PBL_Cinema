using System.Drawing;

namespace cinema_system.nhân_viên
{
    partial class MovieDetailForm
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
            // 
            // MovieDetailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MovieDetailForm";
            this.Text = "MovieDetailForm";
            this.ResumeLayout(false);

            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.ClientSize = new Size(400, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MovieDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Chi tiết phim";
            this.ResumeLayout(false);

        }

        #endregion
    }
}