using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitat.EscolaDigital.Session.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Habitat.EscolaDigital.Session.Persistence.Context;

public class EscolaDigitalContext : DbContext
{
    public EscolaDigitalContext(DbContextOptions<EscolaDigitalContext> options) : base(options)
    {        
    }

    public DbSet<NavItem> NavItems { get; set; }
    public DbSet<NavItemRole> NavItemRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NavItem>(entity =>
        {
            entity.HasMany(x => x.Children)
            .WithOne()
            .HasForeignKey(x => x.IdParent);

            entity.HasMany(x => x.Roles)
            .WithOne()
            .HasForeignKey(x => x.IdNavItem);
        });
    }
}
