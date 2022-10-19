using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task AddAsync(Specialty specialty);
        Task<Specialty> FindById(long id);
        void Update(Specialty specialty);
        void Remove(Specialty specialty);
    }
}
