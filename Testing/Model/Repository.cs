using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Model
{
    public class Repository
    {
        private MovieContext _context;

        public Repository(MovieContext context)
        {
            _context = context;
        }

        public List<Movie> getAllMovies() {
            return _context.Movies.ToList();
        }

        public void updateRating(byte rating, int id) {
            var result = _context.Movies.Single(i => i.MovieID == id);
            result.Stars = rating;
            _context.SaveChanges();
        }

        public List<Person> getActorsByMovieId(int movieID)
        {
            List<int> ids = _context.MovieActors.Where(i => i.MovieID == movieID).Select(u => u.ActorID).ToList();
            //List<Actor> result = _context.Actors.Where(i => ids.Contains(i.ActorId)).ToList();
            return _context.Persons.Where(i => ids.Contains(i.PersonID)).ToList();
        }

        public Person getDirectorByID(int director)
        {
            Person result = _context.Persons.Single(i => i.PersonID == director);
            return result;
        }

        public Genre getGenreByID(int genreID)
        {
            return _context.Genres.Single(i => i.GenreID == genreID);
        }

        public void deleteMovieByID(int movieID) {
            var movieActor = _context.MovieActors.Where(i => i.MovieID == movieID);

            foreach (var ma in movieActor)
            {
                _context.MovieActors.Remove(ma);
            }

            _context.SaveChanges();

            Movie removeThis = _context.Movies.Single(i => i.MovieID == movieID);
            _context.Movies.Remove(removeThis);
            _context.SaveChanges();
        }

        public List<Genre> getAllGenres()
        {
            return _context.Genres.ToList();
        }

        public List<Person> getAllPeople()
        {
            return _context.Persons.ToList();
        }

        public void addMovie(Movie buffer)
        {

            _context.Movies.Add(buffer);
            _context.SaveChanges();
        }
    }
}
