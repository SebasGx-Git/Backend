using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.PeruStar.Domain.Repositories;

public interface IClaimTicketRepository
{
    Task<IEnumerable<ClaimTicket>> ListAsync();
    Task<IEnumerable<ClaimTicket>> ListByPersonIdAsync(long personId);
    Task<IEnumerable<ClaimTicket>> ListByReportedPersonIdAsync(long personId);
    Task AddAsync(ClaimTicket claimTicket);
    Task<ClaimTicket> FindByIdAndPersonId(long id, long personId);
    void Update(ClaimTicket claimTicket);
    void Remove(ClaimTicket claimTicket);

}