using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources;

public class SaveArtworkResource
{
    [Required]
    [MaxLength(100)]
    public string? ArtTitle { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? ArtDescription { get; set; }
    public double ArtCost { get; set; }
    [MaxLength(1000)]
    public string? LinkInfo { get; set; }
}