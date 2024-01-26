using Kino.Application.Services.RequestModels;
using Kino.Application.Services.ViewModels;
using Kino.Domain.Movie.Interfaces;
using Kino.Domain.MovieItem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.MovieItem
{
    public interface IMovieItemService
    {
        Task<long> AddMovieItemAsync(MovieItemViewModel model, CancellationToken cancellationToken);
        Task<Domain.MovieItem.MovieItem> GetMovieItemById(long movieItemID, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.MovieItem.MovieItem>> GetMovieItemsAsync(MovieItemListRequest request, CancellationToken cancellationToken);
        Task<long> UpdateMovieItemAsync(MovieItemViewModel model, CancellationToken cancellationToken);
    }
    internal class MovieItemService : IMovieItemService
    {
        private readonly IMovieItemRepository _movieItemRepository;
        private readonly IMovieRepository _movieRepository;
        public MovieItemService(IMovieItemRepository movieItemRepository, IMovieRepository movieRepository)
        {
            _movieItemRepository = movieItemRepository;
            _movieRepository = movieRepository;
        }

        public async Task<long> AddMovieItemAsync(MovieItemViewModel model, CancellationToken cancellationToken)
        {
            var movieItem = Domain.MovieItem.MovieItem.CreateNew(
                startDate: model.StartDate,
                maxViewers: model.MaxViewers,
                baseTicketPrice: model.BaseTicketPrice,
                actualTicketPrice: model.ActualTicketPrice,
                purchaseTicketPrice: model.PurchaseTicketPrice
            );
            var movie = await _movieRepository.GetMovieByIdAsync(model.MovieId, cancellationToken);
            movieItem.SetMovie(movie);
            await _movieItemRepository.AddAsync(movieItem, cancellationToken);
            await _movieItemRepository.CommitAsync(cancellationToken);
            return movieItem.MovieItemId;
        }

        public async Task<IEnumerable<Domain.MovieItem.MovieItem>> GetMovieItemsAsync(MovieItemListRequest request, CancellationToken cancellationToken)
        {
            var movieItems = await _movieItemRepository.GetAllMovieItemsAsync(cancellationToken);
            if(request.PageIndex.HasValue && request.PageIndex.HasValue)
            {
                movieItems.Skip(request.PageIndex.Value * request.PageSize.Value).Take(request.PageSize.Value);
            }
            return movieItems;
        }

        public async Task<Domain.MovieItem.MovieItem> GetMovieItemById(long movieItemID, CancellationToken cancellationToken)
        {
            var movieItem = await _movieItemRepository.GetMovieItemByIdAsNoTrackingAsync(movieItemID, cancellationToken);
            return movieItem;
        }

        public async Task<long> UpdateMovieItemAsync(MovieItemViewModel model, CancellationToken cancellationToken)
        {
            var movieItem = await _movieItemRepository.GetMovieItemByIdAsync(model.MovieItemId, cancellationToken);

            movieItem.ChangeMainAttributes(model.StartDate, model.MaxViewers);
            movieItem.ChangePriceAttributes(model.BaseTicketPrice, model.ActualTicketPrice, model.PurchaseTicketPrice);

            var movie = await _movieRepository.GetMovieByIdAsync(model.MovieId, cancellationToken);
            movieItem.SetMovie(movie);

            await _movieItemRepository.CommitAsync(cancellationToken);
            return movieItem.MovieItemId;

        }
    }
}
