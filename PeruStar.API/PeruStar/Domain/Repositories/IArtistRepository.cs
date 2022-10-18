using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Artist>> ListAsync();
    Task AddAsync(Artist artist);
    Task<Artist> FindById(long id);
    void Update(Artist artist);
    void Remove(Artist artist);
    Task<bool> IsSameBrandingName(string brandingName);
}