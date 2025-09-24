namespace Habitat.EscolaDigital.Session.Application.Features.UserProfileFeatures.Get;

public class GetUserProfileResponse
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool? Enabled { get; set; }
    public bool? EmailVerified { get; set; }
    public bool? Totp { get; set; }
}
