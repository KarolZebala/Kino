using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.Movie.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken);
        Task<Movie> GetMovieByIdAsync(long movieId, CancellationToken cancellationToken);
        Task<Movie> GetByIdNoTrackingAsync(long movieId, CancellationToken cancellationToken);
        void RemoveAsync(Movie movie);
        Task<int> CommitAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken);
    }
}
