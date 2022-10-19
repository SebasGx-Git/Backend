using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IHobbyistService
{
    Task<IEnumerable<Hobbyist>> ListAsync();
    Task<HobbyistResponse> GetByIdAsync(long id);
    Task<HobbyistResponse> SaveAsync(Hobbyist hobbyist);
    Task<HobbyistResponse> UpdateAsync(long id, Hobbyist hobbyist);
    Task<HobbyistResponse> DeleteAsync(long id);
}