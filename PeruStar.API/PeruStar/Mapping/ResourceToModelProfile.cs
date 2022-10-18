using AutoMapper;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        //CreateMap<SaveRestaurantResource, Restaurant>();
       CreateMap<SaveArtistResource, Artist>();
       CreateMap<SaveArtworkResource, Artwork>();
       CreateMap<SaveClaimTicketResource, ClaimTicket>();
       CreateMap<SaveEventResource, Event>();
       CreateMap<SaveEventAssistanceResource, EventAssistance>();
       CreateMap<SaveFavoriteArtworkResource, FavoriteArtwork>();
       CreateMap<SavePersonResource, PersonResource>();
    }
}