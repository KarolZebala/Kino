using Kino.Application.Services.ViewModels;
using Kino.Domain.Director.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Application.Services.Director
{
    internal class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<long> CreateAsync(DirectorViewModel modle, CancellationToken cancellationToken)
        {
            var director = Domain.Director.Director.CreateNew(modle.DirectorName, modle.DirectorSurname);
            await _directorRepository.AddAsync(director, cancellationToken);
            await _directorRepository.CommitAsync(cancellationToken);
            return director.DirectorId;
        }

        public async Task<Domain.Director.Director> GetByIdAsync(long directorId, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetByIdNoTrackingAsync(directorId, cancellationToken);
            return director;
        }

        public async Task<IEnumerable<Domain.Director.Director>> GetDirectorsAsync(CancellationToken cancellationToken)
        {
            var directors = await _directorRepository.GetDirectorsAsync(cancellationToken);
            return directors;
        }

        public async Task<long> UpdateAsync(DirectorViewModel modle, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetByIdAsync(modle.DirectorId, cancellationToken);
            director.ChangeMainAttributes(modle.DirectorName, modle.DirectorSurname);
            await _directorRepository.CommitAsync(cancellationToken);
            return director.DirectorId;
        }
    }
}
