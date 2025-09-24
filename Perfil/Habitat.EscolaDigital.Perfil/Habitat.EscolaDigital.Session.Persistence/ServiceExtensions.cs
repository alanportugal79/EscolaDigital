using Habitat.EscolaDigital.Session.Application.Repository;
using Habitat.EscolaDigital.Session.Application.Repository.NavItemRepository;
using Habitat.EscolaDigital.Session.Persistence.Context;
using Habitat.EscolaDigital.Session.Persistence.Repository;
using Habitat.EscolaDigital.Session.Persistence.Repository.NavItemRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Habitat.EscolaDigital.Session.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("EscolaDigitalContext");
        services.AddDbContext<EscolaDigitalContext>(options => options.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<INavItemRepository, NavItemRepository>();
    }
}
