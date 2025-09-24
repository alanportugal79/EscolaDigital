using AutoMapper;
using Habitat.EscolaDigital.Session.Domain.Entities;

namespace Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;

public class GetForMenuNavItemMapper : Profile
{
    public GetForMenuNavItemMapper() 
    {
        CreateMap<NavItem, GetForMenuNavItemResponse>();
    }
}
