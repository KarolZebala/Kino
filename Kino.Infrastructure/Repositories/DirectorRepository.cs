using Kino.Domain.Director;
using Kino.Domain.Director.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Infrastructure.Repositories
{
    internal class DirectorRepository : IDirectorRepository
    {
        private readonly KinoDbContext _context;

        public DirectorRepository(KinoDbContext context)
        {
            _context = context;
        }

        public async Task<Director> AddAsync(Director director, CancellationToken cancellationToken)
        {
            var res = await _context.Directros.AddAsync(director, cancellationToken);
            return res.Entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Director> GetByIdAsync(long directorId, CancellationToken cancellationToken)
        {
            var res = await _context.Directros.FirstOrDefaultAsync(x => x.DirectorId == directorId, cancellationToken);
            return res;
        }
        public async Task<Director> GetByIdNoTrackingAsync(long directorId, CancellationToken cancellationToken)
        {
            var res = await _context.Directros
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DirectorId == directorId, cancellationToken);
            return res;
        }

        public async Task<IEnumerable<Director>> GetDirectorsAsync(CancellationToken cancellationToken)
        {
            var res = await _context.Directros
                .AsNoTracking()
                .ToListAsync();
            return res.AsEnumerable();
        }
    }
}
