using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Domain.Entities;

namespace Habitat.EscolaDigital.Session.Application.Repository.NavItemRepository;

public interface INavItemRepository : IBaseRepository<NavItem>
{
    Task<List<NavItem>> GetForMenu(List<string> roles, CancellationToken cancellationToken);
}
