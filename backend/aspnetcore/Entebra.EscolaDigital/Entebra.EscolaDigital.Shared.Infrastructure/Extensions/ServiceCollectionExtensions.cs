using Entebra.EscolaDigital.Shared.Infrastructure.Controllers;
using Entebra.EscolaDigital.Shared.Infrastructure.Persistence;
using Entebra.EsolaDigital.Shared.Domain.Interfaces;
using Entebra.EsolaDigital.Shared.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entebra.EscolaDigital.Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers()
        .ConfigureApplicationPartManager(manager =>
        {
            manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
        });

        services.AddHttpContextAccessor();
        services.AddScoped<ITenantService, TenantService>();
        services.AddDatabaseContext(config);
        return services;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DBED") ?? throw new Exception("Connectionstring DBED não definido");
        
        services.AddScoped<ModuleDbContext>(provider =>
        {
            return provider.GetService(typeof(ITenantService)) is not ITenantService tenantService
                ? throw new Exception("ITenantService não está registrado no provedor de serviços.")
                : new ModuleDbContext(connectionString, tenantService);
        });

        return services;
    }


}

