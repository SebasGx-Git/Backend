using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> ListAsync();
        Task<SpecialtyResponse> GetByIdAsync(long id);
        Task<SpecialtyResponse> SaveAsync(Specialty specialty);
        Task<SpecialtyResponse> UpdateAsync(long id, Specialty specialty);
        Task<SpecialtyResponse> DeleteAsync(long id);
    }
}
