using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.MovieItem.Interfaces
{
    public interface IMovieItemRepository
    {
        Task<MovieItem> GetMovieItemByIdAsync(long movieItemId, CancellationToken cancellationToken);
        Task<IEnumerable<MovieItem>> GetAllMovieItemsAsync(CancellationToken cancellationToken);
        Task<MovieItem> AddAsync(MovieItem movieItem, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task<MovieItem> GetMovieItemByIdAsNoTrackingAsync(long movieItemID, CancellationToken cancellationToken);
    }
}
