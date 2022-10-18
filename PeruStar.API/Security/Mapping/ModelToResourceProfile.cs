using AutoMapper;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Security.Domain.Services.Communication;
using PeruStar.API.Security.Resources;

namespace PeruStar.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, UserResource>();
        CreateMap<User, AuthenticateResponse>();
    }
}