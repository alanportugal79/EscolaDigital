using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Application.Repository.NavItemRepository;
using Habitat.EscolaDigital.Session.Domain.Entities;
using Habitat.EscolaDigital.Session.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Habitat.EscolaDigital.Session.Persistence.Repository.NavItemRepository;

public class NavItemRepository : BaseRepository<NavItem>, INavItemRepository
{
    public NavItemRepository(EscolaDigitalContext context) : base(context) { }
    
    public async Task<List<NavItem>> GetForMenu(List<string> roles, CancellationToken cancellationToken)
    {
        var fullResult = await Context
            .NavItems
            .Include(x => x.Children)
            .Include(x => x.Roles)
            .Where(x => x.Roles == null || x.Roles.Any(r => roles.Contains(r.RoleName)))
            .ToListAsync();

        var navItems = fullResult.Where(c => c.IdParent == null || c.IdParent == 0).ToList();        

        return navItems;
    }
}
