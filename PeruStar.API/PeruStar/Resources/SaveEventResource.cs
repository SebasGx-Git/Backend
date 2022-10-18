using System.ComponentModel.DataAnnotations;
using PeruStar.API.PeruStar.Domain.Models.Status;

namespace PeruStar.API.PeruStar.Resources;

public class SaveEventResource
{
    [Required]
    [MaxLength(100)]
    public string? EventTitle { get; set; }
    [Required]
    public ETypeOfEvent EventType { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateStart { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime DateEnd { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? EventDescription { get; set; }
    public string? EventAditionalInfo { get; set; }
}