using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources
{
    public class SaveFollowerResource
    {
        [Required]
        public long ArtistId { get; set; }
    }
}
