namespace PeruStar.API.PeruStar.Domain.Models;

public class Follower
{
    public IList<Hobbyist>? Hobbyist { get; set; } = new List<Hobbyist>();
    public long HobbyistId { get; set; }
    public Artist? Artist { get; set; }
    public long ArtistId { get; set; }
    public long FollowerId { get; set; }
}