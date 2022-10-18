using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources;

public class SavePersonResource
{
    [Required]
    [MaxLength(100)]
    public string? Firstname { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Lastname { get; set; }
}