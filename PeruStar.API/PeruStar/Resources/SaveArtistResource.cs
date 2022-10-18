using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources;

public class SaveArtistResource

{
    [Required]
    [MaxLength(100)]
    public string? BrandName { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Phrase { get; set; }
    [Required]
    public long SpecialtyId { get; set; }
}
