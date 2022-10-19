using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories
{
    public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
    {
        public SpecialtyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Specialty>> ListAsync()
        {
            return await _context.Specialties.ToListAsync();
        }

        public async Task AddAsync(Specialty specialty)
        {
            await _context.Specialties.AddAsync(specialty);
        }

        public async Task<Specialty> FindById(long id)
        {
            return (await _context.Specialties.FindAsync(id))!;
        }

        public void Update(Specialty specialty)
        {
            _context.Specialties.Update(specialty);
        }

        public void Remove(Specialty specialty)
        {
            _context.Specialties.Remove(specialty);
        }
    }
}
