using Kino.Application.Services.ViewModels;

namespace Kino.Application.Services.Director
{
    public interface IDirectorService
    {
        Task<long> CreateAsync(DirectorViewModel modle, CancellationToken cancellationToken);
        Task<long> UpdateAsync(DirectorViewModel modle, CancellationToken cancellationToken);
        Task<Domain.Director.Director> GetByIdAsync(long directorId, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.Director.Director>> GetDirectorsAsync(RequestModels.DirectorListRequestModel request, CancellationToken cancellationToken);
    }
}