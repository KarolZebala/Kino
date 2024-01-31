using Kino.Domain.Movie;
using Kino.Domain.Movie.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly KinoDbContext _context;

        public MovieRepository(KinoDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddAsync(Movie movie, CancellationToken cancellationToken)
        {
            var res = await _context.Movies.AddAsync(movie, cancellationToken);
            return res.Entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res;
        }

        public async Task<Movie> GetMovieByIdAsync(long movieId, CancellationToken cancellationToken)
        {
            var res = await _context.Movies
                .Include(x => x.Director)
                .Include(x => x.Actors)
                .FirstOrDefaultAsync(x => x.MovieId == movieId, cancellationToken);
            return res;
        }
        public async Task<Movie> GetByIdNoTrackingAsync(long movieId, CancellationToken cancellationToken)
        {
            var res = await _context.Movies
                .Include(x => x.Director)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MovieId == movieId, cancellationToken);
            return res;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken cancellationToken)
        {
            var res = await _context.Movies
                .AsNoTracking()
                .Include(x => x.Director)
                .Include(x => x.Reviews)
                .Include(x => x.MovieVersions)
                .Include(x => x.MovieComents)
                //.Include(x => x.Actors)
                .ToListAsync(cancellationToken);
            return res.AsEnumerable();
        }

        public void RemoveAsync(Movie movie)
        { 
            _context.Movies.Remove(movie);
        }
    }
}
