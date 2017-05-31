using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Model;

namespace MovieShopWebApi.Controllers
{
    [Route("api/[controller]")]
    public class GenresController
    {
        private Repository _repository;

        public GenresController(Repository repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<Genre> buffer = _repository.getAllGenres();
            string[] result = new string[buffer.Count];
            int count = 0;

            foreach (var genre in buffer)
            {

                result[count] = genre.GenreID.ToString() + "," + genre.Description;
                count++;
            }
            return result;
            //return new string[] ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
