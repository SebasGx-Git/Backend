using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources;

public class SaveClaimTicketResource
{
    [Required]
    [MaxLength(100)]
    public string? ClaimSubject { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? ClaimDescription { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime IncidentDate { get; set; }
    [Required]
    public long ReportedPersonId { get; set; }
}