namespace PeruStar.API.PeruStar.Domain.Models;

public class Artist : Person
{
    public string? BrandName { get; set; }
    public string? Description { get; set; }
    public string? Phrase { get; set; }
    public Specialty? SpecialtyArt { get; set; }
    public IList<Artwork> Artworks { get; set; } = new List<Artwork>();
    public IList<Event> Events { get; set; } = new List<Event>();
    public IList<Follower> Followers { get; set; } = new List<Follower>();
    public IList<string> SocialMediaLink { get; set; } = new List<string>();
    public long SpecialtyId { get; set; }
}