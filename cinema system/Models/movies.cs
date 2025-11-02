using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_system.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string NameMovie { get; set; }
        public string Director { get; set; }
        public string GenreMovie { get; set; }
        public string DescriptionMovie { get; set; }

        public int DurationMovie { get; set; }
        public DateTime? ReleaseDateMovie { get; set; }
        public string PosterURL { get; set; }

        public Movie() { }

        public ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    }
}
