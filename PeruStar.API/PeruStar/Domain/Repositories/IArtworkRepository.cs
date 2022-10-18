using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IArtworkRepository
{
    Task<IEnumerable<Artwork>> ListAsync();
    Task AddAsync(Artwork artwork);
    Task<Artwork> FindByIdAndArtistIdAsync(long id, long artistId);
    Task<IEnumerable<Artwork>> ListByArtistIdAsync(long artistId);
    void Update(Artwork artwork);
    void Remove(Artwork artwork);
    Task<bool> IsSameTitle(string title, long artistId);
}