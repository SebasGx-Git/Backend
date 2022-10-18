using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IArtworkService
{
    Task<IEnumerable<Artwork>> ListAsync();
    Task<IEnumerable<Artwork>> ListByArtistIdAsync(long id);
    Task<ArtworkResponse> FindByIdAndArtistIdAsync(long id, long artistId);
    Task<ArtworkResponse> SaveAsync(long artistId, Artwork artwork);
    Task<ArtworkResponse> UpdateAsync(long id, long artistId, Artwork artwork);
    Task<ArtworkResponse> DeleteAsync(long id, long artistId);
    Task<bool> IsSameTitle(string title, long artistId);
    Task<IEnumerable<Artwork>> ListByHobbyistAsync(long hobbyistId);
}