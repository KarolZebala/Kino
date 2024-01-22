using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.MovieItem
{
    public class MovieItem
    {
        public static MovieItem CreateNew(DateTime startDate, int maxViewers, Movie.Movie movie)
        {
            return new MovieItem(startDate, maxViewers, movie);
        }
        public long MovieItemId { get; set; }
        public long MovieId { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxViewers { get; set; }
        public virtual Movie.Movie Movie { get; set; }

        private MovieItem() { }
        private MovieItem(DateTime startDate, int maxViewers, Movie.Movie movie)
        {
            StartDate = startDate;
            MaxViewers = maxViewers;
            Movie = movie;
        }



    }
}
