using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.ViewModel
{
    public class MovieView
    {
        public Movie Movie { get; set; }
        public Person Director { get; set; }
        public List<Person> Actors { get; set; }
        public Genre Genre { get; set; }
    }
}
