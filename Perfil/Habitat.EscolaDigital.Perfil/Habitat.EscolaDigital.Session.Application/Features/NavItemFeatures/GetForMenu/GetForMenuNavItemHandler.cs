using AutoMapper;
using Habitat.EscolaDigital.Session.Application.Common.Models;
using Habitat.EscolaDigital.Session.Application.Repository.NavItemRepository;
using MediatR;

namespace Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;

public class GetForMenuNavItemHandler : IRequestHandler<GetForMenuNavItemRequest, Result<GetForMenuNavItemResponse>>
{
    private readonly INavItemRepository _NavItemRepository;
    private readonly IMapper _Mapper;

    public GetForMenuNavItemHandler(INavItemRepository navItemRepository, IMapper mapper)
    {
        _NavItemRepository = navItemRepository;
        _Mapper = mapper;
    }

    public async Task<Result<GetForMenuNavItemResponse>> Handle(GetForMenuNavItemRequest request, CancellationToken cancellationToken)
    {
        var NavItems = await _NavItemRepository.GetForMenu(request.Roles, cancellationToken);
        var data = _Mapper.Map<List<GetForMenuNavItemResponse>>(NavItems);
        return new Result<GetForMenuNavItemResponse>(data, data.Count(), 1, 1, data.Count());
    }
}
