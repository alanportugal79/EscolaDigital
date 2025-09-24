using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Domain.Common;

namespace Habitat.EscolaDigital.Session.Domain.Entities;

[Table("tb_nav_item_role", Schema = "session")]
public class NavItemRole: BaseAuditableEntity
{
    [Column("id_nav_item")]
    public long IdNavItem { get; set; }

    [Column("role_name")]
    public string RoleName { get; set; }    
}
