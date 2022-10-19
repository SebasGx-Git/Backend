using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class HobbyistRepository : BaseRepository, IHobbyistRepository
{
    public HobbyistRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Hobbyist>> ListAsync()
    {
        return await _context.Hobbyists.ToListAsync();
    }

    public async Task AddAsync(Hobbyist hobbyist)
    {
        await _context.Hobbyists.AddAsync(hobbyist);
    }

    public async Task<Hobbyist> FindById(long id)
    {
        return (await _context.Hobbyists.FindAsync(id))!;
    }

    public void Update(Hobbyist hobbyist)
    {
        _context.Hobbyists.Update(hobbyist);
    }

    public void Remove(Hobbyist hobbyist)
    {
        _context.Hobbyists.Remove(hobbyist);
    }
}