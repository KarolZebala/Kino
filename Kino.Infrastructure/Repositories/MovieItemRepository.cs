using Kino.Domain.MovieItem;
using Kino.Domain.MovieItem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure.Repositories
{
    internal class MovieItemRepository : IMovieItemRepository
    {
        private readonly KinoDbContext _context;

        public MovieItemRepository(KinoDbContext context)
        {
            _context = context;
        }

        public async Task<MovieItem> AddAsync(MovieItem movieItem, CancellationToken cancellationToken)
        {
            var res = await _context.MovieItems.AddAsync(movieItem, cancellationToken);
            return res.Entity;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<MovieItem>> GetAllMovieItemsAsync(CancellationToken cancellationToken)
        {
            var res = await _context.MovieItems
                .AsNoTracking()
                .Include(x => x.Movie)
                .ToListAsync();
            return res.AsEnumerable();
        }

        public Task<MovieItem> GetMovieItemByIdAsNoTrackingAsync(long movieItemID, CancellationToken cancellationToken)
        {
            var res = _context.MovieItems
                .AsNoTracking()
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.MovieItemId == movieItemID);
            return res;
        }

        public Task<MovieItem> GetMovieItemByIdAsync(long movieItemId, CancellationToken cancellationToken)
        {
            var res = _context.MovieItems
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.MovieItemId == movieItemId);
            return res;
        }
    }
}
