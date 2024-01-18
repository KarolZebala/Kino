using Kino.Application.Services.ViewModels;
using Kino.Domain.Actor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.Actor
{
    internal class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<long> CreateAsync(ActorViewModel model, CancellationToken cancellationToken)
        {
            var actor = Domain.Actor.Actor.CreateNew(model.ActorName, model.ActorSurname);
            await _actorRepository.AddASync(actor, cancellationToken);
            await _actorRepository.CommitAsync(cancellationToken);
            return actor.ActorId;
        }

        public async Task<IEnumerable<Domain.Actor.Actor>> GetActorsAsync(CancellationToken cancellationToken)
        {
            var actors = await _actorRepository.GetActors(cancellationToken);
            return actors;
        }

        public async Task<Domain.Actor.Actor> GetByIdAsync(long actorId, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetByIdNoTrackingAsync(actorId, cancellationToken);
            return actor;
        }

        public async Task<long> UpdateAsync(ActorViewModel model, CancellationToken cancellationToken)
        {
            var actor = await _actorRepository.GetByIdAsync(model.ActorId, cancellationToken);
            if (actor is null)
            {
                throw new ArgumentException("Not found actor");
            }
            actor.ChangeMainAttributes(model.ActorName, model.ActorSurname);

            await _actorRepository.CommitAsync(cancellationToken);
            return actor.ActorId;
        }
    }
}
