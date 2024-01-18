using Kino.Application.Services.ViewModels;

namespace Kino.Application.Services.Actor
{
    public interface IActorService
    {
        Task<long> CreateAsync(ActorViewModel model, CancellationToken cancellationToken);
        Task<long> UpdateAsync(ActorViewModel model, CancellationToken cancellationToken);
        Task<Domain.Actor.Actor> GetByIdAsync(long actorId, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Actor.Actor>> GetActorsAsync(CancellationToken cancellationToken);
    }
}