using PeruStar.API.Security.Domain.Models;

namespace PeruStar.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    void Update(User user);
    void Delete(User user);
}