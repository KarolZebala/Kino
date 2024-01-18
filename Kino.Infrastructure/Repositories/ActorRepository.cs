using Kino.Domain.Actor;
using Kino.Domain.Actor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kino.Infrastructure.Repositories
{
    internal class ActorRepository : IActorRepository
    {
        private readonly KinoDbContext _context;

        public ActorRepository(KinoDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> AddASync(Actor actor, CancellationToken cancellationToken)
        {
            var res = await _context.Actors.AddAsync(actor, cancellationToken);
            return res.Entity;
        }

        public async Task<long> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Actor>> GetActors(CancellationToken cancellationToken)
        {
            var res = await _context.Actors
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return res.AsEnumerable();
        }

        public async Task<Actor> GetByIdAsync(long actorId, CancellationToken cancellationToken)
        {
            var res = await _context.Actors.FirstOrDefaultAsync(x => x.ActorId == actorId, cancellationToken);
            return res;
        }

        public async Task<Actor> GetByIdNoTrackingAsync(long actorId, CancellationToken cancellationToken)
        {
            var res = await _context.Actors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ActorId == actorId);
            return res;
        }
    }
}
