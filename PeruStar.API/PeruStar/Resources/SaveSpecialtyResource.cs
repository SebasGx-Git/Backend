using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources
{
    public class SaveSpecialtyResource
    {
        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }
    }
}
