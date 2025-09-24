using System.ComponentModel.DataAnnotations.Schema;
using Habitat.EscolaDigital.Session.Domain.Common;

namespace Habitat.EscolaDigital.Session.Domain.Entities;

[Table("tb_nav_item", Schema = "session")]
public class NavItem: BaseAuditableEntity
{
    [Column("display_name")]
    public string DisplayName { get; set; }

    [Column("disabled")]
    public bool Disabled { get; set; } = false;

    [Column("external")]
    public bool External { get; set; } = false;

    [Column("two_lines")]
    public bool TwoLines { get; set; } = false;

    [Column("chip")]
    public bool Chip { get; set; } = false;

    [Column("icon_name")]
    public string? IconName { get; set; }

    [Column("nav_cap")]
    public string? NavCap { get; set; }

    [Column("chip_content")]
    public string? ChipContent { get; set; }

    [Column("chip_class")]
    public string? ChipClass { get; set; }

    [Column("sub_text")]
    public string? Subtext { get; set; }

    [Column("route")]
    public string? Route { get; set; }

    [Column("id_parent")]
    public long? IdParent { get; set; }

    [Column("dd_type")]
    public string? DdType { get; set; }

    [Column("profiledd")]
    public bool? Profiledd { get; set; }

    [Column("app")]
    public bool? App { get; set; }

    [Column("color")]
    public string? Color { get; set; }
    
    public List<NavItem>? Children { get; set; }

    public List<NavItemRole>? Roles { get; set; }
}
