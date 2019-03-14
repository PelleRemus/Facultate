using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie(new List<string>() { "Mircea", "Mihai" }, new List<string>() { "Adventure" }, "Aventurile lui Mircea si Mihai" ),
            new Movie(new List<string>() { "Ion", "Vasile" }, new List<string>{ "Adventure", "Action" }, "Ion si Vasile")
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies/Details/5
        public ActionResult Details(Guid id)
        {
            return View(movies.FirstOrDefault(movie => movie.Id.Equals(id)));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                List<string> actors = collection.Get("Actors").Split(',').ToList();
                List<string> genres = collection.Get("Genres").Split(',').ToList();
                Movie movie = new Movie(actors, genres, collection.Get("Title"));

                movie.PG = int.Parse(collection.Get("PG"));
                movie.Awards = int.Parse(collection.Get("Awards"));
                movie.Director = collection.Get("Director");
                movie.Duration = int.Parse(collection.Get("Duration"));
                movie.ReleaseYear = int.Parse(collection.Get("ReleaseYear"));

                movies.Add(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(movies.FirstOrDefault(movie => movie.Id.Equals(id)));
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Movie movie = movies.FirstOrDefault(Movie => Movie.Id.Equals(id));

                movie.Title = collection.Get("Title");
                movie.PG = int.Parse(collection.Get("PG"));
                movie.Awards = int.Parse(collection.Get("Awards"));
                movie.Director = collection.Get("Director");
                movie.Duration = int.Parse(collection.Get("Duration"));
                movie.ReleaseYear = int.Parse(collection.Get("ReleaseYear"));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(movies.FirstOrDefault(movie => movie.Id.Equals(id)));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                movies.Remove(movies.FirstOrDefault(movie => movie.Id.Equals(id)));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
