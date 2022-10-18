using PeruStar.API.Shared.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;

namespace PeruStar.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}