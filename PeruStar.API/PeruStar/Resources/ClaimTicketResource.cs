namespace PeruStar.API.PeruStar.Resources;

public class ClaimTicketResource
{
    public long ClaimId { get; set; }
    public string? ClaimSubject { get; set; }
    public string? ClaimDescription { get; set; }
    public DateTime IncidentDate { get; set; }
    public long ReportedPersonId { get; set; }
    public long ReportMadeById { get; set; }
}