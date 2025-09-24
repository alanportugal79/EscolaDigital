using Habitat.EscolaDigital.Session.Application.Common.Models;
using MediatR;

namespace Habitat.EscolaDigital.Session.Application.Features.UserProfileFeatures.Get;

public sealed record GetUserProfileRequest : IRequest<Result<GetUserProfileResponse>>;
