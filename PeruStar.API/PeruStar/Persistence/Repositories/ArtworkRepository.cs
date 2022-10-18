using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class ArtworkRepository: BaseRepository, IArtworkRepository
{
    public ArtworkRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Artwork>> ListAsync()
    {
        return await _context.Artworks.ToListAsync();
    }

    public async Task AddAsync(Artwork artwork)
    {
        await _context.Artworks.AddAsync(artwork);
    }

    public async Task<Artwork> FindByIdAndArtistIdAsync(long id, long artistId)
    {
        return (await _context.Artworks
            .Where(a => a.ArtworkId == id && a.ArtistId == artistId)
            .FirstOrDefaultAsync())!;
    }


    public async Task<IEnumerable<Artwork>> ListByArtistIdAsync(long artistId)
    {
        return await _context.Artworks.Where(a => a.ArtistId == artistId).ToListAsync();
    }

    public void Update(Artwork artwork)
    {
        _context.Artworks.Update(artwork);
    }

    public void Remove(Artwork artwork)
    {
        _context.Artworks.Remove(artwork);
    }

    public async Task<bool> IsSameTitle(string title, long artistId)
    {
        return await _context.Artworks.AnyAsync(a => a.ArtTitle == title && a.ArtistId == artistId);
    }
}