using Kino.Application.Services.ViewModels;

namespace Kino.Application.Services.Movie
{
    public interface IMovieService
    {
        Task<long> CrateMovieAsync(MovieViewModel model, CancellationToken cancellationToken);
        Task<long> UpdateMovieAsync(MovieViewModel model, CancellationToken cancellationToken);
        Task<Domain.Movie.Movie> GetMovoieById(long movieId, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Movie.Movie>> GetMovies(CancellationToken cancellationToken);
    }
}