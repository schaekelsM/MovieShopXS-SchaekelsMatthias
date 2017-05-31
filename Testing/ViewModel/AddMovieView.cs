using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.ViewModel
{
    public class AddMovieView
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "At least a minimum length of 3")]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2017, ErrorMessage = "Year should be between 1900 and 2017")]
        public int Year { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "At least a minimum length of 3")]
        public string Description { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating should be between 0 and 5")]
        public Byte Stars { get; set; }

        public int DirectorID { get; set; }

        public int GenreID { get; set; }

        public List<Genre> Genres { set; get; }
        public List<Person> Directors { get; set; }
    }
}
