using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesPostman.Models;

namespace MoviesPostman.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = Guid.NewGuid(), Awards = 1, Director = "Viorel", Duration = 120, PG = 13, ReleaseYear = 1999, Title = "Mircea si Mihai" }
        };

        // GET: api/Movies
        [HttpGet]
        public Movie[] GetMovies()
        {
            return movies.ToArray();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public Movie GetMovie(Guid id)
        {
            return movies.FirstOrDefault(movie => movie.Id == id);
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            movie.Id = Guid.NewGuid();
            movies.Add(movie);

            return Ok();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult PutMovie([FromRoute] Guid id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie dataBaseMovie = movies.FirstOrDefault(Movie => Movie.Id == id);
            dataBaseMovie.Clone(movie);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] Guid id)
        {
            movies.Remove(movies.FirstOrDefault(movie => movie.Id == id));
            return Ok();
        }
    }
}
