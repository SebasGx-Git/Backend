using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class ArtistRepository : BaseRepository, IArtistRepository
{
    public ArtistRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Artist>> ListAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task AddAsync(Artist artist)
    {
        await _context.Artists.AddAsync(artist);
    }

    public async Task<Artist> FindById(long id)
    {
        return (await _context.Artists.FindAsync(id))!;
    }

    public void Update(Artist artist)
    {
        _context.Artists.Update(artist);
    }

    public void Remove(Artist artist)
    {
        _context.Artists.Remove(artist);
    }

    public async Task<bool> IsSameBrandingName(string brandingName)
    {
        return await _context.Artists.AnyAsync(x => x.BrandName == brandingName);
    }
}