using Microsoft.EntityFrameworkCore;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Security.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.Security.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return (await _context.Users.FindAsync(id))!;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return (await _context.Users.FirstOrDefaultAsync(u => u.Email == email))!;
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }
}