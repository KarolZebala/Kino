using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.Actor.Interfaces
{
    public interface IActorRepository
    {
        Task<Actor> AddASync(Actor actor, CancellationToken cancellationToken);
        Task<Actor> GetByIdAsync(long actorId, CancellationToken cancellationToken);
        Task<Actor> GetByIdNoTrackingAsync(long actorId, CancellationToken cancellationToken);
        Task<IEnumerable<Actor>> GetActors(CancellationToken cancellationToken);
        Task<long> CommitAsync(CancellationToken cancellationToken);
    }
}
