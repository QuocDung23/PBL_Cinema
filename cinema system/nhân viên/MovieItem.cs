using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema_system.nhân_viên
{
    public partial class MovieItem : UserControl
    {
        public MovieItem()
        {
            InitializeComponent();
        }

        public void SetData(string name, string poster, List<TimeSpan> times)
        {
            lblMovieName.Text = name;
            picPoster.Image = Image.FromFile(poster);
            flowTimes.Controls.Clear();

            foreach (var time in times)
            {
                Button btn = new Button();
                btn.Text = time.ToString(@"hh\:mm");
                btn.Width = 70;
                btn.Height = 30;
                btn.BackColor = Color.LightSkyBlue;
                btn.FlatStyle = FlatStyle.Flat;
                flowTimes.Controls.Add(btn);

            }
        }

    }
}
