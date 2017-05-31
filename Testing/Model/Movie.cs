using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Model
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public byte Stars { get; set; }
        public int DirectorID { get; set; }
        public int GenreID { get; set; }

        public ICollection<MovieActor> Actors { set; get; } 
    }
}
