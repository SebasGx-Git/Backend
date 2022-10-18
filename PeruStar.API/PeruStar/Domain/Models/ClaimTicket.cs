namespace PeruStar.API.PeruStar.Domain.Models;

public class ClaimTicket
{
    public long ClaimId { get; set; }
    public string? ClaimSubject { get; set; }
    public string? ClaimDescription { get; set; }
    public DateTime IncidentDate { get; set; }
    public long ReportedPersonId { get; set; }
    public Person? ReportedPerson { get; set; }
    public long ReportMadeById { get; set; }
    public Person? ReportMadeBy { get; set; }
}