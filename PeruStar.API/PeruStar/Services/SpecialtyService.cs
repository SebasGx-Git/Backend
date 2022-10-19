using AutoMapper;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services
{
    public class SpecialtyService : ISpecialtyService 
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialtyService(ISpecialtyRepository specialtyRepository, IUnitOfWork unitOfWork)
        {
            _specialtyRepository = specialtyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Specialty>> ListAsync()
        {
            return await _specialtyRepository.ListAsync();
        }

        public async Task<SpecialtyResponse> GetByIdAsync(long id)
        {
            var existingSpecialty = await _specialtyRepository.FindById(id);

            if (existingSpecialty.Equals(null))
                return new SpecialtyResponse("Specialty not found.");

            return new SpecialtyResponse(existingSpecialty);
        }

        public async Task<SpecialtyResponse> SaveAsync(Specialty specialty)
        {
            try
            {
                await _specialtyRepository.AddAsync(specialty);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(specialty);
            }
            catch (Exception ex)
            {
                return new SpecialtyResponse($"An error occurred when saving the specialty: {ex.Message}");
            }
        }

        public async Task<SpecialtyResponse> UpdateAsync(long id, Specialty specialty)
        {
            var existingSpecialty = await _specialtyRepository.FindById(id);

            if (existingSpecialty.Equals(null))
                return new SpecialtyResponse("Specialty not found.");

            existingSpecialty.Name = specialty.Name;

            try
            {
                _specialtyRepository.Update(existingSpecialty);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(existingSpecialty);
            }
            catch (Exception ex)
            {
                return new SpecialtyResponse($"An error occurred when updating the specialty: {ex.Message}");
            }
        }

        public async Task<SpecialtyResponse> DeleteAsync(long id)
        {
            var existingSpecialty = await _specialtyRepository.FindById(id);

            if (existingSpecialty.Equals(null))
                return new SpecialtyResponse("Specialty not found.");

            try
            {
                _specialtyRepository.Remove(existingSpecialty);
                await _unitOfWork.CompleteAsync();

                return new SpecialtyResponse(existingSpecialty);
            }
            catch (Exception ex)
            {
                return new SpecialtyResponse($"An error occurred when deleting the specialty: {ex.Message}");
            }
        }
    }
}
