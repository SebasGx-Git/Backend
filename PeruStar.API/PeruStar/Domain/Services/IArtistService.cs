using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IArtistService
{
    Task<IEnumerable<Artist>> ListAsync();
    Task<IEnumerable<Artist>> ListByHobbyistIdAsync(int hobbyistId);
    Task<ArtistResponse> GetByIdAsync(long id);
    Task<ArtistResponse> SaveAsync(Artist artist);
    Task<ArtistResponse> UpdateAsync(long id, Artist artist);
    Task<ArtistResponse> DeleteAsync(long id);
    Task<bool> IsSameBrandingName(string brandingName);
}