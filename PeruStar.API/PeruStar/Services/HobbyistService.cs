using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class HobbyistService : IHobbyistService
{
    private readonly IHobbyistRepository _hobbyistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HobbyistService(IHobbyistRepository hobbyistRepository, IUnitOfWork unitOfWork)
    {
        _hobbyistRepository = hobbyistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Hobbyist>> ListAsync()
    {
        return await _hobbyistRepository.ListAsync();
    }

    public async Task<HobbyistResponse> GetByIdAsync(long id)
    {
        return new HobbyistResponse(await _hobbyistRepository.FindById(id));
    }

    public async Task<HobbyistResponse> SaveAsync(Hobbyist hobbyist)
    {
        try
        {
            await _hobbyistRepository.AddAsync(hobbyist);
            await _unitOfWork.CompleteAsync();

            return new HobbyistResponse(hobbyist);
        }
        catch (Exception e)
        {
            return new HobbyistResponse($"An error occurred when saving the hobbyist: {e.Message}");
        }
    }

    public async Task<HobbyistResponse> UpdateAsync(long id, Hobbyist hobbyist)
    {
        var existingHobbyist = await _hobbyistRepository.FindById(id);

        if (existingHobbyist.Equals(null))
            return new HobbyistResponse("Hobbyist not found.");
        
        existingHobbyist.Firstname = hobbyist.Firstname;
        existingHobbyist.Lastname = hobbyist.Lastname;

        try
        {
            _hobbyistRepository.Update(existingHobbyist);
            await _unitOfWork.CompleteAsync();

            return new HobbyistResponse(existingHobbyist);
        }
        catch (Exception e)
        {
            return new HobbyistResponse($"An error occurred when updating the hobbyist: {e.Message}");
        }
    }

    public async Task<HobbyistResponse> DeleteAsync(long id)
    {
        var existingHobbyist = await _hobbyistRepository.FindById(id);
        if (existingHobbyist.Equals(null))
            return new HobbyistResponse("Hobbyist not found.");
        
        try
        {
            _hobbyistRepository.Remove(existingHobbyist);
            await _unitOfWork.CompleteAsync();

            return new HobbyistResponse(existingHobbyist);
        }
        catch (Exception e)
        {
            return new HobbyistResponse($"An error occurred when deleting the hobbyist: {e.Message}");
        }
    }
}