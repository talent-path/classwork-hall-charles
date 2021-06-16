using System;
namespace MovieTracker.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Director { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Movie()
        {
        }

        public Movie(Movie toCopy)
        {
            this.Id = toCopy.Id;
            this.Director = toCopy.Director;
            this.Name = toCopy.Name;
            this.Year = toCopy.Year;
        }
    }
}
