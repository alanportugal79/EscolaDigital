using Habitat.EscolaDigital.Session.Application.Common.Models;
using MediatR;

namespace Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;

public sealed record GetForMenuNavItemRequest(List<string> Roles) : IRequest<Result<GetForMenuNavItemResponse>>;
