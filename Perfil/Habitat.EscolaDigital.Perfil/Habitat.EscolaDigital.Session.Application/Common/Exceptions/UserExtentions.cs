using System.Security.Claims;
using System.Text.Json;
using Habitat.EscolaDigital.Session.Domain.Entities;

namespace Habitat.EscolaDigital.Session.Application.Common.Exceptions;

public static class UserExtentions
{    

    public static UserProfile UserProfile(this ClaimsPrincipal user)
    {
        const string typeClaimEmail = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        const string typeClaimGivenname = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname";
        const string typeClaimLastname = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname";

        return new UserProfile()
        {
            Email = user.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Claims.FirstOrDefault(x => x.Type == typeClaimEmail)?.Value ?? "",
            EmailVerified = user.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Claims.FirstOrDefault(x => x.Type == "email_verified")?.Value == "true",
            Enabled = user.Identity?.IsAuthenticated,
            FirstName = user.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Claims.FirstOrDefault(x => x.Type == typeClaimGivenname)?.Value ?? "",
            LastName = user.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Claims.FirstOrDefault(x => x.Type == typeClaimLastname)?.Value ?? "",
            Id = user.Identities.FirstOrDefault(id => id.IsAuthenticated)?.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "",
            Username = user.Identities.FirstOrDefault(id => id.IsAuthenticated)?.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value ?? "",
            Name = user.Identities.FirstOrDefault(id => id.IsAuthenticated)?.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? ""
        };
    }

    public static List<string> RoleList(this ClaimsPrincipal user, string resourceName)
    {
        var roles = new List<string>();

        var json = user.Claims?.FirstOrDefault(x => x.Type == "resource_access")?.Value ?? "";
        var jsonDoc = JsonDocument.Parse(json);        
        var userRoles = JsonSerializer.Deserialize<List<string>>(jsonDoc.RootElement.GetProperty(resourceName).GetProperty("roles").GetRawText());
        if (userRoles != null) roles.AddRange(userRoles);
        return roles;
    }
}
