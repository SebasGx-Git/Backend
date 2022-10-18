namespace PeruStar.API.PeruStar.Resources;

public class FavoriteArtworkResource
{
    public long HobbyistId { get; set; }
    public ArtworkResource? Artwork { get; set; }
    public long ArtworkId { get; set; }
}