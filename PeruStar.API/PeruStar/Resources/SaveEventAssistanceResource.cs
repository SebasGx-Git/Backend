using System.ComponentModel.DataAnnotations;

namespace PeruStar.API.PeruStar.Resources;

public class SaveEventAssistanceResource
{
    [Required]
    public DateTime AttendanceDay { get; set; }
}