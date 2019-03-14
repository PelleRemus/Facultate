using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public List<string> Actors;

        public List<string> Genres;

        public string Title { get; set; }

        public int PG { get; set; }

        public int Awards { get; set; }

        public string Director { get; set; }

        public int Duration { get; set; }

        public int ReleaseYear { get; set; }

        public Movie(List<string> Actors, List<string> Genres, string Title, int PG = 13, 
            int Awards = 0, string Director = "Vlad", int Duration = 120, int ReleaseYear = 2000)
        {
            this.Id = Guid.NewGuid();
            this.Actors = Actors;
            this.Genres = Genres;
            this.Title = Title;
            this.PG = PG;
            this.Awards = Awards;
            this.Director = Director;
            this.Duration = Duration;
            this.ReleaseYear = ReleaseYear;
        }
    }
}