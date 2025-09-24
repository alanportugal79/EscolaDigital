using Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;
using Habitat.EscolaDigital.Session.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Habitat.EscolaDigital.Session.WebApi.Controllers;

public class NavItemController : BaseController
{
    private readonly IMediator _mediator;

    public NavItemController(IMediator mediator) 
    {  
        _mediator = mediator; 
    }

    [HttpGet]
    public async Task<ActionResult<List<GetForMenuNavItemResponse>>> GetForMenu(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetForMenuNavItemRequest(), cancellationToken);
        return Ok(response);
    }
}
