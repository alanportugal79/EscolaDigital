namespace Habitat.EscolaDigital.Session.Application.Features.NavItemFeatures.GetForMenu;

public class GetForMenuNavItemResponse
{
    public long Id { get; set; }
    public Guid IdGuid { get; set; }
    public string DisplayName { get; set; }
    public bool Disabled { get; set; } = false;
    public bool External { get; set; } = false;
    public bool TwoLines { get; set; } = false;
    public bool Chip { get; set; } = false;
    public string? IconName { get; set; }
    public string? NavCap { get; set; }
    public string? ChipContent { get; set; }
    public string? ChipClass { get; set; }
    public string? Subtext { get; set; }
    public string? Route { get; set; }
    public long? IdParent { get; set; }
    public string? DdType { get; set; }
    public bool? Profiledd { get; set; }
    public bool? App { get; set; }
    public string? Color { get; set; }
    public List<GetForMenuNavItemResponse>? Children { get; set; }
}
