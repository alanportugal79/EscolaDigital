using AutoMapper;
using Habitat.EscolaDigital.Session.Application.Common.Exceptions;
using Habitat.EscolaDigital.Session.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Habitat.EscolaDigital.Session.Application.Features.UserProfileFeatures.Get;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, Result<GetUserProfileResponse>>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _Mapper;

    public GetUserProfileHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper )
    {
        _httpContextAccessor = httpContextAccessor;
        _Mapper = mapper;
    }

    public async Task<Result<GetUserProfileResponse>> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
        var user = _httpContextAccessor.HttpContext.User;
        var data = _Mapper.Map<GetUserProfileResponse>(user.UserProfile());
        return new Result<GetUserProfileResponse>(new [] { data }, 1, 1, 1, 1);
    }    
}
