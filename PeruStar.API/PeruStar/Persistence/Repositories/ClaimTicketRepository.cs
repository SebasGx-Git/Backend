using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class ClaimTicketRepository: BaseRepository, IClaimTicketRepository
{
    public ClaimTicketRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ClaimTicket>> ListAsync()
    {
        return await _context.ClaimTickets.ToListAsync();
    }

    public async Task<IEnumerable<ClaimTicket>> ListByPersonIdAsync(long personId)
    {
        return await _context.ClaimTickets
            .Where(p => p.ReportMadeById == personId)
            .Include(p => p.ReportedPerson)
            .ToListAsync();
    }

    public async Task<IEnumerable<ClaimTicket>> ListByReportedPersonIdAsync(long personId)
    {
        return await _context.ClaimTickets
            .Where(p => p.ReportedPersonId == personId)
            .Include(p => p.ReportedPerson)
            .ToListAsync();
    }

    public async Task AddAsync(ClaimTicket claimTicket)
    {
        await _context.ClaimTickets.AddAsync(claimTicket);
    }

    public async Task<ClaimTicket> FindByIdAndPersonId(long id, long personId)
    {
        return (await _context.ClaimTickets
            .Where(p => p.ClaimId == id && p.ReportMadeById == personId)
            .Include(p => p.ReportMadeBy)
            .FirstOrDefaultAsync())!;
    }

    public void Update(ClaimTicket claimTicket)
    {
        _context.ClaimTickets.Update(claimTicket);
    }

    public void Remove(ClaimTicket claimTicket)
    {
        _context.ClaimTickets.Remove(claimTicket);
    }
}