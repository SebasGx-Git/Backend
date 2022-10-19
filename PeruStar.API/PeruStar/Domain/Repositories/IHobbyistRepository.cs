using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IHobbyistRepository
{
    Task<IEnumerable<Hobbyist>> ListAsync();
    Task AddAsync(Hobbyist hobbyist);
    Task<Hobbyist> FindById(long id);
    void Update(Hobbyist hobbyist);
    void Remove(Hobbyist hobbyist);
}