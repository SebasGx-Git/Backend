namespace PeruStar.API.PeruStar.Domain.Models;

public class FavoriteArtwork
{
    public Hobbyist? Hobbyist{ get; set; }
    public long HobbyistId { get; set; }
    public Artwork? Artwork { get; set; }
    public long ArtworkId { get; set; }
}