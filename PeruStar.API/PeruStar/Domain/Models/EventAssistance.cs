namespace PeruStar.API.PeruStar.Domain.Models;

public class EventAssistance
{
    public Event? Event { get; set; }
    public long EventId { get; set; }
    public Hobbyist? Hobbyist { get; set; }
    public long HobbyistId { get; set; }
    public DateTime AttendanceDay { get; set; }
}