namespace PeruStar.API.PeruStar.Domain.Models;

public class Person
{
    public long Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public IList<ClaimTicket> ClaimTickets { get; set; } = new List<ClaimTicket>();  //Reports that the Person makes
    public IList<ClaimTicket> ReportsClaimTickets { get; set; } = new List<ClaimTicket>();  //Reports you make to the person
}