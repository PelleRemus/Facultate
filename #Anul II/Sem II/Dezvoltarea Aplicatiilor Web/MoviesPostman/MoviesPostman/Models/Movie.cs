using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MoviesPostman.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string[] Actors;

        public string[] Genres;

        [Required(ErrorMessage = "Please insert a title for your movie")]
        public string Title { get; set; }

        public int PG { get; set; }

        public int Awards { get; set; }

        [Required(ErrorMessage = "A movie must have a director")]
        public string Director { get; set; }

        public int Duration { get; set; }

        public int ReleaseYear { get; set; }

        public void Clone(Movie model)
        {
            PropertyInfo[] properties = model.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].SetValue(this, properties[i].GetValue(model));
            }
        }
    }
}
