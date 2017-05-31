using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.ViewModel
{
    public class GenreDirectorView
    {
        public List<Genre> Genres { set; get; }
        public List<Person> Directors { get; set; }
    }
}
