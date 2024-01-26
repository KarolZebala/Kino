using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.MovieItem
{
    public class MovieItem
    {
        public static MovieItem CreateNew(
            DateTime startDate,
            int maxViewers,
            decimal baseTicketPrice,
            decimal actualTicketPrice,
            decimal purchaseTicketPrice
        )
        {
            return new MovieItem(
                startDate: startDate,
                maxViewers: maxViewers,
                baseTicketPrice: baseTicketPrice,
                actualTicketPrice: actualTicketPrice,
                purchaseTicketPrice: purchaseTicketPrice
            );
        }
        public long MovieItemId { get; protected set; }
        public long MovieId { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public int MaxViewers { get; protected set; }
        public decimal BaseTicketPrice { get; protected set; }
        public decimal ActualTicketPrice { get; protected set; }
        public decimal PurchaseTicketPrice { get; protected set; }
        public virtual Movie.Movie Movie { get; protected set; }

        private MovieItem() { }

        public MovieItem(
            DateTime startDate,
            int maxViewers,
            decimal baseTicketPrice,
            decimal actualTicketPrice,
            decimal purchaseTicketPrice
        )
        {
            StartDate = startDate;
            MaxViewers = maxViewers;
            BaseTicketPrice = baseTicketPrice;
            ActualTicketPrice = actualTicketPrice;
            PurchaseTicketPrice = purchaseTicketPrice;
            
        }
        public void SetMovie(Movie.Movie movie)
        {
            Movie = movie;
            MovieId = movie.MovieId;
        }
        public void ChangeMainAttributes(
            DateTime startDate,
            int maxViewers
        )
        {
            StartDate = startDate;
            MaxViewers = maxViewers;
        }
        public void ChangePriceAttributes(
            decimal baseTicketPrice,
            decimal actualTicketPrice,
            decimal purchaseTicketPrice
        )
        {
            BaseTicketPrice = baseTicketPrice;
            ActualTicketPrice = actualTicketPrice;
            PurchaseTicketPrice = purchaseTicketPrice;
        }
    }
}
