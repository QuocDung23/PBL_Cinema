using System.Drawing;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    partial class dat_ve
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelDates;
        private FlowLayoutPanel flowMovies;

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
            this.flowLayoutPanelDates = new System.Windows.Forms.FlowLayoutPanel();
            this.flowMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelDates
            // 
            this.flowLayoutPanelDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelDates.Height = 120;
            this.flowLayoutPanelDates.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelDates.Padding = new Padding(10);
            this.flowLayoutPanelDates.WrapContents = false;
            this.flowLayoutPanelDates.AutoScroll = true;
            this.flowLayoutPanelDates.FlowDirection = FlowDirection.LeftToRight;
            // 
            // flowMovies
            // 
            this.flowMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMovies.AutoScroll = true;
            this.flowMovies.BackColor = Color.OldLace;
            this.flowMovies.Padding = new Padding(10);
            this.flowMovies.FlowDirection = FlowDirection.TopDown;
            this.flowMovies.WrapContents = false;
            // 
            // dat_ve (UserControl)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowMovies);
            this.Controls.Add(this.flowLayoutPanelDates);
            this.Name = "dat_ve";
            this.Size = new System.Drawing.Size(1440, 753);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
