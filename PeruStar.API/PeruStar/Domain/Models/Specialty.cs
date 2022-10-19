namespace PeruStar.API.PeruStar.Domain.Models;

public class Specialty
{
    public long SpecialtyId { get; set; }
    public string? Name { get; set; }
    public IList<Interest> Interests { get; set; } = new List<Interest>();
    public IList<Artist> Artists { get; set; } = new List<Artist>();
}