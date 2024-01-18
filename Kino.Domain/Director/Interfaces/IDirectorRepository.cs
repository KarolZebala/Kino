using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Domain.Director.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> AddAsync(Director director, CancellationToken cancellationToken);
        Task<int> CommitAsync(CancellationToken cancellationToken);
        Task<Director> GetByIdAsync(long directorId, CancellationToken cancellationToken);
        Task<Director> GetByIdNoTrackingAsync(long directorId, CancellationToken cancellationToken);
        Task<IEnumerable<Director>> GetDirectorsAsync(CancellationToken cancellationToken);
    }
}
