using AutoMapper;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Artist, ArtistResource>();
        CreateMap<Artwork, ArtworkResource>();
        CreateMap<ClaimTicket, ClaimTicketResource>();
        CreateMap<Event, EventResource>();
        CreateMap<EventAssistance, EventAssistanceResource>();
        CreateMap<FavoriteArtwork, FavoriteArtworkResource>();
        CreateMap<Person, PersonResource>();
        CreateMap<Specialty, SpecialtyResource>();
        CreateMap<Hobbyist, HobbyistResource>();
    }
}