using AutoMapper;
using Habitat.EscolaDigital.Session.Domain.Entities;

namespace Habitat.EscolaDigital.Session.Application.Features.UserProfileFeatures.Get;

public class GetUserProfileMapper : Profile
{
    public GetUserProfileMapper()
    {
        CreateMap<UserProfile, GetUserProfileResponse>();
    }
}
