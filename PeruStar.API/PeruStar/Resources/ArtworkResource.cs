namespace PeruStar.API.PeruStar.Resources;

public class ArtworkResource
{
    public long ArtworkId { get; set; }
    public string? ArtTitle { get; set; }
    public string? ArtDescription { get; set; }
    public double ArtCost { get; set; }
    public string? LinkInfo { get; set; }
    public long ArtistId { get; set; }
}