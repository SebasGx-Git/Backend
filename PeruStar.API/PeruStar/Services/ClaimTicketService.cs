using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.PeruStar.Domain.Services;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.PeruStar.Services;

public class ClaimTicketService: IClaimTicketService
{
    
    private readonly IClaimTicketRepository _claimTicketRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClaimTicketService(IClaimTicketRepository claimTicketRepository, IUnitOfWork unitOfWork)
    {
        _claimTicketRepository = claimTicketRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClaimTicket>> ListAsync()
    {
        return await _claimTicketRepository.ListAsync();
    }

    public async Task<IEnumerable<ClaimTicket>> ListAsyncByPersonId(long personId)
    {
        return await _claimTicketRepository.ListByPersonIdAsync(personId);
    }

    public async Task<IEnumerable<ClaimTicket>> ListAsyncByReportedPersonId(long personId)
    {
        return await _claimTicketRepository.ListByReportedPersonIdAsync(personId);
    }

    public async Task<ClaimTicketResponse> GetByIdAndPersonIdAsync(long personId, long claimTicketId)
    {
        var existingClaimTicket = await _claimTicketRepository.FindByIdAndPersonId(personId, claimTicketId);

        if (existingClaimTicket.Equals(null))
            return new ClaimTicketResponse("Claim Ticket not found.");

        return new ClaimTicketResponse(existingClaimTicket);
    }

    public async Task<ClaimTicketResponse> SaveAsync(long personId, ClaimTicket claimTicket)
    {
        try
        {
            await _claimTicketRepository.AddAsync(claimTicket);
            await _unitOfWork.CompleteAsync();

            return new ClaimTicketResponse(claimTicket);
        }
        catch (Exception ex)
        {
            return new ClaimTicketResponse($"An error occurred when saving the claim ticket: {ex.Message}");
        }
    }

    public async Task<ClaimTicketResponse> UpdateAsync(long personId, long claimTicketId, ClaimTicket claimTicket)
    {
        var existingClaimTicket = await _claimTicketRepository.FindByIdAndPersonId(personId, claimTicketId);

        if (existingClaimTicket.Equals(null))
            return new ClaimTicketResponse("Claim Ticket not found.");

        existingClaimTicket.ClaimDescription = claimTicket.ClaimDescription;
        existingClaimTicket.ClaimSubject = claimTicket.ClaimSubject;
        existingClaimTicket.IncidentDate = DateTime.Now;

        try
        {
            _claimTicketRepository.Update(existingClaimTicket);
            await _unitOfWork.CompleteAsync();

            return new ClaimTicketResponse(existingClaimTicket);
        }
        catch (Exception ex)
        {
            return new ClaimTicketResponse($"An error occurred when updating the claim ticket: {ex.Message}");
        }
    }

    public async Task<ClaimTicketResponse> DeleteAsync(long personId, long claimTicketId)
    {
        var existingClaimTicket = await _claimTicketRepository.FindByIdAndPersonId(personId, claimTicketId);

        if (existingClaimTicket.Equals(null))
            return new ClaimTicketResponse("Claim Ticket not found.");

        try
        {
            _claimTicketRepository.Remove(existingClaimTicket);
            await _unitOfWork.CompleteAsync();

            return new ClaimTicketResponse(existingClaimTicket);
        }
        catch (Exception ex)
        {
            return new ClaimTicketResponse($"An error occurred when deleting the claim ticket: {ex.Message}");
        }
    }
}