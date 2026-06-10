using Entebra.EsolaDigital.Shared.Domain.Interfaces;
using Entebra.EsolaDigital.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Entebra.EsolaDigital.Shared.Infrastructure.Services;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public TenantService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetTenantId()
    {
        var UserClaims = _contextAccessor.HttpContext?.User.Claims;
        var tenantId = UserClaims?.FirstOrDefault(c => c.Type == "tenant_id")?.Value ?? throw new CustomException("ID Tenant faltando", null, System.Net.HttpStatusCode.InternalServerError);
        return tenantId;
    }
}
