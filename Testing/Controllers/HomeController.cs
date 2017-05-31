using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Model;
using Testing.ViewModel;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        private Repository _repository;

        public HomeController(MovieContext context, Repository repos)
        {
            _context = context;
            _repository = repos;
        }
        [Route("Movie/Index")]
        [Route("")]
        public IActionResult Index()
        {
            List<Movie> movies = _repository.getAllMovies();
            List<MovieView> viewModel = new List<MovieView>();

            foreach (Movie movie in movies)
            {
                List<Person> actors = _repository.getActorsByMovieId(movie.MovieID);
                Person director = _repository.getDirectorByID(movie.DirectorID);
                MovieView view = new MovieView
                {
                    Movie = movie,
                    Director = director,
                    Actors = actors
                };
                viewModel.Add(view);
            }

            return View(viewModel);
        }

        public IActionResult Rate(int rating, int movieID) {
            byte rate = Convert.ToByte(rating);

            _repository.updateRating(rate, movieID);
            List<Movie> movies = _repository.getAllMovies();
            List<MovieView> viewModel = new List<MovieView>();

            foreach (Movie movie in movies)
            {
                List<Person> actors = _repository.getActorsByMovieId(movie.MovieID);
                Person director = _repository.getDirectorByID(movie.DirectorID);
                MovieView view = new MovieView
                {
                    Movie = movie,
                    Director = director,
                    Actors = actors
                };
                viewModel.Add(view);
            }



            return View("index", viewModel);
        }

        [Route("Movie/Add")]
        public IActionResult Add()
        {
            List<MovieView> result = GetAddList();

            return View(result);
        }

        [HttpPost]
        public IActionResult Add(AddMovieView values)
        {
            if (ModelState.IsValid)
            {
                Movie buffer = new Movie {
                    Title = values.Title,
                    Description = values.Description,
                    Year = values.Year,
                    Stars = values.Stars,
                    DirectorID = values.DirectorID,
                    GenreID = values.GenreID
                };
                _repository.addMovie(buffer);
                List<MovieView> result = GetAddList();
                return View("Add", GetAddList());
            }
            else {

                return View("addMovie", getGenreDirectorView());
            }


        }

        public IActionResult Remove(int movieID)
        {
            _repository.deleteMovieByID(movieID);

            List<MovieView> result = GetAddList();

            return View("Add", result);
        }

        [Route("Movie/AddMovie")]
        public IActionResult AddMovie(int movieID)
        {
            
            return View(getGenreDirectorView());
        }

        public IActionResult Error()
        {
            return View();
        }

        private AddMovieView getGenreDirectorView() {
            List<Genre> genres = _repository.getAllGenres();
            List<Person> directors = _repository.getAllPeople();

            AddMovieView result = new AddMovieView {
                Genres = genres,
                Directors = directors
            };

            return result;
        }

        private List<MovieView> GetAddList() {
            List<Movie> movies = _repository.getAllMovies();
            List<MovieView> viewModel = new List<MovieView>();

            foreach (Movie movie in movies)
            {
                List<Person> actors = _repository.getActorsByMovieId(movie.MovieID);
                Person director = _repository.getDirectorByID(movie.DirectorID);
                Genre genre = _repository.getGenreByID(movie.GenreID);
                MovieView view = new MovieView
                {
                    Movie = movie,
                    Director = director,
                    Actors = actors,
                    Genre = genre
                    
                };
                viewModel.Add(view);
            }

            return viewModel;
        }
    }
}
