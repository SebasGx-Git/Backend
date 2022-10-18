using PeruStar.API.PeruStar.Domain.Models.Status;

namespace PeruStar.API.PeruStar.Domain.Models;

public class Event
{
    public long EventId { get; set; }
    public string? EventTitle { get; set; }
    public ETypeOfEvent EventType { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public string? EventDescription { get; set; }
    public string? EventAditionalInfo { get; set; }
    public long ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public IList<EventAssistance>  Assistance { get; set; } = new List<EventAssistance>();
}