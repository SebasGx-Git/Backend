namespace PeruStar.API.PeruStar.Domain.Models;

public class Artwork
{
    public long ArtworkId { get; set; }
    public string? ArtTitle { get; set; }
    public string? ArtDescription { get; set; }
    public double ArtCost { get; set; }
    public string? LinkInfo { get; set; }
    public long ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public IList<FavoriteArtwork> FavoriteArtworks { get; set; } = new List<FavoriteArtwork>();
}