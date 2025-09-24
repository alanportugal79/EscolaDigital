using Habitat.EscolaDigital.Session.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;
using Habitat.EscolaDigital.Session.Application.Common.Exceptions;
using Habitat.EscolaDigital.Session.Application.Features.UserProfileFeatures.Get;

namespace Habitat.EscolaDigital.Session.WebApi.Controllers;

public class SessionController : BaseController
{
    private readonly IMediator _mediator;    

    public SessionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("current-user")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var response =  await _mediator.Send(new GetUserProfileRequest());
        return Ok(response);
    }    

    [HttpGet("menu")]
    [Authorize]
    public async Task<IActionResult> GetMenu(CancellationToken cancellationToken)
    {
        var roles = User.RoleList("session_api");
        var response = await _mediator.Send(new GetForMenuNavItemRequest(roles), cancellationToken);
        return Ok(response);
    }

}
